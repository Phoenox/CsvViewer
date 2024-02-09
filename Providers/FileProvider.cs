namespace CsvViewer.Providers;

using Contracts;
using KristofferStrube.Blazor.FileSystem;

public static class FileProvider
{
	private const string CsvSeparator = ",";
	
	public static async Task<CsvFile> ReadFile(
			FileSystemFileHandle fileHandle)
	{
		var file = await fileHandle.GetFileAsync();
		var content = await file.TextAsync();
		var lines = content.Split(Environment.NewLine);

		var headers = lines[0].Split(CsvSeparator).ToArray();
		var csvLines = lines
				.Skip(1)
				.Select(ToCsvLine)
				.ToArray();
		return new CsvFile(headers, csvLines);

		static CsvLine ToCsvLine(string line)
		{
			var cells = line.Split(CsvSeparator);
			return new CsvLine(cells);
		}
	}
}
