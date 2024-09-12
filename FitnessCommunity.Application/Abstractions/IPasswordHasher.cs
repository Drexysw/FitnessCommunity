namespace FitnessCommunity.Application.Abstractions
{
    public interface IPasswordHasher
    {
        string Hash(string password);
        bool VerifyPassword(string hash, string password);
    }
}
