using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using XiaoTuan.Entity;

namespace Web.Areas.XiaoTuan.ViewModels
{
    public class PersonalInformation_M
    {

        // GET: XiaoTuan/PersonalInformation_M
        public static PersonalInformation_M ToViewModel(student studentData)
        {
            if (studentData.state == 2)//认证完成，有生日
            {
                return new PersonalInformation_M()
                {
                    studentData = studentData,
                    studentDataBirth = studentData.birthday.Value.ToString("yyyy-MM-dd"),
                };
            }
            else
            {
                return new PersonalInformation_M()
                {
                    studentData = studentData,
                    studentDataBirth=""
                };
            }
        }
        public student studentData { get; set; }
        public string studentDataBirth { get; set; }
    }
}