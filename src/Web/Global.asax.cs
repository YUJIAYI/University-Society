using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Qx.Tools.CommonExtendMethods;
using Qx.Tools.Ioc.Unity;
using System;
using System.Web;
using Web.Controllers.Base;

namespace Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {

            UnityIoc.Register(typeof(Controller).GetSubClasses());
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
        protected void Application_Error(object sender, EventArgs e)
        {
           // if (Response.Headers.GetValues("Access-Control-Allow-Origin") == null)
           // {
           //     Response.Headers.Add("Access-Control-Allow-Origin", "*");
           // }
           // var ex = Server.GetLastError();
           //// var msg = ex.Message.Replace("\r\n", "");
      
           // Response.Write(new BaseController.FormUI() {code =(int)BaseController.State.Fail,jsonData = ex.Serialize(),msg = "请求失败",url=""}.Serialize());
           // Response.End();

            //if (msg.Length > 60)
            //{msg = msg.Substring(0, 60); }
            //Response.Redirect("/Home/Error?msg="+ msg);
        }
    }
}
