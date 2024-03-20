using frontend;
using frontend.Data;
using frontend.Data.Contracts;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;
var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");
//builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("http://localhost:5202/api/") });

builder.Services.AddSingleton<ICustomerRepo,CustomerRepo>();
builder.Services.AddSingleton<ICarsRepo,CarRepo>();
builder.Services.AddSingleton<IRentRepo, RentRepo>();
builder.Services.AddMudServices();


await builder.Build().RunAsync();
