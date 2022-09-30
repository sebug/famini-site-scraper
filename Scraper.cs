using HtmlAgilityPack;

public record Scraper(string BaseURL, string Password) {
    public async Task Run() {
        Console.WriteLine($"Scraping images from {BaseURL}");

        var client = new HttpClient() {
            BaseAddress = new Uri(BaseURL)
        };
        client.DefaultRequestHeaders.UserAgent.Clear();
        client.DefaultRequestHeaders.UserAgent.Add(new System.Net.Http.Headers.ProductInfoHeaderValue("famini-scraper", "1.0"));

        var mainPageContent = await client.GetAsync("/");
        mainPageContent.EnsureSuccessStatusCode();
        string content = await mainPageContent.Content.ReadAsStringAsync();

        var doc = new HtmlDocument();
        doc.LoadHtml(content);

        var internLink = doc.DocumentNode.Descendants("a").FirstOrDefault(a => a.InnerText.Contains("Intern"));

        if (internLink == null) {
            throw new Exception("Did not find the intern section");
        }

        var internURL = internLink.GetAttributeValue("href", String.Empty);

        var internResponseNotLogged = await client.GetAsync(internURL);

        // Funnily enough HTTP status is 200 OK

        string internContentNotLogged = await internResponseNotLogged.Content.ReadAsStringAsync();

        var loginDoc = new HtmlDocument();
        loginDoc.LoadHtml(internContentNotLogged);

        var loginForm = loginDoc.DocumentNode.Descendants("form").FirstOrDefault();

        if (loginForm == null) {
            throw new Exception("Did not find login form");
        }

        Console.WriteLine();

        var formFields = loginForm.Descendants("input")
            .ToDictionary(input => input.GetAttributeValue("name", String.Empty), input => input.GetAttributeValue("value", String.Empty));

        formFields["password"] = Password;

        var postContent = new FormUrlEncodedContent(formFields);

        var postResponse = await client.PostAsync(loginForm.GetAttributeValue("action", String.Empty), postContent);

        string loggedInContent = await postResponse.Content.ReadAsStringAsync();

        Console.WriteLine(loggedInContent);
    }
}