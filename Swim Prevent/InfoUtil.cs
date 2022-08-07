using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.IO;
using System.Security.Cryptography;
using System.Globalization;
using System.Management;
using System.Linq;
using System.Text;

namespace Swim_Prevent {
    class InfoUtil {
        public static string getCurrentDateAndTime() {
            DateTime localDate = DateTime.Now;
            var cultureName = "en-US";
            var culture = new CultureInfo(cultureName);
            var date = localDate.ToString(culture);
            TimeZone localZone = TimeZone.CurrentTimeZone;
            return date + " " + localZone.StandardName;
        }

        public static string getRecycleBin() {
            string bin = "C:\\$Recycle.Bin";
            DateTime dt = File.GetLastAccessTime(bin);
            return dt.ToString();
        }

        public static int getSelfPID() {
            return Process.GetCurrentProcess().Id;
        }

        public static string getSelfFilePath() {
            return Assembly.GetExecutingAssembly().Location;
        }

        public static string getCheckSum(string path) {
            try {
                if (!string.IsNullOrEmpty(path)) {
                    using (var md5 = MD5.Create()) {
                        using (var stream = File.OpenRead(path)) {
                            var hash = md5.ComputeHash(stream);
                            return BitConverter.ToString(hash).Replace("-", "").ToLowerInvariant();
                        }
                    }
                }
            } catch (Exception ex) {
                Debug.WriteLine(ex.ToString());
            }
            return "";
        }

        public static string scanForUsbDrives() {
            string drives = "";
            foreach (DriveInfo drive in DriveInfo.GetDrives()) {
                if (drive.DriveType == DriveType.Removable) {
                    Debug.WriteLine(string.Format("({0}) {1}", drive.Name.Replace("\\", ""), drive.VolumeLabel));
                    drives += '\n' + string.Format("({0}) {1}", drive.Name.Replace("\\", ""), drive.VolumeLabel) + " External USB Drive Detected!";
                }
            }
            if (drives.Equals("")) {
                drives = "No External USB Drives Detected";
            }
            return drives;
        }

        public static long getTimeNow() {
            return DateTimeOffset.Now.ToUnixTimeMilliseconds();
        }

        public static string readUSB() {
            var usbDevices = GetUSBDevices();
            var usbs = "";
            foreach (var usbDevice in usbDevices) {
                var id = usbDevice.DeviceID;
                var pnpDID = usbDevice.PnpDeviceID;
                var description = usbDevice.Description;
                string deviceInfo = "\n" + id + " | " + pnpDID + " | " + description;
                usbs += deviceInfo;
            }
            if (usbs.Equals("")) {
                usbs = "\nMachine has no input devices, or Swim Prevent failed to read them";
            }
            return usbs;
        }

        public static int getInputDeviceCount() {
            return GetUSBDevices().Count;
        }

        static List<USBDeviceInfo> GetUSBDevices() {
            List<USBDeviceInfo> devices = new List<USBDeviceInfo>();

            ManagementObjectCollection collection;
            using (var searcher = new ManagementObjectSearcher(@"SELECT * FROM Win32_PnPEntity where Description Like ""USB Input Device%"""))
                collection = searcher.Get();

            foreach (var device in collection) {
                devices.Add(new USBDeviceInfo(
                (string)device.GetPropertyValue("DeviceID"),
                (string)device.GetPropertyValue("PNPDeviceID"),
                (string)device.GetPropertyValue("Description")
                ));
            }

            collection.Dispose();
            return devices;
        }

    }

}
class USBDeviceInfo {
    public USBDeviceInfo(string deviceID, string pnpDeviceID, string description) {
        DeviceID = deviceID;
        PnpDeviceID = pnpDeviceID;
        Description = description;
    }
    public string DeviceID { get; private set; }
    public string PnpDeviceID { get; private set; }
    public string Description { get; private set; }
}
