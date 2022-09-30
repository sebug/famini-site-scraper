public record FaminiUploader(string BaseDirectory, string AccountName, string AccountKey) {
    public async Task UploadImages() {
        var files = Directory.EnumerateFiles(BaseDirectory);

        foreach (var fileName in files) {
            await Console.Out.WriteLineAsync(fileName);
        }
    }
}