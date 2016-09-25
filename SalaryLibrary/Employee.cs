using System;
using System.Xml;

namespace SalaryLibrary
{
	public class Employee : Person
	{
		protected string _personnelNumber = String.Empty;

		/// <summary>
		/// Personalnummer
		/// </summary>
		public string PersonnelNumber { get { return this._personnelNumber; } set { this._personnelNumber = value.Trim(); } }

		public Employee(string firstName, string lastName) : base(firstName, lastName)
		{

		}

		public Employee(object id, string firstName, string lastName) : base(id, firstName, lastName)
		{
			
		}

		public Employee(XmlNode node) : base(node)
		{
			var personnelNumberNode = node.SelectSingleNode("./personnel-number");
			if (personnelNumberNode != null) {
				this.PersonnelNumber = personnelNumberNode.InnerText;
			}
		}
	}
}
