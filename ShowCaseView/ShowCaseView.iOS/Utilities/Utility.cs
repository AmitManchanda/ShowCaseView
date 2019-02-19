using CoreGraphics;

namespace ShowCaseView.iOS.Utilities
{
	public class Utility
	{
	}

	public static class CGRectExtension
	{
		public static CGPoint Center(this CGRect _rect)
		{
			return new CGPoint(_rect.GetMidX(), _rect.GetMidY());
		}
	}
}