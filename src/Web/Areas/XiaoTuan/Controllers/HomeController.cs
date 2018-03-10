using qx.permmision.v2.Interfaces;
using Qx.Tools;
using Qx.Tools.CommonExtendMethods;
using Qx.Tools.Exceptions.Form;
using Qx.Tools.Interfaces;
using System.Web.Mvc;
using Web.Areas.XiaoTuan.ViewModels;
using Web.Controllers.Base;
using XiaoTuan.Entity;
using XiaoTuan.Interfaces;
using XiaoTuan.Model;

namespace Web.Areas.XiaoTuan.Controllers
{
    public class HomeController : AccountFilterController// WxWebFilterController//
    {
        // GET: /XiaoTuan/Home/HomePage
        //public ActionResult Index()
        //{
        //    return View();

        //   // var a= DataContext.UserID;
        //}
        private IXiaoTuanService _IXiaoTuanService;
        private IRepository<activity> _activity;
        private IRepository<enroll> _enroll;
        private IRepository<student> _student;
        public HomeController(IXiaoTuanService IXiaoTuanService, IRepository<activity> activity, IRepository<enroll> enroll, IRepository<student> student)
        {
            _IXiaoTuanService = IXiaoTuanService;
            _activity = activity;
            _enroll = enroll;
            _student = student;
        }

        //----------------------------------------------用户界面---------------------------------------------------//

        //  XiaoTuan/Home/HomePage
        public ActionResult HomePage()
        {
            var activityData = _IXiaoTuanService.GetActivity("");
           // _IXiaoTuanService.AddUser(DataContext.UserID);
            return View(HomePage_M.ToViewModel(activityData));
        }


        //  XiaoTuan/Home/ActivityPage
        public ActionResult ActivityPage(string org_id)
        {
                var activityData = _IXiaoTuanService.GetActivity(org_id);
                var organizationData = _IXiaoTuanService.GetOrganization();
                return View(ActivityPage_M.ToViewModel(activityData, organizationData));
        }
        public ActionResult ActivityPageAjax(string org_id)
        {

                return Json(_IXiaoTuanService.SearchActivityOrg(org_id), JsonRequestBehavior.AllowGet);

        }
        public ActionResult ActivityPageAjaxSorting(string index)
        {
            return Json(_IXiaoTuanService.SearchActivitySorting(index), JsonRequestBehavior.AllowGet);

        }

        //  XiaoTuan/Home/EnrollPage
        public ActionResult EnrollPage(string index)
        {
            V("CurrentHost", GetHost(true));

            if (index.HasValue())
            {
                var userActivity = _IXiaoTuanService.GetUserActivity(DataContext.UserID, index);//报名状态实现
          
                return View(EnrollPage_M.ToViewModel(userActivity));
            }
            else
            {
                return Alert("参数请求错误");
            }
        }
        public ActionResult EnrollPageAjax(string index)
        {
            if (index.HasValue())
            {
               
                return Json(_IXiaoTuanService.GetUserActivityAjax(DataContext.UserID, index), JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Alert("参数请求错误");
            }

        }


        //  XiaoTuan/Home/AssessPage
        public ActionResult AssessPage(string orgFormId)
        {
            if (orgFormId.HasValue())
            {
                var ActivityAssess = _IXiaoTuanService.GetAssessPage(orgFormId);
                return View(AssessPage_M.ToViewModel(ActivityAssess));
            }
            else
            {
                return Alert("参数请求错误");
            }

        }

        [HttpPost]
        public ActionResult AssessPage(string orgFormId, string ActivityGrade, string AssessText,string piclist)
        {
            return Content((_IXiaoTuanService.ChangeAssessPage(orgFormId, ActivityGrade, AssessText, piclist,DataContext.UserID) ? true : false).ToString());
        }


        //  XiaoTuan/Home/AssessFinishedPage
        public ActionResult AssessFinishedPage(string activity_id)
        {
            if (activity_id.HasValue())
            {
                var AssessEnroll = _IXiaoTuanService.GetActivityEnrollDetial(activity_id);
                var ActivityDetial = _IXiaoTuanService.GetActivityDetial(activity_id);
                var ActivityPhoto = _IXiaoTuanService.GetActivityPhoto(activity_id);
                return View(AssessFinishedPage_M.ToViewModel(AssessEnroll, ActivityDetial, ActivityPhoto));
            }
            else
            {
                return Alert("参数请求错误");
            }

        }
        public ActionResult AssessState(string activity_id, string index)
        {

            if (activity_id.HasValue() && index.HasValue())
            {
                return Json(_IXiaoTuanService.AssessState(activity_id, index), JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Alert("参数请求错误");
            }

        }


        //  XiaoTuan/Home/StudentPage
        public ActionResult StudentPage()
        {
            var student = _IXiaoTuanService.GetStudent(DataContext.UserID);
            return View(StudentPage_M.ToViewModel(student));
        }


        //  XiaoTuan/Home/ActivityDetial
        public ActionResult ActivityDetial(string activity_id)
        {
            if (activity_id.HasValue())
            {
                var activityDetial = _IXiaoTuanService.GetActivityDetial(activity_id);
                var activityEnrollList = _IXiaoTuanService.GetActivityEnrollList(activity_id);
                return View(ActivityDetial_M.ToViewModel(activityDetial, activityEnrollList, DataContext.UserID));
            }
            else
            {
                return Alert("参数请求错误");
            }

        }


        //  XiaoTuan/Home/OrganizationDetial
        public ActionResult OrganizationDetial(string org_id)
        {
            if (org_id.HasValue())
            {
                var organizationDetial = _IXiaoTuanService.GetOrganizationDetial(org_id);
                var organizationActivity = _IXiaoTuanService.GetOrganizationActivity(org_id);
                return View(OrganizationDetial_M.ToViewModel(organizationDetial, organizationActivity, DataContext.UserID));
            }
            else
            {
                return Alert("参数请求错误");
            }

        }


        //  XiaoTuan/Home/PersonalInformation
        public ActionResult PersonalInformation()
        {
            var student = _IXiaoTuanService.GetStudent(DataContext.UserID);
            return View(PersonalInformation_M.ToViewModel(student));
        }


        //  XiaoTuan/Home/StudentIdentification
        public ActionResult StudentIdentification()
        {
            return View(StudentIdentification_M.ToViewModel(_IXiaoTuanService.GetStudent(DataContext.UserID)));
        }

        [HttpPost]
        public ActionResult StudentIdentification(string name, string cell_number, string sex, string birthday, string to_school_time, string school, string major, string grade, string card_number, string graduation_time)
        {
            return Content((_IXiaoTuanService.StudentIdentification(name, cell_number, sex, birthday, to_school_time, school, major, grade, card_number, graduation_time, DataContext.UserID) ? true : false).ToString());
        }


        //  XiaoTuan/Home/activityCollection
        public ActionResult ActivityCollection()
        {
            var activityCollection = _IXiaoTuanService.activityCollection(DataContext.UserID);
            return View(ActivityCollection_M.ToViewModel(activityCollection));
        }


        //  XiaoTuan/Home/organizationConcerns
        public ActionResult organizationConcerns()
        {
            var Concerns = _IXiaoTuanService.organizationConcerns(DataContext.UserID);
            return View(OrganizationConcerns_M.ToViewModel(Concerns));
        }


        //XiaoTuan/Home/ActivityPhoto
        public ActionResult ActivityPhoto(string activity_id)
        {
            var Photos = _IXiaoTuanService.GetActivityPhoto(activity_id);
            return View(ActivityPhoto_M.ToViewModel(Photos));
        }


        //XiaoTuan/Home/ActivityFootprint
        public ActionResult ActivityFootprint()
        {
            var Footprint = _IXiaoTuanService.GetFootprint(DataContext.UserID);
            return View(ActivityFootprint_M.ToViewModel(Footprint));
        }


        //  XiaoTuan/Home/AboutUs
        public ActionResult AboutUs()
        {
            return View();
        }


        //  XiaoTuan/Home/ActivityDeleteAdmin
        public ActionResult ActivityDeleteAdmin(string id)
        {
            if (id.HasValue())
            {
                if (!_IXiaoTuanService.FindActivityIsUser(id))
                {
                    return Alert(_activity.Delete(id) ? "删除成功" : "删除失败");
                }
                else
                {
                    return Alert("该活动已有用户报名，不能删除，如想删除，请先删除该活动的所有已报名人员");
                }
            }
            else
            {
                return Alert("参数请求错误");
            }

        }


        //  XiaoTuan/Home/ActivityDetailAdmin
        public ActionResult ActivityDetailAdmin(string id)
        {
            if (id.HasValue())
            {
                InitForm("活动详情", false);
                var ActivityDetial = _IXiaoTuanService.GetActivityDetial(id);
                return View(ActivityDetailAdmin_M.ToViewModel(ActivityDetial));
            }
            else
            {
                return Alert("参数请求错误");
            }

        }


        //  XiaoTuan/Home/ActivityEditAdmin
        public ActionResult ActivityEditAdmin(string id)
        {
            if (id.HasValue())
            {
                InitForm("编辑活动");
                var ActivityDetial = _IXiaoTuanService.GetActivityDetial(id);
                var orgSelect = _IXiaoTuanService.UserOrgList(DataContext.UserID);
                return View(ActivityEditAdmin_M.ToViewModel(ActivityDetial, orgSelect));
            }
            else
            {
                return Alert("参数请求错误");
            }
        }

        [HttpPost]
        public ActionResult ActivityEditAdmin(ActivityEditAdmin_M model,string photo)
        {
            try
            {
                model.activity_photo = photo;
                return _activity.Update(model.ToModel())
                    ? RedirectToAction("ActivityList", "Home", new { area = "XiaoTuan" })
                : Alert("编辑失败");
            }
            catch (FormValitationException ex)
            {
                FormValitation = ex;
                InitForm("编辑活动");
                var ActivityDetial = _IXiaoTuanService.GetActivityDetial(model.activity_id);
                var orgSelect = _IXiaoTuanService.UserOrgList(DataContext.UserID);
                return View(ActivityEditAdmin_M.ToViewModel(ActivityDetial, orgSelect));
            }
        }


        //  XiaoTuan/Home/ActivityAddAdmin
        public ActionResult ActivityAddAdmin()
        {
            InitForm("添加活动");
            var orgSelect = _IXiaoTuanService.UserOrgList(DataContext.UserID);
            return View(ActivityAddAdmin_M.ToViewModel(orgSelect));
        }

        [HttpPost]
        public ActionResult ActivityAddAdmin(ActivityAddAdmin_M model)
        {
            try
            {
                return _activity.Add(model.ToModel()).HasValue()
             ? RedirectToAction("ActivityList", "Home", new { area = "XiaoTuan" })
             : Alert("添加失败");
            }
            catch (FormValitationException ex)
            {
                FormValitation = ex;
                InitForm("添加活动");
                var orgSelect = _IXiaoTuanService.UserOrgList(DataContext.UserID);
                return View(ActivityAddAdmin_M.ToViewModel(orgSelect));
            }
        }


        //  XiaoTuan/Home/searchActivity
        public ActionResult searchActivity(string name)
        {
            return Json(_IXiaoTuanService.SearchActivity(name), JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        public ActionResult CancelEnroll(string org_form_id)
        {
            return Content((_IXiaoTuanService.CancelEnroll(org_form_id) ? true : false).ToString());
        }

        [HttpPost]
        public ActionResult addEnroll(string activity_id)
        {
            var uid = DataContext.UserID;
            return Content(_IXiaoTuanService.addEnroll(activity_id, uid).ToString());
        }

        [HttpPost]
        public ActionResult collection(string activity_id, int index)
        {
            if (index == 0)
            {
                return Content((_IXiaoTuanService.addCollection(activity_id, DataContext.UserID) ? true : false).ToString());
            }
            else
            {
                return Content((_IXiaoTuanService.removeCollection(activity_id, DataContext.UserID) ? true : false).ToString());
            }


        }

        [HttpPost]
        public ActionResult concerns(string org_id, int index)
        {
            if (index == 0)
            {
                return Content((_IXiaoTuanService.addConcerns(org_id, DataContext.UserID) ? true : false).ToString());
            }
            else
            {
                return Content((_IXiaoTuanService.removeConcerns(org_id, DataContext.UserID) ? true : false).ToString());
            }
        }


        //---------------------------------------------用户界面结束--------------------------------------------------//

        //----------------------------------------------管理员页面---------------------------------------------------//

        //XiaoTuan/Home/ActivityList
        public ActionResult ActivityList(string reportId, string Params)
        {
            if (!reportId.HasValue())
            {
                return RedirectToAction("ActivityList",
                    new
                    {
                        reportId = "XiaoTuan.RG4.RZH5DHUJPWD",
                        Params = ";;",
                        pageIndex = 1,
                        perCount = 10
                    });
            }

            Search.Add("活动名称");
            SetFixedParam(DataContext.UserID);
            InitReport("RZH5DHUJPWD", "/XiaoTuan/Home/ActivityAddAdmin", "", true, "XiaoTuan");
            return ReportView();
        }


        //XiaoTuan/Home/ActivityUserList
        public ActionResult ActivityUserList(string reportId, string Params)
        {
            if (!reportId.HasValue())
            {
                return RedirectToAction("ActivityUserList",
                    new
                    {
                        reportId = "XiaoTuan.活动用户",
                        Params = Params.IsFixedParam(),
                        pageIndex = 1,
                        perCount = 10
                    });
            }
            Search.Add("学生卡号");
            Search.Add("学生姓名");
            //  SetFixedParam(DataContext.UserID);
            InitReport("活动用户", "#", "", true, "XiaoTuan");
            return ReportView();
        }


        //  XiaoTuan/Home/DeleteActivityUser
        public ActionResult DeleteActivityUser(string org_form_id)
        {
            if (org_form_id.HasValue())
            {
                return Alert(_enroll.Delete(org_form_id) ? "删除成功" : "删除失败");
            }
            else
            {
                return Alert("参数请求错误");
            }

        }


        //XiaoTuan/Home/IdentfilyUserList
        public ActionResult IdentfilyUserList(string reportId, string Params)
        {
            if (!reportId.HasValue())
            {
                return RedirectToAction("IdentfilyUserList",
                    new
                    {
                        reportId = "XiaoTuan.认证用户",
                        Params = ";",
                        pageIndex = 1,
                        perCount = 10
                    });
            }
            Search.Add("状态", _IXiaoTuanService.statusSelect());
            Search.Add("学生姓名");
            //  SetFixedParam(DataContext.UserID);
            InitReport("认证用户", "#", "", true, "XiaoTuan");
            return ReportView();
        }


        //  XiaoTuan/Home/IdentfilyUser
        public ActionResult IdentfilyUser(string id)
        {
            if (id.HasValue())
            {
                InitForm("认证详情", false);
                var userdetail = _student.Find(id);
                return View(IdentfilyUser_M.ToViewModel(userdetail));
            }
            else
            {
                return Alert("参数请求错误");
            }
        }


        //  XiaoTuan/Home/PassIdentfily
        public ActionResult PassIdentfily(string id)
        {
            if (id.HasValue())
            {
                var data = _student.Find(id);
                data.state = 2;
                return _student.Update(data) ? RedirectToAction("IdentfilyUserList", "Home", new { area = "XiaoTuan" }) : Alert("认证失败");
            }
            else
            {
                return Alert("参数请求错误");
            }
        }


        //  XiaoTuan/Home/NoPassIdentfily
        public ActionResult NoPassIdentfily(string id)
        {
            if (id.HasValue())
            {
                var data = _student.Find(id);
                data.state = 3;
                return _student.Update(data) ? RedirectToAction("IdentfilyUserList", "Home", new { area = "XiaoTuan" }) : Alert("退回失败");
            }
            else
            {
                return Alert("参数请求错误");
            }
        }

        //  XiaoTuan/Home/ChangeStatus
        public ActionResult ChangeStatus(string org_form_id)
        {
            var flag = _IXiaoTuanService.ChangeStatus(org_form_id, DataContext.UserID);
            return View();
        }

    }
}