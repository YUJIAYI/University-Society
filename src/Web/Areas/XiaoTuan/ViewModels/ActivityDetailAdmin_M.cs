using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using XiaoTuan.Entity;

namespace Web.Areas.XiaoTuan.ViewModels
{
    public class ActivityDetailAdmin_M

    {
       

        public static ActivityDetailAdmin_M ToViewModel(activity ActivityDetial)
        {
            return new ActivityDetailAdmin_M()
            {
                org_name= ActivityDetial.organization.org_name,
                activity_name = ActivityDetial.activity_name,
                activity_time= ActivityDetial.activity_time.Value.ToString("yyyy-MM-dd HH:mm"),
                sign_end_time = ActivityDetial.sign_end_time.Value.ToString("yyyy-MM-dd HH:mm"),
                activity_detail = ActivityDetial.activity_detail,
                sign_notice = ActivityDetial.sign_notice,
                activity_place = ActivityDetial.activity_place,
                activity_photo= ActivityDetial.activity_photo
            };
        }

        [Display(Name = "活动名称")]
        public string activity_name { get; set; }

        [Display(Name = "活动时间")]
        public string activity_time { get; set; }

        [Display(Name = "报名截止时间")]
        public string sign_end_time { get; set; }

        [Display(Name = "活动详情")]
        public string activity_detail { get; set; }

        [Display(Name = "报名须知")]
        public string sign_notice { get; set; }

        [Display(Name = "活动地点")]
        public string activity_place { get; set; }

        [Display(Name = "活动图片")]
        public string activity_photo { get; set; }

        [Display(Name = "组织名称")]
        public string org_name { get;  set; }
    }
}