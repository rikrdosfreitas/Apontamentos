using System;

namespace File.Import.Util.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class TextImportAttribute : Attribute
    {
        public TextImportAttribute(int position)
        {
            Position = position;
        }

        public int Position { get; }
    }
}