using aes.Data;
using aes.Models.Racuni.Elektra;
using aes.Repositories.RacuniRepositories.IRacuniRepository.Elektra;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace aes.Repositories.RacuniRepositories.Elektra
{
    public class RacuniElektraIzvrsenjeUslugeEditRepository : Repository<RacunElektraIzvrsenjeUslugeEdit>, IRacuniElektraIzvrsenjeUslugeEditRepository
    {
        public RacuniElektraIzvrsenjeUslugeEditRepository(ApplicationDbContext context) : base(context) { }

#nullable enable
        public async Task<RacunElektraIzvrsenjeUslugeEdit?> GetLastRacunElektraServiceEdit(string userId)
#nullable disable
        {
            return await Context.RacunElektraIzvrsenjeUslugeEdit
                .Include(e => e.RacunElektraIzvrsenjeUsluge)
                .Where(e => e.EditingByUserId == userId)
                .OrderByDescending(e => e.EditTime)
                .FirstOrDefaultAsync();
        }

    }
}