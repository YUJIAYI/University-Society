using qx.permmision.v2.Interfaces;
using Qx.Tools.CommonExtendMethods;
using System;
using System.Collections.Generic;
using System.Linq;
using XiaoTuan.Entity;
using XiaoTuan.Interfaces;
using XiaoTuan.Service.Model;
using XiaoTuan.Model;
using System.Data.Entity.SqlServer;
using System.Web.Mvc;

namespace XiaoTuan.Service
{
    public class XiaoTuanService : BaseRepository, IXiaoTuanService
    {

        private IPermissionProvider _IPermissionProvider;

        public XiaoTuanService(IPermissionProvider IPermissionProvider)
        {
            _IPermissionProvider = IPermissionProvider;
        }

        //用户认证状态搜索框
        public List<SelectListItem> statusSelect()
        {
            return new List<SelectListItem>() {
                 new SelectListItem() {Text="未认证",Value="0" },
                  new SelectListItem() {Text="待审核",Value="1" },
                   new SelectListItem() {Text="已认证",Value="2" },
                    new SelectListItem() {Text="退回",Value="3" },
            };
        }

        //查看该活动有没有人报名
        public bool FindActivityIsUser(string activityid)
        {
            var data = Db.enroll.Where(o => o.activity_id == activityid).ToList();
            return data.Count > 0 ? true : false;
        }

        //负责人的组织机构
        public List<SelectListItem> UserOrgList(string uid)
        {
            return Db.organization.Where(o => o.user_id == uid).Select(b => new SelectListItem()
            {
                Text = b.org_name,
                Value = b.org_id
            }).ToList();
        }

        //二维码签到改变活动状态
        public bool ChangeStatus(string org_form_id, string uid)
        {
                var old = Db.enroll.FirstOrDefault(x => x.org_form_id == org_form_id && x.state == 0 && x.student.userid==uid);
                old.state = 2;//已参加
                Db.SaveModified(old);
                return Db.Saved() ? true : false;
        }

        //一个新账号登陆在学生表增加一条
        public bool AddUser(string uid,string img)
        {
            var data = _IPermissionProvider.UserInfo(uid);
            var record = Db.student.NoTrackingFind(o => o.userid == uid);
            if (record == null)
            {
                Db.student.Add(new student()
                {
                    userid = uid,
                    state = 0,
                    cell_number = data.phone,
                    name = data.nick_name,
                    photo = img.HasValue()?img: "/Areas/XiaoTuan/Contents/img/head/head.png"
                });
                return Db.Saved() ? true : false;
            }
            return true;

        }

        public bool FindUser(string uid)
        {
            var record = Db.student.NoTrackingFind(o => o.userid == uid);
            return record != null;
        }

        //进行学生认证
        public bool StudentIdentification(string name, string cell_number, string sex, string birthday, string to_school_time, string school, string major, string grade, string card_number, string graduation_time, string uid)
        {
            var data = Db.student.NoTrackingFind(o => o.userid == uid);
            data.name = name;
            data.cell_number = cell_number;
            data.sex = sex;
            data.birthday = Convert.ToDateTime(birthday);
            data.to_school_time = Convert.ToDateTime(to_school_time);
            data.school = school;
            data.major = major;
            data.grade = grade;
            data.card_number = card_number;
            data.graduation_time = Convert.ToDateTime(graduation_time);
            data.state = 1;
            return Db.SaveModified(data) ? true : false;
        }

        //取当前用户报名的活动/报名过的活动
        public List<enroll> GetUserActivity(string uid, string index)
        {
            if (index == "1")//等待参加
            {
                return Db.enroll.Where(o => o.user_id == uid && o.state == 0).ToList();
            }
            else if (index == "2")//已参加
            {
                return Db.enroll.Where(o => o.user_id == uid && (o.state == 2 || o.state == 3)).ToList();
            }
            else//默认
            {
                return Db.enroll.Where(o => o.user_id == uid).ToList();
            }

        }

        //ajax当前用户报名的分类
        public List<XiaoTuan.Service.Model.ajaxEnrollActivity> GetUserActivityAjax(string uid, string index)
        {
            if (index == "1")//等待参加
            {
                return Db.enroll.Where(o => o.user_id == uid && o.state == 0).Select(b => new Model.ajaxEnrollActivity
                {
                    org_name = b.activity.organization.org_name,
                    activity_name = b.activity.activity_name,
                    activity_photo = b.activity.activity_photo,
                    activity_detail = b.activity.activity_detail,
                    activity_id = b.activity.activity_id,
                    org_form_id = b.org_form_id,
                    state = b.state

                }).ToList();
            }
            else if (index == "2")//已参加
            {
                return Db.enroll.Where(o => o.user_id == uid && (o.state == 2 || o.state == 3))
                    .Select(b => new Model.ajaxEnrollActivity
                    {
                        org_name = b.activity.organization.org_name,
                        activity_name = b.activity.activity_name,
                        activity_photo = b.activity.activity_photo,
                        activity_detail = b.activity.activity_detail,
                        activity_id = b.activity.activity_id,
                        org_form_id = b.org_form_id,
                        state = b.state

                    }).ToList();
            }
            else//默认
            {
                return Db.enroll.Where(o => o.user_id == uid)
                    .Select(b => new Model.ajaxEnrollActivity
                    {
                        org_name = b.activity.organization.org_name,
                        activity_name = b.activity.activity_name,
                        activity_photo = b.activity.activity_photo,
                        activity_detail = b.activity.activity_detail,
                        activity_id = b.activity.activity_id,
                        org_form_id = b.org_form_id,
                        state = b.state

                    }).ToList();
            }

        }

        //取活动评价的enroll数据
        public enroll GetAssessPage(string orgFormId)
        {
            return Db.enroll.FirstOrDefault(o => o.org_form_id == orgFormId);
        }

        //取用户所有参加过的活动数据
        public List<enroll> GetFootprint(string uid)
        {
            return Db.enroll.Where(o => o.user_id == uid&&o.state==3).ToList();
        }

        //写入活动评价
        public bool ChangeAssessPage(string orgFormId, string ActivityGrade, string AssessText,string piclist,string uid)
        {
            var data = Db.enroll.FirstOrDefault(o => o.org_form_id == orgFormId);
            data.to_activity_evalute = Convert.ToInt32(ActivityGrade);
            data.evaluate_content = AssessText;
            data.evalute_time = DateTime.Now;
            data.state = 3;
            Db.SaveModified(data);

            var pic = piclist.Split(';');
            for (int item = 0; item < pic.Count() - 1; item++)
            {
                Db.photo.Add(new photo() {
                    photo_id=DateTime.Now.Random(),
                    activity_id=data.activity_id,
                    url=pic[item],
                    userid= uid,
                    time=DateTime.Now,
                    state=1
                });
            }

            return Db.Saved() ? true : false;
           
        }

        //取该活动的所有报名且已评价的列表
        public List<enroll> GetActivityEnrollDetial(string activity_id)
        {
            return Db.enroll.Where(o => o.activity_id == activity_id && o.state == 3).ToList();

        }

        //获取活动评价完后的所有图片
        public List<photo> GetActivityPhoto(string activity_id)
        {
            return Db.photo.Where(o => o.activity_id == activity_id && o.state == 1).ToList();
        }

        //ajax评价分数分类 5-3 0-2
        public List<XiaoTuan.Service.Model.assess> AssessState(string activity_id, string index)
        {
            if (index == "1")
            {
                var data = Db.enroll.Where(o => o.activity_id == activity_id && o.state == 3 && o.to_activity_evalute > 3)
                    .Select(b => new XiaoTuan.Service.Model.assess()
                    {
                        name = b.student.name,
                        //evalute_time = SqlFunctions.StringConvert((string)b.evalute_time.Value).ToString(),
                        evalute_time = b.evalute_time,
                        evaluate_content = b.evaluate_content

                    }).ToList();
                return data;
            }
            else if (index == "2")
            {
                var data = Db.enroll.Where(o => o.activity_id == activity_id && o.state == 3 && o.to_activity_evalute <= 3)
                 .Select(b => new XiaoTuan.Service.Model.assess()
                 {
                     name = b.student.name,
                     evalute_time = b.evalute_time,
                     evaluate_content = b.evaluate_content

                 }).ToList();
                return data;
            }
            else
            {
                var data = Db.enroll.Where(o => o.activity_id == activity_id && o.state == 3)
                 .Select(b => new XiaoTuan.Service.Model.assess()
                 {
                     name = b.student.name,
                     evalute_time = b.evalute_time,
                     evaluate_content = b.evaluate_content

                 }).ToList();
                return data;
            }


        }

        //取该活动报名的列表
        public List<enroll> GetActivityEnrollList(string activity_id)
        {
            return Db.enroll.Where(o => o.activity_id == activity_id && o.state != -1).ToList();
        }

        //取该组织是所有活动
        public List<XiaoTuan.Entity.activity> GetOrganizationActivity(string org_id)
        {
            return Db.activity.Where(o => o.org_id == org_id).ToList();
        }

        //取所有活动
        public List<XiaoTuan.Entity.activity> GetActivity(string org_id)
        {
            if (!org_id.HasValue())
            {
                return Db.activity.OrderBy(o => o.activity_time).Where(o => o.sign_end_time > DateTime.Now).ToList();
            }
            else
            {
                return Db.activity.OrderBy(o => o.activity_time).Where(o => o.sign_end_time > DateTime.Now && o.org_id == org_id).ToList();
            }

        }

        //ajax通过活动名称搜索
        public List<XiaoTuan.Service.Model.activity> SearchActivity(string name)
        {
            var data = Db.activity.OrderBy(o => o.activity_time)
                .Where(o => o.sign_end_time > DateTime.Now && o.activity_name.Contains(name))
                .Select(b => new XiaoTuan.Service.Model.activity()
                {
                    activity_id = b.activity_id,
                    activity_name = b.activity_name,
                    activity_detail = b.activity_detail,
                    activity_photo = b.activity_photo
                }).ToList();

            return data;
        }

        //ajax通过组织名称搜索活动
        public List<XiaoTuan.Service.Model.activity> SearchActivityOrg(string org_id)
        {
            if (!org_id.HasValue())
            {
                var data = Db.activity.OrderBy(o => o.activity_time)
                .Where(o => o.sign_end_time > DateTime.Now)
                .Select(b => new XiaoTuan.Service.Model.activity()
                {
                    activity_id = b.activity_id,
                    activity_name = b.activity_name,
                    activity_detail = b.activity_detail,
                    activity_photo = b.activity_photo,
                    activity_time = b.activity_time
                }).ToList();

                return data;
            }
            else
            {
                var data = Db.activity.OrderBy(o => o.activity_time)
               .Where(o => o.sign_end_time > DateTime.Now && o.org_id == org_id)
               .Select(b => new XiaoTuan.Service.Model.activity()
               {
                   activity_id = b.activity_id,
                   activity_name = b.activity_name,
                   activity_detail = b.activity_detail,
                   activity_photo = b.activity_photo,
                   activity_time = b.activity_time
               }).ToList();

                return data;

            }

        }

        //ajax通过高级排序搜索活动
        public List<XiaoTuan.Service.Model.activity> SearchActivitySorting(string index)
        {
            if (index=="x10")
            {
                var data = Db.activity.OrderBy(o => o.activity_time)
                .Where(o => o.sign_end_time > DateTime.Now)
                .Select(b => new XiaoTuan.Service.Model.activity()
                {
                    activity_id = b.activity_id,
                    activity_name = b.activity_name,
                    activity_detail = b.activity_detail,
                    activity_photo = b.activity_photo,
                    activity_time = b.activity_time
                }).ToList();

                return data;
            }
            else if(index=="x11")
            {
                var data = Db.activity
               .Where(o => o.sign_end_time > DateTime.Now)
               .Select(b => new XiaoTuan.Service.Model.activity()
               {
                   activity_id = b.activity_id,
                   activity_name = b.activity_name,
                   activity_detail = b.activity_detail,
                   activity_photo = b.activity_photo,
                   activity_time = b.activity_time,
                   count = Db.enroll.Where(o => o.activity_id == b.activity_id && o.state == 0).Count()
               }).OrderByDescending(o=>o.count).ToList();

                return data;
            }
            else
            {
                var data = Db.activity
               .Where(o => o.sign_end_time > DateTime.Now)
               .Select(b => new XiaoTuan.Service.Model.activity()
               {
                   activity_id = b.activity_id,
                   activity_name = b.activity_name,
                   activity_detail = b.activity_detail,
                   activity_photo = b.activity_photo,
                   activity_time = b.activity_time,
                   count =Db.enroll.Where(o=>o.activity_id==b.activity_id).Count()
               }).OrderByDescending(o=>o.count).ToList();

                return data;

            }

        }

        //取该活动
        public XiaoTuan.Entity.activity GetActivityDetial(string activityId)
        {
            return Db.activity.FirstOrDefault(o => o.activity_id == activityId);
        }

        //取该组织
        public organization GetOrganizationDetial(string organizationId)
        {
            return Db.organization.FirstOrDefault(o => o.org_id == organizationId);
        }

        //获取组织列表
        public List<organization> GetOrganization()
        {
            return Db.organization.ToList();
        }

        //获取活动收藏列表
        public List<activityCollection> activityCollection(string uid)
        {
            return Db.activityCollection.Where(o => o.userid == uid).ToList();
        }

        //获取组织关注列表
        public List<organizationalConcerns> organizationConcerns(string uid)
        {
            return Db.organizationalConcerns.Where(o => o.userid == uid).ToList();
        }

        //获取学生信息
        public student GetStudent(string uid)
        {
            return Db.student.FirstOrDefault(o => o.userid == uid);
        }

        //取消报名活动
        public bool CancelEnroll(string org_form_id)
        {
            var data = Db.enroll.NoTrackingFind(o => o.org_form_id == org_form_id);
            data.state = -1;
            return Db.SaveModified(data) ? true : false;
        }

        //报名活动
        public int addEnroll(string activity_id, string uid)
        {
            //1：报名成功，0：报名失败，2：重复报名 3：没有实名认证
            var student = Db.student.NoTrackingFind(o => o.userid == uid && o.state == 2);
            if (student != null)
            {
                var data = Db.enroll.FirstOrDefault(o => o.activity_id == activity_id && o.user_id == uid);
                if (data != null && data.state == -1)
                {
                    data.state = 0;
                    data.sign_time = DateTime.Now;
                    if (Db.SaveModified(data))
                    {
                        return 1;
                    }
                    else
                    {
                        return 0;
                    }

                }
                else if (data != null && data.state == 2 || data != null && data.state == 3 || data != null && data.state == 0)
                {
                    return 2;
                }
                else
                {
                    Db.enroll.Add(new enroll()
                    {
                        org_form_id = DateTime.Now.Random(),
                        activity_id = activity_id,
                        user_id = uid,
                        sign_time = DateTime.Now,
                        state = 0
                    });
                    return Db.SaveChanges() > 0 ? 1 : 0;
                }
            }
            else
            {
                return 3;
            }

        }

        //添加活动收藏
        public bool addCollection(string activity_id, string uid)
        {
            var data = Db.activityCollection.FirstOrDefault(o => o.activity_id == activity_id && o.userid == uid);
            if (data != null)
            {
                return Db.SaveDelete(data) ? true : false;
            }
            else
            {
                Db.activityCollection.Add(new activityCollection()
                {
                    collection_id = DateTime.Now.Random(),
                    activity_id = activity_id,
                    userid = uid,
                    time = DateTime.Now
                });
                return Db.Saved() ? true : false;
            }

        }

        //取消活动收藏
        public bool removeCollection(string activity_id, string uid)
        {
            var data = Db.activityCollection.FirstOrDefault(o => o.activity_id == activity_id && o.userid == uid);
            return Db.SaveDelete(data) ? true : false;

        }
       
        //添加组织关注
        public bool addConcerns(string org_id, string uid)
        {
            var data = Db.organizationalConcerns.FirstOrDefault(o => o.org_id == org_id && o.userid == uid);
            if (data != null)
            {
                return Db.SaveDelete(data) ? true : false;
            }
            else
            {
                Db.organizationalConcerns.Add(new organizationalConcerns()
                {
                    concerns_id = DateTime.Now.Random(),
                    org_id = org_id,
                    userid = uid,
                    time = DateTime.Now
                });
                return Db.Saved() ? true : false;
            }

        }

        //取消组织关注
        public bool removeConcerns(string org_id, string uid)
        {
            var data = Db.organizationalConcerns.FirstOrDefault(o => o.org_id == org_id && o.userid == uid);
            return Db.SaveDelete(data) ? true : false;

        }
    }
}
