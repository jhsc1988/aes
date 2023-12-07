using aes.Models;
using aes.Models.Racuni.Elektra;
using aes.Repository.IRepository.HEP;

namespace aes.Repository.RacuniRepositories.IRacuniRepository.Elektra;

public interface IRacuniElektraIzvrsenjeUslugeRepository : IElektraRepository<RacunElektraIzvrsenjeUsluge>
{
    Task<IEnumerable<RacunElektraIzvrsenjeUsluge>> GetRacuniElektraIzvrsenjeUslugeWithDopisiAndPredmeti();
    Task<IEnumerable<Dopis>> GetDopisiForPayedRacuniElektraIzvrsenjeUsluge(int predmetId);
    Task<IEnumerable<RacunElektraIzvrsenjeUsluge>> GetRacuniForCustomer(int kupacId);
#pragma warning disable CS8632 // The annotation for nullable reference types should only be used in code within a '#nullable' annotations context.
    Task<RacunElektraIzvrsenjeUsluge?> IncludeAll(int id);
#pragma warning restore CS8632 // The annotation for nullable reference types should only be used in code within a '#nullable' annotations context.
    Task<IEnumerable<RacunElektraIzvrsenjeUsluge>> TempList(string userId);
}