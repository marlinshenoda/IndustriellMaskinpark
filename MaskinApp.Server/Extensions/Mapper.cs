using MaskinPark.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MaskinApp.Server;

namespace MaskinApp.Server.Extensions
{
    public static class Mapper
    {
        public static ItemTableEntity ToTableEntity(this Machine machine)
        {
            return new ItemTableEntity
            {
                Type = machine.Type,
                Location = machine.Location,
                DataTime = machine.DataTime,
                Status = machine.Status,
                PartitionKey = "todo",
                RowKey = machine.DeviceId,   
            };
        }
        public static Machine ToItem(this ItemTableEntity itemTable)
        {
            return new Machine
            {
                DeviceId = itemTable.RowKey,
                Type = itemTable.Type,
                Location = itemTable.Location,
                DataTime = itemTable.DataTime,
                Status = itemTable.Status
            };
        }
    }
}
