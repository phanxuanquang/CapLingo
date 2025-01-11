using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace Utilities
{
    public class JsonSerializerWithSchema
    {
        public static object GenerateSchema(Type type)
        {
            return new
            {
                type = "object",
                properties = GenerateProperties(type),
                required = GetRequiredProperties(type)
            };
        }

        private static object GenerateProperties(Type type)
        {
            return type.GetProperties().ToDictionary(
                property => property.Name,
                property => MapTypeToSchema(property.PropertyType)
            );
        }

        private static object MapTypeToSchema(Type propertyType)
        {
            if (propertyType == typeof(string))
            {
                return new { type = "string" };
            }
            else if (propertyType == typeof(int))
            {
                return new { type = "integer" };
            }
            else if (propertyType == typeof(long) || propertyType == typeof(float) || propertyType == typeof(double) || propertyType == typeof(decimal))
            {
                return new { type = "number" };
            }
            else if (propertyType == typeof(bool))
            {
                return new { type = "boolean" };
            }
            else if (propertyType.IsEnum)
            {
                return new
                {
                    type = "string",
                    @enum = Enum.GetNames(propertyType)
                };
            }
            else if (propertyType.IsArray || typeof(IEnumerable<>).IsAssignableFrom(propertyType))
            {
                var elementType = propertyType.IsArray ? propertyType.GetElementType() : propertyType.GetGenericArguments().FirstOrDefault();
                return new
                {
                    type = "array",
                    items = MapTypeToSchema(elementType)
                };
            }
            else if (propertyType.IsClass && propertyType != typeof(string))
            {
                return new
                {
                    type = "object",
                    properties = GenerateProperties(propertyType),
                    required = GetRequiredProperties(propertyType)
                };
            }
            else
            {
                return new { type = "string" };
            }
        }

        private static List<string> GetRequiredProperties(Type type)
        {
            return type.GetProperties()
                       .Where(p => p.GetCustomAttribute<RequiredAttribute>() != null)
                       .Select(p => p.Name)
                       .ToList();
        }
    }
}
