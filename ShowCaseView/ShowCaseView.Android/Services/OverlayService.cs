using System.Collections.Generic;
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
		private static List<Android.Views.View> _views = new List<Android.Views.View>();
		private ShowCaseConfig _config;

		public OverlayService()
		{
		}

		public void AddOverlay(Xamarin.Forms.View onView, ShowCaseConfig config)
		{
			if (_views.Count == 0)
			{
				_config = config;
				FrameLayout frame = new FrameLayout(MainApplication.ActivityContext);
				frame.AddView(Focus(onView));
				var view = ((Activity)MainApplication.ActivityContext).LayoutInflater.Inflate(Resource.Layout.ShowcaseViewTitleLayout, frame);
				SetTextForView(view);
				_views.Add(view);
				_decoreView.AddView(view);
			}
		}

		private void SetTextForView(Android.Views.View view)
		{
			var textView = view.FindViewById<TextView>(Resource.Id.textView1);
			textView.SetTextAppearance(Resource.Style.ShowcaseDefaultTitleStyle);
			SetGravity(textView);
			textView.Text = _config.ViewText;
		}

		private void SetGravity(TextView textView)
		{
			if (_config.TextVerticalPosition == VerticalPosition.Top)
			{
				textView.Gravity = _config.TextHorizontalPosition == HorizontalPosition.Left ? GravityFlags.Top | GravityFlags.Left :
					_config.TextHorizontalPosition == HorizontalPosition.Right ? GravityFlags.Top | GravityFlags.Right : GravityFlags.Top | GravityFlags.Center;
			}
			else
			{
				textView.Gravity = _config.TextHorizontalPosition == HorizontalPosition.Left ? GravityFlags.Bottom | GravityFlags.Left :
					_config.TextHorizontalPosition == HorizontalPosition.Right ? GravityFlags.Bottom | GravityFlags.Right : GravityFlags.Bottom | GravityFlags.Center;
			}
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