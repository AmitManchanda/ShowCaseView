using ShowCaseView.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ShowCaseView
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();
		}

		protected override void OnAppearing()
		{
			base.OnAppearing();
			ShowCaseViewControl showCaseView = new ShowCaseViewControl();
			showCaseView.Configure(new ShowCaseConfig() { ViewText = "Hello", TextHorizontalPosition = LayoutOptions.CenterAndExpand, TextVerticalPosition = LayoutOptions.EndAndExpand});
			showCaseView.Show(WelcomeTextLabel);
		}
	}
}
