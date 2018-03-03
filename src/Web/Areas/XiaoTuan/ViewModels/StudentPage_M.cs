using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using XiaoTuan.Entity;

namespace Web.Areas.XiaoTuan.ViewModels
{
    public class StudentPage_M 
    {
        // GET: XiaoTuan/StudentPage
        public static StudentPage_M ToViewModel(student studentData)
        {
            return new StudentPage_M()
            {

                studentData = studentData,
               
            };
        }

        public StudentPage_M ToModel()
        {
            return new StudentPage_M()
            {

            };
        }

     
        public student studentData { get; set; }
      
    }
}