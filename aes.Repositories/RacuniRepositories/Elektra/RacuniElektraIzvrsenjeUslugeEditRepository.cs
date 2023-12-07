using aes.Data;
using aes.Models.Racuni.Elektra;
using aes.Repositories.RacuniRepositories.IRacuniRepository.Elektra;
using Microsoft.EntityFrameworkCore;

namespace aes.Repositories.RacuniRepositories.Elektra;

public class RacuniElektraIzvrsenjeUslugeEditRepository : Repository<RacunElektraIzvrsenjeUslugeEdit>, IRacuniElektraIzvrsenjeUslugeEditRepository
{
    public RacuniElektraIzvrsenjeUslugeEditRepository(ApplicationDbContext context) : base(context) { }

#pragma warning disable CS8632 // The annotation for nullable reference types should only be used in code within a '#nullable' annotations context.
    public async Task<RacunElektraIzvrsenjeUslugeEdit?> GetLastRacunElektraServiceEdit(string userId)
#pragma warning restore CS8632 // The annotation for nullable reference types should only be used in code within a '#nullable' annotations context.
    {
        return await Context.RacunElektraIzvrsenjeUslugeEdit
            .Include(e => e.RacunElektraIzvrsenjeUsluge)
            .Where(e => e.EditingByUserId == userId)
            .OrderByDescending(e => e.EditTime)
            .FirstOrDefaultAsync();
    }

}