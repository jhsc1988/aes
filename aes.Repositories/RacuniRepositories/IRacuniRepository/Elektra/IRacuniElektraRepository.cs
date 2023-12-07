using aes.Models;
using aes.Models.Racuni.Elektra;
using aes.Repository.IRepository.HEP;

namespace aes.aes.Repositories.RacuniRepositories.IRacuniRepository.Elektra;

public interface IRacuniElektraRepository : IElektraRepository<RacunElektra>
{
    Task<IEnumerable<RacunElektra>> TempList(string userId);
    Task<IEnumerable<RacunElektra>> GetRacuniElektraWithDopisiAndPredmeti();
    Task<IEnumerable<Predmet>> GetPredmetiForCreate();
    Task<IEnumerable<Dopis>> GetDopisiForPayedRacuniElektra(int predmetId);
#pragma warning disable CS8632 // The annotation for nullable reference types should only be used in code within a '#nullable' annotations context.
    Task<RacunElektra?> IncludeAll(int id);
#pragma warning restore CS8632 // The annotation for nullable reference types should only be used in code within a '#nullable' annotations context.
    Task<IEnumerable<RacunElektra>> GetRacuniForCustomer(int kupacId);
}