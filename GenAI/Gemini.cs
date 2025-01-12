using GenAI.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Text;
using Utilities;

namespace GenAI
{
    public static class Gemini
    {
        private const string BaseUrl = "https://generativelanguage.googleapis.com";
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

        public static async Task<string> GenerateContentFromVideo(string systemInstruction, string prompt, string videoUri, string mimeType, CreativityLevel creativityLevel = CreativityLevel.Medium, Type? responseType = null)
        {
            using var client = new HttpClient();

            var requestData = new ApiRequest.Root
            {
                SystemInstruction = new ApiRequest.SystemInstruction
                {
                    Parts =
                    [
                        new ApiRequest.Part
                        {
                            Text = systemInstruction
                        }
                    ]
                },
                Contents =
                [
                    new ApiRequest.Content
                    {
                        Role = "user",
                        Parts =
                        [
                            new ApiRequest.Part
                            {
                                FileData = new ApiRequest.FileData
                                {
                                    FileUri = videoUri,
                                    MimeType = mimeType
                                }
                            }
                        ]
                    },
                    new ApiRequest.Content
                    {
                        Role = "user",
                        Parts =
                        [
                            new ApiRequest.Part
                            {
                                Text = prompt
                            }
                        ]
                    },
                ],
                GenerationConfig = new ApiRequest.GenerationConfig
                {
                    Temperature = (double)creativityLevel / 100.0D,
                    TopK = 40,
                    TopP = 0.95,
                    MaxOutputTokens = 8192,
                    ResponseMimeType = "application/json"
                }
            };

            var payload = JsonConvert.SerializeObject(requestData);

            var jsonContent = new StringContent(payload, Encoding.UTF8, "application/json");

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

        public static async Task<string> InitiateResumableUpload(string videoPath)
        {
            var fileInfo = new FileInfo(videoPath);
            var fileSize = fileInfo.Length;
            var payload = JsonConvert.SerializeObject(new
            {
                file = new
                {
                    display_name = fileInfo.Name
                }
            });

            using var content = new StringContent(payload, Encoding.UTF8, "application/json");
            content.Headers.Add("X-Goog-Upload-Protocol", "resumable");
            content.Headers.Add("X-Goog-Upload-Command", "start");
            content.Headers.Add("X-Goog-Upload-Header-Content-Length", fileSize.ToString());
            content.Headers.Add("X-Goog-Upload-Header-Content-Type", FileHelper.GetVideoMimeType(videoPath));

            var response = await _client.PostAsync($"{BaseUrl}/upload/v1beta/files?key={ApiKey}", content);

            if (response.IsSuccessStatusCode)
            {
                return response.Headers.GetValues("x-goog-upload-url")?.FirstOrDefault();
            }
            else
            {
                throw new InvalidDataException("Failed to initiate resumable upload");
            }
        }

        public static async Task<string> UploadVideoData(string uploadUrl, string videoPath)
        {
            var videoData = new ByteArrayContent(File.ReadAllBytes(videoPath));
            videoData.Headers.Add("X-Goog-Upload-Offset", "0");
            videoData.Headers.Add("X-Goog-Upload-Command", "upload, finalize");
            videoData.Headers.Add("Content-Length", new FileInfo(videoPath).Length.ToString());

            var response = await _client.PutAsync(uploadUrl, videoData);
            var responseJson = await response.Content.ReadAsStringAsync();

            var jsonResponse = JObject.Parse(responseJson);

            return jsonResponse.SelectToken("$.file.uri")?.ToString();
        }

        public static async Task<string> GetFileState(string fileId)
        {
            var response = await _client.GetAsync($"{BaseUrl}/v1beta/files/{fileId}?key={ApiKey}");

            if (response.IsSuccessStatusCode)
            {
                var responseBody = await response.Content.ReadAsStringAsync();
                var jsonResponse = JObject.Parse(responseBody);
                return jsonResponse.SelectToken("$.state")?.ToString();
            }
            else
            {
                throw new InvalidDataException($"Error checking file state: {response.ReasonPhrase}");
            }
        }
    }
}
