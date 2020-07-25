using Igtampe.BasicRender;
using System;

namespace Igtampe.BasicWindows.WindowElements {

    /// <summary>ProgressBar window element</summary>
    public class Progressbar:WindowElement {

        private double percent;

        /// <summary>Percent of this progress bar.</summary>
        public double Percent {
            get { return percent; }
            //Make sure any attempt to make this below 0 or above 1 are caught
            set { percent = Math.Max(0,Math.Min(value,1)); }
        }

        /// <summary>Background of this progressbar</summary>
        protected ConsoleColor BG;
        
        /// <summary>Color of the bar that will be drawn on top of this progressbar to indicate progress.</summary>
        protected ConsoleColor BarColor;
        private readonly int Length;

        /// <summary>Creates a ProgressBar with the default colors (DarkGray BG, DarkBlue Bar Color)</summary>
        /// <param name="Parent"></param>
        /// <param name="Length"></param>
        /// <param name="LeftPos"></param>
        /// <param name="TopPos"></param>
        public Progressbar(Window Parent,int Length,int LeftPos,int TopPos) : this(Parent,Length,LeftPos,TopPos,ConsoleColor.DarkGray,ConsoleColor.DarkBlue) { }

        /// <summary>Creates a ProgressBar</summary>
        /// <param name="Parent"></param>
        /// <param name="Length"></param>
        /// <param name="LeftPos"></param>
        /// <param name="TopPos"></param>
        /// <param name="BG"></param>
        /// <param name="BarColor"></param>
        public Progressbar(Window Parent, int Length, int LeftPos, int TopPos, ConsoleColor BG,ConsoleColor BarColor):base(Parent){
            this.Length = Length;
            this.LeftPos = LeftPos;
            this.TopPos = TopPos;
            this.BG = BG;
            this.BarColor = BarColor;
        }

        /// <summary>Draws this progress bar</summary>
        public override void DrawElement() {
            Draw.Row(BG,Length,LeftPos + Parent.LeftPos,TopPos + Parent.TopPos);
            Draw.Row(BarColor,Convert.ToInt32(Length * Percent),LeftPos + Parent.LeftPos,TopPos + Parent.TopPos);
        }

    }
}
