using System;
using System.Drawing;

using CoreFoundation;
using UIKit;
using Foundation;
using CoursesLibrary;

namespace CoursesiOS
{
    [Register("CategoryViewController")]
    public class CategoryViewController : UITableViewController
    {

        CourseCategoryManager courseCategoryManager;

        public CategoryViewController()
        {
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            courseCategoryManager = new CourseCategoryManager();

            this.Title = "Categories";

            // get a reference to the tableView we're controlling
            UITableView tableView = this.View as UITableView;
            tableView.Source = new CategoryViewSource(courseCategoryManager);
        }
    }
}