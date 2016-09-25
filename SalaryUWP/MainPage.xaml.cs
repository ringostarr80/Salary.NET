using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// Die Vorlage "Leere Seite" ist unter http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409 dokumentiert.

namespace SalaryUWP
{
    /// <summary>
    /// Eine leere Seite, die eigenständig verwendet oder zu der innerhalb eines Rahmens navigiert werden kann.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

		private void btnShowPane_Click(object sender, RoutedEventArgs e)
		{
			this.splitViewNavigation.IsPaneOpen = !this.splitViewNavigation.IsPaneOpen;
		}

		private void buttonNavigation_Click(object sender, RoutedEventArgs e)
		{
			this.splitViewNavigation.IsPaneOpen = !this.splitViewNavigation.IsPaneOpen;
		}
	}
}
