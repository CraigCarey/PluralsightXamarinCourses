using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Support.V4.App;
using CoursesLibrary;
using Android.Support.V4.View;

namespace CoursesAndroid
{
    //[Activity(Label = "Courses", MainLauncher = true, Icon = "@drawable/icon")]
    [Activity(Label = "CourseActivity)")]
    public class CourseActivity : FragmentActivity
    {
        public const String DISPLAY_CATEGORY_TITLE_EXTRA = "DisplayCategoryTitleExtra";
        private const String DEFAULT_CATEGORY_TITLE = "Android";

        // Our custom data class
        CourseManager courseManager;

        // Attaches the courseManager to the fragments
        CoursePagerAdapter coursePagerAdapter;

        // Attaches the layout fragments to the fragments
        ViewPager viewPager;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // load the main layout
            SetContentView(Resource.Layout.CourseActivity);

            String displayCategoryTitle = DEFAULT_CATEGORY_TITLE;

            Intent startupIntent = this.Intent;

            if (startupIntent != null)
            {
                String displayCategoryTitleExtra = startupIntent.GetStringExtra(DISPLAY_CATEGORY_TITLE_EXTRA);

                if (displayCategoryTitleExtra != null)
                {
                    displayCategoryTitle = displayCategoryTitleExtra;
                }
            }

            // create courseManager and move to start of courseList
            courseManager = new CourseManager(displayCategoryTitle);
            courseManager.MoveFirst();

            // coursePagerAdapter is used to link together the fragments and the data
            // SupportFragmentManager is a member of FragmentActivity, and allows us to manage fragments
            coursePagerAdapter = new CoursePagerAdapter(SupportFragmentManager, courseManager);

            // Sets the layout for each fragment
            viewPager = FindViewById<ViewPager>(Resource.Id.coursePager);


            viewPager.Adapter = coursePagerAdapter;
        }
    }
}