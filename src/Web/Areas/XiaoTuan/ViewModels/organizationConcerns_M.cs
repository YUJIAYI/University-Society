using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using XiaoTuan.Entity;

namespace Web.Areas.XiaoTuan.ViewModels
{
    public class organizationConcerns_M
    {


        public static organizationConcerns_M ToViewModel(List<organizationalConcerns> organizationConcerns)
        {
            return new organizationConcerns_M()
            {
                organizationConcerns= organizationConcerns
            };
        }
        public List<organizationalConcerns> organizationConcerns { get;  set; }
    }      
}