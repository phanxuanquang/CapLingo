using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Text;
using Utilities;

namespace GenAI
{
    public class FileData
    {
        public string mime_type { get; set; }
        public string file_uri { get; set; }
    }

    public class Part
    {
        public string text { get; set; }
        public FileData file_data { get; set; }
    }

    public enum CreativityLevel
    {
        Low = 25,
        Medium = 50,
        High = 75
    }

    public static class GoogleVideoUploader
    {
        private static readonly string BaseUrl = "https://generativelanguage.googleapis.com";
        public static string GoogleApiKey;
        private static readonly HttpClient client = new();

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

            var response = await client.PostAsync($"{BaseUrl}/upload/v1beta/files?key={GoogleApiKey}", content);

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

            var response = await client.PutAsync(uploadUrl, videoData);
            var responseJson = await response.Content.ReadAsStringAsync();

            var jsonResponse = JObject.Parse(responseJson);

            return jsonResponse.SelectToken("$.file.uri")?.ToString();
        }

        public static async Task<string> GetFileState(string fileId)
        {
            var response = await client.GetAsync($"{BaseUrl}/v1beta/files/{fileId}?key={GoogleApiKey}");

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
