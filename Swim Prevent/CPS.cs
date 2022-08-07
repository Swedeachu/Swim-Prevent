using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Swim_Prevent {
    class CPS {
        // the way this works is if the click has been alive longer than 1000 milliseconds then remove it from the cps stack
        // did it in differenent managers to be async
        public static void leftCpsManager(Object foo, System.Timers.ElapsedEventArgs bar) {
            if (ClickListener.leftClicks.Count <= 0 || App.closed) return;
            var oldestLeftClickTime = Convert.ToInt64(ClickListener.leftClicks[0]);
            var leftClickDeltaTime = Math.Abs(oldestLeftClickTime - InfoUtil.getTimeNow());
            if (leftClickDeltaTime >= 1000 && ClickListener.leftClicks.Count > 0) {
                ClickListener.leftClicks.RemoveAt(0);
            }
        }

        public static void rightCpsManager(Object foo, System.Timers.ElapsedEventArgs bar) {
            if (ClickListener.rightClicks.Count <= 0 || App.closed) return;
            var oldestRightClickTime = Convert.ToInt64(ClickListener.rightClicks[0]);
            var rightClickDeltaTime = Math.Abs(oldestRightClickTime - InfoUtil.getTimeNow());
            if (rightClickDeltaTime >= 1000 && ClickListener.rightClicks.Count > 0) {
                ClickListener.rightClicks.RemoveAt(0);
            }
        }

        public static void uncappedLeftCpsManager(Object foo, System.Timers.ElapsedEventArgs bar) {
            if (ClickListener.unfilteredLeftClicks.Count <= 0 || App.closed) return;
            var oldestClickTime = Convert.ToInt64(ClickListener.unfilteredLeftClicks[0]);
            var deltaTime = Math.Abs(oldestClickTime - InfoUtil.getTimeNow());
            if (deltaTime >= 1000 && ClickListener.unfilteredLeftClicks.Count > 0) {
                ClickListener.unfilteredLeftClicks.RemoveAt(0);
            }
        }

        public static void uncappedRightCpsManager(Object foo, System.Timers.ElapsedEventArgs bar) {
            if (ClickListener.unfilteredRightClicks.Count <= 0 || App.closed) return;
            var oldestClickTime = Convert.ToInt64(ClickListener.unfilteredRightClicks[0]);
            var deltaTime = Math.Abs(oldestClickTime - InfoUtil.getTimeNow());
            if (deltaTime >= 1000 && ClickListener.unfilteredRightClicks.Count > 0) {
                ClickListener.unfilteredRightClicks.RemoveAt(0);
            }
        }
    }
}
