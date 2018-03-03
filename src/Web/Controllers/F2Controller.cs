using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
//using app.focus.Entity;
//using app.focus.Interfaces;
using Qx.Tools.CommonExtendMethods;
using Web.Controllers.Base;
using HtmlAgilityPack;
using qx.permmision.v2.Interfaces;
using Qx.Tools;
using Qx.Tools.QxClass;
using Web.ViewModels;
//using Regist_M = Web.Areas.Wb.Models.Regist_M;
//using app.focus.Entity;
//using ecampus.yxxt.Interfaces;


namespace Web.Controllers
{
    public class F2Controller : BaseController
    {
        private IPermissionProvider _permissionProvider;
      //  private IFocusService _focusService;
       // private IYxxtService _yxxtService;
 

    //    private MyDbContext Db
    //{
    //    get { return _focusService.GetDb(); }
    //}

    public F2Controller(IPermissionProvider permissionProvider/*, IFocusService focusService, IYxxtService yxxtService*/)
        {
            _permissionProvider = permissionProvider;
           // _focusService = focusService;
     //   _yxxtService = yxxtService;
        }

        // GET: F2
        // GET: /<controller>/
        //  /F2/Grap?dist_url=/emap/sys/panda/*default/index.do#/jgb
        public ActionResult Grap(string dist_url)
        {
            
            var html = "Failed To Connect To" + dist_url;
            //抓取页面
            if (dist_url.HasValue())
            {
                var author_host = "http://148u548o08.imwork.net:31796";
                var author_url = "/emap/sys/emapAuth/debug/login.do?back=%2Femap%2Fsys%2Fpanda%2F*default%2Findex.do";
                dist_url = "/emap/sys/panda/*default/index.do#/jgb";
                var client= new HttpClient(new Uri(author_host));
                client.CookieContainer = new System.Net.CookieContainer();
                //身份认证
                html = client.Post(author_url, new Dictionary<string, string>()
                {
                    {"userId","admin" },
                    {"role","" }
                });
                html = client.Get(dist_url);
                //ar doc = new HtmlDocument();
                //oc.LoadHtml(html);
                //ar nodes = doc.DocumentNode.ChildNodes.ToList();
            }
            V("html", html);
            return View();
        }
        public ActionResult blank()
        {
            return View();
        }
        public ActionResult buttons()
        {
            return View();
        }
        public ActionResult flot()
        {
            return View();
        }
        public ActionResult forms()
        {
            return View();
        }
        public ActionResult grid()
        {
            return View();
        }
        public ActionResult icons()
        {
            return View();
        }
        public ActionResult index()
        {
            if (!DataContext.UserID.HasValue())
            {
                return RedirectToAction("Login");}
            V("uid", Session["user"]);
            return View();
        }
        public ActionResult welcome()
        {
            return View();
        }
        //#region api
        //// HttpPost: F2/LoginApi
        //[HttpPost]
        //public ActionResult LoginApi(string uid, string psw)
        //{
        //    var code = 0;

        //    if (uid.HasValue() && psw.HasValue() &&
        //      _focusService.HasUser(uid, psw))
        //    {
        //        code = 1;
        //    }

        //    return new Areas.Wb.Models.Login_M()
        //    {
        //        code = code
        //    }.ToResult();

        //}
        //// HttpPost: F2/RegistApi
        //[HttpPost]
        //public ActionResult RegistApi(string uid, string psw)
        //{
        //    var code = 0;
        //    if (uid.HasValue() && psw.HasValue() &&
        //        _focusService.UpdateUser(uid, psw))
        //    {
        //        code = 1;
        //    }

        //    return new Regist_M()
        //    {
        //        code = code
        //    }.ToResult();

        //}
        //// HttpPost: F2/AutoDownLoadHomeWork
        //[HttpPost]
        //public ActionResult AutoDownLoadHomeWork(string uid)
        //{
        //    var code = 0;
        //    try
        //    {
        //        Db.user_homework.AddOrUpdate(new user_homework()
        //        {
        //            user_homework_id = uid +"-"+ "1",
        //            create_time = DateTime.Now,
        //            user_id = uid,
        //            homework_id = "1"
        //        });
        //        Db.user_homework.AddOrUpdate(new user_homework()
        //        {
        //            user_homework_id = uid + "-" + "2",
        //            create_time = DateTime.Now,
        //            user_id = uid,
        //            homework_id = "2"
        //        });

        //        if (Db.SaveChanges() > 0)
        //        {
        //            code = 1;
        //        }
        //    }
        //    catch (Exception ex)
        //    {

        //    }
        //    return new Areas.Wb.Models.Login_M()
        //    {
        //        code = code
        //    }.ToResult();
        //}
        //#endregion
        public ActionResult notlogin(string uid)
        {
            //if (uid.HasValue())
            //{
            //    return Redirect("/Wb/Mode/index");}
            InitFrLayout("请注册成为会员");
            return View();
        }
        public ActionResult login()
        {
            if (DataContext.UserID.HasValue())
            {
                return RedirectToAction("index");
            }
            return View(new Login_M()
            {
                UserId = "1325112032",
              //  _anouncement = _yxxtService.GetAnouncements(12)
            });
        }
        #region Login Logic
        [HttpPost]
        public ActionResult login(Login_M model)
        {
            model.UserId = F("UserId");
            model.UserPsw = F("UserPsw");

            if (model.UserId.HasValue()&&ModelState.IsValid)
            {
                var user = _permissionProvider.UserInfo(model.UserId);
                // if (_permissionProvider.Login(model.UserId, model.UserPsw))
                if (user != null)
                {
                    Session["user"] = user.nick_name;
                    return LoginOk(model.UserId, "");
                }
                else
                {
                    return Alert("用户名或密码错误！", -1);
                }
            }
            else
            {
                return View(model);
            }
     
        }
        // GET: /Account/LoginOk?uid=panda&return_url=http://52xyj.cn&msg=测试
        public ActionResult LoginOk(string uid, string return_url, string msg = "", string uName = "未设置")
        {
            var accountContext = new AccountContext();
            DataContext.UserID =
                accountContext.UserID = uid;
            DataContext.UserName =
             accountContext.UserName = uName;
            Session["AccountContext"] = accountContext;
            if (return_url.HasValue())
            {
                return Redirect(return_url);
            }
            else if (ReturnUrl.HasValue() && ReturnUrl != "/" && !return_url.ToLower().Contains("login"))
            {
                return Redirect(ReturnUrl);
            }
            else
            {
                return RedirectToAction("Index", new {msg = "用户[" + uid + "]登录成功!"});
            }
        }
        public ActionResult LoginOut()
        {
            //退出登录前准备工作
            Session.Clear();
            if (Session["AccountContext"] != null)
            {
                Session.Remove("AccountContext");
            }
            return RedirectToAction("Login", new { msg = "退出登录成功!" });
        }
        #endregion
        public ActionResult morris()
        {
            return View();
        }
        public ActionResult notifications()
        {
            return View();
        }
        public ActionResult panelsWells()
        {
            return View();
        }
        public ActionResult tables()
        {
            return View();
        }
        public ActionResult typography()
        {
            return View();
        }
        public ActionResult layer()
        {
            return View();
        }
        
    }
}