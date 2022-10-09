
using MaskinPark.Shared;
namespace Maskinpark.Shared
{
    public class SeedData
    {
        public List<Machine> Machine { get; set; } = new List<Machine>()

            {
                new Machine{DeviceId = Guid.NewGuid(),Location= "Vega",DataTime=new DateTime (2016, 5, 2) ,Status = Shared.Status.Online, Type = "Old Sparky" },
                new Machine { DeviceId = Guid.NewGuid(), Location= "Vega", DataTime=new DateTime (2016, 5, 2),Status = Shared.Status.Online, Type = "New Sparky" },
                new Machine { DeviceId = Guid.NewGuid(),Location= "Stockholm",DataTime=new DateTime (2016, 5, 2), Status = Shared.Status.Offline, Type = "Old Shiny" },
                new Machine { DeviceId = Guid.NewGuid(), Location= "Stockholm",DataTime=new DateTime (2016, 5, 2), Status = Shared.Status.Offline, Type = "New Shiny" },

            };
    }
}
