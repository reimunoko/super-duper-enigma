using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using EmployeeService.UI.BlazorServer.Dtos;

namespace EmployeeService.UI.BlazorServer.Services
{
    public class DepartmentService : IDepartmentService
    {
        

        private readonly HttpClient client;

        public DepartmentService(IHttpClientFactory httpClient)
        {
            this.client = httpClient.CreateClient("fullsearch");
        }

        public async Task<List<SearchDto>> Search(string keyword)
        {
           return await client.GetFromJsonAsync<List<SearchDto>>($"?keyword={keyword}");
        }
    }
}
