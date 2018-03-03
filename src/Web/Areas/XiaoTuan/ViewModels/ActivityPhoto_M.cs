using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using XiaoTuan.Entity;

namespace Web.Areas.XiaoTuan.ViewModels
{
    public class ActivityPhoto_M
    {
     

        public static ActivityPhoto_M ToViewModel(List<photo> Photos)
        {
            return new ActivityPhoto_M()
            {
                Photos= Photos
            };
        }
        public List<photo> Photos { get;  set; }
    }
}