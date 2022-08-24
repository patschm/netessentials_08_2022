using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using Newtonsoft.Json;
using Shapes;

namespace DrawNotSoPerfect;

// TODO 7: Go to appsettings.json and set the loglevel for LocalFileStorage to information.
// Test the application. Open or save some data and check the Output Window in VS2022
public class LocalFileStorage : IStorage
{
    private ILogger<LocalFileStorage> _logger = NullLogger<LocalFileStorage>.Instance;
    private string? _currentFile = null;
    // TODO 6: Inject an instance of the ILogger<LocalFileStorage> here
    public LocalFileStorage(ILogger<LocalFileStorage> logger)
    {
        _logger = logger;   
    }
    public List<Shape>? Open(string path)
    {
        _logger.LogInformation($"Opening file {path}");
        _currentFile = path;
        JsonSerializer serializer = new JsonSerializer();
        serializer.TypeNameHandling = TypeNameHandling.All;
        using (var stream = File.OpenRead(_currentFile))
        using (var reader = new StreamReader(stream))
            return serializer.Deserialize(reader, typeof(List<Shape>)) as List<Shape>;
    }

    public void Save(List<Shape> shapes)
    {
        if (_currentFile == null)
        {
            throw new FileNotFoundException();
        }
        _logger.LogInformation($"Save {shapes.Count} shapes to file: {_currentFile}");
        SaveAs(_currentFile, shapes); 
    }

    public void SaveAs(string path, List<Shape> shapes)
    {
        _currentFile = path;
        _logger.LogInformation($"SaveAs {shapes.Count} shapes to file: {_currentFile}");
        JsonSerializer serializer = new JsonSerializer();
        serializer.TypeNameHandling = TypeNameHandling.All;
        using (var stream = File.OpenWrite(_currentFile))
        using (var writer = new StreamWriter(stream))
            serializer.Serialize(writer, shapes);
    }
}
