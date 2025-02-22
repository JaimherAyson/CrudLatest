using System.Net.Http;
using System.Net.Http.Json;
using System.Collections.Generic;
using System.Threading.Tasks;
using CrudLatest.Server.Shared.Models;

namespace CrudLatest.Services
{
    public class ItemService
    {
        private readonly HttpClient _httpClient;

        public ItemService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Item>> GetItemsAsync() =>
            await _httpClient.GetFromJsonAsync<List<Item>>("items");

        public async Task CreateItemAsync(Item item) =>
            await _httpClient.PostAsJsonAsync("items", item);

        public async Task UpdateItemAsync(string id, Item item) =>
            await _httpClient.PutAsJsonAsync($"items/{id}", item);

        public async Task DeleteItemAsync(string id) =>
            await _httpClient.DeleteAsync($"items/{id}");
    }
}
