if (args.Length == 0) {
    Console.WriteLine("Usage: FaminiScraper outputDirectory");
    return;
}

string baseUrl = Environment.GetEnvironmentVariable("FAMINI_URL") ?? throw new Exception("Define env variable FAMINI_URL");
string password = Environment.GetEnvironmentVariable("FAMINI_PASSWORD") ?? throw new Exception("Define env variable FAMINI_PASSWORD");
string accountName = Environment.GetEnvironmentVariable("FAMINI_ACCOUNT_NAME") ?? throw new Exception("Define env variable FAMINI_ACCOUNT_NAME");
string accountKey = Environment.GetEnvironmentVariable("FAMINI_ACCOUNT_KEY") ?? throw new Exception("Define env variable FAMINI_ACCOUNT_KEY");

var scraper = new Scraper(baseUrl, password, args[0]);

await scraper.Run();

var uploader = new FaminiUploader(args[0], accountName, accountKey);

await uploader.UploadImages();

