using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using EmployeeService.UI.Business.Model.Dto;

namespace EmployeeService.UI.Business.Services
{
    public class DepartmentService : IDepartmentService
    {        
        private readonly HttpClient client;

        public DepartmentService(IHttpClientFactory httpClient)
        {
            this.client = httpClient.CreateClient("department");
        }

        public async Task<List<SearchDto>> Search(string keyword)
        {
           return await client.GetFromJsonAsync<List<SearchDto>>($"department/fullsearch?keyword={keyword}");
        }

        public async Task<List<DepartmentDto>> GetAll()
        {
            return await client.GetFromJsonAsync<List<DepartmentDto>>($"department");
        }

        public async Task Add(DepartmentDto department)
        {
            await client.PostAsJsonAsync<DepartmentDto>($"department", department);
        }

        public async Task Update(DepartmentDto department)
        {
            var jsonString = System.Text.Json.JsonSerializer.Serialize<DepartmentDto>(department);
            var httpContent = new StringContent(jsonString, Encoding.UTF8, "application/json");
            await client.PutAsync($"department", httpContent);             
        }

        public async Task Delete(int id)
        {
            await client.DeleteAsync($"department/{id}");
        }
    }
}
