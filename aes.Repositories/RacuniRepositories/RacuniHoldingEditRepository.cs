using aes.aes.Repositories.RacuniRepositories.IRacuniRepository;
using aes.Data;
using aes.Models.Racuni.Holding;
using aes.Repositories.RacuniRepositories.IRacuniRepository;
using aes.Repository;
using Microsoft.EntityFrameworkCore;

namespace aes.Repositories.RacuniRepositories;

public class RacuniHoldingEditRepository : Repository<RacunHoldingEdit>, IRacuniHoldingEditRepository
{
    public RacuniHoldingEditRepository(ApplicationDbContext context) : base(context) { }

#pragma warning disable CS8632 // The annotation for nullable reference types should only be used in code within a '#nullable' annotations context.
    public async Task<RacunHoldingEdit?> GetLastRacunHoldingEdit(string userId)
#pragma warning restore CS8632 // The annotation for nullable reference types should only be used in code within a '#nullable' annotations context.
    {
        return await Context.RacunHoldingEdit
            .Include(e => e.RacunHolding)
            .Where(e => e.EditingByUserId == userId)
            .OrderByDescending(e => e.EditTime)
            .FirstOrDefaultAsync();
    }
}