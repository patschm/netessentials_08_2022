
namespace Shapes;

public interface IStorage
{
    void Save(List<Shape> shapes);
    void SaveAs(string path, List<Shape> shapes);
    List<Shape>? Open(string path);
}
