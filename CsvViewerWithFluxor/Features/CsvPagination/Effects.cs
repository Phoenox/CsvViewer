namespace CsvViewerWithFluxor.Features.CsvPagination;

using Core;
using Fluxor;
using CsvViewer.Providers;

public static class Effects
{
	[EffectMethod]
	public static async Task LoadCsvFile(LoadFileAction action, IDispatcher dispatcher)
	{
		var fileContent = await FileProvider.ReadText(action.FileHandle);
		var csvFile = CsvParser.ToCsvFile(fileContent);
		dispatcher.Dispatch(new SetFileAction(csvFile));
	}
}
