using aes.Data;
using aes.Models.Racuni.Elektra;
using aes.Repositories.RacuniRepositories.IRacuniRepository.Elektra;
using Microsoft.EntityFrameworkCore;

namespace aes.Repositories.RacuniRepositories.Elektra;

public class RacuniElektraEditRepository : Repository<RacunElektraEdit>, IRacuniElektraEditRepository
{
    public RacuniElektraEditRepository(ApplicationDbContext context) : base(context) { }

#pragma warning disable CS8632 // The annotation for nullable reference types should only be used in code within a '#nullable' annotations context.
    public async Task<RacunElektraEdit?> GetLastRacunElektraEdit(string userId)
#pragma warning restore CS8632 // The annotation for nullable reference types should only be used in code within a '#nullable' annotations context.
    {
        return await Context.RacunElektraEdit
            .Include(e => e.RacunElektra)
            .Where(e => e.EditingByUserId == userId)
            .OrderByDescending(e => e.EditTime)
            .FirstOrDefaultAsync();
    }
}