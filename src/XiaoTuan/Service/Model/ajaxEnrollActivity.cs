using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XiaoTuan.Service.Model
{
    public class ajaxEnrollActivity
    {
        public string activity_detail { get;  set; }
        public string activity_id { get;  set; }
        public string activity_name { get;  set; }
        public string activity_photo { get;  set; }
        public string org_name { get;  set; }
        public string org_form_id { get;  set; }
        public int? state { get; set; }
    }
}
