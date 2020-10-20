using System.Collections.Generic;

namespace File.Import.Interfaces
{
    public interface IFileService
    {
        IEnumerable<T> Import<T>(string file, char separator) where T : IImportModel;
    }
}