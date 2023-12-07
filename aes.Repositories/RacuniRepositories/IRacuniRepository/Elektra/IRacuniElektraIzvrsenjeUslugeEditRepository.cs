using aes.Models.Racuni.Elektra;
using aes.Repositories.IRepository;

namespace aes.Repositories.RacuniRepositories.IRacuniRepository.Elektra;

public interface IRacuniElektraIzvrsenjeUslugeEditRepository : IRepository<RacunElektraIzvrsenjeUslugeEdit>
{
#pragma warning disable CS8632 // The annotation for nullable reference types should only be used in code within a '#nullable' annotations context.
    Task<RacunElektraIzvrsenjeUslugeEdit?> GetLastRacunElektraServiceEdit(string userId);
#pragma warning restore CS8632 // The annotation for nullable reference types should only be used in code within a '#nullable' annotations context.
}