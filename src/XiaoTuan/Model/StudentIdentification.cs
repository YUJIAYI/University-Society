using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace XiaoTuan.Model
{
    public class StudentIdentification
    {
        public string userid { get; set; }

        public string name { get; set; }

        public string photo { get; set; }

        public string sex { get; set; }

        public DateTime birthday { get; set; }

        public string school { get; set; }

        public string major { get; set; }

        public string grade { get; set; }

        public string cell_number { get; set; }

        public DateTime to_school_time { get; set; }

        public string card_number { get; set; }

        public DateTime graduation_time { get; set; }

        public int state { get; set; }
    }
}