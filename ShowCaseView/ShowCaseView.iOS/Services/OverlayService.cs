using Foundation;
using ShowCaseView.iOS.Services;
using ShowCaseView.IServices;
using ShowCaseView.Model;
using System.Threading.Tasks;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: Dependency(typeof(OverlayService))]
namespace ShowCaseView.iOS.Services
{
	public class OverlayService : IOverlayService
	{
		public OverlayService()
		{
			UIDevice.Notifications.ObserveOrientationDidChange(OrientationChanged);
		}

		private async void OrientationChanged(object sender, NSNotificationEventArgs e)
		{
			await Task.CompletedTask;
		}

		public void AddOverlay(View onView, ShowCaseConfig config)
		{
			ShowCase showCase = new ShowCase();
			showCase.SetTargetView(GetOrCreateRenderer(onView).NativeView);
			showCase.InitConfig(config);
			showCase.Show();
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
	}
}