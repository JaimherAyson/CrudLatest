using System.Collections.Generic;
using System.Threading.Tasks;
using CrudLatest.Server.Shared.Models;

namespace CrudLatest.Server.Services
{
    public interface IMongoDbService
    {
        Task<List<Item>> GetItemsAsync();
        Task<Item> GetItemByIdAsync(string id);
        Task CreateItemAsync(Item item);
        Task UpdateItemAsync(string id, Item item);
        Task DeleteItemAsync(string id);
    }
}
