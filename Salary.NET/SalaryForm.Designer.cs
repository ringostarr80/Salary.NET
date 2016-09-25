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
			this.objectListViewEmployees = new BrightIdeasSoftware.ObjectListView();
			this.olvColumnHeaderId = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
			this.olvColumnHeaderPersonnelNumber = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
			this.olvColumnHeaderFirstName = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
			this.olvColumnHeaderLastName = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
			this.olvColumnHeaderBirthday = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
			this.tabPageSalaries = new System.Windows.Forms.TabPage();
			this.objectListViewSalaryAccounts = new BrightIdeasSoftware.ObjectListView();
			this.olvColumnId = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
			this.olvColumnGross = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
			this.olvColumnNet = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
			this.olvColumnPeriod = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
			this.contextMenuStripEmployees = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.toolStripMenuItemShowSalaryAccounts = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItemContextEmployeeEdit = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItemContextEmployeeDelete = new System.Windows.Forms.ToolStripMenuItem();
			this.contextMenuStripSalaryAccountings = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.toolStripMenuItemSalaryAccountingsEdit = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItemSalaryAccountingsCopy = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItemSalaryAccountingsPaste = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItemSalaryAccountingsDelete = new System.Windows.Forms.ToolStripMenuItem();
			this.menuStripMain.SuspendLayout();
			this.tabControlMain.SuspendLayout();
			this.tabPageEmployees.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.objectListViewEmployees)).BeginInit();
			this.tabPageSalaries.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.objectListViewSalaryAccounts)).BeginInit();
			this.contextMenuStripEmployees.SuspendLayout();
			this.contextMenuStripSalaryAccountings.SuspendLayout();
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
			this.tabPageEmployees.Controls.Add(this.objectListViewEmployees);
			resources.ApplyResources(this.tabPageEmployees, "tabPageEmployees");
			this.tabPageEmployees.Name = "tabPageEmployees";
			this.tabPageEmployees.UseVisualStyleBackColor = true;
			// 
			// objectListViewEmployees
			// 
			this.objectListViewEmployees.AllColumns.Add(this.olvColumnHeaderId);
			this.objectListViewEmployees.AllColumns.Add(this.olvColumnHeaderPersonnelNumber);
			this.objectListViewEmployees.AllColumns.Add(this.olvColumnHeaderFirstName);
			this.objectListViewEmployees.AllColumns.Add(this.olvColumnHeaderLastName);
			this.objectListViewEmployees.AllColumns.Add(this.olvColumnHeaderBirthday);
			this.objectListViewEmployees.CellEditUseWholeCell = false;
			this.objectListViewEmployees.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.olvColumnHeaderId,
            this.olvColumnHeaderPersonnelNumber,
            this.olvColumnHeaderFirstName,
            this.olvColumnHeaderLastName,
            this.olvColumnHeaderBirthday});
			this.objectListViewEmployees.Cursor = System.Windows.Forms.Cursors.Default;
			resources.ApplyResources(this.objectListViewEmployees, "objectListViewEmployees");
			this.objectListViewEmployees.FullRowSelect = true;
			this.objectListViewEmployees.GridLines = true;
			this.objectListViewEmployees.HideSelection = false;
			this.objectListViewEmployees.MultiSelect = false;
			this.objectListViewEmployees.Name = "objectListViewEmployees";
			this.objectListViewEmployees.ShowGroups = false;
			this.objectListViewEmployees.UseCompatibleStateImageBehavior = false;
			this.objectListViewEmployees.View = System.Windows.Forms.View.Details;
			this.objectListViewEmployees.DoubleClick += new System.EventHandler(this.objectListViewEmployees_DoubleClick);
			this.objectListViewEmployees.MouseClick += new System.Windows.Forms.MouseEventHandler(this.objectListViewEmployees_MouseClick);
			this.objectListViewEmployees.Resize += new System.EventHandler(this.objectListViewEmployees_Resize);
			// 
			// olvColumnHeaderId
			// 
			this.olvColumnHeaderId.AspectName = "Id";
			resources.ApplyResources(this.olvColumnHeaderId, "olvColumnHeaderId");
			// 
			// olvColumnHeaderPersonnelNumber
			// 
			this.olvColumnHeaderPersonnelNumber.AspectName = "PersonnelNumber";
			resources.ApplyResources(this.olvColumnHeaderPersonnelNumber, "olvColumnHeaderPersonnelNumber");
			// 
			// olvColumnHeaderFirstName
			// 
			this.olvColumnHeaderFirstName.AspectName = "FirstName";
			resources.ApplyResources(this.olvColumnHeaderFirstName, "olvColumnHeaderFirstName");
			// 
			// olvColumnHeaderLastName
			// 
			this.olvColumnHeaderLastName.AspectName = "LastName";
			resources.ApplyResources(this.olvColumnHeaderLastName, "olvColumnHeaderLastName");
			// 
			// olvColumnHeaderBirthday
			// 
			this.olvColumnHeaderBirthday.AspectName = "Birthday";
			this.olvColumnHeaderBirthday.AspectToStringFormat = "{0:yyyy}-{0:MM}-{0:dd}";
			resources.ApplyResources(this.olvColumnHeaderBirthday, "olvColumnHeaderBirthday");
			// 
			// tabPageSalaries
			// 
			this.tabPageSalaries.Controls.Add(this.objectListViewSalaryAccounts);
			resources.ApplyResources(this.tabPageSalaries, "tabPageSalaries");
			this.tabPageSalaries.Name = "tabPageSalaries";
			this.tabPageSalaries.UseVisualStyleBackColor = true;
			// 
			// objectListViewSalaryAccounts
			// 
			this.objectListViewSalaryAccounts.AllColumns.Add(this.olvColumnId);
			this.objectListViewSalaryAccounts.AllColumns.Add(this.olvColumnGross);
			this.objectListViewSalaryAccounts.AllColumns.Add(this.olvColumnNet);
			this.objectListViewSalaryAccounts.AllColumns.Add(this.olvColumnPeriod);
			this.objectListViewSalaryAccounts.CellEditUseWholeCell = false;
			this.objectListViewSalaryAccounts.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.olvColumnId,
            this.olvColumnGross,
            this.olvColumnNet,
            this.olvColumnPeriod});
			this.objectListViewSalaryAccounts.Cursor = System.Windows.Forms.Cursors.Default;
			resources.ApplyResources(this.objectListViewSalaryAccounts, "objectListViewSalaryAccounts");
			this.objectListViewSalaryAccounts.FullRowSelect = true;
			this.objectListViewSalaryAccounts.GridLines = true;
			this.objectListViewSalaryAccounts.HideSelection = false;
			this.objectListViewSalaryAccounts.MultiSelect = false;
			this.objectListViewSalaryAccounts.Name = "objectListViewSalaryAccounts";
			this.objectListViewSalaryAccounts.ShowGroups = false;
			this.objectListViewSalaryAccounts.UseCompatibleStateImageBehavior = false;
			this.objectListViewSalaryAccounts.View = System.Windows.Forms.View.Details;
			this.objectListViewSalaryAccounts.DoubleClick += new System.EventHandler(this.objectListViewSalaryAccounts_DoubleClick);
			this.objectListViewSalaryAccounts.MouseUp += new System.Windows.Forms.MouseEventHandler(this.objectListViewSalaryAccounts_MouseUp);
			this.objectListViewSalaryAccounts.Resize += new System.EventHandler(this.objectListViewSalaryAccounts_Resize);
			// 
			// olvColumnId
			// 
			this.olvColumnId.AspectName = "Id";
			resources.ApplyResources(this.olvColumnId, "olvColumnId");
			// 
			// olvColumnGross
			// 
			this.olvColumnGross.AspectName = "GrossWage";
			this.olvColumnGross.AspectToStringFormat = "{0:0.00} €";
			resources.ApplyResources(this.olvColumnGross, "olvColumnGross");
			// 
			// olvColumnNet
			// 
			this.olvColumnNet.AspectName = "NetWage";
			this.olvColumnNet.AspectToStringFormat = "{0:0.00} €";
			resources.ApplyResources(this.olvColumnNet, "olvColumnNet");
			// 
			// olvColumnPeriod
			// 
			this.olvColumnPeriod.AspectName = "FormattedPeriod";
			resources.ApplyResources(this.olvColumnPeriod, "olvColumnPeriod");
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
			// contextMenuStripSalaryAccountings
			// 
			this.contextMenuStripSalaryAccountings.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemSalaryAccountingsEdit,
            this.toolStripMenuItemSalaryAccountingsCopy,
            this.toolStripMenuItemSalaryAccountingsPaste,
            this.toolStripMenuItemSalaryAccountingsDelete});
			this.contextMenuStripSalaryAccountings.Name = "contextMenuStripSalaryAccountings";
			resources.ApplyResources(this.contextMenuStripSalaryAccountings, "contextMenuStripSalaryAccountings");
			// 
			// toolStripMenuItemSalaryAccountingsEdit
			// 
			this.toolStripMenuItemSalaryAccountingsEdit.Name = "toolStripMenuItemSalaryAccountingsEdit";
			resources.ApplyResources(this.toolStripMenuItemSalaryAccountingsEdit, "toolStripMenuItemSalaryAccountingsEdit");
			this.toolStripMenuItemSalaryAccountingsEdit.Click += new System.EventHandler(this.toolStripMenuItemSalaryAccountingsEdit_Click);
			// 
			// toolStripMenuItemSalaryAccountingsCopy
			// 
			this.toolStripMenuItemSalaryAccountingsCopy.Name = "toolStripMenuItemSalaryAccountingsCopy";
			resources.ApplyResources(this.toolStripMenuItemSalaryAccountingsCopy, "toolStripMenuItemSalaryAccountingsCopy");
			this.toolStripMenuItemSalaryAccountingsCopy.Click += new System.EventHandler(this.toolStripMenuItemSalaryAccountingsCopy_Click);
			// 
			// toolStripMenuItemSalaryAccountingsPaste
			// 
			this.toolStripMenuItemSalaryAccountingsPaste.Name = "toolStripMenuItemSalaryAccountingsPaste";
			resources.ApplyResources(this.toolStripMenuItemSalaryAccountingsPaste, "toolStripMenuItemSalaryAccountingsPaste");
			this.toolStripMenuItemSalaryAccountingsPaste.Click += new System.EventHandler(this.toolStripMenuItemSalaryAccountingsPaste_Click);
			// 
			// toolStripMenuItemSalaryAccountingsDelete
			// 
			this.toolStripMenuItemSalaryAccountingsDelete.Name = "toolStripMenuItemSalaryAccountingsDelete";
			resources.ApplyResources(this.toolStripMenuItemSalaryAccountingsDelete, "toolStripMenuItemSalaryAccountingsDelete");
			this.toolStripMenuItemSalaryAccountingsDelete.Click += new System.EventHandler(this.toolStripMenuItemSalaryAccountingsDelete_Click);
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
			((System.ComponentModel.ISupportInitialize)(this.objectListViewEmployees)).EndInit();
			this.tabPageSalaries.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.objectListViewSalaryAccounts)).EndInit();
			this.contextMenuStripEmployees.ResumeLayout(false);
			this.contextMenuStripSalaryAccountings.ResumeLayout(false);
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
		private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemEdit;
		private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemEditAdd;
		private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemEditAddEmployee;
		private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemEditAddSalaryAccount;
		private System.Windows.Forms.ContextMenuStrip contextMenuStripEmployees;
		private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemContextEmployeeEdit;
		private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemContextEmployeeDelete;
		private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemShowSalaryAccounts;
		private System.Windows.Forms.ContextMenuStrip contextMenuStripSalaryAccountings;
		private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemSalaryAccountingsEdit;
		private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemSalaryAccountingsDelete;
		private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemSalaryAccountingsCopy;
		private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemSalaryAccountingsPaste;
		private BrightIdeasSoftware.ObjectListView objectListViewSalaryAccounts;
		private BrightIdeasSoftware.OLVColumn olvColumnId;
		private BrightIdeasSoftware.OLVColumn olvColumnGross;
		private BrightIdeasSoftware.OLVColumn olvColumnNet;
		private BrightIdeasSoftware.OLVColumn olvColumnPeriod;
		private BrightIdeasSoftware.ObjectListView objectListViewEmployees;
		private BrightIdeasSoftware.OLVColumn olvColumnHeaderId;
		private BrightIdeasSoftware.OLVColumn olvColumnHeaderPersonnelNumber;
		private BrightIdeasSoftware.OLVColumn olvColumnHeaderFirstName;
		private BrightIdeasSoftware.OLVColumn olvColumnHeaderLastName;
		private BrightIdeasSoftware.OLVColumn olvColumnHeaderBirthday;
	}
}

