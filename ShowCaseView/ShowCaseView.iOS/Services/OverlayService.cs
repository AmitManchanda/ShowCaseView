using ShowCaseView.iOS.Services;
using ShowCaseView.IServices;
using ShowCaseView.Model;
using Xamarin.Forms;

[assembly: Dependency(typeof(OverlayService))]
namespace ShowCaseView.iOS.Services
{
	public class OverlayService : IOverlayService
	{
		public void AddOverlay(View onView, ShowCaseConfig config)
		{
		}
	}
}