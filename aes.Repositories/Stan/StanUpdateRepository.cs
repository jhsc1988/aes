using aes.Data;
using aes.Models;
using aes.Repositories.IRepository;

namespace aes.Repositories.Stan;

public class StanUpdateRepository : Repository<StanUpdate>, IStanUpdateRepository
{
    public StanUpdateRepository(ApplicationDbContext context) : base(context) { }

    /// <summary>
    /// Gets the latest StanUpdate based on when the update began.
    /// </summary>
    /// <returns>The most recently started StanUpdate.</returns>
#pragma warning disable CS8632 // The annotation for nullable reference types should only be used in code within a '#nullable' annotations context.
    public StanUpdate? GetLatestAsync()
#pragma warning restore CS8632 // The annotation for nullable reference types should only be used in code within a '#nullable' annotations context.
    {
        return Context.StanUpdate
                .OrderByDescending(e => e.UpdateBegan)
                .FirstOrDefault();
    }

    /// <summary>
    /// Gets the latest 'successful' StanUpdate based on DateOfData.
    /// A successful update here is assumed to be the latest by DateOfData.
    /// </summary>
    /// <returns>The StanUpdate with the most recent DateOfData.</returns>
#pragma warning disable CS8632 // The annotation for nullable reference types should only be used in code within a '#nullable' annotations context.
    public StanUpdate? GetLatestSuccessfulUpdateAsync()
#pragma warning restore CS8632 // The annotation for nullable reference types should only be used in code within a '#nullable' annotations context.
    {
        return Context.StanUpdate
            .OrderByDescending(e => e.DateOfData)
            .FirstOrDefault();
    }
}
