using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using XiaoTuan.Entity;

namespace Web.Areas.XiaoTuan.ViewModels
{
    public class AssessFinishedPage_M
    {
       

        public static AssessFinishedPage_M ToViewModel(List<enroll> AssessEnroll, activity ActivityDetial,List<photo> ActivityPhoto)
        {
            return new AssessFinishedPage_M()
            {
                AssessEnroll = AssessEnroll,
                ActivityDetial = ActivityDetial,
                ActivityTime =Convert.ToDateTime(ActivityDetial.activity_time).ToString("yyyy-MM-dd"),
                AssessAverage= Convert.ToDouble(AssessEnroll.Average(b => b.to_activity_evalute)),
                ActivityPhoto= ActivityPhoto,
                ActivityPhotoNum= ActivityPhoto.Count
            };
        }
        public List<enroll> AssessEnroll { get; set; }
        public activity ActivityDetial { get;  set; }
        public string ActivityTime { get;  set; }
        public double AssessAverage { get;  set; }
        public List<photo> ActivityPhoto { get;  set; }
        public int ActivityPhotoNum { get;  set; }
    }
}