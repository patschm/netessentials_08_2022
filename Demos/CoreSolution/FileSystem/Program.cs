using System.Reflection;
using System.Text;

namespace FileSystem;

internal class Program
{
    static void Main(string[] args)
    {
        //Files();
        //WatchFiles();

        //PreHistoricWriteToStream();
        //PreHistoricReadToStream();

        //ModernWriteToStream();
        ModernReadFromStream();
        //Console.ReadLine();
    }

    private static void ModernReadFromStream()
    {
        FileStream fs = File.OpenRead(@"D:\WatchThis\adv.txt");
        StreamReader sr = new StreamReader(fs);
        string? line;
        while((line= sr.ReadLine()) != null)
        {           
            Console.WriteLine(line);
        }
        sr.Close();
    }

    private static void ModernWriteToStream()
    {
        FileStream fs = File.Create(@"D:\WatchThis\adv.txt");
        StreamWriter writer = new StreamWriter(fs);
        for (int i = 0; i < 1000; i++)
        {
            writer.WriteLine($"Hello World {i}");
        }
        //writer.Flush();
        writer.Close();
    }

    private static void PreHistoricReadToStream()
    {
        FileStream fs = File.OpenRead(@"D:\WatchThis\simple.txt");
        int nrRead = 0;  
        byte[] buffer = new byte[100];
        do
        {
            Array.Clear(buffer, 0, buffer.Length);
            nrRead = fs.Read(buffer, 0, buffer.Length);
            Console.Write(Encoding.UTF8.GetString(buffer));
        }
        while (nrRead > 0);
    }

    private static void PreHistoricWriteToStream()
    {
        FileStream fs = File.Create(@"D:\WatchThis\simple.txt");
        for (int i = 0; i < 1000; i++)
        {
            byte[] bytes = Encoding.UTF8.GetBytes($"Hello World {i}\n");
            fs.Write(bytes, 0, bytes.Length);
        }
        fs.Close();
    }

    private static void WatchFiles()
    {
        if (!Directory.Exists(@"D:\WatchThis"))
        {
            Directory.CreateDirectory(@"D:\WatchThis");
        }
        FileSystemWatcher watcher = new FileSystemWatcher();
        watcher.Path = @"D:\WatchThis";
        watcher.Created += (s, e) =>
        {
            Console.WriteLine($"{e.Name} was created");
        };
        watcher.EnableRaisingEvents = true;

    }

    private static void Files()
    {
        FileInfo file = new FileInfo(@"D:\myfile.txt");
        Stream fs = file.Create();
        fs.Close();
        Console.WriteLine(file.Exists);

        file.Delete();

        Stream str = File.Create(@"D:\myfile.txt");

        str.Close();

        bool ok = File.Exists(@"D:\myfile.txt");
        Console.WriteLine(ok);
        File.Delete(@"D:\myfile.txt");


    }
}