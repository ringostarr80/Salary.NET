using System;
using System.Linq;
using System.Collections.Generic;

namespace SalaryLibrary
{
	public class SalaryTypeCollection : List<SalaryType>
	{
		public bool HasConflictingElements {
			get {
				var duplicateNumber = this.GroupBy(s => s.Number, s => s.Number).Any(g => g.Count() > 1);
				if (duplicateNumber) {
					return true;
				}
				var duplicateName = this.GroupBy(s => s.Name, s => s.Name).Any(g => g.Count() > 1);
				if (duplicateName) {
					return true;
				}
				return false;
			}
		}
	}
}
