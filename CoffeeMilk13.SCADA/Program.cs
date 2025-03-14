using CoffeeMilk13.SCADA.Test;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeMilk13.SCADA
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("——开始SCADA模块测试——");
            TestOPCUA();


            Console.ReadLine();
        }


        //测试OPCUA
        private static void TestOPCUA()
        {
            Console.WriteLine("开始进行OPCUA测试");
            Test_OPCUAHelper test_OPCUAHelper = new Test_OPCUAHelper();
            test_OPCUAHelper.OpenConn();
        }

    }//Class_end
}
