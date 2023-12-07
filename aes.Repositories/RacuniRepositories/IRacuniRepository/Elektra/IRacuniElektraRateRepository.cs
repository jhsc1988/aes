using aes.Models;
using aes.Models.Racuni.Elektra;
using aes.Repository.IRepository.HEP;

namespace aes.aes.Repositories.RacuniRepositories.IRacuniRepository.Elektra;

public interface IRacuniElektraRateRepository : IElektraRepository<RacunElektraRate>
{
    Task<IEnumerable<RacunElektraRate>> GetRacuniElektraRateWithDopisiAndPredmeti();
    Task<IEnumerable<Dopis>> GetDopisiForPayedRacuniElektraRate(int predmetId);
    Task<IEnumerable<RacunElektraRate>> GetRacuniForCustomer(int kupacId);
#pragma warning disable CS8632 // The annotation for nullable reference types should only be used in code within a '#nullable' annotations context.
    Task<RacunElektraRate?> IncludeAll(int id);
#pragma warning restore CS8632 // The annotation for nullable reference types should only be used in code within a '#nullable' annotations context.
    Task<IEnumerable<RacunElektraRate>> TempList(string userId);
}