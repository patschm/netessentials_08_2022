using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Feeds
{
    public class RegexpStrategy : IProcessStreamStrategy
    {
        public IEnumerable<Item> Process(Stream stream)
        {
            StreamReader rdr = new StreamReader(stream);
            string data = rdr.ReadToEnd();
            Regex reg = new Regex(@"<item>.*?<title>(?<title>.*?)</title>.*?<description>(?<desc>.*?)</description>.*?<category>(?<cat>.*?)</category>.*?</item>", RegexOptions.None);
            var mc = reg.Matches(data);
            foreach (Match it in mc)
            {
                yield return new Item
                {
                    Title = it.Groups["title"].Value,
                    Description = it.Groups["desc"].Value,
                    Category = it.Groups["cat"].Value
                };
            }
        }
    }
}
