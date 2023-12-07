using aes.Models.Racuni.Holding;
using aes.Repositories.IRepository;

namespace aes.Repositories.RacuniRepositories.IRacuniRepository;

public interface IRacuniHoldingEditRepository : IRepository<RacunHoldingEdit>
{
#pragma warning disable CS8632 // The annotation for nullable reference types should only be used in code within a '#nullable' annotations context.
    Task<RacunHoldingEdit?> GetLastRacunHoldingEdit(string userId);
#pragma warning restore CS8632 // The annotation for nullable reference types should only be used in code within a '#nullable' annotations context.
}