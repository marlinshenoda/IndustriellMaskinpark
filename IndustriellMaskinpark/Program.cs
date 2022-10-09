using IndustriellMaskinpark;
using IndustriellMaskinpark.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

//builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
//builder.Services.AddSingleton<SeedData>();
builder.Services.AddHttpClient<IToDoClient, ToDoClient>(client => client.BaseAddress = new Uri("http://localhost:7184"));
await builder.Build().RunAsync();
