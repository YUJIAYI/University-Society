using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using XiaoTuan.Entity;

namespace Web.Areas.XiaoTuan.ViewModels
{
    public class IdentfilyUser_M
    {
        public string userid { get; set; }
        [Display(Name ="姓名")]
        public string name { get; set; }

        [Display(Name = "头像")]
        public string photo { get; set; }

        [Display(Name = "性别")]
        public string sex { get; set; }

        [Display(Name = "生日")]
        public string birthday { get; set; }

        [Display(Name = "学校")]
        public string school { get; set; }

        [Display(Name = "专业")]
        public string major { get; set; }

        [Display(Name = "年级")]
        public string grade { get; set; }

        [Display(Name = "电话")]
        public string cell_number { get; set; }

        [Display(Name = "入校时间")]
        public string to_school_time { get; set; }

        [Display(Name = "学生卡号")]
        public string card_number { get; set; }

        [Display(Name = "离校时间")]
        public string graduation_time { get; set; }

        [Display(Name = "认证照片")]
        public string identfily_pic { get; set; }


        public int? state { get; set; }
        public static IdentfilyUser_M ToViewModel(student data)
        {
            return new IdentfilyUser_M()
            {
                userid=data.userid,
                name=data.name,
                photo=data.photo,
                sex=data.sex,
                birthday=data.birthday.Value.ToString("yyyy-MM-dd"),
                school=data.school,
                major=data.major,
                grade=data.grade,
                cell_number=data.cell_number,
                to_school_time=data.to_school_time.Value.ToString("yyyy-MM-dd"),
                card_number=data.card_number,
                graduation_time=data.graduation_time.Value.ToString("yyyy-MM-dd"),
                state=data.state,
                identfily_pic=data.identfily_pic
            };
        }
    }
}