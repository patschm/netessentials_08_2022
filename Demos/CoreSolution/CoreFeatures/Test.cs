using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreFeatures;

internal class Test
{
    private readonly ICounter _counter;

    public Test(ICounter counter)
    {
        _counter = counter;
    }

    public void Run()
    {
        _counter.Increment();
        _counter.Show();
    }
}
