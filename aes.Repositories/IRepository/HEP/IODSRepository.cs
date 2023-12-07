using aes.Models.HEP;
using aes.Models.Racuni.Elektra;
using aes.Repositories.IRepository;

namespace aes.Repository.IRepository.HEP
{
    public interface IOdsRepository : IRepository<Ods>
    {
        Task<IEnumerable<Ods>> GetAllOds();
        Task<IEnumerable<TRacun>> GetRacuniForOmm<TRacun>(int stanId) where TRacun : Elektra;
        Task<Ods> IncludeApartment(Ods ods);
    }
}
