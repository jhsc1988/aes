using aes.Models.Racuni.Elektra;
using aes.Repositories.IRepository;

namespace aes.Repositories.RacuniRepositories.IRacuniRepository.Elektra;

public interface IRacuniElektraEditRepository : IRepository<RacunElektraEdit>
{
#pragma warning disable CS8632 // The annotation for nullable reference types should only be used in code within a '#nullable' annotations context.
    Task<RacunElektraEdit?> GetLastRacunElektraEdit(string userId);
#pragma warning restore CS8632 // The annotation for nullable reference types should only be used in code within a '#nullable' annotations context.
}