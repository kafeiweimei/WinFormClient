using CoffeeMilk13.TimeSeriesDB.DBTest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeMilk13.TimeSeriesDB
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("————时序数据库测试————");
            Test_Influxdb2OfficialHelper.Test();

            Console.ReadLine();
        }


    }//Class_end
}
