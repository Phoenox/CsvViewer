namespace CsvViewer.Providers;

using KristofferStrube.Blazor.FileSystem;

public static class FileProvider
{
	public static async Task<string> ReadText(FileSystemFileHandle fileHandle)
	{
		var file = await fileHandle.GetFileAsync();
		return await file.TextAsync();
	}
}
