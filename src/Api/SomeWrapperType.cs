using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;

namespace Api;

// public record struct SomeWrapperType(int Value)
// {
//     public int Value { get; } = Value;
//
//     public static bool TryParse(string? value, out SomeWrapperType result)
//     {
//         if (int.TryParse(value, out var parsed))
//         {
//             result = new SomeWrapperType(parsed);
//             return true;
//         }
//
//         result = default;
//         return false;
//     }
// }

[TypeConverter(typeof(SomeWrapperTypeTypeConverter))]
public record struct SomeWrapperType(int Value)
{
    public int Value { get; } = Value;

    public static bool TryParse(string? value, out SomeWrapperType result)
    {
        if (int.TryParse(value, out var parsed))
        {
            result = new SomeWrapperType(parsed);
            return true;
        }

        result = default;
        return false;
    }

    private class SomeWrapperTypeTypeConverter : TypeConverter
    {
        public override bool CanConvertFrom(ITypeDescriptorContext? context, Type sourceType)
            => sourceType == typeof(string) || base.CanConvertFrom(context, sourceType);

        public override object? ConvertFrom(ITypeDescriptorContext? context, CultureInfo? culture, object value)
        {
            var stringValue = value as string;
            if (TryParse(stringValue, out var result))
            {
                return result;
            }

            return base.ConvertFrom(context, culture, value);
        }
    }
}