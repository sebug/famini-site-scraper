

using Azure.Storage;
using Azure.Storage.Blobs;

public record FaminiUploader(string BaseDirectory, string AccountName, string AccountKey) {
    public async Task UploadImages() {
        var sharedKeyCredential = new StorageSharedKeyCredential(AccountName, AccountKey);
        string blobUri = "https://" + AccountName + ".blob.core.windows.net";
        var blobServiceClient = new BlobServiceClient(new Uri(blobUri), sharedKeyCredential);

        var blobContainers = blobServiceClient.GetBlobContainers();
        var photosContainer = blobContainers.FirstOrDefault(bc => bc.Name == "photos");
        if (photosContainer == null) {
            var createContainerResponse = await blobServiceClient.CreateBlobContainerAsync("photos");
        }

        var containerClient = blobServiceClient.GetBlobContainerClient("photos");

        var files = Directory.EnumerateFiles(BaseDirectory);

        foreach (var fileName in files) {
            var blobClient = containerClient.GetBlobClient(Path.GetFileName(fileName));
            await blobClient.UploadAsync(fileName, true);
        }
    }
}