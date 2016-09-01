using System;
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

		public SalaryForm()
		{
			InitializeComponent();
		}

		private void SalaryForm_Load(object sender, EventArgs e)
		{
			this.AdjustEmployeesListView();
		}

		private void listViewEmployees_Resize(object sender, EventArgs e)
		{
			this.AdjustEmployeesListView();
		}

		private void AdjustEmployeesListView()
		{
			var listViewWidth = this.listViewEmployees.Width;
			var idWidth = this.listViewEmployees.Columns[0].Width;
			var personnelNumberWidth = this.listViewEmployees.Columns[1].Width;
			var birthdayWidth = this.listViewEmployees.Columns[4].Width;

			var minFirstNameWidth = 100;
			var minLastNameWidth = 100;
			var buffer = listViewWidth - (idWidth + 1 + personnelNumberWidth + 1 + birthdayWidth + 1 + minFirstNameWidth + 1 + minLastNameWidth);
			if (buffer <= 0) {
				this.listViewEmployees.Columns[2].Width = minFirstNameWidth;
				this.listViewEmployees.Columns[3].Width = minLastNameWidth;
				return;
			}

			var newFirstNameWidth = minFirstNameWidth + buffer / 2;
			var newLastNameWidth = minLastNameWidth + buffer / 2;
			this.listViewEmployees.Columns[2].Width = newFirstNameWidth;
			this.listViewEmployees.Columns[3].Width = newLastNameWidth;
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
			Console.WriteLine("changing language to: " + languageCode);
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

			this.columnHeaderPersonnelNumber.Text = this._resourceManager.GetString("columnHeaderPersonnelNumber.Text");
			this.columnHeaderFirstName.Text = this._resourceManager.GetString("columnHeaderFirstName.Text");
			this.columnHeaderLastName.Text = this._resourceManager.GetString("columnHeaderLastName.Text");
			this.columnHeaderBirthday.Text = this._resourceManager.GetString("columnHeaderBirthday.Text");

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
			foreach(var employee in employees) {
				var item = new ListViewItem(new string[] { employee.Id.ToString(), employee.PersonnelNumber, employee.FirstName, employee.LastName, employee.Birthday.ToShortDateString() });
				this.listViewEmployees.Items.Add(item);
			}
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
				var item = new ListViewItem(new string[] { id.ToString(), employee.PersonnelNumber, employee.FirstName, employee.LastName, employee.Birthday.ToShortDateString() });
				this.listViewEmployees.Items.Add(item);
			}
		}

		private void listViewEmployees_MouseClick(object sender, MouseEventArgs e)
		{
			if (e.Button != MouseButtons.Right) {
				return;
			}
			if (this.listViewEmployees.SelectedItems.Count != 1) {
				return;
			}

			this.contextMenuStripEmployees.Show(this.listViewEmployees, e.Location);
		}

		private void listViewEmployees_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			if(this.listViewEmployees.SelectedItems.Count != 1) {
				return;
			}

			var item = this.listViewEmployees.SelectedItems[0];
			var id = Convert.ToUInt32(item.SubItems[0].Text);
			this.ShowSalaryAccountsOfEmployee(id);
		}

		private void toolStripMenuItemShowSalaryAccounts_Click(object sender, EventArgs e)
		{
			if(this.listViewEmployees.SelectedItems.Count != 1) {
				return;
			}

			var item = this.listViewEmployees.SelectedItems[0];
			var id = Convert.ToUInt32(item.SubItems[0].Text);
			this.ShowSalaryAccountsOfEmployee(id);
		}

		private void ShowSalaryAccountsOfEmployee(uint id)
		{
			var employee = this._salaryData.GetEmployee(id);
			this.tabControlMain.SelectedTab = this.tabPageSalaries;
			this._openedEmployee = employee;
			this.Text = "Salary.NET - " + this._openedDataProvider + " (" + this._openedEmployee.GetInformalSalutation() + ")";
		}

		private void toolStripMenuItemContextEmployeeEdit_Click(object sender, EventArgs e)
		{
			var item = this.listViewEmployees.SelectedItems[0];
			var id = Convert.ToUInt32(item.SubItems[0].Text);
			var employee = this._salaryData.GetEmployee(id);

			using(var addEmployeeForm = new AddEmployeeForm(employee)) {
				var dialogResult = addEmployeeForm.ShowDialog();
				if(dialogResult == DialogResult.Cancel) {
					return;
				}

				var employeeEdit = addEmployeeForm.Employee;
				this._salaryData.UpdateEmployee(employee);
				item.SubItems[1].Text = employee.PersonnelNumber;
				item.SubItems[2].Text = employee.FirstName;
				item.SubItems[3].Text = employee.LastName;
				item.SubItems[4].Text = employee.Birthday.ToShortDateString();
			}
		}

		private void toolStripMenuItemContextEmployeeDelete_Click(object sender, EventArgs e)
		{
			var item = this.listViewEmployees.SelectedItems[0];
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
			this.listViewEmployees.Items.Remove(item);
		}
	}
}
