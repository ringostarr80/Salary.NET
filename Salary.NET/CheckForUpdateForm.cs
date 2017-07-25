using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;

namespace Salary.NET
{
	public partial class CheckForUpdateForm : Form
	{
		private SalaryVersionInfo _latestSalaryVersion = null;

		public CheckForUpdateForm()
		{
			InitializeComponent();
		}

		private void ButtonClose_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void CheckForUpdateForm_Load(object sender, EventArgs e)
		{
			this.labelInstalledVersionValue.Text = Assembly.GetEntryAssembly().GetName().Version.ToString();
			this.labelLatestVersionValue.Text = "loading...";
			this.TryLoadingLatestVersionInfo();
		}

		private void TryLoadingLatestVersionInfo()
		{
			using (var webClient = new WebClient()) {
				webClient.DownloadStringCompleted += (sender, e) => {
					if (e.Cancelled) {
						this.labelLatestVersionValue.Text = "cancelled!";
						return;
					}
					if (e.Error != null) {
						this.labelLatestVersionValue.Text = "error!";
						return;
					}
					var jsonResult = JObject.Parse(e.Result);
					if (jsonResult["versions"] == null) {
						this.labelLatestVersionValue.Text = "no version info available";
						return;
					}

					var salaryVersions = new List<SalaryVersionInfo>();
					var jsonVersions = jsonResult["versions"].Children().ToList();
					foreach(var jsonVersion in jsonVersions) {
						var salaryVersion = jsonVersion.ToObject<SalaryVersionInfo>();
						salaryVersions.Add(salaryVersion);
					}

					var architecture = "x86";
					var processorArchitecture = Assembly.GetEntryAssembly().GetName().ProcessorArchitecture;
					if (processorArchitecture == ProcessorArchitecture.Amd64 || processorArchitecture == ProcessorArchitecture.IA64) {
						architecture = "x64";
					}

					var orderedVersions = salaryVersions.FindAll(s => s.Architecture == architecture).OrderByDescending(s => s.Version);
					if (orderedVersions.Count() == 0) {
						this.labelLatestVersionValue.Text = "no version info available";
						return;
					}

					this._latestSalaryVersion = orderedVersions.First();
					
					this.labelLatestVersionValue.Text = this._latestSalaryVersion.Version.ToString();
				};
				webClient.DownloadStringAsync(new Uri("https://salary.ringoleese.de/api/salary.net/"));
			}
		}
	}
}
