using Gma.System.MouseKeyHook;
using System;
using System.Collections;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Swim_Prevent {
    class ClickListener {

        // variables to care about
        private static int lastLeftClickedTimeStamp = 0; // to keep track of when we last left clicked
        private static int lastRightClickedTimeStamp = 0; // to keep track of when we last right clicked
        public static ArrayList leftClicks = new ArrayList(); // the size of this array = cps
        public static ArrayList rightClicks = new ArrayList(); // the size of this array = cps
        public static ArrayList unfilteredLeftClicks = new ArrayList(); // the size of this array = left cps unfiltered clicks
        public static ArrayList unfilteredRightClicks = new ArrayList(); // the size of this array = right cps unfiltered clicks
        public static ArrayList tempClickHistory = new ArrayList(); // for auto clicker checks

        // fun statistics to keep track of
        public static int totalLeftClicks = 0;
        public static int totalRightClicks = 0;
        public static int topLeftCPS = 0;
        public static int topRightCPS = 0;
        public static int totalFilteredLeftClicks = 0;
        public static int totalFilteredRightClicks = 0;
        public static double ratioLeft = 0.0;
        public static double ratioRight = 0.0;

        // inject global mouse input hooks
        public static IKeyboardMouseEvents m_GlobalHook;
        public static void Subscribe() {
            m_GlobalHook = Hook.GlobalEvents();
            m_GlobalHook.MouseDownExt += onClick;
            m_GlobalHook.MouseDownExt += mouseStats;
            Debug.WriteLine("Subscribed Mouse Input Hooks");
        }

        public static void Unsubscribe() {
            m_GlobalHook.MouseDownExt -= onClick;
            m_GlobalHook.MouseDownExt -= mouseStats;
            m_GlobalHook.Dispose();
            Debug.WriteLine("Disposed Mouse Input Hooks");
        }

        // on left and right click
        private static async void mouseStats(object sender, MouseEventExtArgs e) {
            int leftCPS = leftClicks.Count;
            int rightCPS = rightClicks.Count;

            if (leftCPS > topLeftCPS) {
                topLeftCPS = leftCPS;
            }

            if (rightCPS > topRightCPS) {
                topRightCPS = rightCPS;
            }

            if (totalFilteredLeftClicks > 0) {
                ratioLeft = Math.Round(((double)totalFilteredLeftClicks / (double)totalLeftClicks) * 100, 2);
            } else {
                ratioLeft = 0;
            }

            if (totalFilteredRightClicks > 0) {
                ratioRight = Math.Round(((double)totalFilteredRightClicks / (double)totalRightClicks) * 100, 2);
            } else {
                ratioRight = 0;
            }

            if (totalLeftClicks % 250 == 0) {
                await Task.Run(() => Detections.runChecks());
            }
        }

        private static void onClick(object sender, MouseEventExtArgs e) {
            string msg = "";
            var button = e.Button;
            // e.Handled cancels it, as we are telling the OS that we already dealt with the click
            if (button.Equals(MouseButtons.Left)) {
                totalLeftClicks++;
                var timeDifference = Math.Abs(lastLeftClickedTimeStamp - e.Timestamp);
                lastLeftClickedTimeStamp = e.Timestamp;
                if (timeDifference != e.Timestamp && !(timeDifference >= 2000)) {
                    if ((timeDifference < SwimLoader.clockSpeed && leftClicks.Count >= 5) || leftClicks.Count >= 17) {
                        e.Handled = true;
                        totalFilteredLeftClicks++;
                        unfilteredLeftClicks.Add(DateTimeOffset.Now.ToUnixTimeMilliseconds());
                        msg = "Suppressed Left Double Click | " + timeDifference + "ms";
                    } else {
                        msg = "Left Click | " + timeDifference + "ms";
                    }
                    tempClickHistory.Add(timeDifference);
                } else {
                    msg = "Left Click | Started Clicking";
                }
                if (e.Handled == false) {
                    unfilteredLeftClicks.Add(DateTimeOffset.Now.ToUnixTimeMilliseconds());
                    leftClicks.Add(DateTimeOffset.Now.ToUnixTimeMilliseconds());
                }
            } else if (button.Equals(MouseButtons.Right)) {
                totalRightClicks++;
                var timeDifference = Math.Abs(lastRightClickedTimeStamp - e.Timestamp);
                lastRightClickedTimeStamp = e.Timestamp;
                if (timeDifference != e.Timestamp && !(timeDifference >= 2000)) {
                    if ((timeDifference < SwimLoader.clockSpeed && rightClicks.Count >= 5) || rightClicks.Count >= 17) {
                        e.Handled = true;
                        totalFilteredRightClicks++;
                        unfilteredRightClicks.Add(DateTimeOffset.Now.ToUnixTimeMilliseconds());
                        msg = "Suppressed Right Double Click | " + timeDifference + "ms";
                    } else {
                        msg = "Right Click | " + timeDifference + "ms";
                    }
                } else {
                    msg = "Right Click | Started Clicking";
                }
                if (e.Handled == false) {
                    unfilteredRightClicks.Add(DateTimeOffset.Now.ToUnixTimeMilliseconds());
                    rightClicks.Add(DateTimeOffset.Now.ToUnixTimeMilliseconds());
                }
            }
            // send message to logs after all this
            if (!msg.Equals("")) {
                App.updateLogBox("    " + msg);
            }
        }
    }
}
