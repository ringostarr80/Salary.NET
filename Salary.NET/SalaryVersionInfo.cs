using Newtonsoft.Json;
using System;

namespace Salary.NET
{
	class SalaryVersionInfo
	{
		[JsonProperty(PropertyName = "version")]
		public Version Version = new Version();
		[JsonProperty(PropertyName = "release_date")]
		public DateTime ReleaseDate = DateTime.MinValue;
		[JsonProperty(PropertyName = "architecture")]
		public string Architecture = string.Empty;
		[JsonProperty(PropertyName = "url")]
		public string Url = string.Empty;
	}
}
