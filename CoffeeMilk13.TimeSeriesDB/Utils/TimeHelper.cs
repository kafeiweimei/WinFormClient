/***
*	Title："WinFormClient" 项目
*		主题：时间帮助类
*	Description：
*		功能：
*		    1、时间转为时间戳
*		    2、时间戳转为时间
*	Date：2025/3/25 9:56:56
*	Version：0.1版本
*	Author：XXX
*	Modify Recoder：
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeMilk13.TimeSeriesDB.Utils
{
    public class TimeHelper
    {
        public static long GetNowTimeStamp_Unix()
        {
            long unixTimeStamp = (long)(DateTime.UtcNow - new DateTime(1970, 1, 1)).TotalMilliseconds;
            return unixTimeStamp;
            
        }

    }//Class_end
}
