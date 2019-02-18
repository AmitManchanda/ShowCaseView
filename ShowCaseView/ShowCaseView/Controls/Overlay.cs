using ShowCaseView.IServices;
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

		public void Show(View onView)
		{
			OverlayService.AddOverlay(this, onView);
		}
	}
}
