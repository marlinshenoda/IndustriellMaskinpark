using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Collections.Generic;
using MaskinPark.Shared;
using Maskinpark.Shared;
using MaskinApp.Server.Extensions;
using Microsoft.Azure.Cosmos.Table;
using System.Linq;

namespace MaskinApp.Server
{
    public static class ToDoApi
    {
        [FunctionName("GetMachines")]
        public static async Task<IActionResult> Get(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "todo")] HttpRequest req,
               [Table("machine", Connection = "AzureWebJobsStorage")] CloudTable itemTable,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            //     string name = req.Query["name"];

            //   string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            //   dynamic data = JsonConvert.DeserializeObject(requestBody);
            //   name = name ?? data?.name;

            //  string responseMessage = string.IsNullOrEmpty(name)
            //     ? "This HTTP triggered function executed successfully. Pass a name in the query string or in the request body for a personalized response."
            //     : $"Hello, {name}. This HTTP triggered function executed successfully.";
            // var machines = GetMachines();
            var query = new TableQuery<ItemTableEntity>();
            var result = await itemTable.ExecuteQuerySegmentedAsync(query, null);

            var response = result.Select(Mapper.ToItem).ToList();
            return new OkObjectResult(JsonConvert.SerializeObject(response));
        }

        private static IEnumerable<Machine> GetMachines()
        {
            return new List<Machine>()
            {
                 new Machine{DeviceId = Guid.NewGuid().ToString(),Location= "Vega",DataTime=new DateTime (2016, 5, 2) ,Status = Status.Online, Type = "Old Sparky" },
                new Machine { DeviceId = Guid.NewGuid().ToString(), Location= "Vega", DataTime=new DateTime (2016, 5, 2),Status = Status.Online, Type = "New Sparky" },
                new Machine { DeviceId = Guid.NewGuid().ToString(),Location= "Stockholm",DataTime=new DateTime (2016, 5, 2), Status = Status.Offline, Type = "Old Shiny" },
                new Machine { DeviceId = Guid.NewGuid().ToString(), Location= "Stockholm",DataTime=new DateTime (2016, 5, 2), Status = Status.Offline, Type = "New Shiny" },

            };
        }

        //microsoft.azure .webjobs.extensions.storage version 4.0.5
        [FunctionName("CreateMachines")]
        public static async Task<IActionResult> Create(
          [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = "todo")] HttpRequest req,
        [Table("machine", Connection = "AzureWebJobsStorage")] CloudTable itemTable,//  IAsyncCollector<ItemTableEntity> itemTable,
          ILogger log)
        {
            log.LogInformation("Create item");


            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            var createItem = JsonConvert.DeserializeObject<Machine>(requestBody);

            if (createItem == null ) return new BadRequestResult();

            var machine = new Machine() 
            { 
                Status = createItem.Status,
                Type =createItem.Type ,
                Location = createItem.Location,
                DataTime = createItem.DataTime
                ,
            };

          //   await itemTable.AddAsync(machine.ToTableEntity());

           var operation = TableOperation.Insert(machine.ToTableEntity());
           var res = await itemTable.ExecuteAsync(operation);

            return new OkObjectResult(machine);
        }
    }
}
