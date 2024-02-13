namespace CsvViewer.Features.CsvPagination;

using Contracts;
using KristofferStrube.Blazor.FileSystem;

public record LoadFileAction(FileSystemFileHandle FileHandle);
public record SetFileAction(CsvFile CsvFile);
public record SetPageIndexAction(int PageIndex);
public record SetPageLengthAction(int PageLength);