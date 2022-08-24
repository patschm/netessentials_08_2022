using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Feeds
{
    public class LinqToXmlStrategy : IProcessStreamStrategy
    {
        public IEnumerable<Item> Process(Stream stream)
        {
            XDocument doc = XDocument.Load(stream);

            var query = from item in doc.Descendants("item")
                        select new Item
                        {
                            Title = item.Element("title")?.Value,
                            Description = item.Element("description")?.Value,
                            Category = item.Element("category")?.Value,
                        };
            return query;
        }
    }
}
