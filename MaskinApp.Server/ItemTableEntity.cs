using Maskinpark.Shared;
using Microsoft.Azure.Cosmos.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaskinApp.Server
{
    public class ItemTableEntity:TableEntity
    {
        public string Location { get; set; } 

        public Status Status { get; set; }

        public string Type { get; set; }

        public DateTime DataTime { get; set; }
    }
}
