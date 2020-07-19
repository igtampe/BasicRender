using System;
using Igtampe.BasicRender;

namespace Igtampe.BasicWindows.WindowElements {
    /// <summary>Label that holds text</summary>
    public class Label:WindowElement {
        private readonly String Text;
        private readonly ConsoleColor BG;
        private readonly ConsoleColor FG;

        /// <summary>Creates a Label Window element</summary>
        /// <param name="Parent"></param>
        /// <param name="Text"></param>
        /// <param name="BG"></param>
        /// <param name="FG"></param>
        /// <param name="LeftPos"></param>
        /// <param name="TopPos"></param>
        public Label(Window Parent,string Text,ConsoleColor BG,ConsoleColor FG,int LeftPos,int TopPos) : base(Parent) {
            this.Text = Text;
            this.BG = BG;
            this.FG = FG;
            this.LeftPos = LeftPos;
            this.TopPos = TopPos;
        }

        /// <summary>Draws this label</summary>
        public override void DrawElement() {
            int LineOffset = 0;
            foreach(String Line in Text.Split('\n')) {
                Draw.Sprite(Line,BG,FG,Parent.LeftPos + LeftPos,Parent.TopPos + TopPos+LineOffset);
                LineOffset++;
            }
            
        
        }
    }
}
