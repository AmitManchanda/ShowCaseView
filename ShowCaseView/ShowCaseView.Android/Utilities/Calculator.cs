using Android.App;
using Android.OS;
using Android.Util;
using Android.Views;

namespace ShowcaseView.Utilities
{ 
    public class Calculator
    {
        #region Class Variables

        private double mBitmapWidth, mBitmapHeight;
        private double mFocusWidth, mFocusHeight, mCircleCenterX, mCircleCenterY, mCircleRadius;
        private bool mHasFocus;
        private Activity mActivity;
        private View mView;
        private double mFocusCircleRadiusFactor;
        private bool mFitSystemWindows;

        /**
         * @return Focus width
         */
        public double FocusWidth
        {
            get { return mFocusWidth; }
        }

        /**
         * @return Focus height
         */
        public double FocusHeight
        {
            get { return mFocusHeight; }
        }

        /**
         * @return X coordinate of focus circle
         */
        public double CircleCenterX
        {
            get { return mCircleCenterX; }
        }

        /**
         * @return Y coordinate of focus circle
         */
        public double CircleCenterY
        {
            get { return mCircleCenterY; }
        }

        /**
         * @return Radius of focus circle
         */
        public double ViewRadius
        {
            get { return mCircleRadius; }
        }

        /**
         * @return True if there is a view to focus
         */
        public bool HasFocus
        {
            get { return mHasFocus; }
        }

        /**
         * @return Width of background bitmap
         */
        public double BitmapWidth
        {
            get { return mBitmapWidth; }
        }

        /**
         * @return Height of background bitmap
         */
        public double BitmapHeight
        {
            get { return mBitmapHeight; }
        }

        #endregion
        
        public void SetmCircleRadius(int mCircleRadius)
        {
            this.mCircleRadius = mCircleRadius;
        }

        public Calculator(View view, double radiusFactor)
        {
            double deviceWidth = Xamarin.Forms.Application.Current.MainPage.Bounds.Width;
            double deviceHeight = Xamarin.Forms.Application.Current.MainPage.Bounds.Height;
            mBitmapWidth = deviceWidth;
            mBitmapHeight = deviceHeight;
            if (view != null)
            {
                int adjustHeight = 0;
                int[] viewPoint = new int[2];
                view.GetLocationInWindow(viewPoint);
                mFocusWidth = view.Width;
                mFocusHeight = view.Height;
                mCircleCenterX = viewPoint[0] + mFocusWidth / 2;
                mCircleCenterY = viewPoint[1] + mFocusHeight / 2 - adjustHeight;
                mCircleRadius = (int)((int)(Java.Lang.Math.Hypot(view.Width, view.Height) / 2) * radiusFactor);
                mHasFocus = true;
            }
            else
            {
                mHasFocus = false;
            }
        }

        public void SetRectPosition(int positionX, int positionY, int rectWidth, int rectHeight)
        {
            mCircleCenterX = positionX;
            mCircleCenterY = positionY;
            mFocusWidth = rectWidth;
            mFocusHeight = rectHeight;
            mHasFocus = true;
        }

        public void SetCirclePosition(int positionX, int positionY, int radius)
        {
            mCircleCenterX = positionX;
            mCircleRadius = radius;
            mCircleCenterY = positionY;
            mHasFocus = true;
        }

        /// <summary>
        /// Return Radius of animating circle, given the paramaters
        /// </summary>
        /// <param name="animCounter"></param>
        /// <param name="animMoveFactor"></param>
        /// <returns></returns>
        public float CircleRadius(int animCounter, double animMoveFactor)
        {
            return (float)(mCircleRadius + animCounter * animMoveFactor);
        }

        /// <summary>
        /// Return Bottom position of round rect
        /// </summary>
        /// <param name="animCounter"></param>
        /// <param name="animMoveFactor"></param>
        /// <returns></returns>
        public float RoundRectLeft(int animCounter, double animMoveFactor)
        {
            return (float)(mCircleCenterX - mFocusWidth / 2 - animCounter * animMoveFactor);
        }

        /// <summary>
        /// Return Top position of focus round rect
        /// </summary>
        /// <param name="animCounter"></param>
        /// <param name="animMoveFactor"></param>
        /// <returns></returns>
        public float RoundRectTop(int animCounter, double animMoveFactor)
        {
            return (float)(mCircleCenterY - mFocusHeight / 2 - animCounter * animMoveFactor);
        }

        /// <summary>
        /// Return Bottom position of round rect
        /// </summary>
        /// <param name="animCounter"></param>
        /// <param name="animMoveFactor"></param>
        /// <returns></returns>
        public float RoundRectRight(int animCounter, double animMoveFactor)
        {
            return (float)(mCircleCenterX + mFocusWidth / 2 + animCounter * animMoveFactor);
        }

        /// <summary>
        /// Return Bottom position of round rect
        /// </summary>
        /// <param name="animCounter"></param>
        /// <param name="animMoveFactor"></param>
        /// <returns></returns>
        public float RoundRectBottom(int animCounter, double animMoveFactor)
        {
            return (float)(mCircleCenterY + mFocusHeight / 2 + animCounter * animMoveFactor);
        }

        /// <summary>
        /// Return Radius of focus round rect
        /// </summary>
        /// <param name="animCounter"></param>
        /// <param name="animMoveFactor"></param>
        /// <returns></returns>
        public float RoundRectLeftCircleRadius(int animCounter, double animMoveFactor)
        {
            return (float)(mFocusHeight / 2 + animCounter * animMoveFactor);
        }
    }
}