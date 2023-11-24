using SwarmWPF.Models.DatabaseModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repositories {
    public interface ISimulationRepository {
        Task<Simulation> FindOneSimulationAsync(string id, int round);
        Task<List<Simulation>> GetEventsByIdsAsync(string id);
        Task<bool> InsertOneAsync(Simulation simulation);
        Task<bool> DeleteOneAsync(string id);

    }
}
