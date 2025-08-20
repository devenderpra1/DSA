using System.IO;
using System.Text;
using System.Threading.Tasks.Dataflow;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace UI_app
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            var typeOffunc = new TypeOfFunction();
            
            int num = await typeOffunc.DoSomethingGetNothingButEnsurity();

            Alwayswait();

            ViewText.Text = "Hello, World!";
        }

        public async Task  Alwayswait()
        {
            //int Reiterate = 100;
            //int i = 0;
            //while (i < Reiterate)
            //{
            //    for (int j = 0; j < 100; j++)
            //        {

            //    }
            //}
            await Task.Run(() => System.Threading.Thread.Sleep(5000));
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }
    }

    public class TypeOfFunction
    {

        public async Task<int> DoSomethingGetNothingButEnsurity()
        {
            return await Task.Run(() => Alwayswait(5));
        }


        public async Task<int> Alwayswait(int a)
        {
            int Reiterate = 100;
            int i = 0;
            while (i < Reiterate)
            {
                for (int j = 0; j < 10000; j++)
                {

                }
            }
            return 1;
        }

        public Task DoSomethingGetSomethingWithTask()
        {
            Thread.Sleep(20000);
            return Task.CompletedTask;
        }

        public async void OnlyDoSomethingGetNothing()
        {
        }
        public async void DoSomethingGetSomethingCallBack(Func<int, string> func)
        {

        }

        public async void DoSomethingGetSomethingCallBackDelegate(ReturnNothingCallBack returnNothingCallBack)
        {

        }

        public void JustDoSomething(string input)
        {
            Console.Write(input);
        }
    }

    public delegate void ReturnNothingCallBack(int num);
}