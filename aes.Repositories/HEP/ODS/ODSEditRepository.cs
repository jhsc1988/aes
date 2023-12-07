using aes.Data;
using aes.Models.HEP;
using aes.Repositories.IRepository.HEP;
using aes.Repository;
using aes.Repository.IRepository.HEP;
using Microsoft.EntityFrameworkCore;

namespace aes.Repositories.HEP.ODS
{
    public class OdsEditRepository : Repository<OdsEdit>, IOdsEditRepository
    {
        public OdsEditRepository(ApplicationDbContext context) : base(context) { }
#pragma warning disable CS8632 // The annotation for nullable reference types should only be used in code within a '#nullable' annotations context.
        public async Task<OdsEdit?> GetLastOdsEdit(string userId)
#pragma warning restore CS8632 // The annotation for nullable reference types should only be used in code within a '#nullable' annotations context.
        {
            return await Context.OdsEdit
                .Include(e => e.Ods)
                .Where(e => e.EditingByUserId == userId)
                .OrderByDescending(e => e.EditTime)
                .FirstOrDefaultAsync();
        }
    }
}
