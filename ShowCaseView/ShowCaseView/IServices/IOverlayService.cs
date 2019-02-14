using ShowCaseView.Controls;

namespace ShowCaseView.IServices
{
	public interface IOverlayService
    {
		void AddOverlay(Overlay view);
		void RemoveOverlay(Overlay view);
	}
}
