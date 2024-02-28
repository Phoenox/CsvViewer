namespace CsvViewer.FluxorFeatures.CsvPagination;

using Contracts;
using KristofferStrube.Blazor.FileSystem;

public record LoadFileAction(FileSystemFileHandle FileHandle);
public record SetFileAction(CsvFile CsvFile);
public record SetPageIndexAction(int PageIndex);
public record SetPageLengthAction(int PageLength);

public record ConsoleLoadFileAction(string FilePath);
public record NavigateToFirstPageAction;
public record NavigateToPreviousPageAction;
public record NavigateToNextPageAction;
public record NavigateToLastPageAction;