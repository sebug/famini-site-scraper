public record Scraper(string BaseURL, string Password) {
    public async Task Run() {
        Console.WriteLine($"Scraping images from {BaseURL}");

        var client = new HttpClient() {
            BaseAddress = new Uri(BaseURL)
        };
        client.DefaultRequestHeaders.UserAgent.Clear();
        client.DefaultRequestHeaders.UserAgent.Add(new System.Net.Http.Headers.ProductInfoHeaderValue("famini-scraper", "1.0"));

        var mainPageContent = await client.GetAsync("/");
        
        string content = await mainPageContent.Content.ReadAsStringAsync();

        Console.WriteLine(content);
    }
}