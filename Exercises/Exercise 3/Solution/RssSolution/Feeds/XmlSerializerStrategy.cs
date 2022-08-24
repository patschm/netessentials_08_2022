using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace Feeds
{
    public class XmlSerializerStrategy : IProcessStreamStrategy
    {
        private XmlSerializer serializer = new XmlSerializer(typeof(Item));

        public IEnumerable<Item> Process(Stream stream)
        {
            var reader = XmlReader.Create(stream);
            while (reader.ReadToFollowing("item"))
            {
                var item = ProcessItem(reader.ReadSubtree());
                if (item != null) yield return item;    
            }
        }

        private Item? ProcessItem(XmlReader xmlReader)
        {
            return serializer.Deserialize(xmlReader) as Item;
        }
    }
}
