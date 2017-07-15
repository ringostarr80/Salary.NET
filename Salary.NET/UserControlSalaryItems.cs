using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using SalaryLibrary;

namespace Salary.NET
{
	public partial class UserControlSalaryItems : UserControl
	{
		private SalaryTypeCollection _salaryTypes = new SalaryTypeCollection();
		private List<UserControlGrossIncome> _grossIncomeControls = new List<UserControlGrossIncome>();
		private int _userControlCounter = 1;

		public event EventHandler<SalaryItemChangedEventArgs> SalaryItemChanged;
		public Dictionary<SalaryType, SalaryItem> Salaries {
			get {
				var salaries = new Dictionary<SalaryType, SalaryItem> {
					{ this.userControlGrossIncome1.SalaryType, new SalaryItem(this.userControlGrossIncome1.Amount) }
				};
				foreach (var grossControl in this._grossIncomeControls) {
					if (grossControl.Amount == 0.0) {
						continue;
					}
					if (salaries.ContainsKey(grossControl.SalaryType)) {
						continue;
					}
					salaries.Add(grossControl.SalaryType, new SalaryItem(grossControl.Amount));
				}

				return salaries;
			}
		}

		protected virtual void OnSalaryItemChanged(SalaryItemChangedEventArgs e)
		{
			this.SalaryItemChanged?.Invoke(this, e);
		}

		public UserControlSalaryItems()
		{
			InitializeComponent();
			this.userControlGrossIncome1.SalaryType = new SalaryType(1, 2000, "Gehalt");
			this.RefreshPanelSize();
		}

		public UserControlSalaryItems(SalaryTypeCollection salaryTypes)
		{
			this._salaryTypes = salaryTypes;

			InitializeComponent();
			this.userControlGrossIncome1.SalaryType = new SalaryType(1, 2000, "Gehalt");
			this.RefreshPanelSize();
		}

		public void SetSalaryTypes(SalaryTypeCollection salaryTypes)
		{
			this._salaryTypes = salaryTypes;
			this.userControlGrossIncome1.SalaryTypes = salaryTypes;
			this.userControlGrossIncome1.InitControls();
			this.ResetSalaryItems();
		}

		public void SetSalaryItems(SalaryTypeCollection salaryTypes, Dictionary<SalaryType, SalaryItem> salaryAccounts)
		{
			this.SetSalaryTypes(salaryTypes);

			var counter = 0;
			foreach(var keyValue in salaryAccounts) {
				var salaryType = this._salaryTypes.Find(st => st == keyValue.Key);
				if (salaryType == null) {
					continue;
				}

				counter++;
				if (counter > 1) {
					this.AddSalaryItem(salaryType, keyValue.Value.Amount);
					continue;
				}

				this.userControlGrossIncome1.SalaryType = salaryType;
				this.userControlGrossIncome1.Amount = keyValue.Value.Amount;
			}
		}

		private void ResetSalaryItems()
		{
			var numbers = new List<int>();
			this._grossIncomeControls.ForEach((userControl) => {
				var match = Regex.Match(userControl.Name, "([0-9]+)$", RegexOptions.Compiled);
				if(!match.Success) {
					return;
				}

				numbers.Add(Convert.ToInt32(match.Groups[1].Value));
			});

			foreach(var number in numbers) {
				this._grossIncomeControls.RemoveAll(c => c.Name == "userControlGrossIncome" + number);

				this.panel.Controls.RemoveByKey("userControlGrossIncome" + number);
				this.panel.Controls.RemoveByKey("buttonAdd" + number);
				this.panel.Controls.RemoveByKey("buttonRemove" + number);
			}

			this.userControlGrossIncome1.Amount = 0;
			if (this._salaryTypes.Count > 0) {
				foreach(var salaryType in this._salaryTypes) {
					this.userControlGrossIncome1.SalaryType = salaryType;
					break;
				}
			} else {
				this.userControlGrossIncome1.SalaryType = new SalaryType(1, 1, "Dummy");
			}

			this.ReorderItems();
			this.RefreshPanelSize();
		}

		private void ButtonAdd1_Click(object sender, EventArgs e)
		{
			this.AddSalaryItem();
		}

		private void AddSalaryItem()
		{
			if (this._salaryTypes.Count > 0) {
				foreach (var salaryType in this._salaryTypes) {
					this.AddSalaryItem(salaryType, 0);
					break;
				}
			} else {
				this.AddSalaryItem(new SalaryType(1, 1, "Dummy"), 0);
			}
		}

		private void AddSalaryItem(SalaryType salaryType, double amount)
		{
			var incomeControlsCount = this._grossIncomeControls.Count;

			var newUserControlGrossIncome = new UserControlGrossIncome(this._salaryTypes) {
				Name = "userControlGrossIncome" + (++this._userControlCounter),
				Left = this.userControlGrossIncome1.Left,
				Top = this.userControlGrossIncome1.Top + (incomeControlsCount + 1) * 27, // 46 - 19 = 27
				Amount = amount,
				AmountWidth = this.userControlGrossIncome1.AmountWidth,
				SalaryType = salaryType,
				SalaryTypeWidth = this.userControlGrossIncome1.SalaryTypeWidth
			};
			newUserControlGrossIncome.SalaryItemChanged += this.UserControlGrossIncome1_SalaryItemChanged;

			var newButtonAdd = new Button() {
				Name = "buttonAdd" + this._userControlCounter,
				Left = this.buttonAdd1.Left,
				Top = this.buttonAdd1.Top + (incomeControlsCount + 1) * 27,
				Width = this.buttonAdd1.Width,
				Height = this.buttonAdd1.Height,
				Text = this.buttonAdd1.Text
			};
			newButtonAdd.Click += this.ButtonAdd1_Click;

			var newButtonRemove = new Button() {
				Name = "buttonRemove" + this._userControlCounter,
				Left = this.buttonRemove1.Left,
				Top = this.buttonRemove1.Top + (incomeControlsCount + 1) * 27,
				Width = this.buttonRemove1.Width,
				Height = this.buttonRemove1.Height,
				Text = this.buttonRemove1.Text
			};
			newButtonRemove.Click += this.ButtonRemove1_Click;

			this._grossIncomeControls.Add(newUserControlGrossIncome);
			this.panel.Controls.Add(newUserControlGrossIncome);
			this.panel.Controls.Add(newButtonAdd);
			this.panel.Controls.Add(newButtonRemove);

			this.RefreshPanelSize();
		}

		private void ButtonRemove1_Click(object sender, EventArgs e)
		{
			var removeButton = (Button)sender;
			var buttonNumberMatch = Regex.Match(removeButton.Name, "^buttonRemove([0-9]+)$", RegexOptions.Compiled);
			if (!buttonNumberMatch.Success) {
				return;
			}
			var buttonNumber = Convert.ToInt32(buttonNumberMatch.Groups[1].Value);

			this._grossIncomeControls.RemoveAll(c => c.Name == "userControlGrossIncome" + buttonNumber);

			this.panel.Controls.RemoveByKey("userControlGrossIncome" + buttonNumber);
			this.panel.Controls.RemoveByKey("buttonAdd" + buttonNumber);
			this.panel.Controls.RemoveByKey("buttonRemove" + buttonNumber);

			this.ReorderItems();
			this.RefreshPanelSize();
		}

		private void RefreshPanelSize()
		{
			var itemsCount = this._grossIncomeControls.Count;
			var height = (itemsCount + 1) * 27 + 2;
			this.panel.Height = height;

			if (this.groupBox.Height - this.panel.Height < 25) {
				var overlap = this.panel.Height + 25 - this.groupBox.Height;
				var steps = overlap / 5;
				var stepsRest = overlap % 5;
				if (stepsRest > 0) {
					steps++;
				}
				this.vScrollBar.Maximum = 9 + steps;
				this.vScrollBar.Enabled = true;
			} else {
				this.vScrollBar.Enabled = false;
			}
		}

		private void ReorderItems()
		{
			for(var i = 0; i < this._grossIncomeControls.Count; i++) {
				this._grossIncomeControls[i].Top = this.userControlGrossIncome1.Top + (i + 1) * 27;

				var itemNumberMatch = Regex.Match(this._grossIncomeControls[i].Name, "^userControlGrossIncome([0-9]+)$", RegexOptions.Compiled);
				if(!itemNumberMatch.Success) {
					continue;
				}
				var itemNumber = Convert.ToInt32(itemNumberMatch.Groups[1].Value);
				var buttonAddControls = this.panel.Controls.Find("buttonAdd" + itemNumber, true);
				var buttonRemoveControls = this.panel.Controls.Find("buttonRemove" + itemNumber, true);

				foreach(var buttonAddControl in buttonAddControls) {
					buttonAddControl.Top = this.userControlGrossIncome1.Top + (i + 1) * 27;
				}
				foreach(var buttonRemoveControl in buttonRemoveControls) {
					buttonRemoveControl.Top = this.userControlGrossIncome1.Top + (i + 1) * 27;
				}
			}
		}

		private void VScrollBar_Scroll(object sender, ScrollEventArgs e)
		{
			this.panel.Top = -e.NewValue * 5;
		}

		private void UserControlGrossIncome1_SalaryItemChanged(object sender, SalaryItemChangedEventArgs e)
		{
			this.OnSalaryItemChanged(e);
		}
	}
}
