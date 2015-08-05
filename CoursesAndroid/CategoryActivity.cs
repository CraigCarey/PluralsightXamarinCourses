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
using CoursesLibrary;

namespace CoursesAndroid
{
    // This is the Activity that is loaded on app launch
    [Activity(Label = "Courses", MainLauncher = true, Icon = "@drawable/icon")]
    public class CategoryActivity : ListActivity
    {
        CourseCategoryManager coursecategoryManager;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            //String[] categoryTitles = { "Cat1", "Cat2", "Cat3" };

            //// used to associate the datasource with this activity
            //ListAdapter = new ArrayAdapter<String>(this, Android.Resource.Layout.SimpleListItem1, categoryTitles);

            coursecategoryManager = new CourseCategoryManager();

            ListAdapter = new CourseCategoryManagerAdapter(this, Android.Resource.Layout.SimpleListItem1, coursecategoryManager);
        }

        protected override void OnListItemClick(ListView l, View v, int position, long id)
        {
            Intent intent = new Intent(this, typeof(CourseActivity));

            coursecategoryManager.MoveTo(position);

            String categoryTitle = coursecategoryManager.Current.Title;

            intent.PutExtra(CourseActivity.DISPLAY_CATEGORY_TITLE_EXTRA, categoryTitle);

            StartActivity(intent);
        }
    }
}