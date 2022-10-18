
using Maskinpark.Shared;
using System.ComponentModel.DataAnnotations;

namespace MaskinPark.Shared
{
    public class Machine
    {
        public string DeviceId { get; set; } = Guid.NewGuid().ToString("n");

        public string Location { get; set; } = string.Empty;

        public Status Status { get; set; } 

        [StringLength(5)]
        public string Type { get; set; }

        public DateTime DataTime { get; set; }
    }
}