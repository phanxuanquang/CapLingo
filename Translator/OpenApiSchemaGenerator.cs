using Newtonsoft.Json;
using System.Collections;
using System.Reflection;
using Translator.Models;
using Formatting = Newtonsoft.Json.Formatting;

namespace Translator
{
    public static class OpenApiSchemaGenerator
    {
        public static string GenerateSchema(Type type)
        {
            var schema = new Dictionary<string, object>
            {
                ["type"] = "object",
                ["properties"] = GenerateProperties(type),
                ["required"] = GetRequiredProperties(type)
            };

            return JsonConvert.SerializeObject(new { responseSchema = schema }, Formatting.Indented);
        }

        private static Dictionary<string, object> GenerateProperties(Type type)
        {
            var properties = new Dictionary<string, object>();

            foreach (var property in type.GetProperties())
            {
                var propertyType = property.PropertyType;

                // Kiểm tra kiểu dữ liệu và ánh xạ sang OpenAPI schema
                properties[property.Name] = MapTypeToSchema(propertyType);
            }

            return properties;
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
                    @enum = Enum.GetNames(propertyType) // Lấy danh sách giá trị enum
                };
            }
            else if (propertyType.IsArray || typeof(IEnumerable).IsAssignableFrom(propertyType) && propertyType != typeof(string))
            {
                // Mảng hoặc danh sách
                var elementType = propertyType.IsArray ? propertyType.GetElementType() : propertyType.GetGenericArguments().FirstOrDefault();
                return new
                {
                    type = "array",
                    items = MapTypeToSchema(elementType)
                };
            }
            else if (propertyType.IsClass && propertyType != typeof(string))
            {
                // Đối tượng phức tạp
                return new
                {
                    type = "object",
                    properties = GenerateProperties(propertyType),
                    required = GetRequiredProperties(propertyType)
                };
            }
            else
            {
                // Kiểu dữ liệu không xác định, giả sử là chuỗi
                return new { type = "string" };
            }
        }

        private static List<string> GetRequiredProperties(Type type)
        {
            // Lấy danh sách các thuộc tính được đánh dấu là required
            return type.GetProperties()
                       .Where(p => p.GetCustomAttribute<RequiredAttribute>() != null)
                       .Select(p => p.Name)
                       .ToList();
        }
    }

}
