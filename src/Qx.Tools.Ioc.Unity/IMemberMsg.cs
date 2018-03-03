using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Qx.Tools.Ioc.Unity
{
    public interface IMemberMsg
    {
        //获取用户联系人详情
        List<List<string>> MyContacterInfo(string memberid,string name);

        //添加联系人
        List<List<string>> ContacterAdd(string memberid);

        //获取群组联系人
        List<List<string>> GroupMember(string groupid, string name);

        //获取指定用户的联系人
        List<SelectListItem> GetContactName(string OwnerID);

        //获取用户搜藏的消息
        List<List<string>> MsgCollections(string userid, string sbjects);

        //获取用户的收件箱列表
        List<List<string>> InBox(string userid);

        //获取用户的发件箱列表
        List<List<string>> OutBox(string userid);

        //获取用户未读消息
        List<List<string>> UnReadMsg(string userid);

        //获取用户草稿箱列表
        List<List<string>> Drafts(string userid);

        //获取用户定时消息发送记录
        List<List<string>> TimerSendRecords(string userid);

        //获取用户定时消息
        List<List<string>> TimerTask(string userid);
    }
}
