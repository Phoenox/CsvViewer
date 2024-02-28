namespace CsvViewer.FluxorFeatures.CsvPagination;

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

	[ReducerMethod]
	public static State NavigateToFirstPage(State state, NavigateToFirstPageAction action)
	{
		var csvPage = Pagination.GetPage(state.CsvFile!, 0, state.PageLength);
		return state with {CsvPage = csvPage, PageIndex = 0};
	}

	[ReducerMethod]
	public static State NavigateToPreviousPage(State state, NavigateToPreviousPageAction action)
	{
		var nextPageIndex = Math.Max(state.PageIndex - 1, 0);
		var csvPage = Pagination.GetPage(state.CsvFile!, nextPageIndex, state.PageLength);
		return state with {CsvPage = csvPage, PageIndex = nextPageIndex};
	}

	[ReducerMethod]
	public static State NavigateToNextPage(State state, NavigateToNextPageAction action)
	{
		var maximumPageIndex = (int)Math.Ceiling(state.CsvFile!.Lines.Length / (double)state.PageLength) - 1;
		var nextPageIndex = Math.Min(state.PageIndex + 1, maximumPageIndex);
		var csvPage = Pagination.GetPage(state.CsvFile!, nextPageIndex, state.PageLength);
		return state with {CsvPage = csvPage, PageIndex = nextPageIndex};
	}

	[ReducerMethod]
	public static State NavigateToLastPage(State state, NavigateToLastPageAction action)
	{
		var maximumPageIndex = (int)Math.Ceiling(state.CsvFile!.Lines.Length / (double)state.PageLength) - 1;
		var csvPage = Pagination.GetPage(state.CsvFile!, maximumPageIndex, state.PageLength);
		return state with {CsvPage = csvPage, PageIndex = maximumPageIndex};
	}
}
