namespace Salary.NET
{
	partial class UserControlSalaryFilter
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
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Vom Komponenten-Designer generierter Code

		/// <summary> 
		/// Erforderliche Methode für die Designerunterstützung. 
		/// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserControlSalaryFilter));
			this.checkBoxFilter = new System.Windows.Forms.CheckBox();
			this.checkBoxId = new System.Windows.Forms.CheckBox();
			this.checkBoxGrossWage = new System.Windows.Forms.CheckBox();
			this.checkBoxNetWage = new System.Windows.Forms.CheckBox();
			this.checkBoxPeriod = new System.Windows.Forms.CheckBox();
			this.numericUpDownMaxId = new System.Windows.Forms.NumericUpDown();
			this.numericUpDownMinId = new System.Windows.Forms.NumericUpDown();
			this.labelMaxId = new System.Windows.Forms.Label();
			this.labelMinId = new System.Windows.Forms.Label();
			this.labelMinGrossWage = new System.Windows.Forms.Label();
			this.labelMinNetWage = new System.Windows.Forms.Label();
			this.labelMinPeriod = new System.Windows.Forms.Label();
			this.labelMaxGrossWage = new System.Windows.Forms.Label();
			this.labelMaxNetWage = new System.Windows.Forms.Label();
			this.labelMaxPeriod = new System.Windows.Forms.Label();
			this.numericUpDownMinGrossWage = new System.Windows.Forms.NumericUpDown();
			this.numericUpDownMaxGrossWage = new System.Windows.Forms.NumericUpDown();
			this.numericUpDownMinNetWage = new System.Windows.Forms.NumericUpDown();
			this.numericUpDownMaxNetWage = new System.Windows.Forms.NumericUpDown();
			this.dateTimePickerMinPeriod = new System.Windows.Forms.DateTimePicker();
			this.dateTimePickerMaxPeriod = new System.Windows.Forms.DateTimePicker();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownMaxId)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownMinId)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownMinGrossWage)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownMaxGrossWage)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownMinNetWage)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownMaxNetWage)).BeginInit();
			this.SuspendLayout();
			// 
			// checkBoxFilter
			// 
			resources.ApplyResources(this.checkBoxFilter, "checkBoxFilter");
			this.checkBoxFilter.Name = "checkBoxFilter";
			this.checkBoxFilter.UseVisualStyleBackColor = true;
			this.checkBoxFilter.CheckedChanged += new System.EventHandler(this.CheckBoxFilter_CheckedChanged);
			// 
			// checkBoxId
			// 
			resources.ApplyResources(this.checkBoxId, "checkBoxId");
			this.checkBoxId.Name = "checkBoxId";
			this.checkBoxId.UseVisualStyleBackColor = true;
			this.checkBoxId.CheckedChanged += new System.EventHandler(this.CheckBox_CheckedChanged);
			// 
			// checkBoxGrossWage
			// 
			resources.ApplyResources(this.checkBoxGrossWage, "checkBoxGrossWage");
			this.checkBoxGrossWage.Name = "checkBoxGrossWage";
			this.checkBoxGrossWage.UseVisualStyleBackColor = true;
			this.checkBoxGrossWage.CheckedChanged += new System.EventHandler(this.CheckBox_CheckedChanged);
			// 
			// checkBoxNetWage
			// 
			resources.ApplyResources(this.checkBoxNetWage, "checkBoxNetWage");
			this.checkBoxNetWage.Name = "checkBoxNetWage";
			this.checkBoxNetWage.UseVisualStyleBackColor = true;
			this.checkBoxNetWage.CheckedChanged += new System.EventHandler(this.CheckBox_CheckedChanged);
			// 
			// checkBoxPeriod
			// 
			resources.ApplyResources(this.checkBoxPeriod, "checkBoxPeriod");
			this.checkBoxPeriod.Name = "checkBoxPeriod";
			this.checkBoxPeriod.UseVisualStyleBackColor = true;
			this.checkBoxPeriod.CheckedChanged += new System.EventHandler(this.CheckBox_CheckedChanged);
			// 
			// numericUpDownMaxId
			// 
			resources.ApplyResources(this.numericUpDownMaxId, "numericUpDownMaxId");
			this.numericUpDownMaxId.Maximum = new decimal(new int[] {
            1000000000,
            0,
            0,
            0});
			this.numericUpDownMaxId.Name = "numericUpDownMaxId";
			this.numericUpDownMaxId.ValueChanged += new System.EventHandler(this.NumericUpDown_ValueChanged);
			// 
			// numericUpDownMinId
			// 
			resources.ApplyResources(this.numericUpDownMinId, "numericUpDownMinId");
			this.numericUpDownMinId.Maximum = new decimal(new int[] {
            1000000000,
            0,
            0,
            0});
			this.numericUpDownMinId.Name = "numericUpDownMinId";
			this.numericUpDownMinId.ValueChanged += new System.EventHandler(this.NumericUpDown_ValueChanged);
			// 
			// labelMaxId
			// 
			resources.ApplyResources(this.labelMaxId, "labelMaxId");
			this.labelMaxId.Name = "labelMaxId";
			// 
			// labelMinId
			// 
			resources.ApplyResources(this.labelMinId, "labelMinId");
			this.labelMinId.Name = "labelMinId";
			// 
			// labelMinGrossWage
			// 
			resources.ApplyResources(this.labelMinGrossWage, "labelMinGrossWage");
			this.labelMinGrossWage.Name = "labelMinGrossWage";
			// 
			// labelMinNetWage
			// 
			resources.ApplyResources(this.labelMinNetWage, "labelMinNetWage");
			this.labelMinNetWage.Name = "labelMinNetWage";
			// 
			// labelMinPeriod
			// 
			resources.ApplyResources(this.labelMinPeriod, "labelMinPeriod");
			this.labelMinPeriod.Name = "labelMinPeriod";
			// 
			// labelMaxGrossWage
			// 
			resources.ApplyResources(this.labelMaxGrossWage, "labelMaxGrossWage");
			this.labelMaxGrossWage.Name = "labelMaxGrossWage";
			// 
			// labelMaxNetWage
			// 
			resources.ApplyResources(this.labelMaxNetWage, "labelMaxNetWage");
			this.labelMaxNetWage.Name = "labelMaxNetWage";
			// 
			// labelMaxPeriod
			// 
			resources.ApplyResources(this.labelMaxPeriod, "labelMaxPeriod");
			this.labelMaxPeriod.Name = "labelMaxPeriod";
			// 
			// numericUpDownMinGrossWage
			// 
			resources.ApplyResources(this.numericUpDownMinGrossWage, "numericUpDownMinGrossWage");
			this.numericUpDownMinGrossWage.Maximum = new decimal(new int[] {
            1000000000,
            0,
            0,
            0});
			this.numericUpDownMinGrossWage.Name = "numericUpDownMinGrossWage";
			this.numericUpDownMinGrossWage.ValueChanged += new System.EventHandler(this.NumericUpDown_ValueChanged);
			// 
			// numericUpDownMaxGrossWage
			// 
			resources.ApplyResources(this.numericUpDownMaxGrossWage, "numericUpDownMaxGrossWage");
			this.numericUpDownMaxGrossWage.Maximum = new decimal(new int[] {
            1000000000,
            0,
            0,
            0});
			this.numericUpDownMaxGrossWage.Name = "numericUpDownMaxGrossWage";
			this.numericUpDownMaxGrossWage.ValueChanged += new System.EventHandler(this.NumericUpDown_ValueChanged);
			// 
			// numericUpDownMinNetWage
			// 
			resources.ApplyResources(this.numericUpDownMinNetWage, "numericUpDownMinNetWage");
			this.numericUpDownMinNetWage.Maximum = new decimal(new int[] {
            1000000000,
            0,
            0,
            0});
			this.numericUpDownMinNetWage.Name = "numericUpDownMinNetWage";
			this.numericUpDownMinNetWage.ValueChanged += new System.EventHandler(this.NumericUpDown_ValueChanged);
			// 
			// numericUpDownMaxNetWage
			// 
			resources.ApplyResources(this.numericUpDownMaxNetWage, "numericUpDownMaxNetWage");
			this.numericUpDownMaxNetWage.Maximum = new decimal(new int[] {
            1000000000,
            0,
            0,
            0});
			this.numericUpDownMaxNetWage.Name = "numericUpDownMaxNetWage";
			this.numericUpDownMaxNetWage.ValueChanged += new System.EventHandler(this.NumericUpDown_ValueChanged);
			// 
			// dateTimePickerMinPeriod
			// 
			resources.ApplyResources(this.dateTimePickerMinPeriod, "dateTimePickerMinPeriod");
			this.dateTimePickerMinPeriod.Name = "dateTimePickerMinPeriod";
			this.dateTimePickerMinPeriod.ValueChanged += new System.EventHandler(this.DateTimePicker_ValueChanged);
			// 
			// dateTimePickerMaxPeriod
			// 
			resources.ApplyResources(this.dateTimePickerMaxPeriod, "dateTimePickerMaxPeriod");
			this.dateTimePickerMaxPeriod.Name = "dateTimePickerMaxPeriod";
			this.dateTimePickerMaxPeriod.ValueChanged += new System.EventHandler(this.DateTimePicker_ValueChanged);
			// 
			// UserControlSalaryFilter
			// 
			resources.ApplyResources(this, "$this");
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.dateTimePickerMaxPeriod);
			this.Controls.Add(this.dateTimePickerMinPeriod);
			this.Controls.Add(this.numericUpDownMaxNetWage);
			this.Controls.Add(this.numericUpDownMinNetWage);
			this.Controls.Add(this.numericUpDownMaxGrossWage);
			this.Controls.Add(this.numericUpDownMinGrossWage);
			this.Controls.Add(this.labelMaxPeriod);
			this.Controls.Add(this.labelMaxNetWage);
			this.Controls.Add(this.labelMaxGrossWage);
			this.Controls.Add(this.labelMinPeriod);
			this.Controls.Add(this.labelMinNetWage);
			this.Controls.Add(this.labelMinGrossWage);
			this.Controls.Add(this.labelMinId);
			this.Controls.Add(this.labelMaxId);
			this.Controls.Add(this.numericUpDownMinId);
			this.Controls.Add(this.numericUpDownMaxId);
			this.Controls.Add(this.checkBoxPeriod);
			this.Controls.Add(this.checkBoxNetWage);
			this.Controls.Add(this.checkBoxGrossWage);
			this.Controls.Add(this.checkBoxId);
			this.Controls.Add(this.checkBoxFilter);
			this.Name = "UserControlSalaryFilter";
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownMaxId)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownMinId)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownMinGrossWage)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownMaxGrossWage)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownMinNetWage)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownMaxNetWage)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.CheckBox checkBoxFilter;
		private System.Windows.Forms.CheckBox checkBoxId;
		private System.Windows.Forms.CheckBox checkBoxGrossWage;
		private System.Windows.Forms.CheckBox checkBoxNetWage;
		private System.Windows.Forms.CheckBox checkBoxPeriod;
		private System.Windows.Forms.NumericUpDown numericUpDownMaxId;
		private System.Windows.Forms.NumericUpDown numericUpDownMinId;
		private System.Windows.Forms.Label labelMaxId;
		private System.Windows.Forms.Label labelMinId;
		private System.Windows.Forms.Label labelMinGrossWage;
		private System.Windows.Forms.Label labelMinNetWage;
		private System.Windows.Forms.Label labelMinPeriod;
		private System.Windows.Forms.Label labelMaxGrossWage;
		private System.Windows.Forms.Label labelMaxNetWage;
		private System.Windows.Forms.Label labelMaxPeriod;
		private System.Windows.Forms.NumericUpDown numericUpDownMinGrossWage;
		private System.Windows.Forms.NumericUpDown numericUpDownMaxGrossWage;
		private System.Windows.Forms.NumericUpDown numericUpDownMinNetWage;
		private System.Windows.Forms.NumericUpDown numericUpDownMaxNetWage;
		private System.Windows.Forms.DateTimePicker dateTimePickerMinPeriod;
		private System.Windows.Forms.DateTimePicker dateTimePickerMaxPeriod;
	}
}
