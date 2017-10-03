using BrightIdeasSoftware;
using System;

namespace Salary.NET
{
	public class SalaryFilterEventArgs : EventArgs
	{
		private ModelFilter _modelFilter = null;

		public ModelFilter ModelFilter { get { return this._modelFilter; } }

		public SalaryFilterEventArgs(ModelFilter modelFilter)
		{
			this._modelFilter = modelFilter;
		}
	}
}
