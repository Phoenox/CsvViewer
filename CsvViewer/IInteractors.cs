namespace CsvViewer;

using Contracts;
using KristofferStrube.Blazor.FileSystem;

public interface IInteractors
{
	Task<CsvPage> LoadFile(FileSystemFileHandle fileHandle, int pageLength);
}
