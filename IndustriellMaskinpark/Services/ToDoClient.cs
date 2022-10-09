using MaskinPark.Shared;

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





        public async Task<bool> RemoveAsync(string id)
        {
            var response = await httpClient.DeleteAsync($"api/todo/{id}");

            return response.IsSuccessStatusCode ? true : false;
        }


    }
}
