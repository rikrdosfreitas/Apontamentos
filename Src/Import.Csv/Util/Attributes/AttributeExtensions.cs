using System.Linq;
using System.Reflection;

namespace File.Import.Util.Attributes
{
    public static class AttributeExtensions
    {
        public static TextImportAttribute GetMember(this PropertyInfo propInfo)
        {
            var attributes = propInfo.GetCustomAttributes(false);
            var sheet = attributes.FirstOrDefault(a => a.GetType() == typeof(TextImportAttribute)) as TextImportAttribute;

            return sheet;
        }
    }
}