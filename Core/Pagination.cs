namespace Core;

using CsvViewer.Contracts;

public static class Pagination
{
	public static CsvPage GetPage(CsvFile file, int pageIndex, int pageLength)
	{
		var startIndex = pageIndex * pageLength;
		var endIndex = startIndex + pageLength;
		var pageLines = file.Lines.Take(new Range(startIndex, endIndex)).ToArray();
		return new CsvPage(file.Headers, pageLines, file.Lines.Length);
	}
}
