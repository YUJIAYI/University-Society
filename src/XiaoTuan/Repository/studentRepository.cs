
using Qx.Tools.CommonExtendMethods;
using Qx.Tools.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using XiaoTuan.Entity;
using XiaoTuan.Service;

namespace XiaoTuan.Repository
{
    public class studentRepository : BaseRepository, IRepository<student>
    {
        public List<SelectListItem> ToSelectItems(string value = "")
        {
            return Db.student.ToItems(v => v.userid, t => t.name);
        }

        public string Add(student model)
        {
            model.userid = Pk;
            return Find(model.userid) == null ? (Db.SaveAdd(model) ? Pk : null) : "";
        }

        public bool Delete(object id)
        {
            return Db.SaveDelete(Find(id));
        }

        public bool Update(student model, string note = "")
        {
            Db.student.AddOrUpdate(model);
            return Db.Saved();
        }

        public student Find(object id)
        {
            return Db.student.NoTrackingFind(a => a.userid == (string)id);
        }

        public List<student> All()
        {
            return Db.student.NoTrackingToList();
        }

        public List<student> All(Func<student, bool> filter)
        {
            return Db.student.NoTrackingWhere(filter);
        }
    }
}
