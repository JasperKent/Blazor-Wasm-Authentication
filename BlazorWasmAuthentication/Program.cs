using Blazored.SessionStorage;
using BlazorWasmAuthentication;
using BlazorWasmAuthentication.Handlers;
using BlazorWasmAuthentication.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddTransient<AuthenticationHandler>();

builder.Services.AddHttpClient("ServerApi")
                .ConfigureHttpClient(c => c.BaseAddress = new Uri(builder.Configuration["ServerUrl"] ?? ""))
                .AddHttpMessageHandler<AuthenticationHandler>();

builder.Services.AddScoped<IReviewRepository, ReviewRepository>();
builder.Services.AddSingleton<IAuthenticationService, AuthenticationService>();

builder.Services.AddBlazoredSessionStorageAsSingleton();

await builder.Build().RunAsync();
