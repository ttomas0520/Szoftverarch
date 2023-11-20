using Microsoft.Extensions.Options;
using Models;
using MongoDB.Bson;
using MongoDB.Driver;
using Repositories;

namespace Swarm.Repositories {
    internal class SimulationRepository : ISimulationRepository {
        private readonly IMongoCollection<Simulation> _simulations;

        public SimulationRepository(IOptions<DatabaseSettings> dbConfig) {
            var client = new MongoClient("mongodb://localhost:27017");
            var database = client.GetDatabase("SwarmDb");
            _simulations = database.GetCollection<Simulation>("Simulations");
        }
        public async Task<bool> DeleteOneAsync(string id) {
            try {
                await _simulations.DeleteOneAsync(ev => ev.Id == ObjectId.Parse(id));
                return true;
            }
            catch (Exception e) {
                Console.WriteLine($"Error removing: {e.Message}");
                return false;
            }
        }

        public async Task<Simulation> FindOneSimulationAsync(string id, int round) {
            try {
                var filterBuilder = Builders<Simulation>.Filter;
                var filters = new List<FilterDefinition<Simulation>>();
                filters.Add(filterBuilder.Eq(e => e.Id, ObjectId.Parse(id)));
                filters.Add(filterBuilder.Eq(e => e.Round, round));
                var combinedFilter = filterBuilder.And(filters);
                return await _simulations.Find(combinedFilter).SingleOrDefaultAsync();
            }
            catch (Exception e) {
                Console.WriteLine($"Error removing participant: {e.Message}");
            }
            return null;
        }

        public async Task<List<Simulation>> GetEventsByIdsAsync(string id) {
            var filter = Builders<Simulation>.Filter.Eq(ev => ev.Id, ObjectId.Parse(id));
            return await _simulations.Find(filter).ToListAsync();
        }

        public async Task<bool> InsertOneAsync(Simulation simulation) {
            await _simulations.InsertOneAsync(simulation);
            return true;
        }
    }
}
