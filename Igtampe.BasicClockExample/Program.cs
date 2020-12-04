using System;
using System.IO;
using System.Collections.Generic;
using System.Threading;
using Igtampe.BasicFonts;
using Igtampe.BasicRender;
using Igtampe.BasicGraphics;
using Igtampe.DictionaryOnDisk;
using System.Media;
using Igtampe.BasicClockExample.Properties;

namespace Igtampe.BasicClockExample {
    class Program {

        static Clock MainClock;
        static BasicFont ClockFont;

        static Boolean Voice = true;
        static Boolean Audio = true;
        static Boolean Collapsed = false;

        static string dir = AppDomain.CurrentDomain.BaseDirectory + "/ClockSettings.dod";
        static string FontDir = "";

        static Thread AudioVoiceThread;

        static void Main(string[] args) {
            ClockFont = BasicFont.DigitalClockFont;

            if(args.Length > 0) {
                if(args[0].ToUpper().EndsWith(".DOD")) {dir = args[0];}
                if(args[0].ToUpper().EndsWith(".BFNT")) { FontDir=args[0]; }
            }

            MainClock = LoadClock();
            MainClock.Init();

            if(Collapsed) { Collapse(); } else { Expand(); }

            MainClock.RunAsync();
            string[] ReadSplit;

            StartAudioVoiceBackend();

            do {
                RenderUtils.SetPos(1,10);
                String Read = Console.ReadLine();
                Draw.Row(ConsoleColor.Black,Read.Length,1,10);
                Draw.ClearLine(12);
                RenderUtils.SetPos(0,12);
                ReadSplit=Read.Split(' '); 
                Parse(ReadSplit);
                Save();
            } while(ReadSplit[0].ToUpper()!="CLOSE");

            MainClock.Stop();
            AudioVoiceThread.Abort();
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
                case "VOICE":
                    if(Read.Length == 2) { if(Boolean.TryParse(Read[1],out bool Flag)) { Voice = Flag; } } 
                    else { Draw.Sprite("Incorrect syntax: ShowSeconds (bool)",ConsoleColor.Black,ConsoleColor.Red); }
                    break;
                case "AUDIO":
                    if(Read.Length == 2) { if(Boolean.TryParse(Read[1],out bool Flag)) { Audio = Flag; } } 
                    else { Draw.Sprite("Incorrect syntax: ShowSeconds (bool)",ConsoleColor.Black,ConsoleColor.Red); }
                    break;
                case "COLLAPSE":
                    Collapse();
                    break;
                case "EXPAND":
                    Expand();
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
                    MainClock = LoadClock();
                    MainClock.RunAsync();
                    break;
                case "CLOSE":
                    break;
                default:
                    Draw.Sprite("Unable to parse command, see HELP",ConsoleColor.Black,ConsoleColor.Red);
                    break;
            }
        }

        /// <summary>Collapse the window to a smaller size</summary>
        static void Collapse(){
            Collapsed = true;
            MainClock.Pause();
            Console.SetWindowSize(Math.Max(Console.WindowWidth,(MainClock.Width + ClockFont.Width + 4)),13);
            Console.SetBufferSize(Math.Max(Console.WindowWidth,(MainClock.Width + ClockFont.Width + 4)),13);
            Console.Clear();
            MainClock.Render();
            Draw.Sprite(":",Console.BackgroundColor,Console.ForegroundColor,0,10);
            MainClock.Resume();
        }

        /// <summary>Expand the window and resize it to a larger size</summary>
        static void Expand() {
            Collapsed = false;
            MainClock.Pause();
            Console.SetBufferSize(Math.Max(Console.WindowWidth,(MainClock.Width + ClockFont.Width + 4)),34);
            Console.SetWindowSize(Math.Max(Console.WindowWidth,(MainClock.Width + ClockFont.Width + 4)),34);
            DrawHelp();
            MainClock.Resume();
        }

        /// <summary>Draws the help</summary>
        static void DrawHelp() {
            Draw.Sprite(":",Console.BackgroundColor,Console.ForegroundColor,0,10);
            RenderUtils.SetPos(0,14);
            RenderUtils.Echo("Welcome to the Digital Grandfather Clock!\n\n" +
                "" +
                "Here you can use the following commands to modify this clock:\n" +
                "SetBG (Color)     : Set the background of this clock (Needs a redraw to fully come into effect)\n" +
                "SetFG (Color)     : Set the foreground of this clock (Needs a redraw to fully come into effect)\n" +
                "MilitTime (bool)  : Set Military Time on or off (True or false)\n" +
                "ShowDate (bool)   : Set date showing on or off (True or false)\n" +
                "ShowSeconds (bool): Set second showing on or off (True or false)\n" +
                "AdjustHours (int) : Set the hour adjustment on this clock\n" +
                "Voice (bool)      : Turn voice on or off\n" +
                "Audio (bool)      : Turn the audio alarm on this clock on or off\n" +
                "Collapse          : Collapses the help menu\n" +
                "Expand            : Expands to show this help menu again.\n" +
                "Pause             : Pause the clock\n" +
                "Resume            : Resume the clock\n" +
                "Reset             : Resets the clock to its original state\n" +
                "Close             : Close this demo\n\n" +
                "" +
                "If the clock is showing seconds, it is not recommended you do anything until you pause it.");
        }

        public static Clock LoadClock() {

            if(!File.Exists(dir)) { return DefaultClock(); }

            Dictionary<String,String> LoadDict = DOD.Load(dir);

            try {
                Clock ReturnClock;

                if(string.IsNullOrWhiteSpace(FontDir)) { FontDir = LoadDict["FONT"]; }

                if(!string.IsNullOrWhiteSpace(FontDir)) { ReturnClock = new Clock(BasicFont.LoadFromFile(FontDir),2,1); } 
                else { ReturnClock = new Clock(2,1); }

                ReturnClock.BG = GraphicUtils.ColorCharToConsoleColor(LoadDict["BG"][0]);
                ReturnClock.FG = GraphicUtils.ColorCharToConsoleColor(LoadDict["FG"][0]);
                ReturnClock.MilitaryTime = Boolean.Parse(LoadDict["MILITTIME"]);
                ReturnClock.ShowDate = Boolean.Parse(LoadDict["SHOWDATE"]);
                ReturnClock.ShowSeconds = Boolean.Parse(LoadDict["SHOWSECONDS"]);
                ReturnClock.HourAdjust = int.Parse(LoadDict["ADJUSTHOURS"]);

                Audio = Boolean.Parse(LoadDict["AUDIO"]);
                Voice = Boolean.Parse(LoadDict["VOICE"]);
                Collapsed = Boolean.Parse(LoadDict["COLLAPSED"]);

                return ReturnClock;
                
            } catch(Exception) {
                Draw.CenterText("There was an error loading file " + dir.Split('\\')[dir.Split('\\').Length-1],Console.WindowHeight / 2,ConsoleColor.Red,ConsoleColor.Black);
                RenderUtils.Pause();
                Draw.ClearLine(Console.WindowHeight / 2);
                return DefaultClock();
            }


        }

        public static void Save() {
            Dictionary<string,string> SaveDict = new Dictionary<string,string> {
                { "FONT",FontDir },
                { "BG",BasicFont.ConsoleColorToColorChar(MainClock.BG) + "" },
                { "FG",BasicFont.ConsoleColorToColorChar(MainClock.FG) + "" },
                { "MILITTIME",MainClock.MilitaryTime.ToString() },
                { "SHOWDATE",MainClock.ShowDate.ToString() },
                { "SHOWSECONDS",MainClock.ShowSeconds.ToString() },
                { "ADJUSTHOURS",MainClock.HourAdjust.ToString() },
                { "AUDIO",Audio.ToString() },
                { "VOICE",Voice.ToString() },
                { "COLLAPSED",Collapsed.ToString() }
            };
            DOD.Save(SaveDict,dir);
        }

        public static Clock DefaultClock() {
            return new Clock(BasicFont.DigitalClockFont,2,1) {
                BG = ConsoleColor.Black,
                FG = ConsoleColor.White,
                MilitaryTime = false,
                ShowDate = false,
                ShowSeconds = true,
                HourAdjust = 0
            };
        }

        public static void AudioVoiceBackend() {
            DateTime CurrentTime;
            Actor TheActor = new Actor();
            int Index = 0;
            int[] Minutes = { 0,15,30,45 }; //Minutes to activate on IN ASCENDING ORDER.
            //check the minutes array, cycle to the top the next minute that is to be checked
            
            CurrentTime = DateTime.Now;
            if(!(CurrentTime.Minute >= Minutes[Minutes.Length - 1])) { //Make sure this doesn't get stuck. If its larger than the last index, the next index to check is the first.
                while(Minutes[Index] < CurrentTime.Minute) { Index++; }
            }

            //If Voice, say the time.
            if(Voice) { TheActor.SayAsync("The time is now " + CurrentTime.ToString("h:mm tt")); }


            //now lets go:
            while(true) {
                CurrentTime = DateTime.Now.AddHours(MainClock.HourAdjust);
                if(CurrentTime.Minute == Minutes[Index]) {

                    //its time to activate
                    //if Audio, play the sound
                    if(Audio) {
                        switch(CurrentTime.Minute) {
                            case 0:
                                new SoundPlayer(Resources.Down).PlaySync();
                                new SoundPlayer(Resources.Up).PlaySync();
                                new SoundPlayer(Resources.Down).PlaySync();
                                new SoundPlayer(Resources.Up).PlaySync();

                                //get the number of bongs by doing this:
                                int Bongs = int.Parse(CurrentTime.ToString("hh"));

                                //Play the bongs
                                for(int x = 0; x < Bongs; x++) {new SoundPlayer(Resources.Bong).PlaySync();}
                                break;
                            case 15:
                                new SoundPlayer(Resources.Down).PlaySync();
                                break;
                            case 30:
                                new SoundPlayer(Resources.Down).PlaySync();
                                new SoundPlayer(Resources.Up).PlaySync();
                                break;
                            case 45:
                                new SoundPlayer(Resources.Down).PlaySync();
                                new SoundPlayer(Resources.Up).PlaySync();
                                new SoundPlayer(Resources.Down).PlaySync();
                                break;
                            default:
                                break;
                        }
                    }

                    //If Voice, say the time.
                    if(Voice) { TheActor.SayAsync("The time is now " + CurrentTime.ToString("h:m tt")); }

                    //Move us forward
                    Index++;
                    if(Index >= Minutes.Length) { Index = 0; }

                }
                Thread.Sleep(1000);
            }

        }

        public static void StartAudioVoiceBackend() {
            if(AudioVoiceThread?.IsAlive == true) { throw new InvalidOperationException("Thread is running!"); }
            AudioVoiceThread = new Thread(AudioVoiceBackend);
            AudioVoiceThread.Start();
        }


    }


}
