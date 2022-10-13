using Blazored.LocalStorage;
using HearthStoneForum.Client;
using HearthStoneForum.Client.Service;
using HearthStoneForum.Client.Shared;
using HearthStoneForum.Client.Utility;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7153/api/") });
builder.Services.AddMasaBlazor();
builder.Services.AddBlazoredLocalStorage();
builder.Services.AddAuthorizationCore();
builder.Services.AddScoped<AuthenticationStateProvider, ApiAuthenticationStateProvider>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<MainLayoutState>();
builder.Services.AddScoped<SearchState>();

await builder.Build().RunAsync();
