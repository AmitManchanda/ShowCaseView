using ShowCaseView.IServices;
using ShowCaseView.Model;
using Xamarin.Forms;

namespace ShowCaseView.Controls
{
	public class Overlay
    {
		public Overlay()
		{
			OverlayService = DependencyService.Get<IOverlayService>();
		}

		private IOverlayService OverlayService { get; }

		public void Show(View onView, ShowCaseConfig config)
		{
			OverlayService.AddOverlay(onView, config);
		}
	}
}
