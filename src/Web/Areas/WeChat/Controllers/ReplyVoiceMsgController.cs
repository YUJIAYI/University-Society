﻿using System;
using System.Web.Mvc;
using Qx.Tools.CommonExtendMethods;
using Qx.Tools.Interfaces;
using Web.Controllers.Base;
using Qx.Wechat.Entity;
using Web.Areas.WeChat.ViewModels;

namespace Web.Areas.WeChat.Controllers
{
    public class ReplyVoiceMsgController : BaseWeChatController, ICrud<ReplyVoiceMsg_M>
    {
        // TODO: 把<string> 更换为数据库model类型如 <Car>
        private IRepository<ReplyVoiceMsg> _repository;

        public ReplyVoiceMsgController(IRepository<ReplyVoiceMsg> repository)
        {
            _repository = repository;
        }

        public ActionResult Index(string reportId, string Params, int pageIndex=1 , int perCount=10 )
        {
            if (!reportId.HasValue())
            {

                return RedirectToAction("Index", new { reportId = "Qx.WeChat.回复语音消息", Params = ";", pageIndex = 1, perCount = 10 });
            }
            InitReport("回复语音消息", "/WeChat/ReplyVoiceMsg/Create");
            return View();
        }

        // GET: Area/Controller/Create
        public ActionResult Create()
        {
            InitForm("添加回复语音消息");
            return View(ReplyVoiceMsg_M.ToViewModel());
        }

        // POST: Area/Controller/Create
        [HttpPost]
        public ActionResult Create(ReplyVoiceMsg_M viewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    viewModel.ReplyMsgId = DateTime.Now.Random().ToString();
                    _repository.Add(viewModel.ToModel());
                    // TODO: 这里编写添加逻辑
                    return RedirectToAction("Index");
                }
                else
                {
                    InitForm("添加回复语音消息");
                    return View(viewModel);
                }

            }
            catch (Exception ex)
            {
                return Alert("请联系开发人员\n" + ex.Message);
            }
        }

        // GET: Area/Controller/Edit/5
        public ActionResult Edit(string id)
        {
            InitForm("编辑回复语音消息");
            var replyvoice = _repository.Find(id);
            if(replyvoice != null)
            {
                return View(ReplyVoiceMsg_M.ToViewModel(replyvoice));
            }
            else
            {
                return Alert("操作失败!");
            }
        }

        // POST: Area/Controller/Edit/5
        [HttpPost]
        public ActionResult Edit(ReplyVoiceMsg_M viewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _repository.Update(viewModel.ToModel());
                    // TODO: 这里编写更新逻辑
                    return RedirectToAction("Index");
                }
                else
                {
                    InitForm("编辑回复语音消息");
                    return View(viewModel);
                }

            }
            catch (Exception ex)
            {
                return Alert("请联系开发人员\n" + ex.Message);
            }
        }

        // GET: Area/Controller/Delete/5
        public ActionResult Delete(string id)
        {
            if(id.HasValue())
            {
                _repository.Delete(id);
                return Alert("操作成功!");
            }
            // TODO: 这里编写删除逻辑
            else
            {
                return Alert("操作失败!");
            }
        }

        // GET: Area/Controller/Details/5
        public ActionResult Details(string id)
        {
            InitForm("这里填写标题");
            // TODO: 这里编写详情逻辑
            return View();
        }

    }
}