namespace Core;

using CsvViewer.Contracts;

public static class CsvParser
{
	private const string CsvSeparator = ",";
	
	public static CsvFile ToCsvFile(string text)
	{
		var lines = text.Split(
				Environment.NewLine,
				StringSplitOptions.RemoveEmptyEntries);
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
