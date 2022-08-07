using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Management;
using System.Runtime.InteropServices;

namespace Swim_Prevent {

    // all of these detections are ring 3 and are super simple, congrats if you bypassed, it is not hard
    // dc prevent with mouse stats is what matters more for this program

    class Detections {

        // every 250 clicks checks are run (and on the start of the program)
        public static void runChecks() {
            readModules(); // get dlls for minecraft exe to detect the internal cheats, semi reliable
            scanProcesses(); // does like 3 checks as I scan process hashes and shit, sorta mid if I am being honest with my self
            autoClickerCheck(); // could also keep track of how long mouse button is held between each click but meh
            virtualMachineCheck(); // sort of useless
        }

        // I am lazy as fuck and only bother to check for left auto clickers, right click autoing is visually blatant anyways
        private static void autoClickerCheck() {
            int[] clicks = (int[])ClickListener.tempClickHistory.ToArray(typeof(int));
            ClickListener.tempClickHistory.Clear();
            Dictionary<int, int> clickTally = new Dictionary<int, int>();
            double total = 0;
            int count = 0;
            int trueCount = -1; // for keeping track of clicks array index
            // sorting and getting average of clicks
            foreach (int click in clicks) {
                trueCount++;
                if (click > 200) {
                    clicks = clicks.Where((source, index) => index != trueCount).ToArray();
                    continue; // to avoid useless outliers when the user just started clicking or is normal clicking
                }
                if (clickTally.ContainsKey(click)) {
                    clickTally[click]++;
                } else {
                    clickTally[click] = 1;
                }
                total += click;
                count++;
            }
            double avg = total / count;
            // now for variance of clicks
            // the reason I loop again is because now I have the average value I needed beforehand
            double sqrSums = 0;
            foreach (int click in clicks) {
                if (click > 200) {
                    continue; // again just in case to avoid outliers
                }
                sqrSums += Math.Pow((click - avg), 2.0);
            }
            // the important values:
            int uniqueness = clickTally.Count;
            double variance = sqrSums / (count - 1);
            double deviation = Math.Sqrt(variance);
            double skewness = MathUtil.getSkewness(clicks);
            // double kurtosis = MathUtil.getKurtosis(clicks); // honestly a near useless value
            Debug.WriteLine("Variance: " + variance + " | Average: " + avg + " | Deviation: " + deviation + " | Skewness: " + skewness);
            // all these checks are kind of bad and might false flag or be bypassed
            // checks with our values and sorted click tally array
            foreach (var kvp in clickTally) {
                Debug.WriteLine("Wait Time = {0}ms, Occurances = {1}", kvp.Key, kvp.Value);
                if (kvp.Value >= 100) {
                    App.updateLogBox("Auto Clicking Suspected [A]"); // if to many occurances of the same wait time between each click
                }
            }
            if (deviation < 10 && deviation > 1) {
                App.updateLogBox("Auto Clicking Suspected [B]"); // if clicks pattern is to similar
            }
            if (skewness > 20) {
                App.updateLogBox("Auto Clicking Suspected [C]"); // if click pattern 'feels' artificially randomized 
            }
            if (uniqueness < 10) {
                App.updateLogBox("Auto Clicking Suspected [D]"); // if not very many different click wait times, also sorta doubles as an exhaustion check
            }
        }

        private static void readModules() {
            Process[] mcproc = Process.GetProcessesByName("Minecraft.Windows");
            foreach (Process proc in mcproc) {
                int dllCount = 0;
                foreach (ProcessModule module in proc.Modules) {
                    dllCount++;
                    string md5 = InfoUtil.getCheckSum(module.FileName);
                    if (!CheatTable.checkMD5(md5).Equals("clean") || !checkProcessName(module.FileName)) {
                        App.updateLogBox("Illegal Process Detected: " + module.FileName + " | " + CheatTable.checkMD5(md5));
                    }
                    Debug.WriteLine(dllCount + " : " + module.ModuleName + " -> " + module.FileName);
                }
                /*
                if (dllCount > 173) { // very very very unreliable false flaggy and shitty way to detect injection
                    App.updateLogBox("Suspicous DLL Count: " + dllCount + ", this log however does not always mean cheats");
                }
                */
            }
        }

        // this could possibly create false flags, very easy to bypass, but does not hurt to have it
        // basically a good back up for hash value checks and can confirm blatant cheats
        public static bool checkProcessName(string name) {
            foreach (string str in CheatTable.illegalStrings) {
                if (name.ToLower().Contains(str.ToLower()) || name.ToLower().Equals(str.ToLower())) {
                    return false;
                }
            }
            return true;
        }

        private static void scanProcesses() {
            var wmiQueryString = "SELECT ProcessId, ExecutablePath, CommandLine FROM Win32_Process";
            using (var searcher = new ManagementObjectSearcher(wmiQueryString))
            using (var results = searcher.Get()) {
                var query = from p in Process.GetProcesses()
                            join mo in results.Cast<ManagementObject>()
                            on p.Id equals (int)(uint)mo["ProcessId"]
                            select new {
                                Process = p,
                                Name = p.ProcessName,
                                Pid = p.Id,
                                Path = (string)mo["ExecutablePath"],
                                CommandLine = (string)mo["CommandLine"],
                            };
                // the checks to be done on every running process
                string selfPath = InfoUtil.getSelfFilePath();
                foreach (var item in query) {
                    string path = item.Path;
                    if (path == null) {
                        continue;
                    }
                    if (path.Equals(selfPath)) {
                        continue; // don't want to scan ourselves lmao
                    }
                    string md5 = InfoUtil.getCheckSum(path);
                    string checksum = CheatTable.checkMD5(md5);
                    //string readStrings = readProcessStrings(path);
                    string name = item.Name;
                    // now do checks
                    if (!checksum.Equals("clean")) {
                        App.updateLogBox("Illegal Process Detected: " + path + " | " + checksum + " | Named as: " + name);
                    }
                    if (!checkProcessName(name)) {
                        App.updateLogBox("Possibly Illegal Process Detected: " + path + " | " + checksum + " | Proc Name: " + name);
                    }
                    /*
                    if (!readStrings.Equals("clean")) {
                        App.updateLogBox("Possibly Illegal Process Detected: " + path + " | " + checksum + " | Proc Name: " + name + " | Illegal String Found: " + readStrings);
                    } */
                }
            }
        }

        private static void virtualMachineCheck() {
            if (new ManagementObjectSearcher("SELECT * FROM Win32_PortConnector").Get().Count == 0) {
                App.updateLogBox("Virtual Machine Detected");
            }
        }

        // performance wise this last one just is not possible
        /*
        public static string readProcessStrings(string filePath) {
            string line;
            if (filePath != null) {
                try {
                    using (StreamReader sr = new StreamReader(filePath)) {
                        line = sr.ReadLine();
                        // Debug.WriteLine(line + " | " + filePath);
                        while (line != null) {
                            for (int i = 0; i < CheatTable.illegalStrings.Length; i++) {
                                string ill = CheatTable.illegalStrings[i].ToLower();
                                if (line.Contains(ill)) {
                                    return ill;
                                }
                            }
                            line = sr.ReadLine();
                        }
                    }
                } catch (Exception ex) {
                    Console.WriteLine(ex.ToString());
                }
            }
            return "clean";
        } */

    }

}
