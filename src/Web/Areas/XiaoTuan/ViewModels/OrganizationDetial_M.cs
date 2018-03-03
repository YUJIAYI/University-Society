using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using XiaoTuan.Entity;

namespace Web.Areas.XiaoTuan.ViewModels
{
    public class OrganizationDetial_M
    {
     

        public static OrganizationDetial_M ToViewModel(organization organizationDetial,List<activity> organizationActivity,string uid)
        {
            return new OrganizationDetial_M()
            {
                userName= organizationDetial.orgMember.FirstOrDefault().student.name,
                organizationDetial = organizationDetial,
                organizationBeginTime = organizationDetial.establish_time.Value.ToString("yyyy-MM-dd"),
                organizationActivity = organizationActivity,
                activityWaiting = organizationActivity.Where(o => o.activity_time > DateTime.Now).ToList(),
                activityFinished = organizationActivity.Where(o => o.activity_time <= DateTime.Now).ToList(),
                concernsState = organizationDetial.organizationalConcerns.Count(o => o.org_id == organizationDetial.org_id && o.userid == uid) > 0 ? 1 : 0

            };
        }
        public organization organizationDetial { get;  set; }
        public string organizationBeginTime { get;  set; }
        public List<activity> organizationActivity { get;  set; }
        public List<activity> activityWaiting { get;  set; }
        public List<activity> activityFinished { get;  set; }
        public string userName { get;  set; }
        public int concernsState { get;  set; }
    }
}