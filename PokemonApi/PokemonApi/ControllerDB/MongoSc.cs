using Microsoft.Extensions.Options;
using MongoDB.Driver;
using PokemonApi.BaseDatos;
using PokemonApi.Objetos;

namespace PokemonApi.ControllerDB
{
    public class MongoSc
    {
        private readonly IMongoCollection<Pokemon> items;
        public MongoSc(IOptions<DBSettings> mongoDbSettings)
        {
            var mongoClient = new MongoClient(
                mongoDbSettings.Value.ConnectionUrl);

            var mongoDatabase = mongoClient.GetDatabase(
                mongoDbSettings.Value.DatabaseName);

            items = mongoDatabase.GetCollection<Pokemon>("Pokemon");
        }

        public async Task<Pokemon> GetAsyncById(string id) => await items.Find(pk=> pk.id == id).FirstOrDefaultAsync();
        public async Task<Pokemon> GetFirstAsync() => await items.Find(pk => true).FirstOrDefaultAsync();
        public async Task<List<Pokemon>> GetAllByTypeAsync(string tipo) => await items.Find(pk => pk.tipo == tipo).ToListAsync();
        public async Task CreateAsync(Pokemon pk) => await items.InsertOneAsync(pk);
        public async Task CreateManyAsync(List<Pokemon> pks) => await items.InsertManyAsync(pks);
        public async Task UpdateAsync(string id, Pokemon pk) => await items.ReplaceOneAsync(pk=> pk.id == id, pk);
        public async Task DeleteAsync(string id) => await items.DeleteOneAsync(pk=> pk.id == id);

    }
}
