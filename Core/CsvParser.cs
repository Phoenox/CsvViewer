namespace Core;

using CsvViewer.Contracts;

public static class CsvParser
{
	private const string CsvSeparator = ",";
	
	public static CsvFile ToCsvFile(string text)
	{
		var lines = text.Split(
				'\n',
				StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
		var headers = lines[0].Split(CsvSeparator, StringSplitOptions.TrimEntries).ToArray();
		var csvLines = lines
				.Skip(1)
				.Select(ToCsvLine)
				.ToArray();
		return new CsvFile(headers, csvLines);

		static CsvLine ToCsvLine(string line)
		{
			var cells = line.Split(CsvSeparator, StringSplitOptions.TrimEntries);
			return new CsvLine(cells);
		}
	}
}
