
namespace GarbageMan;

internal class FileEmulator : IDisposable
{
    private FileStream _stream;
    private static bool isOpen = false;
    public void Open()
    {
        Console.WriteLine("Opening....");
        if (!isOpen)
        {
            isOpen = true;
            Console.WriteLine("Is Open");
            _stream = new FileStream(@"D:\bla.txt", FileMode.OpenOrCreate);
        }
       else
        {
            Console.WriteLine("In use");
        }
    }
    public void Close()
    {
        isOpen = false;
        Console.WriteLine("Closed");
    }

    protected void Dispose(bool disposing)
    {
        Close();
        if (disposing)
        {
            _stream.Dispose();
        }
    }

    public void Dispose()
    {
        Dispose(true);
        
        GC.SuppressFinalize(this);
    }

    ~FileEmulator()
    {
        Dispose(false);
        //_stream.Dispose(); Don't do this
    }

}
