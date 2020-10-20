using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using File.Import.Interfaces;
using File.Import.Util.Attributes;

namespace File.Import.Services
{
    public class FileService : IFileService
    {
        public IEnumerable<T> Import<T>(string file, char separator) where T : IImportModel
        {
            Type elementType = typeof(T);

            var list = System.IO.File.ReadAllLines(file, Encoding.Default).ToArray();
            int rowCount = list.Length;

            var columns = elementType.GetProperties()
                .Where(p => p.GetCustomAttributes(false).Any(a => a.GetType() == typeof(TextImportAttribute)))
                .ToList();

            var models = new List<T>();

            for (int row = 1; row < rowCount; row++)
            {
                var line = list[row]?.Split(separator);
                var obj = Activator.CreateInstance(elementType);

                foreach (var column in columns)
                {
                    TextImportAttribute attribute = column.GetMember();

                    var value = line?[attribute.Position]?.Trim();

                    column.SetValue(obj, value, null);
                }

                models.Add((T)obj);
            }

            return models;
        }
    }
}
