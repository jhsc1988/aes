using aes.Models.Racuni.Elektra;
using aes.Repositories.IRepository;
using System.Threading.Tasks;

namespace aes.Repositories.RacuniRepositories.IRacuniRepository.Elektra
{
    public interface IRacuniElektraEditRepository : IRepository<RacunElektraEdit>
    {
#nullable enable
        Task<RacunElektraEdit?> GetLastRacunElektraEdit(string userId);
    }
}