using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;
using System.IO;
using System.IO.Compression;

namespace Salary.NET
{
	public partial class CheckForUpdateForm : Form
	{
		private SalaryVersionInfo _latestSalaryVersion = null;
		private string _updateExecutable = string.Empty;

		public string UpdateExecutable { get { return this._updateExecutable; } }

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

					if (this._latestSalaryVersion.Version > Assembly.GetEntryAssembly().GetName().Version) {
						this.buttonInstallUpdate.Enabled = true;
					}
				};
				webClient.DownloadStringAsync(new Uri("https://salary.ringoleese.de/api/salary.net/versions"));
			}
		}

		private void ButtonInstallUpdate_Click(object sender, EventArgs e)
		{
			this.labelUpdateStatusValue.Text = "downloading...";
			var downloadPath = Path.GetTempPath();
			using(var webClient = new WebClient()) {
				var uri = new Uri(this._latestSalaryVersion.Url);
				var downloadFilename = downloadPath + uri.Segments[uri.Segments.Length - 1];

				webClient.DownloadProgressChanged += (senderW, eW) => {
					this.labelUpdateStatusValue.Text = "downloading... (" + eW.ProgressPercentage + "%)";
				};
				webClient.DownloadFileCompleted += (senderW, eW) => {
					if (eW.Cancelled) {
						return;
					}
					if (eW.Error != null) {
						return;
					}
					
					var archive = ZipFile.OpenRead(downloadFilename);
					var totalFiles = archive.Entries.Count;
					var extractingFile = 0;
					string foundExecutable = null;
					this.labelUpdateStatusValue.Text = "extracting...";
					foreach(var entry in archive.Entries) {
						if (entry.Name == string.Empty) {
							continue;
						}

						extractingFile++;
						this.labelUpdateStatusValue.Text = "extracting... (file " + extractingFile + "/" + totalFiles + ")";
						entry.ExtractToFile(downloadPath + entry.Name, true);
						if (entry.Name.EndsWith(".msi")) {
							foundExecutable = entry.Name;
						}
					}
					this.labelUpdateStatusValue.Text = "extracting... ready.";
					if (foundExecutable == null) {
						this.labelUpdateStatusValue.Text = "extracting... no executable found.";
						return;
					}
					
					this._updateExecutable = downloadPath + foundExecutable;
					this.Close();
				};

				webClient.DownloadFileAsync(uri, downloadFilename);
			}
		}
	}
}
