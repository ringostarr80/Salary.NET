using System;
using System.Globalization;
using System.IO;
using System.Resources;
using System.Threading;
using System.Windows.Forms;
using SalaryLibrary;
using SalaryLibrary.SalaryDataProviders;
using System.Drawing;
using ZedGraph;
using System.Linq;
using System.Diagnostics;
using System.Collections.Generic;

namespace Salary.NET
{
	public partial class SalaryForm : Form
	{
		private readonly ResourceManager _resourceManager = new ResourceManager("Salary.NET.SalaryForm", typeof(SalaryForm).Assembly);
		private readonly ResourceManager _localizations = new ResourceManager("Salary.NET.Strings", typeof(SalaryForm).Assembly);
		private ISalaryDataProvider _salaryData = null;
		private string _openedDataProvider = string.Empty;
		private Employee _openedEmployee = null;
		private object _clipboardSalaryId = null;
		private string _updateExecutable = string.Empty;

		public SalaryForm()
		{
			InitializeComponent();
		}

		private void SalaryForm_Load(object sender, EventArgs e)
		{
			this.AdjustEmployeesListView();
			this.AdjustSalaryAccountsListView();
		}

		private void ObjectListViewEmployees_Resize(object sender, EventArgs e)
		{
			this.AdjustEmployeesListView();
		}
		
		private void ObjectListViewSalaryAccounts_Resize(object sender, EventArgs e)
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

			/*
			this.userControlSalaryFilter.Left = 0;
			this.userControlSalaryFilter.Top = 0;
			this.userControlSalaryFilter.Width = this.tabPageSalaries.Width;

			this.objectListViewSalaryAccounts.Left = 0;
			this.objectListViewSalaryAccounts.Top = this.userControlSalaryFilter.Height;
			this.objectListViewSalaryAccounts.Width = this.tabPageSalaries.Width;
			this.objectListViewSalaryAccounts.Height = this.tabPageSalaries.Height - this.objectListViewSalaryAccounts.Top;
			*/

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

		private void UserControlSalaryFilter_Resize(object sender, EventArgs e)
		{
			this.splitContainerSalaryAccounts.SplitterDistance = this.userControlSalaryFilter.Height;
			//this.objectListViewSalaryAccounts.Top = this.userControlSalaryFilter.Height;
			//this.objectListViewSalaryAccounts.Height = this.tabPageSalaries.Height - this.userControlSalaryFilter.Height;
		}

		private void BeendenToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void ToolStripMenuItemLanguageSelect_Click(object sender, EventArgs e)
		{
			if (!(sender is ToolStripMenuItem)) {
				Console.WriteLine("if (!(sender is ToolStripMenuItem))");
				return;
			}

			var toolStripMenuItem = (ToolStripMenuItem)sender;
			var languageCode = toolStripMenuItem.Tag.ToString();
			switch(languageCode) {
				case "de":
				case "de-DE":
				case "":
					this.toolStripMenuItemLanguageEnglish.Checked = false;
					this.toolStripMenuItemLanguageEnglish.CheckState = CheckState.Unchecked;
					this.toolStripMenuItemLanguageGermany.Checked = true;
					this.toolStripMenuItemLanguageGermany.CheckState = CheckState.Checked;
					this.toolStripMenuItemLanguageJapanese.Checked = false;
					this.toolStripMenuItemLanguageJapanese.CheckState = CheckState.Unchecked;
					break;

				case "en":
				case "en-US":
					this.toolStripMenuItemLanguageGermany.Checked = false;
					this.toolStripMenuItemLanguageGermany.CheckState = CheckState.Unchecked;
					this.toolStripMenuItemLanguageEnglish.Checked = true;
					this.toolStripMenuItemLanguageEnglish.CheckState = CheckState.Checked;
					this.toolStripMenuItemLanguageJapanese.Checked = false;
					this.toolStripMenuItemLanguageJapanese.CheckState = CheckState.Unchecked;
					break;

				case "ja":
					this.toolStripMenuItemLanguageGermany.Checked = false;
					this.toolStripMenuItemLanguageGermany.CheckState = CheckState.Unchecked;
					this.toolStripMenuItemLanguageEnglish.Checked = false;
					this.toolStripMenuItemLanguageEnglish.CheckState = CheckState.Unchecked;
					this.toolStripMenuItemLanguageJapanese.Checked = true;
					this.toolStripMenuItemLanguageJapanese.CheckState = CheckState.Checked;
					break;

				default:
					Console.WriteLine("invalid or unknown language-code: " +languageCode);
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
			this.toolStripMenuItemEditChange.Text = this._resourceManager.GetString("toolStripMenuItemEditChange.Text");
			this.toolStripMenuItemEditAddEmployee.Text = this._resourceManager.GetString("toolStripMenuItemEditAddEmployee.Text");
			this.toolStripMenuItemEditAddSalaryAccount.Text = this._resourceManager.GetString("toolStripMenuItemEditAddSalaryAccount.Text");
			this.toolStripMenuItemShowSalaryAccounts.Text = this._resourceManager.GetString("toolStripMenuItemShowSalaryAccounts.Text");
			this.toolStripMenuItemAddSalaryTypes.Text = this._resourceManager.GetString("toolStripMenuItemAddSalaryTypes.Text");
			this.toolStripMenuItemChangeSalaryTypes.Text = this._resourceManager.GetString("toolStripMenuItemChangeSalaryTypes.Text");

			this.toolStripMenuItemOptions.Text = this._resourceManager.GetString("toolStripMenuItemOptions.Text");
			this.toolStripMenuItemLanguage.Text = this._resourceManager.GetString("toolStripMenuItemLanguage.Text");

			this.toolStripMenuItemHelp.Text = this._resourceManager.GetString("toolStripMenuItemHelp.Text");
			this.toolStripMenuItemCheckForUpdates.Text = this._resourceManager.GetString("toolStripMenuItemCheckForUpdates.Text");
			this.toolStripMenuItemAboutSalaryNET.Text = this._resourceManager.GetString("toolStripMenuItemAboutSalaryNET.Text");

			this.olvColumnHeaderPersonnelNumber.Text = this._resourceManager.GetString("olvColumnHeaderPersonnelNumber.Text");
			this.olvColumnHeaderFirstName.Text = this._resourceManager.GetString("olvColumnHeaderFirstName.Text");
			this.olvColumnHeaderLastName.Text = this._resourceManager.GetString("olvColumnHeaderLastName.Text");
			this.olvColumnHeaderBirthday.Text = this._resourceManager.GetString("olvColumnHeaderBirthday.Text");

			this.olvColumnGross.Text = this._resourceManager.GetString("olvColumnGross.Text");
			this.olvColumnNet.Text = this._resourceManager.GetString("olvColumnNet.Text");
			this.olvColumnPeriod.Text = this._resourceManager.GetString("olvColumnPeriod.Text");

			this.tabPageEmployees.Text = this._resourceManager.GetString("tabPageEmployees.Text");
			this.tabPageSalaries.Text = this._resourceManager.GetString("tabPageSalaries.Text");
			this.saveFileDialogNewDb.Filter = this._localizations.GetString("XML_FILE_FILTER");
			this.openFileDialog.Filter = this._localizations.GetString("XML_FILE_FILTER");

			this.userControlSalaryFilter.ChangeLocalization(languageCode);
		}

		public string GetLocalizedString(string name)
		{
			return this._localizations.GetString(name);
		}

		private void ToolStripMenuItemXMLFile_Click(object sender, EventArgs e)
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

			this.objectListViewEmployees.ClearObjects();

			this.toolStripMenuItemEditAdd.Enabled = true;
		}

		private void OnlineAccountToolStripMenuItem_Click(object sender, EventArgs e)
		{
			using (var createOnlineAccountForm = new CreateOnlineAccountForm()) {
				var dialogResult = createOnlineAccountForm.ShowDialog();
				if (dialogResult != DialogResult.OK) {
					return;
				}

				this._salaryData = new SalaryDataREST(createOnlineAccountForm.Username, createOnlineAccountForm.Password, createOnlineAccountForm.EncryptionPassword, createOnlineAccountForm.BaseUrl);
				this._openedDataProvider = "Online-Account: " + createOnlineAccountForm.Username;
				this.Text = "Salary.NET - " + this._openedDataProvider;

				this.objectListViewEmployees.ClearObjects();

				this.toolStripMenuItemEditAdd.Enabled = true;
			}
		}

		private void ToolStripMenuItemOpenXMLFile_Click(object sender, EventArgs e)
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
			this.toolStripMenuItemEditChange.Enabled = true;

			var employees = this._salaryData.GetEmployees();
			this.objectListViewEmployees.SetObjects(employees);

			var salaryTypes = this._salaryData.GetSalaryTypes();
			if (salaryTypes.HasConflictingElements) {
				MessageBox.Show("Es gibt Lohnarten, die miteinander in Konflikt stehen.", this._localizations.GetString("ERROR"), MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void OnlineAccountToolStripMenuItem1_Click(object sender, EventArgs e)
		{
			using (var loginToOnlineAccountForm = new LoginToOnlineAccountForm()) {
				var dialogResult = loginToOnlineAccountForm.ShowDialog();
				if (dialogResult != DialogResult.OK) {
					return;
				}

				this._salaryData = new SalaryDataREST(loginToOnlineAccountForm.Username, loginToOnlineAccountForm.Password, loginToOnlineAccountForm.EncryptionPassword, loginToOnlineAccountForm.BaseUrl);
				this._openedDataProvider = "Online-Account: " + loginToOnlineAccountForm.Username;
				this.Text = "Salary.NET - " + this._openedDataProvider;

				this.toolStripMenuItemEditAdd.Enabled = true;
				this.toolStripMenuItemEditChange.Enabled = true;

				try {
					var employees = this._salaryData.GetEmployees();
					this.objectListViewEmployees.SetObjects(employees);

					var salaryTypes = this._salaryData.GetSalaryTypes();
					if (salaryTypes.HasConflictingElements) {
						MessageBox.Show("Es gibt Lohnarten, die miteinander in Konflikt stehen.", this._localizations.GetString("ERROR"), MessageBoxButtons.OK, MessageBoxIcon.Error);
					}
				} catch (Exception exc) {
					MessageBox.Show("Fehler: " + exc.Message, this._localizations.GetString("ERROR"), MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}
		}

		private void ToolStripMenuItemEditAddSalaryAccount_Click(object sender, EventArgs e)
		{
			if (this._openedEmployee == null) {
				return;
			}

			var salaryTypes = this._salaryData.GetSalaryTypes();
			using (var addSalaryAccountForm = new AddSalaryAccountForm(salaryTypes, this._openedEmployee)) {
				var dialogResult = addSalaryAccountForm.ShowDialog();
				if (dialogResult == DialogResult.Cancel) {
					return;
				}
				this._salaryData.InsertSalary(addSalaryAccountForm.SalaryAccount);
				this.objectListViewSalaryAccounts.AddObject(addSalaryAccountForm.SalaryAccount);
			}
		}

		private void ToolStripMenuItemEditAddEmployee_Click(object sender, EventArgs e)
		{
			using(var addEmployeeForm = new AddEmployeeForm()) {
				var dialogResult = addEmployeeForm.ShowDialog();
				if(dialogResult == DialogResult.Cancel) {
					return;
				}

				var employee = addEmployeeForm.Employee;
				this._salaryData.InsertEmployee(employee);
				this.objectListViewEmployees.AddObject(employee);
			}
		}

		private void ObjectListViewEmployees_MouseClick(object sender, MouseEventArgs e)
		{
			if(e.Button != MouseButtons.Right) {
				return;
			}
			if(this.objectListViewEmployees.SelectedItems.Count != 1) {
				return;
			}

			this.contextMenuStripEmployees.Show(this.objectListViewEmployees, e.Location);
		}

		private void ObjectListViewEmployees_DoubleClick(object sender, EventArgs e)
		{
			if(this.objectListViewEmployees.SelectedItems.Count != 1) {
				return;
			}

			var item = this.objectListViewEmployees.SelectedItems[0];
			//var id = Convert.ToUInt32(item.SubItems[0].Text);
			this.ShowSalaryAccountsOfEmployee(item.SubItems[0].Text);
		}

		private void ToolStripMenuItemShowSalaryAccounts_Click(object sender, EventArgs e)
		{
			if(this.objectListViewEmployees.SelectedItems.Count != 1) {
				return;
			}

			var item = this.objectListViewEmployees.SelectedItems[0];
			//var id = Convert.ToUInt32(item.SubItems[0].Text);
			this.ShowSalaryAccountsOfEmployee(item.SubItems[0].Text);
		}

		private void ShowSalaryAccountsOfEmployee(object id)
		{
			var employee = this._salaryData.GetEmployee(id);
			this.tabControlMain.SelectedTab = this.tabPageSalaries;
			this._openedEmployee = employee;
			this.Text = "Salary.NET - " + this._openedDataProvider + " (" + this._openedEmployee.GetInformalSalutation() + ")";

			var salaryAccounts = this._salaryData.GetSalaryAccounts(id);
			this.objectListViewSalaryAccounts.Items.Clear();
			this.objectListViewSalaryAccounts.SetObjects(salaryAccounts);
			this.objectListViewSalaryAccounts.Sort(this.olvColumnPeriod, SortOrder.Descending);

			this.RefreshGraphControl();
		}

		private void RefreshGraphControl()
		{
			List<SalaryAccount> salaryAccounts = new List<SalaryAccount>();
			foreach(var obj in this.objectListViewSalaryAccounts.FilteredObjects) {
				salaryAccounts.Add((SalaryAccount)obj);
			}

			var graphPane = this.zedGraphControl1.GraphPane;
			graphPane.CurveList.RemoveAll(cl => true);
			graphPane.Title.Text = this._openedEmployee.GetInformalSalutation();
			graphPane.XAxis.Title.Text = this._localizations.GetString("PERIOD");
			graphPane.YAxis.Title.Text = this._localizations.GetString("INCOME");
			graphPane.XAxis.Type = AxisType.DateAsOrdinal;
			graphPane.YAxis.Type = AxisType.Linear;
			graphPane.Fill.Type = FillType.Solid;

			var grossWageData = new StockPointList();
			var netWageData = new StockPointList();
			var orderedSalaryAccounts = salaryAccounts.OrderBy(sa => sa.PeriodStart);
			foreach (var salaryAccount in orderedSalaryAccounts)
			{
				netWageData.Add(new XDate(salaryAccount.PeriodStart), salaryAccount.NetWage);
				grossWageData.Add(new XDate(salaryAccount.PeriodStart), salaryAccount.GrossWage);
			}
			graphPane.AddBar("Netto-Gehalt", netWageData, Color.Green);
			graphPane.AddBar("Brutto-Gehalt", grossWageData, Color.Blue);
			graphPane.BarSettings.Type = BarType.SortedOverlay;
			graphPane.AxisChange();
		}

		private void ToolStripMenuItemContextEmployeeEdit_Click(object sender, EventArgs e)
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

		private void ToolStripMenuItemContextEmployeeDelete_Click(object sender, EventArgs e)
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

		private void ObjectListViewSalaryAccounts_DoubleClick(object sender, EventArgs e)
		{
			this.OpenSelectedSalaryAccount();
		}

		private void ToolStripMenuItemSalaryAccountingsEdit_Click(object sender, EventArgs e)
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
			var salaryTypes = this._salaryData.GetSalaryTypes();
			using (var addSalaryAccountForm = new AddSalaryAccountForm(salaryTypes, salaryAccount)) {
				var dialogResult = addSalaryAccountForm.ShowDialog();
				if(dialogResult == DialogResult.Cancel) {
					return;
				}
				
				this._salaryData.UpdateSalary(addSalaryAccountForm.SalaryAccount);
				var modelObject = this.objectListViewSalaryAccounts.GetModelObject(item.Index);
				this.objectListViewSalaryAccounts.RemoveObject(modelObject);
				this.objectListViewSalaryAccounts.AddObject(addSalaryAccountForm.SalaryAccount);
				this.objectListViewSalaryAccounts.SelectedObject = addSalaryAccountForm.SalaryAccount;
			}
		}

		private void ObjectListViewSalaryAccounts_MouseUp(object sender, MouseEventArgs e)
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

		private void ToolStripMenuItemSalaryAccountingsDelete_Click(object sender, EventArgs e)
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

		private void ToolStripMenuItemSalaryAccountingsCopy_Click(object sender, EventArgs e)
		{
			var item = this.objectListViewSalaryAccounts.SelectedItems[0];
			this._clipboardSalaryId = Convert.ToUInt32(item.SubItems[0].Text);
		}

		private void ObjectListViewSalaryAccounts_KeyUp(object sender, KeyEventArgs e)
		{
			if (e.Control) {
				if (e.KeyCode == Keys.C) {
					if (this.objectListViewSalaryAccounts.SelectedIndex == -1) {
						return;
					}

					this.ToolStripMenuItemSalaryAccountingsCopy_Click(sender, e);
				} else if (e.KeyCode == Keys.V) {
					this.ToolStripMenuItemSalaryAccountingsPaste_Click(sender, e);
				}
			}
		}

		private void ToolStripMenuItemSalaryAccountingsPaste_Click(object sender, EventArgs e)
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

		private void LohnartenToolStripMenuItem_Click(object sender, EventArgs e)
		{
			using (var addSalaryTypeForm = new AddSalaryTypeForm()) {
				var dialogResult = addSalaryTypeForm.ShowDialog();
				if (dialogResult == DialogResult.Cancel) {
					return;
				}

				this._salaryData.InsertSalaryType(addSalaryTypeForm.SalaryType);
			}
		}

		private void LohnartenToolStripMenuItem1_Click(object sender, EventArgs e)
		{
			var salaryTypes = this._salaryData.GetSalaryTypes();
			using (var addSalaryTypeForm = new AddSalaryTypeForm(salaryTypes)) {
				var dialogResult = addSalaryTypeForm.ShowDialog();
				if (dialogResult == DialogResult.Cancel) {
					return;
				}

				this._salaryData.DeleteSalaryTypes();
				this._salaryData.InsertSalaryTypes(addSalaryTypeForm.SalaryTypes);
			}
		}

		private void UberSalaryNETToolStripMenuItem_Click(object sender, EventArgs e)
		{
			using (var aboutForm = new AboutForm()) {
				aboutForm.ShowDialog();
			}
		}

		private void AufUpdatesUberprufenToolStripMenuItem_Click(object sender, EventArgs e)
		{
			using (var updateForm = new CheckForUpdateForm()) {
				updateForm.ShowDialog();
				if (updateForm.UpdateExecutable != string.Empty) {
					this._updateExecutable = updateForm.UpdateExecutable;
					this.Close();
				}
			}
		}

		private void SalaryForm_FormClosed(object sender, FormClosedEventArgs e)
		{
			if (this._updateExecutable != string.Empty) {
				var psi = new ProcessStartInfo("msiexec", "/i \"" + this._updateExecutable + "\" REINSTALL=ALL REINSTALLMODE=vomus");
				Process.Start(psi);
			}
		}

		private void UserControlSalaryFilter_FilterChanged(object sender, EventArgs e)
		{
			this.objectListViewSalaryAccounts.ModelFilter = ((SalaryFilterEventArgs)e).ModelFilter;
			this.RefreshGraphControl();
		}
	}
}
