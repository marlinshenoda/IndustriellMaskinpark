
using Maskinpark.Shared;
using System.ComponentModel.DataAnnotations;

namespace MaskinPark.Shared
{
    public class Machine
    {
        public Guid DeviceId { get; set; } = Guid.NewGuid();

        public string Location { get; set; } = string.Empty;

        public Status Status { get; set; } = Status.Offline;

        [StringLength(5)]
        public string Type { get; set; }

        public DateTime DataTime { get; set; }
    }
}