namespace Feeds
{
    public class FeedReader : IFeedReader
    {
        private IHttpClientFactory _httpClientFactory;
        private IProcessStreamStrategy _strategy;

        public FeedReader(IHttpClientFactory httpFactory, IProcessStreamStrategy strategy)
        {
            _httpClientFactory = httpFactory;
            _strategy = strategy;
        }

        public IEnumerable<Item> Read()
        {
            var client = _httpClientFactory.CreateClient("nu");
            var result = client.GetAsync("rss").Result;
            if (result.IsSuccessStatusCode)
            {
                return _strategy.Process(result.Content.ReadAsStream());
            }
            return null;
        }
    }
}