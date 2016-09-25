namespace Salary.NET
{
	partial class AddSalaryAccountForm
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if(disposing && (components != null)) {
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddSalaryAccountForm));
			this.buttonAdd = new System.Windows.Forms.Button();
			this.buttonCancel = new System.Windows.Forms.Button();
			this.labelWageTax = new System.Windows.Forms.Label();
			this.numericUpDownWageTax = new System.Windows.Forms.NumericUpDown();
			this.labelSolidarityTax = new System.Windows.Forms.Label();
			this.numericUpDownSolidarityTax = new System.Windows.Forms.NumericUpDown();
			this.numericUpDownSicknessInsurance = new System.Windows.Forms.NumericUpDown();
			this.labelSicknessInsurance = new System.Windows.Forms.Label();
			this.numericUpDownAnnuityInsurance = new System.Windows.Forms.NumericUpDown();
			this.labelAnnuityInsurance = new System.Windows.Forms.Label();
			this.numericUpDownUnemploymentInsurance = new System.Windows.Forms.NumericUpDown();
			this.labelUnemploymentInsurance = new System.Windows.Forms.Label();
			this.numericUpDownCompulsoryLongTermCareInsurance = new System.Windows.Forms.NumericUpDown();
			this.labelCompulsoryLongTermCareInsurance = new System.Windows.Forms.Label();
			this.labelTotalGross = new System.Windows.Forms.Label();
			this.textBoxTotalGross = new System.Windows.Forms.TextBox();
			this.textBoxTotalNet = new System.Windows.Forms.TextBox();
			this.labelTotalNet = new System.Windows.Forms.Label();
			this.buttonEdit = new System.Windows.Forms.Button();
			this.labelPeriod = new System.Windows.Forms.Label();
			this.comboBoxPeriodYear = new System.Windows.Forms.ComboBox();
			this.comboBoxPeriodMonth = new System.Windows.Forms.ComboBox();
			this.userControlSalaryItems1 = new Salary.NET.UserControlSalaryItems();
			this.checkBoxPeriodFromTo = new System.Windows.Forms.CheckBox();
			this.comboBoxPeriodFromDay = new System.Windows.Forms.ComboBox();
			this.comboBoxPeriodToDay = new System.Windows.Forms.ComboBox();
			this.textBoxWageTaxPercentage = new System.Windows.Forms.TextBox();
			this.textBoxSolidarityTaxPercentage = new System.Windows.Forms.TextBox();
			this.textBoxSicknessInsurancePercentage = new System.Windows.Forms.TextBox();
			this.textBoxAnnuityInsurancePercentage = new System.Windows.Forms.TextBox();
			this.textBoxUnemploymentInsurancePercentage = new System.Windows.Forms.TextBox();
			this.textBoxCompulsoryLongTermCareInsurancePercentage = new System.Windows.Forms.TextBox();
			this.textBoxTotalGrossPercentage = new System.Windows.Forms.TextBox();
			this.textBoxTotalNetPercentage = new System.Windows.Forms.TextBox();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownWageTax)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownSolidarityTax)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownSicknessInsurance)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownAnnuityInsurance)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownUnemploymentInsurance)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownCompulsoryLongTermCareInsurance)).BeginInit();
			this.SuspendLayout();
			// 
			// buttonAdd
			// 
			resources.ApplyResources(this.buttonAdd, "buttonAdd");
			this.buttonAdd.Name = "buttonAdd";
			this.buttonAdd.UseVisualStyleBackColor = true;
			this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
			// 
			// buttonCancel
			// 
			resources.ApplyResources(this.buttonCancel, "buttonCancel");
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.UseVisualStyleBackColor = true;
			this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
			// 
			// labelWageTax
			// 
			resources.ApplyResources(this.labelWageTax, "labelWageTax");
			this.labelWageTax.Name = "labelWageTax";
			// 
			// numericUpDownWageTax
			// 
			this.numericUpDownWageTax.DecimalPlaces = 2;
			resources.ApplyResources(this.numericUpDownWageTax, "numericUpDownWageTax");
			this.numericUpDownWageTax.Maximum = new decimal(new int[] {
            1000000000,
            0,
            0,
            0});
			this.numericUpDownWageTax.Name = "numericUpDownWageTax";
			this.numericUpDownWageTax.ValueChanged += new System.EventHandler(this.numericUpDownWageTax_ValueChanged);
			// 
			// labelSolidarityTax
			// 
			resources.ApplyResources(this.labelSolidarityTax, "labelSolidarityTax");
			this.labelSolidarityTax.Name = "labelSolidarityTax";
			// 
			// numericUpDownSolidarityTax
			// 
			this.numericUpDownSolidarityTax.DecimalPlaces = 2;
			resources.ApplyResources(this.numericUpDownSolidarityTax, "numericUpDownSolidarityTax");
			this.numericUpDownSolidarityTax.Maximum = new decimal(new int[] {
            1000000000,
            0,
            0,
            0});
			this.numericUpDownSolidarityTax.Name = "numericUpDownSolidarityTax";
			this.numericUpDownSolidarityTax.ValueChanged += new System.EventHandler(this.numericUpDownWageTax_ValueChanged);
			// 
			// numericUpDownSicknessInsurance
			// 
			this.numericUpDownSicknessInsurance.DecimalPlaces = 2;
			resources.ApplyResources(this.numericUpDownSicknessInsurance, "numericUpDownSicknessInsurance");
			this.numericUpDownSicknessInsurance.Maximum = new decimal(new int[] {
            1000000000,
            0,
            0,
            0});
			this.numericUpDownSicknessInsurance.Name = "numericUpDownSicknessInsurance";
			this.numericUpDownSicknessInsurance.ValueChanged += new System.EventHandler(this.numericUpDownWageTax_ValueChanged);
			// 
			// labelSicknessInsurance
			// 
			resources.ApplyResources(this.labelSicknessInsurance, "labelSicknessInsurance");
			this.labelSicknessInsurance.Name = "labelSicknessInsurance";
			// 
			// numericUpDownAnnuityInsurance
			// 
			this.numericUpDownAnnuityInsurance.DecimalPlaces = 2;
			resources.ApplyResources(this.numericUpDownAnnuityInsurance, "numericUpDownAnnuityInsurance");
			this.numericUpDownAnnuityInsurance.Maximum = new decimal(new int[] {
            1000000000,
            0,
            0,
            0});
			this.numericUpDownAnnuityInsurance.Name = "numericUpDownAnnuityInsurance";
			this.numericUpDownAnnuityInsurance.ValueChanged += new System.EventHandler(this.numericUpDownWageTax_ValueChanged);
			// 
			// labelAnnuityInsurance
			// 
			resources.ApplyResources(this.labelAnnuityInsurance, "labelAnnuityInsurance");
			this.labelAnnuityInsurance.Name = "labelAnnuityInsurance";
			// 
			// numericUpDownUnemploymentInsurance
			// 
			this.numericUpDownUnemploymentInsurance.DecimalPlaces = 2;
			resources.ApplyResources(this.numericUpDownUnemploymentInsurance, "numericUpDownUnemploymentInsurance");
			this.numericUpDownUnemploymentInsurance.Maximum = new decimal(new int[] {
            1000000000,
            0,
            0,
            0});
			this.numericUpDownUnemploymentInsurance.Name = "numericUpDownUnemploymentInsurance";
			this.numericUpDownUnemploymentInsurance.ValueChanged += new System.EventHandler(this.numericUpDownWageTax_ValueChanged);
			// 
			// labelUnemploymentInsurance
			// 
			resources.ApplyResources(this.labelUnemploymentInsurance, "labelUnemploymentInsurance");
			this.labelUnemploymentInsurance.Name = "labelUnemploymentInsurance";
			// 
			// numericUpDownCompulsoryLongTermCareInsurance
			// 
			this.numericUpDownCompulsoryLongTermCareInsurance.DecimalPlaces = 2;
			resources.ApplyResources(this.numericUpDownCompulsoryLongTermCareInsurance, "numericUpDownCompulsoryLongTermCareInsurance");
			this.numericUpDownCompulsoryLongTermCareInsurance.Maximum = new decimal(new int[] {
            1000000000,
            0,
            0,
            0});
			this.numericUpDownCompulsoryLongTermCareInsurance.Name = "numericUpDownCompulsoryLongTermCareInsurance";
			this.numericUpDownCompulsoryLongTermCareInsurance.ValueChanged += new System.EventHandler(this.numericUpDownWageTax_ValueChanged);
			// 
			// labelCompulsoryLongTermCareInsurance
			// 
			resources.ApplyResources(this.labelCompulsoryLongTermCareInsurance, "labelCompulsoryLongTermCareInsurance");
			this.labelCompulsoryLongTermCareInsurance.Name = "labelCompulsoryLongTermCareInsurance";
			// 
			// labelTotalGross
			// 
			resources.ApplyResources(this.labelTotalGross, "labelTotalGross");
			this.labelTotalGross.Name = "labelTotalGross";
			// 
			// textBoxTotalGross
			// 
			resources.ApplyResources(this.textBoxTotalGross, "textBoxTotalGross");
			this.textBoxTotalGross.Name = "textBoxTotalGross";
			this.textBoxTotalGross.ReadOnly = true;
			// 
			// textBoxTotalNet
			// 
			resources.ApplyResources(this.textBoxTotalNet, "textBoxTotalNet");
			this.textBoxTotalNet.Name = "textBoxTotalNet";
			this.textBoxTotalNet.ReadOnly = true;
			// 
			// labelTotalNet
			// 
			resources.ApplyResources(this.labelTotalNet, "labelTotalNet");
			this.labelTotalNet.Name = "labelTotalNet";
			// 
			// buttonEdit
			// 
			resources.ApplyResources(this.buttonEdit, "buttonEdit");
			this.buttonEdit.Name = "buttonEdit";
			this.buttonEdit.UseVisualStyleBackColor = true;
			this.buttonEdit.Click += new System.EventHandler(this.buttonEdit_Click);
			// 
			// labelPeriod
			// 
			resources.ApplyResources(this.labelPeriod, "labelPeriod");
			this.labelPeriod.Name = "labelPeriod";
			// 
			// comboBoxPeriodYear
			// 
			this.comboBoxPeriodYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBoxPeriodYear.FormattingEnabled = true;
			resources.ApplyResources(this.comboBoxPeriodYear, "comboBoxPeriodYear");
			this.comboBoxPeriodYear.Name = "comboBoxPeriodYear";
			this.comboBoxPeriodYear.SelectedIndexChanged += new System.EventHandler(this.comboBoxPeriodYear_SelectedIndexChanged);
			// 
			// comboBoxPeriodMonth
			// 
			this.comboBoxPeriodMonth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBoxPeriodMonth.FormattingEnabled = true;
			this.comboBoxPeriodMonth.Items.AddRange(new object[] {
            resources.GetString("comboBoxPeriodMonth.Items"),
            resources.GetString("comboBoxPeriodMonth.Items1"),
            resources.GetString("comboBoxPeriodMonth.Items2"),
            resources.GetString("comboBoxPeriodMonth.Items3"),
            resources.GetString("comboBoxPeriodMonth.Items4"),
            resources.GetString("comboBoxPeriodMonth.Items5"),
            resources.GetString("comboBoxPeriodMonth.Items6"),
            resources.GetString("comboBoxPeriodMonth.Items7"),
            resources.GetString("comboBoxPeriodMonth.Items8"),
            resources.GetString("comboBoxPeriodMonth.Items9"),
            resources.GetString("comboBoxPeriodMonth.Items10"),
            resources.GetString("comboBoxPeriodMonth.Items11")});
			resources.ApplyResources(this.comboBoxPeriodMonth, "comboBoxPeriodMonth");
			this.comboBoxPeriodMonth.Name = "comboBoxPeriodMonth";
			this.comboBoxPeriodMonth.SelectedIndexChanged += new System.EventHandler(this.comboBoxPeriodMonth_SelectedIndexChanged);
			// 
			// userControlSalaryItems1
			// 
			resources.ApplyResources(this.userControlSalaryItems1, "userControlSalaryItems1");
			this.userControlSalaryItems1.Name = "userControlSalaryItems1";
			this.userControlSalaryItems1.SalaryItemChanged += new System.EventHandler<Salary.NET.SalaryItemChangedEventArgs>(this.userControlSalaryItems1_SalaryItemChanged);
			// 
			// checkBoxPeriodFromTo
			// 
			resources.ApplyResources(this.checkBoxPeriodFromTo, "checkBoxPeriodFromTo");
			this.checkBoxPeriodFromTo.Name = "checkBoxPeriodFromTo";
			this.checkBoxPeriodFromTo.UseVisualStyleBackColor = true;
			this.checkBoxPeriodFromTo.CheckedChanged += new System.EventHandler(this.checkBoxPeriodFromTo_CheckedChanged);
			// 
			// comboBoxPeriodFromDay
			// 
			this.comboBoxPeriodFromDay.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			resources.ApplyResources(this.comboBoxPeriodFromDay, "comboBoxPeriodFromDay");
			this.comboBoxPeriodFromDay.FormattingEnabled = true;
			this.comboBoxPeriodFromDay.Items.AddRange(new object[] {
            resources.GetString("comboBoxPeriodFromDay.Items"),
            resources.GetString("comboBoxPeriodFromDay.Items1"),
            resources.GetString("comboBoxPeriodFromDay.Items2"),
            resources.GetString("comboBoxPeriodFromDay.Items3"),
            resources.GetString("comboBoxPeriodFromDay.Items4"),
            resources.GetString("comboBoxPeriodFromDay.Items5"),
            resources.GetString("comboBoxPeriodFromDay.Items6"),
            resources.GetString("comboBoxPeriodFromDay.Items7"),
            resources.GetString("comboBoxPeriodFromDay.Items8"),
            resources.GetString("comboBoxPeriodFromDay.Items9"),
            resources.GetString("comboBoxPeriodFromDay.Items10"),
            resources.GetString("comboBoxPeriodFromDay.Items11"),
            resources.GetString("comboBoxPeriodFromDay.Items12"),
            resources.GetString("comboBoxPeriodFromDay.Items13"),
            resources.GetString("comboBoxPeriodFromDay.Items14"),
            resources.GetString("comboBoxPeriodFromDay.Items15"),
            resources.GetString("comboBoxPeriodFromDay.Items16"),
            resources.GetString("comboBoxPeriodFromDay.Items17"),
            resources.GetString("comboBoxPeriodFromDay.Items18"),
            resources.GetString("comboBoxPeriodFromDay.Items19"),
            resources.GetString("comboBoxPeriodFromDay.Items20"),
            resources.GetString("comboBoxPeriodFromDay.Items21"),
            resources.GetString("comboBoxPeriodFromDay.Items22"),
            resources.GetString("comboBoxPeriodFromDay.Items23"),
            resources.GetString("comboBoxPeriodFromDay.Items24"),
            resources.GetString("comboBoxPeriodFromDay.Items25"),
            resources.GetString("comboBoxPeriodFromDay.Items26"),
            resources.GetString("comboBoxPeriodFromDay.Items27"),
            resources.GetString("comboBoxPeriodFromDay.Items28"),
            resources.GetString("comboBoxPeriodFromDay.Items29"),
            resources.GetString("comboBoxPeriodFromDay.Items30")});
			this.comboBoxPeriodFromDay.Name = "comboBoxPeriodFromDay";
			// 
			// comboBoxPeriodToDay
			// 
			this.comboBoxPeriodToDay.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			resources.ApplyResources(this.comboBoxPeriodToDay, "comboBoxPeriodToDay");
			this.comboBoxPeriodToDay.FormattingEnabled = true;
			this.comboBoxPeriodToDay.Items.AddRange(new object[] {
            resources.GetString("comboBoxPeriodToDay.Items"),
            resources.GetString("comboBoxPeriodToDay.Items1"),
            resources.GetString("comboBoxPeriodToDay.Items2"),
            resources.GetString("comboBoxPeriodToDay.Items3"),
            resources.GetString("comboBoxPeriodToDay.Items4"),
            resources.GetString("comboBoxPeriodToDay.Items5"),
            resources.GetString("comboBoxPeriodToDay.Items6"),
            resources.GetString("comboBoxPeriodToDay.Items7"),
            resources.GetString("comboBoxPeriodToDay.Items8"),
            resources.GetString("comboBoxPeriodToDay.Items9"),
            resources.GetString("comboBoxPeriodToDay.Items10"),
            resources.GetString("comboBoxPeriodToDay.Items11"),
            resources.GetString("comboBoxPeriodToDay.Items12"),
            resources.GetString("comboBoxPeriodToDay.Items13"),
            resources.GetString("comboBoxPeriodToDay.Items14"),
            resources.GetString("comboBoxPeriodToDay.Items15"),
            resources.GetString("comboBoxPeriodToDay.Items16"),
            resources.GetString("comboBoxPeriodToDay.Items17"),
            resources.GetString("comboBoxPeriodToDay.Items18"),
            resources.GetString("comboBoxPeriodToDay.Items19"),
            resources.GetString("comboBoxPeriodToDay.Items20"),
            resources.GetString("comboBoxPeriodToDay.Items21"),
            resources.GetString("comboBoxPeriodToDay.Items22"),
            resources.GetString("comboBoxPeriodToDay.Items23"),
            resources.GetString("comboBoxPeriodToDay.Items24"),
            resources.GetString("comboBoxPeriodToDay.Items25"),
            resources.GetString("comboBoxPeriodToDay.Items26"),
            resources.GetString("comboBoxPeriodToDay.Items27"),
            resources.GetString("comboBoxPeriodToDay.Items28"),
            resources.GetString("comboBoxPeriodToDay.Items29"),
            resources.GetString("comboBoxPeriodToDay.Items30")});
			this.comboBoxPeriodToDay.Name = "comboBoxPeriodToDay";
			// 
			// textBoxWageTaxPercentage
			// 
			resources.ApplyResources(this.textBoxWageTaxPercentage, "textBoxWageTaxPercentage");
			this.textBoxWageTaxPercentage.Name = "textBoxWageTaxPercentage";
			this.textBoxWageTaxPercentage.ReadOnly = true;
			// 
			// textBoxSolidarityTaxPercentage
			// 
			resources.ApplyResources(this.textBoxSolidarityTaxPercentage, "textBoxSolidarityTaxPercentage");
			this.textBoxSolidarityTaxPercentage.Name = "textBoxSolidarityTaxPercentage";
			this.textBoxSolidarityTaxPercentage.ReadOnly = true;
			// 
			// textBoxSicknessInsurancePercentage
			// 
			resources.ApplyResources(this.textBoxSicknessInsurancePercentage, "textBoxSicknessInsurancePercentage");
			this.textBoxSicknessInsurancePercentage.Name = "textBoxSicknessInsurancePercentage";
			this.textBoxSicknessInsurancePercentage.ReadOnly = true;
			// 
			// textBoxAnnuityInsurancePercentage
			// 
			resources.ApplyResources(this.textBoxAnnuityInsurancePercentage, "textBoxAnnuityInsurancePercentage");
			this.textBoxAnnuityInsurancePercentage.Name = "textBoxAnnuityInsurancePercentage";
			this.textBoxAnnuityInsurancePercentage.ReadOnly = true;
			// 
			// textBoxUnemploymentInsurancePercentage
			// 
			resources.ApplyResources(this.textBoxUnemploymentInsurancePercentage, "textBoxUnemploymentInsurancePercentage");
			this.textBoxUnemploymentInsurancePercentage.Name = "textBoxUnemploymentInsurancePercentage";
			this.textBoxUnemploymentInsurancePercentage.ReadOnly = true;
			// 
			// textBoxCompulsoryLongTermCareInsurancePercentage
			// 
			resources.ApplyResources(this.textBoxCompulsoryLongTermCareInsurancePercentage, "textBoxCompulsoryLongTermCareInsurancePercentage");
			this.textBoxCompulsoryLongTermCareInsurancePercentage.Name = "textBoxCompulsoryLongTermCareInsurancePercentage";
			this.textBoxCompulsoryLongTermCareInsurancePercentage.ReadOnly = true;
			// 
			// textBoxTotalGrossPercentage
			// 
			resources.ApplyResources(this.textBoxTotalGrossPercentage, "textBoxTotalGrossPercentage");
			this.textBoxTotalGrossPercentage.Name = "textBoxTotalGrossPercentage";
			this.textBoxTotalGrossPercentage.ReadOnly = true;
			// 
			// textBoxTotalNetPercentage
			// 
			resources.ApplyResources(this.textBoxTotalNetPercentage, "textBoxTotalNetPercentage");
			this.textBoxTotalNetPercentage.Name = "textBoxTotalNetPercentage";
			this.textBoxTotalNetPercentage.ReadOnly = true;
			// 
			// AddSalaryAccountForm
			// 
			resources.ApplyResources(this, "$this");
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.textBoxTotalNetPercentage);
			this.Controls.Add(this.textBoxTotalGrossPercentage);
			this.Controls.Add(this.textBoxCompulsoryLongTermCareInsurancePercentage);
			this.Controls.Add(this.textBoxUnemploymentInsurancePercentage);
			this.Controls.Add(this.textBoxAnnuityInsurancePercentage);
			this.Controls.Add(this.textBoxSicknessInsurancePercentage);
			this.Controls.Add(this.textBoxSolidarityTaxPercentage);
			this.Controls.Add(this.textBoxWageTaxPercentage);
			this.Controls.Add(this.comboBoxPeriodToDay);
			this.Controls.Add(this.comboBoxPeriodFromDay);
			this.Controls.Add(this.checkBoxPeriodFromTo);
			this.Controls.Add(this.comboBoxPeriodMonth);
			this.Controls.Add(this.comboBoxPeriodYear);
			this.Controls.Add(this.labelPeriod);
			this.Controls.Add(this.buttonEdit);
			this.Controls.Add(this.labelTotalNet);
			this.Controls.Add(this.textBoxTotalNet);
			this.Controls.Add(this.textBoxTotalGross);
			this.Controls.Add(this.labelTotalGross);
			this.Controls.Add(this.userControlSalaryItems1);
			this.Controls.Add(this.labelCompulsoryLongTermCareInsurance);
			this.Controls.Add(this.numericUpDownCompulsoryLongTermCareInsurance);
			this.Controls.Add(this.labelUnemploymentInsurance);
			this.Controls.Add(this.numericUpDownUnemploymentInsurance);
			this.Controls.Add(this.labelAnnuityInsurance);
			this.Controls.Add(this.numericUpDownAnnuityInsurance);
			this.Controls.Add(this.labelSicknessInsurance);
			this.Controls.Add(this.numericUpDownSicknessInsurance);
			this.Controls.Add(this.numericUpDownSolidarityTax);
			this.Controls.Add(this.labelSolidarityTax);
			this.Controls.Add(this.numericUpDownWageTax);
			this.Controls.Add(this.labelWageTax);
			this.Controls.Add(this.buttonCancel);
			this.Controls.Add(this.buttonAdd);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.Name = "AddSalaryAccountForm";
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownWageTax)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownSolidarityTax)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownSicknessInsurance)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownAnnuityInsurance)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownUnemploymentInsurance)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownCompulsoryLongTermCareInsurance)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button buttonAdd;
		private System.Windows.Forms.Button buttonCancel;
		private System.Windows.Forms.Label labelWageTax;
		private System.Windows.Forms.NumericUpDown numericUpDownWageTax;
		private System.Windows.Forms.Label labelSolidarityTax;
		private System.Windows.Forms.NumericUpDown numericUpDownSolidarityTax;
		private System.Windows.Forms.NumericUpDown numericUpDownSicknessInsurance;
		private System.Windows.Forms.Label labelSicknessInsurance;
		private System.Windows.Forms.NumericUpDown numericUpDownAnnuityInsurance;
		private System.Windows.Forms.Label labelAnnuityInsurance;
		private System.Windows.Forms.NumericUpDown numericUpDownUnemploymentInsurance;
		private System.Windows.Forms.Label labelUnemploymentInsurance;
		private System.Windows.Forms.NumericUpDown numericUpDownCompulsoryLongTermCareInsurance;
		private System.Windows.Forms.Label labelCompulsoryLongTermCareInsurance;
		private UserControlSalaryItems userControlSalaryItems1;
		private System.Windows.Forms.Label labelTotalGross;
		private System.Windows.Forms.TextBox textBoxTotalGross;
		private System.Windows.Forms.TextBox textBoxTotalNet;
		private System.Windows.Forms.Label labelTotalNet;
		private System.Windows.Forms.Button buttonEdit;
		private System.Windows.Forms.Label labelPeriod;
		private System.Windows.Forms.ComboBox comboBoxPeriodYear;
		private System.Windows.Forms.ComboBox comboBoxPeriodMonth;
		private System.Windows.Forms.CheckBox checkBoxPeriodFromTo;
		private System.Windows.Forms.ComboBox comboBoxPeriodFromDay;
		private System.Windows.Forms.ComboBox comboBoxPeriodToDay;
		private System.Windows.Forms.TextBox textBoxWageTaxPercentage;
		private System.Windows.Forms.TextBox textBoxSolidarityTaxPercentage;
		private System.Windows.Forms.TextBox textBoxSicknessInsurancePercentage;
		private System.Windows.Forms.TextBox textBoxAnnuityInsurancePercentage;
		private System.Windows.Forms.TextBox textBoxUnemploymentInsurancePercentage;
		private System.Windows.Forms.TextBox textBoxCompulsoryLongTermCareInsurancePercentage;
		private System.Windows.Forms.TextBox textBoxTotalGrossPercentage;
		private System.Windows.Forms.TextBox textBoxTotalNetPercentage;
	}
}