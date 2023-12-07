using aes.Models;
using aes.Models.Racuni;
using aes.Repositories.IRepository;

namespace aes.Repository.IRepository
{
    public interface IPredmetRepository : IRepository<Predmet>
    {
        IEnumerable<Predmet> GetPredmetForAllPaidRacuni(IEnumerable<Racun> racuni);
    }
}