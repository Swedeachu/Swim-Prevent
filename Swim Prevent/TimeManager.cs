using System;
using System.Diagnostics;

namespace Swim_Prevent {
    class TimeManager {

        private static System.Timers.Timer leftClickTimer;
        private static System.Timers.Timer rightClickTimer;
        private static System.Timers.Timer uncappedLeftClickTimer;
        private static System.Timers.Timer uncappedRightClickTimer;
        private static System.Timers.Timer cpsInfoBoxRenderTimer;
        private static System.Timers.Timer clockTimer;
        public static string clock = "00:00:00"; // place holder before updating

        public static void startTimers() {
            leftClickTimer = new System.Timers.Timer(SwimLoader.clockSpeed);
            leftClickTimer.AutoReset = true;
            leftClickTimer.Elapsed += new System.Timers.ElapsedEventHandler(CPS.leftCpsManager);
            leftClickTimer.Start();

            rightClickTimer = new System.Timers.Timer(SwimLoader.clockSpeed);
            rightClickTimer.AutoReset = true;
            rightClickTimer.Elapsed += new System.Timers.ElapsedEventHandler(CPS.rightCpsManager);
            rightClickTimer.Start();

            uncappedLeftClickTimer = new System.Timers.Timer(SwimLoader.clockSpeed);
            uncappedLeftClickTimer.AutoReset = true;
            uncappedLeftClickTimer.Elapsed += new System.Timers.ElapsedEventHandler(CPS.uncappedLeftCpsManager);
            uncappedLeftClickTimer.Start();

            uncappedRightClickTimer = new System.Timers.Timer(SwimLoader.clockSpeed);
            uncappedRightClickTimer.AutoReset = true;
            uncappedRightClickTimer.Elapsed += new System.Timers.ElapsedEventHandler(CPS.uncappedRightCpsManager);
            uncappedRightClickTimer.Start();

            cpsInfoBoxRenderTimer = new System.Timers.Timer(10); // very fast refresh speed so cps is displayed accurately
            cpsInfoBoxRenderTimer.AutoReset = true;
            cpsInfoBoxRenderTimer.Elapsed += new System.Timers.ElapsedEventHandler(App.render);
            cpsInfoBoxRenderTimer.Start();

            clockTimer = new System.Timers.Timer(1000); // every second
            clockTimer.AutoReset = true;
            clockTimer.Elapsed += new System.Timers.ElapsedEventHandler(clockTick);
            clockTimer.Start();
        }

        public static void stopTimers() {
            leftClickTimer.Stop();
            rightClickTimer.Stop();
            uncappedLeftClickTimer.Stop();
            uncappedRightClickTimer.Stop();
            cpsInfoBoxRenderTimer.Stop();
            clockTimer.Stop();
        }

        private static int seconds = 0;
        private static int minutes = 0;
        private static int hours = 0;

        // clock tick is each second
        private static void clockTick(Object foo, System.Timers.ElapsedEventArgs bar) {
            if (App.closed) return;
            seconds++; 
            string formattedHours = hours.ToString();
            string formattedMinutes = minutes.ToString();
            string formattedSeconds = seconds.ToString();

            if (seconds == 60) { // check if we hit a minute
                seconds = 0;
                formattedSeconds = "00";
                minutes++;
            }

            if (minutes == 60) { // check if we hit an hour
                minutes = 0;
                formattedMinutes = "00";
                hours++;
            }

            if (seconds < 10) { // format for the seconds if single digit
                formattedSeconds = "0" + seconds.ToString();
            }

            if (minutes < 10) { // formate for the minutes if single digit
                formattedMinutes = "0" + minutes.ToString();
            }

            if (hours < 10) { // formate for the hours if single digit
                formattedHours = "0" + hours.ToString();
            }

            clock = formattedHours + ":" + formattedMinutes + ":" + formattedSeconds;
        }
    }
}
