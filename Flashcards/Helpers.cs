using System.ComponentModel;
using System.Reflection;

namespace Flashcards;
internal static class Helpers
{
    internal static string? GetEnumDescription(Enum value)
    {
        if (value == null) return "";

        var field = value.GetType().GetField(value.ToString());
        var attribute = field?.GetCustomAttribute<DescriptionAttribute>();
        var attrDescription = attribute?.Description;

        return attrDescription ?? value.ToString();
    }
}
