
using Qx.Msg.Interfaces;
using Qx.Tools.CommonExtendMethods;
using Qx.Tools.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using qx.permmision.v2.Interfaces;

namespace Qx.Tools.Ioc.Unity
{
    public class MemberMsg : IMemberMsg
    {
        private IMemberProvider _memberProvider;
        private IMsgProvider _msgProvider;
        private IPermissionProvider _permissionProvider;
    
        public MemberMsg(
            IMemberProvider memberProvider, 
            IMsgProvider msgProvider,
            IPermissionProvider permissionProvider
            )
        {
            _memberProvider = memberProvider;
            _msgProvider = msgProvider;
            _permissionProvider = permissionProvider;
        }
        public List<List<string>> MyContacterInfo(string memberid, string name)
        {

            var member = _memberProvider.GetMember(memberid);
            var memberinfo = _memberProvider.GetMemContactInfo(memberid);
            var body = _msgProvider.ContactRepository.All().Where(a => a.OwnerID == memberid).Select(b => new List<string>()
                {
                    b.ContactID,                  
                    _permissionProvider.UserInfo(b.MembersID).NickName,
                    _memberProvider.GetMember(b.MembersID).M_Sex,
                    _memberProvider.GetMember(b.MembersID).M_Address,
                    _memberProvider.GetMemContactInfo(b.MembersID).FixedPhone,
                    _memberProvider.GetMemContactInfo(b.MembersID).MobilePhone,
                    _memberProvider.GetMemContactInfo(b.MembersID).Email,
                    _memberProvider.GetMemContactInfo(b.MembersID).WeChat,
                    _memberProvider.GetMemContactInfo(b.MembersID).QQ,
                 }).ToList();
            if (name == ";")
            {
                name = "";
            }
            body = body.Where(a => a[1].Contains(name)).ToList();
            return body;       
        }
        public List<List<string>> ContacterAdd(string memberid)
        {
            var body = new List<List<string>>();         
            var member = _memberProvider.GetMember(memberid);
                if (member != null)
                {
                    body.Add(new List<string>()
                {
                     memberid,
                    _permissionProvider.UserInfo(memberid).NickName,
                 });
                }
                return body;                   
        }
        public List<List<string>> GroupMember(string groupid, string name)
        {
            var body = _msgProvider.GroupMemberRepository.All().Where(a => a.GroupID == groupid).Select(b => new List<string>()
                {
                    b.GroupMemberID,
                    _msgProvider.GroupRepository.Find(groupid).GroupName,
                    _permissionProvider.UserInfo(b.MembersID).NickName,
                    _memberProvider.GetMember(b.MembersID).M_Sex,
                    _memberProvider.GetMember(b.MembersID).M_Address,
                    _memberProvider.GetMemContactInfo(b.MembersID).FixedPhone,
                    _memberProvider.GetMemContactInfo(b.MembersID).MobilePhone,
                    _memberProvider.GetMemContactInfo(b.MembersID).Email,
                    _memberProvider.GetMemContactInfo(b.MembersID).WeChat,
                    _memberProvider.GetMemContactInfo(b.MembersID).QQ,
                 }).ToList();
            if (name == ";")
            {
                name = "";
            }
            body = body.Where(a => a[2].Contains(name)).ToList();
            return body;
        }
        public List<SelectListItem> GetContactName(string OwnerID)
        {
            var Contacts = _msgProvider.ContactRepository.All().Where(a => a.OwnerID == OwnerID).ToList();
            //var Users = Db.Users;
            List<SelectListItem> ContactName = new List<SelectListItem>();
            foreach (var Contact in Contacts)
            {
                ContactName.Add(new SelectListItem()
                {
                    Text = _permissionProvider.UserInfo(Contact.MembersID).NickName,
                    Value = Contact.MembersID,
                });
            }
            return ContactName;
        }
        public List<List<string>> MsgCollections(string userid, string sbjects)
        {
            var body = _msgProvider.MsgCollectionRepository.All().OrderBy(a=>a.Time).Where(a => a.UserID == userid).Select(c => new List<string>()
            {
                    c.Time.ToString(),//收藏时间
                    _permissionProvider.UserInfo(_msgProvider.MsgRepository.Find(c.MsgID).SenderID).NickName,//发件人
                    _permissionProvider.UserInfo(c.ReceiverID).NickName,//收件人
                    _msgProvider.MsgRepository.Find(c.MsgID).Subjects,//主题
                    c.MsgCollectionID,
                    c.MsgID,
            }).ToList();                
            if (sbjects == ";")
            {
                sbjects = "";
            }
            body = body.Where(a => a[2].Contains(sbjects)).ToList();
            return body;
        }

        public List<List<string>> UnReadMsg(string userid)
        {
            var msgSendReocrd = _msgProvider.UnReadMsg(userid).OrderBy(a => a.SendTime).Where(a => a.InStateID == "01").OrderByDescending(a => a.SendTime);
            var body = new List<List<string>>();
            foreach (var item in msgSendReocrd)
            {
                body.Add(new List<string>()
                {
                    item.InState.StateName,
                    _permissionProvider.UserInfo(item.Msg.SenderID).NickName,
                    item.Msg.Subjects,
                    item.SendTime==null?"":item.SendTime.Value.ToString(),
                    item.MsgSendRecordID,
                    item.InStateID
                });
            }
            return body;
        }
        public List<List<string>> InBox(string userid)
        {
            var msgSendReocrd = _msgProvider.InBox(userid).OrderBy(a => a.SendTime).Where(a=>a.InStateID=="01"||a.InStateID=="02").OrderByDescending(a=>a.SendTime);
            var body = new List<List<string>>();
            foreach (var item in msgSendReocrd)
            {
                body.Add(new List<string>()
                {
                    item.InState.StateName,
                    _permissionProvider.UserInfo(item.Msg.SenderID).NickName,
                    item.Msg.Subjects,
                    item.SendTime==null?"":item.SendTime.Value.ToString(),
                    item.MsgSendRecordID,
                    item.InStateID
                });
            }
            return body;
        }

        public List<List<string>> OutBox(string userid)
        {
            var msgSendReocrd = _msgProvider.Drafts(userid).OrderBy(a => a.SendTime).Where(a => a.OutStateID == "02" || a.OutStateID == "03").OrderByDescending(a => a.SendTime);
            var body = new List<List<string>>();
            foreach (var item in msgSendReocrd)
            {
                body.Add(new List<string>()
                {
                    item.OutState.StateName,
                    _permissionProvider.UserInfo(item.ReceiverID).NickName,
                    item.Msg.Subjects,
                    item.SendTime==null?"":item.SendTime.Value.ToString(),
                    item.MsgSendRecordID,
                    item.InStateID
                });
            }
            return body;
        }

        public List<List<string>> Drafts(string userid)
        {
            var msgSendRecord = _msgProvider.Drafts(userid).OrderBy(a => a.SendTime).Where(a => a.OutStateID == "01").OrderByDescending(a => a.Msg.CreationTime);
            var body = new List<List<string>>();
            foreach(var item in msgSendRecord)
            {
                body.Add(new List<string>()
                {
                    item.OutState.StateName,
                    _permissionProvider.UserInfo(item.ReceiverID).NickName,
                    item.Msg.Subjects,
                    item.Msg.CreationTime==null?"":item.Msg.CreationTime.ToString(),
                    item.MsgSendRecordID,
                    item.MsgID
                });
            }
            return body;
        }

        public List<List<string>> TimerSendRecords(string userid)
        {
            var msgSendReocrd = _msgProvider.TimerSendRecords(userid).Where(a => a.OutStateID == "05" || a.OutStateID == "06");
            var body = new List<List<string>>();
            foreach (var item in msgSendReocrd)
            {
                body.Add(new List<string>()
                {
                    item.OutState.StateName,
                    _permissionProvider.UserInfo(item.ReceiverID).NickName,
                    item.Msg.Subjects,
                    item.Msg.TimerMsgs.FirstOrDefault().SetSendTime==null?"":item.Msg.TimerMsgs.FirstOrDefault().RealSendTime.Value.ToString(),
                    item.Msg.TimerMsgs.FirstOrDefault().RealSendTime==null?"":item.Msg.TimerMsgs.FirstOrDefault().RealSendTime.Value.ToString(),
                    item.MsgSendRecordID,
                    item.OutStateID
                });
            }
            return body;
        }

        public List<List<string>> TimerTask(string userid)
        {
            var msgSendReocrd = _msgProvider.Drafts(userid).Where(a => a.OutStateID == "04" );
            var body = new List<List<string>>();
            foreach (var item in msgSendReocrd)
            {
                body.Add(new List<string>()
                {
                    item.OutState.StateName,
                    _permissionProvider.UserInfo(item.ReceiverID).NickName,
                    item.Msg.Subjects,
                    item.Msg.CreationTime==null?"":item.Msg.CreationTime.ToString(),
                    item.Msg.TimerMsgs.FirstOrDefault().SetSendTime==null?"":item.Msg.TimerMsgs.FirstOrDefault().RealSendTime.Value.ToShortTimeString(), 
                    item.MsgSendRecordID,
                    item.OutStateID
                });
            }
            return body;
        }
    }
}
