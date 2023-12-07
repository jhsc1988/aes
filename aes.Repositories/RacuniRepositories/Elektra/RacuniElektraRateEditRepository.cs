using aes.Data;
using aes.Models.Racuni.Elektra;
using aes.Repositories.RacuniRepositories.IRacuniRepository.Elektra;
using Microsoft.EntityFrameworkCore;

namespace aes.Repositories.RacuniRepositories.Elektra;

public class RacuniElektraRateEditRepository : Repository<RacunElektraRateEdit>, IRacuniElektraRateEditRepository
{
    public RacuniElektraRateEditRepository(ApplicationDbContext context) : base(context) { }

#pragma warning disable CS8632 // The annotation for nullable reference types should only be used in code within a '#nullable' annotations context.
    public async Task<RacunElektraRateEdit?> GetLastRacunElektraRateEdit(string userId)
#pragma warning restore CS8632 // The annotation for nullable reference types should only be used in code within a '#nullable' annotations context.
    {
        return await Context.RacunElektraRateEdit
            .Include(e => e.RacunElektraRate)
            .Where(e => e.EditingByUserId == userId)
            .OrderByDescending(e => e.EditTime)
            .FirstOrDefaultAsync();
    }
}