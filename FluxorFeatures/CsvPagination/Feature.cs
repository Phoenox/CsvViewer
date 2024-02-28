namespace CsvViewer.FluxorFeatures.CsvPagination;

using Contracts;
using Fluxor;

public record State(CsvFile? CsvFile, CsvPage? CsvPage, int PageLength, int PageIndex);

public class Feature : Feature<State>
{
	public override string GetName() => "CsvPagination";

	protected override State GetInitialState()
		=> new(null, null, 10, 0);
}
