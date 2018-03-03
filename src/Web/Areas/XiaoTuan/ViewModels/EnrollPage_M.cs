using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using XiaoTuan.Entity;

namespace Web.Areas.XiaoTuan.ViewModels
{
    public class EnrollPage_M
    {
        // GET: XiaoTuan/EnrollPage_M
        public static EnrollPage_M ToViewModel(List<enroll> userActivity)
        {
            return new EnrollPage_M()
            {
                userActivityNum = userActivity.Count,
                userActivityFail = userActivity.Where(o => o.state == -1).ToList(),
                userActivitySuccessed = userActivity.Where(o => o.state == 0).ToList(),
                userActivityFinished = userActivity.Where(o => o.state == 2).ToList(),
                userActivityAssessFinished = userActivity.Where(o => o.state == 3).ToList()
            };
        }

        public EnrollPage_M ToModel()
        {
            return new EnrollPage_M()
            {

            };
        }

        public List<enroll> userActivitySuccessed { get; set; }
        public List<enroll> userActivityFinished { get; set; }
        public List<enroll> userActivityAssessFinished { get; set; }
        public List<enroll> userActivityFail { get; set; }
        public int userActivityNum { get;  set; }
    }
}