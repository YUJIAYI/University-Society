using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using XiaoTuan.Entity;

namespace Web.Areas.XiaoTuan.ViewModels
{
    public class ActivityFootprint_M
    {
       

        public static ActivityFootprint_M ToViewModel(List<enroll> Footprint)
        {
            return new ActivityFootprint_M()
            {
               Footprint= Footprint
            };
        }
        public List<enroll> Footprint { get;  set; }
    }
}