using DemoClientApp.Api;
using DemoClientApp.Client;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using System;

namespace DemoClientApp
{
    class Program
    {
        //In this case we created web api and hosted on app service and configured authentication in portal itself.
        static string appId = "40195283-ee2e-4e29-99f4-a646b91c4359";
        static string secret = "cpP8Q~GIgnoUqPyZOEpNyt2RLe1tJorjQWRAFa3t";
        static string tenantId = "0c44cc27-a1cd-4b20-9c98-607c791fc563";

        static void Main(string[] args)
        {
            var context = new AuthenticationContext("https://login.windows.net/" + tenantId);
            var credential = new ClientCredential(clientId: appId, clientSecret: secret);
            AuthenticationResult result = context.AcquireTokenAsync(appId, credential).Result;
            if (result == null)
                throw new InvalidOperationException("Failed to obtain the JWT token");
            var token = result.AccessToken;

            var config = new Configuration();
            config.DefaultHeaders.Add("Authorization", "Bearer " + token);
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
