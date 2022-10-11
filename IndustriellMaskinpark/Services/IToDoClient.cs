
using MaskinPark.Shared;

namespace IndustriellMaskinpark.Services
{
    public interface IToDoClient
    {
        Task<IEnumerable<Machine>?> GetAsync();
        Task<Machine?> PostAsync(Machine createMachine);

        Task<bool> RemoveAsync(string id);
    }
}