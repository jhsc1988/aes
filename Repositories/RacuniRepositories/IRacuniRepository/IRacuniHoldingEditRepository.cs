using aes.Models.Racuni.Holding;
using aes.Repositories.IRepository;
using System.Threading.Tasks;

namespace aes.Repositories.RacuniRepositories.IRacuniRepository
{
    public interface IRacuniHoldingEditRepository : IRepository<RacunHoldingEdit>
    {
#nullable enable
        Task<RacunHoldingEdit?> GetLastRacunHoldingEdit(string userId);
    }
}