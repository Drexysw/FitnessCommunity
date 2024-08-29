namespace FitnessCommunity.Domain.Abstractions
{
    public interface IUnitOfWork
    {
        Task SaveChangesAsync();
    }
}
