using Blazored.LocalStorage;
using HearthStoneForum.Client;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7153/api/") });
builder.Services.AddMasaBlazor();
builder.Services.AddBlazoredLocalStorage();

await builder.Build().RunAsync();
