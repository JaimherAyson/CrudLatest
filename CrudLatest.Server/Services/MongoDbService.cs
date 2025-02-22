using CrudLatest.Server.Models;
using CrudLatest.Server.Shared.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CrudLatest.Server.Services
{
    public class MongoDbService : IMongoDbService
    {
        private readonly IMongoCollection<Item> _itemsCollection;

        public MongoDbService(IOptions<MongoDbSettings> mongoDbSettings)
        {
            var mongoClient = new MongoClient(mongoDbSettings.Value.ConnectionString);
            var database = mongoClient.GetDatabase(mongoDbSettings.Value.DatabaseName);
            _itemsCollection = database.GetCollection<Item>(mongoDbSettings.Value.CollectionName);
        }

        public async Task<List<Item>> GetItemsAsync() =>
            await _itemsCollection.Find(_ => true).ToListAsync();

        public async Task<Item> GetItemByIdAsync(string id) =>
            await _itemsCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

        public async Task CreateItemAsync(Item item) =>
            await _itemsCollection.InsertOneAsync(item);

        public async Task UpdateItemAsync(string id, Item item) =>
            await _itemsCollection.ReplaceOneAsync(x => x.Id == id, item);

        public async Task DeleteItemAsync(string id) =>
            await _itemsCollection.DeleteOneAsync(x => x.Id == id);
    }
}
