using System;
using System.IO;
using NUnit.Framework;
using SalaryLibrary;
using SalaryLibrary.SalaryDataProviders;
using System.Collections.Generic;

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

		private List<SalaryType> GetDefaultSalaryTypes()
		{
			var salaryTypes = new List<SalaryType> {
				new SalaryType(1, 2000, "Gehalt"),
				new SalaryType(2, 2033, "Freiwillige Zulage"),
				new SalaryType(3, 2310, "Erholungsbeihilfe"),
				new SalaryType(4, 3100, "Bezug VWL lfd", true),
				new SalaryType(5, 4401, "Brutto Weihnachtsgeld"),
				new SalaryType(6, 4402, "Netto Weihnachtsgeld"),
				new SalaryType(7, 9840, "Abzug VWL", true),
				new SalaryType(8, 10000, "Netto Bezug aus Vormonat")
			};

			return salaryTypes;
		}

		private SalaryAccount GetDefaultSalaryAccount()
		{
			var employee = new Employee(1, "Max", "Mustermann");
			var defaultSalaryTypes = this.GetDefaultSalaryTypes();
			var salaryAccount = new SalaryAccount(defaultSalaryTypes, employee) {
				SolidarityTax = 21.30,
				SicknessInsurance = 277.22,
				AnnuityInsurance = 312.29,
				CompulsoryLongTermCareInsurance = 47.60,
				UnemploymentInsurance = 50.10,
				WageTax = 387.33
			};
			var salaryType1 = defaultSalaryTypes.Find(st => st.Number == 2000);
			var salaryType2 = defaultSalaryTypes.Find(st => st.Number == 3100);
			salaryAccount.Salaries.Add(salaryType1, new SalaryItem(3300.00));
			salaryAccount.Salaries.Add(salaryType2, new SalaryItem(40.00));
			salaryAccount.SetPeriod(2000, 1);

			return salaryAccount;
		}

		private SalaryAccount GetAlternativeSalaryAccount()
		{
			var employee = new Employee(2, "Erika", "Musterfrau");
			var defaultSalaryTypes = this.GetDefaultSalaryTypes();
			var salaryAccount = new SalaryAccount(defaultSalaryTypes, employee) {
				SolidarityTax = 11.30,
				SicknessInsurance = 237.22,
				AnnuityInsurance = 272.29,
				CompulsoryLongTermCareInsurance = 37.60,
				UnemploymentInsurance = 40.10,
				WageTax = 297.33
			};
			var salaryType1 = defaultSalaryTypes.Find(st => st.Number == 2000);
			var salaryType2 = defaultSalaryTypes.Find(st => st.Number == 3100);
			salaryAccount.Salaries.Add(salaryType1, new SalaryItem(2300.00));
			salaryAccount.Salaries.Add(salaryType2, new SalaryItem(24.00));
			salaryAccount.SetPeriod(2005, 5);

			return salaryAccount;
		}

		[Test]
		public void TestSalaryAccountConstructor()
		{
			var employee = new Employee(1, "Max", "Mustermann");
			var salaryAccount = new SalaryAccount(this.GetDefaultSalaryTypes(), employee);
		}

		[Test]
		public void TestSalaryAccountConstructorException()
		{
			Employee employee = null;
			Assert.Throws<ArgumentNullException>(() => { new SalaryAccount(this.GetDefaultSalaryTypes(), employee); });
		}

		[Test]
		public void TestSalaryAccountClone()
		{
			var salaryAccount = this.GetDefaultSalaryAccount();
			var defaultSalaryTypes = this.GetDefaultSalaryTypes();
			var salaryAccountCloned = (SalaryAccount)salaryAccount.Clone();
			salaryAccountCloned.AnnuityInsurance++;
			salaryAccountCloned.CompulsoryLongTermCareInsurance++;
			salaryAccountCloned.SicknessInsurance++;
			salaryAccountCloned.SolidarityTax++;
			salaryAccountCloned.UnemploymentInsurance++;
			salaryAccountCloned.WageTax++;

			Assert.AreEqual(salaryAccount.Salaries.Count, salaryAccountCloned.Salaries.Count);

			salaryAccountCloned.Salaries.Clear();
			var salaryType1 = defaultSalaryTypes.Find(st => st.Number == 2000);
			salaryAccountCloned.Salaries.Add(salaryType1, new SalaryItem(1234.56));
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
			var salaryAccount = new SalaryAccount(this.GetDefaultSalaryTypes(), employee) {
				SolidarityTax = 21.30,
				SicknessInsurance = 277.22,
				AnnuityInsurance = 312.29,
				CompulsoryLongTermCareInsurance = 47.60,
				UnemploymentInsurance = 50.10
			};
			Assert.AreEqual(21.30, salaryAccount.SolidarityTax);
			Assert.AreEqual(277.22, salaryAccount.SicknessInsurance);
			Assert.AreEqual(312.29, salaryAccount.AnnuityInsurance);
			Assert.AreEqual(47.60, salaryAccount.CompulsoryLongTermCareInsurance);
			Assert.AreEqual(50.10, salaryAccount.UnemploymentInsurance);
		}

		[Test]
		public void TestSalaryAccountInsertSalaryTypes()
		{
			var employee = new Employee(1, "Max", "Mustermann");
			var defaultSalaryTypes = this.GetDefaultSalaryTypes();
			var salaryAccount = new SalaryAccount(defaultSalaryTypes, employee);
			Settings.DefaultDataBackend = new SalaryDataXml(this._temporaryCombinedXmlFilename);
			foreach(var defaultSalaryType in defaultSalaryTypes) {
				Settings.DefaultDataBackend.InsertSalaryType(defaultSalaryType);
			}

			Assert.AreEqual(8, Settings.DefaultDataBackend.GetSalaryTypes().Count);

			var salaryType = Settings.DefaultDataBackend.GetSalaryType(1);
			Assert.AreEqual(1, salaryType.Id);
			Assert.AreEqual(2000, salaryType.Number);
			Assert.AreEqual("Gehalt", salaryType.Name);
			Assert.AreEqual(false, salaryType.DiscountOnNetWage);
			Assert.IsTrue(new SalaryType(1, 2000, "Gehalt") == salaryType);
		}

		[Test]
		public void TestSalaryAccountAddSalaryItems()
		{
			var employee = new Employee(1, "Max", "Mustermann");
			var defaultSalaryTypes = this.GetDefaultSalaryTypes();
			var salaryAccount = new SalaryAccount(defaultSalaryTypes, employee);
			Assert.AreEqual(0, salaryAccount.Salaries.Count);
			var salaryType1 = defaultSalaryTypes.Find(st => st.Number == 2000);
			var salaryType2 = defaultSalaryTypes.Find(st => st.Number == 3100);
			salaryAccount.Salaries.Add(salaryType1, new SalaryItem(3300.00));
			salaryAccount.Salaries.Add(salaryType2, new SalaryItem(40.00));
			Assert.AreEqual(2, salaryAccount.Salaries.Count);
		}

		[Test]
		public void TestSalaryAccountCalculateNetWage()
		{
			var employee = new Employee(1, "Max", "Mustermann");
			var defaultSalaryTypes = this.GetDefaultSalaryTypes();
			var salaryAccount = new SalaryAccount(defaultSalaryTypes, employee) {
				SolidarityTax = 21.30,
				SicknessInsurance = 277.22,
				AnnuityInsurance = 312.29,
				CompulsoryLongTermCareInsurance = 47.60,
				UnemploymentInsurance = 50.10,
				WageTax = 387.33
			};
			var salaryType1 = defaultSalaryTypes.Find(st => st.Number == 2000);
			var salaryType2 = defaultSalaryTypes.Find(st => st.Number == 3100);
			salaryAccount.Salaries.Add(salaryType1, new SalaryItem(3300.00));
			salaryAccount.Salaries.Add(salaryType2, new SalaryItem(40.00));

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
			var defaultSalaryTypes = this.GetDefaultSalaryTypes();
			var salaryAccount = this.GetDefaultSalaryAccount();

			Settings.DefaultDataBackend = new SalaryDataXml(this._temporaryCombinedXmlFilename);
			foreach (var salaryType in defaultSalaryTypes) {
				Settings.DefaultDataBackend.InsertSalaryType(salaryType);
			}
			Settings.DefaultDataBackend.InsertEmployee(salaryAccount.Employee);
			var newId = Settings.DefaultDataBackend.InsertSalary(salaryAccount);
			var newInsertedSalaryAccount = Settings.DefaultDataBackend.GetSalaryAccount(newId);
			Assert.IsTrue(salaryAccount == newInsertedSalaryAccount);
		}

		[Test]
		public void TestGetSalaryAccounts()
		{
			var employee = new Employee(1, "Max", "Mustermann");
			var defaultSalaryTypes = this.GetDefaultSalaryTypes();
			var salaryAccount = new SalaryAccount(defaultSalaryTypes, employee) {
				SolidarityTax = 21.30,
				SicknessInsurance = 277.22,
				AnnuityInsurance = 312.29,
				CompulsoryLongTermCareInsurance = 47.60,
				UnemploymentInsurance = 50.10,
				WageTax = 387.33
			};
			var salaryType1 = defaultSalaryTypes.Find(st => st.Number == 2000);
			var salaryType2 = defaultSalaryTypes.Find(st => st.Number == 3100);
			salaryAccount.Salaries.Add(salaryType1, new SalaryItem(3300.00));
			salaryAccount.Salaries.Add(salaryType2, new SalaryItem(40.00));

			Settings.DefaultDataBackend = new SalaryDataXml(this._temporaryCombinedXmlFilename);
			foreach (var salaryType in defaultSalaryTypes) {
				Settings.DefaultDataBackend.InsertSalaryType(salaryType);
			}
			Settings.DefaultDataBackend.InsertEmployee(employee);
			Settings.DefaultDataBackend.InsertSalary(salaryAccount);
			var salaryAccounts = Settings.DefaultDataBackend.GetSalaryAccounts();
			Assert.AreEqual(1, salaryAccounts.Count);
		}

		[Test]
		public void TestGetSalaryAccountsCallback()
		{
			var defaultSalaryTypes = this.GetDefaultSalaryTypes();
			var salaryAccount = this.GetDefaultSalaryAccount();
			Settings.DefaultDataBackend = new SalaryDataXml(this._temporaryCombinedXmlFilename);
			foreach (var salaryType in defaultSalaryTypes) {
				Settings.DefaultDataBackend.InsertSalaryType(salaryType);
			}
			Settings.DefaultDataBackend.InsertEmployee(salaryAccount.Employee);
			Settings.DefaultDataBackend.InsertSalary(salaryAccount);
			var salaryAccounts = Settings.DefaultDataBackend.GetSalaryAccounts((data) => {

			});
			Assert.AreEqual(1, salaryAccounts);
		}

		[Test]
		public void TestGetSalaryAccountsAsync()
		{
			var defaultSalaryTypes = this.GetDefaultSalaryTypes();
			var salaryAccount = this.GetDefaultSalaryAccount();
			Settings.DefaultDataBackend = new SalaryDataXml(this._temporaryCombinedXmlFilename);
			foreach (var salaryType in defaultSalaryTypes) {
				Settings.DefaultDataBackend.InsertSalaryType(salaryType);
			}
			Settings.DefaultDataBackend.InsertEmployee(salaryAccount.Employee);
			Settings.DefaultDataBackend.InsertSalary(salaryAccount);
			var salaryAccountsAsync = Settings.DefaultDataBackend.GetSalaryAccountsAsync();
			salaryAccountsAsync.Wait();
			Assert.AreEqual(1, salaryAccountsAsync.Result.Count);
		}

		[Test]
		public void TestGetSalaryAccountsByUserId()
		{
			var defaultSalaryTypes = this.GetDefaultSalaryTypes();
			var salaryAccount1 = this.GetDefaultSalaryAccount();
			var salaryAccount2 = this.GetAlternativeSalaryAccount();

			Settings.DefaultDataBackend = new SalaryDataXml(this._temporaryCombinedXmlFilename);
			foreach (var salaryType in defaultSalaryTypes) {
				Settings.DefaultDataBackend.InsertSalaryType(salaryType);
			}
			Settings.DefaultDataBackend.InsertEmployee(salaryAccount1.Employee);
			Settings.DefaultDataBackend.InsertEmployee(salaryAccount2.Employee);
			Settings.DefaultDataBackend.InsertSalary(salaryAccount1);
			Settings.DefaultDataBackend.InsertSalary(salaryAccount2);
			var salaryAccounts1 = Settings.DefaultDataBackend.GetSalaryAccounts(1);
			var salaryAccounts2 = Settings.DefaultDataBackend.GetSalaryAccounts(2);
			Assert.AreEqual(1, salaryAccounts1.Count);
			Assert.AreEqual(1, salaryAccounts2.Count);
		}

		[Test]
		public void TestGetSalaryAccountsByUserIdAsync()
		{
			var defaultSalaryTypes = this.GetDefaultSalaryTypes();
			var salaryAccount1 = this.GetDefaultSalaryAccount();
			var salaryAccount2 = this.GetAlternativeSalaryAccount();

			Settings.DefaultDataBackend = new SalaryDataXml(this._temporaryCombinedXmlFilename);
			foreach (var salaryType in defaultSalaryTypes) {
				Settings.DefaultDataBackend.InsertSalaryType(salaryType);
			}
			Settings.DefaultDataBackend.InsertEmployee(salaryAccount1.Employee);
			Settings.DefaultDataBackend.InsertEmployee(salaryAccount2.Employee);
			Settings.DefaultDataBackend.InsertSalary(salaryAccount1);
			Settings.DefaultDataBackend.InsertSalary(salaryAccount2);
			var salaryAccounts1 = Settings.DefaultDataBackend.GetSalaryAccounts(1, (data) => {

			});
			var salaryAccounts2 = Settings.DefaultDataBackend.GetSalaryAccounts(2, (data) => {

			});
			Assert.AreEqual(1, salaryAccounts1);
			Assert.AreEqual(1, salaryAccounts2);
		}

		[Test]
		public void TestUpdateSalaryAccount()
		{
			var defaultSalaryTypes = this.GetDefaultSalaryTypes();
			var salaryAccount = this.GetDefaultSalaryAccount();
			Settings.DefaultDataBackend = new SalaryDataXml(this._temporaryCombinedXmlFilename);
			foreach (var salaryType in defaultSalaryTypes) {
				Settings.DefaultDataBackend.InsertSalaryType(salaryType);
			}
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
			var defaultSalaryTypes = this.GetDefaultSalaryTypes();
			var salaryAccount = this.GetDefaultSalaryAccount();
			Settings.DefaultDataBackend = new SalaryDataXml(this._temporaryCombinedXmlFilename);
			foreach(var salaryType in defaultSalaryTypes) {
				Settings.DefaultDataBackend.InsertSalaryType(salaryType);
			}
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
