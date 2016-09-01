using System;
using System.Collections.Generic;
using System.Globalization;
using System.Xml;

namespace SalaryLibrary
{
	public class SalaryAccount
	{
		private uint _id = 0;
		private Employee _employee = null;
		private Dictionary<SalaryType, SalaryItem> _salaries = new Dictionary<SalaryType, SalaryItem>();
		private double _wageTax = 0.0;
		private double _solidarityTax = 0.0;
		private double _sicknessInsurance = 0.0;
		private double _annuityInsurance = 0.0;
		private double _unemploymentInsurance = 0.0;
		private double _compulsoryLongTermCareInsurance = 0.0;

		public uint Id { get { return this._id; }
			set {
				if(value == 0) {
					throw new ArgumentException("Salary.Id must be greater than 0!");
				}

				this._id = value;
			}
		}
		public Employee Employee { get { return this._employee; } }
		public Dictionary<SalaryType, SalaryItem> Salaries { get { return this._salaries; } }
		/// <summary>
		/// Lohnsteuer
		/// </summary>
		public double WageTax { get { return this._wageTax; } set { this._wageTax = value; } }
		/// <summary>
		/// Solidaritätszuschlag
		/// </summary>
		public double SolidarityTax { get { return this._solidarityTax; } set { this._solidarityTax = value; } }
		/// <summary>
		/// Krankenversicherung
		/// </summary>
		public double SicknessInsurance { get { return this._sicknessInsurance; } set { this._sicknessInsurance = value; } }
		/// <summary>
		/// Rentenversicherung
		/// </summary>
		public double AnnuityInsurance { get { return this._annuityInsurance; } set { this._annuityInsurance = value; } }
		/// <summary>
		/// Arbeitslosenversicherung
		/// </summary>
		public double UnemploymentInsurance { get { return this._unemploymentInsurance; } set { this._unemploymentInsurance = value; } }
		/// <summary>
		/// Pflegeversicherung
		/// </summary>
		public double CompulsoryLongTermCareInsurance { get { return this._compulsoryLongTermCareInsurance; } set { this._compulsoryLongTermCareInsurance = value; } }
		/// <summary>
		/// Nettolohn
		/// </summary>
		public double NetWage {
			get {
				var finalSubtraction = 0.0;

				var netWage = 0.0;
				foreach(var salaryItem in this._salaries) {
					netWage += salaryItem.Value.Amount;
					if(salaryItem.Key == SalaryType.BezugVWLlfd) {
						finalSubtraction += salaryItem.Value.Amount;
					}
				}
				netWage -= this.AnnuityInsurance;
				netWage -= this.CompulsoryLongTermCareInsurance;
				netWage -= this.SicknessInsurance;
				netWage -= this.SolidarityTax;
				netWage -= this.UnemploymentInsurance;
				netWage -= this.WageTax;

				netWage -= finalSubtraction;

				return netWage;
			}
		}

		public SalaryAccount(Employee employee)
		{
			if(employee == null) {
				throw new ArgumentNullException("employee", "Parameter \"employee\" cannot be null.");
			}

			this._employee = employee;
		}

		public SalaryAccount(XmlNode node)
		{
			var idAttr = node.Attributes.GetNamedItem("id");
			if(idAttr != null) {
				this.Id = Convert.ToUInt32(idAttr.Value);
			}

			if(node.ChildNodes != null) {
				var culture = CultureInfo.CreateSpecificCulture("en-US");
				foreach(XmlNode childNode in node.ChildNodes) {
					switch(childNode.Name) {
						case "annuity-insurance":
							this.AnnuityInsurance = Convert.ToDouble(childNode.InnerText, culture);
							break;

						case "compulsory-long-term-care-insurance":
							this.CompulsoryLongTermCareInsurance = Convert.ToDouble(childNode.InnerText, culture);
							break;

						case "unemployment-insurance":
							this.UnemploymentInsurance = Convert.ToDouble(childNode.InnerText, culture);
							break;

						case "salaries":
							if (childNode.ChildNodes != null) {
								foreach(XmlNode salaryNode in childNode.ChildNodes) {
									switch(salaryNode.Name) {
										case "salary":
											var typeAttr = salaryNode.Attributes.GetNamedItem("type");
											var amountAttr = salaryNode.Attributes.GetNamedItem("amount");
											if (typeAttr != null && amountAttr != null) {
												var salaryType = (SalaryType)Convert.ToInt32(typeAttr.Value);
												var salaryAmount = Convert.ToDouble(amountAttr.Value, culture);
												this._salaries.Add(salaryType, new SalaryItem(salaryAmount));
											}
											break;
									}
								}
							}
							break;

						case "sickness-insurance":
							this.SicknessInsurance = Convert.ToDouble(childNode.InnerText, culture);
							break;

						case "solidarity-tax":
							this.SolidarityTax = Convert.ToDouble(childNode.InnerText, culture);
							break;

						case "wage-tax":
							this.WageTax = Convert.ToDouble(childNode.InnerText, culture);
							break;
					}
				}
			}
		}

		public override bool Equals(object obj)
		{
			if (obj == null) {
				return false;
			}

			var s = obj as SalaryAccount;
			if ((object)s == null) {
				return false;
			}

			return this == s;
		}

		public override int GetHashCode()
		{
			return base.GetHashCode();
		}

		public static bool operator ==(SalaryAccount a, SalaryAccount b)
		{
			if (Object.ReferenceEquals(a, b)) {
				return true;
			}

			if (((object)a == null) || ((object)b == null)) {
				return false;
			}

			if(a.AnnuityInsurance != b.AnnuityInsurance ||
				a.CompulsoryLongTermCareInsurance != b.CompulsoryLongTermCareInsurance ||
				a.NetWage != b.NetWage ||
				a.SicknessInsurance != b.SicknessInsurance ||
				a.SolidarityTax != b.SolidarityTax ||
				a.UnemploymentInsurance != b.UnemploymentInsurance ||
				a.WageTax != b.WageTax) {
				return false;
			}
			if (a.Salaries.Count != b.Salaries.Count) {
				return false;
			}

			return true;
		}

		public static bool operator !=(SalaryAccount a, SalaryAccount b)
		{
			return !(a == b);
		}
	}
}
