using Foundation;
using ShowCaseView.iOS.Services;
using ShowCaseView.IServices;
using ShowCaseView.Model;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: Dependency(typeof(OverlayService))]
namespace ShowCaseView.iOS.Services
{
	public class OverlayService : IOverlayService
	{
		ShowCase _showCase;

		public OverlayService()
		{
			UIDevice.Notifications.ObserveOrientationDidChange(OrientationChanged);
		}

		private void OrientationChanged(object sender, NSNotificationEventArgs e)
		{
			
		}

		public void AddOverlay(View onView, ShowCaseConfig config)
		{
			_showCase = new ShowCase();
			_showCase.SetTargetView(GetOrCreateRenderer(onView).NativeView);
			_showCase.InitConfig(config);
			_showCase.Show();
		}

		public static IVisualElementRenderer GetOrCreateRenderer(VisualElement element)
		{
			var renderer = Platform.GetRenderer(element);
			if (renderer == null)
			{
				renderer = Platform.CreateRenderer(element);
				Platform.SetRenderer(element, renderer);
			}
			return renderer;
		}

		public void HideOverlay()
		{
			if (_showCase != null)
				_showCase.Hide();

			_showCase = null;
		}
	}
}