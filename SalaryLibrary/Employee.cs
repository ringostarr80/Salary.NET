using System.Xml;
using Newtonsoft.Json.Linq;

namespace SalaryLibrary
{
	public class Employee : Person
	{
		protected string _personnelNumber = string.Empty;

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

		public Employee(JToken json) : base(json)
		{
			if (json["personnel_number"]?.Type == JTokenType.String) {
				this.PersonnelNumber = json["personnel_number"].ToString();
			}
		}
	}
}
