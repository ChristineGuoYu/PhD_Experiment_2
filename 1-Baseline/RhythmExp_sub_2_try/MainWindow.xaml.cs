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
using System.Windows.Media.Animation;
using System.IO;
using System.Timers;
using System.Windows.Forms;
using System.Media;

namespace RhythmExp_sub_2_try
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            var brush0 = new ImageBrush();
            brush0.ImageSource = new BitmapImage(new Uri("Images/ClickButton.png", UriKind.Relative));
            Libet_Clock.clickButton_t3.Background = Libet_Clock.clickButton_t4.Background = Libet_Clock.clickButton_bl_c.Background = brush0;
        }


        private Duration RotateDuration = new Duration(new TimeSpan(0, 0, 0, 0, 2560));
        private Duration ReverseDuration = new Duration(new TimeSpan(0, 0, 0, 0, 50));
        public DoubleAnimation ClockHandRotate;



        public DirectoryInfo dir = new DirectoryInfo(System.IO.Path.GetDirectoryName(System.Environment.CurrentDirectory));
        public string soundfile;
        public SoundPlayer playSound = new SoundPlayer();

        public int taskNum = 0;
        public int subTask = 0;
        public int countTask = 0;

        public DateTime[,] cue_click = new DateTime[500, 6];
        public TimeSpan[,] cue_interval = new TimeSpan[500, 6];
        public int[,] cue_interval_ms = new int[500, 6];

        public DateTime[,] pre_cue_click = new DateTime[500, 6];
        public TimeSpan[,] pre_cue_interval = new TimeSpan[500, 6];
        public int[,] pre_cue_interval_ms = new int[500, 6];


        public int type = 1; // This could be 0, 1, 2, 3 or 4, or 5 or 6
        public string[] taskType = { "SelfPacedClick", "ComputerRhythmic", "ComputerAperiodic", "UserActivated", "ComputerAligned", "BaselineClick", "BaselineBeep" };
        public int[] taskFlag = new int[7];

        public int sub_type = 0; // This could be 0, 1 or 2, or 3
        public string[] sub_taskType = { "7beeps", "8beeps", "9beeps", "baseline" };


        public int[] sub_type_array = new int[31];

        public void gen_sub_type_array()
        {
            int c_7 = 0;
            int c_8 = 0;
            int c_9 = 0;
            int sub = 0;
            int i = 1;
            Random sub_Rnd = new Random();
            string s = "";

            while (sub_type_array[30] != 7 && sub_type_array[30] != 8 && sub_type_array[30] != 9)
            {
                sub = 7 + sub_Rnd.Next(3);
                if (sub == 7)
                {
                    c_7 = count_7();
                    if (c_7 < 10)
                    {
                        sub_type_array[i] = sub;
                        i++;
                        s = s + "7" + ", ";
                    }
                }
                else if (sub == 8)
                {
                    c_8 = count_8();
                    if (c_8 < 10)
                    {
                        sub_type_array[i] = sub;
                        i++;
                        s = s + "8" + ", ";
                    }

                }
                else if (sub == 9)
                {
                    c_9 = count_9();
                    if (c_9 < 10)
                    {
                        sub_type_array[i] = sub;
                        i++;
                        s = s + "9" + ", ";
                    }
                }

            }
            timeinterval.Content = s;

        }


        public int count_7()
        {
            int c = 0;
            for (int i = 1; i <= 30; i++)
            {
                if (sub_type_array[i] == 7)
                    c++;
            }
            return c;
        }
        public int count_8()
        {
            int c = 0;
            for (int i = 1; i <= 30; i++)
            {
                if (sub_type_array[i] == 8)
                    c++;
            }
            return c;
        }
        public int count_9()
        {
            int c = 0;
            for (int i = 1; i <= 30; i++)
            {
                if (sub_type_array[i] == 9)
                    c++;
            }
            return c;
        }

        // public int rhythmic_interval = 660;

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            taskFlag[1] = taskFlag[2] = taskFlag[3] = taskFlag[4] = 0;
        }

        private void Task1Btn_Click(object sender, RoutedEventArgs e)
        {

            type = 1; taskFlag[1] = 1;

            gen_sub_type_array();
            //ReadSubType(sub_type_array);
            sub_type = sub_type_array[1] - 7;


            Libet_Clock.Visibility = Estimate_Clock.doneButton_t1.Visibility = taskInstruction.Visibility = System.Windows.Visibility.Visible;
            Libet_Clock.goButton_t1.Visibility = System.Windows.Visibility.Visible; //Libet_Clock.stopButton_t1.Visibility = Libet_Clock.resetButton_t1.Visibility =
            Libet_Clock.goButton_t2.Visibility = Libet_Clock.stopButton_t2.Visibility = Libet_Clock.resetButton_t2.Visibility = System.Windows.Visibility.Hidden;
            Libet_Clock.goButton_t3.Visibility = Libet_Clock.stopButton_t3.Visibility = Libet_Clock.resetButton_t3.Visibility = System.Windows.Visibility.Hidden;
            Libet_Clock.goButton_t4.Visibility = Libet_Clock.stopButton_t4.Visibility = Libet_Clock.resetButton_t4.Visibility = System.Windows.Visibility.Hidden;
            Task1Btn.Visibility = Task2Btn.Visibility = Task3Btn.Visibility = Task4Btn.Visibility = System.Windows.Visibility.Hidden;
            Estimate_Clock.doneButton_t2.Visibility = Estimate_Clock.doneButton_t3.Visibility = Estimate_Clock.doneButton_t4.Visibility = System.Windows.Visibility.Hidden;
            taskInstruction.Content = "Please listen to the beeps while observing the clock.";

        }

        private void Task2Btn_Click(object sender, RoutedEventArgs e)
        {
           

            type = 2; taskFlag[2] = 1;

            ReadSubType(sub_type_array);
            //gen_sub_type_array();
            sub_type = sub_type_array[1] - 7;
            ReadAperiodicInterval(Libet_Clock.aperiodic_interval);

            Libet_Clock.Visibility = Estimate_Clock.doneButton_t2.Visibility = taskInstruction.Visibility = System.Windows.Visibility.Visible;
            Libet_Clock.goButton_t1.Visibility = Libet_Clock.stopButton_t1.Visibility = Libet_Clock.resetButton_t1.Visibility = System.Windows.Visibility.Hidden; //  
            Libet_Clock.goButton_t2.Visibility = System.Windows.Visibility.Visible; //Libet_Clock.stopButton_t2.Visibility = Libet_Clock.resetButton_t2.Visibility =
            Libet_Clock.goButton_t3.Visibility = Libet_Clock.stopButton_t3.Visibility = Libet_Clock.resetButton_t3.Visibility = System.Windows.Visibility.Hidden;
            Libet_Clock.goButton_t4.Visibility = Libet_Clock.stopButton_t4.Visibility = Libet_Clock.resetButton_t4.Visibility = System.Windows.Visibility.Hidden;
            Task1Btn.Visibility = Task2Btn.Visibility = Task3Btn.Visibility = Task4Btn.Visibility = System.Windows.Visibility.Hidden;
            Estimate_Clock.doneButton_t1.Visibility = Estimate_Clock.doneButton_t3.Visibility = Estimate_Clock.doneButton_t4.Visibility = System.Windows.Visibility.Hidden;
            taskInstruction.Content = "Please listen to the beeps while observing the clock.";

        }

        private void Task3Btn_Click(object sender, RoutedEventArgs e)
        {
            type = 3; taskFlag[3] = 1;

            gen_sub_type_array();
            sub_type = sub_type_array[1] - 7;

            Libet_Clock.Visibility = Estimate_Clock.doneButton_t3.Visibility = taskInstruction.Visibility = System.Windows.Visibility.Visible;
            Libet_Clock.goButton_t1.Visibility = Libet_Clock.stopButton_t1.Visibility = Libet_Clock.resetButton_t1.Visibility = System.Windows.Visibility.Hidden; // 
            Libet_Clock.goButton_t2.Visibility = Libet_Clock.stopButton_t2.Visibility = Libet_Clock.resetButton_t2.Visibility = System.Windows.Visibility.Hidden;
            Libet_Clock.goButton_t3.Visibility = System.Windows.Visibility.Visible; //Libet_Clock.stopButton_t3.Visibility = Libet_Clock.resetButton_t3.Visibility =
            Libet_Clock.goButton_t4.Visibility = Libet_Clock.stopButton_t4.Visibility = Libet_Clock.resetButton_t4.Visibility = System.Windows.Visibility.Hidden;
            Task1Btn.Visibility = Task2Btn.Visibility = Task3Btn.Visibility = Task4Btn.Visibility = System.Windows.Visibility.Hidden;
            Estimate_Clock.doneButton_t2.Visibility = Estimate_Clock.doneButton_t1.Visibility = Estimate_Clock.doneButton_t4.Visibility = System.Windows.Visibility.Hidden;
            taskInstruction.Content = "Please click the round gradient BUTTON & listen to the beeps while observing the clock.";

        }

        private void Task4Btn_Click(object sender, RoutedEventArgs e)
        {
            type = 4; taskFlag[4] = 1;

            gen_sub_type_array();
            sub_type = sub_type_array[1] - 7;

            Libet_Clock.Visibility = Estimate_Clock.doneButton_t4.Visibility = taskInstruction.Visibility = System.Windows.Visibility.Visible;
            Libet_Clock.goButton_t1.Visibility = Libet_Clock.stopButton_t1.Visibility = Libet_Clock.resetButton_t1.Visibility = System.Windows.Visibility.Hidden;
            Libet_Clock.goButton_t2.Visibility = Libet_Clock.stopButton_t2.Visibility = Libet_Clock.resetButton_t2.Visibility = System.Windows.Visibility.Hidden;
            Libet_Clock.goButton_t3.Visibility = Libet_Clock.stopButton_t3.Visibility = Libet_Clock.resetButton_t3.Visibility = System.Windows.Visibility.Hidden;
            Libet_Clock.goButton_t4.Visibility = System.Windows.Visibility.Visible; //= Libet_Clock.stopButton_t4.Visibility = Libet_Clock.resetButton_t4.Visibility
            Task1Btn.Visibility = Task2Btn.Visibility = Task3Btn.Visibility = Task4Btn.Visibility = System.Windows.Visibility.Hidden;
            Estimate_Clock.doneButton_t2.Visibility = Estimate_Clock.doneButton_t3.Visibility = Estimate_Clock.doneButton_t1.Visibility = System.Windows.Visibility.Hidden;
            taskInstruction.Content = "Please click the round gradient BUTTON & listen to the beeps while observing the clock.";

        }


        /*  //Animatated rectangle//
        AnimationClock clock;

        private void StartAnimation(Object sender, RoutedEventArgs e)
        {
            DoubleAnimation animation = new DoubleAnimation();
            animation.Duration = new Duration(TimeSpan.FromSeconds(5));
            animation.To = 500d;
            animation.From = 0d;
            clock = animation.CreateClock();
            rect.ApplyAnimationClock(Rectangle.WidthProperty, clock);
            //rect.ApplyAnimationClock(RotateTransform.AngleProperty, clock);
            //RotateTransform.AngleProperty
        }

        private void PauseAnimation(Object sender, RoutedEventArgs e)
        {
            clock.Controller.Pause();
        }

        private void ResumeAnimation(Object sender, RoutedEventArgs e)
        {
            clock.Controller.Resume();
        }

        private void StopAnimation(Object sender, RoutedEventArgs e)
        {
            clock.Controller.Stop();
        }
        */

        /*
    public void PlayBeep(object sender, EventArgs e)
    {
        if (uiTimer0.Enabled)
        {
            SystemSounds.Beep.Play();
        }
       // uiTimer0.Tick -= PlayBeep;
        //uiTimer0.Stop();
    }
    */
        public void ReadAperiodicInterval(int[,] aperiodic_interval)
        {
            var dir = new DirectoryInfo(System.IO.Path.GetDirectoryName(System.Environment.CurrentDirectory));

            string file = dir.Parent.FullName + @"\TXT\Aperiodic_Intervals\Aperiodic_Interval_1.txt";

            StreamReader sr = new StreamReader(file);

            // var lines = File.ReadAllLines(file).ToList();
            for (int i = 0; i < 30; i++)
            {
                string thisLine = sr.ReadLine();
                string[] thisLineData = thisLine.Split(new char[0]);

                for (int j = 0; j < sub_type_array[i + 1]; j++)
                {
                    aperiodic_interval[i, j] = Int32.Parse(thisLineData[j]);

                    // Int32.Parse(lines[i].Split('\t'));
                    //aperiodic_interval[i, j] = Int.TryParse(ioi_table.Rows[i][j]);
                }
            }



        }

        public void ReadSubType(int[] sub_type_array)
        {
            var dir = new DirectoryInfo(System.IO.Path.GetDirectoryName(System.Environment.CurrentDirectory));

            string file = dir.Parent.FullName + @"\TXT\Aperiodic_Intervals\sub_type_1.txt";

            StreamReader sr = new StreamReader(file);

            // var lines = File.ReadAllLines(file).ToList();
            
                string thisLine = sr.ReadLine();
                string[] thisLineData = thisLine.Split(new char[0]);
                for (int i = 1; i < 31; i++)
                {
                    sub_type_array[i] = Int32.Parse(thisLineData[i-1]);

                    // Int32.Parse(lines[i].Split('\t'));
                    //aperiodic_interval[i, j] = Int.TryParse(ioi_table.Rows[i][j]);
                }
            
        }

        private void Baseline_click_Btn_Click(object sender, RoutedEventArgs e)
        {
            type = 5; taskFlag[5] = 1;

           
            sub_type = 3;

            Libet_Clock.Visibility = Estimate_Clock.doneButton_bl_c.Visibility = taskInstruction.Visibility = System.Windows.Visibility.Visible;
            Libet_Clock.goButton_t1.Visibility = Libet_Clock.stopButton_t1.Visibility = Libet_Clock.resetButton_t1.Visibility = System.Windows.Visibility.Hidden; // 
            Libet_Clock.goButton_t2.Visibility = Libet_Clock.stopButton_t2.Visibility = Libet_Clock.resetButton_t2.Visibility = System.Windows.Visibility.Hidden;
            Libet_Clock.goButton_t3.Visibility = Libet_Clock.stopButton_t3.Visibility = Libet_Clock.resetButton_t3.Visibility = System.Windows.Visibility.Hidden;
            Libet_Clock.goButton_bl_c.Visibility = System.Windows.Visibility.Visible; //Libet_Clock.stopButton_t3.Visibility = Libet_Clock.resetButton_t3.Visibility =
            Libet_Clock.goButton_t4.Visibility = Libet_Clock.stopButton_t4.Visibility = Libet_Clock.resetButton_t4.Visibility = System.Windows.Visibility.Hidden;
            Libet_Clock.goButton_bl_b.Visibility = Libet_Clock.resetButton_bl_b.Visibility = System.Windows.Visibility.Hidden;

            Task1Btn.Visibility = Task2Btn.Visibility = Task3Btn.Visibility = Task4Btn.Visibility = Baseline_beep_Btn.Visibility = Baseline_click_Btn.Visibility = System.Windows.Visibility.Hidden;
            Estimate_Clock.doneButton_t2.Visibility = Estimate_Clock.doneButton_t1.Visibility = Estimate_Clock.doneButton_t4.Visibility = Estimate_Clock.doneButton_t3.Visibility = Estimate_Clock.doneButton_bl_b.Visibility = System.Windows.Visibility.Hidden;
            taskInstruction.Content = "Please click READY to start" + Environment.NewLine + "Then click the round gradient BUTTON while observing the CLOCK";

        }

        private void Baseline_beep_Btn_Click(object sender, RoutedEventArgs e)
        {
            type = 6; taskFlag[6] = 1;


            sub_type = 3;

            Libet_Clock.Visibility = Estimate_Clock.doneButton_bl_b.Visibility = taskInstruction.Visibility = System.Windows.Visibility.Visible;
            Libet_Clock.goButton_t1.Visibility = Libet_Clock.stopButton_t1.Visibility = Libet_Clock.resetButton_t1.Visibility = System.Windows.Visibility.Hidden; // 
            Libet_Clock.goButton_t2.Visibility = Libet_Clock.stopButton_t2.Visibility = Libet_Clock.resetButton_t2.Visibility = System.Windows.Visibility.Hidden;
            Libet_Clock.goButton_t3.Visibility = Libet_Clock.stopButton_t3.Visibility = Libet_Clock.resetButton_t3.Visibility = System.Windows.Visibility.Hidden;
            Libet_Clock.goButton_bl_b.Visibility = System.Windows.Visibility.Visible; //Libet_Clock.stopButton_t3.Visibility = Libet_Clock.resetButton_t3.Visibility =
            Libet_Clock.goButton_t4.Visibility = Libet_Clock.stopButton_t4.Visibility = Libet_Clock.resetButton_t4.Visibility = System.Windows.Visibility.Hidden;
            Libet_Clock.goButton_bl_c.Visibility = Libet_Clock.resetButton_bl_c.Visibility = System.Windows.Visibility.Hidden;

            Task1Btn.Visibility = Task2Btn.Visibility = Task3Btn.Visibility = Task4Btn.Visibility = Baseline_beep_Btn.Visibility = Baseline_click_Btn.Visibility = System.Windows.Visibility.Hidden;
            Estimate_Clock.doneButton_t2.Visibility = Estimate_Clock.doneButton_t1.Visibility = Estimate_Clock.doneButton_t4.Visibility = Estimate_Clock.doneButton_t3.Visibility = Estimate_Clock.doneButton_bl_c.Visibility = System.Windows.Visibility.Hidden;
            taskInstruction.Content = "Please click READY to start" + Environment.NewLine + "Then listen to the BEEP while observing the CLOCK";
        
        }
    }


}
