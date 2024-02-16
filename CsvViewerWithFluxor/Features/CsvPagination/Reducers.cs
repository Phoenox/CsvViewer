namespace CsvViewerWithFluxor.Features.CsvPagination;

using Core;
using Fluxor;

public static class Reducers
{
	[ReducerMethod]
	public static State SetFile(State state, SetFileAction action)
	{
		var csvPage = Pagination.GetPage(action.CsvFile, state.PageIndex, state.PageLength);
		return state with {CsvFile = action.CsvFile, CsvPage = csvPage};
	}

	[ReducerMethod]
	public static State SetPageIndex(State state, SetPageIndexAction action) {
		var csvPage = Pagination.GetPage(state.CsvFile!, action.PageIndex, state.PageLength);
		return state with {CsvPage = csvPage, PageIndex = action.PageIndex};
	}

	[ReducerMethod]
	public static State SetPageLength(State state, SetPageLengthAction action)
	{
		var csvPage = Pagination.GetPage(state.CsvFile!, state.PageIndex, action.PageLength);
		return state with {CsvPage = csvPage, PageLength = action.PageLength};
	}
}
