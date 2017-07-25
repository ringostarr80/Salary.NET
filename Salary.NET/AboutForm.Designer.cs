namespace Salary.NET
{
	partial class AboutForm
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
			if (disposing && (components != null))
			{
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AboutForm));
			this.buttonClose = new System.Windows.Forms.Button();
			this.labelVersion = new System.Windows.Forms.Label();
			this.labelVersionValue = new System.Windows.Forms.Label();
			this.labelName = new System.Windows.Forms.Label();
			this.labelNameValue = new System.Windows.Forms.Label();
			this.labelProcessorArchitecture = new System.Windows.Forms.Label();
			this.labelProcessorArchitectureValue = new System.Windows.Forms.Label();
			this.labelLicense = new System.Windows.Forms.Label();
			this.linkLabelLicenseValue = new System.Windows.Forms.LinkLabel();
			this.labelDeveloper = new System.Windows.Forms.Label();
			this.labelDeveloperValue = new System.Windows.Forms.Label();
			this.labelReleaseDate = new System.Windows.Forms.Label();
			this.labelReleaseDateValue = new System.Windows.Forms.Label();
			this.labelWebsite = new System.Windows.Forms.Label();
			this.linkLabelWebsite = new System.Windows.Forms.LinkLabel();
			this.SuspendLayout();
			// 
			// buttonClose
			// 
			resources.ApplyResources(this.buttonClose, "buttonClose");
			this.buttonClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.buttonClose.Name = "buttonClose";
			this.buttonClose.UseVisualStyleBackColor = true;
			this.buttonClose.Click += new System.EventHandler(this.ButtonClose_Click);
			// 
			// labelVersion
			// 
			resources.ApplyResources(this.labelVersion, "labelVersion");
			this.labelVersion.Name = "labelVersion";
			// 
			// labelVersionValue
			// 
			resources.ApplyResources(this.labelVersionValue, "labelVersionValue");
			this.labelVersionValue.Name = "labelVersionValue";
			// 
			// labelName
			// 
			resources.ApplyResources(this.labelName, "labelName");
			this.labelName.Name = "labelName";
			// 
			// labelNameValue
			// 
			resources.ApplyResources(this.labelNameValue, "labelNameValue");
			this.labelNameValue.Name = "labelNameValue";
			// 
			// labelProcessorArchitecture
			// 
			resources.ApplyResources(this.labelProcessorArchitecture, "labelProcessorArchitecture");
			this.labelProcessorArchitecture.Name = "labelProcessorArchitecture";
			// 
			// labelProcessorArchitectureValue
			// 
			resources.ApplyResources(this.labelProcessorArchitectureValue, "labelProcessorArchitectureValue");
			this.labelProcessorArchitectureValue.Name = "labelProcessorArchitectureValue";
			// 
			// labelLicense
			// 
			resources.ApplyResources(this.labelLicense, "labelLicense");
			this.labelLicense.Name = "labelLicense";
			// 
			// linkLabelLicenseValue
			// 
			resources.ApplyResources(this.linkLabelLicenseValue, "linkLabelLicenseValue");
			this.linkLabelLicenseValue.Name = "linkLabelLicenseValue";
			this.linkLabelLicenseValue.TabStop = true;
			this.linkLabelLicenseValue.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkLabelLicenseValue_LinkClicked);
			// 
			// labelDeveloper
			// 
			resources.ApplyResources(this.labelDeveloper, "labelDeveloper");
			this.labelDeveloper.Name = "labelDeveloper";
			// 
			// labelDeveloperValue
			// 
			resources.ApplyResources(this.labelDeveloperValue, "labelDeveloperValue");
			this.labelDeveloperValue.Name = "labelDeveloperValue";
			// 
			// labelReleaseDate
			// 
			resources.ApplyResources(this.labelReleaseDate, "labelReleaseDate");
			this.labelReleaseDate.Name = "labelReleaseDate";
			// 
			// labelReleaseDateValue
			// 
			resources.ApplyResources(this.labelReleaseDateValue, "labelReleaseDateValue");
			this.labelReleaseDateValue.Name = "labelReleaseDateValue";
			// 
			// labelWebsite
			// 
			resources.ApplyResources(this.labelWebsite, "labelWebsite");
			this.labelWebsite.Name = "labelWebsite";
			// 
			// linkLabelWebsite
			// 
			resources.ApplyResources(this.linkLabelWebsite, "linkLabelWebsite");
			this.linkLabelWebsite.Name = "linkLabelWebsite";
			this.linkLabelWebsite.TabStop = true;
			this.linkLabelWebsite.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkLabelWebsite_LinkClicked);
			// 
			// AboutForm
			// 
			resources.ApplyResources(this, "$this");
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.buttonClose;
			this.Controls.Add(this.linkLabelWebsite);
			this.Controls.Add(this.labelWebsite);
			this.Controls.Add(this.labelReleaseDateValue);
			this.Controls.Add(this.labelReleaseDate);
			this.Controls.Add(this.labelDeveloperValue);
			this.Controls.Add(this.labelDeveloper);
			this.Controls.Add(this.linkLabelLicenseValue);
			this.Controls.Add(this.labelLicense);
			this.Controls.Add(this.labelProcessorArchitectureValue);
			this.Controls.Add(this.labelProcessorArchitecture);
			this.Controls.Add(this.labelNameValue);
			this.Controls.Add(this.labelName);
			this.Controls.Add(this.labelVersionValue);
			this.Controls.Add(this.labelVersion);
			this.Controls.Add(this.buttonClose);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "AboutForm";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.TopMost = true;
			this.Load += new System.EventHandler(this.AboutForm_Load);
			this.Resize += new System.EventHandler(this.AboutForm_Resize);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button buttonClose;
		private System.Windows.Forms.Label labelVersion;
		private System.Windows.Forms.Label labelVersionValue;
		private System.Windows.Forms.Label labelName;
		private System.Windows.Forms.Label labelNameValue;
		private System.Windows.Forms.Label labelProcessorArchitecture;
		private System.Windows.Forms.Label labelProcessorArchitectureValue;
		private System.Windows.Forms.Label labelLicense;
		private System.Windows.Forms.LinkLabel linkLabelLicenseValue;
		private System.Windows.Forms.Label labelDeveloper;
		private System.Windows.Forms.Label labelDeveloperValue;
		private System.Windows.Forms.Label labelReleaseDate;
		private System.Windows.Forms.Label labelReleaseDateValue;
		private System.Windows.Forms.Label labelWebsite;
		private System.Windows.Forms.LinkLabel linkLabelWebsite;
	}
}