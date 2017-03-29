using System;
using System.Text.RegularExpressions;
using System.Xml;

namespace SalaryLibrary
{
	public enum Gender
	{
		Male,
		Female,
		Unknown,
		NotSpecified
	}

    public class Person
    {
		protected object _id = null;
		protected Gender _gender = Gender.NotSpecified;
		protected string _firstName = string.Empty;
		protected string _middleName = string.Empty;
		protected string _lastName = string.Empty;
		protected DateTime _birthday = DateTime.MinValue;

		/// <summary>
		/// Id
		/// </summary>
		public object Id { get { return this._id; }
			set {
				this._id = value ?? throw new ArgumentException("Person.Id cannot be null!");
			}
		}
		/// <summary>
		/// Vorname
		/// </summary>
		public string FirstName { get { return this._firstName; } set { this._firstName = value.Trim(); } }
		/// <summary>
		/// 2. Vorname
		/// </summary>
		public string MiddleName { get { return this._middleName; } set { this._middleName = value.Trim(); } }
		/// <summary>
		/// Nachname
		/// </summary>
		public string LastName { get { return this._lastName; } set { this._lastName = value.Trim(); } }
		/// <summary>
		/// Geschlecht
		/// </summary>
		public Gender Gender { get { return this._gender; } set { this._gender = value; } }
		/// <summary>
		/// Geburtsdatum
		/// </summary>
		public DateTime Birthday { get { return this._birthday; } set { this._birthday = value; } }

		public Person(string firstName, string lastName)
		{
			this.FirstName = firstName;
			this.LastName = lastName;
		}

		public Person(object id, string firstName, string lastName)
		{
			this.Id = id;
			this.FirstName = firstName;
			this.LastName = lastName;
		}

		public Person(XmlNode node)
		{
			var idAttr = node.Attributes.GetNamedItem("id");
			if (idAttr != null) {
				this.Id = Convert.ToUInt32(idAttr.Value);
			}

			if (node.ChildNodes != null) {
				foreach(XmlNode childNode in node.ChildNodes) {
					switch(childNode.Name) {
						case "first-name":
							this.FirstName = childNode.InnerText;
							break;

						case "middle-name":
							this.MiddleName = childNode.InnerText;
							break;

						case "last-name":
							this.LastName = childNode.InnerText;
							break;

						case "gender":
							switch(childNode.InnerText.Trim().ToLower()) {
								case "male":
									this.Gender = Gender.Male;
									break;

								case "female":
									this.Gender = Gender.Female;
									break;

								case "notspecified":
									this.Gender = Gender.NotSpecified;
									break;

								case "unknown":
									this.Gender = Gender.Unknown;
									break;

								default:
									throw new FormatException("The gender (" + childNode.InnerText + ") is invalid. Valid genders are: male, female, notspecified or unknown.");
							}
							break;

						case "birthday":
							var birthdayText = childNode.InnerText.Trim();
							if (birthdayText != string.Empty) {
								var dateMatch = Regex.Match(birthdayText, "^(\\d{4})-(\\d{2})-(\\d{2})$", RegexOptions.Compiled);
								if(!dateMatch.Success) {
									throw new FormatException("The birthday-node (" + birthdayText + ") has an invalid format. Expected format: YYYY-MM-DD.");
								}
								var year = Convert.ToInt32(dateMatch.Groups[1].Value);
								var month = Convert.ToInt32(dateMatch.Groups[2].Value);
								var day = Convert.ToInt32(dateMatch.Groups[3].Value);
								this.Birthday = new DateTime(year, month, day);
							}
							break;
					}
				}
			}
		}

		public string GetFormalSalutation()
		{
			var salutation = this.GetInformalSalutation();

			switch(this._gender) {
				case Gender.Male:
					salutation = "Herr " + salutation;
					break;

				case Gender.Female:
					salutation = "Frau " + salutation;
					break;
			}

			return salutation;
		}

		public string GetInformalSalutation()
		{
			var salutation = string.Empty;

			if (this.FirstName != string.Empty) {
				salutation += this.FirstName;
			}

			if(this.LastName != string.Empty) {
				if(salutation != string.Empty) {
					salutation += " ";
				}
				salutation += this.LastName;
			}

			return salutation;
		}
    }
}
