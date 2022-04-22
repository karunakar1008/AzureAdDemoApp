using DemoClientApp.Api;
using DemoClientApp.Client;
using System;

namespace DemoClientApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var config = new Configuration();
            config.BasePath = "https://dssdemoapiapp345.azurewebsites.net/";
            EmployeesApi api = new EmployeesApi(config);
            var emps = api.ApiEmployeesGet();
            foreach (var emp in emps)
            {
                Console.WriteLine(emp.Id + " " + emp.Name + " " + emp.Salary);
            }
        }
    }
}
