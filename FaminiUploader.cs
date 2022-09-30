

using Azure.Storage;
using Azure.Storage.Blobs;

public record FaminiUploader(string BaseDirectory, string AccountName, string AccountKey) {
    public async Task UploadImages() {
        var sharedKeyCredential = new StorageSharedKeyCredential(AccountName, AccountKey);
        string blobUri = "https://" + AccountName + ".blob.core.windows.net";
        var blobServiceClient = new BlobServiceClient(new Uri(blobUri), sharedKeyCredential);
        var files = Directory.EnumerateFiles(BaseDirectory);

        foreach (var fileName in files) {
            await Console.Out.WriteLineAsync(fileName);
        }
    }
}