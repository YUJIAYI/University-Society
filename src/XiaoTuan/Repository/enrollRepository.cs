
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
    public class enrollRepository : BaseRepository, IRepository<enroll>
    {
        public List<SelectListItem> ToSelectItems(string value = "")
        {
            return Db.enroll.ToItems(v => v.org_form_id, t => t.activity_id);
        }

        public string Add(enroll model)
        {
            model.org_form_id = Pk;
            return Find(model.org_form_id) == null ? (Db.SaveAdd(model) ? Pk : null) : "";
        }

        public bool Delete(object id)
        {
            return Db.SaveDelete(Find(id));
        }

        public bool Update(enroll model, string note = "")
        {
            Db.enroll.AddOrUpdate(model);
            return Db.Saved();
        }

        public enroll Find(object id)
        {
            return Db.enroll.NoTrackingFind(a => a.org_form_id == (string)id);
        }

        public List<enroll> All()
        {
            return Db.enroll.NoTrackingToList();
        }

        public List<enroll> All(Func<enroll, bool> filter)
        {
            return Db.enroll.NoTrackingWhere(filter);
        }
    }
}
