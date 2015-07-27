using System;
using System.Collections.Generic;
using System.Linq;

using Foundation;
using UIKit;

namespace CoursesiOS
{
    [Register("AppDelegate")]
    public partial class AppDelegate : UIApplicationDelegate
    {
        public override UIWindow Window
        {
            get;
            set;
        }
		CourseViewController viewController;

		public override bool FinishedLaunching(UIApplication app, NSDictionary options)
		{
			Window = new UIWindow(UIScreen.MainScreen.Bounds);

			viewController = new CourseViewController ();
			Window.RootViewController = viewController;

			Window.MakeKeyAndVisible ();

			return true;
		}
    }
}