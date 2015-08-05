using System;
using System.Drawing;

using CoreFoundation;
using UIKit;
using Foundation;
using CoursesLibrary;

namespace CoursesiOS
{

    [Register("CoursePagerViewController")]
    public class CoursePagerViewController : UIViewController
    {
        UIPageViewController pageViewController;
        CourseManager courseManager;

        public CoursePagerViewController()
        {
        }

        public override void DidReceiveMemoryWarning()
        {
            // Releases the view if it doesn't have a superview.
            base.DidReceiveMemoryWarning();
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            // create a UIPageViewController that pages horizontally (min puts the spine on the left
            pageViewController = new UIPageViewController(UIPageViewControllerTransitionStyle.PageCurl, UIPageViewControllerNavigationOrientation.Horizontal, UIPageViewControllerSpineLocation.Min);

            // size the view controller so it fills the containing View (context is this.View.Bounds)
            pageViewController.View.Frame = View.Bounds;

            // place the pageViewController inside the UIViewController
            View.AddSubview(pageViewController.View);

            courseManager = new CourseManager();
            courseManager.MoveFirst();

            CoursePagerViewControllerDataSource dataSource = new CoursePagerViewControllerDataSource(courseManager);
            pageViewController.DataSource = dataSource;

            // Create an instance of the CourseViewController for the current course of the CourseManager
            CourseViewController firstCourseViewController = dataSource.GetFirstViewController();

            pageViewController.SetViewControllers(new UIViewController[] { firstCourseViewController }, UIPageViewControllerNavigationDirection.Forward, false, null);

            // assign delegate methods
            //pageViewController.GetNextViewController = GetNextViewController;
            //pageViewController.GetPreviousViewController = GetPreviousViewController;
        }

        //CourseViewController CreateCourseViewController()
        //{
        //    CourseViewController courseViewController = new CourseViewController();
        //    courseViewController.Course = courseManager.Current;
        //    courseViewController.CoursePosition = courseManager.CurrentPosition;

        //    return courseViewController;
        //}

        //// delegate
        //// pageViewController is the ViewController that is firing the delegate
        //// referenceViewController is the currently displayed ViewController
        //public UIViewController GetNextViewController(UIPageViewController pageViewController, UIViewController referenceViewController)
        //{
        //    CourseViewController returnCourseViewController = null;

        //    CourseViewController referenceCourseViewController = referenceViewController as CourseViewController;

        //    if (referenceCourseViewController != null)
        //    {
        //        courseManager.MoveTo(referenceCourseViewController.CoursePosition);
        //        if(courseManager.CanMoveNext)
        //        {
        //            courseManager.MoveNext();

        //            // create a CourseViewController at wahatever course is at that position
        //            returnCourseViewController = CreateCourseViewController();
        //        }
        //    }

        //    return returnCourseViewController;
        //}

        //public UIViewController GetPreviousViewController(UIPageViewController pageViewController, UIViewController referenceViewController)
        //{
        //    CourseViewController returnCourseViewController = null;

        //    CourseViewController referenceCourseViewController = referenceViewController as CourseViewController;

        //    if (referenceCourseViewController != null)
        //    {
        //        courseManager.MoveTo(referenceCourseViewController.CoursePosition);
        //        if (courseManager.CanMovePrev)
        //        {
        //            courseManager.MovePrev();

        //            // create a CourseViewController at wahatever course is at that position
        //            returnCourseViewController = CreateCourseViewController();
        //        }
        //    }

        //    return returnCourseViewController;
        //}

    }
}