namespace Core.Tests;

public class PaginationsTests
{
	[Fact]
	public void IntegrationTest()
	{
		var file = Dummies.CsvFile;
		var page = Pagination.GetPage(file, 17, 5);
		page.Should().MatchSnapshot();
	}
}
