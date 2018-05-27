using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
using System.IO;

namespace RhythmExp_sub_2_try
{
    /// <summary>
    /// Interaction logic for PreferredRhythm.xaml
    /// </summary>
    public partial class PreferredRhythm : UserControl
    {
        public int t = 660;
        public System.Windows.Forms.Timer uiTimer0_1 = new System.Windows.Forms.Timer();
        public int countBeep = 0;

        public PreferredRhythm()
        {
            InitializeComponent();
        }

        private void submit_Click(object sender, RoutedEventArgs e)
        {
            uiTimer0_1.Tick -= BeepTimer0_1;
            uiTimer0_1.Stop();
            this.Visibility = System.Windows.Visibility.Hidden;
            write_preferredrhythm(t);
            var main = App.Current.MainWindow as MainWindow;
            main.Task1Btn.Visibility = main.Task2Btn.Visibility = main.Task3Btn.Visibility = main.Task4Btn.Visibility = System.Windows.Visibility.Visible;
        }


        private void sld1_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {


        }


        public void BeepTimer0_1(object sender, EventArgs e)
        {
            if (uiTimer0_1.Enabled)
            {
                //Console.Beep(4200, 50);
                BackgroundBeep.Beep();
                countBeep++;

                if (countBeep >= 16)
                {
                    submit.IsEnabled = true;
                }
            }
            //uiTimer0_1.Tick -= BeepTimer0_1;
            //uiTimer0_1.Stop();
        }



        private void write_preferredrhythm(int t)
        {
            var main = App.Current.MainWindow as MainWindow;

            var dir = new DirectoryInfo(System.IO.Path.GetDirectoryName(System.Environment.CurrentDirectory));

            string file = dir.Parent.FullName + @"\TXT\PreferredRhythm.txt";

            StreamWriter sr;


            sr = File.AppendText(file);

            sr.WriteLine("Preferred time interval: " + t + "\t" + System.DateTime.Now.ToString("hh:mm:ss.fff"));//将传入的字符串加上时间写入文本文件一行

            sr.Close();
        }

        private void start_Click(object sender, RoutedEventArgs e)
        {
            uiTimer0_1.Interval = t;
            uiTimer0_1.Tick += BeepTimer0_1;
            uiTimer0_1.Start();
            start.Visibility = System.Windows.Visibility.Hidden;
            submit.Visibility = System.Windows.Visibility.Visible;
            sld1.IsEnabled = true;

        }

        private void sld1_DragCompleted(object sender, RoutedEventArgs e)
        {
            uiTimer0_1.Tick -= BeepTimer0_1;
            uiTimer0_1.Stop();

            t = 660 + 660 - (int)(sld1.Value);

            //  Console.Beep(4200, 50);
            uiTimer0_1.Interval = t;
            uiTimer0_1.Tick += BeepTimer0_1;
            uiTimer0_1.Start();
            countBeep = 0;
            submit.IsEnabled = false;
        }

        private void sld1_MouseUp(object sender, RoutedEventArgs e)
        {
            uiTimer0_1.Tick -= BeepTimer0_1;
            uiTimer0_1.Stop();

            t = 660 + 660 - (int)(sld1.Value);

            //  Console.Beep(4200, 50);
            uiTimer0_1.Interval = t;
            uiTimer0_1.Tick += BeepTimer0_1;
            uiTimer0_1.Start();
            countBeep = 0;
            submit.IsEnabled = false;
        }
    }
}
