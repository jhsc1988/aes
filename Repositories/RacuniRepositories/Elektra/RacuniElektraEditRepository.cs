using aes.Data;
using aes.Models.Racuni.Elektra;
using aes.Repositories.RacuniRepositories.IRacuniRepository.Elektra;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace aes.Repositories.RacuniRepositories.Elektra
{
    public class RacuniElektraEditRepository : Repository<RacunElektraEdit>, IRacuniElektraEditRepository
    {
        public RacuniElektraEditRepository(ApplicationDbContext context) : base(context) { }

#nullable enable
        public async Task<RacunElektraEdit?> GetLastRacunElektraEdit(string userId)
        {
            return await Context.RacunElektraEdit
                .Include(e => e.RacunElektra)
                .Where(e => e.EditingByUserId == userId)
                .OrderByDescending(e => e.EditTime)
                .FirstOrDefaultAsync();
        }
    }
}