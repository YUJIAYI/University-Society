using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using XiaoTuan.Entity;

namespace Web.Areas.XiaoTuan.ViewModels
{
    public class OrganizationConcerns_M
    {


        public static OrganizationConcerns_M ToViewModel(List<organizationalConcerns> organizationConcerns)
        {
            return new OrganizationConcerns_M()
            {
                organizationConcerns= organizationConcerns,
                organizationConcernsNum = organizationConcerns.Count
            };
        }
        public List<organizationalConcerns> organizationConcerns { get;  set; }
        public int organizationConcernsNum { get;  set; }
    }      
}