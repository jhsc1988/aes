using aes.Models.HEP;
using System.Threading.Tasks;

namespace aes.Repositories.IRepository.HEP
{
    public interface IOdsEditRepository : IRepository<OdsEdit>
    {
#nullable enable
        Task<OdsEdit?> GetLastOdsEdit(string userId);
    }
}