using CoreGraphics;
using ShowCaseView.iOS.Services;
using UIKit;

namespace ShowCaseView.iOS.Layout
{
	public class ShowCaseInstructionView : UIView
	{
		public UILabel label;
		public string text;

		public ShowCaseInstructionView() : base(new CGRect(0, 0, UIScreen.MainScreen.Bounds.Width, 0))
		{
		}

		private void AddPrimaryLabel()
		{
			label = new UILabel();
			label.Font = UIFont.BoldSystemFontOfSize(40);
			label.TextColor = UIColor.White;
			label.Hidden = false;
			label.Lines = 0;
			label.LineBreakMode = UILineBreakMode.WordWrap;
			label.Text = text;
			ShowCase showCase = (ShowCase)Superview;
			if (showCase.config.TextHorizontalPosition == Model.HorizontalPosition.Left)
			{
				label.TextAlignment = UITextAlignment.Left;
				label.Frame = new CGRect(20, 0, Frame.Width - 20, 50);
			}
			else if (showCase.config.TextHorizontalPosition == Model.HorizontalPosition.Center)
			{
				label.TextAlignment = UITextAlignment.Center;
				label.Frame = new CGRect(20, 0, Frame.Width - 40, 50);
			}
			else
			{
				label.TextAlignment = UITextAlignment.Right;
				label.Frame = new CGRect(0, 0, Frame.Width - 20, 50);
			}
			
			AddSubview(label);
		}

		public override void LayoutSubviews()
		{
			base.LayoutSubviews();
			AddPrimaryLabel();
			foreach (var subview in Subviews)
				subview.UserInteractionEnabled = false;
		}
	}
}