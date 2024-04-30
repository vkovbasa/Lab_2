using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp2
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

        private void StartCalculation_Click(object sender, RoutedEventArgs e)
        {
            // Створюємо перший потік
            Thread thread1 = new Thread(ThreadFunction1);
            thread1.Start();
            // Створюємо другий потік
            Thread thread2 = new Thread(ThreadFunction2);
            thread2.Start();
        }

        static void ThreadFunction1()
        {
            double result = CalculateResult(0.5, g1);
            Application.Current.Dispatcher.Invoke(() =>
            {
                MessageBox.Show($"Education 2x - cos (x) = 0\nAnswer: X= {result}, iquel {Thread1.e}");
            });
        }

        static void ThreadFunction2()
        {
            double result = CalculateResult(0.75, g2);
            Application.Current.Dispatcher.Invoke(() =>
            {
                MessageBox.Show($"Education x + ln (x) = 0\nAnswer: X= {result}, iquel {Thread1.e}");
            });
        }

        static double CalculateResult(double x, MyFunc g)
        {
            double temp, d;
            do
            {
                temp = g(x);
                d = Math.Abs(temp - x);
                x = temp;
            }
            while (d >= Thread1.e);
            return x;
        }

        public delegate double MyFunc(double x);

        public static double g1(double x)
        {
            return 0.5 * Math.Cos(x);
        }

        public static double g2(double x)
        {
            return (2 * x - Math.Log(x)) / 3;
        }
    }

    public class Thread1
    {
        public static double e = 0.01;
    }
}
