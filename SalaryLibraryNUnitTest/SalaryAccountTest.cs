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

		private SalaryAccount GetDefaultSalaryAccount()
		{
			var employee = new Employee(1, "Max", "Mustermann");
			var salaryAccount = new SalaryAccount(employee) {
				SolidarityTax = 21.30,
				SicknessInsurance = 277.22,
				AnnuityInsurance = 312.29,
				CompulsoryLongTermCareInsurance = 47.60,
				UnemploymentInsurance = 50.10,
				WageTax = 387.33
			};
			salaryAccount.Salaries.Add(SalaryType.Gehalt, new SalaryItem(3300.00));
			salaryAccount.Salaries.Add(SalaryType.BezugVWLlfd, new SalaryItem(40.00));
			salaryAccount.SetPeriod(2000, 1);

			return salaryAccount;
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
		public void TestSalaryAccountClone()
		{
			var salaryAccount = this.GetDefaultSalaryAccount();
			var salaryAccountCloned = (SalaryAccount)salaryAccount.Clone();
			salaryAccountCloned.AnnuityInsurance++;
			salaryAccountCloned.CompulsoryLongTermCareInsurance++;
			salaryAccountCloned.SicknessInsurance++;
			salaryAccountCloned.SolidarityTax++;
			salaryAccountCloned.UnemploymentInsurance++;
			salaryAccountCloned.WageTax++;

			Assert.AreEqual(salaryAccount.Salaries.Count, salaryAccountCloned.Salaries.Count);

			salaryAccountCloned.Salaries.Clear();
			salaryAccountCloned.Salaries.Add(SalaryType.Gehalt, new SalaryItem(1234.56));
			Assert.AreEqual(2, salaryAccount.Salaries.Count);
			Assert.AreEqual(1, salaryAccountCloned.Salaries.Count);

			Assert.IsFalse(salaryAccount.AnnuityInsurance == salaryAccountCloned.AnnuityInsurance);
			Assert.IsFalse(salaryAccount.CompulsoryLongTermCareInsurance == salaryAccountCloned.CompulsoryLongTermCareInsurance);
			Assert.IsFalse(salaryAccount.SicknessInsurance == salaryAccountCloned.SicknessInsurance);
			Assert.IsFalse(salaryAccount.SolidarityTax == salaryAccountCloned.SolidarityTax);
			Assert.IsFalse(salaryAccount.UnemploymentInsurance == salaryAccountCloned.UnemploymentInsurance);
			Assert.IsFalse(salaryAccount.WageTax == salaryAccountCloned.WageTax);
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
		public void TestSalaryAccountSetPeriodCompleteMonth()
		{
			var salaryAccount = this.GetDefaultSalaryAccount();

			Assert.AreEqual(2000, salaryAccount.PeriodStart.Year);
			Assert.AreEqual(1, salaryAccount.PeriodStart.Month);
			Assert.AreEqual(1, salaryAccount.PeriodStart.Day);

			Assert.AreEqual(2000, salaryAccount.PeriodEnd.Year);
			Assert.AreEqual(1, salaryAccount.PeriodEnd.Month);
			Assert.AreEqual(31, salaryAccount.PeriodEnd.Day);

			salaryAccount.SetPeriod(2000, 2);

			Assert.AreEqual(2000, salaryAccount.PeriodStart.Year);
			Assert.AreEqual(2, salaryAccount.PeriodStart.Month);
			Assert.AreEqual(1, salaryAccount.PeriodStart.Day);

			Assert.AreEqual(2000, salaryAccount.PeriodEnd.Year);
			Assert.AreEqual(2, salaryAccount.PeriodEnd.Month);
			Assert.AreEqual(29, salaryAccount.PeriodEnd.Day);
		}

		[Test]
		public void TestSalaryAccountSetPeriodFromTo()
		{
			var salaryAccount = this.GetDefaultSalaryAccount();
			salaryAccount.SetPeriod(2000, 1, 1, 2000, 1, 15);

			Assert.AreEqual(2000, salaryAccount.PeriodStart.Year);
			Assert.AreEqual(1, salaryAccount.PeriodStart.Month);
			Assert.AreEqual(1, salaryAccount.PeriodStart.Day);

			Assert.AreEqual(2000, salaryAccount.PeriodEnd.Year);
			Assert.AreEqual(1, salaryAccount.PeriodEnd.Month);
			Assert.AreEqual(15, salaryAccount.PeriodEnd.Day);
		}

		[Test]
		public void TestSalaryAccountSave()
		{
			var salaryAccount = this.GetDefaultSalaryAccount();

			Settings.DefaultDataBackend = new SalaryDataXml(this._temporaryCombinedXmlFilename);
			Settings.DefaultDataBackend.InsertEmployee(salaryAccount.Employee);
			var newId = Settings.DefaultDataBackend.InsertSalary(salaryAccount);
			var newInsertedSalaryAccount = Settings.DefaultDataBackend.GetSalaryAccount(newId);
			Assert.IsTrue(salaryAccount == newInsertedSalaryAccount);
		}

		[Test]
		public void TestGetSalaryAccounts()
		{
			var employee = new Employee(1, "Max", "Mustermann");
			var salaryAccount = new SalaryAccount(employee) {
				SolidarityTax = 21.30,
				SicknessInsurance = 277.22,
				AnnuityInsurance = 312.29,
				CompulsoryLongTermCareInsurance = 47.60,
				UnemploymentInsurance = 50.10,
				WageTax = 387.33
			};
			salaryAccount.Salaries.Add(SalaryType.Gehalt, new SalaryItem(3300.00));
			salaryAccount.Salaries.Add(SalaryType.BezugVWLlfd, new SalaryItem(40.00));

			Settings.DefaultDataBackend = new SalaryDataXml(this._temporaryCombinedXmlFilename);
			Settings.DefaultDataBackend.InsertEmployee(employee);
			Settings.DefaultDataBackend.InsertSalary(salaryAccount);
			var salaryAccounts = Settings.DefaultDataBackend.GetSalaryAccounts();
			Assert.AreEqual(1, salaryAccounts.Count);
		}

		[Test]
		public void TestGetSalaryAccountsCallback()
		{
			var employee = new Employee(1, "Max", "Mustermann");
			var salaryAccount = new SalaryAccount(employee) {
				SolidarityTax = 21.30,
				SicknessInsurance = 277.22,
				AnnuityInsurance = 312.29,
				CompulsoryLongTermCareInsurance = 47.60,
				UnemploymentInsurance = 50.10,
				WageTax = 387.33
			};
			salaryAccount.Salaries.Add(SalaryType.Gehalt, new SalaryItem(3300.00));
			salaryAccount.Salaries.Add(SalaryType.BezugVWLlfd, new SalaryItem(40.00));

			Settings.DefaultDataBackend = new SalaryDataXml(this._temporaryCombinedXmlFilename);
			Settings.DefaultDataBackend.InsertEmployee(employee);
			Settings.DefaultDataBackend.InsertSalary(salaryAccount);
			var salaryAccounts = Settings.DefaultDataBackend.GetSalaryAccounts((data) => {

			});
			Assert.AreEqual(1, salaryAccounts);
		}

		[Test]
		public void TestGetSalaryAccountsAsync()
		{
			var employee = new Employee(1, "Max", "Mustermann");
			var salaryAccount = new SalaryAccount(employee) {
				SolidarityTax = 21.30,
				SicknessInsurance = 277.22,
				AnnuityInsurance = 312.29,
				CompulsoryLongTermCareInsurance = 47.60,
				UnemploymentInsurance = 50.10,
				WageTax = 387.33
			};
			salaryAccount.Salaries.Add(SalaryType.Gehalt, new SalaryItem(3300.00));
			salaryAccount.Salaries.Add(SalaryType.BezugVWLlfd, new SalaryItem(40.00));

			Settings.DefaultDataBackend = new SalaryDataXml(this._temporaryCombinedXmlFilename);
			Settings.DefaultDataBackend.InsertEmployee(employee);
			Settings.DefaultDataBackend.InsertSalary(salaryAccount);
			var salaryAccountsAsync = Settings.DefaultDataBackend.GetSalaryAccountsAsync();
			salaryAccountsAsync.Wait();
			Assert.AreEqual(1, salaryAccountsAsync.Result.Count);
		}

		[Test]
		public void TestUpdateSalaryAccount()
		{
			var salaryAccount = this.GetDefaultSalaryAccount();
			Settings.DefaultDataBackend = new SalaryDataXml(this._temporaryCombinedXmlFilename);
			Settings.DefaultDataBackend.InsertEmployee(salaryAccount.Employee);
			var id = Settings.DefaultDataBackend.InsertSalary(salaryAccount);
			var savedSalary = Settings.DefaultDataBackend.GetSalaryAccount(id);
			salaryAccount.WageTax++;
			salaryAccount.AnnuityInsurance++;
			Settings.DefaultDataBackend.UpdateSalary(salaryAccount);
			var updatedSalary = Settings.DefaultDataBackend.GetSalaryAccount(id);

			Assert.AreEqual(savedSalary.WageTax + 1, updatedSalary.WageTax);
			Assert.AreEqual(savedSalary.AnnuityInsurance + 1, updatedSalary.AnnuityInsurance);
		}

		[Test]
		public void TestDeleteSalaryAccount()
		{
			var salaryAccount = this.GetDefaultSalaryAccount();
			Settings.DefaultDataBackend = new SalaryDataXml(this._temporaryCombinedXmlFilename);
			Settings.DefaultDataBackend.InsertEmployee(salaryAccount.Employee);
			var id = Settings.DefaultDataBackend.InsertSalary(salaryAccount);
			var salariesCount = Settings.DefaultDataBackend.GetSalaryAccounts().Count;
			Assert.AreEqual(1, salariesCount);
			Settings.DefaultDataBackend.DeleteSalary(id);
			salariesCount = Settings.DefaultDataBackend.GetSalaryAccounts().Count;
			Assert.AreEqual(0, salariesCount);
		}
	}
}
