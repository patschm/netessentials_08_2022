using System;
using System.Collections.Concurrent;

namespace Threading;

internal class Program
{
    static void Main(string[] args)
    {
        //Synchrochronous();
        //Asynchronous();
        //TaskChaining();
        //Breaking();
        //Errors();
        //MoreFun();
        SynchrochronousLocks();
        Console.WriteLine("Main thread continues");
        Console.ReadLine();
    }

    static object stick = new object();
    private static void SynchrochronousLocks()
    {
        ConcurrentBag<int> bag = new ConcurrentBag<int>();
        bag.Add(3);
        int counter = 0;
        Parallel.For(0, 15, idx => {
            //Mutex
            //ManualResetEvent
           // AutoResetEvent
            //Monitor.Enter(stick);
            lock (stick)
            {
                int tmp = counter;
                Task.Delay(200);
                tmp++;
                Console.WriteLine(tmp);
                counter = tmp;
            }
            //Monitor.Exit(stick);
        });
    }

    private static async void MoreFun()
    {
        var t1 = Task.Run(() => LongAdd(4, 5));
        //.ContinueWith(prevTask => Console.WriteLine(prevTask.Result));

        //var ta = t1.GetAwaiter();
        //ta.GetResult();
        int result = await t1;  // return;
        Console.WriteLine(result);
        result = await Task.Run(() => LongAdd(14, 15));
        Console.WriteLine(result);
        result = await LongAddAsync(9, 10);
        Console.WriteLine(result);
    }

    private static void Errors()
    {
        //try
        //{
        //    Task.Run(() =>
        //    {
        //        Task.Delay(3000).Wait();
        //        throw new Exception("Ooops");
        //    });
        //}
        //catch(AggregateException e)
        //{
        //    Console.WriteLine(e.InnerException.Message);
        //}

        Task.Run(() =>
            {
                Task.Delay(3000).Wait();
                throw new Exception("Ooops");
            }).ContinueWith(pt => { 
                if (pt.Exception != null)
                {
                    Console.WriteLine(pt.Exception?.InnerException?.Message);
                }
            });
    }

    private static void Breaking()
    {
        CancellationTokenSource nikko = new CancellationTokenSource();

        CancellationToken bomb = nikko.Token;
        Task.Run(() =>
        {
            for (int i = 1; i < 10000; i++)
            {
                Task.Run(() =>
                {
                    Console.WriteLine(i);
                });
                Task.Delay(500).Wait();
                if (bomb.IsCancellationRequested)
                {
                    Console.WriteLine("Bye bye");
                    return;
                }
            }
        });

        //Task.Delay(20000).Wait();
        //nikko.Cancel();

        nikko.CancelAfter(10000);
    }

    private static void TaskChaining()
    {
        var t1 = new Task<int>(() => LongAdd(4, 5));

        // Sequential execution
        t1.ContinueWith(prevTask =>
        {
            int result = prevTask.Result;
            Console.WriteLine(result);
        }).ContinueWith(pt => Console.WriteLine("Next 1"))
            .ContinueWith(pt => Console.WriteLine("Next 2"))
            .ContinueWith(pt => Console.WriteLine("Next 3"))
            .ContinueWith(pt => Console.WriteLine("Next 4"));

        t1 = new Task<int>(() => LongAdd(4, 5));

        // Parallel execution 
        t1.ContinueWith(prevTask => {
            int result = prevTask.Result;
            Console.WriteLine(result);
        });
        t1.ContinueWith(pt => Console.WriteLine("Next 1"));
        t1.ContinueWith(pt => Console.WriteLine("Next 2"));
        t1.ContinueWith(pt => Console.WriteLine("Next 3"));
        t1.ContinueWith(pt => Console.WriteLine("Next 4"));

        t1.Start();
    }

    private static void Asynchronous()
    {
        // APM
        //Func<int, int, int> func = LongAdd;
        //IAsyncResult ar = func.BeginInvoke(4, 5, MyCallback, func);
        //while (!ar.IsCompleted)
        //{
        //    Console.Write(".");
        //    Task.Delay(100).Wait();
        //}
        //int result = func.EndInvoke(ar);
        //Console.WriteLine(result);

        Task<int> t1 = new Task<int>(() => LongAdd(4, 5));

        t1.ContinueWith(prevTask => {
            int result = prevTask.Result;
            Console.WriteLine(result);
        });

        t1.Start();

        var t2 = Task.Run(() => LongAdd(4, 5))
            .ContinueWith(prevTask => Console.WriteLine(prevTask.Result));

    }

    private static void MyCallback(IAsyncResult ar)
    {
        var func = ar.AsyncState as Func<int, int, int>;
        int result = func.EndInvoke(ar);
        Console.WriteLine(result);
    }

    private static void Synchrochronous()
    {
        int result = LongAdd(2, 3);
        Console.WriteLine(result);
    }

    static int LongAdd(int a, int b)
    {
        Task.Delay(5000).Wait();
        return a + b;
    }
    static Task<int> LongAddAsync(int a, int b)
    {
        return Task.Run(() => LongAdd(a, b));
    }
}