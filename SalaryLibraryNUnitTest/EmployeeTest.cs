using System;
using System.IO;
using NUnit.Framework;
using SalaryLibrary;
using SalaryLibrary.SalaryDataProviders;

namespace SalaryLibraryNUnitTest
{
	[TestFixture]
	public class EmployeeTest
	{
		private string _temporaryCombinedXmlFilename = String.Empty;

		[SetUp]
		protected void SetUp()
		{
			var tempFolder = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData);
			this._temporaryCombinedXmlFilename = tempFolder + "\\salary_combined.xml";
			if (File.Exists(this._temporaryCombinedXmlFilename)) {
				File.Delete(this._temporaryCombinedXmlFilename);
			}
		}

		[TearDown]
		protected void TearDown()
		{
			if(File.Exists(this._temporaryCombinedXmlFilename)) {
				//File.Delete(this._temporaryCombinedXmlFilename);
			}
		}

		private Employee GetDefaultEmployee()
		{
			var employee1 = new Employee(1, "Max", "Mustermann");
			employee1.Birthday = new DateTime(1976, 2, 1);
			employee1.PersonnelNumber = "T01";
			employee1.Gender = Gender.Male;

			return employee1;
		}

		[Test]
		public void TestEmployeeConstructor()
		{
			var employee1 = this.GetDefaultEmployee();
			Assert.AreEqual(1, employee1.Id);
			Assert.AreEqual("Max", employee1.FirstName);
			Assert.AreEqual("Mustermann", employee1.LastName);
			Assert.AreEqual(new DateTime(1976, 2, 1), employee1.Birthday);
			Assert.AreEqual("T01", employee1.PersonnelNumber);
			Assert.AreEqual(Gender.Male, employee1.Gender);

			var employee2 = new Employee(2, "John", "Doe");
			employee2.MiddleName = "Dummy";
			Assert.AreEqual(2, employee2.Id);
			Assert.AreEqual("John", employee2.FirstName);
			Assert.AreEqual("Dummy", employee2.MiddleName);
			Assert.AreEqual("Doe", employee2.LastName);
			Assert.AreEqual(Gender.NotSpecified, employee2.Gender);
		}

		[Test]
		public void TestEmployeeConstructorIdException()
		{
			Assert.Throws<ArgumentException>(() => { new Employee(null, "Max", "Mustermann"); });
		}

		[Test]
		public void TestEmployeeInsert()
		{
			Settings.DefaultDataBackend = new SalaryDataXml(this._temporaryCombinedXmlFilename);
			
			var employee1 = this.GetDefaultEmployee();
			var employee2 = new Employee("Erika", "Mustermann");
			employee2.Birthday = new DateTime(1964, 8, 12);
			employee2.PersonnelNumber = "T02";
			employee2.Gender = Gender.Female;

			var employee1Exists = Settings.DefaultDataBackend.EmployeeExists(employee1.FirstName, employee1.LastName);
			var employee2Exists = Settings.DefaultDataBackend.EmployeeExists(employee2.FirstName, employee2.LastName);
			Assert.IsFalse(employee1Exists);
			Assert.IsFalse(employee2Exists);
			var newId1 = Settings.DefaultDataBackend.InsertEmployee(employee1);
			var newId2 = Settings.DefaultDataBackend.InsertEmployee(employee2);
			Assert.AreEqual(1, newId1);
			Assert.AreEqual(2, newId2);

			var employeesCount = Settings.DefaultDataBackend.GetEmployeesCount();
			Assert.AreEqual(2, employeesCount);
		}

		[Test]
		public void TestEmployeeInsertAsync()
		{
			Settings.DefaultDataBackend = new SalaryDataXml(this._temporaryCombinedXmlFilename);

			var employee1 = this.GetDefaultEmployee();
			var employee2 = new Employee("Erika", "Mustermann");
			employee2.Birthday = new DateTime(1964, 8, 12);
			employee2.PersonnelNumber = "T02";

			var employee1Exists = Settings.DefaultDataBackend.EmployeeExists(employee1.FirstName, employee1.LastName);
			var employee2Exists = Settings.DefaultDataBackend.EmployeeExists(employee2.FirstName, employee2.LastName);
			Assert.IsFalse(employee1Exists);
			Assert.IsFalse(employee2Exists);
			var newId1Task = Settings.DefaultDataBackend.InsertEmployeeAsync(employee1);
			var newId2Task = Settings.DefaultDataBackend.InsertEmployeeAsync(employee2);
			newId1Task.Wait();
			newId2Task.Wait();
			Assert.AreEqual(1, newId1Task.Result);
			Assert.AreEqual(2, newId2Task.Result);

			var employeesCount = Settings.DefaultDataBackend.GetEmployeesCount();
			Assert.AreEqual(2, employeesCount);
		}

		[Test]
		public void TestGetEmployeeById()
		{
			Settings.DefaultDataBackend = new SalaryDataXml(this._temporaryCombinedXmlFilename);

			var employee1 = this.GetDefaultEmployee();

			var employee1Exists = Settings.DefaultDataBackend.EmployeeExists(employee1.FirstName, employee1.LastName);
			Assert.IsFalse(employee1Exists);
			var newId1 = Settings.DefaultDataBackend.InsertEmployee(employee1);
			Assert.AreEqual(1, newId1);

			var employee1ExistsById = Settings.DefaultDataBackend.EmployeeExists(newId1);
			Assert.IsTrue(employee1ExistsById);

			var employeeLoaded = Settings.DefaultDataBackend.GetEmployee(newId1);

			Assert.AreEqual("Max", employeeLoaded.FirstName);
			Assert.AreEqual("T01", employeeLoaded.PersonnelNumber);
			Assert.AreEqual(Gender.Male, employeeLoaded.Gender);
		}

		[Test]
		public void TestGetEmployeeByName()
		{
			Settings.DefaultDataBackend = new SalaryDataXml(this._temporaryCombinedXmlFilename);

			var employee1 = this.GetDefaultEmployee();

			var employee1Exists = Settings.DefaultDataBackend.EmployeeExists(employee1.FirstName, employee1.LastName);
			Assert.IsFalse(employee1Exists);
			var newId1 = Settings.DefaultDataBackend.InsertEmployee(employee1);
			Assert.AreEqual(1, newId1);

			var employeeLoaded = Settings.DefaultDataBackend.GetEmployee("Max", "Mustermann");

			Assert.AreEqual("Max", employeeLoaded.FirstName);
			Assert.AreEqual("T01", employeeLoaded.PersonnelNumber);
		}

		[Test]
		public void TestEmployeeUpdate()
		{
			Settings.DefaultDataBackend = new SalaryDataXml(this._temporaryCombinedXmlFilename);

			var employee1 = this.GetDefaultEmployee();

			var employee1Exists = Settings.DefaultDataBackend.EmployeeExists(employee1.FirstName, employee1.LastName);
			Assert.IsFalse(employee1Exists);
			var newId1 = Settings.DefaultDataBackend.InsertEmployee(employee1);
			Assert.AreEqual(1, newId1);
			Assert.AreEqual(String.Empty, employee1.MiddleName);

			employee1.MiddleName = "John";
			Settings.DefaultDataBackend.UpdateEmployee(employee1);

			var employeeLoaded = Settings.DefaultDataBackend.GetEmployee(employee1.Id);
			Assert.AreEqual(employee1.MiddleName, employeeLoaded.MiddleName);
		}

		[Test]
		public void TestEmployeeUpdateAsync()
		{
			Settings.DefaultDataBackend = new SalaryDataXml(this._temporaryCombinedXmlFilename);

			var employee1 = this.GetDefaultEmployee();

			var employee1Exists = Settings.DefaultDataBackend.EmployeeExists(employee1.FirstName, employee1.LastName);
			Assert.IsFalse(employee1Exists);
			var newId1 = Settings.DefaultDataBackend.InsertEmployee(employee1);
			Assert.AreEqual(1, newId1);
			Assert.AreEqual(String.Empty, employee1.MiddleName);

			employee1.MiddleName = "John";
			var task = Settings.DefaultDataBackend.UpdateEmployeeAsync(employee1);
			task.Wait();

			var employeeLoaded = Settings.DefaultDataBackend.GetEmployee(employee1.Id);
			Assert.AreEqual(employee1.MiddleName, employeeLoaded.MiddleName);
		}

		[Test]
		public void TestEmployeeDeleteById()
		{
			Settings.DefaultDataBackend = new SalaryDataXml(this._temporaryCombinedXmlFilename);

			var employee1 = this.GetDefaultEmployee();

			var employee1Exists = Settings.DefaultDataBackend.EmployeeExists(employee1.FirstName, employee1.LastName);
			Assert.IsFalse(employee1Exists);
			var newId1 = Settings.DefaultDataBackend.InsertEmployee(employee1);
			Assert.AreEqual(1, newId1);
			employee1Exists = Settings.DefaultDataBackend.EmployeeExists(employee1.FirstName, employee1.LastName);
			Assert.IsTrue(employee1Exists);

			Settings.DefaultDataBackend.DeleteEmployee(newId1);
			employee1Exists = Settings.DefaultDataBackend.EmployeeExists(employee1.FirstName, employee1.LastName);
			Assert.IsFalse(employee1Exists);
		}

		[Test]
		public void TestEmployeeDeleteByName()
		{
			Settings.DefaultDataBackend = new SalaryDataXml(this._temporaryCombinedXmlFilename);

			var employee1 = this.GetDefaultEmployee();

			var employee1Exists = Settings.DefaultDataBackend.EmployeeExists(employee1.FirstName, employee1.LastName);
			Assert.IsFalse(employee1Exists);
			var newId1 = Settings.DefaultDataBackend.InsertEmployee(employee1);
			Assert.AreEqual(1, newId1);
			employee1Exists = Settings.DefaultDataBackend.EmployeeExists(employee1.FirstName, employee1.LastName);
			Assert.IsTrue(employee1Exists);

			Settings.DefaultDataBackend.DeleteEmployee(employee1.FirstName, employee1.LastName);
			employee1Exists = Settings.DefaultDataBackend.EmployeeExists(employee1.FirstName, employee1.LastName);
			Assert.IsFalse(employee1Exists);
		}

		[Test]
		public void TestEmployeeDeleteByObject()
		{
			Settings.DefaultDataBackend = new SalaryDataXml(this._temporaryCombinedXmlFilename);

			var employee1 = this.GetDefaultEmployee();

			var employee1Exists = Settings.DefaultDataBackend.EmployeeExists(employee1.FirstName, employee1.LastName);
			Assert.IsFalse(employee1Exists);
			var newId1 = Settings.DefaultDataBackend.InsertEmployee(employee1);
			Assert.AreEqual(1, newId1);
			employee1Exists = Settings.DefaultDataBackend.EmployeeExists(employee1.FirstName, employee1.LastName);
			Assert.IsTrue(employee1Exists);

			Settings.DefaultDataBackend.DeleteEmployee(employee1);
			employee1Exists = Settings.DefaultDataBackend.EmployeeExists(employee1.FirstName, employee1.LastName);
			Assert.IsFalse(employee1Exists);
		}

		[Test]
		public void TestGetEmployees()
		{
			Settings.DefaultDataBackend = new SalaryDataXml(this._temporaryCombinedXmlFilename);

			var employee1 = this.GetDefaultEmployee();
			var employee2 = new Employee(2, "John", "Doe");
			employee2.MiddleName = "Dummy";
			Settings.DefaultDataBackend.InsertEmployee(employee1);
			Settings.DefaultDataBackend.InsertEmployee(employee2);

			var employees = Settings.DefaultDataBackend.GetEmployees();
			Assert.AreEqual(2, employees.Count);
		}

		[Test]
		public void TestGetEmployeesAsync()
		{
			Settings.DefaultDataBackend = new SalaryDataXml(this._temporaryCombinedXmlFilename);

			var employee1 = this.GetDefaultEmployee();
			var employee2 = new Employee(2, "John", "Doe");
			employee2.MiddleName = "Dummy";
			Settings.DefaultDataBackend.InsertEmployee(employee1);
			Settings.DefaultDataBackend.InsertEmployee(employee2);

			var employeesAsync = Settings.DefaultDataBackend.GetEmployeesAsync();
			employeesAsync.Wait();
			Assert.AreEqual(2, employeesAsync.Result.Count);
		}

		[Test]
		public void TestGetEmployeesCallback()
		{
			Settings.DefaultDataBackend = new SalaryDataXml(this._temporaryCombinedXmlFilename);

			var employee1 = this.GetDefaultEmployee();
			var employee2 = new Employee(2, "John", "Doe");
			employee2.MiddleName = "Dummy";
			Settings.DefaultDataBackend.InsertEmployee(employee1);
			Settings.DefaultDataBackend.InsertEmployee(employee2);

			var employeesCount = Settings.DefaultDataBackend.GetEmployees((employee) => {
				// do nothing
			});
			Assert.AreEqual(2, employeesCount);
		}
	}
}