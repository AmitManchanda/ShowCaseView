using System;
using ShowCaseView.Controls;
using ShowCaseView.Droid.Services;
using ShowCaseView.IServices;
using Xamarin.Forms;

[assembly: Dependency(typeof(OverlayService))]
namespace ShowCaseView.Droid.Services
{
	public class OverlayService : IOverlayService
	{
		public void AddOverlay(Overlay view)
		{
		}

		public void RemoveOverlay(Overlay view)
		{
		}
	}
}