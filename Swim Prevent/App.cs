using System;
using System.Diagnostics;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Swim_Prevent {
    public partial class App : Form {
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern bool HideCaret(IntPtr hWnd);
        public static bool closed = false;

        public App() {
            InitializeComponent();
            ClickListener.Subscribe();
            TimeManager.startTimers();
            FileManager.createLogs();
            Task.Run(() => Detections.runChecks());
            // some info
            string selfPath = InfoUtil.getSelfFilePath();
            string checksum = InfoUtil.getCheckSum(selfPath);
            int pid = InfoUtil.getSelfPID();
            string currentDateAndTime = InfoUtil.getCurrentDateAndTime();
            string usbDriveCheck = InfoUtil.scanForUsbDrives();
            int inputDeviceCount = InfoUtil.getInputDeviceCount();
            string recycleBinTime = InfoUtil.getRecycleBin();
            // write it to app UI
            timeInfoBox.AppendText(Environment.NewLine);
            timeInfoBox.AppendText("   Swim Prevent Opened At " + currentDateAndTime);
            systemInfoBox.AppendText("   Swim Prevent File Path: " + Environment.NewLine + "   " + selfPath);
            systemInfoBox.AppendText(Environment.NewLine);
            systemInfoBox.AppendText(Environment.NewLine);
            systemInfoBox.AppendText("   Swim Prevent MD5 CheckSum: " + Environment.NewLine + "   " + checksum);
            systemInfoBox.AppendText(Environment.NewLine);
            systemInfoBox.AppendText(Environment.NewLine);
            systemInfoBox.AppendText("   Swim Prevent PID: " + Environment.NewLine + "   " + pid);
            systemInfoBox.AppendText(Environment.NewLine);
            systemInfoBox.AppendText(Environment.NewLine);
            systemInfoBox.AppendText("   Recycle Bin Last Cleared: " + Environment.NewLine + "   " + recycleBinTime);
            // write it to the log file too
            FileManager.appendLogs("   Swim Prevent Opened At " + currentDateAndTime + Environment.NewLine);
            FileManager.appendLogs("   Swim Prevent File Path: " + selfPath + Environment.NewLine);
            FileManager.appendLogs("   Swim Prevent MD5 CheckSum: " + checksum + Environment.NewLine);
            FileManager.appendLogs("   Swim Prevent PID: " + pid + Environment.NewLine);
            FileManager.appendLogs("   Recycle Bin Last Cleared: " + recycleBinTime + Environment.NewLine);
            FileManager.appendLogs("   USB Drive Status: " + usbDriveCheck + Environment.NewLine);
            FileManager.appendLogs("   USB Device Count: " + inputDeviceCount + Environment.NewLine);
        }

        public static void render(Object foo, System.Timers.ElapsedEventArgs bar) {
            if (closed) return;
            if (leftCPS.IsHandleCreated == false) return;
            if (rightCPS.IsHandleCreated == false) return;
            if (clockLabel.IsHandleCreated == false) return;
            if (leftWithDC.IsHandleCreated == false) return;
            if (rightWithDC.IsHandleCreated == false) return;
            if (leftRecordText.IsHandleCreated == false) return;
            if (rightRecord.IsHandleCreated == false) return;
            if (leftDcCount.IsHandleCreated == false) return;
            if (rightDcCount.IsHandleCreated == false) return;
            if (leftAverage.IsHandleCreated == false) return;
            if (rightAverage.IsHandleCreated == false) return;
            if (leftTotalText.IsHandleCreated == false) return;
            if (rightTotal.IsHandleCreated == false) return;
            if (leftDcCount.IsHandleCreated == false) return;
            if (rightDcCount.IsHandleCreated == false) return;
            if (ratioLeftText.IsHandleCreated == false) return;
            if (rightAverage.IsHandleCreated == false) return;

            leftCPS.Invoke((MethodInvoker)delegate {
                leftCPS.Text = ClickListener.leftClicks.Count.ToString();
            });

            rightCPS.Invoke((MethodInvoker)delegate {
                rightCPS.Text = ClickListener.rightClicks.Count.ToString();
            });

            leftWithDC.Invoke((MethodInvoker)delegate {
                leftWithDC.Text = ClickListener.unfilteredLeftClicks.Count.ToString();
            });

            rightWithDC.Invoke((MethodInvoker)delegate {
                rightWithDC.Text = ClickListener.unfilteredRightClicks.Count.ToString();
            });

            leftRecordText.Invoke((MethodInvoker)delegate {
                leftRecordText.Text = ClickListener.topLeftCPS.ToString();
            });

            rightRecord.Invoke((MethodInvoker)delegate {
                rightRecord.Text = ClickListener.topRightCPS.ToString();
            });

            leftTotalText.Invoke((MethodInvoker)delegate {
                leftTotalText.Text = ClickListener.totalLeftClicks.ToString();
            });

            rightTotal.Invoke((MethodInvoker)delegate {
                rightTotal.Text = ClickListener.totalRightClicks.ToString();
            });

            leftDcCount.Invoke((MethodInvoker)delegate {
                leftDcCount.Text = ClickListener.totalFilteredLeftClicks.ToString();
            });

            rightDcCount.Invoke((MethodInvoker)delegate {
                rightDcCount.Text = ClickListener.totalFilteredRightClicks.ToString();
            });

            ratioLeftText.Invoke((MethodInvoker)delegate {
                ratioLeftText.Text = ClickListener.ratioLeft.ToString();
            });

            rightAverage.Invoke((MethodInvoker)delegate {
                rightAverage.Text = ClickListener.ratioRight.ToString();
            });

            clockLabel.Invoke((MethodInvoker)delegate {
                clockLabel.Text = TimeManager.clock;
            });
        }

        public static void updateLogBox(string msg) {
            logBox.Invoke((MethodInvoker)delegate {
                logBox.BackColor = Color.Black;
                logBox.ForeColor = Color.White;
                logBox.AppendText(msg);
                logBox.AppendText(Environment.NewLine);
            });
            FileManager.appendLogs(msg);
        }

        private void hideCaret(object sender, EventArgs e) {
            HideCaret(logBox.Handle);
            HideCaret(clickInfoBox.Handle);
            HideCaret(timeInfoBox.Handle);
            HideCaret(systemInfoBox.Handle);
        }

        public static async Task closeAsync() {
            closed = true;
            TimeManager.stopTimers();
            ClickListener.Unsubscribe();
            // info dump that can be written to a log file after closing
            string selfPath = InfoUtil.getSelfFilePath();
            string checksum = InfoUtil.getCheckSum(selfPath);
            int pid = InfoUtil.getSelfPID();
            string currentDateAndTime = InfoUtil.getCurrentDateAndTime();
            string usbDriveCheck = InfoUtil.scanForUsbDrives();
            int inputDeviceCount = InfoUtil.getInputDeviceCount();
            string parsedUSB = InfoUtil.readUSB();
            string recycleBinTime = InfoUtil.getRecycleBin();
            // write to log file
            FileManager.appendLogs(Environment.NewLine);
            FileManager.appendLogs("   Swim Prevent Closed At " + currentDateAndTime + Environment.NewLine);
            FileManager.appendLogs("   Swim Prevent File Path: " + selfPath + Environment.NewLine);
            FileManager.appendLogs("   Swim Prevent MD5 CheckSum: " + checksum + Environment.NewLine);
            FileManager.appendLogs("   Swim Prevent PID: " + pid + Environment.NewLine);
            FileManager.appendLogs("   Recycle Bin Last Cleared: " + recycleBinTime + Environment.NewLine);
            FileManager.appendLogs("   USB Drive Status: " + usbDriveCheck + Environment.NewLine);
            FileManager.appendLogs("   USB Device Count: " + inputDeviceCount + Environment.NewLine);
            await Task.Run(() => Detections.runChecks());
            // Debug.WriteLine("List of USB Input Devices: " + parsedUSB); // this is usually a lot of spam and not worth looking at half the time
        }
    }
}
