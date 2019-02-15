using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ShowCaseView.Controls
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ShowCaseViewControl : Overlay
	{
		private ShowCaseConfig _showCaseConfig;
		public ShowCaseViewControl () : base()
		{
			InitializeComponent ();
			BackgroundColor = Color.FromRgba(0, 0, 0, 0.5);
		}

		public void Configure(ShowCaseConfig config)
		{
			try
			{
				_showCaseConfig = config;
				SetText(config.ViewText, config.TextHorizontalPosition, config.TextVerticalPosition);
			}
			catch (Exception ex)
			{
			}
		}

		private void SetText(string viewText, LayoutOptions textHorizontalPosition, LayoutOptions textVerticalPosition)
		{
			var text = new Label
			{
				Text = viewText,
				TextColor = Color.White,
				FontSize = 13,
				VerticalTextAlignment = TextAlignment.Center,
				HorizontalTextAlignment = TextAlignment.Center,
				BackgroundColor = Color.Transparent,
				HorizontalOptions = textHorizontalPosition,
				VerticalOptions = textVerticalPosition,
				LineBreakMode = LineBreakMode.WordWrap
			};
			StackContainer.Children.Add(text);
		}

		public override void Show(View onView)
		{
			try
			{
				StackContainer.Children.Add(onView);
				OverlayService.AddOverlay(this, onView);
			}
			catch (Exception ex)
			{
			}
		}
	}

	public class ShowCaseConfig
	{
		public Color BackgroundColor { get; set; }
		public string ViewText { get; set; }
		//Here Top and Bottom Equivalent to Top and Right
		public LayoutOptions TextVerticalPosition { get; set; }
		public LayoutOptions TextHorizontalPosition { get; internal set; }
	}
}