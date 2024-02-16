namespace Core.Tests;

public class PaginationsTests
{
	[Fact]
	public void IntegationTest()
	{
		var file = Dummies.CsvFile;
		var page = Pagination.GetPage(file, 17, 5);
		page.Should().MatchSnapshot();
	}
}
