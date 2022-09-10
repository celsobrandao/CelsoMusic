namespace CelsoMusic.Infra.Storage.Interfaces
{
    public interface IStorage
    {
        Task<string> Upload(string imageUrl);
    }
}
