namespace CsvViewer.Features.CsvPagination;

using Fluxor;
using Providers;

public static class Effects
{
	[EffectMethod]
	public static async Task LoadCsvFile(LoadFileAction action, IDispatcher dispatcher)
	{
		var csvFile = await FileProvider.ReadFile(action.FileHandle);
		dispatcher.Dispatch(new SetFileAction(csvFile));
	}
}
