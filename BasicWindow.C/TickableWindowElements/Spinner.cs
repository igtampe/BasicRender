using Igtampe.BasicRender;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Igtampe.BasicWindows.TickableWindowElements {

    /// <summary>Spinner that "spins" one frame every 250ms</summary>
    public class Spinner:TickableWindowElement {

        private int State = 0;
        private readonly String[] Frames = { "|","/","-","\\"};

        private readonly ConsoleColor BG;
        private readonly ConsoleColor FG;

        /// <summary>Creates a spinner window element</summary>
        /// <param name="Parent"></param>
        /// <param name="BG"></param>
        /// <param name="FG"></param>
        /// <param name="LeftPos"></param>
        /// <param name="TopPos"></param>
        public Spinner(Window Parent, ConsoleColor BG, ConsoleColor FG, int LeftPos, int TopPos):base(Parent) {
            this.LeftPos = LeftPos;
            this.TopPos = TopPos;
            this.BG = BG;
            this.FG = FG;
        }

        /// <summary>Draws the spinner, and increments its state by one.</summary>
        public override void DrawElement() {
            Draw.Sprite(Frames[State],BG,FG,LeftPos + Parent.LeftPos,TopPos + Parent.TopPos);
            State++;
            if(State == Frames.Length) { State = 0; }
        }

        /// <summary>Draws the element again, spinning one frame</summary>
        /// <returns>Always returns true. Execution is not determined by the spinner.</returns>
        public override bool Tick() {
            DrawElement();
            return true;
        }
    }
}
