using aes.Models.HEP;
using System.Threading.Tasks;

namespace aes.Repositories.IRepository.HEP
{
    public interface IElektraKupacEditRepository : IRepository<ElektraKupacEdit>
    {
        Task<ElektraKupacEdit> GetLastElektraKupacEdit(string userId);
    }
}