﻿using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Support.V7.Widget;
using Android.Views;
using ShowcaseView.Utilities;

namespace ShowCaseView.Droid.Services
{
	public class ShowCaseImageView : AppCompatImageView
    {
        #region CLASS LEVEL VARIABLES

        private Bitmap mBitmap;
        private Paint mBackgroundPaint, mErasePaint;
        private Color mBackgroundColor = Color.Transparent;
        private Color mFocusBorderColor = Color.Transparent;
        private int mRoundRectRadius = 10;
        private Calculator mCalculator;
        private RectF rectF;

        #endregion

        #region CONSTRUCTORS

        public ShowCaseImageView(Context context) : base(context)
        {
            Init();
        }

        #endregion


        /// <summary>
        /// Initializations for background and paints
        /// </summary>
        private void Init()
        {
            if (Build.VERSION.SdkInt >= BuildVersionCodes.Honeycomb)
            {
                SetLayerType(LayerType.Hardware, null);
            }

            SetWillNotDraw(false);
            SetBackgroundColor(Color.Transparent);
            mBackgroundPaint = new Paint();
            mBackgroundPaint.AntiAlias = true;
            mBackgroundPaint.Color = mBackgroundColor;
            mBackgroundPaint.Alpha = 0xFF;

            mErasePaint = new Paint();
            mErasePaint.SetXfermode(new PorterDuffXfermode(PorterDuff.Mode.Clear));
            mErasePaint.Alpha = 0xFF;
            mErasePaint.AntiAlias = true;

            rectF = new RectF();
        }

        /// <summary>
        /// Setting parameters for background an animation
        /// </summary>
        /// <param name="backgroundColor"></param>
        /// <param name="calculator"></param>
        public void SetParameters(Color backgroundColor, Calculator calculator)
        {
            mBackgroundColor = backgroundColor;
            mCalculator = calculator;
        }

        /// <summary>
        /// Draws background and moving focus area
        /// </summary>
        /// <param name="canvas"></param>
        public override void Draw(Canvas canvas)
        {
            base.Draw(canvas);

            if (mBitmap == null)
            {
                mBitmap = Bitmap.CreateBitmap(Width, Height, Bitmap.Config.Argb8888);
                mBitmap.EraseColor(mBackgroundColor);
            }
            canvas.DrawBitmap(mBitmap, 0, 0, mBackgroundPaint);
			DrawRoundedRectangle(canvas);
		}

        /// <summary>
        /// Draws focus rounded rectangle
        /// </summary>
        /// <param name="canvas"></param>
        private void DrawRoundedRectangle(Canvas canvas)
        {
            float left = mCalculator.RoundRectLeft(0, 1);
            float top = mCalculator.RoundRectTop(0, 1);
            float right = mCalculator.RoundRectRight(0, 1);
            float bottom = mCalculator.RoundRectBottom(0, 1);
            rectF.Set(left, top, right, bottom);
            canvas.DrawRoundRect(rectF, mRoundRectRadius, mRoundRectRadius, mErasePaint);
        }
    }
}