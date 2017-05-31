using System;
using System.Collections.Generic;
using System.Windows.Forms;
using SalaryLibrary;

namespace Salary.NET
{
	public partial class UserControlGrossIncome : UserControl, ICloneable
	{
		private SalaryTypeCollection _salaryTypes = new SalaryTypeCollection();

		public SalaryTypeCollection SalaryTypes { get { return this._salaryTypes; } set { this._salaryTypes = value; } }

		public event EventHandler<SalaryItemChangedEventArgs> SalaryItemChanged;

		protected virtual void OnSalaryItemChanged(SalaryItemChangedEventArgs e)
		{
			this.SalaryItemChanged?.Invoke(this, e);
		}

		public SalaryType SalaryType {
			get {
				return ((SalaryTypeItem)this.comboBoxSalaryType.SelectedItem).Type;
			}
			set {
				var itemsCount = this.comboBoxSalaryType.Items.Count;
				for(var i = 0; i < itemsCount; i++) {
					var item = (SalaryTypeItem)this.comboBoxSalaryType.Items[i];
					if (item.Type == value) {
						this.comboBoxSalaryType.SelectedIndex = i;
						break;
					}
				}

				this.OnSalaryItemChanged(new SalaryItemChangedEventArgs(this.SalaryType, this.Amount));
			}
		}

		public int SalaryTypeWidth {
			get {
				return this.comboBoxSalaryType.Width;
			}
			set {
				this.comboBoxSalaryType.Width = value;
				this.numericUpDownAmount.Left = this.comboBoxSalaryType.Width + 6;
				this.Width = this.comboBoxSalaryType.Width + 6 + this.numericUpDownAmount.Width;
			}
		}

		public double Amount {
			get {
				return (double)this.numericUpDownAmount.Value;
			}
			set {
				this.numericUpDownAmount.Value = (decimal)value;
				this.OnSalaryItemChanged(new SalaryItemChangedEventArgs(this.SalaryType, this.Amount));
			}
		}

		public int AmountWidth {
			get {
				return this.numericUpDownAmount.Width;
			}
			set {
				this.numericUpDownAmount.Width = value;
				this.Width = this.comboBoxSalaryType.Width + 6 + this.numericUpDownAmount.Width;
			}
		}

		public UserControlGrossIncome()
		{
			this._salaryTypes = new SalaryTypeCollection();

			InitializeComponent();
			this.InitControls();
		}

		public UserControlGrossIncome(SalaryTypeCollection salaryTypes)
		{
			this._salaryTypes = salaryTypes;

			InitializeComponent();
			this.InitControls();
		}

		public UserControlGrossIncome(SalaryTypeCollection salaryTypes, SalaryType salaryType)
		{
			this._salaryTypes = salaryTypes;
			InitializeComponent();
			this.InitControls();

			this.SalaryType = salaryType;
		}

		public UserControlGrossIncome(SalaryTypeCollection salaryTypes, SalaryType salaryType, double amount)
		{
			this._salaryTypes = salaryTypes;

			InitializeComponent();
			this.InitControls();

			this.SalaryType = salaryType;
			this.numericUpDownAmount.Value = (decimal)amount;
		}

		public object Clone()
		{
			var clone = new UserControlGrossIncome(this._salaryTypes, this.SalaryType, this.Amount) {
				Top = this.Top,
				Left = this.Left,
				SalaryTypeWidth = this.SalaryTypeWidth,
				AmountWidth = this.AmountWidth
			};
			return clone;
		}

		public void InitControls()
		{
			this.comboBoxSalaryType.Items.Clear();
			foreach(var salaryType in this._salaryTypes) {
				this.comboBoxSalaryType.Items.Add(new SalaryTypeItem(salaryType));
			}
			if (this.comboBoxSalaryType.Items.Count == 0) {
				this.comboBoxSalaryType.Items.Add(new SalaryTypeItem(new SalaryType(1, 1, "Dummy")));
			}

			this.comboBoxSalaryType.SelectedIndex = 0;
		}

		private void ComboBoxSalaryType_SelectedIndexChanged(object sender, EventArgs e)
		{
			this.OnSalaryItemChanged(new SalaryItemChangedEventArgs(this.SalaryType, this.Amount));
		}

		private void NumericUpDownAmount_ValueChanged(object sender, EventArgs e)
		{
			this.OnSalaryItemChanged(new SalaryItemChangedEventArgs(this.SalaryType, this.Amount));
		}

		private void numericUpDownAmount_Enter(object sender, EventArgs e)
		{
			var numericUpDown = (NumericUpDown)sender;
			numericUpDown.Select(0, numericUpDown.Value.ToString().Length + 3);
		}
	}
}
