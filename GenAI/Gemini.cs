using GenAI.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Text;
using Utilities;

namespace GenAI
{
    public static class Gemini
    {
        public const string ApiKeySite = "https://aistudio.google.com/app/apikey";
        public const string ApiKeyPrefix = "AIzaSy";

        public static string ApiKey;
        private static readonly HttpClient _client = new();

        public static async Task<string> GenerateContent(string systemInstruction, string prompt, CreativityLevel creativityLevel = CreativityLevel.Medium, Type? responseType = null)
        {
            var modelName = "gemini-1.5-flash-latest";
            var endpoint = $"https://generativelanguage.googleapis.com/v1beta/models/{modelName}:generateContent?key={ApiKey}";

            var request = responseType != null
                ? BuildRequest(systemInstruction, prompt, responseType, creativityLevel)
                : new
                {
                    contents = new[]
                    {
                            new
                            {
                                parts = new[]
                                {
                                    new
                                    {
                                        text = prompt
                                    }
                                }
                            }
                        },
                    safetySettings = new[]
                    {
                            new
                            {
                                category = "HARM_CATEGORY_DANGEROUS_CONTENT",
                                threshold = "BLOCK_NONE"
                            },
                            new
                            {
                                category = "HARM_CATEGORY_HARASSMENT",
                                threshold = "BLOCK_NONE"
                            },
                            new
                            {
                                category = "HARM_CATEGORY_HATE_SPEECH",
                                threshold = "BLOCK_NONE"
                            },
                            new
                            {
                                category = "HARM_CATEGORY_SEXUALLY_EXPLICIT",
                                threshold = "BLOCK_NONE"
                            }
                        },
                    generationConfig = new
                    {
                        temperature = (double)creativityLevel / 100,
                        topP = 0.8,
                        topK = 10,
                        responseMimeType = "text/plain"
                    }
                };

            var json = JsonConvert.SerializeObject(request);

            var body = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _client.PostAsync(endpoint, body).ConfigureAwait(false);
            response.EnsureSuccessStatusCode();

            var responseData = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

            return JObject.Parse(responseData).SelectToken("$.candidates[0].content.parts[0].text")?.ToString();
        }

        public static async Task<string> GenerateContentFromVideo(string fileUri)
        {
            using var client = new HttpClient();

            var parts = new List<Part>
            {
                new() {
                    file_data = new FileData
                    {
                        mime_type = FileHelper.GetVideoMimeType(fileUri),
                        file_uri = fileUri
                    }
                }
            };

            var requestData = new
            {
                contents = new[]
                {
                    new Content
                    {
                        parts = parts
                    }
                }
            };

            var jsonContent = new StringContent(JObject.FromObject(requestData).ToString(), Encoding.UTF8, "application/json");

            var response = await client.PostAsync($"https://generativelanguage.googleapis.com/v1beta/models/gemini-1.5-flash-latest:generateContent?key={ApiKey}", jsonContent);
            var responseJson = await response.Content.ReadAsStringAsync();

            return JObject.Parse(responseJson).SelectToken("$.candidates[0].content.parts[0].text")?.ToString();
        }

        public static bool CanBeGeminiApiKey()
        {
            if (ApiKeyPrefix.StartsWith(ApiKey, StringComparison.OrdinalIgnoreCase) || ApiKey.StartsWith(ApiKeyPrefix, StringComparison.OrdinalIgnoreCase))
            {
                return true;
            }

            ApiKey = string.Empty;
            return false;
        }

        public static async Task<bool> IsValidApiKey()
        {
            try
            {
                await GenerateContent("You are my partner.", "Say 'Hello World' to me!", CreativityLevel.Low);
                return true;
            }
            catch
            {
                ApiKey = string.Empty;
                return false;
            }
        }

        public static object BuildRequest(string systemInstruction, string prompt, Type responseType, CreativityLevel creativityLevel = CreativityLevel.Medium)
        {
            var schema = JsonSerializerWithSchema.GenerateSchema(responseType);

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
    }
}
