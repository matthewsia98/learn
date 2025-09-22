using System.Reflection;

namespace Expressions.Extensions;

public static class TypeExtensions
{
    public static PropertyInfo GetNestedProperty(this Type type, string propertyPath)
    {
        var parts = propertyPath.Split(".");

        PropertyInfo? result = default;
        var currType = type;
        foreach (var part in parts)
        {
            result = currType.GetProperty(part);
            if (result is null)
            {
                throw new Exception($"{part} does not exist on type {currType}");
            }
            currType = result.PropertyType;
        }

        return result!;
    }
}
