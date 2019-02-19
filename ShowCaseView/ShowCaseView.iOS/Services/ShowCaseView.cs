﻿using CoreGraphics;
using ShowCaseView.iOS.Utilities;
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
		public const float LabelMargin = 40f;
		public const float TargetPadding = 20f;

		// Other default properties
		public const float LabelDefaultHeight = 50f;
		public static UIColor BackgroundDefaultColor = UIColor.Black;
		public static UIColor TargetHolderColor = UIColor.White;

		// MARK: Private view properties
		public UIView containerView;
		public UIView targetView;
		public UIView backgroundView;
		public UIView targetHolderView;
		public UIView hiddenTargetHolderView;
		public UIView targetRippleView;
		public UIView targetCopyView;

		// MARK: Public Properties

		// Background
		public UIColor backgroundPromptColor;
		public float backgroundPromptColorAlpha;
		// Target
		public bool shouldSetTintColor = true;
		public UIColor targetTintColor;
		public float targetHolderRadius;
		public UIColor targetHolderColor;

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
			materialShowcase.AddSubview(materialShowcase.targetCopyView);
		}

		public static void InitViews(this ShowCase materialShowcase)
		{
			var center = materialShowcase.CalculateCenter(materialShowcase.targetView, materialShowcase.containerView);
			materialShowcase.AddTarget(center);
			foreach (var subView in materialShowcase.Subviews)
				subView.UserInteractionEnabled = false;
		}

		/// Sets a general UIView as target
		public static void SetTargetView(this ShowCase materialShowcase, UIView view)
		{
			materialShowcase.targetView = view;
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