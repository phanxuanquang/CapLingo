using Newtonsoft.Json;

namespace GenAI.Models
{
    public class ContentGenerationApiRequest
    {
        public class Content
        {
            [JsonProperty("role")]
            public string Role;

            [JsonProperty("parts")]
            public List<Part> Parts;
        }

        public class FileData
        {
            [JsonProperty("fileUri")]
            public string FileUri;

            [JsonProperty("mimeType")]
            public string MimeType;
        }

        public class GenerationConfig
        {
            [JsonProperty("temperature")]
            public double Temperature;

            [JsonProperty("topK")]
            public int TopK;

            [JsonProperty("topP")]
            public double TopP;

            [JsonProperty("maxOutputTokens")]
            public int MaxOutputTokens;

            [JsonProperty("responseMimeType")]
            public string ResponseMimeType;
        }

        public class Part
        {
            [JsonProperty("fileData")]
            public FileData FileData;

            [JsonProperty("text")]
            public string Text;
        }

        public class Root
        {
            [JsonProperty("contents")]
            public List<Content> Contents;

            [JsonProperty("systemInstruction")]
            public SystemInstruction SystemInstruction;

            [JsonProperty("generationConfig")]
            public GenerationConfig GenerationConfig;
        }

        public class SystemInstruction
        {
            [JsonProperty("role")]
            public string Role;

            [JsonProperty("parts")]
            public List<Part> Parts;
        }
    }
}
