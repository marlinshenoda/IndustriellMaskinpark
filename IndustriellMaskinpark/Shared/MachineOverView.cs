using Maskinpark.Shared;
using Microsoft.AspNetCore.Components;

namespace IndustriellMaskinpark.Shared
{
    public partial class MachineOverView: ComponentBase
    {
        [Inject]
        public SeedData SeedData { get; set; }
    }
}
