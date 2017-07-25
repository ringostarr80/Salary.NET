using System;
using System.Diagnostics;
using System.Reflection;
using System.Windows.Forms;

namespace Salary.NET
{
	public partial class AboutForm : Form
	{
		public AboutForm()
		{
			InitializeComponent();
		}

		private void ButtonClose_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void AboutForm_Resize(object sender, EventArgs e)
		{
			this.RepositionCloseButton();
		}

		private void AboutForm_Load(object sender, EventArgs e)
		{
			this.RepositionCloseButton();

			var version = Assembly.GetEntryAssembly().GetName().Version;
			var name = Assembly.GetEntryAssembly().GetName().Name;
			var processorArchitecture = Assembly.GetEntryAssembly().GetName().ProcessorArchitecture;
			this.labelVersionValue.Text = version.ToString();
			this.labelNameValue.Text = name;
			this.labelProcessorArchitectureValue.Text = processorArchitecture.ToString();
		}

		private void RepositionCloseButton()
		{
			var newCloseButtonLeftPos = this.Width / 2 - this.buttonClose.Width / 2 - 8;
			var newCloseButtomTopPos = this.Height - this.buttonClose.Height - 51;
			this.buttonClose.Left = newCloseButtonLeftPos;
			this.buttonClose.Top = newCloseButtomTopPos;
		}

		private void LinkLabelLicenseValue_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			var psi = new ProcessStartInfo(this.linkLabelLicenseValue.Text);
			using (Process.Start(psi)) {

			}
		}

		private void LinkLabelWebsite_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			var psi = new ProcessStartInfo(this.linkLabelWebsite.Text);
			using (Process.Start(psi)) {

			}
		}
	}
}
