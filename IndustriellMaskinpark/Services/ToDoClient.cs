using MaskinPark.Shared;
using System.Net.Http.Json;

namespace IndustriellMaskinpark.Services
{
    public class ToDoClient : IToDoClient
    {
        private readonly HttpClient httpClient;

        public ToDoClient(HttpClient httpClient)
        {
            this.httpClient = httpClient;
            // this.httpClient.BaseAddress
        }

        public async Task<IEnumerable<Machine>?> GetAsync()
        {
            return await httpClient.GetFromJsonAsync<IEnumerable<Machine>>("api/todo");
        }
        public async Task<Machine?> PostAsync(Machine machine)
        {
            var response = await httpClient.PostAsJsonAsync<Machine>("api/todo", machine);

            if (response.IsSuccessStatusCode)
                return await response.Content.ReadFromJsonAsync<Machine>();

            return null;
        }

        public async Task<bool> RemoveAsync(string id)
        {
            var response = await httpClient.DeleteAsync($"api/todo/{id}");

            return response.IsSuccessStatusCode ? true : false;
        }


    }
}
