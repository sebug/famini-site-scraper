public record Scraper(string BaseURL, string Password) {
    public async Task Run() {
        await Console.Out.WriteLineAsync($"Scraping images from {BaseURL}");
    }
}