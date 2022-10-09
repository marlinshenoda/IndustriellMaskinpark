
using Maskinpark.Shared;

namespace MaskinPark.Shared
{
    public class Machine
    {
        public Guid DeviceId { get; set; } = Guid.NewGuid();

        public string Location { get; set; } = string.Empty;

        public Status Status { get; set; } = Status.Offline;

        public string Type { get; set; }

        public DateTime DataTime { get; set; }
    }
}