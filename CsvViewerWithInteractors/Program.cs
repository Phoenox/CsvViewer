using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using CsvViewerWithInteractors;
using KristofferStrube.Blazor.FileSystemAccess;
using Material.Blazor;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(_ => new HttpClient
		{BaseAddress = new Uri(builder.HostEnvironment.BaseAddress)});
builder.Services.AddMBServices();
builder.Services.AddFileSystemAccessService();
builder.Services.AddSingleton<Interactors>();

await builder.Build().RunAsync();
