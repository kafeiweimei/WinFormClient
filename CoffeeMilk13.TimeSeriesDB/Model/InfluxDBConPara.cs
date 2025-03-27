/***
*	Title："WinFormClient" 项目
*		主题：InfluxDB数据库的连接参数模型
*	Description：
*		功能：XXX
*	Date：2025/3/24 10:57:31
*	Version：0.1版本
*	Author：XXX
*	Modify Recoder：
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeMilk13.TimeSeriesDB.Model
{
    public struct InfluxDBConPara
    {
        public string Url { get; set; }

        public string Token { get; set; }

        public string User { get; set; }

        public string Pwd { get; set; }

        public string BucketName { get; set; }

        public string Org { get; set; }

    }
}
