using Domains;
using GenAI.Models;
using System.Reflection;

namespace GenAI
{
    public static class JsonSerializerWithSchema
    {
        public static object Serialize(string systemInstruction, string prompt, Type responseType, CreativityLevel creativityLevel = CreativityLevel.Medium)
        {
            var schema = GenerateSchema(responseType);

            var result = new
            {
                systemInstruction = new
                {
                    parts = new[]
                    {
                        new
                        {
                            text = systemInstruction,
                        }
                    }
                },
                contents = new[]
                {
                    new
                    {
                        role = "user",
                        parts = new[]
                        {
                            new { text = prompt }
                        }
                    }
                },
                generationConfig = new
                {
                    temperature = (double)creativityLevel / 100,
                    topK = 40,
                    topP = 0.95,
                    responseMimeType = "application/json",
                    responseSchema = schema
                }
            };

            return result;
        }

        private static object GenerateSchema(Type type)
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
