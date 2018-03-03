
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
    public class activityRepository : BaseRepository, IRepository<activity>
    {
        public List<SelectListItem> ToSelectItems(string value = "")
        {
            return Db.activity.ToItems(v => v.activity_id, t => t.activity_name);
        }

        public string Add(activity model)
        {
            model.activity_id = Pk;
            return Find(model.activity_id) == null ? (Db.SaveAdd(model) ? Pk : null) : "";
        }

        public bool Delete(object id)
        {
            return Db.SaveDelete(Find(id));
        }

        public bool Update(activity model, string note = "")
        {
            Db.activity.AddOrUpdate(model);
            return Db.Saved();
        }

        public activity Find(object id)
        {
            return Db.activity.NoTrackingFind(a => a.activity_id == (string)id);
        }

        public List<activity> All()
        {
            return Db.activity.NoTrackingToList();
        }

        public List<activity> All(Func<activity, bool> filter)
        {
            return Db.activity.NoTrackingWhere(filter);
        }
    }
}
