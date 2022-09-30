public record FaminiUploader(string BaseDirectory) {
    public async Task UploadImages() {
        var files = Directory.EnumerateFiles(BaseDirectory);

        foreach (var fileName in files) {
            await Console.Out.WriteLineAsync(fileName);
        }
    }
}