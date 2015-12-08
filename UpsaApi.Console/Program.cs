using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using UpsaApi.DAL;
using UpsaApi.DAL.Entities;
using UpsaApi.DAL.Utils;

namespace UpsaApi.Console
{
    class Program
    {
        public static void Main()
        {
            var result = new EmployeeRepository().GetEmployeeInfo();
            result.Wait();
            System.Console.WriteLine(result.Result);
        }
    }
}
