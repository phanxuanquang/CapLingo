namespace Capcut_Helpers
{
    public static class FileHelper
    {
        public static async Task<string> ReadFileAsync(string path)
        {
            try
            {
                path = Path.GetFullPath(path);
                if (!File.Exists(path))
                {
                    throw new FileNotFoundException($"File not found: {path}", path);
                }

                return await File.ReadAllTextAsync(path).ConfigureAwait(false);
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

        public static async Task WriteFileAsync(string dirPath, string fileName, string content)
        {
            try
            {
                dirPath = Path.GetFullPath(dirPath);
                if (!Directory.Exists(dirPath))
                {
                    throw new DirectoryNotFoundException($"Directory not found: {dirPath}");
                }

                var filePath = Path.Combine(dirPath, fileName);
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
    }
}
