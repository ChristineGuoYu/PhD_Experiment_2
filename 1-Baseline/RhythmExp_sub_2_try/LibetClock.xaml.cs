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
using System.Media;
using System.IO;
using System.Timers;
//using System.Windows.Interactivity;
using System.Threading;
using System.ComponentModel;
using System.Data;
//using System.Windows.Forms;

namespace RhythmExp_sub_2_try
{
    /// <summary>
    /// Interaction logic for LibetClock.xaml
    /// </summary>
    public partial class LibetClock : UserControl
    {
        public LibetClock()
        {
            InitializeComponent();
        }

     //   public int subtaskType = 1;
        public int goButtonFlag = 0;

        public System.Windows.Forms.Timer uiTimer0_1 = new System.Windows.Forms.Timer();
        public System.Windows.Forms.Timer uiTimer0_2 = new System.Windows.Forms.Timer();
        public System.Windows.Forms.Timer uiTimer0_3 = new System.Windows.Forms.Timer();
        public System.Windows.Forms.Timer uiTimer0_4 = new System.Windows.Forms.Timer();

        public System.Windows.Forms.Timer uiTimer1 = new System.Windows.Forms.Timer();
        public System.Windows.Forms.Timer uiTimer2 = new System.Windows.Forms.Timer();
        public System.Windows.Forms.Timer uiTimer3 = new System.Windows.Forms.Timer();
        public System.Windows.Forms.Timer uiTimer4 = new System.Windows.Forms.Timer();
        public System.Windows.Forms.Timer uiTimer5 = new System.Windows.Forms.Timer();

        public System.Windows.Forms.Timer uiTimer_end = new System.Windows.Forms.Timer();

        public System.Windows.Forms.Timer uiTimer_btn_blink = new System.Windows.Forms.Timer();


        public int countBeep_t1 = 0; // Could be 7 or 8 or 9 depending on subtask type
        public int countBeep_t2 = 0;
        public int countBeep_t3 = 0;
        public int countBeep_t4 = 0;


        public int[,] aperiodic_interval = new int[36, 9];
    
        public int rhythmic_interval = 660;

        /*
                public void SetAperiodicInterval(int subtaskType, int periodic_interval, int half_range, int exclude_window, int totalDurVariation, int[,] aperiodic_interval)
                {

                    int totalDur = 1;
                    int sum = 0;

                    totalDur = (subtaskType + 7) * periodic_interval;
                    Random time_Rnd = new Random();

                    aperiodic_interval[0] = periodic_interval + time_Rnd.Next(-half_range, half_range);
                    while (sum > totalDur + totalDurVariation || sum < totalDur - totalDurVariation)
                    {
                        for (int i = 1; i < subtaskType + 7; i++)
                        {
                            do
                            {
                                aperiodic_interval[i] = periodic_interval + time_Rnd.Next(-half_range, half_range);
                            }

                            while (aperiodic_interval[i] <= aperiodic_interval[i - 1] + exclude_window
                                && aperiodic_interval[i] >= aperiodic_interval[i - 1] - exclude_window);
                            //Console.Write(aperiodic_interval[i].ToString());


                            sum = sum + aperiodic_interval[i];
                        }
                    }




                    if (subtaskType == 2)
                    {
                        uiTimer0_1.Interval = aperiodic_interval[0]; uiTimer0_1.Tick += BeepTimer0_1;
                        uiTimer0_2.Interval = uiTimer0_1.Interval + aperiodic_interval[1]; uiTimer0_2.Tick += BeepTimer0_2;
                        uiTimer0_3.Interval = uiTimer0_2.Interval + aperiodic_interval[2]; uiTimer0_3.Tick += BeepTimer0_3;
                        uiTimer0_4.Interval = uiTimer0_3.Interval + aperiodic_interval[3]; uiTimer0_4.Tick += BeepTimer0_4;
                        uiTimer1.Interval = uiTimer0_4.Interval + aperiodic_interval[4]; uiTimer1.Tick += BeepTimer1;
                        uiTimer2.Interval = uiTimer1.Interval + aperiodic_interval[5]; uiTimer2.Tick += BeepTimer1;
                        uiTimer3.Interval = uiTimer2.Interval + aperiodic_interval[6]; uiTimer3.Tick += BeepTimer3;
                        uiTimer4.Interval = uiTimer3.Interval + aperiodic_interval[7]; uiTimer4.Tick += BeepTimer4;
                        uiTimer5.Interval = uiTimer4.Interval + aperiodic_interval[8]; uiTimer5.Tick += BeepTimer5;
                        uiTimer_end.Interval = 1000 + totalDur; uiTimer_end.Tick += HideLibetClock;
                    }
                    else if (subtaskType == 1)
                    {
                        uiTimer0_1.Interval = aperiodic_interval[0]; uiTimer0_1.Tick += BeepTimer0_1;
                        uiTimer0_2.Interval = uiTimer0_1.Interval + aperiodic_interval[1]; uiTimer0_2.Tick += BeepTimer0_2;
                        uiTimer0_3.Interval = uiTimer0_2.Interval + aperiodic_interval[2]; uiTimer0_3.Tick += BeepTimer0_3;
                        uiTimer0_4.Interval = uiTimer0_3.Interval + aperiodic_interval[3]; uiTimer0_4.Tick += BeepTimer0_4;
                        uiTimer1.Interval = uiTimer0_4.Interval + aperiodic_interval[4]; uiTimer1.Tick += BeepTimer1;
                        uiTimer2.Interval = uiTimer1.Interval + aperiodic_interval[5]; uiTimer2.Tick += BeepTimer1;
                        uiTimer3.Interval = uiTimer2.Interval + aperiodic_interval[6]; uiTimer3.Tick += BeepTimer3;
                        uiTimer4.Interval = uiTimer3.Interval + aperiodic_interval[7]; uiTimer4.Tick += BeepTimer4;
                        uiTimer_end.Interval = 1000 + totalDur; uiTimer_end.Tick += HideLibetClock;
                    }
                    else if (subtaskType == 0)
                    {
                        uiTimer0_1.Interval = aperiodic_interval[0]; uiTimer0_1.Tick += BeepTimer0_1;
                        uiTimer0_2.Interval = uiTimer0_1.Interval + aperiodic_interval[1]; uiTimer0_2.Tick += BeepTimer0_2;
                        uiTimer0_3.Interval = uiTimer0_2.Interval + aperiodic_interval[2]; uiTimer0_3.Tick += BeepTimer0_3;
                        uiTimer0_4.Interval = uiTimer0_3.Interval + aperiodic_interval[3]; uiTimer0_4.Tick += BeepTimer0_4;
                        uiTimer1.Interval = uiTimer0_4.Interval + aperiodic_interval[4]; uiTimer1.Tick += BeepTimer1;
                        uiTimer2.Interval = uiTimer1.Interval + aperiodic_interval[5]; uiTimer2.Tick += BeepTimer1;
                        uiTimer3.Interval = uiTimer2.Interval + aperiodic_interval[6]; uiTimer3.Tick += BeepTimer3;
                        uiTimer_end.Interval = 1000 + totalDur; uiTimer_end.Tick += HideLibetClock;
                    }

                    var main = App.Current.MainWindow as MainWindow;
                    main.timeinterval.Content = aperiodic_interval[0].ToString() + ", " +
                        aperiodic_interval[1].ToString() + ", " + aperiodic_interval[2].ToString() + ", " + aperiodic_interval[3].ToString() + ", " +
                        aperiodic_interval[4].ToString() + ", " + aperiodic_interval[5].ToString() + ", " + aperiodic_interval[6].ToString() + ", " +
                        aperiodic_interval[7].ToString() + ", " + aperiodic_interval[8].ToString() + " || " + sum.ToString();



                    return;
                }

                    */




        public void BeepTimer0_1(object sender, EventArgs e)
        {
            if (uiTimer0_1.Enabled)
            {

                // var dir = new DirectoryInfo(System.IO.Path.GetDirectoryName(System.Environment.CurrentDirectory));

                /*
                soundfile = dir.Parent.FullName + @"\Sound\ClickSound.wav";                           
                playSound.SoundLocation = soundfile;
                playSound.Play();
                */
                //Console.Beep(4200, 50);
                BackgroundBeep.Beep();
            }
            uiTimer0_1.Tick -= BeepTimer0_1;
            uiTimer0_1.Stop();
        }

        public void BeepTimer0_2(object sender, EventArgs e)
        {
            if (uiTimer0_2.Enabled)
            {

                //var dir = new DirectoryInfo(System.IO.Path.GetDirectoryName(System.Environment.CurrentDirectory));
                /*
                soundfile = dir.Parent.FullName + @"\Sound\ShortTone.wav";               
                playSound.SoundLocation = soundfile;              
                playSound.Play();
                */
                //Console.Beep(4200, 50);
                BackgroundBeep.Beep();
            }
            uiTimer0_2.Tick -= BeepTimer0_2;
            uiTimer0_2.Stop();
        }

        public void BeepTimer0_3(object sender, EventArgs e)
        {
            if (uiTimer0_3.Enabled)
            {

                //var dir = new DirectoryInfo(System.IO.Path.GetDirectoryName(System.Environment.CurrentDirectory));

                /*
                soundfile = dir.Parent.FullName + @"\Sound\ShortTone.wav";
                playSound.SoundLocation = soundfile;
                playSound.Play();
                */
                //Console.Beep(4200, 50);
                BackgroundBeep.Beep();
            }
            uiTimer0_3.Tick -= BeepTimer0_3;
            uiTimer0_3.Stop();
        }

        public void BeepTimer0_4(object sender, EventArgs e)
        {
            if (uiTimer0_4.Enabled)
            {
                //var dir = new DirectoryInfo(System.IO.Path.GetDirectoryName(System.Environment.CurrentDirectory));
                /*
                soundfile = dir.Parent.FullName + @"\Sound\ShortTone.wav";               
                playSound.SoundLocation = soundfile;
                playSound.Play();
                */
                //Console.Beep(4200, 50);
                BackgroundBeep.Beep();
            }
            uiTimer0_4.Tick -= BeepTimer0_4;
            uiTimer0_4.Stop();
        }

        public void BeepTimer1(object sender, EventArgs e)
        {
            if (uiTimer1.Enabled)
            {
                //Console.Beep(4200, 50);
                BackgroundBeep.Beep();
            }
            uiTimer1.Tick -= BeepTimer1;
            uiTimer1.Stop();
        }

        public void BeepTimer2(object sender, EventArgs e)
        {
            if (uiTimer2.Enabled)
            {
                //Console.Beep(4200, 50);
                BackgroundBeep.Beep();
            }
            uiTimer2.Tick -= BeepTimer2;
            uiTimer2.Stop();
        }

        public void BeepTimer3(object sender, EventArgs e)
        {
            if (uiTimer3.Enabled)
            {
                //Console.Beep(4200, 50);
                BackgroundBeep.Beep();
            }
            uiTimer3.Tick -= BeepTimer3;
            uiTimer3.Stop();
        }

        public void BeepTimer4(object sender, EventArgs e)
        {
            if (uiTimer4.Enabled)
            {
                //Console.Beep(4200, 50);
                BackgroundBeep.Beep();
            }
            uiTimer4.Tick -= BeepTimer4;
            uiTimer4.Stop();

        }

        public void BeepTimer5(object sender, EventArgs e)
        {
            if (uiTimer5.Enabled)
            {
                //Console.Beep(4200, 50);
                BackgroundBeep.Beep();
            }
            uiTimer5.Tick -= BeepTimer5;
            uiTimer5.Stop();

        }

        /*
        public static RoutedEvent StopClockEvent = EventManager.RegisterRoutedEvent
            ("StopClock", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(LibetClock));

        public event RoutedEventHandler StopClock
        {
            add { AddHandler(StopClockEvent, value); }
            remove { RemoveHandler(StopClockEvent, value); }
        }
        */

        public void HideLibetClock(object sender, EventArgs e)
        {
            var main = App.Current.MainWindow as MainWindow;
            write_subtasktime(main.taskType[main.type], main.taskNum, "HideLibetClock", System.DateTime.Now);
            if (main.type == 1)
            {
                resetButton_t1.RaiseEvent(new RoutedEventArgs(Button.ClickEvent, resetButton_t1));
                if (main.sub_type == 0)
                {
                    write_rhythm(main.taskType[main.type], main.taskNum, "Computer-f4",  uiTimer0_1.Interval,
                        uiTimer0_2.Interval - uiTimer0_1.Interval, uiTimer0_3.Interval - uiTimer0_2.Interval, uiTimer0_4.Interval - uiTimer0_3.Interval, 0, System.DateTime.Now);
                    write_rhythm(main.taskType[main.type], main.taskNum, "Computer-l3", uiTimer1.Interval - uiTimer0_4.Interval,
    uiTimer2.Interval - uiTimer1.Interval, uiTimer3.Interval - uiTimer2.Interval, 0, 0, System.DateTime.Now);

                }
                else if (main.sub_type == 1)
                {
                    write_rhythm(main.taskType[main.type], main.taskNum, "Computer-f4", uiTimer0_1.Interval,
    uiTimer0_2.Interval - uiTimer0_1.Interval, uiTimer0_3.Interval - uiTimer0_2.Interval, uiTimer0_4.Interval - uiTimer0_3.Interval, 0, System.DateTime.Now);
                    write_rhythm(main.taskType[main.type], main.taskNum, "Computer-l4", uiTimer1.Interval - uiTimer0_4.Interval,
    uiTimer2.Interval - uiTimer1.Interval, uiTimer3.Interval - uiTimer2.Interval, uiTimer4.Interval - uiTimer3.Interval, 0, System.DateTime.Now);

                }
                else if (main.sub_type == 2)
                {
                    write_rhythm(main.taskType[main.type], main.taskNum, "Computer-f4", uiTimer0_1.Interval,
uiTimer0_2.Interval - uiTimer0_1.Interval, uiTimer0_3.Interval - uiTimer0_2.Interval, uiTimer0_4.Interval - uiTimer0_3.Interval, 0, System.DateTime.Now);
                    write_rhythm(main.taskType[main.type], main.taskNum, "Computer-l5", uiTimer1.Interval - uiTimer0_4.Interval,
    uiTimer2.Interval - uiTimer1.Interval, uiTimer3.Interval - uiTimer2.Interval, uiTimer4.Interval - uiTimer3.Interval,
    uiTimer5.Interval - uiTimer4.Interval, System.DateTime.Now);

                }

            }
            else if (main.type == 2)
            {
                resetButton_t2.RaiseEvent(new RoutedEventArgs(Button.ClickEvent, resetButton_t2));
                if (main.sub_type == 0)
                {
                    write_rhythm(main.taskType[main.type], main.taskNum, "Computer-f4", aperiodic_interval[main.countTask - 1, 0],
aperiodic_interval[main.countTask - 1, 1], aperiodic_interval[main.countTask - 1, 2], aperiodic_interval[main.countTask - 1, 3], 0, System.DateTime.Now);

                    write_rhythm(main.taskType[main.type], main.taskNum, "Computer-l3", aperiodic_interval[main.countTask - 1, 4],
    aperiodic_interval[main.countTask - 1, 5], aperiodic_interval[main.countTask - 1, 6], 0, 0, System.DateTime.Now);
                }
                else if (main.sub_type == 1)
                {
                    write_rhythm(main.taskType[main.type], main.taskNum, "Computer-f4", aperiodic_interval[main.countTask - 1, 0],
aperiodic_interval[main.countTask - 1, 1], aperiodic_interval[main.countTask - 1, 2], aperiodic_interval[main.countTask - 1, 3], 0, System.DateTime.Now);

                    write_rhythm(main.taskType[main.type], main.taskNum, "Computer-l4", aperiodic_interval[main.countTask - 1, 4],
    aperiodic_interval[main.countTask - 1, 5], aperiodic_interval[main.countTask - 1, 6], aperiodic_interval[main.countTask - 1, 7],
    0, System.DateTime.Now);
                }
                else if (main.sub_type == 2)
                {
                    write_rhythm(main.taskType[main.type], main.taskNum, "Computer-f4", aperiodic_interval[main.countTask - 1, 0],
aperiodic_interval[main.countTask - 1, 1], aperiodic_interval[main.countTask - 1, 2], aperiodic_interval[main.countTask - 1, 3], 0, System.DateTime.Now);

                    write_rhythm(main.taskType[main.type], main.taskNum, "Computer-l5", aperiodic_interval[main.countTask - 1, 4],
    aperiodic_interval[main.countTask - 1, 5], aperiodic_interval[main.countTask - 1, 6], aperiodic_interval[main.countTask - 1, 7],
    aperiodic_interval[main.countTask - 1, 8], System.DateTime.Now);

                    
                }
            }
            else if (main.type == 3)
            {
                resetButton_t3.RaiseEvent(new RoutedEventArgs(Button.ClickEvent, resetButton_t3));
                if (main.sub_type == 0)
                {
                    write_rhythm(main.taskType[main.type], main.taskNum, "User-f4", main.pre_cue_interval_ms[main.taskNum, 1],
main.pre_cue_interval_ms[main.taskNum, 2], main.pre_cue_interval_ms[main.taskNum, 3], main.pre_cue_interval_ms[main.taskNum, 4], 0, System.DateTime.Now);
                    write_rhythm(main.taskType[main.type], main.taskNum, "User-l3", main.cue_interval_ms[main.taskNum, 1],
main.cue_interval_ms[main.taskNum, 2], main.cue_interval_ms[main.taskNum, 3], 0, 0, System.DateTime.Now);

                }
                else if (main.sub_type == 1)
                {
                    write_rhythm(main.taskType[main.type], main.taskNum, "User-f4", main.pre_cue_interval_ms[main.taskNum, 1],
main.pre_cue_interval_ms[main.taskNum, 2], main.pre_cue_interval_ms[main.taskNum, 3], main.pre_cue_interval_ms[main.taskNum, 4], 0, System.DateTime.Now);
                    write_rhythm(main.taskType[main.type], main.taskNum, "User-l4", main.cue_interval_ms[main.taskNum, 1],
main.cue_interval_ms[main.taskNum, 2], main.cue_interval_ms[main.taskNum, 3], main.cue_interval_ms[main.taskNum, 4], 0, System.DateTime.Now);
                }
                else if (main.sub_type == 2)
                {
                    write_rhythm(main.taskType[main.type], main.taskNum, "User-f4", main.pre_cue_interval_ms[main.taskNum, 1],
main.pre_cue_interval_ms[main.taskNum, 2], main.pre_cue_interval_ms[main.taskNum, 3], main.pre_cue_interval_ms[main.taskNum, 4], 0, System.DateTime.Now);
                    write_rhythm(main.taskType[main.type], main.taskNum, "User-l5", main.cue_interval_ms[main.taskNum, 1],
main.cue_interval_ms[main.taskNum, 2], main.cue_interval_ms[main.taskNum, 3], main.cue_interval_ms[main.taskNum, 4],
main.cue_interval_ms[main.taskNum, 5], System.DateTime.Now);
                }
                
            }
            else if (main.type == 4)
            {
                resetButton_t4.RaiseEvent(new RoutedEventArgs(Button.ClickEvent, resetButton_t4));
                if (main.sub_type == 0)
                {
                    write_rhythm(main.taskType[main.type], main.taskNum, "User-f4", main.pre_cue_interval_ms[main.taskNum, 1],
main.pre_cue_interval_ms[main.taskNum, 2], main.pre_cue_interval_ms[main.taskNum, 3], main.pre_cue_interval_ms[main.taskNum, 4], 0, System.DateTime.Now);
                    write_rhythm(main.taskType[main.type], main.taskNum, "Computer-l3", main.pre_cue_interval_ms[main.taskNum, 1],
main.pre_cue_interval_ms[main.taskNum, 2], main.pre_cue_interval_ms[main.taskNum, 3], 0, 0, System.DateTime.Now);


                }
                else if (main.sub_type == 1)
                {
                    write_rhythm(main.taskType[main.type], main.taskNum, "User-f4", main.pre_cue_interval_ms[main.taskNum, 1],
main.pre_cue_interval_ms[main.taskNum, 2], main.pre_cue_interval_ms[main.taskNum, 3], main.pre_cue_interval_ms[main.taskNum, 4], 0, System.DateTime.Now);
                    write_rhythm(main.taskType[main.type], main.taskNum, "Computer-l4", main.pre_cue_interval_ms[main.taskNum, 1],
main.pre_cue_interval_ms[main.taskNum, 2], main.pre_cue_interval_ms[main.taskNum, 3], main.pre_cue_interval_ms[main.taskNum, 4], 0, System.DateTime.Now);

                }
                else if (main.sub_type == 2)
                {
                    write_rhythm(main.taskType[main.type], main.taskNum, "User-f4", main.pre_cue_interval_ms[main.taskNum, 1],
main.pre_cue_interval_ms[main.taskNum, 2], main.pre_cue_interval_ms[main.taskNum, 3], main.pre_cue_interval_ms[main.taskNum, 4], 0, System.DateTime.Now);
                    write_rhythm(main.taskType[main.type], main.taskNum, "Computer-l5", main.pre_cue_interval_ms[main.taskNum, 1],
main.pre_cue_interval_ms[main.taskNum, 2], main.pre_cue_interval_ms[main.taskNum, 3], main.pre_cue_interval_ms[main.taskNum, 4], uiTimer4.Interval/4, System.DateTime.Now);

                }
            }

            else if (main.type == 5)
            {
                resetButton_bl_c.RaiseEvent(new RoutedEventArgs(Button.ClickEvent, resetButton_bl_c));
               
                    write_rhythm(main.taskType[main.type], main.taskNum, "Basline-User-Click", main.pre_cue_interval_ms[main.taskNum, 1],0,0,0,0, System.DateTime.Now);
                main.taskInstruction.Content = "Please enter the clock hand position when you clicked the round button." + Environment.NewLine + "(Number range: 0 - 60)";

            }

            else if (main.type == 6)
            {
                resetButton_bl_b.RaiseEvent(new RoutedEventArgs(Button.ClickEvent, resetButton_bl_b));

                write_rhythm(main.taskType[main.type], main.taskNum, "Basline-Computer-Beep", main.pre_cue_interval_ms[main.taskNum, 1], 0, 0, 0, 0, System.DateTime.Now);
                main.taskInstruction.Content = "Please enter the clock hand position when the beep occured." + Environment.NewLine + "(Number range: 0 - 60)";

            }

            // System.Windows.EventTrigger endClock = new System.Windows.EventTrigger();
            // RemoveStoryboard endRotate = new RemoveStoryboard();
            // endRotate.BeginStoryboardName = "Spin_t1_BeginStoryboard";
            //endClock.Actions.Add(endRotate);
            //endClock.RoutedEvent = ;
            // this.RaiseEvent();
            //resetButton_t1_Click(sender, new RoutedEventArgs(Button.ClickEvent, resetButton_t1));

            if (uiTimer_end.Enabled)
            {
                //Console.Beep(3000, 50);
            }
            ///StopClock += resetButton_t1_Click;
            // RaiseEvent(new RoutedEventArgs(StopClockEvent));


            //resetButton_t1_Click(sender, e);
            uiTimer_end.Tick -= HideLibetClock;
            uiTimer_end.Stop();
            this.Visibility = System.Windows.Visibility.Hidden;

            main.Cursor = System.Windows.Input.Cursors.Arrow;

            main.Estimate_Clock.Visibility = System.Windows.Visibility.Visible;
            write_subtasktime(main.taskType[main.type], main.taskNum, "ShowEstimateClock", System.DateTime.Now);
            //main.taskInstruction.Content = "Please enter the clock hand position on the last beep."+ Environment.NewLine +"(Number range: 0 - 60)";



        }

        public void btn_blink(object sender, EventArgs e)
        {
            if (uiTimer_btn_blink.Enabled)
            {
                
            }

            uiTimer_btn_blink.Tick -= btn_blink;
            uiTimer_btn_blink.Stop();
            var main = App.Current.MainWindow as MainWindow;
            if (main.type == 3)
            {
                clickButton_t3.Visibility = System.Windows.Visibility.Visible;
            }
            else if (main.type == 4)
            {
                clickButton_t4.Visibility = System.Windows.Visibility.Visible;
            }

        }

        /* Resume Button

        private void resumeButton_Click(object sender, RoutedEventArgs e)
        {
            Storyboard spinStoryboard = Resources["Spin"] as Storyboard;
            if (spinStoryboard != null)
            {
                if (spinStoryboard.GetIsPaused(this))
                {
                    spinStoryboard.Resume(this);
                }
                else
                {
                    spinStoryboard.Pause(this);
                }
            }
        }
        */


        private void goButton_t1_Click(object sender, RoutedEventArgs e)
        {
            var main = App.Current.MainWindow as MainWindow;
            main.taskNum++;
            main.countTask++;
            main.subTask++;
            write_subtasktime(main.taskType[main.type], main.taskNum, "StartLibetClock", System.DateTime.Now);

            rhythmic_interval = main.Preferred_Rhythm.t;

            uiTimer0_1.Interval = rhythmic_interval;
            uiTimer0_2.Interval = 2 * rhythmic_interval;
            uiTimer0_3.Interval = 3 * rhythmic_interval;
            uiTimer0_4.Interval = 4 * rhythmic_interval;
            uiTimer1.Interval = 5 * rhythmic_interval;
            uiTimer2.Interval = 6 * rhythmic_interval;
            uiTimer3.Interval = 7 * rhythmic_interval;
            uiTimer4.Interval = 8 * rhythmic_interval;
            uiTimer5.Interval = 9 * rhythmic_interval;
          
            //var main = App.Current.MainWindow as MainWindow;
            //SystemSounds.Beep.Play();
            if (goButtonFlag == 0)
            {
                goButtonFlag = 1;
                goButton_t1.IsEnabled = false;
                resetButton_t1.IsEnabled = stopButton_t1.IsEnabled = true; //resumeButton.IsEnabled =

                if (main.sub_type == 2)
                {
                uiTimer_end.Interval = 2000 + uiTimer5.Interval;
                uiTimer0_1.Tick += BeepTimer0_1;
                uiTimer0_2.Tick += BeepTimer0_2;
                uiTimer0_3.Tick += BeepTimer0_3;
                uiTimer0_4.Tick += BeepTimer0_4;
                uiTimer1.Tick += BeepTimer1;
                uiTimer2.Tick += BeepTimer2;
                uiTimer3.Tick += BeepTimer3;
                uiTimer4.Tick += BeepTimer4;
                uiTimer5.Tick += BeepTimer5;
                uiTimer_end.Tick += HideLibetClock;

                uiTimer0_1.Start();
                uiTimer0_2.Start();
                uiTimer0_3.Start();
                uiTimer0_4.Start();
                uiTimer1.Start();
                uiTimer2.Start();
                uiTimer3.Start();
                uiTimer4.Start();
                uiTimer5.Start();
                uiTimer_end.Start();

                }
                else if (main.sub_type == 1)
                {
                    uiTimer_end.Interval = 2000 + uiTimer4.Interval;
                    uiTimer0_1.Tick += BeepTimer0_1;
                    uiTimer0_2.Tick += BeepTimer0_2;
                    uiTimer0_3.Tick += BeepTimer0_3;
                    uiTimer0_4.Tick += BeepTimer0_4;
                    uiTimer1.Tick += BeepTimer1;
                    uiTimer2.Tick += BeepTimer2;
                    uiTimer3.Tick += BeepTimer3;
                    uiTimer4.Tick += BeepTimer4;
                    uiTimer_end.Tick += HideLibetClock;

                    uiTimer0_1.Start();
                    uiTimer0_2.Start();
                    uiTimer0_3.Start();
                    uiTimer0_4.Start();
                    uiTimer1.Start();
                    uiTimer2.Start();
                    uiTimer3.Start();
                    uiTimer4.Start();
                    uiTimer_end.Start();
                }
                else if
                     (main.sub_type == 0)
                {
                    uiTimer_end.Interval = 2000 + uiTimer3.Interval;
                    uiTimer0_1.Tick += BeepTimer0_1;
                    uiTimer0_2.Tick += BeepTimer0_2;
                    uiTimer0_3.Tick += BeepTimer0_3;
                    uiTimer0_4.Tick += BeepTimer0_4;
                    uiTimer1.Tick += BeepTimer1;
                    uiTimer2.Tick += BeepTimer2;
                    uiTimer3.Tick += BeepTimer3;
                    uiTimer_end.Tick += HideLibetClock;

                    uiTimer0_1.Start();
                    uiTimer0_2.Start();
                    uiTimer0_3.Start();
                    uiTimer0_4.Start();
                    uiTimer1.Start();
                    uiTimer2.Start();
                    uiTimer3.Start();
                    uiTimer_end.Start();
                }


                //main.uiTimer0.Interval = 1000;
                //main.uiTimer0.Tick += main.PlayBeep;
                //main.uiTimer0_1.Start();
                //SystemSounds.Beep.Play();

            }


        }

        private void stopButton_t1_Click(object sender, RoutedEventArgs e)
        {
            if (goButtonFlag == 1)
            {

            }


        }


        private void resetButton_t1_Click(object sender, RoutedEventArgs e)
        {
            if (goButtonFlag == 1)
            {
                goButtonFlag = 0;
                goButton_t1.IsEnabled = true;
                // resetButton_t1.IsEnabled = stopButton_t1.IsEnabled = false; //resumeButton.IsEnabled
            }
        }




        private void goButton_t2_Click(object sender, RoutedEventArgs e)
        {
            var main = App.Current.MainWindow as MainWindow;
            main.taskNum++;
            main.countTask++;
            main.subTask++;
            write_subtasktime(main.taskType[main.type], main.taskNum, "StartLibetClock", System.DateTime.Now);

            if (main.countTask == 1)
            {
                //main.ReadAperiodicInterval(aperiodic_interval);
            }
            if (goButtonFlag == 0)
            {
                goButtonFlag = 1;
                goButton_t2.IsEnabled = false;
                resetButton_t2.IsEnabled = stopButton_t2.IsEnabled = true;

                //    SetAperiodicInterval(1, 660, 250, 25, 10, aperiodic_interval);
                /*
                Random timer_Rnd = new Random();
                int a1 = timer_Rnd.Next(100); int a2 = timer_Rnd.Next(100);
                int b1 = timer_Rnd.Next(100); int b2 = timer_Rnd.Next(100);
                int c1 = timer_Rnd.Next(100); int c2 = timer_Rnd.Next(100);
                int d1 = timer_Rnd.Next(100); int d2 = timer_Rnd.Next(100);
                int e1 = timer_Rnd.Next(100);

                uiTimer0_1.Interval = 250 + 3000 * a1 / (a1 + b1 + c1 + d1 + e1); uiTimer0_1.Tick += BeepTimer0_1;
                uiTimer0_2.Interval = uiTimer0_1.Interval + 250 + 3000 * b1 / (a1 + b1 + c1 + d1 + e1); uiTimer0_2.Tick += BeepTimer0_2;
                uiTimer0_3.Interval = uiTimer0_2.Interval + 250 + 3000 * c1 / (a1 + b1 + c1 + d1 + e1); uiTimer0_3.Tick += BeepTimer0_3;
                uiTimer0_4.Interval = uiTimer0_3.Interval + 250 + 3000 * d1 / (a1 + b1 + c1 + d1 + e1); uiTimer0_4.Tick += BeepTimer0_4;

                uiTimer1.Interval = 4000 + 250 + 3250 * a2 / (a2 + b2 + c2 + d2); uiTimer1.Tick += BeepTimer1;
                uiTimer2.Interval = uiTimer1.Interval + 250 + 3250 * b2 / (a2 + b2 + c2 + d2); uiTimer2.Tick += BeepTimer2;
                uiTimer3.Interval = uiTimer2.Interval + 250 + 3250 * c2 / (a2 + b2 + c2 + d2); uiTimer3.Tick += BeepTimer3;
                uiTimer4.Interval = 8000; uiTimer4.Tick += BeepTimer4;
                uiTimer5.Interval = 9000; uiTimer5.Tick += HideLibetClock;
                */
                if (main.sub_type == 2)
                {
                    uiTimer0_1.Interval = aperiodic_interval[main.countTask - 1, 0]; uiTimer0_1.Tick += BeepTimer0_1;
                    uiTimer0_2.Interval = uiTimer0_1.Interval + aperiodic_interval[main.countTask - 1, 1]; uiTimer0_2.Tick += BeepTimer0_2;
                    uiTimer0_3.Interval = uiTimer0_2.Interval + aperiodic_interval[main.countTask - 1, 2]; uiTimer0_3.Tick += BeepTimer0_3;
                    uiTimer0_4.Interval = uiTimer0_3.Interval + aperiodic_interval[main.countTask - 1, 3]; uiTimer0_4.Tick += BeepTimer0_4;
                    uiTimer1.Interval = uiTimer0_4.Interval + aperiodic_interval[main.countTask - 1, 4]; uiTimer1.Tick += BeepTimer1;
                    uiTimer2.Interval = uiTimer1.Interval + aperiodic_interval[main.countTask - 1, 5]; uiTimer2.Tick += BeepTimer2;
                    uiTimer3.Interval = uiTimer2.Interval + aperiodic_interval[main.countTask - 1, 6]; uiTimer3.Tick += BeepTimer3;
                    uiTimer4.Interval = uiTimer3.Interval + aperiodic_interval[main.countTask - 1, 7]; uiTimer4.Tick += BeepTimer4;
                    uiTimer5.Interval = uiTimer4.Interval + aperiodic_interval[main.countTask - 1, 8]; uiTimer5.Tick += BeepTimer5;
                    uiTimer_end.Interval = 2000 + uiTimer5.Interval; uiTimer_end.Tick += HideLibetClock;
                    uiTimer0_1.Start();
                    uiTimer0_2.Start();
                    uiTimer0_3.Start();
                    uiTimer0_4.Start();
                    uiTimer1.Start();
                    uiTimer2.Start();
                    uiTimer3.Start();
                    uiTimer4.Start();
                    uiTimer5.Start();
                    uiTimer_end.Start();
                }
                else if (main.sub_type == 1)
                {
                    uiTimer0_1.Interval = aperiodic_interval[main.countTask - 1, 0]; uiTimer0_1.Tick += BeepTimer0_1;
                    uiTimer0_2.Interval = uiTimer0_1.Interval + aperiodic_interval[main.countTask - 1, 1]; uiTimer0_2.Tick += BeepTimer0_2;
                    uiTimer0_3.Interval = uiTimer0_2.Interval + aperiodic_interval[main.countTask - 1, 2]; uiTimer0_3.Tick += BeepTimer0_3;
                    uiTimer0_4.Interval = uiTimer0_3.Interval + aperiodic_interval[main.countTask - 1, 3]; uiTimer0_4.Tick += BeepTimer0_4;
                    uiTimer1.Interval = uiTimer0_4.Interval + aperiodic_interval[main.countTask - 1, 4]; uiTimer1.Tick += BeepTimer1;
                    uiTimer2.Interval = uiTimer1.Interval + aperiodic_interval[main.countTask - 1, 5]; uiTimer2.Tick += BeepTimer2;
                    uiTimer3.Interval = uiTimer2.Interval + aperiodic_interval[main.countTask - 1, 6]; uiTimer3.Tick += BeepTimer3;
                    uiTimer4.Interval = uiTimer3.Interval + aperiodic_interval[main.countTask - 1, 7]; uiTimer4.Tick += BeepTimer4;
                    uiTimer_end.Interval = 2000 + uiTimer4.Interval; uiTimer_end.Tick += HideLibetClock;
                    uiTimer0_1.Start();
                    uiTimer0_2.Start();
                    uiTimer0_3.Start();
                    uiTimer0_4.Start();
                    uiTimer1.Start();
                    uiTimer2.Start();
                    uiTimer3.Start();
                    uiTimer4.Start();
                    uiTimer_end.Start();
                }
                else if (main.sub_type == 0)
                {
                    uiTimer0_1.Interval = aperiodic_interval[main.countTask - 1, 0]; uiTimer0_1.Tick += BeepTimer0_1;
                    uiTimer0_2.Interval = uiTimer0_1.Interval + aperiodic_interval[main.countTask - 1, 1]; uiTimer0_2.Tick += BeepTimer0_2;
                    uiTimer0_3.Interval = uiTimer0_2.Interval + aperiodic_interval[main.countTask - 1, 2]; uiTimer0_3.Tick += BeepTimer0_3;
                    uiTimer0_4.Interval = uiTimer0_3.Interval + aperiodic_interval[main.countTask - 1, 3]; uiTimer0_4.Tick += BeepTimer0_4;
                    uiTimer1.Interval = uiTimer0_4.Interval + aperiodic_interval[main.countTask - 1, 4]; uiTimer1.Tick += BeepTimer1;
                    uiTimer2.Interval = uiTimer1.Interval + aperiodic_interval[main.countTask - 1, 5]; uiTimer2.Tick += BeepTimer2;
                    uiTimer3.Interval = uiTimer2.Interval + aperiodic_interval[main.countTask - 1, 6]; uiTimer3.Tick += BeepTimer3;
                    uiTimer_end.Interval = 2000 + uiTimer3.Interval; uiTimer_end.Tick += HideLibetClock;
                    uiTimer0_1.Start();
                    uiTimer0_2.Start();
                    uiTimer0_3.Start();
                    uiTimer0_4.Start();
                    uiTimer1.Start();
                    uiTimer2.Start();
                    uiTimer3.Start();
                    uiTimer_end.Start();
                }




            }
        }

        private void stopButton_t2_Click(object sender, RoutedEventArgs e)
        {

        }

        private void resetButton_t2_Click(object sender, RoutedEventArgs e)
        {
            if (goButtonFlag == 1)
            {
                goButtonFlag = 0;
                goButton_t2.IsEnabled = true;
                // resetButton_t2.IsEnabled = stopButton_t2.IsEnabled = false; //resumeButton.IsEnabled
            }
        }

        private void goButton_t3_Click(object sender, RoutedEventArgs e)
        {

            var main = App.Current.MainWindow as MainWindow;
            write_subtasktime(main.taskType[main.type], main.taskNum, "StartLibetClock", System.DateTime.Now);

            clickButton_t3.Visibility = System.Windows.Visibility.Visible;
            goButton_t3.Visibility = System.Windows.Visibility.Hidden;

            uiTimer_btn_blink.Interval = 150;


            if (goButtonFlag == 0)
            {
                goButtonFlag = 1;
                goButton_t3.IsEnabled = false;
                clickButton_t3.IsEnabled = true;
                main.taskNum++;
                main.countTask++;
                main.subTask++;
                main.pre_cue_click[main.taskNum, 0] = System.DateTime.Now;
            }
        }

        private void stopButton_t3_Click(object sender, RoutedEventArgs e)
        {

        }

        private void resetButton_t3_Click(object sender, RoutedEventArgs e)
        {
            if (goButtonFlag == 1)
            {
                goButtonFlag = 0;
                goButton_t3.IsEnabled = true;
                //clickButton_t3.IsEnabled = false;

                //   resetButton_t3.IsEnabled = stopButton_t3.IsEnabled = false; //resumeButton.IsEnabled
            }
        }

        private void goButton_t4_Click(object sender, RoutedEventArgs e)
        {
            var main = App.Current.MainWindow as MainWindow;
            write_subtasktime(main.taskType[main.type], main.taskNum, "StartLibetClock", System.DateTime.Now);

            clickButton_t4.Visibility = System.Windows.Visibility.Visible;
            goButton_t4.Visibility = System.Windows.Visibility.Hidden;

            uiTimer_btn_blink.Interval = 150;


            if (goButtonFlag == 0)
            {
                goButtonFlag = 1;
                clickButton_t4.IsEnabled = true;
                goButton_t4.IsEnabled = false;

                main.taskNum++;
                main.countTask++;
                main.subTask++;
                main.pre_cue_click[main.taskNum, 0] = System.DateTime.Now;

            }
        }

        private void stopButton_t4_Click(object sender, RoutedEventArgs e)
        {

        }

        private void resetButton_t4_Click(object sender, RoutedEventArgs e)
        {
            if (goButtonFlag == 1)
            {
                goButtonFlag = 0;
                goButton_t4.IsEnabled = true;
                //   clickButton_t4.IsEnabled = false;

                //   resetButton_t4.IsEnabled = stopButton_t4.IsEnabled = false; //resumeButton.IsEnabled
            }
        }

        private void clickButton_t3_Click(object sender, RoutedEventArgs e)
        {
            countBeep_t3++;

            var main = App.Current.MainWindow as MainWindow;

            if(main.sub_type == 1) // countBeep up to 8
            {

                if (countBeep_t3 <= 4)
                {
                    //Console.Beep(4200, 50);
                    BackgroundBeep.Beep();
                    main.pre_cue_click[main.taskNum, countBeep_t3] = System.DateTime.Now;
                    clickButton_t3.Visibility = System.Windows.Visibility.Hidden;
                    uiTimer_btn_blink.Tick += btn_blink;
                    uiTimer_btn_blink.Start();


                }
                else if (countBeep_t3 > 4 && countBeep_t3 < 8)
                {
                    //Console.Beep(4200, 50);
                    BackgroundBeep.Beep();
                    main.cue_click[main.taskNum, countBeep_t3 - 4] = System.DateTime.Now;
                    clickButton_t3.Visibility = System.Windows.Visibility.Hidden;
                    uiTimer_btn_blink.Tick += btn_blink;
                    uiTimer_btn_blink.Start();
                }
                else if (countBeep_t3 == 8)
                {
                    //Console.Beep(4200, 50);
                    BackgroundBeep.Beep();
                    main.cue_click[main.taskNum, 4] = System.DateTime.Now;

                    clickButton_t3.IsEnabled = false;
                    clickButton_t3.Visibility = System.Windows.Visibility.Hidden;

                    countBeep_t3 = 0;
                    uiTimer_end.Interval = 2000;
                    uiTimer_end.Tick += HideLibetClock;
                    uiTimer_end.Start();

                    main.pre_cue_interval[main.taskNum, 1] = main.pre_cue_click[main.taskNum, 1] - main.pre_cue_click[main.taskNum, 0];
                    main.pre_cue_interval_ms[main.taskNum, 1] = Convert.ToInt32(main.pre_cue_interval[main.taskNum, 1].TotalMilliseconds);
                    main.pre_cue_interval[main.taskNum, 2] = main.pre_cue_click[main.taskNum, 2] - main.pre_cue_click[main.taskNum, 1];
                    main.pre_cue_interval_ms[main.taskNum, 2] = Convert.ToInt32(main.pre_cue_interval[main.taskNum, 2].TotalMilliseconds);
                    main.pre_cue_interval[main.taskNum, 3] = main.pre_cue_click[main.taskNum, 3] - main.pre_cue_click[main.taskNum, 2];
                    main.pre_cue_interval_ms[main.taskNum, 3] = Convert.ToInt32(main.pre_cue_interval[main.taskNum, 3].TotalMilliseconds);
                    main.pre_cue_interval[main.taskNum, 4] = main.pre_cue_click[main.taskNum, 4] - main.pre_cue_click[main.taskNum, 3];
                    main.pre_cue_interval_ms[main.taskNum, 4] = Convert.ToInt32(main.pre_cue_interval[main.taskNum, 4].TotalMilliseconds);

                    main.cue_interval[main.taskNum, 1] = main.cue_click[main.taskNum, 1] - main.pre_cue_click[main.taskNum, 4];
                    main.cue_interval_ms[main.taskNum, 1] = Convert.ToInt32(main.cue_interval[main.taskNum, 1].TotalMilliseconds);
                    main.cue_interval[main.taskNum, 2] = main.cue_click[main.taskNum, 2] - main.cue_click[main.taskNum, 1];
                    main.cue_interval_ms[main.taskNum, 2] = Convert.ToInt32(main.cue_interval[main.taskNum, 2].TotalMilliseconds);
                    main.cue_interval[main.taskNum, 3] = main.cue_click[main.taskNum, 3] - main.cue_click[main.taskNum, 2];
                    main.cue_interval_ms[main.taskNum, 3] = Convert.ToInt32(main.cue_interval[main.taskNum, 3].TotalMilliseconds);
                    main.cue_interval[main.taskNum, 4] = main.cue_click[main.taskNum, 4] - main.cue_click[main.taskNum, 3];
                    main.cue_interval_ms[main.taskNum, 4] = Convert.ToInt32(main.cue_interval[main.taskNum, 4].TotalMilliseconds);


                }
            }
            else if (main.sub_type == 0) // countBeep up to 7
            {

                if (countBeep_t3 <= 4)
                {
                    //Console.Beep(4200, 50);
                    BackgroundBeep.Beep();
                    main.pre_cue_click[main.taskNum, countBeep_t3] = System.DateTime.Now;
                    clickButton_t3.Visibility = System.Windows.Visibility.Hidden;
                    uiTimer_btn_blink.Tick += btn_blink;
                    uiTimer_btn_blink.Start();
                }
                else if (countBeep_t3 > 4 && countBeep_t3 < 7)
                {
                    //Console.Beep(4200, 50);
                    BackgroundBeep.Beep();
                    main.cue_click[main.taskNum, countBeep_t3 - 4] = System.DateTime.Now;
                    clickButton_t3.Visibility = System.Windows.Visibility.Hidden;
                    uiTimer_btn_blink.Tick += btn_blink;
                    uiTimer_btn_blink.Start();
                }
                else if (countBeep_t3 == 7)
                {
                    //Console.Beep(4200, 50);
                    BackgroundBeep.Beep();
                    main.cue_click[main.taskNum, 3] = System.DateTime.Now;

                    clickButton_t3.IsEnabled = false;
                    clickButton_t3.Visibility = System.Windows.Visibility.Hidden;

                    countBeep_t3 = 0;
                    uiTimer_end.Interval = 2000;
                    uiTimer_end.Tick += HideLibetClock;
                    uiTimer_end.Start();

                    main.pre_cue_interval[main.taskNum, 1] = main.pre_cue_click[main.taskNum, 1] - main.pre_cue_click[main.taskNum, 0];
                    main.pre_cue_interval_ms[main.taskNum, 1] = Convert.ToInt32(main.pre_cue_interval[main.taskNum, 1].TotalMilliseconds);
                    main.pre_cue_interval[main.taskNum, 2] = main.pre_cue_click[main.taskNum, 2] - main.pre_cue_click[main.taskNum, 1];
                    main.pre_cue_interval_ms[main.taskNum, 2] = Convert.ToInt32(main.pre_cue_interval[main.taskNum, 2].TotalMilliseconds);
                    main.pre_cue_interval[main.taskNum, 3] = main.pre_cue_click[main.taskNum, 3] - main.pre_cue_click[main.taskNum, 2];
                    main.pre_cue_interval_ms[main.taskNum, 3] = Convert.ToInt32(main.pre_cue_interval[main.taskNum, 3].TotalMilliseconds);
                    main.pre_cue_interval[main.taskNum, 4] = main.pre_cue_click[main.taskNum, 4] - main.pre_cue_click[main.taskNum, 3];
                    main.pre_cue_interval_ms[main.taskNum, 4] = Convert.ToInt32(main.pre_cue_interval[main.taskNum, 4].TotalMilliseconds);

                    main.cue_interval[main.taskNum, 1] = main.cue_click[main.taskNum, 1] - main.pre_cue_click[main.taskNum, 4];
                    main.cue_interval_ms[main.taskNum, 1] = Convert.ToInt32(main.cue_interval[main.taskNum, 1].TotalMilliseconds);
                    main.cue_interval[main.taskNum, 2] = main.cue_click[main.taskNum, 2] - main.cue_click[main.taskNum, 1];
                    main.cue_interval_ms[main.taskNum, 2] = Convert.ToInt32(main.cue_interval[main.taskNum, 2].TotalMilliseconds);
                    main.cue_interval[main.taskNum, 3] = main.cue_click[main.taskNum, 3] - main.cue_click[main.taskNum, 2];
                    main.cue_interval_ms[main.taskNum, 3] = Convert.ToInt32(main.cue_interval[main.taskNum, 3].TotalMilliseconds);

                }
            }
            else if (main.sub_type == 2) // // countBeep up to 9
            {

                if (countBeep_t3 <= 4)
                {
                    //Console.Beep(4200, 50);
                    BackgroundBeep.Beep();
                    main.pre_cue_click[main.taskNum, countBeep_t3] = System.DateTime.Now;
                    clickButton_t3.Visibility = System.Windows.Visibility.Hidden;
                    uiTimer_btn_blink.Tick += btn_blink;
                    uiTimer_btn_blink.Start();
                }
                else if (countBeep_t3 > 4 && countBeep_t3 < 9)
                {
                    //Console.Beep(4200, 50);
                    BackgroundBeep.Beep();
                    main.cue_click[main.taskNum, countBeep_t3 - 4] = System.DateTime.Now;
                    clickButton_t3.Visibility = System.Windows.Visibility.Hidden;
                    uiTimer_btn_blink.Tick += btn_blink;
                    uiTimer_btn_blink.Start();
                }
                else if (countBeep_t3 == 9)
                {
                    //Console.Beep(4200, 50);
                    BackgroundBeep.Beep();
                    main.cue_click[main.taskNum, 5] = System.DateTime.Now;

                    clickButton_t3.IsEnabled = false;
                    clickButton_t3.Visibility = System.Windows.Visibility.Hidden;

                    countBeep_t3 = 0;
                    uiTimer_end.Interval = 2000;
                    uiTimer_end.Tick += HideLibetClock;
                    uiTimer_end.Start();

                    main.pre_cue_interval[main.taskNum, 1] = main.pre_cue_click[main.taskNum, 1] - main.pre_cue_click[main.taskNum, 0];
                    main.pre_cue_interval_ms[main.taskNum, 1] = Convert.ToInt32(main.pre_cue_interval[main.taskNum, 1].TotalMilliseconds);
                    main.pre_cue_interval[main.taskNum, 2] = main.pre_cue_click[main.taskNum, 2] - main.pre_cue_click[main.taskNum, 1];
                    main.pre_cue_interval_ms[main.taskNum, 2] = Convert.ToInt32(main.pre_cue_interval[main.taskNum, 2].TotalMilliseconds);
                    main.pre_cue_interval[main.taskNum, 3] = main.pre_cue_click[main.taskNum, 3] - main.pre_cue_click[main.taskNum, 2];
                    main.pre_cue_interval_ms[main.taskNum, 3] = Convert.ToInt32(main.pre_cue_interval[main.taskNum, 3].TotalMilliseconds);
                    main.pre_cue_interval[main.taskNum, 4] = main.pre_cue_click[main.taskNum, 4] - main.pre_cue_click[main.taskNum, 3];
                    main.pre_cue_interval_ms[main.taskNum, 4] = Convert.ToInt32(main.pre_cue_interval[main.taskNum, 4].TotalMilliseconds);

                    main.cue_interval[main.taskNum, 1] = main.cue_click[main.taskNum, 1] - main.pre_cue_click[main.taskNum, 4];
                    main.cue_interval_ms[main.taskNum, 1] = Convert.ToInt32(main.cue_interval[main.taskNum, 1].TotalMilliseconds);
                    main.cue_interval[main.taskNum, 2] = main.cue_click[main.taskNum, 2] - main.cue_click[main.taskNum, 1];
                    main.cue_interval_ms[main.taskNum, 2] = Convert.ToInt32(main.cue_interval[main.taskNum, 2].TotalMilliseconds);
                    main.cue_interval[main.taskNum, 3] = main.cue_click[main.taskNum, 3] - main.cue_click[main.taskNum, 2];
                    main.cue_interval_ms[main.taskNum, 3] = Convert.ToInt32(main.cue_interval[main.taskNum, 3].TotalMilliseconds);
                    main.cue_interval[main.taskNum, 4] = main.cue_click[main.taskNum, 4] - main.cue_click[main.taskNum, 3];
                    main.cue_interval_ms[main.taskNum, 4] = Convert.ToInt32(main.cue_interval[main.taskNum, 4].TotalMilliseconds);
                    main.cue_interval[main.taskNum, 5] = main.cue_click[main.taskNum, 5] - main.cue_click[main.taskNum, 4];
                    main.cue_interval_ms[main.taskNum, 5] = Convert.ToInt32(main.cue_interval[main.taskNum, 5].TotalMilliseconds);


                }
            }
        }

        private void clickButton_t4_Click(object sender, RoutedEventArgs e)
        {
            countBeep_t4++;
            var main = App.Current.MainWindow as MainWindow;

            if (main.sub_type == 1)
            {
                if (countBeep_t4 < 4)
                {
                    //Console.Beep(4200, 50);
                    BackgroundBeep.Beep();
                    main.pre_cue_click[main.taskNum, countBeep_t4] = System.DateTime.Now;
                    clickButton_t4.Visibility = System.Windows.Visibility.Hidden;
                    uiTimer_btn_blink.Tick += btn_blink;
                    uiTimer_btn_blink.Start();
                }
                else if (countBeep_t4 == 4)
                {
                    //Console.Beep(4200, 50);
                    BackgroundBeep.Beep();
                    main.pre_cue_click[main.taskNum, countBeep_t4] = System.DateTime.Now;

                    clickButton_t4.IsEnabled = false;
                    clickButton_t4.Visibility = System.Windows.Visibility.Hidden;

                    countBeep_t4 = 0;
                    main.pre_cue_interval[main.taskNum, 1] = main.pre_cue_click[main.taskNum, 1] - main.pre_cue_click[main.taskNum, 0];
                    main.pre_cue_interval_ms[main.taskNum, 1] = Convert.ToInt32(main.pre_cue_interval[main.taskNum, 1].TotalMilliseconds);
                    main.pre_cue_interval[main.taskNum, 2] = main.pre_cue_click[main.taskNum, 2] - main.pre_cue_click[main.taskNum, 1];
                    main.pre_cue_interval_ms[main.taskNum, 2] = Convert.ToInt32(main.pre_cue_interval[main.taskNum, 2].TotalMilliseconds);
                    main.pre_cue_interval[main.taskNum, 3] = main.pre_cue_click[main.taskNum, 3] - main.pre_cue_click[main.taskNum, 2];
                    main.pre_cue_interval_ms[main.taskNum, 3] = Convert.ToInt32(main.pre_cue_interval[main.taskNum, 3].TotalMilliseconds);
                    main.pre_cue_interval[main.taskNum, 4] = main.pre_cue_click[main.taskNum, 4] - main.pre_cue_click[main.taskNum, 3];
                    main.pre_cue_interval_ms[main.taskNum, 4] = Convert.ToInt32(main.pre_cue_interval[main.taskNum, 4].TotalMilliseconds);

                    uiTimer1.Interval = main.pre_cue_interval_ms[main.taskNum, 1]; uiTimer1.Tick += BeepTimer1;
                    uiTimer2.Interval = uiTimer1.Interval + main.pre_cue_interval_ms[main.taskNum, 2]; uiTimer2.Tick += BeepTimer2;
                    uiTimer3.Interval = uiTimer2.Interval + main.pre_cue_interval_ms[main.taskNum, 3]; uiTimer3.Tick += BeepTimer3;
                    uiTimer4.Interval = uiTimer3.Interval + main.pre_cue_interval_ms[main.taskNum, 4]; uiTimer4.Tick += BeepTimer4;
                    uiTimer_end.Interval = uiTimer4.Interval + 2000; uiTimer_end.Tick += HideLibetClock;

                    uiTimer1.Start();
                    uiTimer2.Start();
                    uiTimer3.Start();
                    uiTimer4.Start();
                    uiTimer_end.Start();

                }
            }
            else if (main.sub_type == 2)
            {
                if (countBeep_t4 < 4)
                {
                    //Console.Beep(4200, 50);
                    BackgroundBeep.Beep();
                    main.pre_cue_click[main.taskNum, countBeep_t4] = System.DateTime.Now;
                    clickButton_t4.Visibility = System.Windows.Visibility.Hidden;
                    uiTimer_btn_blink.Tick += btn_blink;
                    uiTimer_btn_blink.Start();
                }
                else if (countBeep_t4 == 4)
                {
                    //Console.Beep(4200, 50);
                    BackgroundBeep.Beep();
                    main.pre_cue_click[main.taskNum, countBeep_t4] = System.DateTime.Now;

                    clickButton_t4.IsEnabled = false;
                    clickButton_t4.Visibility = System.Windows.Visibility.Hidden;

                    countBeep_t4 = 0;
                    main.pre_cue_interval[main.taskNum, 1] = main.pre_cue_click[main.taskNum, 1] - main.pre_cue_click[main.taskNum, 0];
                    main.pre_cue_interval_ms[main.taskNum, 1] = Convert.ToInt32(main.pre_cue_interval[main.taskNum, 1].TotalMilliseconds);
                    main.pre_cue_interval[main.taskNum, 2] = main.pre_cue_click[main.taskNum, 2] - main.pre_cue_click[main.taskNum, 1];
                    main.pre_cue_interval_ms[main.taskNum, 2] = Convert.ToInt32(main.pre_cue_interval[main.taskNum, 2].TotalMilliseconds);
                    main.pre_cue_interval[main.taskNum, 3] = main.pre_cue_click[main.taskNum, 3] - main.pre_cue_click[main.taskNum, 2];
                    main.pre_cue_interval_ms[main.taskNum, 3] = Convert.ToInt32(main.pre_cue_interval[main.taskNum, 3].TotalMilliseconds);
                    main.pre_cue_interval[main.taskNum, 4] = main.pre_cue_click[main.taskNum, 4] - main.pre_cue_click[main.taskNum, 3];
                    main.pre_cue_interval_ms[main.taskNum, 4] = Convert.ToInt32(main.pre_cue_interval[main.taskNum, 4].TotalMilliseconds);

                    uiTimer1.Interval = main.pre_cue_interval_ms[main.taskNum, 1]; uiTimer1.Tick += BeepTimer1;
                    uiTimer2.Interval = uiTimer1.Interval + main.pre_cue_interval_ms[main.taskNum, 2]; uiTimer2.Tick += BeepTimer2;
                    uiTimer3.Interval = uiTimer2.Interval + main.pre_cue_interval_ms[main.taskNum, 3]; uiTimer3.Tick += BeepTimer3;
                    uiTimer4.Interval = uiTimer3.Interval + main.pre_cue_interval_ms[main.taskNum, 4]; uiTimer4.Tick += BeepTimer4;
                    uiTimer5.Interval = uiTimer4.Interval * 5 / 4; uiTimer5.Tick += BeepTimer5;

                    uiTimer_end.Interval = uiTimer5.Interval + 2000; uiTimer_end.Tick += HideLibetClock;

                    uiTimer1.Start();
                    uiTimer2.Start();
                    uiTimer3.Start();
                    uiTimer4.Start();
                    uiTimer5.Start();
                    uiTimer_end.Start();
                }
            }
            else if (main.sub_type == 0)
            {
                if (countBeep_t4 < 4)
                {
                    //Console.Beep(4200, 50);
                    BackgroundBeep.Beep();
                    main.pre_cue_click[main.taskNum, countBeep_t4] = System.DateTime.Now;
                    clickButton_t4.Visibility = System.Windows.Visibility.Hidden;
                    uiTimer_btn_blink.Tick += btn_blink;
                    uiTimer_btn_blink.Start();
                }
                else if (countBeep_t4 == 4)
                {
                    //Console.Beep(4200, 50);
                    BackgroundBeep.Beep();
                    main.pre_cue_click[main.taskNum, countBeep_t4] = System.DateTime.Now;

                    clickButton_t4.IsEnabled = false;
                    clickButton_t4.Visibility = System.Windows.Visibility.Hidden;

                    countBeep_t4 = 0;
                    main.pre_cue_interval[main.taskNum, 1] = main.pre_cue_click[main.taskNum, 1] - main.pre_cue_click[main.taskNum, 0];
                    main.pre_cue_interval_ms[main.taskNum, 1] = Convert.ToInt32(main.pre_cue_interval[main.taskNum, 1].TotalMilliseconds);
                    main.pre_cue_interval[main.taskNum, 2] = main.pre_cue_click[main.taskNum, 2] - main.pre_cue_click[main.taskNum, 1];
                    main.pre_cue_interval_ms[main.taskNum, 2] = Convert.ToInt32(main.pre_cue_interval[main.taskNum, 2].TotalMilliseconds);
                    main.pre_cue_interval[main.taskNum, 3] = main.pre_cue_click[main.taskNum, 3] - main.pre_cue_click[main.taskNum, 2];
                    main.pre_cue_interval_ms[main.taskNum, 3] = Convert.ToInt32(main.pre_cue_interval[main.taskNum, 3].TotalMilliseconds);
                    main.pre_cue_interval[main.taskNum, 4] = main.pre_cue_click[main.taskNum, 4] - main.pre_cue_click[main.taskNum, 3];
                    main.pre_cue_interval_ms[main.taskNum, 4] = Convert.ToInt32(main.pre_cue_interval[main.taskNum, 4].TotalMilliseconds);

                    uiTimer1.Interval = main.pre_cue_interval_ms[main.taskNum, 1]; uiTimer1.Tick += BeepTimer1;
                    uiTimer2.Interval = uiTimer1.Interval + main.pre_cue_interval_ms[main.taskNum, 2]; uiTimer2.Tick += BeepTimer2;
                    uiTimer3.Interval = uiTimer2.Interval + main.pre_cue_interval_ms[main.taskNum, 3]; uiTimer3.Tick += BeepTimer3;

                    uiTimer_end.Interval = uiTimer3.Interval + 2000; uiTimer_end.Tick += HideLibetClock;

                    uiTimer1.Start();
                    uiTimer2.Start();
                    uiTimer3.Start();
                    uiTimer_end.Start();
                }
            }

     }

        private void write_rhythm(string taskType, int taskNum, string generator, int time1, int time2, int time3, int time4, int time5, DateTime dt)
        {
            var main = App.Current.MainWindow as MainWindow;

            System.DateTime currentTime = System.DateTime.Now;

            var dir = new DirectoryInfo(System.IO.Path.GetDirectoryName(System.Environment.CurrentDirectory));

            string file = dir.Parent.FullName + @"\TXT\Rhythm.txt";
            string strYMD = currentTime.ToString("dd-MM-yy");
            //("yyyy-MM-dd HH：mm：ss：ffff");

            string FILE_NAME = strYMD + ".txt";//每天按照日期建立一个不同的文件名
            StreamWriter sr;


            sr = File.AppendText(file);
            if (main.sub_type == 2)
            {
                if (generator == "User-f4" || generator == "Computer-f4")
                {
                    sr.WriteLine(dt.ToString("hh:mm:ss.fff") + "\t" + taskType + "\t" + taskNum + "\t" + generator + ":\t" + time1 + "\t" + time2 + "\t" + time3 + "\t" + time4);//将传入的字符串加上时间写入文本文件一行
                }
                else if (generator == "Computer-l5" || generator == "User-l5")
                {
                    sr.WriteLine(dt.ToString("hh:mm:ss.fff") + "\t" + taskType + "\t" + taskNum + "\t" + generator + ":\t" + time1 + "\t" + time2 + "\t" + time3 + "\t" + time4 + "\t" + time5);//将传入的字符串加上时间写入文本文件一行
                }

            }
            else if (main.sub_type == 1)
            {

                sr.WriteLine(dt.ToString("hh:mm:ss.fff") + "\t" + taskType + "\t" + taskNum + "\t" + generator + ":\t" + time1 + "\t" + time2 + "\t" + time3 + "\t" + time4);//将传入的字符串加上时间写入文本文件一行
            }
            else if (main.sub_type == 0)
            {
                if (generator == "User-f4" || generator == "Computer-f4")
                {
                    sr.WriteLine(dt.ToString("hh:mm:ss.fff") + "\t" + taskType + "\t" + taskNum + "\t" + generator + ":\t" + time1 + "\t" + time2 + "\t" + time3 + "\t" + time4);//将传入的字符串加上时间写入文本文件一行

                }
                else if (generator == "Computer-l3" || generator == "User-l3")
                {
                    sr.WriteLine(dt.ToString("hh:mm:ss.fff") + "\t" + taskType + "\t" + taskNum + "\t" + generator + ":\t" + time1 + "\t" + time2 + "\t" + time3);//将传入的字符串加上时间写入文本文件一行
                }
            }
            sr.Close();
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



        public int last_beep_time(int taskNum, int type, int sub_type)
        {
            var main = App.Current.MainWindow as MainWindow;

            int t = 0;
            if (type == 1 || type == 2)
            {
                if (sub_type == 0)
                {
                    t = uiTimer3.Interval % 2560;

                }
                else if (sub_type == 1)
                {
                    t = uiTimer4.Interval % 2560;

                }
                else if (sub_type == 2)
                {
                    t = uiTimer5.Interval % 2560;

                }
            }
            else if (type == 3)
            {
                if (sub_type == 0)
                {
                    t = (Convert.ToInt32((main.cue_click[main.taskNum, 3] - main.pre_cue_click[main.taskNum, 0]).TotalMilliseconds)) % 2560;
                }
                else if (sub_type == 1)
                {
                    t = (Convert.ToInt32((main.cue_click[main.taskNum, 4] - main.pre_cue_click[main.taskNum, 0]).TotalMilliseconds)) % 2560;

                }
                else if (sub_type == 2)
                {
                    t = (Convert.ToInt32((main.cue_click[main.taskNum, 5] - main.pre_cue_click[main.taskNum, 0]).TotalMilliseconds)) % 2560;

                }
            }
            else if (type == 4)
            {
                if (sub_type == 0)
                {
                    t = (uiTimer3.Interval + Convert.ToInt32((main.pre_cue_click[main.taskNum, 4] - main.pre_cue_click[main.taskNum, 0]).TotalMilliseconds)) % 2560;

                }
                else if (sub_type == 1)
                {
                    t = (uiTimer4.Interval + Convert.ToInt32((main.pre_cue_click[main.taskNum, 4] - main.pre_cue_click[main.taskNum, 0]).TotalMilliseconds)) % 2560;

                }
                else if (sub_type == 2)
                {
                    t = (uiTimer5.Interval + Convert.ToInt32((main.pre_cue_click[main.taskNum, 4] - main.pre_cue_click[main.taskNum, 0]).TotalMilliseconds)) % 2560;

                }
            }
            else if (type == 5)
            {
                t = (Convert.ToInt32((main.pre_cue_click[main.taskNum, 1] - main.pre_cue_click[main.taskNum, 0]).TotalMilliseconds)) % 2560;
            }
            else if (type == 6)
            {
                t = uiTimer0_1.Interval % 2560;
            }
            return t;
        }

        public System.Windows.Forms.Timer DelayTimer = new System.Windows.Forms.Timer();
        public void DelayTimer_1(object sender, EventArgs e)
        {
            if (DelayTimer.Enabled)
            {

                // var dir = new DirectoryInfo(System.IO.Path.GetDirectoryName(System.Environment.CurrentDirectory));

                /*
                soundfile = dir.Parent.FullName + @"\Sound\ClickSound.wav";                           
                playSound.SoundLocation = soundfile;
                playSound.Play();
                */
                //Console.Beep(4200, 50);
                clickButton_bl_c.Visibility = System.Windows.Visibility.Visible;
            }
            DelayTimer.Tick -= DelayTimer_1;
            DelayTimer.Stop();
        }

        private void goButton_bl_c_Click(object sender, RoutedEventArgs e)
        {
            var main = App.Current.MainWindow as MainWindow;
            write_subtasktime(main.taskType[main.type], main.taskNum, "StartLibetClock", System.DateTime.Now);

            //clickButton_bl_c.Visibility = System.Windows.Visibility.Visible;
            goButton_bl_c.Visibility = System.Windows.Visibility.Hidden;

           
            if (goButtonFlag == 0)
            {
                goButtonFlag = 1;
                goButton_bl_c.IsEnabled = false;
                clickButton_bl_c.IsEnabled = true;
                main.taskNum++;
                main.countTask++;
                main.subTask++;
                main.pre_cue_click[main.taskNum, 0] = System.DateTime.Now;

                DelayTimer.Interval = 500;
                DelayTimer.Tick += DelayTimer_1;
                DelayTimer.Start();


            }
        }

        private void goButton_bl_b_Click(object sender, RoutedEventArgs e)
        {
            var main = App.Current.MainWindow as MainWindow;
            main.taskNum++;
            main.countTask++;
            main.subTask++;
            write_subtasktime(main.taskType[main.type], main.taskNum, "StartLibetClock", System.DateTime.Now);

            Random time_Rnd = new Random();

            uiTimer0_1.Interval = time_Rnd.Next(1000, 3560);
        
            if (goButtonFlag == 0)
            {
                goButtonFlag = 1;
                goButton_bl_b.IsEnabled = false;
                resetButton_bl_b.IsEnabled  = true; //resumeButton.IsEnabled =

                
                
                    uiTimer_end.Interval = 2000 + uiTimer0_1.Interval;
                    uiTimer0_1.Tick += BeepTimer0_1;
                    uiTimer_end.Tick += HideLibetClock;

                    uiTimer0_1.Start();
                    uiTimer_end.Start();
                main.Cursor = System.Windows.Input.Cursors.None;
                
            }

            }

        private void clickButton_bl_c_Click(object sender, RoutedEventArgs e)
        {
           
            var main = App.Current.MainWindow as MainWindow;

             
                    main.pre_cue_click[main.taskNum, 1] = System.DateTime.Now;

                    clickButton_bl_c.IsEnabled = false;
                    clickButton_bl_c.Visibility = System.Windows.Visibility.Hidden;

                   
                    uiTimer_end.Interval = 2000;
                    uiTimer_end.Tick += HideLibetClock;
                    uiTimer_end.Start();
            main.Cursor = System.Windows.Input.Cursors.None;

            main.pre_cue_interval[main.taskNum, 1] = main.pre_cue_click[main.taskNum, 1] - main.pre_cue_click[main.taskNum, 0];
                    main.pre_cue_interval_ms[main.taskNum, 1] = Convert.ToInt32(main.pre_cue_interval[main.taskNum, 1].TotalMilliseconds);
             
        }

        private void resetButton_bl_c_Click(object sender, RoutedEventArgs e)
        {
            if (goButtonFlag == 1)
            {
                goButtonFlag = 0;
                goButton_bl_c.IsEnabled = true;
                //clickButton_t3.IsEnabled = false;

                //   resetButton_t3.IsEnabled = stopButton_t3.IsEnabled = false; //resumeButton.IsEnabled
            }
        }

        private void resetButton_bl_b_Click(object sender, RoutedEventArgs e)
        {
            if (goButtonFlag == 1)
            {
                goButtonFlag = 0;
                goButton_bl_b.IsEnabled = true;
                //clickButton_t3.IsEnabled = false;

                //   resetButton_t3.IsEnabled = stopButton_t3.IsEnabled = false; //resumeButton.IsEnabled
            }
        }
    }

}
