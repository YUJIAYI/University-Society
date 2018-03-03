using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XiaoTuan.Service.Model
{
   public  class activity
    {
        public string activity_id { get; set; }

        public string activity_name { get; set; }
        
        public string activity_detail { get; set; }

        public string activity_photo { get; set; }
        public DateTime? activity_time { get;  set; }
        public int count { get; set; }
    }
}
