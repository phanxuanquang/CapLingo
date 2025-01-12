using Newtonsoft.Json;

namespace GenAI.Models
{
    public class FileUploadApiResponse
    {
        public class File
        {
            [JsonProperty("name")]
            public string Name;

            [JsonProperty("displayName")]
            public string DisplayName;

            [JsonProperty("mimeType")]
            public string MimeType;

            [JsonProperty("sizeBytes")]
            public string SizeBytes;

            [JsonProperty("createTime")]
            public DateTime? CreateTime;

            [JsonProperty("updateTime")]
            public DateTime? UpdateTime;

            [JsonProperty("expirationTime")]
            public string ExpirationTime;

            [JsonProperty("sha256Hash")]
            public string Sha256Hash;

            [JsonProperty("uri")]
            public string Uri;

            [JsonProperty("state")]
            public string State;

            [JsonProperty("videoMetadata")]
            public VideoMetadata VideoMetadata;
        }

        public class Root
        {
            [JsonProperty("files")]
            public List<File> Files;
        }

        public class VideoMetadata
        {
            [JsonProperty("videoDuration")]
            public string VideoDuration;
        }
    }
}
