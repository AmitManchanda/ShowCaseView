using ShowCaseView.Model;
using Xamarin.Forms;

namespace ShowCaseView.IServices
{
	public interface IOverlayService
    {
		void AddOverlay(View onView, ShowCaseConfig config);
		void HideOverlay();
	}
}
