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
    [Activity(Label = "Courses", MainLauncher = true, Icon = "@drawable/icon")]
    public class CourseActivity : FragmentActivity
    {
        CourseManager courseManager;
        CoursePagerAdapter coursePagerAdapter;
        ViewPager viewPager;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // load the layout
            SetContentView(Resource.Layout.CourseActivity);

            // create courseManager and move to start of courseList
            courseManager = new CourseManager();
            courseManager.MoveFirst();

            // coursePagerAdapter is used to link together the fragments and the data
            // SupportFragmentManager is a member of FragmentActivity, and allows us to manage fragments
            coursePagerAdapter = new CoursePagerAdapter(SupportFragmentManager, courseManager);

            viewPager = FindViewById<ViewPager>(Resource.Id.coursePager);

            viewPager.Adapter = coursePagerAdapter;
        }
    }
}