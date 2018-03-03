using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using XiaoTuan.Entity;

namespace Web.Areas.XiaoTuan.ViewModels
{
    public class ActivityEditAdmin_M
    {
        public static ActivityEditAdmin_M ToViewModel(activity ActivityDetial, List<SelectListItem> orgSelect)
        {
            return new ActivityEditAdmin_M()
            {
                orgSelect= orgSelect,
                org_id= ActivityDetial.org_id,
                activity_id= ActivityDetial.activity_id,
                activity_name = ActivityDetial.activity_name,
                activity_time = ActivityDetial.activity_time,
                sign_end_time = ActivityDetial.sign_end_time,
                activity_detail = ActivityDetial.activity_detail,
                sign_notice = ActivityDetial.sign_notice,
                activity_place = ActivityDetial.activity_place,
                activity_photo= ActivityDetial.activity_photo
            };
        }
        public activity ToModel()
        {
            return new activity()
            {
                activity_id = activity_id,
                org_id = org_id,
                activity_name = activity_name,
                activity_time = activity_time,
                sign_end_time = sign_end_time,
                activity_detail = activity_detail,
                sign_notice = sign_notice,
                activity_place = activity_place,
                activity_photo = activity_photo
            };
        }

        [Display(Name = "活动名称")]
        public string activity_name { get; set; }

        [Display(Name = "活动时间")]
        public DateTime? activity_time { get; set; }

        [Display(Name = "报名截止时间")]
        public DateTime? sign_end_time { get; set; }

        [Display(Name = "活动详情")]
        public string activity_detail { get; set; }

        [Display(Name = "报名须知")]
        public string sign_notice { get; set; }

        [Display(Name = "活动地点")]
        public string activity_place { get; set; }

        public string activity_photo { get; set; }
        public List<SelectListItem> orgSelect { get;  set; }

        [Display(Name = "组织名称")]
        public string org_id { get;  set; }
        public string activity_id { get;  set; }
    }
}