using System;
using System.Linq;
using System.Collections.Generic;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Xml;

namespace SalaryLibrary
{
	public class SalaryAccount : ICloneable
	{
		private object _id = null;
		private Employee _employee = null;
		private DateTime _periodStart = DateTime.Now;
		private DateTime _periodEnd = DateTime.Now;
		private Dictionary<SalaryType, SalaryItem> _salaries = new Dictionary<SalaryType, SalaryItem>();
		private List<SalaryType> _salaryTypes = new List<SalaryType>();
		private double _wageTax = 0.0;
		private double _churchTax = 0.0;
		private double _solidarityTax = 0.0;
		private double _sicknessInsurance = 0.0;
		private double _annuityInsurance = 0.0;
		private double _unemploymentInsurance = 0.0;
		private double _compulsoryLongTermCareInsurance = 0.0;

		public object Id { get { return this._id; } set { this._id = value; } }
		public Employee Employee { get { return this._employee; } }
		public DateTime PeriodStart { get { return this._periodStart; } set { this._periodStart = value; } }
		public DateTime PeriodEnd { get { return this._periodEnd; } set { this._periodEnd = value; } }
		public string FormattedPeriod {
			get {
				var periodString = String.Format("{0}-{1:00}", this.PeriodStart.Year, this.PeriodStart.Month);
				if(this.PeriodStart.Day != 1 ||
					this.PeriodEnd.Day != DateTime.DaysInMonth(this.PeriodStart.Year, this.PeriodStart.Month)) {
					periodString += String.Format("-{0:00} - {1}-{2:00}-{3:00}", this.PeriodStart.Day, this.PeriodEnd.Year, this.PeriodEnd.Month, this.PeriodEnd.Day);
				}

				return periodString;
			}
		}
		public Dictionary<SalaryType, SalaryItem> Salaries { get { return this._salaries; } }
		/// <summary>
		/// Lohnsteuer
		/// </summary>
		public double WageTax { get { return this._wageTax; } set { this._wageTax = value; } }
		/// <summary>
		/// Kirchensteuer
		/// </summary>
		public double ChurchTax { get { return this._churchTax; } set { this._churchTax = value; } }
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
		
		public double GrossWage {
			get {
				return this._salaries.Sum(s => s.Value.Amount);
			}
		}

		public double NetWage {
			get {
				var netWage = this.GrossWage;
				var finalSubtraction = this._salaries.Sum(s => s.Key.DiscountOnNetWage ? s.Value.Amount : 0.0);

				netWage -= this.AnnuityInsurance;
				netWage -= this.CompulsoryLongTermCareInsurance;
				netWage -= this.SicknessInsurance;
				netWage -= this.SolidarityTax;
				netWage -= this.UnemploymentInsurance;
				netWage -= this.WageTax;
				netWage -= this.ChurchTax;
				
				netWage -= finalSubtraction;

				return netWage;
			}
		}

		public SalaryAccount(List<SalaryType> salaryTypes, Employee employee)
		{
			this._salaryTypes = salaryTypes ?? throw new ArgumentNullException("salaryTypes", "Parameter \"salaryTypes\" cannot be null.");
			this._employee = employee ?? throw new ArgumentNullException("employee", "Parameter \"employee\" cannot be null.");
			this.SetPeriod(DateTime.Now.Year, DateTime.Now.Month);
		}

		public SalaryAccount(List<SalaryType> salaryTypes, XmlNode node)
		{
			this._salaryTypes = salaryTypes ?? throw new ArgumentNullException("salaryTypes", "Parameter \"salaryTypes\" cannot be null.");
			this.SetPeriod(DateTime.Now.Year, DateTime.Now.Month);
			this.ParseNode(node);
		}

		public SalaryAccount(List<SalaryType> salaryTypes, Employee employee, XmlNode node)
		{
			this._salaryTypes = salaryTypes ?? throw new ArgumentNullException("salaryTypes", "Parameter \"salaryTypes\" cannot be null.");
			this._employee = employee ?? throw new ArgumentNullException("employee", "Parameter \"employee\" cannot be null.");
			this.SetPeriod(DateTime.Now.Year, DateTime.Now.Month);

			this.ParseNode(node);
		}

		public object Clone()
		{
			var clone = (SalaryAccount)this.MemberwiseClone();
			clone._salaries = new Dictionary<SalaryType, SalaryItem>();
			foreach(var keyValue in this._salaries) {
				clone._salaries.Add(keyValue.Key, (SalaryItem)keyValue.Value.Clone());
			}

			return clone;
		}

		public void SetPeriod(int year, int month)
		{
			this._periodStart = new DateTime(year, month, 1);
			this._periodEnd = new DateTime(year, month, DateTime.DaysInMonth(year, month));
		}

		public void SetPeriod(int startYear, int startMonth, int startDay, int endYear, int endMonth, int endDay)
		{
			this._periodStart = new DateTime(startYear, startMonth, startDay);
			this._periodEnd = new DateTime(endYear, endMonth, endDay);
		}

		private void ParseNode(XmlNode node)
		{
			var idAttr = node.Attributes.GetNamedItem("id");
			if(idAttr != null) {
				this.Id = Convert.ToUInt32(idAttr.Value);
			}

			if(node.ChildNodes == null) {
				return;
			}

			var culture = CultureInfo.CreateSpecificCulture("en-US");
			foreach(XmlNode childNode in node.ChildNodes) {
				switch(childNode.Name) {
					case "annuity-insurance":
						this.AnnuityInsurance = Convert.ToDouble(childNode.InnerText, culture);
						break;

					case "compulsory-long-term-care-insurance":
						this.CompulsoryLongTermCareInsurance = Convert.ToDouble(childNode.InnerText, culture);
						break;

					case "period":
						var periodPattern = "^([0-9]{1,4})\\-([0-9]{2})(\\-([0-9]{2}) \\- ([0-9]{1,4})\\-([0-9]{2})\\-([0-9]{2}))?$";
						var periodMatch = Regex.Match(childNode.InnerText.Trim(), periodPattern, RegexOptions.Compiled);
						if (!periodMatch.Success) {
							throw new FormatException("The format of the period is invalid. It must be 'YYYY-MM' or 'YYYY-MM-DD - YYYY-MM-DD'!");
						}
						if (periodMatch.Groups[3].Value == String.Empty) {
							var periodYear = Convert.ToInt32(periodMatch.Groups[1].Value);
							var periodMonth = Convert.ToInt32(periodMatch.Groups[2].Value);
							this.SetPeriod(periodYear, periodMonth);
						} else {
							var periodStartYear = Convert.ToInt32(periodMatch.Groups[1].Value);
							var periodStartMonth = Convert.ToInt32(periodMatch.Groups[2].Value);
							var periodStartDay = Convert.ToInt32(periodMatch.Groups[4].Value);
							var periodEndYear = Convert.ToInt32(periodMatch.Groups[5].Value);
							var periodEndMonth = Convert.ToInt32(periodMatch.Groups[6].Value);
							var periodEndDay = Convert.ToInt32(periodMatch.Groups[7].Value);
							this.SetPeriod(periodStartYear, periodStartMonth, periodStartDay, periodEndYear, periodEndMonth, periodEndDay);
						}
						break;

					case "unemployment-insurance":
						this.UnemploymentInsurance = Convert.ToDouble(childNode.InnerText, culture);
						break;

					case "salaries":
						if (childNode.ChildNodes == null) {
							break;
						}

						foreach(XmlNode salaryNode in childNode.ChildNodes) {
							switch(salaryNode.Name) {
								case "salary":
									var typeIdAttr = salaryNode.Attributes.GetNamedItem("type-id");
									var amountAttr = salaryNode.Attributes.GetNamedItem("amount");
									if (typeIdAttr == null || amountAttr == null) {
										break;
									}
									var salaryTypeId = Convert.ToUInt32(typeIdAttr.Value);
									var salaryType = this._salaryTypes.Find(st => Convert.ToUInt32(st.Id) == salaryTypeId);
									var salaryAmount = Convert.ToDouble(amountAttr.Value, culture);
									this._salaries.Add(salaryType, new SalaryItem(salaryAmount));
									break;
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

					case "church-tax":
						this.ChurchTax = Convert.ToDouble(childNode.InnerText, culture);
						break;
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
			if (object.ReferenceEquals(a, b)) {
				return true;
			}

			if (((object)a == null) || ((object)b == null)) {
				return false;
			}
			if (a.PeriodStart != b.PeriodStart) {
				return false;
			}
			if(a.PeriodEnd != b.PeriodEnd) {
				return false;
			}

			if(a.AnnuityInsurance != b.AnnuityInsurance ||
				a.CompulsoryLongTermCareInsurance != b.CompulsoryLongTermCareInsurance ||
				a.NetWage != b.NetWage ||
				a.SicknessInsurance != b.SicknessInsurance ||
				a.SolidarityTax != b.SolidarityTax ||
				a.UnemploymentInsurance != b.UnemploymentInsurance ||
				a.WageTax != b.WageTax ||
				a.ChurchTax != b.ChurchTax) {
				return false;
			}
			if (a.Salaries.Count != b.Salaries.Count) {
				return false;
			}
			foreach(var keyValue in a.Salaries) {
				if (!b.Salaries.Any(s => s.Key.Number == keyValue.Key.Number)) {
					return false;
				}
				var bKeyValue = b.Salaries.Single(s => s.Key.Number == keyValue.Key.Number);
				if (keyValue.Value != bKeyValue.Value) {
					return false;
				}
			}

			return true;
		}

		public static bool operator !=(SalaryAccount a, SalaryAccount b)
		{
			return !(a == b);
		}
	}
}
