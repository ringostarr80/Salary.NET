using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Threading.Tasks;
using System.Xml;

namespace SalaryLibrary.SalaryDataProviders
{
	public class SalaryDataXml : ISalaryDataProvider
	{
		private string _combinedFilename = String.Empty;
		private string _employeeFilename = String.Empty;
		private string _salaryFilename = String.Empty;
		private XmlDocument _combinedDoc = null;
		private XmlDocument _employeeDoc = null;
		private XmlDocument _salaryDoc = null;
		private CultureInfo _culture = CultureInfo.CreateSpecificCulture("en-US");
		private object _writeLock = new object();

		public SalaryDataXml(string combinedFilename)
		{
			if (!combinedFilename.EndsWith(".xml")) {
				throw new ArgumentException("The XML-filename must end with .xml!", "filename");
			}

			this._combinedFilename = combinedFilename;

			if (!File.Exists(this._combinedFilename)) {
				var newDocument = new XmlDocument();
				var xmlDeclaration = newDocument.CreateXmlDeclaration("1.0", "utf-8", null);
				newDocument.AppendChild(xmlDeclaration);
				var xmlSalaryData = newDocument.CreateElement("salary-data");
				var xmlEmployees = newDocument.CreateElement("employees");
				xmlSalaryData.AppendChild(xmlEmployees);
				var xmlSalaryAccountings = newDocument.CreateElement("salary-accountings");
				xmlSalaryData.AppendChild(xmlSalaryAccountings);
				newDocument.AppendChild(xmlSalaryData);
				newDocument.Save(this._combinedFilename);
			}

			this._combinedDoc = new XmlDocument();
			this._combinedDoc.Load(this._combinedFilename);
		}

		public SalaryDataXml(string employeeFilename, string salaryFilename)
		{
			if(!employeeFilename.EndsWith(".xml")) {
				throw new ArgumentException("The XML-filename must end with .xml!", "employeeFilename");
			}

			if(!salaryFilename.EndsWith(".xml")) {
				throw new ArgumentException("The XML-filename must end with .xml!", "salaryFilename");
			}

			this._employeeFilename = employeeFilename;
			this._salaryFilename = salaryFilename;

			if(!File.Exists(this._employeeFilename)) {
				var newDocument = new XmlDocument();
				var xmlSalaryData = newDocument.CreateElement("salary-data");
				var xmlEmployees = newDocument.CreateElement("employees");
				xmlSalaryData.AppendChild(xmlEmployees);
				newDocument.AppendChild(xmlSalaryData);
				newDocument.Save(this._employeeFilename);
			}

			if(!File.Exists(this._salaryFilename)) {
				var newDocument = new XmlDocument();
				var xmlSalaryData = newDocument.CreateElement("salary-data");
				var xmlSalaryAccountings = newDocument.CreateElement("salary-accountings");
				xmlSalaryData.AppendChild(xmlSalaryAccountings);
				newDocument.AppendChild(xmlSalaryData);
				newDocument.Save(this._salaryFilename);
			}

			this._employeeDoc = new XmlDocument();
			this._employeeDoc.Load(this._employeeFilename);
			this._salaryDoc = new XmlDocument();
			this._salaryDoc.Load(this._salaryFilename);
		}

		private XmlNode BuildEmployeeNode(Employee employee, XmlDocument employeeDoc)
		{
			var employeeNode = employeeDoc.CreateElement("employee");
			employeeNode.SetAttribute("id", employee.Id.ToString());
			if(employee.PersonnelNumber != String.Empty) {
				var personnelNumberNode = employeeDoc.CreateElement("personnel-number");
				personnelNumberNode.InnerText = employee.PersonnelNumber;
				employeeNode.AppendChild(personnelNumberNode);
			}
			if(employee.FirstName != String.Empty) {
				var firstNameNode = employeeDoc.CreateElement("first-name");
				firstNameNode.InnerText = employee.FirstName;
				employeeNode.AppendChild(firstNameNode);
			}
			if(employee.MiddleName != String.Empty) {
				var middleNameNode = employeeDoc.CreateElement("middle-name");
				middleNameNode.InnerText = employee.MiddleName;
				employeeNode.AppendChild(middleNameNode);
			}
			if(employee.LastName != String.Empty) {
				var lastNameNode = employeeDoc.CreateElement("last-name");
				lastNameNode.InnerText = employee.LastName;
				employeeNode.AppendChild(lastNameNode);
			}
			if (employee.Gender != Gender.Unknown) {
				var genderNode = employeeDoc.CreateElement("gender");
				genderNode.InnerText = employee.Gender.ToString().ToLower();
				employeeNode.AppendChild(genderNode);
			}
			if(employee.Birthday != DateTime.MinValue) {
				var birthdayNode = employeeDoc.CreateElement("birthday");
				birthdayNode.InnerText = employee.Birthday.ToString("yyyy-MM-dd");
				employeeNode.AppendChild(birthdayNode);
			}

			return employeeNode;
		}

		private XmlNode BuildSalaryNode(SalaryAccount salary, XmlDocument salaryDoc)
		{
			var salaryNode = salaryDoc.CreateElement("salary");
			salaryNode.SetAttribute("id", salary.Id.ToString());
			if (salary.Employee != null && salary.Employee.Id is uint && ((uint)salary.Employee.Id) > 0) {
				salaryNode.SetAttribute("employee-id", ((uint)salary.Employee.Id).ToString());
			}

			var periodNode = salaryDoc.CreateElement("period");
			var periodString = String.Format("{0}-{1:00}", salary.PeriodStart.Year, salary.PeriodStart.Month);
			if (salary.PeriodStart.Year != salary.PeriodEnd.Year ||
				salary.PeriodStart.Month != salary.PeriodEnd.Month ||
				salary.PeriodStart.Day != 1 ||
				salary.PeriodEnd.Day != DateTime.DaysInMonth(salary.PeriodEnd.Year, salary.PeriodEnd.Month)) {
				periodString += String.Format("-{0:00} - {1}-{2:00}-{3:00}", salary.PeriodStart.Day, salary.PeriodEnd.Year, salary.PeriodEnd.Month, salary.PeriodEnd.Day);
			}
			periodNode.InnerText = periodString;
			salaryNode.AppendChild(periodNode);

			if (salary.Salaries.Count > 0) {
				var salariesNode = salaryDoc.CreateElement("salaries");
				foreach(var keyValue in salary.Salaries) {
					var salaryItemNode = salaryDoc.CreateElement("salary");
					salaryItemNode.SetAttribute("type", ((int)keyValue.Key).ToString());
					salaryItemNode.SetAttribute("amount", keyValue.Value.Amount.ToString(this._culture));
					salariesNode.AppendChild(salaryItemNode);
				}
				salaryNode.AppendChild(salariesNode);
			}

			if (salary.WageTax != 0.0) {
				var wageTaxNode = salaryDoc.CreateElement("wage-tax");
				wageTaxNode.InnerText = salary.WageTax.ToString(this._culture);
				salaryNode.AppendChild(wageTaxNode);
			}
			if(salary.SolidarityTax != 0.0) {
				var solidarityTaxNode = salaryDoc.CreateElement("solidarity-tax");
				solidarityTaxNode.InnerText = salary.SolidarityTax.ToString(this._culture);
				salaryNode.AppendChild(solidarityTaxNode);
			}

			if(salary.SicknessInsurance != 0.0) {
				var sicknessInsuranceNode = salaryDoc.CreateElement("sickness-insurance");
				sicknessInsuranceNode.InnerText = salary.SicknessInsurance.ToString(this._culture);
				salaryNode.AppendChild(sicknessInsuranceNode);
			}
			if(salary.AnnuityInsurance != 0.0) {
				var annuityInsuranceNode = salaryDoc.CreateElement("annuity-insurance");
				annuityInsuranceNode.InnerText = salary.AnnuityInsurance.ToString(this._culture);
				salaryNode.AppendChild(annuityInsuranceNode);
			}
			if(salary.UnemploymentInsurance != 0.0) {
				var unemploymentInsuranceNode = salaryDoc.CreateElement("unemployment-insurance");
				unemploymentInsuranceNode.InnerText = salary.UnemploymentInsurance.ToString(this._culture);
				salaryNode.AppendChild(unemploymentInsuranceNode);
			}
			if(salary.CompulsoryLongTermCareInsurance != 0.0) {
				var compulsoryLongTermCareInsuranceeNode = salaryDoc.CreateElement("compulsory-long-term-care-insurance");
				compulsoryLongTermCareInsuranceeNode.InnerText = salary.CompulsoryLongTermCareInsurance.ToString(this._culture);
				salaryNode.AppendChild(compulsoryLongTermCareInsuranceeNode);
			}

			return salaryNode;
		}

		public object InsertEmployee(Employee employee)
		{
			var employeeDoc = (this._employeeDoc != null) ? this._employeeDoc : this._combinedDoc;
			var employeeFilename = (this._employeeFilename != String.Empty) ? this._employeeFilename : this._combinedFilename;

			var salaryDataNode = employeeDoc.SelectSingleNode("/salary-data");
			if (salaryDataNode == null) {
				throw new InvalidDataException("salary-data node does not exists in xml-file.");
			}

			var employeesNode = salaryDataNode.SelectSingleNode("./employees");
			if (employeesNode == null) {
				employeesNode = employeeDoc.CreateElement("employees");
				salaryDataNode.AppendChild(employeesNode);
			}

			employee.Id = this.GetLastEmployeeId() + 1;
			var employeeNode = this.BuildEmployeeNode(employee, employeeDoc);

			employeesNode.AppendChild(employeeNode);
			employeeDoc.Save(employeeFilename);

			return employee.Id;
		}

		public async Task<object> InsertEmployeeAsync(Employee employee)
		{
			return await Task.Run(() => {
				lock(this._writeLock) {
					return this.InsertEmployee(employee);
				}
			});
		}

		public void UpdateEmployee(Employee employee)
		{
			var employeeDoc = (this._employeeDoc != null) ? this._employeeDoc : this._combinedDoc;
			var employeeFilename = (this._employeeFilename != String.Empty) ? this._employeeFilename : this._combinedFilename;
			var employeeNode = employeeDoc.SelectSingleNode("/salary-data/employees/employee[@id='" + employee.Id + "']");
			if (employeeNode == null) {
				throw new ArgumentException("Cannot find employee-id in xml-data to update.");
			}
			
			var newEmployeeNode = this.BuildEmployeeNode(employee, employeeDoc);
			employeeNode.ParentNode.ReplaceChild(newEmployeeNode, employeeNode);
			employeeDoc.Save(employeeFilename);
		}

		public async Task UpdateEmployeeAsync(Employee employee)
		{
			await Task.Run(() => {
				lock(this._writeLock) {
					this.UpdateEmployee(employee);
				}
			});
		}

		public void DeleteEmployee(object id)
		{
			var employeeDoc = (this._employeeDoc != null) ? this._employeeDoc : this._combinedDoc;
			var employeeFilename = (this._employeeFilename != String.Empty) ? this._employeeFilename : this._combinedFilename;
			var employeeNode = employeeDoc.SelectSingleNode("/salary-data/employees/employee[@id='" + id + "']");
			if(employeeNode == null) {
				return;
			}

			employeeNode.ParentNode.RemoveChild(employeeNode);
			employeeDoc.Save(employeeFilename);
		}

		public void DeleteEmployee(string firstName, string lastName)
		{
			var employeeDoc = (this._employeeDoc != null) ? this._employeeDoc : this._combinedDoc;
			var employeeNodes = employeeDoc.SelectNodes("/salary-data/employees/employee");
			foreach(XmlNode employeeNode in employeeNodes) {
				var firstNameNode = employeeNode.SelectSingleNode("./first-name");
				var lastNameNode = employeeNode.SelectSingleNode("./last-name");
				var currentFirstName = String.Empty;
				var currentLastName = String.Empty;
				if(firstNameNode != null) {
					currentFirstName = firstNameNode.InnerText.Trim();
				}
				if(lastNameNode != null) {
					currentLastName = lastNameNode.InnerText.Trim();
				}
				if(currentFirstName != firstName) {
					continue;
				}
				if(currentLastName != lastName) {
					continue;
				}

				employeeNode.ParentNode.RemoveChild(employeeNode);
				break;
			}
		}

		public void DeleteEmployee(Employee employee)
		{
			this.DeleteEmployee((uint)employee.Id);
		}

		public bool EmployeeExists(object id)
		{
			var employeeDoc = (this._employeeDoc != null) ? this._employeeDoc : this._combinedDoc;
			var employeeNode = employeeDoc.SelectSingleNode("/salary-data/employees/employee[@id='" + id + "']");
			return (employeeNode != null) ? true : false;
		}

		public bool EmployeeExists(string firstName, string lastName)
		{
			var employeeDoc = (this._employeeDoc != null) ? this._employeeDoc : this._combinedDoc;
			var employeeNodes = employeeDoc.SelectNodes("/salary-data/employees/employee");
			foreach(XmlNode employeeNode in employeeNodes) {
				var firstNameNode = employeeNode.SelectSingleNode("./first-name");
				var lastNameNode = employeeNode.SelectSingleNode("./last-name");
				var currentFirstName = String.Empty;
				var currentLastName = String.Empty;
				if(firstNameNode != null) {
					currentFirstName = firstNameNode.InnerText.Trim();
				}
				if(lastNameNode != null) {
					currentLastName = lastNameNode.InnerText.Trim();
				}
				if(currentFirstName != firstName) {
					continue;
				}
				if (currentLastName != lastName) {
					continue;
				}

				return true;
			}

			return false;
		}

		public Employee GetEmployee(object id)
		{
			var employeeDoc = (this._employeeDoc != null) ? this._employeeDoc : this._combinedDoc;
			var employeeNode = employeeDoc.SelectSingleNode("/salary-data/employees/employee[@id='" + id + "']");
			if (employeeNode == null) {
				return null;
			}

			return new Employee(employeeNode);
		}

		public Employee GetEmployee(string firstName, string lastName)
		{
			var employeeDoc = (this._employeeDoc != null) ? this._employeeDoc : this._combinedDoc;
			var employeeNodes = employeeDoc.SelectNodes("/salary-data/employees/employee[@id]");
			foreach(XmlNode employeeNode in employeeNodes) {
				var firstNameNode = employeeNode.SelectSingleNode("./first-name");
				var lastNameNode = employeeNode.SelectSingleNode("./last-name");
				var currentFirstName = String.Empty;
				var currentLastName = String.Empty;
				if(firstNameNode != null) {
					currentFirstName = firstNameNode.InnerText.Trim();
				}
				if(lastNameNode != null) {
					currentLastName = lastNameNode.InnerText.Trim();
				}
				if(currentFirstName != firstName) {
					continue;
				}
				if(currentLastName != lastName) {
					continue;
				}

				return new Employee(employeeNode);
			}

			return null;
		}

		public uint GetEmployeesCount()
		{
			var employeeDoc = (this._employeeDoc != null) ? this._employeeDoc : this._combinedDoc;
			var employeeNodes = employeeDoc.SelectNodes("/salary-data/employees/employee[@id]");
			return (uint)employeeNodes.Count;
		}

		public List<Employee> GetEmployees()
		{
			var employees = new List<Employee>();

			this.GetEmployees((employee) => {
				employees.Add(employee);
			});

			return employees;
		}

		public async Task<List<Employee>> GetEmployeesAsync()
		{
			return await Task.Run(() => { return this.GetEmployees(); });
		}

		public uint GetEmployees(Action<Employee> callback)
		{
			var count = 0U;

			var employeeDoc = (this._employeeDoc != null) ? this._employeeDoc : this._combinedDoc;
			var employeeNodes = employeeDoc.SelectNodes("/salary-data/employees/employee[@id]");
			foreach(XmlNode employeeNode in employeeNodes) {
				var employee = new Employee(employeeNode);
				callback(employee);
				count++;
			}

			return count;
		}

		private uint GetLastEmployeeId()
		{
			uint lastId = 0;
			uint parsedId = 0;

			var employeeDoc = (this._employeeDoc != null) ? this._employeeDoc : this._combinedDoc;
			var employeeNodes = employeeDoc.SelectNodes("/salary-data/employees/employee[@id]");
			foreach(XmlNode employeeNode in employeeNodes) {
				var idAttr = employeeNode.Attributes.GetNamedItem("id");
				if (idAttr == null) {
					continue;
				}

				if(!UInt32.TryParse(idAttr.Value, out parsedId)) {
					continue;
				}

				if (parsedId > lastId) {
					lastId = parsedId;
				}
			}

			return lastId;
		}

		private uint GetLastSalaryId()
		{
			uint lastId = 0;
			uint parsedId = 0;

			var salaryDoc = (this._salaryDoc != null) ? this._salaryDoc : this._combinedDoc;
			var salaryNodes = salaryDoc.SelectNodes("/salary-data/salary-accountings/salary[@id]");
			foreach(XmlNode salaryNode in salaryNodes) {
				var idAttr = salaryNode.Attributes.GetNamedItem("id");
				if(idAttr == null) {
					continue;
				}

				if(!UInt32.TryParse(idAttr.Value, out parsedId)) {
					continue;
				}

				if(parsedId > lastId) {
					lastId = parsedId;
				}
			}

			return lastId;
		}

		public object InsertSalary(SalaryAccount salary)
		{
			var salaryDoc = (this._salaryDoc != null) ? this._salaryDoc : this._combinedDoc;
			var salaryFilename = (this._salaryFilename != String.Empty) ? this._salaryFilename : this._combinedFilename;

			var salaryDataNode = salaryDoc.SelectSingleNode("/salary-data");
			if (salaryDataNode == null) {
				throw new InvalidDataException("salary-data node does not exists in xml-file.");
			}

			var salaryAccountingsNode = salaryDataNode.SelectSingleNode("./salary-accountings");
			if(salaryAccountingsNode == null) {
				salaryAccountingsNode = salaryDoc.CreateElement("salary-accountings");
				salaryDataNode.AppendChild(salaryAccountingsNode);
			}

			salary.Id = this.GetLastSalaryId() + 1;
			var salaryNode = this.BuildSalaryNode(salary, salaryDoc);

			salaryAccountingsNode.AppendChild(salaryNode);
			salaryDoc.Save(salaryFilename);

			return salary.Id;
		}

		public SalaryAccount GetSalaryAccount(object id)
		{
			var salaryDoc = (this._salaryDoc != null) ? this._salaryDoc : this._combinedDoc;
			var salaryNode = salaryDoc.SelectSingleNode("/salary-data/salary-accountings/salary[@id='" + id + "']");
			if(salaryNode == null) {
				return null;
			}
			var employeeIdAttr = salaryNode.Attributes.GetNamedItem("employee-id");
			uint employeeId = 0;
			if(employeeIdAttr == null) {
				return null;
			}
			employeeId = Convert.ToUInt32(employeeIdAttr.Value);

			var employeeDoc = (this._employeeDoc != null) ? this._employeeDoc : this._combinedDoc;
			var employeeNode = employeeDoc.SelectSingleNode("/salary-data/employees/employee[@id='" + employeeId + "']");
			if(employeeNode == null) {
				return null;
			}
			var employee = new Employee(employeeNode);

			return new SalaryAccount(employee, salaryNode);
		}

		public List<SalaryAccount> GetSalaryAccounts()
		{
			var salaryAccounts = new List<SalaryAccount>();

			this.GetSalaryAccounts((salaryAccount) => {
				salaryAccounts.Add(salaryAccount);
			});

			return salaryAccounts;
		}

		public uint GetSalaryAccounts(Action<SalaryAccount> callback)
		{
			uint count = 0;

			var salaryDoc = (this._salaryDoc != null) ? this._salaryDoc : this._combinedDoc;
			var salaryNodes = salaryDoc.SelectNodes("/salary-data/salary-accountings/salary[@id]");
			foreach(XmlNode salaryNode in salaryNodes) {
				callback(new SalaryAccount(salaryNode));
				count++;
			}

			return count;
		}

		public async Task<List<SalaryAccount>> GetSalaryAccountsAsync()
		{
			return await Task.Run(() => { return this.GetSalaryAccounts(); });
		}

		public void UpdateSalary(SalaryAccount salary)
		{
			var salaryDoc = (this._salaryDoc != null) ? this._salaryDoc : this._combinedDoc;
			var salaryFilename = (this._salaryFilename != String.Empty) ? this._salaryFilename : this._combinedFilename;
			var salaryNode = salaryDoc.SelectSingleNode("/salary-data/salary-accountings/salary[@id='" + salary.Id + "']");
			if(salaryNode == null) {
				throw new ArgumentException("Cannot find salary-id in xml-data to update.");
			}

			var newSalaryNode = this.BuildSalaryNode(salary, salaryDoc);
			salaryNode.ParentNode.ReplaceChild(newSalaryNode, salaryNode);
			salaryDoc.Save(salaryFilename);
		}

		public async Task UpdateSalaryAsync(SalaryAccount salary)
		{
			await Task.Run(() => { this.UpdateSalary(salary); });
		}

		public void DeleteSalary(object id)
		{
			var salaryDoc = (this._salaryDoc != null) ? this._salaryDoc : this._combinedDoc;
			var salaryFilename = (this._salaryFilename != String.Empty) ? this._salaryFilename : this._combinedFilename;
			var salaryNode = salaryDoc.SelectSingleNode("/salary-data/salary-accountings/salary[@id='" + id + "']");
			if(salaryNode == null) {
				throw new ArgumentException("Cannot find salary-id in xml-data to delete.");
			}

			salaryNode.ParentNode.RemoveChild(salaryNode);
			salaryDoc.Save(salaryFilename);
		}

		public async Task DeleteSalaryAsync(object id)
		{
			await Task.Run(() => { this.DeleteSalary(id); });
		}
	}
}
