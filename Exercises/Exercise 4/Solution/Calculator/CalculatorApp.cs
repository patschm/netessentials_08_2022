namespace Calculator
{
    public partial class CalculatorApp : Form
    {
        private SynchronizationContext Context;
        public CalculatorApp()
        {
            InitializeComponent();
            Context = SynchronizationContext.Current;
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            //SynchronizationContext context = SynchronizationContext.Current;
            if (int.TryParse(txtA.Text, out int a) && int.TryParse(txtB.Text, out int b))
            {
                //int result = LongAdd(a, b);
                ////UpdateAnswer(result);
                //Task.Run<int>(() => LongAdd(a,b))
                //    .ContinueWith(pt => {
                //        Context.Send(UpdateAnswer, pt.Result);
                //       //UpdateAnswer(pt.Result);

                //        });
                int result = await DoTheAdd(a, b);//.ConfigureAwait(false);
                UpdateAnswer(result);
            }    
        }

        private async Task<int> DoTheAdd(int a, int b)
        {
            int result = await LongAddAsync(a, b);
            return result;
            //return LongAddAsync(a, b).Result;  // Dead lock
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
}