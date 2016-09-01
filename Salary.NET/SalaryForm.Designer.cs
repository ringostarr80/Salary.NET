namespace Salary.NET
{
	partial class SalaryForm
	{
		/// <summary>
		/// Erforderliche Designervariable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Verwendete Ressourcen bereinigen.
		/// </summary>
		/// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
		protected override void Dispose(bool disposing)
		{
			if(disposing && (components != null)) {
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Vom Windows Form-Designer generierter Code

		/// <summary>
		/// Erforderliche Methode für die Designerunterstützung.
		/// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SalaryForm));
			this.menuStripMain = new System.Windows.Forms.MenuStrip();
			this.toolStripMenuItemFile = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItemNew = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItemXMLFile = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItemOpen = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItemOpenXMLFile = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.toolStripMenuItemClose = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItemEdit = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItemEditAdd = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItemEditAddEmployee = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItemEditAddSalaryAccount = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItemOptions = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItemLanguage = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItemLanguageGermany = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItemLanguageEnglish = new System.Windows.Forms.ToolStripMenuItem();
			this.saveFileDialogNewDb = new System.Windows.Forms.SaveFileDialog();
			this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
			this.tabControlMain = new System.Windows.Forms.TabControl();
			this.tabPageEmployees = new System.Windows.Forms.TabPage();
			this.listViewEmployees = new System.Windows.Forms.ListView();
			this.columnHeaderId = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeaderPersonnelNumber = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeaderFirstName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeaderLastName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeaderBirthday = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.tabPageSalaries = new System.Windows.Forms.TabPage();
			this.contextMenuStripEmployees = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.toolStripMenuItemShowSalaryAccounts = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItemContextEmployeeEdit = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItemContextEmployeeDelete = new System.Windows.Forms.ToolStripMenuItem();
			this.listViewSalaryAccounts = new System.Windows.Forms.ListView();
			this.columnHeaderSalaryAccountId = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeaderSalaryAccountGross = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeaderSalaryAccountNet = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeaderSalaryAccountPeriod = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.menuStripMain.SuspendLayout();
			this.tabControlMain.SuspendLayout();
			this.tabPageEmployees.SuspendLayout();
			this.tabPageSalaries.SuspendLayout();
			this.contextMenuStripEmployees.SuspendLayout();
			this.SuspendLayout();
			// 
			// menuStripMain
			// 
			this.menuStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemFile,
            this.toolStripMenuItemEdit,
            this.toolStripMenuItemOptions});
			resources.ApplyResources(this.menuStripMain, "menuStripMain");
			this.menuStripMain.Name = "menuStripMain";
			// 
			// toolStripMenuItemFile
			// 
			this.toolStripMenuItemFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemNew,
            this.toolStripMenuItemOpen,
            this.toolStripSeparator1,
            this.toolStripMenuItemClose});
			this.toolStripMenuItemFile.Name = "toolStripMenuItemFile";
			resources.ApplyResources(this.toolStripMenuItemFile, "toolStripMenuItemFile");
			// 
			// toolStripMenuItemNew
			// 
			this.toolStripMenuItemNew.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemXMLFile});
			this.toolStripMenuItemNew.Name = "toolStripMenuItemNew";
			resources.ApplyResources(this.toolStripMenuItemNew, "toolStripMenuItemNew");
			// 
			// toolStripMenuItemXMLFile
			// 
			this.toolStripMenuItemXMLFile.Name = "toolStripMenuItemXMLFile";
			resources.ApplyResources(this.toolStripMenuItemXMLFile, "toolStripMenuItemXMLFile");
			this.toolStripMenuItemXMLFile.Click += new System.EventHandler(this.toolStripMenuItemXMLFile_Click);
			// 
			// toolStripMenuItemOpen
			// 
			this.toolStripMenuItemOpen.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemOpenXMLFile});
			this.toolStripMenuItemOpen.Name = "toolStripMenuItemOpen";
			resources.ApplyResources(this.toolStripMenuItemOpen, "toolStripMenuItemOpen");
			// 
			// toolStripMenuItemOpenXMLFile
			// 
			this.toolStripMenuItemOpenXMLFile.Name = "toolStripMenuItemOpenXMLFile";
			resources.ApplyResources(this.toolStripMenuItemOpenXMLFile, "toolStripMenuItemOpenXMLFile");
			this.toolStripMenuItemOpenXMLFile.Click += new System.EventHandler(this.toolStripMenuItemOpenXMLFile_Click);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			resources.ApplyResources(this.toolStripSeparator1, "toolStripSeparator1");
			// 
			// toolStripMenuItemClose
			// 
			this.toolStripMenuItemClose.Name = "toolStripMenuItemClose";
			resources.ApplyResources(this.toolStripMenuItemClose, "toolStripMenuItemClose");
			this.toolStripMenuItemClose.Click += new System.EventHandler(this.beendenToolStripMenuItem_Click);
			// 
			// toolStripMenuItemEdit
			// 
			this.toolStripMenuItemEdit.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemEditAdd});
			this.toolStripMenuItemEdit.Name = "toolStripMenuItemEdit";
			resources.ApplyResources(this.toolStripMenuItemEdit, "toolStripMenuItemEdit");
			// 
			// toolStripMenuItemEditAdd
			// 
			this.toolStripMenuItemEditAdd.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemEditAddEmployee,
            this.toolStripMenuItemEditAddSalaryAccount});
			resources.ApplyResources(this.toolStripMenuItemEditAdd, "toolStripMenuItemEditAdd");
			this.toolStripMenuItemEditAdd.Name = "toolStripMenuItemEditAdd";
			// 
			// toolStripMenuItemEditAddEmployee
			// 
			this.toolStripMenuItemEditAddEmployee.Name = "toolStripMenuItemEditAddEmployee";
			resources.ApplyResources(this.toolStripMenuItemEditAddEmployee, "toolStripMenuItemEditAddEmployee");
			this.toolStripMenuItemEditAddEmployee.Click += new System.EventHandler(this.toolStripMenuItemEditAddEmployee_Click);
			// 
			// toolStripMenuItemEditAddSalaryAccount
			// 
			this.toolStripMenuItemEditAddSalaryAccount.Name = "toolStripMenuItemEditAddSalaryAccount";
			resources.ApplyResources(this.toolStripMenuItemEditAddSalaryAccount, "toolStripMenuItemEditAddSalaryAccount");
			this.toolStripMenuItemEditAddSalaryAccount.Click += new System.EventHandler(this.toolStripMenuItemEditAddSalaryAccount_Click);
			// 
			// toolStripMenuItemOptions
			// 
			this.toolStripMenuItemOptions.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemLanguage});
			this.toolStripMenuItemOptions.Name = "toolStripMenuItemOptions";
			resources.ApplyResources(this.toolStripMenuItemOptions, "toolStripMenuItemOptions");
			// 
			// toolStripMenuItemLanguage
			// 
			this.toolStripMenuItemLanguage.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemLanguageGermany,
            this.toolStripMenuItemLanguageEnglish});
			this.toolStripMenuItemLanguage.Name = "toolStripMenuItemLanguage";
			resources.ApplyResources(this.toolStripMenuItemLanguage, "toolStripMenuItemLanguage");
			// 
			// toolStripMenuItemLanguageGermany
			// 
			this.toolStripMenuItemLanguageGermany.Checked = true;
			this.toolStripMenuItemLanguageGermany.CheckState = System.Windows.Forms.CheckState.Checked;
			this.toolStripMenuItemLanguageGermany.Name = "toolStripMenuItemLanguageGermany";
			resources.ApplyResources(this.toolStripMenuItemLanguageGermany, "toolStripMenuItemLanguageGermany");
			this.toolStripMenuItemLanguageGermany.Tag = "de";
			this.toolStripMenuItemLanguageGermany.Click += new System.EventHandler(this.toolStripMenuItemLanguageSelect_Click);
			// 
			// toolStripMenuItemLanguageEnglish
			// 
			this.toolStripMenuItemLanguageEnglish.Name = "toolStripMenuItemLanguageEnglish";
			resources.ApplyResources(this.toolStripMenuItemLanguageEnglish, "toolStripMenuItemLanguageEnglish");
			this.toolStripMenuItemLanguageEnglish.Tag = "en";
			this.toolStripMenuItemLanguageEnglish.Click += new System.EventHandler(this.toolStripMenuItemLanguageSelect_Click);
			// 
			// saveFileDialogNewDb
			// 
			resources.ApplyResources(this.saveFileDialogNewDb, "saveFileDialogNewDb");
			// 
			// tabControlMain
			// 
			this.tabControlMain.Controls.Add(this.tabPageEmployees);
			this.tabControlMain.Controls.Add(this.tabPageSalaries);
			resources.ApplyResources(this.tabControlMain, "tabControlMain");
			this.tabControlMain.Name = "tabControlMain";
			this.tabControlMain.SelectedIndex = 0;
			// 
			// tabPageEmployees
			// 
			this.tabPageEmployees.Controls.Add(this.listViewEmployees);
			resources.ApplyResources(this.tabPageEmployees, "tabPageEmployees");
			this.tabPageEmployees.Name = "tabPageEmployees";
			this.tabPageEmployees.UseVisualStyleBackColor = true;
			// 
			// listViewEmployees
			// 
			this.listViewEmployees.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderId,
            this.columnHeaderPersonnelNumber,
            this.columnHeaderFirstName,
            this.columnHeaderLastName,
            this.columnHeaderBirthday});
			resources.ApplyResources(this.listViewEmployees, "listViewEmployees");
			this.listViewEmployees.FullRowSelect = true;
			this.listViewEmployees.GridLines = true;
			this.listViewEmployees.MultiSelect = false;
			this.listViewEmployees.Name = "listViewEmployees";
			this.listViewEmployees.UseCompatibleStateImageBehavior = false;
			this.listViewEmployees.View = System.Windows.Forms.View.Details;
			this.listViewEmployees.MouseClick += new System.Windows.Forms.MouseEventHandler(this.listViewEmployees_MouseClick);
			this.listViewEmployees.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listViewEmployees_MouseDoubleClick);
			this.listViewEmployees.Resize += new System.EventHandler(this.listViewEmployees_Resize);
			// 
			// columnHeaderId
			// 
			resources.ApplyResources(this.columnHeaderId, "columnHeaderId");
			// 
			// columnHeaderPersonnelNumber
			// 
			resources.ApplyResources(this.columnHeaderPersonnelNumber, "columnHeaderPersonnelNumber");
			// 
			// columnHeaderFirstName
			// 
			resources.ApplyResources(this.columnHeaderFirstName, "columnHeaderFirstName");
			// 
			// columnHeaderLastName
			// 
			resources.ApplyResources(this.columnHeaderLastName, "columnHeaderLastName");
			// 
			// columnHeaderBirthday
			// 
			resources.ApplyResources(this.columnHeaderBirthday, "columnHeaderBirthday");
			// 
			// tabPageSalaries
			// 
			this.tabPageSalaries.Controls.Add(this.listViewSalaryAccounts);
			resources.ApplyResources(this.tabPageSalaries, "tabPageSalaries");
			this.tabPageSalaries.Name = "tabPageSalaries";
			this.tabPageSalaries.UseVisualStyleBackColor = true;
			// 
			// contextMenuStripEmployees
			// 
			this.contextMenuStripEmployees.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemShowSalaryAccounts,
            this.toolStripMenuItemContextEmployeeEdit,
            this.toolStripMenuItemContextEmployeeDelete});
			this.contextMenuStripEmployees.Name = "contextMenuStripEmployees";
			resources.ApplyResources(this.contextMenuStripEmployees, "contextMenuStripEmployees");
			// 
			// toolStripMenuItemShowSalaryAccounts
			// 
			this.toolStripMenuItemShowSalaryAccounts.Name = "toolStripMenuItemShowSalaryAccounts";
			resources.ApplyResources(this.toolStripMenuItemShowSalaryAccounts, "toolStripMenuItemShowSalaryAccounts");
			this.toolStripMenuItemShowSalaryAccounts.Click += new System.EventHandler(this.toolStripMenuItemShowSalaryAccounts_Click);
			// 
			// toolStripMenuItemContextEmployeeEdit
			// 
			this.toolStripMenuItemContextEmployeeEdit.Name = "toolStripMenuItemContextEmployeeEdit";
			resources.ApplyResources(this.toolStripMenuItemContextEmployeeEdit, "toolStripMenuItemContextEmployeeEdit");
			this.toolStripMenuItemContextEmployeeEdit.Click += new System.EventHandler(this.toolStripMenuItemContextEmployeeEdit_Click);
			// 
			// toolStripMenuItemContextEmployeeDelete
			// 
			this.toolStripMenuItemContextEmployeeDelete.Name = "toolStripMenuItemContextEmployeeDelete";
			resources.ApplyResources(this.toolStripMenuItemContextEmployeeDelete, "toolStripMenuItemContextEmployeeDelete");
			this.toolStripMenuItemContextEmployeeDelete.Click += new System.EventHandler(this.toolStripMenuItemContextEmployeeDelete_Click);
			// 
			// listViewSalaryAccounts
			// 
			this.listViewSalaryAccounts.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderSalaryAccountId,
            this.columnHeaderSalaryAccountGross,
            this.columnHeaderSalaryAccountNet,
            this.columnHeaderSalaryAccountPeriod});
			resources.ApplyResources(this.listViewSalaryAccounts, "listViewSalaryAccounts");
			this.listViewSalaryAccounts.FullRowSelect = true;
			this.listViewSalaryAccounts.GridLines = true;
			this.listViewSalaryAccounts.MultiSelect = false;
			this.listViewSalaryAccounts.Name = "listViewSalaryAccounts";
			this.listViewSalaryAccounts.UseCompatibleStateImageBehavior = false;
			this.listViewSalaryAccounts.View = System.Windows.Forms.View.Details;
			// 
			// columnHeaderSalaryAccountId
			// 
			resources.ApplyResources(this.columnHeaderSalaryAccountId, "columnHeaderSalaryAccountId");
			// 
			// columnHeaderSalaryAccountGross
			// 
			resources.ApplyResources(this.columnHeaderSalaryAccountGross, "columnHeaderSalaryAccountGross");
			// 
			// columnHeaderSalaryAccountNet
			// 
			resources.ApplyResources(this.columnHeaderSalaryAccountNet, "columnHeaderSalaryAccountNet");
			// 
			// columnHeaderSalaryAccountPeriod
			// 
			resources.ApplyResources(this.columnHeaderSalaryAccountPeriod, "columnHeaderSalaryAccountPeriod");
			// 
			// SalaryForm
			// 
			resources.ApplyResources(this, "$this");
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.tabControlMain);
			this.Controls.Add(this.menuStripMain);
			this.MainMenuStrip = this.menuStripMain;
			this.Name = "SalaryForm";
			this.Load += new System.EventHandler(this.SalaryForm_Load);
			this.menuStripMain.ResumeLayout(false);
			this.menuStripMain.PerformLayout();
			this.tabControlMain.ResumeLayout(false);
			this.tabPageEmployees.ResumeLayout(false);
			this.tabPageSalaries.ResumeLayout(false);
			this.contextMenuStripEmployees.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.MenuStrip menuStripMain;
		private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemFile;
		private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemClose;
		private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemOptions;
		private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemLanguage;
		private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemLanguageGermany;
		private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemLanguageEnglish;
		private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemNew;
		private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemXMLFile;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.SaveFileDialog saveFileDialogNewDb;
		private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemOpen;
		private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemOpenXMLFile;
		private System.Windows.Forms.OpenFileDialog openFileDialog;
		private System.Windows.Forms.TabControl tabControlMain;
		private System.Windows.Forms.TabPage tabPageEmployees;
		private System.Windows.Forms.TabPage tabPageSalaries;
		private System.Windows.Forms.ListView listViewEmployees;
		private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemEdit;
		private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemEditAdd;
		private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemEditAddEmployee;
		private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemEditAddSalaryAccount;
		private System.Windows.Forms.ColumnHeader columnHeaderId;
		private System.Windows.Forms.ColumnHeader columnHeaderPersonnelNumber;
		private System.Windows.Forms.ColumnHeader columnHeaderFirstName;
		private System.Windows.Forms.ColumnHeader columnHeaderLastName;
		private System.Windows.Forms.ColumnHeader columnHeaderBirthday;
		private System.Windows.Forms.ContextMenuStrip contextMenuStripEmployees;
		private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemContextEmployeeEdit;
		private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemContextEmployeeDelete;
		private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemShowSalaryAccounts;
		private System.Windows.Forms.ListView listViewSalaryAccounts;
		private System.Windows.Forms.ColumnHeader columnHeaderSalaryAccountId;
		private System.Windows.Forms.ColumnHeader columnHeaderSalaryAccountGross;
		private System.Windows.Forms.ColumnHeader columnHeaderSalaryAccountNet;
		private System.Windows.Forms.ColumnHeader columnHeaderSalaryAccountPeriod;
	}
}

