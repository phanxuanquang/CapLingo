using GenAI.Models;
using Newtonsoft.Json;
using System.Text;

namespace GenAI
{
    public static class Generator
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
                ? JsonSerializerWithSchema.Serialize(systemInstruction, prompt, responseType, creativityLevel)
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
            var responseDTO = JsonConvert.DeserializeObject<ApiResponseDto.Response>(responseData);

            return responseDTO.Candidates[0].Content.Parts[0].Text;
        }

        public static bool CanBeGeminiApiKey()
        {
            if (ApiKeyPrefix.StartsWith(ApiKey, StringComparison.OrdinalIgnoreCase) || ApiKey.StartsWith(ApiKeyPrefix, StringComparison.OrdinalIgnoreCase))
            {
                return true;
            }

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
                return false;
            }
        }

    }
}
