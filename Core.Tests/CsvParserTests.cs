namespace Core.Tests;

public class CsvParserTests
{
	[Fact]
	public void ParsesCsvContent()
	{
		var csvFile = CsvParser.ToCsvFile(Dummies.CsvFileContent);
		csvFile.Should().MatchSnapshot();
	}
}
