using System;
using System.IO;

using NUnit.Framework;
using SalaryLibrary;
using SalaryLibrary.SalaryDataProviders;

namespace SalaryLibraryNUnitTest
{
	[TestFixture]
	public class SalaryTypesTest
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
			if (File.Exists(this._temporaryCombinedXmlFilename))
			{
				//File.Delete(this._temporaryCombinedXmlFilename);
			}
		}

		private SalaryType GetDefaultSalaryType1()
		{
			return new SalaryType(1, 2000, "Gehalt");
		}

		private SalaryType GetDefaultSalaryType2()
		{
			return new SalaryType(2, 2033, "Freiwillige Zulage", true);
		}

		[Test]
		public void TestSalaryTypeConstructor()
		{
			var salaryType1 = this.GetDefaultSalaryType1();
			Assert.AreEqual(1, salaryType1.Id);
			Assert.AreEqual(2000, salaryType1.Number);
			Assert.AreEqual("Gehalt", salaryType1.Name);
			Assert.AreEqual(false, salaryType1.DiscountOnNetWage);

			var salaryType2 = this.GetDefaultSalaryType2();
			Assert.AreEqual(2, salaryType2.Id);
			Assert.AreEqual(2033, salaryType2.Number);
			Assert.AreEqual("Freiwillige Zulage", salaryType2.Name);
			Assert.AreEqual(true, salaryType2.DiscountOnNetWage);
		}

		[Test]
		public void TestSalaryTypeInsert()
		{
			Settings.DefaultDataBackend = new SalaryDataXml(this._temporaryCombinedXmlFilename);

			var salaryType1 = this.GetDefaultSalaryType1();
			var newId1 = Settings.DefaultDataBackend.InsertSalaryType(salaryType1);
			Assert.AreEqual(1, newId1);

			var loadSalaryType = Settings.DefaultDataBackend.GetSalaryType(newId1);
			Assert.IsTrue(salaryType1 == loadSalaryType);
		}

		[Test]
		public void TestConflictingSalaryTypes()
		{
			var salaryTypes = new SalaryTypeCollection {
				this.GetDefaultSalaryType1(),
				this.GetDefaultSalaryType2()
			};
			Assert.IsFalse(salaryTypes.HasConflictingElements);
			salaryTypes.Add(this.GetDefaultSalaryType1());
			Assert.IsTrue(salaryTypes.HasConflictingElements);
		}
	}
}
