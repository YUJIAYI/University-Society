using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using qx.permmision.v2.Entity;
using qx.permmision.v2.Interfaces;
using Qx.Tools.CommonExtendMethods;
using Qx.Tools.Interfaces;
using Qx.WorkFlow.Interfaces;
using Web.Controllers.Base;

namespace Web.Controllers
{
    public class WorkFlowController :BaseController
    {
        private IWorkFlowService _workFlowService;
        private IRepository<user_role> _userRole;

        public WorkFlowController(IWorkFlowService workFlowService, IRepository<user_role> userRole)
        {
            _workFlowService = workFlowService;
            _userRole = userRole;
        }

        // 获取待办 GET: /WorkFlow/GetToDo?uid=
        public ActionResult GetToDo(string uid)
        { 
            return Json(State.Success, _workFlowService.GetToDo(uid, _userRole.All(a => a.user_id == uid).Select(b => b.role_id).ToList()),false);
        }
        // 激活实例 GET: /WorkFlow/Create?uid=1325112033&wfid=TEST-DAYOFF
        public ActionResult Create(string uid,string wfid)
        { 
            return Json(State.Success, _workFlowService.CreateInstance(wfid, uid).Instance);
        }
        // 移动节点  GET: /WorkFlow/MoveNext?uid=1325112033&wfid=TEST-DAYOFF&reason=同意
        public ActionResult MoveNext(string uid, string wfid,string reason)
        {
            var old = _workFlowService.FindInstance(wfid);
            return Json(State.Success, _workFlowService.MoveNext(old, new {}, uid, reason));
        }
    }
}