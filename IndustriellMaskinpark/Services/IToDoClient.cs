
using MaskinPark.Shared;

namespace IndustriellMaskinpark.Services
{
    public interface IToDoClient
    {
        Task<IEnumerable<Machine>?> GetAsync();
        Task<Machine?> PostAsync(Machine machine);

        Task<bool> RemoveAsync(string id);
    }
}