using aes.Models.Racuni.Elektra;
using aes.Repositories.IRepository;
using System.Threading.Tasks;

namespace aes.Repositories.RacuniRepositories.IRacuniRepository.Elektra
{
    public interface IRacuniElektraIzvrsenjeUslugeEditRepository : IRepository<RacunElektraIzvrsenjeUslugeEdit>
    {
#nullable enable
        Task<RacunElektraIzvrsenjeUslugeEdit?> GetLastRacunElektraServiceEdit(string userId);
    }
}