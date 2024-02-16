namespace Core.Tests;

using CsvViewer.Contracts;

public static class Dummies
{
	public static CsvFile CsvFile
	{
		get
		{
			var lines = Enumerable.Range(0, 100)
					.Select(i => new CsvLine([i.ToString(), i.ToString(), i.ToString()]))
					.ToArray();
			return new CsvFile(
					Headers: ["foo", "bar", "bla"],
					Lines: lines);
		}
	}
}
