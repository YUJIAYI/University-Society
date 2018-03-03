using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using XiaoTuan.Entity;

namespace Web.Areas.XiaoTuan.ViewModels
{
    public class ActivityPage_M
    {
        // GET: XiaoTuan/ActivityPage_M
        public static ActivityPage_M ToViewModel( List<activity> activityData, List<organization> organizationData)
        {
            return new ActivityPage_M()
            {

                activityData = activityData,
                organizationData= organizationData
            };
        }

        public ActivityPage_M ToModel()
        {
            return new ActivityPage_M()
            {

            };
        }
      
        public List<activity> activityData { get; set; }
        public List<organization> organizationData { get; set; }

    }
}