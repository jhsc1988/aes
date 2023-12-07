using aes.Models.HEP;
using aes.Models.Racuni.Elektra;
using aes.Repositories.IRepository;

namespace aes.Repository.IRepository.HEP
{
    public interface IElektraRepository<T> : IRepository<T> where T : Elektra
    {
        Task<ElektraKupac> GetKupacByUgovorniRacun(long uRacun);
        Task<IEnumerable<T>> GetRacuni(int predmetId, int dopisId);
        Task<IEnumerable<T>> GetRacuniTemp(string userId);
    }
}
