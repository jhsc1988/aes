using aes.Models;

namespace aes.Repositories.IRepository
{
    public interface IStanUpdateRepository : IRepository<StanUpdate>
    {
#pragma warning disable CS8632 // The annotation for nullable reference types should only be used in code within a '#nullable' annotations context.
        StanUpdate? GetLatestAsync();
#pragma warning restore CS8632 // The annotation for nullable reference types should only be used in code within a '#nullable' annotations context.
#pragma warning disable CS8632 // The annotation for nullable reference types should only be used in code within a '#nullable' annotations context.
        StanUpdate? GetLatestSuccessfulUpdateAsync();
#pragma warning restore CS8632 // The annotation for nullable reference types should only be used in code within a '#nullable' annotations context.
    }
}