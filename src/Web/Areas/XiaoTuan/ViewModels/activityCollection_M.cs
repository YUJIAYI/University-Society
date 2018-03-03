using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using XiaoTuan.Entity;

namespace Web.Areas.XiaoTuan.ViewModels
{
    public class ActivityCollection_M
    {
       

        public static ActivityCollection_M ToViewModel(List<activityCollection> ActivityCollection)
        {
            return new ActivityCollection_M()
            {
                ActivityCollection = ActivityCollection
            };

        }
        public List<activityCollection> ActivityCollection { get;  set; }
    }
}