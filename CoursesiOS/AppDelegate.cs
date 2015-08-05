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
        //CoursePagerViewController viewController;

        public UINavigationController RootNavigationController
        {
            get;
            private set;
        }

		public override bool FinishedLaunching(UIApplication app, NSDictionary options)
		{
			Window = new UIWindow(UIScreen.MainScreen.Bounds);

            RootNavigationController = new UINavigationController();

            //viewController = new CoursePagerViewController ();
            var viewController = new CategoryViewController();

            RootNavigationController.PushViewController(viewController, false);

			Window.RootViewController = RootNavigationController;

			Window.MakeKeyAndVisible ();

			return true;
		}
    }
}