using System;
using Igtampe.BasicFonts;
using Igtampe.BasicRender;
using Igtampe.BasicGraphics;

namespace Igtampe.BasicClockExample {
    class Program {

        static Clock MainClock;
        static BasicFont ClockFont;

        static void Main(string[] args) {
            ClockFont = BasicFont.DigitalClockFont;

            if(args.Length > 0) {
                if(args[0].ToUpper().EndsWith(".BFNT")) {
                    //try to load the basicfont
                    try {ClockFont = BasicFont.LoadFromFile(args[0]);} catch(Exception) {} //if we can't load it, that's ok
                }
            }

            MainClock = new Clock(ClockFont,2,1) {
                ShowDate = true,
                ShowSeconds = true
            };
            MainClock.Init();

            Console.SetBufferSize(Math.Max(Console.WindowWidth,(MainClock.Width + ClockFont.Width + 4)),30);
            Console.SetWindowSize(Math.Max(Console.WindowWidth,(MainClock.Width + ClockFont.Width + 4)),30);

            //Render help 
            Draw.Sprite(":",Console.BackgroundColor,Console.ForegroundColor,0,10);
            RenderUtils.SetPos(0,14);
            RenderUtils.Echo("Welcome to the BasicFont Clock Demo!\n\n" +
                "" +
                "Here you can use the following commands to modify this clock:\n" +
                "SetBG (Color)     : Set the background of this clock (Needs a redraw to fully come into effect)\n" +
                "SetFG (Color)     : Set the foreground of this clock (Needs a redraw to fully come into effect)\n" +
                "MilitTime (bool)  : Set Military Time on or off (True or false)\n" +
                "ShowDate (bool)   : Set date showing on or off (True or false)\n" +
                "ShowSeconds (bool): Set second showing on or off (True or false)\n" +
                "AdjustHours (int) : Set the hour adjustment on this clock\n" +
                "Pause             : Pause the clock\n" +
                "Resume            : Resume the clock\n" +
                "Reset             : Resets the clock to its original state\n" +
                "Close             : Close this demo\n\n" +
                "" +
                "If the clock is showing seconds, it is not recommended you do anything until you pause it.");
            
            MainClock.RunAsync();
            string[] ReadSplit;

            do {
                RenderUtils.SetPos(1,10);
                String Read = Console.ReadLine();
                Draw.Row(ConsoleColor.Black,Read.Length,1,10);
                Draw.ClearLine(12);
                RenderUtils.SetPos(0,12);
                ReadSplit=Read.Split(' '); 
                Parse(ReadSplit);
            } while(ReadSplit[0].ToUpper()!="CLOSE");

            MainClock.Stop();
        }


        /// <summary>Parser for the commands of the demo</summary>
        /// <param name="Read"></param>
        static void Parse(String[] Read) {
            switch(Read[0].ToUpper()) {
                case "SETBG":
                    if(Read.Length == 2) { MainClock.BG = GraphicUtils.ColorCharToConsoleColor(Read[1][0]); } 
                    else { Draw.Sprite("Incorrect syntax: SetBG (ColorChar)",ConsoleColor.Black,ConsoleColor.Red); }
                    break;
                case "SETFG":
                    if(Read.Length == 2) { MainClock.FG = GraphicUtils.ColorCharToConsoleColor(Read[1][0]); } 
                    else { Draw.Sprite("Incorrect syntax: SetFG (ColorChar)",ConsoleColor.Black,ConsoleColor.Red); }
                    break;
                case "MILITTIME":
                    if(Read.Length == 2) { if(Boolean.TryParse(Read[1],out bool Flag)) { MainClock.MilitaryTime = Flag; } }
                    else { Draw.Sprite("Incorrect syntax: MilitTime (bool)",ConsoleColor.Black,ConsoleColor.Red); }
                    break;
                case "SHOWDATE":
                    if(Read.Length == 2) { if(Boolean.TryParse(Read[1],out bool Flag)) { MainClock.ShowDate = Flag; } }
                    else { Draw.Sprite("Incorrect syntax: ShowDate (bool)",ConsoleColor.Black,ConsoleColor.Red); }
                    break;
                case "SHOWSECONDS":
                    if(Read.Length == 2) { if(Boolean.TryParse(Read[1],out bool Flag)) { MainClock.ShowSeconds = Flag; } } 
                    else { Draw.Sprite("Incorrect syntax: ShowSeconds (bool)",ConsoleColor.Black,ConsoleColor.Red); }
                    break;
                case "ADJUSTHOURS":
                    if(Read.Length == 2) { if(int.TryParse(Read[1],out int Flag)) { MainClock.HourAdjust = Flag; } } 
                    else { Draw.Sprite("Incorrect syntax: ShowSeconds (bool)",ConsoleColor.Black,ConsoleColor.Red); }
                    break;
                case "PAUSE":
                    MainClock.Pause();
                    break;
                case "RESUME":
                    MainClock.Resume();
                    break;
                case "RESET":
                    MainClock.Stop();
                    Draw.Box(ConsoleColor.Black,MainClock.Width,MainClock.Height,2,1);
                    MainClock = new Clock(ClockFont,2,1) {
                        MilitaryTime = true,
                        ShowDate = true,
                        ShowSeconds = true
                    };
                    MainClock.RunAsync();
                    break;
                case "CLOSE":
                    break;
                default:
                    Draw.Sprite("Unable to parse command, see HELP",ConsoleColor.Black,ConsoleColor.Red);
                    break;
            }
        }
    }
}
