using aes.Models.HEP;
using aes.Repositories.IRepository;

namespace aes.Repositories.IRepository.HEP
{
    public interface IOdsEditRepository : IRepository<OdsEdit>
    {
#pragma warning disable CS8632 // The annotation for nullable reference types should only be used in code within a '#nullable' annotations context.
        Task<OdsEdit?> GetLastOdsEdit(string userId);
#pragma warning restore CS8632 // The annotation for nullable reference types should only be used in code within a '#nullable' annotations context.
    }
}