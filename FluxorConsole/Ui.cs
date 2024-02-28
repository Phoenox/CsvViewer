namespace FluxorConsole;

using CsvViewer.FluxorFeatures.CsvPagination;
using Fluxor;

public class Ui(IState<State> state, IDispatcher dispatcher)
{
	public void Run()
	{
		SubscribeToState();
		Update();
		RunEventLoop();
	}
	
	private void SubscribeToState()
		=> state.StateChanged += (_, _) => Update();
	
	private void Update()
	{
		ClearConsole();
		PrintTable();
		PrintNavigationInformation();
		PrintCommandBar();
	}

	private static void ClearConsole()
		=> Console.Clear();

	private void PrintTable()
	{
		if (state.Value.CsvPage is not { } csvPage)
			return;

		var headerLine = string.Join(" ", csvPage.Headers);
		Console.WriteLine(headerLine);
		
		foreach (var line in csvPage.Lines)
		{
			var lineToPrint = string.Join(" ", line.Cells);
			Console.WriteLine(lineToPrint);
		}
		
		Console.WriteLine();
	}

	private void PrintNavigationInformation()
	{
		if (state.Value.CsvPage is not null)
			Console.WriteLine($"Page {state.Value.PageIndex + 1}");
	}

	private void PrintCommandBar()
	{
		const string openCommand = "<O>pen File";
		const string exitCommand = "<E>xit";
		var navigationCommands = new[] {"<F>irst Page", "<P>revious Page", "<N>extPage", "<L>ast Page"};
		var commandsToDisplay = state.Value.CsvFile is null
				? [openCommand, exitCommand]
				: new[] {openCommand}.Concat(navigationCommands).Concat([exitCommand]);
		var commandLine = string.Join(", ", commandsToDisplay);
		Console.WriteLine(commandLine);
	}

	private void RunEventLoop()
	{
		while (true)
		{
			var character = Console.ReadKey().KeyChar;
			switch (character)
			{
				case 'o':
					dispatcher.Dispatch(new ConsoleLoadFileAction("cities.csv"));
					break;
				case 'f' when IsNavigationCommandValid():
					dispatcher.Dispatch(new NavigateToFirstPageAction());
					break;
				case 'p' when IsNavigationCommandValid():
					dispatcher.Dispatch(new NavigateToPreviousPageAction());
					break;
				case 'n' when IsNavigationCommandValid():
					dispatcher.Dispatch(new NavigateToNextPageAction());
					break;
				case 'l' when IsNavigationCommandValid():
					dispatcher.Dispatch(new NavigateToLastPageAction());
					break;
				case 'e':
					return;
			}
		}

		bool IsNavigationCommandValid()
			=> state.Value.CsvFile is not null;
	}
}
