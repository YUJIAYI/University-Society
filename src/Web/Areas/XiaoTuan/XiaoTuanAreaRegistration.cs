using System.Web.Mvc;

namespace Web.Areas.XiaoTuan
{
    public class XiaoTuanAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "XiaoTuan";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "XiaoTuan_default",
                "XiaoTuan/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}