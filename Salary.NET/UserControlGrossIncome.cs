using System;
using System.Windows.Forms;
using SalaryLibrary;

namespace Salary.NET
{
	public partial class UserControlGrossIncome : UserControl, ICloneable
	{
		public event EventHandler<SalaryItemChangedEventArgs> SalaryItemChanged;

		protected virtual void OnSalaryItemChanged(SalaryItemChangedEventArgs e)
		{
			if(this.SalaryItemChanged != null) {
				this.SalaryItemChanged(this, e);
			}
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
			InitializeComponent();
			this.InitControls();
		}

		public UserControlGrossIncome(SalaryType salaryType)
		{
			InitializeComponent();
			this.InitControls();

			this.SalaryType = salaryType;
		}

		public UserControlGrossIncome(SalaryType salaryType, double amount)
		{
			InitializeComponent();
			this.InitControls();

			this.SalaryType = salaryType;
			this.numericUpDownAmount.Value = (decimal)amount;
		}

		public object Clone()
		{
			var clone = new UserControlGrossIncome(this.SalaryType, this.Amount) {
				Top = this.Top,
				Left = this.Left,
				SalaryTypeWidth = this.SalaryTypeWidth,
				AmountWidth = this.AmountWidth
			};
			return clone;
		}

		public void InitControls()
		{
			this.comboBoxSalaryType.Items.Add(new SalaryTypeItem(SalaryType.Gehalt));
			this.comboBoxSalaryType.Items.Add(new SalaryTypeItem(SalaryType.BezugVWLlfd));
			this.comboBoxSalaryType.Items.Add(new SalaryTypeItem(SalaryType.BruttoWeihnachtsgeld));
			this.comboBoxSalaryType.Items.Add(new SalaryTypeItem(SalaryType.NettoWeihnachtsgeld));
			this.comboBoxSalaryType.Items.Add(new SalaryTypeItem(SalaryType.AbzugVWL));

			this.comboBoxSalaryType.SelectedIndex = 0;
		}

		private void comboBoxSalaryType_SelectedIndexChanged(object sender, EventArgs e)
		{
			this.OnSalaryItemChanged(new SalaryItemChangedEventArgs(this.SalaryType, this.Amount));
		}

		private void numericUpDownAmount_ValueChanged(object sender, EventArgs e)
		{
			this.OnSalaryItemChanged(new SalaryItemChangedEventArgs(this.SalaryType, this.Amount));
		}
	}
}
