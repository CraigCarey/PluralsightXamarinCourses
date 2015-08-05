using System;
using System.Drawing;

using CoreFoundation;
using UIKit;
using Foundation;

namespace CoursesiOS
{

    [Register("CoursePagerViewController")]
    public class CoursePagerViewController : UIViewController
    {
        UIPageViewController pageViewController;

        public CoursePagerViewController()
        {
        }

        public override void DidReceiveMemoryWarning()
        {
            // Releases the view if it doesn't have a superview.
            base.DidReceiveMemoryWarning();

            // Release any cached data, images, etc that aren't in use.
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            // create a UIPageViewController that scrolls horizontally
            pageViewController = new UIPageViewController(UIPageViewControllerTransitionStyle.Scroll, UIPageViewControllerNavigationOrientation.Horizontal);

            // size the view controller so it fills the containing View (context is this.View.Bounds)
            pageViewController.View.Frame = View.Bounds;

            // place the pageViewController inside the UIViewController
            View.AddSubview(pageViewController.View);
        }
    }
}