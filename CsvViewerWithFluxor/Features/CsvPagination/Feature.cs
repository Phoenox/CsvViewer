namespace CsvViewerWithFluxor.Features.CsvPagination;

using CsvViewer.Contracts;
using Fluxor;

public record State(CsvFile? CsvFile, CsvPage? CsvPage, int PageLength, int PageIndex);

public class Feature : Feature<State>
{
	public override string GetName() => "CsvPagination";

	protected override State GetInitialState()
		=> new(null, null, 10, 0);
}
