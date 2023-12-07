using aes.Data;
using aes.Models.HEP;
using aes.Repositories.IRepository.HEP;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace aes.Repositories.HEP.ODS
{
    public class OdsEditRepository : Repository<OdsEdit>, IOdsEditRepository
    {
        public OdsEditRepository(ApplicationDbContext context) : base(context) { }
#nullable enable
        public async Task<OdsEdit?> GetLastOdsEdit(string userId)
#nullable disable
        {
            return await Context.OdsEdit
                .Include(e => e.Ods)
                .Where(e => e.EditingByUserId == userId)
                .OrderByDescending(e => e.EditTime)
                .FirstOrDefaultAsync();
        }
    }
}
