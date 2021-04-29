using System;
using Igtampe.BasicRender;
using Igtampe.BasicWindows.Utils;
using Igtampe.BasicFonts;

namespace Igtampe.BasicWindows.WindowElements {
    /// <summary>Label that holds text and is drawn using a specified BasicFont</summary>
    public class BasicFontLabel:WindowElement {
        private readonly String Text;
        private readonly ConsoleColor FG;
        private readonly BasicFont Font;

        /// <summary>Creates a Label Window element</summary>
        /// <param name="Parent"></param>
        /// <param name="Text"></param>
        /// <param name="Font"></param>
        /// <param name="FG"></param>
        /// <param name="LeftPos"></param>
        /// <param name="TopPos"></param>
        public BasicFontLabel(Window Parent,string Text,BasicFont Font,ConsoleColor FG,int LeftPos,int TopPos) : this(Parent,
            new BasicFontFormattedText(Text,Font,Parent.Length - LeftPos,Parent.Height - TopPos),Font,FG,LeftPos,TopPos){}

        /// <summary>Creates a label window element of the specified maximum width and maximum height</summary>
        /// <param name="Parent"></param>
        /// <param name="Text"></param>
        /// <param name="Font"></param>
        /// <param name="MaxWidth"></param>
        /// <param name="MaxHeight"></param>
        /// <param name="FG"></param>
        /// <param name="LeftPos"></param>
        /// <param name="TopPos"></param>
        public BasicFontLabel(Window Parent,string Text,BasicFont Font,int MaxWidth,int MaxHeight,ConsoleColor FG,int LeftPos,int TopPos):this(Parent,
            new BasicFontFormattedText(Text,Font,Math.Min(Parent.Length - LeftPos,MaxWidth),Math.Min(Parent.Height - TopPos,MaxHeight)),Font,FG,LeftPos,TopPos) {}

        /// <summary>Creates a label with pre-formated text</summary>
        /// <param name="Parent"></param>
        /// <param name="Text"></param>
        /// <param name="Font"></param>
        /// <param name="FG"></param>
        /// <param name="LeftPos"></param>
        /// <param name="TopPos"></param>
        public BasicFontLabel(Window Parent,BasicFontFormattedText Text,BasicFont Font,ConsoleColor FG,int LeftPos,int TopPos) : base(Parent) {

            //Maybe at some point it'd be good to check if the formatted text can *fit* but shh
            this.Font = Font;
            this.Text = Text.Text;
            this.FG = FG;
            this.LeftPos = LeftPos;
            this.TopPos = TopPos;
        }

        /// <summary>Draws this label</summary>
        public override void DrawElement() {
            int LineOffset = 0;
            foreach(String Line in Text.Split('\n')) {
                Font.DrawText(Line,Parent.LeftPos + LeftPos,Parent.TopPos + TopPos + (LineOffset * Font.Height + 1),FG);
                LineOffset++;
            }
            
        
        }
    }
}
