using System;
using Igtampe.BasicRender;

namespace Igtampe.BasicWindows.WindowElements {
    /// <summary>Label that holds text</summary>
    public class Label:WindowElement {
        private String Text;
        private ConsoleColor BG;
        private ConsoleColor FG;

        public Label(Window Parent,string Text,ConsoleColor BG,ConsoleColor FG,int LeftPos,int TopPos) : base(Parent) {
            this.Text = Text;
            this.BG = BG;
            this.FG = FG;
            this.LeftPos = LeftPos;
            this.TopPos = TopPos;
        }

        public override void DrawElement(int WindowLeft,int WindowTop) { Draw.Sprite(Text,BG,FG,WindowLeft + LeftPos,WindowTop + TopPos); }
    }
}
