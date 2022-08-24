using Newtonsoft.Json;
using Shapes;

namespace DrawNotSoPerfect;

// TODO 1: Save the shapes to the given file using a Json serializer
// Implement the IStorage interface and test the application.
public class LocalFileStorage : IStorage
{
    public List<Shape>? Open(string path)
    {
        return null;
    }

    public void Save(List<Shape> shapes)
    { 
        
    }

    public void SaveAs(string path, List<Shape> shapes)
    {
       
    }
}
