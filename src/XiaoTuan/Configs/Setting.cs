using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XiaoTuan.Configs
{
    public static class Setting
    {
        public static readonly string ConnectionString = ConfigurationManager.ConnectionStrings["XiaoTuan"].ConnectionString;
    }

}
