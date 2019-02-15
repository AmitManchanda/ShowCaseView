using ShowCaseView.Controls;
using Xamarin.Forms;

namespace ShowCaseView.IServices
{
	public interface IOverlayService
    {
		void AddOverlay(Overlay view, View onView);
		void RemoveOverlay(Overlay view);
	}
}
