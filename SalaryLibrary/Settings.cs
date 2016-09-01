using System;

namespace SalaryLibrary
{
	public class Settings
	{
		private static ISalaryDataProvider _defaultDataBackend = null;

		public static ISalaryDataProvider DefaultDataBackend { get { return _defaultDataBackend; } set { _defaultDataBackend = value; } }
	}
}
