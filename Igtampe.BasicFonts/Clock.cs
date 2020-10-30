using System;
using System.Threading;
using Igtampe.BasicRender;

namespace Igtampe.BasicFonts {

    /// <summary>Handles the rendering of a BasicFont Clock</summary>
    public class Clock {

        //-[Fields and properties]------------------------------------------------------------------------------------------

        /// <summary>Font the clock uses</summary>
        public BasicFont ClockFont { get; private set; }

        /// <summary>Rendered string for the clock</summary>
        private string RenderedTime = "";

        /// <summary>Rendered string for the date</summary>
        private string RenderedDate = "";

        /// <summary>Leftmost corner of the clock</summary>
        private readonly int LeftPos;

        /// <summary>Topmost corner of the clock</summary>
        private readonly int TopPos;

        /// <summary>Adjustment to the hour (for timezones)</summary>
        public int HourAdjust { get; set; } = 0;

        /// <summary>Enable or disable military time</summary>
        public bool MilitaryTime { get; set; } = false;

        /// <summary>Enable or disable Seconds</summary>
        public bool ShowSeconds { get; set; } = false;

        /// <summary>Enable or disable showing the date on a line below it.</summary>
        public bool ShowDate { get; set; } = false;

        /// <summary>Background of this Clock</summary>
        public ConsoleColor BG { get; set; } = Console.BackgroundColor;

        /// <summary>Foreground of this clock</summary>
        public ConsoleColor FG { get; set; } = Console.ForegroundColor;

        //01:01:01 PM (At a maximum 11 characters long

        /// <summary>Width of this clock</summary>
        public int Width {
            get {
                return (RenderedTime.Length*ClockFont.Width)+(RenderedTime.Length-1); //width of each individual character and its spacing (minus the last one)
            }
        }

        /// <summary>Height of this clock</summary>
        public int Height {
            get {
                //The absolute baseheight is font height
                int BaseHeight = ClockFont.Height; //one character height
                if(!string.IsNullOrWhiteSpace(RenderedDate)) { BaseHeight += 2; } //Add 2 rows. for padding and the date
                return BaseHeight;
            }
        }

        private Thread AsyncThread;

        //-[Holders]------------------------------------------------------------------------------------------

        private ConsoleColor OldBG; //Holders for when we do the esta cosa.
        private ConsoleColor OldFG;
        private int OldLeft;
        private int OldTop;

        //-[Constructors]------------------------------------------------------------------------------------------

        /// <summary>Constructs a clock using the default DigitalClock.bfnt</summary>
        /// <param name="LeftPos"></param>
        /// <param name="TopPos"></param>
        public Clock(int LeftPos, int TopPos):this(BasicFont.LoadFromResource(Properties.Resources.DigitalClock),LeftPos,TopPos) { }
        
        /// <summary>Constructs a clock</summary>
        /// <param name="ClockFont">A font that must contain numbers from 0-9 and the letters 'A', 'P', and 'M'</param>
        /// <param name="LeftPos"></param>
        /// <param name="TopPos"></param>
        public Clock(BasicFont ClockFont, int LeftPos, int TopPos) {
            this.ClockFont = ClockFont;
            this.LeftPos = LeftPos;
            this.TopPos = TopPos;
        }

        //-[Text Preparers]------------------------------------------------------------------------------------------

        /// <summary>Returns the current date in DDDD MM/DD/YYYY</summary>
        /// <returns></returns>
        public string PrepareRenderedDate() {
            if(ShowDate) { return DateTime.Now.AddHours(HourAdjust).ToString("dddd MM/dd/yyyy"); }
            return "";
        }
        public string PrepareRenderedTime() {
            DateTime CurrentTime = DateTime.Now.AddHours(HourAdjust);
            string DisplayTime;
            if(MilitaryTime) {
                if(ShowSeconds) { DisplayTime = CurrentTime.ToString("HH:mm:ss"); } else { DisplayTime = CurrentTime.ToString("HH:mm"); }
            } else {
                if(ShowSeconds) { DisplayTime = CurrentTime.ToString("hh:mm:ss tt").ToLower(); } else { DisplayTime = CurrentTime.ToString("hh:mm tt").ToLower(); }
            }

            if(DisplayTime.StartsWith("0")) { DisplayTime = " " + DisplayTime.Substring(1); } //replace the first leading 0 of an hour with a space.
            return DisplayTime;
        }


        //-[Public Functions]------------------------------------------------------------------------------------------

        /// <summary>Initializes renderedtime to make calculations on clock width before rendering</summary>
        public void Init() {
            RenderedTime = PrepareRenderedTime();
            RenderedDate = PrepareRenderedDate();
        }

        /// <summary>Render the clock (for the first time)</summary>
        public void Render() {
            Init();
            SetColor();
            ClearClock();
            ClockFont.DrawText(RenderedTime,LeftPos,TopPos);
            RenderDate();
            ResetColor();
        }

        /// <summary>Re-render the clock </summary>
        public void Rerender() {
            //First lets verify if the new DisplayTime is equal to the already rendered time
            string DisplayTime = PrepareRenderedTime();
            string DisplayDate = PrepareRenderedDate();
            if(RenderedTime.Length != DisplayTime.Length || RenderedDate.Length!=DisplayDate.Length){ 
                SetColor(); 
                ClearClock();
                ResetColor();
                Render(); 
                return; 
            } 
            
            //If they're different length, a setting has changed. Redraw the whole thing.
            if(RenderedTime == DisplayTime && RenderedDate == DisplayDate) { return; } //no changes need to be made

            SetColor();
            if(RenderedTime != DisplayTime) {
                //Time to hunt for the differences
                for(int i = 0; i < RenderedTime.Length; i++) {
                    if(RenderedTime[i] != DisplayTime[i]) {ClockFont.DrawText("" + DisplayTime[i],LeftPos+CalculateLeftposAdjustment(i),TopPos);} //render only the changed text
                }
                RenderedTime = DisplayTime; //Save the new rendered time.

            }

            if(RenderedDate != DisplayDate) {
                ClearDate();
                RenderedDate = DisplayTime;
                RenderDate();
            }

            ResetColor();

        }

        //-[Private Functions]------------------------------------------------------------------------------------------

        /// <summary>Renders only the date</summary>
        private void RenderDate() {if(!string.IsNullOrWhiteSpace(RenderedDate)) { Draw.Sprite(RenderedDate,Console.BackgroundColor,Console.ForegroundColor,LeftPos+ClockFont.Width+1,TopPos + ClockFont.Height); }}

        /// <summary>Sets colors for the clock to render, saving old color, and old cursor position.</summary>
        private void SetColor() {
            OldLeft = Console.CursorLeft;
            OldTop = Console.CursorTop;
            OldBG = Console.BackgroundColor;
            OldFG = Console.ForegroundColor;
            RenderUtils.Color(BG,FG);
        }

        /// <summary>Resets colors and cursor position to what they were before</summary>
        private void ResetColor() {
            RenderUtils.Color(OldBG,OldFG);
            RenderUtils.SetPos(OldLeft,OldTop);
        }

        /// <summary>Clears this clock based on the last rendered time.</summary>
        private void ClearClock() {Draw.Box(BG,Width,Height,LeftPos,TopPos);}

        /// <summary>Clears this clock's date based on the last rendered date.</summary>
        private void ClearDate() { Draw.Row(BG,RenderedDate.Length,LeftPos,TopPos + ClockFont.Height + 2); }

        /// <summary>Calculates the necessary leftpos offset to render a character at the specified characterindex with the set clockfont</summary>
        /// <param name="CharacterIndex"></param>
        private int CalculateLeftposAdjustment(int CharacterIndex) {return ((CharacterIndex) * ClockFont.Width)+CharacterIndex;}

        //-[Execution]------------------------------------------------------------------------------------------

#pragma warning disable CS0618 // Type or member is obsolete
        /// <summary>Stops the clock if its running asynchronously</summary>
        public void Stop() {
            try { AsyncThread?.Resume(); } catch { } //Try to resume the thread if it is suspended
            AsyncThread?.Abort();
        }

        /// <summary>Pauses updating the clock</summary>
        public void Pause() { try { AsyncThread?.Suspend(); } catch { }} //I know these are obsolete but mira, the whole reason they are is because of resource protection.

        /// <summary>Resumes updating the clock</summary>
        public void Resume() { try { AsyncThread?.Resume(); } catch { } } //for us we *literally have to pause the clock so this is necessary.
#pragma warning restore CS0618 // Type or member is obsolete

        /// <summary>Runs the clock SYNCHRONOUSLY</summary>
        private void Run() {
            Render();
            while(true) {
                Thread.Sleep(100);
                Rerender();
            }
        }

        /// <summary>Runs the clock asynchronously</summary>
        public void RunAsync() {
            AsyncThread = new Thread(Run);
            AsyncThread.Start();
        }

    }
}
