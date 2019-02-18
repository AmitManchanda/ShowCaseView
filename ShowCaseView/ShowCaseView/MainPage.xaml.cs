using ShowCaseView.Controls;
using System;
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
		}

		private void ClickMeButton_Clicked(object sender, EventArgs e)
		{
			ShowCaseViewControl showCaseView = new ShowCaseViewControl();
			showCaseView.Show(ClickMeButton);
		}
	}
}