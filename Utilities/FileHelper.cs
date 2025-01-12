namespace Utilities
{
    public static class FileHelper
    {
        public static async Task<string> ReadFileAsync(string path, bool useEncription = false)
        {
            try
            {
                path = Path.GetFullPath(path);
                if (!File.Exists(path))
                {
                    throw new FileNotFoundException($"File not found: {path}", path);
                }

                var content = await File.ReadAllTextAsync(path).ConfigureAwait(false);

                return useEncription ? CriptographyHelper.Decrypt(content) : content;
            }
            catch (UnauthorizedAccessException ex)
            {
                throw new IOException("Access to the file is denied", ex);
            }
            catch (Exception ex)
            {
                throw new IOException("An error occurred while reading the file", ex);
            }
        }

        public static async Task WriteFileAsync(string filePath, string content, bool useEncription = false)
        {
            try
            {
                content = useEncription ? CriptographyHelper.Encrypt(content) : content;

                await File.WriteAllTextAsync(filePath, content).ConfigureAwait(false);
            }
            catch (UnauthorizedAccessException ex)
            {
                throw new IOException("Access to the file is denied", ex);
            }
            catch (Exception ex)
            {
                throw new IOException($"Failed to write file", ex);
            }
        }

        public static string GetVideoMimeType(string filePath)
        {
            var extension = Path.GetExtension(filePath).ToLowerInvariant();
            return $"video/{extension.Replace(".", string.Empty)}";
        }
    }
}
