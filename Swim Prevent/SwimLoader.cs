using System;
using System.Windows.Forms;
using System.Collections;

namespace Swim_Prevent {
    class SwimLoader {
        public static App SwimApp;

        // 50 milliseconds is the time it takes for one minecraft tick
        // You should never be able to click more than once in a minecraft tick, that is unfair and not humanely possible legit.
        // This program solves that issue by measuring the time difference of each click and filtering out anything under 50 ms.
        // This program also has some very basic Minecraft Bedrock client side anti cheat features, hopefully none to invasive.
        // Idea sourced from: https://github.com/Schellmr/dcPrevent/tree/master/dcPrevent/dcPrevent
        // All code written by Swimfan72 in like 3 days or something lol, property of Swim Services
        // discord.gg/swim

        public static readonly int clockSpeed = 50; // milliseconds, same speed as one minecraft in game tick

        [STAThread]
        public static void Main() {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            SwimApp = new App();
            Application.Run(SwimApp);
            // all code under here is executed once the application is closed
            _ = App.closeAsync();
        }

    }
}
