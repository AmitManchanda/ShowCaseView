using CoreGraphics;
using ShowCaseView.iOS.Layout;
using ShowCaseView.iOS.Utilities;
using ShowCaseView.Model;
using UIKit;

namespace ShowCaseView.iOS.Services
{
	public class ShowCase : UIView
	{
		// MARK: Material design guideline constant
		public const float BackgroundAlpha = .96f;
		public const float TargetHolderRadius = 44f;
		public const float TextCenterOffset = 44f + 20f;
		public const float InstructionsCenterOffset = 20f;
		public const float LabelMargin = 0f;
		public const float TargetPadding = 20f;

		// Other default properties
		public const float LabelDefaultHeight = 50f;
		public static UIColor BackgroundDefaultColor = UIColor.Black;
		public static UIColor TargetHolderColor = UIColor.White;

		// MARK: Private view properties
		public UIView containerView;
		public UIView targetView;
		public UIView targetCopyView;
		public ShowCaseInstructionView instructionView;

		// MARK: Public Properties

		// Background
		public UIColor backgroundPromptColor;
		public float backgroundPromptColorAlpha;
		// Target
		public UIColor targetTintColor;
		public float targetHolderRadius;
		public UIColor targetHolderColor;


		//Config
		public ShowCaseConfig config;

		public ShowCase() : base(new CGRect(0, 0, UIScreen.MainScreen.Bounds.Width, UIScreen.MainScreen.Bounds.Height))
		{
			this.Configure();
		}
	}

	public static class ShowCaseExtension
	{

		public static void Configure(this ShowCase materialShowcase)
		{
			materialShowcase.BackgroundColor = UIColor.Clear;
			var window = UIApplication.SharedApplication.Delegate?.GetWindow();
			if (window != null)
			{
				materialShowcase.containerView = window;
				materialShowcase.SetDefaultProperties();
			}
		}

		public static void SetDefaultProperties(this ShowCase materialShowcase)
		{
			// Background
			materialShowcase.backgroundPromptColor = ShowCase.BackgroundDefaultColor;
			materialShowcase.backgroundPromptColorAlpha = ShowCase.BackgroundAlpha;
			// Target view
			materialShowcase.targetTintColor = ShowCase.BackgroundDefaultColor;
			materialShowcase.targetHolderColor = ShowCase.TargetHolderColor;
			materialShowcase.targetHolderRadius = ShowCase.TargetHolderRadius;
		}

		// Calculates the center point based on targetview
		public static CGPoint CalculateCenter(this ShowCase materialShowcase, UIView targetView, UIView containerView)
		{
			var targetRect = targetView.ConvertRectToCoordinateSpace(targetView.Bounds, containerView);
			return targetRect.Center();
		}

		/// Create a copy view of target view
		/// It helps us not to affect the original target view
		public static void AddTarget(this ShowCase materialShowcase, CGPoint atCenter)
		{
			materialShowcase.targetCopyView = materialShowcase.targetView.SnapshotView(true);
			var width = materialShowcase.targetCopyView.Frame.Width;
			var height = materialShowcase.targetCopyView.Frame.Height;
			materialShowcase.targetCopyView.Frame = new CGRect(0, 0, width, height);
			materialShowcase.targetCopyView.Center = atCenter;
			materialShowcase.targetCopyView.TranslatesAutoresizingMaskIntoConstraints = true;
			materialShowcase.targetCopyView.Frame = RectangleFExtensions.Inset(materialShowcase.targetCopyView.Frame, -5f, -5f);
			materialShowcase.targetCopyView.Layer.BorderColor = UIColor.White.CGColor;
			materialShowcase.targetCopyView.Layer.BorderWidth = 5f;
			materialShowcase.AddSubview(materialShowcase.targetCopyView);
		}

		public static void InitViews(this ShowCase materialShowcase)
		{
			var center = materialShowcase.CalculateCenter(materialShowcase.targetView, materialShowcase.containerView);
			materialShowcase.AddTarget(center);
			materialShowcase.AddInstructionView(center);
			materialShowcase.instructionView.LayoutIfNeeded();
			foreach (var subView in materialShowcase.Subviews)
				subView.UserInteractionEnabled = false;
		}

		public static void AddInstructionView(this ShowCase materialShowcase, CGPoint atCenter)
		{
			materialShowcase.instructionView = new ShowCaseInstructionView();
			materialShowcase.instructionView.text = materialShowcase.config.ViewText;

			// Calculate x position
			
			float xPosition = ShowCase.LabelMargin;

			// Calculate y position
			float yPosition;

			if (materialShowcase.config.TextVerticalPosition != VerticalPosition.Top)
				yPosition = (float)atCenter.Y + ShowCase.TextCenterOffset;
			else
				yPosition = (float)atCenter.Y - ShowCase.TextCenterOffset - ShowCase.LabelDefaultHeight * 2;

			materialShowcase.instructionView.Frame = new CGRect(
				xPosition,
				yPosition,
				materialShowcase.containerView.Frame.Width - (xPosition + xPosition),
				(materialShowcase.containerView.Frame.Height / 2));
			materialShowcase.AddSubview(materialShowcase.instructionView);
		}

		/// Sets a general UIView as target
		public static void SetTargetView(this ShowCase materialShowcase, UIView view)
		{
			materialShowcase.targetView = view;
		}

		public static void InitConfig(this ShowCase materialShowcase, ShowCaseConfig showCaseConfig)
		{
			materialShowcase.config = showCaseConfig;
		}

		public static void Show(this ShowCase materialShowcase)
		{
			materialShowcase.InitViews();
			materialShowcase.BackgroundColor = UIColor.Black;
			materialShowcase.Alpha = .2f;
			materialShowcase.containerView.AddSubview(materialShowcase);
			materialShowcase.LayoutIfNeeded();
		}
	}
}