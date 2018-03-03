using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using XiaoTuan.Entity;
using XiaoTuan.Model;

namespace XiaoTuan.Interfaces
{
   public  interface IXiaoTuanService
    {
        //用户认证状态搜索框
        List<SelectListItem> statusSelect();

        //查看该活动有没有人报名
        bool FindActivityIsUser(string activityid);

        //负责人的组织机构
        List<SelectListItem> UserOrgList(string uid);

        //通过扫描二维码改变活动状态
        bool ChangeStatus(string org_form_id, string uid);

        //一个新账号登陆在学生表增加一条
        bool AddUser(string uid,string img);
        bool FindUser(string uid);

        //进行学生认证
        bool StudentIdentification(string name, string cell_number, string sex, string birthday, string to_school_time, string school, string major, string grade, string card_number, string graduation_time, string uid);

        //取当前用户报名的活动/报名过的活动
        List<enroll> GetUserActivity(string uid, string index);

        //取用户所有参加过的活动数据
        List<enroll> GetFootprint(string uid);

        //ajax当前用户报名的分类
        List<XiaoTuan.Service.Model.ajaxEnrollActivity> GetUserActivityAjax(string uid, string index);

        //取活动评价的enroll数据
        enroll GetAssessPage(string orgFormId);

        //写入活动评价
        bool ChangeAssessPage(string orgFormId, string ActivityGrade, string AssessText, string piclist, string uid);

        //取该活动的所有报名且已评价的列表
        List<enroll> GetActivityEnrollDetial(string activity_id);

        //获取活动评价完后的所有图片
        List<photo> GetActivityPhoto(string activity_id);

        //ajax评价分数分类 5-3 0-2
        List<XiaoTuan.Service.Model.assess> AssessState(string activity_id, string index);

        //取该活动报名的列表
        List<enroll> GetActivityEnrollList(string activity_id);

        //取该组织是所有活动
        List<XiaoTuan.Entity.activity> GetOrganizationActivity(string org_id);

        //取所有活动
        List<XiaoTuan.Entity.activity> GetActivity(string org_id);

        //ajax通过活动名称搜索
        List<XiaoTuan.Service.Model.activity> SearchActivity(string name);

        //ajax通过组织名称搜索活动
        List<XiaoTuan.Service.Model.activity> SearchActivityOrg(string org_id);

        //ajax通过高级排序搜索活动
        List<XiaoTuan.Service.Model.activity> SearchActivitySorting(string index);
        
        //取该活动
        XiaoTuan.Entity.activity GetActivityDetial(string activityId);

        //取该组织
        organization GetOrganizationDetial(string organizationId);

        //获取组织列表
        List<organization> GetOrganization();

        //获取活动收藏列表
        List<activityCollection> activityCollection(string uid);

        //获取组织关注列表
        List<organizationalConcerns> organizationConcerns(string uid);

        //获取学生信息
        student GetStudent(string uid);

        //取消报名活动
        bool CancelEnroll(string org_form_id);

        //报名活动
        int addEnroll(string activity_id, string uid);

        //添加活动收藏
        bool addCollection(string activity_id, string uid);

        //取消活动收藏
        bool removeCollection(string activity_id, string uid);

        //添加组织关注
        bool addConcerns(string org_id, string uid);

        //取消组织关注
        bool removeConcerns(string org_id, string uid);
       
    }
}
