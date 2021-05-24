using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Markup;

namespace Lab.UI.Utility
{
    public class EnumBindingExtension : MarkupExtension
    {
        public Type EnumType { get; private set; }
        public EnumBindingExtension(Type enumType)
        {
            if (enumType==null || !enumType.IsEnum)
            {
                throw new Exception($"{enumType} is not an enum");
            }
            EnumType = enumType;
        }
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return Enum.GetValues(EnumType);
        }
    }
}
