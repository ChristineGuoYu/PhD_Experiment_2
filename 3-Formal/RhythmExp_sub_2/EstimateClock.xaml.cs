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
using System.Text.RegularExpressions;

namespace RhythmExp_sub_2
{
    /// <summary>
    /// Interaction logic for EstimateClock.xaml
    /// </summary>
    public partial class EstimateClock : UserControl
    {
        public EstimateClock()
        {
            InitializeComponent();
        }

        //public Line clock_hand = new Line();
        public Point clock_centre = new Point();
        public Point estimate_point = new Point();
        public double Mouse_To_Centre = 100;
        public SolidColorBrush slateblueBrush = new SolidColorBrush();
/*
        private void Clock_Canvas_MouseMove(object sender, MouseEventArgs e)
        {
            Point p = Mouse.GetPosition(Clock_Canvas);
            Mouse_Position.Content = p.X.ToString() + " , " + p.Y.ToString();

            Mouse_To_Centre = Math.Pow(Math.Pow((150.5 - p.X), 2) + Math.Pow((150 - p.Y), 2), 0.5);

            if (Mouse_To_Centre > 60 || Mouse_To_Centre < 25)
            {
                Estimate_Point.Visibility = System.Windows.Visibility.Hidden;
            }
            else
            {
                Estimate_Point.Visibility = System.Windows.Visibility.Visible;
                Canvas.SetLeft(Estimate_Point, p.X - Estimate_Point.ActualWidth / 2);
                Canvas.SetTop(Estimate_Point, p.Y - Estimate_Point.ActualHeight / 2);
            }

        }
        */

        /*
        private void Clock_Canvas_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (Estimate_Point.Visibility == System.Windows.Visibility.Visible)
            {
                Point p = Mouse.GetPosition(Clock_Canvas);


                clock_hand.X1 = 150.5;
                clock_hand.Y1 = 150;
                // clock_hand.X2 = p.X;

                if (p.Y > 149)
                {
                    clock_hand.Y2 = 150 + Math.Pow(1600 / (1 + Math.Pow((p.X - 150.5) / (p.Y - 150), 2)), 0.5);
                }
                else
                {
                    clock_hand.Y2 = 150 - Math.Pow(1600 / (1 + Math.Pow((p.X - 150.5) / (p.Y - 150), 2)), 0.5);
                }

                if (p.X > 150)
                {
                    clock_hand.X2 = 150.5 + Math.Pow(1600 - Math.Pow((clock_hand.Y2 - 150), 2), 0.5);
                }
                else
                {
                    clock_hand.X2 = 150.5 - Math.Pow(1600 - Math.Pow((clock_hand.Y2 - 150), 2), 0.5);
                }
                //Clock_Canvas.Children.Add(clock_hand);
                clock_hand.Visibility = System.Windows.Visibility.Visible;

                var main = App.Current.MainWindow as MainWindow;
                if (main.type == 1)
                { doneButton_t1.IsEnabled = true; }
                else if (main.type == 2)
                { doneButton_t2.IsEnabled = true; }
                else if (main.type == 3)
                { doneButton_t3.IsEnabled = true; }
                else if (main.type == 4)
                { doneButton_t4.IsEnabled = true; }

                write_subtasktime(main.taskType[main.type], main.taskNum, "ClickEstimateClock", System.DateTime.Now);


            }
        }
        */


        private void doneButton_t1_Click(object sender, RoutedEventArgs e)
        {

            if (String.IsNullOrEmpty(UserInput.Text) || int.Parse(UserInput.Text) < 0 || int.Parse(UserInput.Text) > 60)
            {

                MessageBox.Show("Please enter a number between 0 and 60!", "Oops!");
            }
           
            else
            {
                var main = App.Current.MainWindow as MainWindow;
                this.Visibility = System.Windows.Visibility.Hidden;//this.clock_hand.Visibility = 
                //doneButton_t1.IsEnabled = false;


                int t = main.Libet_Clock.last_beep_time(main.taskNum, main.type, main.sub_type);
                write_answer(main.taskType[main.type], main.taskNum, "CorrectAnswer:", t);

                // int t2 = estimate_time();
                //write_answer(main.taskType[main.type], main.taskNum, "EstimateAnswer:", t2);
                write_answer2(main.taskType[main.type], main.taskNum, "EstimateTextAnswer:", UserInput.Text);
                UserInput.Text = String.Empty;
                write_subtasktime(main.taskType[main.type], main.taskNum, "HideEstimateClock", System.DateTime.Now);



                if (main.countTask < 24)
                {
                    //Random sub_Rnd = new Random();
                    main.sub_type = main.sub_type_array[main.subTask + 1] - 7;
                    main.Libet_Clock.Visibility = System.Windows.Visibility.Visible;
                    main.taskInstruction.Content = "Please click READY to start" + Environment.NewLine + "Then listen to the BEEPS while observing the CLOCK";

                }
                else
                {
                    main.Task_Rating.Visibility = System.Windows.Visibility.Visible;
                    main.taskInstruction.Visibility = System.Windows.Visibility.Hidden;
                    main.countTask = main.subTask = 0;


                }
            }


        }

        private void doneButton_t2_Click(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrEmpty(UserInput.Text) || int.Parse(UserInput.Text) < 0 || int.Parse(UserInput.Text) > 60)
            {
                MessageBox.Show("Please enter a number between 0 and 60!", "Oops!");
            }
            else
            {
                var main = App.Current.MainWindow as MainWindow;
                this.Visibility = System.Windows.Visibility.Hidden;//this.clock_hand.Visibility = 
               // doneButton_t2.IsEnabled = false;


                int t = main.Libet_Clock.last_beep_time(main.taskNum, main.type, main.sub_type);
                write_answer(main.taskType[main.type], main.taskNum, "CorrectAnswer:", t);

                //  int t2 = estimate_time();
                // write_answer(main.taskType[main.type], main.taskNum, "EstimateAnswer:", t2);
                write_answer2(main.taskType[main.type], main.taskNum, "EstimateTextAnswer:", UserInput.Text);
                UserInput.Text = String.Empty;
                write_subtasktime(main.taskType[main.type], main.taskNum, "HideEstimateClock", System.DateTime.Now);


                if (main.countTask < 24)
                {
                    main.Libet_Clock.Visibility = System.Windows.Visibility.Visible;
                    main.taskInstruction.Content = "Please click READY to start" + Environment.NewLine + "Then listen to the BEEPS while observing the CLOCK";
                    // Random sub_Rnd = new Random();
                    main.sub_type = main.sub_type_array[main.subTask + 1] - 7; // set the sub_type for next subtask
                }
                else
                {
                    main.Task_Rating.Visibility = System.Windows.Visibility.Visible;
                    main.taskInstruction.Visibility = System.Windows.Visibility.Hidden;
                    main.countTask = main.subTask = 0;

                }
            }
        }

        private void doneButton_t3_Click(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrEmpty(UserInput.Text) || int.Parse(UserInput.Text) < 0 || int.Parse(UserInput.Text) > 60)
            {
                MessageBox.Show("Please enter a number between 0 and 60!", "Oops!");
            }
            else
            {
                var main = App.Current.MainWindow as MainWindow;
               this.Visibility = System.Windows.Visibility.Hidden;// this.clock_hand.Visibility = 
               // doneButton_t3.IsEnabled = false;


                int t = main.Libet_Clock.last_beep_time(main.taskNum, main.type, main.sub_type);
                write_answer(main.taskType[main.type], main.taskNum, "CorrectAnswer:", t);

                //  int t2 = estimate_time();
                // write_answer(main.taskType[main.type], main.taskNum, "EstimateAnswer:", t2);
                write_answer2(main.taskType[main.type], main.taskNum, "EstimateTextAnswer:", UserInput.Text);
                UserInput.Text = String.Empty;
                write_subtasktime(main.taskType[main.type], main.taskNum, "HideEstimateClock", System.DateTime.Now);


                if (main.countTask < 24)
                {
                    main.Libet_Clock.Visibility = main.Libet_Clock.goButton_t3.Visibility = System.Windows.Visibility.Visible;
                    main.taskInstruction.Content = "Please click READY to start" + Environment.NewLine + "Keep clicking the round gradient BUTTON" + Environment.NewLine + "While listening to the BEEPS and observing the CLOCK";

                    // Random sub_Rnd = new Random();
                    main.sub_type = main.sub_type_array[main.subTask + 1] - 7;

                }
                else
                {
                    main.Task_Rating.Visibility = System.Windows.Visibility.Visible;
                    main.taskInstruction.Visibility = System.Windows.Visibility.Hidden;
                    main.countTask= main.subTask = 0;
                }
            }
        }

        private void doneButton_t4_Click(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrEmpty(UserInput.Text) || int.Parse(UserInput.Text) < 0 || int.Parse(UserInput.Text) > 60)
            {
                MessageBox.Show("Please enter a number between 0 and 60!", "Oops!");
            }
            else
            {
                var main = App.Current.MainWindow as MainWindow;
                this.Visibility = System.Windows.Visibility.Hidden;//this.clock_hand.Visibility = 
             //   doneButton_t4.IsEnabled = false;

                int t = main.Libet_Clock.last_beep_time(main.taskNum, main.type, main.sub_type);
                write_answer(main.taskType[main.type], main.taskNum, "CorrectAnswer:", t);

                //int t2 = estimate_time();
                // write_answer(main.taskType[main.type], main.taskNum, "EstimateAnswer:", t2);
                write_answer2(main.taskType[main.type], main.taskNum, "EstimateTextAnswer:", UserInput.Text);
                UserInput.Text = String.Empty;

                write_subtasktime(main.taskType[main.type], main.taskNum, "HideEstimateClock", System.DateTime.Now);


                if (main.countTask < 24)
                {
                    main.Libet_Clock.Visibility = main.Libet_Clock.goButton_t4.Visibility = System.Windows.Visibility.Visible;
                    main.taskInstruction.Content = "Please click READY to start" + Environment.NewLine + "Then click the round gradient BUTTON for 4 times" + Environment.NewLine + "Keep listening to the BEEPS and observing the CLOCK";
                    //Random sub_Rnd = new Random();
                    main.sub_type = main.sub_type_array[main.subTask + 1] - 7;
                }
                else
                {
                    main.Task_Rating.Visibility = System.Windows.Visibility.Visible;
                    main.taskInstruction.Visibility = System.Windows.Visibility.Hidden;
                    main.countTask = main.subTask = 0;
                }
            }
        }


        private void write_subtasktime(string taskType, int taskNum, string generator, DateTime dt)
        {
            var main = App.Current.MainWindow as MainWindow;


            var dir = new DirectoryInfo(System.IO.Path.GetDirectoryName(System.Environment.CurrentDirectory));

            string file = dir.Parent.FullName + @"\TXT\SubTaskTime.txt";

            StreamWriter sr;


            sr = File.AppendText(file);

            sr.WriteLine(dt.ToString("hh:mm:ss.fff") + "\t" + taskType + "\t" + taskNum + "\t" + generator);//将传入的字符串加上时间写入文本文件一行

            sr.Close();
        }
/*
        private int estimate_time()
        {
            int t = 0;

            if (clock_hand.X2 >= 150.5 && clock_hand.Y2 <= 150)
            {
                //t = (int)(2560 * (Math.Asin((clock_hand.X2 - 150) / 80) * 180 / Math.PI) / 360);
                t = (int)(2560 / 360 * (Math.Asin((clock_hand.X2 - 150.5) / 40) * 180 / Math.PI));
            }
            else if (clock_hand.X2 >= 150.5 && clock_hand.Y2 > 150)
            {
                // t = (int)(2560 * (90 + Math.Asin((clock_hand.Y2 - 149) / 80) * 180 / Math.PI) /360);
                t = (int)(2560 / 360 * (90 + Math.Asin((clock_hand.Y2 - 150) / 40) * 180 / Math.PI));

            }

            else if (clock_hand.X2 < 150.5 && clock_hand.Y2 > 150)
            {
                // t = (int)(2560 * (180 + Math.Asin((150 - clock_hand.X2) / 80) * 180 / Math.PI ) / 360);
                t = (int)(2560 / 360 * (180 + Math.Asin((150.5 - clock_hand.X2) / 40) * 180 / Math.PI));

            }
            else if (clock_hand.X2 < 150.5 && clock_hand.Y2 <= 150)
            {
                //t = (int)(2560 * (270 + Math.Asin((149 - clock_hand.Y2) / 80) * 180 / Math.PI) / 360);

                t = (int)(2560 / 360 * (270 + Math.Asin((150 - clock_hand.Y2) / 40) * 180 / Math.PI));

            }

            return t;

        }
*/

        private void write_answer(string taskType, int taskNum, string generator, int ms)
        {

            var dir = new DirectoryInfo(System.IO.Path.GetDirectoryName(System.Environment.CurrentDirectory));

            string file = dir.Parent.FullName + @"\TXT\Answers.txt";
            //("yyyy-MM-dd HH：mm：ss：ffff");

            StreamWriter sr;

            sr = File.AppendText(file);

            sr.WriteLine(taskType + "\t" + taskNum + "\t" + generator + "\t" + ms);//将传入的字符串加上时间写入文本文件一行
            sr.Close();
        }

        private void write_answer2(string taskType, int taskNum, string generator, string t)
        {

            var dir = new DirectoryInfo(System.IO.Path.GetDirectoryName(System.Environment.CurrentDirectory));

            string file = dir.Parent.FullName + @"\TXT\Answers.txt";
            //("yyyy-MM-dd HH：mm：ss：ffff");

            StreamWriter sr;

            sr = File.AppendText(file);

            sr.WriteLine(taskType + "\t" + taskNum + "\t" + generator + "\t" + t);//将传入的字符串加上时间写入文本文件一行
            sr.Close();
        }

        private void UserInput_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !IsTextAllowed(e.Text);
        }

        private static bool IsTextAllowed(string text)
        {
            Regex regex = new Regex("[^0-9.-]+"); //regex that matches disallowed text
            return !regex.IsMatch(text);
        }
    }
}
