using System;
using Igtampe.BasicRender;

namespace Igtampe.BasicWindows.WindowElements {
    /// <summary>Window Element that draws a nice box</summary>
    public class Box : WindowElement {

        private readonly int Length;
        private readonly int Height;
        private readonly ConsoleColor Color;

        /// <summary>Creates a box Window Element</summary>
        /// <param name="Parent"></param>
        /// <param name="Color"></param>
        /// <param name="Length"></param>
        /// <param name="Height"></param>
        /// <param name="LeftPos"></param>
        /// <param name="TopPos"></param>
        public Box(Window Parent, ConsoleColor Color, int Length, int Height, int LeftPos, int TopPos) : base(Parent) {
            this.Length = Length;
            this.Color = Color;
            this.Height = Height;
            this.LeftPos = LeftPos;
            this.TopPos = TopPos;
        }

        /// <summary>Draws this box</summary>
        public override void DrawElement() => Draw.Box(Color, Length, Height, Parent.LeftPos + LeftPos, Parent.TopPos + TopPos);
    }
}
