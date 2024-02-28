namespace CsvViewer.FluxorFeatures.CsvPagination;

using Core;
using Fluxor;
using Providers;

public static class Effects
{
	[EffectMethod]
	public static async Task LoadCsvFile(LoadFileAction action, IDispatcher dispatcher)
	{
		var fileContent = await FileProvider.ReadText(action.FileHandle);
		var csvFile = CsvParser.ToCsvFile(fileContent);
		dispatcher.Dispatch(new SetFileAction(csvFile));
	}

	[EffectMethod]
	public static Task LoadCsvFileForConsole(ConsoleLoadFileAction action, IDispatcher dispatcher)
	{
		var fileContent = FileProvider.ReadText(action.FilePath);
		var csvFile = CsvParser.ToCsvFile(fileContent);
		dispatcher.Dispatch(new SetFileAction(csvFile));
		return Task.CompletedTask;
	}
}
