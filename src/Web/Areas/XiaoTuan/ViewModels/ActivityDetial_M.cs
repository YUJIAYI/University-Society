using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using XiaoTuan.Entity;

namespace Web.Areas.XiaoTuan.ViewModels
{
    public class ActivityDetial_M
    {
        // GET: XiaoTuan/ActivityDetial_M
        public static ActivityDetial_M ToViewModel(activity activityDetial, List<enroll> activityEnrollList, string uid)
        {
            return new ActivityDetial_M()
            {
                activityDetial = activityDetial,
                activityTime = activityDetial.activity_time.Value.ToString("yyyy-MM-dd HH:mm"),
                endTime = activityDetial.sign_end_time.Value.ToString("yyyy-MM-dd HH:mm"),
                activityEnrollNum = activityEnrollList.Count(),
                stateOne = activityDetial.sign_end_time > DateTime.Now ? 0 : 1,
                stateTwo = activityDetial.activity_time > DateTime.Now ? 0 : 1,
                collectionState = activityDetial.activityCollection.Count(o => o.activity_id == activityDetial.activity_id && o.userid == uid) >0 ? 1 : 0
                
            };
        }

        public ActivityDetial_M ToModel()
        {
            return new ActivityDetial_M()
            {

            };
        }

        public activity activityDetial { get; set; }
        public string activityTime { get;  set; }
        public string endTime { get;  set; }
        public int activityEnrollNum { get;  set; }
        public int stateOne { get;  set; }
        public int stateTwo { get; set; }
        public int collectionState { get;  set; }

    }
}