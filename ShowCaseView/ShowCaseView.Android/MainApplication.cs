using System;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;

// found this at https://stackoverflow.com/questions/47353986/xamarin-forms-forms-context-is-obsolete
namespace ShowCaseView.Droid
{
#if DEBUG
	[Application(Debuggable = true)]
#else
    [Application(Debuggable=false)]
#endif

	public partial class MainApplication : Application, Application.IActivityLifecycleCallbacks
	{
		internal static Context ActivityContext { get; private set; }

		public MainApplication(IntPtr handle, JniHandleOwnership transfer) : base(handle, transfer) { }

		public override void OnCreate()
		{
			base.OnCreate();
			RegisterActivityLifecycleCallbacks(this);
		}

		public override void OnTerminate()
		{
			base.OnTerminate();
			UnregisterActivityLifecycleCallbacks(this);
		}

		public void OnActivityCreated(Activity activity, Bundle savedInstanceState)
		{
			ActivityContext = activity;
		}

		public void OnActivityResumed(Activity activity)
		{
			ActivityContext = activity;
		}

		public void OnActivityStarted(Activity activity)
		{
			ActivityContext = activity;
		}

		public void OnActivityDestroyed(Activity activity) { }
		public void OnActivityPaused(Activity activity) { }
		public void OnActivitySaveInstanceState(Activity activity, Bundle outState) { }
		public void OnActivityStopped(Activity activity) { }
	}
}