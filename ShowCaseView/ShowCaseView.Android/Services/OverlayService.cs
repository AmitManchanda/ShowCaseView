using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Android.App;
using Android.Widget;
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
		private static List<Overlay> _views = new List<Overlay>();
		private Rectangle _currentBounds;

		public OverlayService()
		{
		}

		private async void _decoreView_LayoutChange(object sender, Android.Views.View.LayoutChangeEventArgs e)
		{
			var b = Xamarin.Forms.Application.Current.MainPage.Bounds;
			if (_currentBounds.Width == b.Width && _currentBounds.Height == b.Height)
				return;
			_currentBounds = b;
			await Task.Delay(200);

			_views.ForEach(v => v.Layout(b));
		}

		public void AddOverlay(Overlay view, View onView)
		{
			_decoreView.LayoutChange += _decoreView_LayoutChange;
			view.Parent = Xamarin.Forms.Application.Current.MainPage;
			var renderer = GetOrCreateRenderer(view);
			_currentBounds = Xamarin.Forms.Application.Current.MainPage.Bounds;
			view.Layout(_currentBounds);
			_views.Add(view);
			_decoreView.AddView(renderer.View, 1);
			_decoreView.BringChildToFront(renderer.View);
		}

		public void RemoveOverlay(Overlay view)
		{
			var renderer = Platform.GetRenderer(view);
			if (renderer == null || view.Parent == null)
				return;

			Xamarin.Forms.Device.BeginInvokeOnMainThread(() =>
			{
				_decoreView.RemoveView(renderer.View);
				view.Parent = null;
			});
			_views.Remove(view);
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
	}
}