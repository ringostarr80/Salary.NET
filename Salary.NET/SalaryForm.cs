﻿using System;
using System.Globalization;
using System.IO;
using System.Resources;
using System.Threading;
using System.Windows.Forms;
using SalaryLibrary;
using SalaryLibrary.SalaryDataProviders;

namespace Salary.NET
{
	public partial class SalaryForm : Form
	{
		private ResourceManager _resourceManager = new ResourceManager("Salary.NET.SalaryForm", typeof(SalaryForm).Assembly);
		private ResourceManager _localizations = new ResourceManager("Salary.NET.Strings", typeof(SalaryForm).Assembly);
		private ISalaryDataProvider _salaryData = null;
		private string _openedDataProvider = String.Empty;
		private Employee _openedEmployee = null;
		private object _clipboardSalaryId = null;

		public SalaryForm()
		{
			InitializeComponent();
		}

		private void SalaryForm_Load(object sender, EventArgs e)
		{
			this.AdjustEmployeesListView();
			this.AdjustSalaryAccountsListView();
		}

		private void objectListViewEmployees_Resize(object sender, EventArgs e)
		{
			this.AdjustEmployeesListView();
		}
		
		private void objectListViewSalaryAccounts_Resize(object sender, EventArgs e)
		{
			this.AdjustSalaryAccountsListView();
		}

		private void AdjustEmployeesListView()
		{
			var listViewWidth = this.objectListViewEmployees.Width;
			var idWidth = this.objectListViewEmployees.Columns[0].Width;
			var personnelNumberWidth = this.objectListViewEmployees.Columns[1].Width;
			var birthdayWidth = this.objectListViewEmployees.Columns[4].Width;

			var minFirstNameWidth = 100;
			var minLastNameWidth = 100;
			var buffer = listViewWidth - (idWidth + 1 + personnelNumberWidth + 1 + birthdayWidth + 1 + minFirstNameWidth + 1 + minLastNameWidth);
			if (buffer <= 0) {
				this.objectListViewEmployees.Columns[2].Width = minFirstNameWidth;
				this.objectListViewEmployees.Columns[3].Width = minLastNameWidth;
				return;
			}

			var newFirstNameWidth = minFirstNameWidth + buffer / 2;
			var newLastNameWidth = minLastNameWidth + buffer / 2;
			this.objectListViewEmployees.Columns[2].Width = newFirstNameWidth;
			this.objectListViewEmployees.Columns[3].Width = newLastNameWidth;
		}

		private void AdjustSalaryAccountsListView()
		{
			var listViewWidth = this.objectListViewSalaryAccounts.Width;
			var idWidth = this.objectListViewSalaryAccounts.Columns[0].Width;
			var periodWidth = this.objectListViewSalaryAccounts.Columns[3].Width;

			var minGrossWageWidth = 100;
			var minNetWageWidth = 100;
			var buffer = listViewWidth - (idWidth + 1 + periodWidth + 1 + minGrossWageWidth + 1 + minNetWageWidth + 1);
			if(buffer <= 0) {
				this.objectListViewSalaryAccounts.Columns[1].Width = minGrossWageWidth;
				this.objectListViewSalaryAccounts.Columns[1].Width = minNetWageWidth;
				return;
			}

			var newGrossWageWidth = minGrossWageWidth + buffer / 2;
			var newNetWageWidth = minNetWageWidth + buffer / 2;
			this.objectListViewSalaryAccounts.Columns[1].Width = newGrossWageWidth;
			this.objectListViewSalaryAccounts.Columns[2].Width = newNetWageWidth;
		}

		private void beendenToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void toolStripMenuItemLanguageSelect_Click(object sender, EventArgs e)
		{
			if (!(sender is ToolStripMenuItem)) {
				return;
			}

			var toolStripMenuItem = (ToolStripMenuItem)sender;
			var languageCode = toolStripMenuItem.Tag.ToString();
			switch(languageCode) {
				case "de":
				case "de-DE":
					this.toolStripMenuItemLanguageEnglish.Checked = false;
					this.toolStripMenuItemLanguageEnglish.CheckState = CheckState.Unchecked;
					this.toolStripMenuItemLanguageGermany.Checked = true;
					this.toolStripMenuItemLanguageGermany.CheckState = CheckState.Checked;
					break;

				case "en":
				case "en-US":
					this.toolStripMenuItemLanguageGermany.Checked = false;
					this.toolStripMenuItemLanguageGermany.CheckState = CheckState.Unchecked;
					this.toolStripMenuItemLanguageEnglish.Checked = true;
					this.toolStripMenuItemLanguageEnglish.CheckState = CheckState.Checked;
					break;
			}

			Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo(languageCode);

			this.toolStripMenuItemFile.Text = this._resourceManager.GetString("toolStripMenuItemFile.Text");
			this.toolStripMenuItemNew.Text = this._resourceManager.GetString("toolStripMenuItemNew.Text");
			this.toolStripMenuItemXMLFile.Text = this._resourceManager.GetString("toolStripMenuItemXMLFile.Text");
			this.toolStripMenuItemOpen.Text = this._resourceManager.GetString("toolStripMenuItemOpen.Text");
			this.toolStripMenuItemOpenXMLFile.Text = this._resourceManager.GetString("toolStripMenuItemOpenXMLFile.Text");
			this.toolStripMenuItemClose.Text = this._resourceManager.GetString("toolStripMenuItemClose.Text");

			this.toolStripMenuItemEdit.Text = this._resourceManager.GetString("toolStripMenuItemEdit.Text");
			this.toolStripMenuItemEditAdd.Text = this._resourceManager.GetString("toolStripMenuItemEditAdd.Text");
			this.toolStripMenuItemEditAddEmployee.Text = this._resourceManager.GetString("toolStripMenuItemEditAddEmployee.Text");
			this.toolStripMenuItemEditAddSalaryAccount.Text = this._resourceManager.GetString("toolStripMenuItemEditAddSalaryAccount.Text");
			this.toolStripMenuItemShowSalaryAccounts.Text = this._resourceManager.GetString("toolStripMenuItemShowSalaryAccounts.Text");

			this.toolStripMenuItemOptions.Text = this._resourceManager.GetString("toolStripMenuItemOptions.Text");
			this.toolStripMenuItemLanguage.Text = this._resourceManager.GetString("toolStripMenuItemLanguage.Text");

			this.olvColumnHeaderPersonnelNumber.Text = this._resourceManager.GetString("columnHeaderPersonnelNumber.Text");
			this.olvColumnHeaderFirstName.Text = this._resourceManager.GetString("columnHeaderFirstName.Text");
			this.olvColumnHeaderLastName.Text = this._resourceManager.GetString("columnHeaderLastName.Text");
			this.olvColumnHeaderBirthday.Text = this._resourceManager.GetString("columnHeaderBirthday.Text");

			this.tabPageEmployees.Text = this._resourceManager.GetString("tabPageEmployees.Text");
			this.tabPageSalaries.Text = this._resourceManager.GetString("tabPageSalaries.Text");
			this.saveFileDialogNewDb.Filter = this._localizations.GetString("XML_FILE_FILTER");
			this.openFileDialog.Filter = this._localizations.GetString("XML_FILE_FILTER");
		}

		private void toolStripMenuItemXMLFile_Click(object sender, EventArgs e)
		{
			var dialogResult = this.saveFileDialogNewDb.ShowDialog();
			if (dialogResult == DialogResult.Cancel) {
				return;
			}

			if (File.Exists(this.saveFileDialogNewDb.FileName)) {
				File.Delete(this.saveFileDialogNewDb.FileName);
			}
			
			this._salaryData = new SalaryDataXml(this.saveFileDialogNewDb.FileName);
			var fileInfo = new FileInfo(this.saveFileDialogNewDb.FileName);
			this._openedDataProvider = fileInfo.Name;
			this.Text = "Salary.NET - " + this._openedDataProvider;

			this.toolStripMenuItemEditAdd.Enabled = true;
		}

		private void toolStripMenuItemOpenXMLFile_Click(object sender, EventArgs e)
		{
			var dialogResult = this.openFileDialog.ShowDialog();
			if(dialogResult == DialogResult.Cancel) {
				return;
			}
			
			this._salaryData = new SalaryDataXml(this.openFileDialog.FileName);
			var fileInfo = new FileInfo(this.openFileDialog.FileName);
			this._openedDataProvider = fileInfo.Name;
			this.Text = "Salary.NET - " + this._openedDataProvider;

			this.toolStripMenuItemEditAdd.Enabled = true;

			var employees = this._salaryData.GetEmployees();
			this.objectListViewEmployees.SetObjects(employees);
		}

		private void toolStripMenuItemEditAddSalaryAccount_Click(object sender, EventArgs e)
		{
			if (this._openedEmployee == null) {
				return;
			}

			using(var addSalaryAccountForm = new AddSalaryAccountForm(this._openedEmployee)) {
				var dialogResult = addSalaryAccountForm.ShowDialog();
				if (dialogResult == DialogResult.Cancel) {
					return;
				}
				this._salaryData.InsertSalary(addSalaryAccountForm.SalaryAccount);
			}
		}

		private void toolStripMenuItemEditAddEmployee_Click(object sender, EventArgs e)
		{
			using(var addEmployeeForm = new AddEmployeeForm()) {
				var dialogResult = addEmployeeForm.ShowDialog();
				if(dialogResult == DialogResult.Cancel) {
					return;
				}

				var employee = addEmployeeForm.Employee;
				var id = this._salaryData.InsertEmployee(employee);
				this.objectListViewEmployees.AddObject(employee);
			}
		}

		private void objectListViewEmployees_MouseClick(object sender, MouseEventArgs e)
		{
			if(e.Button != MouseButtons.Right) {
				return;
			}
			if(this.objectListViewEmployees.SelectedItems.Count != 1) {
				return;
			}

			this.contextMenuStripEmployees.Show(this.objectListViewEmployees, e.Location);
		}

		private void objectListViewEmployees_DoubleClick(object sender, EventArgs e)
		{
			if(this.objectListViewEmployees.SelectedItems.Count != 1) {
				return;
			}

			var item = this.objectListViewEmployees.SelectedItems[0];
			var id = Convert.ToUInt32(item.SubItems[0].Text);
			this.ShowSalaryAccountsOfEmployee(id);
		}

		private void toolStripMenuItemShowSalaryAccounts_Click(object sender, EventArgs e)
		{
			if(this.objectListViewEmployees.SelectedItems.Count != 1) {
				return;
			}

			var item = this.objectListViewEmployees.SelectedItems[0];
			var id = Convert.ToUInt32(item.SubItems[0].Text);
			this.ShowSalaryAccountsOfEmployee(id);
		}

		private void ShowSalaryAccountsOfEmployee(uint id)
		{
			var employee = this._salaryData.GetEmployee(id);
			this.tabControlMain.SelectedTab = this.tabPageSalaries;
			this._openedEmployee = employee;
			this.Text = "Salary.NET - " + this._openedDataProvider + " (" + this._openedEmployee.GetInformalSalutation() + ")";

			this.objectListViewSalaryAccounts.Items.Clear();
			this.objectListViewSalaryAccounts.SetObjects(this._salaryData.GetSalaryAccounts());
		}

		private void toolStripMenuItemContextEmployeeEdit_Click(object sender, EventArgs e)
		{
			var employee = (Employee)this.objectListViewEmployees.GetModelObject(this.objectListViewEmployees.SelectedIndex);

			using(var addEmployeeForm = new AddEmployeeForm(employee)) {
				var dialogResult = addEmployeeForm.ShowDialog();
				if(dialogResult == DialogResult.Cancel) {
					return;
				}

				var employeeEdit = addEmployeeForm.Employee;
				this._salaryData.UpdateEmployee(employeeEdit);
				this.objectListViewEmployees.UpdateObject(employeeEdit);
			}
		}

		private void toolStripMenuItemContextEmployeeDelete_Click(object sender, EventArgs e)
		{
			var item = this.objectListViewEmployees.SelectedItems[0];
			var firstName = item.SubItems[2].Text;
			var lastName = item.SubItems[3].Text;
			var fullEmployeeName = firstName.Trim();
			if (lastName.Trim() != String.Empty) {
				if (fullEmployeeName != String.Empty) {
					fullEmployeeName += " ";
				}
				fullEmployeeName += lastName.Trim();
			}
			var confirmMessage = this._localizations.GetString("CONFIRM_EMPLOYEE_DELETION").Replace("%s", fullEmployeeName);
			var dialogResult = MessageBox.Show(confirmMessage, this._localizations.GetString("WARNING"), MessageBoxButtons.YesNo, MessageBoxIcon.Question);
			if (dialogResult == DialogResult.No) {
				return;
			}

			var id = Convert.ToUInt32(item.SubItems[0].Text);
			this._salaryData.DeleteEmployee(id);
			this.objectListViewEmployees.Items.Remove(item);
		}

		private void objectListViewSalaryAccounts_DoubleClick(object sender, EventArgs e)
		{
			this.OpenSelectedSalaryAccount();
		}

		private void toolStripMenuItemSalaryAccountingsEdit_Click(object sender, EventArgs e)
		{
			this.OpenSelectedSalaryAccount();
		}

		private void OpenSelectedSalaryAccount()
		{
			if(this.objectListViewSalaryAccounts.SelectedItems.Count != 1) {
				return;
			}

			var item = this.objectListViewSalaryAccounts.SelectedItems[0];
			var id = Convert.ToUInt32(item.SubItems[0].Text);
			var salaryAccount = this._salaryData.GetSalaryAccount(id);
			using(var addSalaryAccountForm = new AddSalaryAccountForm(salaryAccount)) {
				var dialogResult = addSalaryAccountForm.ShowDialog();
				if(dialogResult == DialogResult.Cancel) {
					return;
				}

				item.SubItems[1].Text = String.Format("{0:0.00} €", addSalaryAccountForm.SalaryAccount.GrossWage);
				item.SubItems[2].Text = String.Format("{0:0.00} €", addSalaryAccountForm.SalaryAccount.NetWage);
				var periodString = String.Format("{0}-{1:00}", salaryAccount.PeriodStart.Year, salaryAccount.PeriodStart.Month);
				if(salaryAccount.PeriodStart.Day != 1 ||
					salaryAccount.PeriodEnd.Day != DateTime.DaysInMonth(salaryAccount.PeriodStart.Year, salaryAccount.PeriodStart.Month)) {
					periodString += String.Format("-{0:00} - {1}-{2:00}-{3:00}", salaryAccount.PeriodStart.Day, salaryAccount.PeriodEnd.Year, salaryAccount.PeriodEnd.Month, salaryAccount.PeriodEnd.Day);
				}
				item.SubItems[3].Text = periodString;
				this._salaryData.UpdateSalary(addSalaryAccountForm.SalaryAccount);
			}
		}

		private void objectListViewSalaryAccounts_MouseUp(object sender, MouseEventArgs e)
		{
			if(e.Button != MouseButtons.Right) {
				return;
			}

			var editable = (this.objectListViewSalaryAccounts.SelectedItems.Count >= 1);
			this.toolStripMenuItemSalaryAccountingsCopy.Enabled = editable;
			this.toolStripMenuItemSalaryAccountingsEdit.Enabled = editable;
			this.toolStripMenuItemSalaryAccountingsDelete.Enabled = editable;

			this.toolStripMenuItemSalaryAccountingsPaste.Enabled = (this._clipboardSalaryId != null);

			this.contextMenuStripSalaryAccountings.Show(this.objectListViewSalaryAccounts, e.Location);
		}

		private void toolStripMenuItemSalaryAccountingsDelete_Click(object sender, EventArgs e)
		{
			var item = this.objectListViewSalaryAccounts.SelectedItems[0];
			var id = Convert.ToUInt32(item.SubItems[0].Text);
			var confirmMessage = this._localizations.GetString("CONFIRM_SALARY_ACCOUNTING_DELETION").Replace("%s", item.SubItems[0].Text);
			var dialogResult = MessageBox.Show(confirmMessage, this._localizations.GetString("WARNING"), MessageBoxButtons.YesNo, MessageBoxIcon.Question);
			if(dialogResult == DialogResult.No) {
				return;
			}

			this._salaryData.DeleteSalary(id);
			this.objectListViewSalaryAccounts.Items.Remove(item);
		}

		private void toolStripMenuItemSalaryAccountingsCopy_Click(object sender, EventArgs e)
		{
			var item = this.objectListViewSalaryAccounts.SelectedItems[0];
			var id = Convert.ToUInt32(item.SubItems[0].Text);
			this._clipboardSalaryId = id;
		}

		private void toolStripMenuItemSalaryAccountingsPaste_Click(object sender, EventArgs e)
		{
			if(this._clipboardSalaryId == null) {
				return;
			}

			var salaryAccount = this._salaryData.GetSalaryAccount(this._clipboardSalaryId);
			if (salaryAccount == null) {
				return;
			}
			var newSalaryAccount = (SalaryAccount)salaryAccount.Clone();
			this._salaryData.InsertSalary(newSalaryAccount);

			this.objectListViewSalaryAccounts.AddObject(newSalaryAccount);
		}
	}
}
