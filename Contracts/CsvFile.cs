namespace CsvViewer.Contracts;

public record CsvFile(string[] Headers, CsvLine[] Lines);

public record CsvPage(string[] Headers, CsvLine[] Lines, int TotalLines);

public record CsvLine(string[] Cells);
