using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using UpsaApi.DAL.Utils;

namespace UpsaApi.DAL
{
    public class EmployeeRepository
    {
        private HttpClient _client;
        private String _authorization;
        private String _currentClientId;

        public EmployeeRepository()
        {
            _client = new HttpClient();
            TokenHelper.GetCurrentToken().ContinueWith(x =>
            {
                _authorization = "Bearer " + x.Result.ToString();
                _currentClientId = x.Result.Id;
            }).Wait();
            _client.DefaultRequestHeaders.Authorization = AuthenticationHeaderValue.Parse(_authorization);

        }

        public Task<String> GetEmployeeInfo()
        {
            return
                _client.GetStringAsync(String.Format("https://upsa.epam.com/workload/rest/v3/employees/{0}/info",
                    _currentClientId));
        }

        public Task<String> GetEmployeeSkills(String employeeId)
        {
            return
                _client.GetStringAsync(String.Format("https://upsa.epam.com/workload/rest/v3/employees/{0}/skills",
                    employeeId));
        }

    }
}
