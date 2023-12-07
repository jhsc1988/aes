using aes.Models.Racuni.Elektra;
using aes.Repositories.IRepository;
using System.Threading.Tasks;

namespace aes.Repositories.RacuniRepositories.IRacuniRepository.Elektra
{
    public interface IRacuniElektraRateEditRepository : IRepository<RacunElektraRateEdit>
    {
#nullable enable
        Task<RacunElektraRateEdit?> GetLastRacunElektraRateEdit(string userId);
    }
}