using ShowCaseView.Controls;
using ShowCaseView.iOS.Services;
using ShowCaseView.IServices;
using Xamarin.Forms;

[assembly: Dependency(typeof(OverlayService))]
namespace ShowCaseView.iOS.Services
{
	public class OverlayService : IOverlayService
	{
		public void AddOverlay(Overlay view, View onView)
		{
		}
	}
}