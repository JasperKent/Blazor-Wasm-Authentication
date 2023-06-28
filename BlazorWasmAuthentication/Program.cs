using BlazorWasmAuthentication;
using BlazorWasmAuthentication.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.Configuration["ServerUrl"] ?? "") });
builder.Services.AddScoped<IReviewRepository, ReviewRepository>();

await builder.Build().RunAsync();
