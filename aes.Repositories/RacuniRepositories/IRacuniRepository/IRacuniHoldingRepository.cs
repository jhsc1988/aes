using aes.Models;
using aes.Models.Racuni.Holding;
using aes.Repositories.IRepository;

namespace aes.Repositories.RacuniRepositories.IRacuniRepository;

public interface IRacuniHoldingRepository : IRepository<RacunHolding>
{
#pragma warning disable CS8632 // The annotation for nullable reference types should only be used in code within a '#nullable' annotations context.
    Task<Models.Stan?> GetStanBySifraObjekta(long sifraObjekta);
#pragma warning restore CS8632 // The annotation for nullable reference types should only be used in code within a '#nullable' annotations context.
    Task<IEnumerable<RacunHolding>> GetRacuni(int predmetId, int dopisId);
    Task<IEnumerable<RacunHolding>> GetRacuniForStan(int stanId);
    Task<IEnumerable<RacunHolding>> GetRacuniHoldingWithDopisiAndPredmeti();
    Task<IEnumerable<Predmet>> GetPredmetiForCreate();
    Task<IEnumerable<Dopis>> GetDopisiForPayedRacuni(int predmetId);
    Task<IEnumerable<RacunHolding>> TempList(string userId);
#pragma warning disable CS8632 // The annotation for nullable reference types should only be used in code within a '#nullable' annotations context.
    Task<RacunHolding?> IncludeAll(int id);
#pragma warning restore CS8632 // The annotation for nullable reference types should only be used in code within a '#nullable' annotations context.
}