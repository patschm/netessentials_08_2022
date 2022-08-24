using Newtonsoft.Json;
using Shapes;

namespace DrawNotSoPerfect;

// TODO 1: Save the shapes to the given file using a Json serializer
// Implement the IStorage interface and test the application.
public class LocalFileStorage : IStorage
{
    private string? _currentFile = null;
    public List<Shape>? Open(string path)
    {
        JsonSerializer serializer = new JsonSerializer();
        serializer.TypeNameHandling = TypeNameHandling.All;
        using (var stream = File.OpenRead(path))
        using (var reader = new StreamReader(stream))
            return serializer.Deserialize(reader, typeof(List<Shape>)) as List<Shape>;
    }

    public void Save(List<Shape> shapes)
    { 
        if (_currentFile == null)
        {
            throw new FileNotFoundException();
        }
       SaveAs(_currentFile, shapes); 
    }

    public void SaveAs(string path, List<Shape> shapes)
    {
        _currentFile = path;
        JsonSerializer serializer = new JsonSerializer();
        serializer.TypeNameHandling = TypeNameHandling.All;
        using (var stream = File.OpenWrite(_currentFile))
        using (var writer = new StreamWriter(stream))
            serializer.Serialize(writer, shapes);
    }
}
