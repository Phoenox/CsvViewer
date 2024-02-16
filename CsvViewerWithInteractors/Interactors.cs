namespace CsvViewerWithInteractors;

using Core;
using CsvViewer.Contracts;
using CsvViewer.Providers;
using KristofferStrube.Blazor.FileSystem;

public class Interactors
{
	private CsvFile? file;

	public async Task<CsvPage> LoadCsvFile(FileSystemFileHandle fileHandle, int pageLength)
	{
		file = await FileProvider.ReadFile(fileHandle);
		return Pagination.GetPage(file, 0, pageLength);
	}

	public CsvPage LoadCsvPage(int pageIndex, int pageLength)
		=> Pagination.GetPage(file!, pageIndex, pageLength);
}
