using Igtampe.BasicWindows.WindowElements;

namespace Igtampe.BasicWindows.TickableWindowElements {
    
    /// <summary>Example tickable element that counts down from the time given.</summary>
    public class Timer:TickableWindowElement {

        /// <summary>Original time this timer was counting down from in seconds.</summary>
        public readonly double Time;

        /// <summary>Window that will execute when time is up</summary>
        public Window TimeUpWindow { get; set; }

        /// <summary>Time left in Miliseconds</summary>
        public double TimeLeft { get; protected set; }
        private readonly Progressbar MyProgressBar;

        /// <summary>Creates a timer element that will cut execution when it reaches 0, and that will show a progress bar going from 100% to 0% as time progresses</summary>
        /// <param name="Parent"></param>
        /// <param name="Time"></param>
        /// <param name="progressbar"></param>
        public Timer(Window Parent, int Time, Progressbar progressbar):this(Parent,Time) {
            MyProgressBar = progressbar;
            progressbar.Percent = 1;
        }

        /// <summary>Creates a silent timer that will cut execution when it reaches 0.</summary>
        /// <param name="Parent"></param>
        /// <param name="Time"></param>
        public Timer(Window Parent,int Time):base(Parent) {
            this.Time = Time * 1000.0;
            TimeLeft = this.Time;
        }
        /// <summary>Draws the progress bar this element holds</summary>
        public override void DrawElement() {MyProgressBar?.DrawElement();}

        /// <summary>Ticks this element, and takes away 250ms from this timer</summary>
        /// <returns>True if there's still time, false otherwise</returns>
        public override bool Tick() {
            TimeLeft -= 250;
            MyProgressBar.Percent = TimeLeft / Time;
            DrawElement();

            if(TimeLeft <= 0) {
                TimeUpWindow?.Execute();
                return false;
            }

            return true;
        }
    }
}
