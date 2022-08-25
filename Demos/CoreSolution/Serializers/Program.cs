
using System.Xml;
using System.Xml.Serialization;

namespace Serializers;

internal class Program
{
    static void Main(string[] args)
    {
        //Person p1 = new Person { Id = 1, FirstName = "Ada", LastName = "Kok", Age = 42 };
        //SerializeXml(p1);
        DeserializeXml();
        Console.ReadLine();
    }

    private static void DeserializeXml()
    {
        XmlSerializer serializer = new XmlSerializer(typeof(Person));
        FileStream fs = File.OpenRead(@"D:\WatchThis\person3.xml");
        XmlReader reader = XmlReader.Create(fs);
        reader.ReadToFollowing("person");
        var p1 = serializer.Deserialize(reader.ReadSubtree()) as Person;
        Console.WriteLine(p1.FirstName);
    }

    private static void SerializeXml(Person p1)
    {
        XmlSerializer serializer = new XmlSerializer(typeof(Person));
        FileStream fs = File.Create(@"D:\WatchThis\person3.xml");
        serializer.Serialize(fs, p1);
    }
}