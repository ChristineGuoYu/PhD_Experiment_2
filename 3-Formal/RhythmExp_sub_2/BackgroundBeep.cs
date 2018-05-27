﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace RhythmExp_sub_2
{
    class BackgroundBeep
    {
        static Thread _beepThread;
        static AutoResetEvent _signalBeep;

        static BackgroundBeep()
        {
            _signalBeep = new AutoResetEvent(false);
            _beepThread = new Thread(() =>
            {
                for (;;)
                {
                    _signalBeep.WaitOne();
                    Console.Beep(3600, 50);
                }
            }, 1);
            _beepThread.IsBackground = true;
            _beepThread.Start();
        }

        public static void Beep()
        {
            _signalBeep.Set();
        }
    }
}
