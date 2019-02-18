using Android.App;
using Android.Views;
using Android.Widget;
using ShowcaseView.Utilities;
using ShowCaseView.Droid.Services;
using ShowCaseView.IServices;
using ShowCaseView.Model;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: Dependency(typeof(OverlayService))]
namespace ShowCaseView.Droid.Services
{
	public class OverlayService : IOverlayService
	{
		private FrameLayout _decoreView => (FrameLayout)((Activity)MainApplication.ActivityContext).Window.DecorView;

		public OverlayService()
		{
		}

		public void AddOverlay(Xamarin.Forms.View onView, ShowCaseConfig config)
		{
			var focusedView = Focus(onView);
			_decoreView.AddView(focusedView);
		}

		private static IVisualElementRenderer GetOrCreateRenderer(VisualElement element)
		{
			var renderer = Platform.GetRenderer(element);
			if (renderer == null)
			{
				renderer = Platform.CreateRendererWithContext(element, MainApplication.ActivityContext);
				Platform.SetRenderer(element, renderer);
			}
			return renderer;
		}

		private ShowCaseImageView Focus(Xamarin.Forms.View onView)
		{
			Android.Graphics.Color color = Android.Graphics.Color.Black;
			color.A = 90;
			var mView = GetOrCreateRenderer(onView).View;
			var mCalculator = new Calculator(mView, 0);
			ShowCaseImageView imageView = new ShowCaseImageView(MainApplication.ActivityContext);
			imageView.SetParameters(color, mCalculator);
			imageView.LayoutParameters = new FrameLayout.LayoutParams(ViewGroup.LayoutParams.MatchParent, ViewGroup.LayoutParams.MatchParent);
			imageView.SetBorderParameters(Android.Graphics.Color.White, 2);
			return imageView;
		}
	}
}