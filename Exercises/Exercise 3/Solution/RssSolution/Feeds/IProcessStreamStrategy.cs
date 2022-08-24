namespace Feeds
{
    public interface IProcessStreamStrategy
    {
        IEnumerable<Item> Process(Stream stream);
    }
}