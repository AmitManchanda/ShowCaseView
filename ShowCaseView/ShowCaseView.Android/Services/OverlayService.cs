using Android.App;
using Android.Views;
using Android.Widget;
using ShowcaseView.Utilities;
using ShowCaseView.Controls;
using ShowCaseView.Droid.Services;
using ShowCaseView.IServices;
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

		public void AddOverlay(Overlay view, Xamarin.Forms.View onView)
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
			var mView = GetOrCreateRenderer(onView).View;
			var mCalculator = new Calculator(mView, 0);
			var context = Android.App.Application.Context;
			ShowCaseImageView imageView = new ShowCaseImageView(context);
			imageView.SetParameters(Android.Graphics.Color.Black, mCalculator);
			imageView.LayoutParameters = new FrameLayout.LayoutParams(ViewGroup.LayoutParams.MatchParent, ViewGroup.LayoutParams.MatchParent);
			return imageView;
		}
	}
}