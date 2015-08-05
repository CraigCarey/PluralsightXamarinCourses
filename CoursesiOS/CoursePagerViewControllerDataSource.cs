using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;
using CoursesLibrary;

namespace CoursesiOS
{
    class CoursePagerViewControllerDataSource : UIPageViewControllerDataSource
    {
        public CoursePagerViewControllerDataSource(CourseManager courseManager)
        {
            this.courseManager = courseManager;
        }

        CourseManager courseManager;

        public CourseViewController GetFirstViewController()
        {
            courseManager.MoveFirst();

            return CreateCourseViewController();

        }

        public override UIViewController GetNextViewController(UIPageViewController pageViewController, UIViewController referenceViewController)
        {
            CourseViewController returnCourseViewController = null;

            CourseViewController referenceCourseViewController = referenceViewController as CourseViewController;

            if (referenceCourseViewController != null)
            {
                courseManager.MoveTo(referenceCourseViewController.CoursePosition);
                if (courseManager.CanMoveNext)
                {
                    courseManager.MoveNext();

                    // create a CourseViewController at wahatever course is at that position
                    returnCourseViewController = CreateCourseViewController();
                }
            }

            return returnCourseViewController;
        }

        public override UIViewController GetPreviousViewController(UIPageViewController pageViewController, UIViewController referenceViewController)
        {
            CourseViewController returnCourseViewController = null;

            CourseViewController referenceCourseViewController = referenceViewController as CourseViewController;

            if (referenceCourseViewController != null)
            {
                courseManager.MoveTo(referenceCourseViewController.CoursePosition);
                if (courseManager.CanMovePrev)
                {
                    courseManager.MovePrev();

                    // create a CourseViewController at wahatever course is at that position
                    returnCourseViewController = CreateCourseViewController();
                }
            }

            return returnCourseViewController;
        }

        CourseViewController CreateCourseViewController()
        {
            CourseViewController courseViewController = new CourseViewController();
            courseViewController.Course = courseManager.Current;
            courseViewController.CoursePosition = courseManager.CurrentPosition;

            return courseViewController;
        }

    }
}