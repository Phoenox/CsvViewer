namespace CsvViewer;

using Contracts;
using Core;
using KristofferStrube.Blazor.FileSystem;
using Providers;

public class Interactors : IInteractors
{
	private CsvFile? csvFile;
	
	public async Task<CsvPage> LoadFile(FileSystemFileHandle fileHandle, int pageLength)
	{
		csvFile = await FileProvider.ReadFile(fileHandle);
		return Pagination.GetPage(csvFile, 1, pageLength);
	}
}
