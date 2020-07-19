using System;
using Igtampe.BasicRender;

namespace Igtampe.BasicWindows.WindowElements {
    /// <summary>Label that holds text</summary>
    public class Label:WindowElement {
        private readonly String Text;
        private readonly ConsoleColor BG;
        private readonly ConsoleColor FG;

        public Label(Window Parent,string Text,ConsoleColor BG,ConsoleColor FG,int LeftPos,int TopPos) : base(Parent) {
            this.Text = Text;
            this.BG = BG;
            this.FG = FG;
            this.LeftPos = LeftPos;
            this.TopPos = TopPos;
        }

        public override void DrawElement(int WindowLeft,int WindowTop) {
            int LineOffset = 0;
            foreach(String Line in Text.Split('\n')) {
                Draw.Sprite(Line,BG,FG,WindowLeft + LeftPos,WindowTop + TopPos+LineOffset);
                LineOffset++;
            }
            
        
        }
    }
}
