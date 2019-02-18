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

		private void ShowMeButton_Clicked(object sender, EventArgs e)
		{
			Overlay overlay = new Overlay();
			overlay.Show(ShowMeButton, null);
		}
	}
}