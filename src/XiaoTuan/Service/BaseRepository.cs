﻿using Qx.Tools;
using Qx.Tools.CommonExtendMethods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XiaoTuan.Entity;

namespace XiaoTuan.Service
{
    public class BaseRepository
    {
        private MyDbContext db;
        protected MyDbContext Db
        {
            get
            {
                if (db == null)
                {
                    db = new MyDbContext();
                }
                return db;
            }
        }
        protected string Check(DataContext DataContext, string key)
        {
            var value = DataContext.GetFiled(key) + "";
            if (string.IsNullOrEmpty(value))
                throw new NullReferenceException("DataContext.SetFiled(\"" + key + "\",value)给" + key + "赋值！");
            return value;
        }

        protected string Pk { get { return DateTime.Now.Random().ToString(); } }

    }
}
