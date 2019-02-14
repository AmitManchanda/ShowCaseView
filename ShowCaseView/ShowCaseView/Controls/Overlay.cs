using ShowCaseView.IServices;
using Xamarin.Forms;

namespace ShowCaseView.Controls
{
	public abstract class Overlay : ContentView
    {
		public Overlay()
		{
			OverlayService = DependencyService.Get<IOverlayService>();
		}

		protected IOverlayService OverlayService { get; }

		public virtual void Show()
		{
			OverlayService.AddOverlay(this);
		}

		public virtual void Hide()
		{
			OverlayService.RemoveOverlay(this);
		}
	}
}
