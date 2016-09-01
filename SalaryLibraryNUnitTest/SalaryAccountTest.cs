using System;
using System.IO;
using NUnit.Framework;
using SalaryLibrary;
using SalaryLibrary.SalaryDataProviders;

namespace SalaryLibraryNUnitTest
{
	[TestFixture]
	public class SalaryAccountTest
	{
		private string _temporaryCombinedXmlFilename = String.Empty;

		[SetUp]
		protected void SetUp()
		{
			var tempFolder = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData);
			this._temporaryCombinedXmlFilename = tempFolder + "\\salary_combined.xml";
			if(File.Exists(this._temporaryCombinedXmlFilename)) {
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

		[Test]
		public void TestSalaryAccountConstructor()
		{
			var employee = new Employee(1, "Max", "Mustermann");
			var salaryAccount = new SalaryAccount(employee);
		}

		[Test]
		public void TestSalaryAccountConstructorException()
		{
			Employee employee = null;
			Assert.Throws<ArgumentNullException>(() => { new SalaryAccount(employee); });
		}

		[Test]
		public void TestSalaryAccountProperties()
		{
			var employee = new Employee(1, "Max", "Mustermann");
			var salaryAccount = new SalaryAccount(employee);
			salaryAccount.SolidarityTax = 21.30;
			salaryAccount.SicknessInsurance = 277.22;
			salaryAccount.AnnuityInsurance = 312.29;
			salaryAccount.CompulsoryLongTermCareInsurance = 47.60;
			salaryAccount.UnemploymentInsurance = 50.10;

			Assert.AreEqual(21.30, salaryAccount.SolidarityTax);
			Assert.AreEqual(277.22, salaryAccount.SicknessInsurance);
			Assert.AreEqual(312.29, salaryAccount.AnnuityInsurance);
			Assert.AreEqual(47.60, salaryAccount.CompulsoryLongTermCareInsurance);
			Assert.AreEqual(50.10, salaryAccount.UnemploymentInsurance);
		}

		[Test]
		public void TestSalaryAccountAddSalaryItems()
		{
			var employee = new Employee(1, "Max", "Mustermann");
			var salaryAccount = new SalaryAccount(employee);
			Assert.AreEqual(0, salaryAccount.Salaries.Count);
			salaryAccount.Salaries.Add(SalaryType.Gehalt, new SalaryItem(3300.00));
			salaryAccount.Salaries.Add(SalaryType.BezugVWLlfd, new SalaryItem(40.00));
			Assert.AreEqual(2, salaryAccount.Salaries.Count);
		}

		[Test]
		public void TestSalaryAccountCalculateNetWage()
		{
			var employee = new Employee(1, "Max", "Mustermann");
			var salaryAccount = new SalaryAccount(employee);
			salaryAccount.Salaries.Add(SalaryType.Gehalt, new SalaryItem(3300.00));
			salaryAccount.Salaries.Add(SalaryType.BezugVWLlfd, new SalaryItem(40.00));
			salaryAccount.SolidarityTax = 21.30;
			salaryAccount.SicknessInsurance = 277.22;
			salaryAccount.AnnuityInsurance = 312.29;
			salaryAccount.CompulsoryLongTermCareInsurance = 47.60;
			salaryAccount.UnemploymentInsurance = 50.10;
			salaryAccount.WageTax = 387.33;

			Assert.AreEqual(2204.16, salaryAccount.NetWage, 0.001);
		}

		[Test]
		public void TestSalaryAccountSave()
		{
			var employee = new Employee(1, "Max", "Mustermann");
			var salaryAccount = new SalaryAccount(employee);
			salaryAccount.Salaries.Add(SalaryType.Gehalt, new SalaryItem(3300.00));
			salaryAccount.Salaries.Add(SalaryType.BezugVWLlfd, new SalaryItem(40.00));
			salaryAccount.SolidarityTax = 21.30;
			salaryAccount.SicknessInsurance = 277.22;
			salaryAccount.AnnuityInsurance = 312.29;
			salaryAccount.CompulsoryLongTermCareInsurance = 47.60;
			salaryAccount.UnemploymentInsurance = 50.10;
			salaryAccount.WageTax = 387.33;

			Settings.DefaultDataBackend = new SalaryDataXml(this._temporaryCombinedXmlFilename);
			Settings.DefaultDataBackend.InsertEmployee(employee);
			var newId = Settings.DefaultDataBackend.InsertSalary(salaryAccount);
			var newInsertedSalaryAccount = Settings.DefaultDataBackend.GetSalaryAccount(newId);
			Assert.IsTrue(salaryAccount == newInsertedSalaryAccount);
		}
	}
}
