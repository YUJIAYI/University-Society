using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using XiaoTuan.Entity;

namespace Web.Areas.XiaoTuan.ViewModels
{
    public class HomePage_M
    {
        public static HomePage_M ToViewModel(List<activity> activityData)
        {
            return new HomePage_M()
            {
                activityData = activityData
            };
        }

        public HomePage_M ToModel()
        {
            return new HomePage_M()
            {

            };
        }

        public List<activity> activityData { get; set; }
       
    }
}