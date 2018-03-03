using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using XiaoTuan.Entity;
using XiaoTuan.Model;

namespace Web.Areas.XiaoTuan.ViewModels
{
    public class StudentIdentification_M
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
        public student model { get;  set; }

        public static StudentIdentification_M ToViewModel(student model)
        {
            return new StudentIdentification_M()
            {
                name = model.name,
                cell_number = model.cell_number,
                model= model
            };
        }
        public StudentIdentification ToModel()
        {
            return new StudentIdentification()
            {
                name = name,
                cell_number = cell_number,
                birthday = birthday,
                to_school_time = to_school_time,
                school = school,
                major = major,
                grade = grade,
                card_number = card_number,
                graduation_time = graduation_time
            };
        }
    }
}