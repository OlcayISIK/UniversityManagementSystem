using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using UMS.Client.Business.Interface.Shared;
using UMS.Client.Business.Shared;
using UMS.Client.Main;
using MudBlazor.Services;
using UMS.Client.Business.StudentService;
using UMS.Client.Business.Interface.StudentService;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.Services.AddMudServices();
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddScoped<ILocalStorageService, LocalStorageService>()
    .AddScoped<IHttpService, HttpService>()
    .AddScoped<IAuthenticationService, AuthenticationService>()
    .AddScoped<IStudentService, StudentService>()
    .AddScoped<IChatService, ChatService>()
    .AddScoped<IUniversityService, UniversityService>();


builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("http://localhost:5005") });

var authenticationService = builder.Build().Services.GetRequiredService<IAuthenticationService>();
await authenticationService.Initialize();

await builder.Build().RunAsync();
