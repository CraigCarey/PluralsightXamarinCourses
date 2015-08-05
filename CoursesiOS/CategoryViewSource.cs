using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;
using CoursesLibrary;

namespace CoursesiOS
{
    class CategoryViewSource : UITableViewSource
    {
        CourseCategoryManager courseCategoryManager;
        const String cellId = "CategoryCell";

        public CategoryViewSource(CourseCategoryManager courseCategoryManager)
        {
            this.courseCategoryManager = courseCategoryManager;
        }

        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            // reuse a cell if available, create one if not
            UITableViewCell cell = tableView.DequeueReusableCell(cellId);

            if (cell == null)
            {
                cell = new UITableViewCell(UITableViewCellStyle.Default, cellId);
            }

            courseCategoryManager.MoveTo(indexPath.Row);
            cell.TextLabel.Text = courseCategoryManager.Current.Title;

            return cell;
        }

        public override nint RowsInSection(UITableView tableview, nint section)
        {
           return courseCategoryManager.Length;
        }

        public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
        {
            courseCategoryManager.MoveTo(indexPath.Row);

            CoursePagerViewController coursePagerViewController = new CoursePagerViewController(courseCategoryManager.Current.Title);

            // gives you access to the only Application object inside the application
            AppDelegate appdelegate = UIApplication.SharedApplication.Delegate as AppDelegate;

            appdelegate.RootNavigationController.PushViewController(coursePagerViewController, true);
        }
    }
}