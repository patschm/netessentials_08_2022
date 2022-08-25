namespace GarbageMan;

internal class Program
{
    private static FileEmulator f1 = new FileEmulator();
    private static FileEmulator f2 = new FileEmulator();

    static void Main(string[] args)
    {
        try
        {
            f1.Open();
            
        }
        finally
        {
            f1.Dispose();
        }
        f1 = null;

        // Not the way to go
        //GC.Collect();
       // GC.WaitForPendingFinalizers();

        using (f2)
        {
            f2.Open();
        }

        Console.ReadLine();
        GC.Collect();
        GC.WaitForPendingFinalizers();
    }
}