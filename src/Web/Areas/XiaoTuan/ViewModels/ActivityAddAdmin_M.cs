using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using XiaoTuan.Entity;

namespace Web.Areas.XiaoTuan.ViewModels
{
    public class ActivityAddAdmin_M
    {
        //public string activity_id { get; set; }

        //public string org_id { get; set; }
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

        [Display(Name = "组织机构名称")]
        public string org_id { get; set; }

        public List<SelectListItem> orgSelect { get;  set; }

        public activity ToModel()
        {
            return new activity()
            {
                org_id= org_id,
                activity_name= activity_name,
                activity_time= activity_time,
                sign_end_time= sign_end_time,
                activity_detail= activity_detail,
                sign_notice= sign_notice,
                activity_place= activity_place,
                activity_photo= activity_photo
            };
        }
        public static ActivityAddAdmin_M ToViewModel(List<SelectListItem> orgSelect)
        {
            return new ActivityAddAdmin_M()
            {
                orgSelect= orgSelect
            };
        }
    }
}