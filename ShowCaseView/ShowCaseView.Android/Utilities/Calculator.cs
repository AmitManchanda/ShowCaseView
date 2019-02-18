using Android.Views;

namespace ShowcaseView.Utilities
{
	public class Calculator
    {
        #region Class Variables

        private double mBitmapWidth, mBitmapHeight;
        private double mFocusWidth, mFocusHeight, mCircleCenterX, mCircleCenterY;
        private bool mHasFocus;

		#endregion

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
    }
}