
namespace IndustriellMaskinpark.Services
{
    public interface IToDoClient
    {
        Task<bool> RemoveAsync(string id);
    }
}