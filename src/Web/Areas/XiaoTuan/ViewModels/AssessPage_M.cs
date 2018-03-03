using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using XiaoTuan.Entity;

namespace Web.Areas.XiaoTuan.ViewModels
{
    public class AssessPage_M
    {
       

        public static AssessPage_M ToViewModel(enroll ActivityAssess)
        {
            return new AssessPage_M()
            {
                ActivityAssess= ActivityAssess
            };
        }
        public enroll ActivityAssess { get; set; }
    }
}