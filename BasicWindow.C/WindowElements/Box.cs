using System;
using Igtampe.BasicRender;

namespace Igtampe.BasicWindows.WindowElements {
    /// <summary>Image that holds a BasicRenderGraphic</summary>
    public class Box:WindowElement {

        private int Length;
        private int Height;
        private ConsoleColor Color;


        public Box(Window Parent,ConsoleColor Color,int Length,int Height,int LeftPos,int TopPos) : base(Parent) {
            this.Length = Length;
            this.Color = Color;
            this.Height = Height;
            this.LeftPos = LeftPos;
            this.TopPos = TopPos;
        }

        public override void DrawElement(int WindowLeft,int WindowTop) { Draw.Box(Color,Length,Height,WindowLeft + LeftPos,WindowTop + TopPos); }

    }
}
