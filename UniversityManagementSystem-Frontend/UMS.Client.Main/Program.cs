using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using UMS.Client.Business.Interface.Shared;
using UMS.Client.Business.Shared;
using UMS.Client.Main;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddScoped<ILocalStorageService, LocalStorageService>()
    .AddScoped<IHttpService, HttpService>();

await builder.Build().RunAsync();
