using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Feeds
{
    public interface IFeedReader
    {
        IEnumerable<Item> Read();
    }
}
