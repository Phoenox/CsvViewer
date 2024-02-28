using Fluxor;
using FluxorConsole;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = Host.CreateApplicationBuilder(args);
builder.Services.AddFluxor(o => o
		.ScanAssemblies(typeof(CsvViewer.FluxorFeatures.CsvPagination.Feature).Assembly));
builder.Services.AddSingleton<Ui>();

using var host = builder.Build();

var store = host.Services.GetService<IStore>();
await store!.InitializeAsync();

var ui = host.Services.GetService<Ui>();
ui!.Run();
