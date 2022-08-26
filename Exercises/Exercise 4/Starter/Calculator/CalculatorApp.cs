namespace Calculator;

public partial class CalculatorApp : Form
{
    public CalculatorApp()
    {
        InitializeComponent();
    }

    private async void button1_Click(object sender, EventArgs e)
    {
        // Capture the main thread
        //SynchronizationContext main = SynchronizationContext.Current!;
        //int result = 42;

        //if (int.TryParse(txtA.Text, out int a) && int.TryParse(txtB.Text, out int b))
        //{
        //    //result = LongAdd(a, b);
        //    //UpdateAnswer(result);
        //    Task<int> t1 = new Task<int>(() => LongAdd(a, b));

        //    t1.ContinueWith(prevTask => {
        //        int result = prevTask.Result;
        //        main.Post(UpdateAnswer!, result);    
        //        //UpdateAnswer(result);
        //    });

        //    t1.Start();
        //}

        if (int.TryParse(txtA.Text, out int a) && int.TryParse(txtB.Text, out int b))
        {
            //var tx = LongAddAsync(a, b);//.ConfigureAwait(false);
            //int result = await tx;
            //UpdateAnswer(result);
            int result = await DoTheMath(a, b);
            UpdateAnswer(result);
        }
    }

    private async Task<int> DoTheMath(int a, int b)
    {
        return  await LongAddAsync(a, b);
    }
    private void UpdateAnswer(object result)
    {
        lblAnswer.Text = result.ToString();
    }

    private int LongAdd(int a, int b)
    {
        Task.Delay(10000).Wait();
        return a + b;
    }
    private Task<int> LongAddAsync(int a, int b)
    {
        return Task.Run(() => LongAdd(a, b));
    }
}