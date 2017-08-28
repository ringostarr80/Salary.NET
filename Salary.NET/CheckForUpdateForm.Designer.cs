namespace Salary.NET
{
	partial class CheckForUpdateForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CheckForUpdateForm));
			this.buttonClose = new System.Windows.Forms.Button();
			this.labelInstalledVersion = new System.Windows.Forms.Label();
			this.labelInstalledVersionValue = new System.Windows.Forms.Label();
			this.labelLatestVersion = new System.Windows.Forms.Label();
			this.labelLatestVersionValue = new System.Windows.Forms.Label();
			this.buttonInstallUpdate = new System.Windows.Forms.Button();
			this.labelUpdateStatus = new System.Windows.Forms.Label();
			this.labelUpdateStatusValue = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// buttonClose
			// 
			resources.ApplyResources(this.buttonClose, "buttonClose");
			this.buttonClose.Name = "buttonClose";
			this.buttonClose.UseVisualStyleBackColor = true;
			this.buttonClose.Click += new System.EventHandler(this.ButtonClose_Click);
			// 
			// labelInstalledVersion
			// 
			resources.ApplyResources(this.labelInstalledVersion, "labelInstalledVersion");
			this.labelInstalledVersion.Name = "labelInstalledVersion";
			// 
			// labelInstalledVersionValue
			// 
			resources.ApplyResources(this.labelInstalledVersionValue, "labelInstalledVersionValue");
			this.labelInstalledVersionValue.Name = "labelInstalledVersionValue";
			// 
			// labelLatestVersion
			// 
			resources.ApplyResources(this.labelLatestVersion, "labelLatestVersion");
			this.labelLatestVersion.Name = "labelLatestVersion";
			// 
			// labelLatestVersionValue
			// 
			resources.ApplyResources(this.labelLatestVersionValue, "labelLatestVersionValue");
			this.labelLatestVersionValue.Name = "labelLatestVersionValue";
			// 
			// buttonInstallUpdate
			// 
			resources.ApplyResources(this.buttonInstallUpdate, "buttonInstallUpdate");
			this.buttonInstallUpdate.Name = "buttonInstallUpdate";
			this.buttonInstallUpdate.UseVisualStyleBackColor = true;
			this.buttonInstallUpdate.Click += new System.EventHandler(this.ButtonInstallUpdate_Click);
			// 
			// labelUpdateStatus
			// 
			resources.ApplyResources(this.labelUpdateStatus, "labelUpdateStatus");
			this.labelUpdateStatus.Name = "labelUpdateStatus";
			// 
			// labelUpdateStatusValue
			// 
			resources.ApplyResources(this.labelUpdateStatusValue, "labelUpdateStatusValue");
			this.labelUpdateStatusValue.Name = "labelUpdateStatusValue";
			// 
			// CheckForUpdateForm
			// 
			resources.ApplyResources(this, "$this");
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.labelUpdateStatusValue);
			this.Controls.Add(this.labelUpdateStatus);
			this.Controls.Add(this.buttonInstallUpdate);
			this.Controls.Add(this.labelLatestVersionValue);
			this.Controls.Add(this.labelLatestVersion);
			this.Controls.Add(this.labelInstalledVersionValue);
			this.Controls.Add(this.labelInstalledVersion);
			this.Controls.Add(this.buttonClose);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "CheckForUpdateForm";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.TopMost = true;
			this.Load += new System.EventHandler(this.CheckForUpdateForm_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button buttonClose;
		private System.Windows.Forms.Label labelInstalledVersion;
		private System.Windows.Forms.Label labelInstalledVersionValue;
		private System.Windows.Forms.Label labelLatestVersion;
		private System.Windows.Forms.Label labelLatestVersionValue;
		private System.Windows.Forms.Button buttonInstallUpdate;
		private System.Windows.Forms.Label labelUpdateStatus;
		private System.Windows.Forms.Label labelUpdateStatusValue;
	}
}