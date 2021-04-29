using System;
using Igtampe.BasicRender;
using Igtampe.BasicWindows.Utils;
using Igtampe.BasicWindows.Windows;

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
        public Label(Window Parent,string Text,ConsoleColor BG,ConsoleColor FG,int LeftPos,int TopPos) : this(Parent,
            new FormattedText(Text,Parent.Length - LeftPos,Parent.Height - TopPos),BG,FG,LeftPos,TopPos){}

        /// <summary>Creates a label window element of the specified maximum width and maximum height</summary>
        /// <param name="Parent"></param>
        /// <param name="Text"></param>
        /// <param name="MaxWidth"></param>
        /// <param name="MaxHeight"></param>
        /// <param name="BG"></param>
        /// <param name="FG"></param>
        /// <param name="LeftPos"></param>
        /// <param name="TopPos"></param>
        public Label(Window Parent,string Text,int MaxWidth,int MaxHeight,ConsoleColor BG,ConsoleColor FG,int LeftPos,int TopPos):this(Parent,
            new FormattedText(Text,Math.Min(Parent.Length - LeftPos,MaxWidth),Math.Min(Parent.Height - TopPos,MaxHeight)),BG,FG,LeftPos,TopPos) {}

        /// <summary>Creates a label with pre-formated text</summary>
        /// <param name="Parent"></param>
        /// <param name="Text"></param>
        /// <param name="BG"></param>
        /// <param name="FG"></param>
        /// <param name="LeftPos"></param>
        /// <param name="TopPos"></param>
        public Label(Window Parent,FormattedText Text,ConsoleColor BG,ConsoleColor FG,int LeftPos,int TopPos) : base(Parent) {
            
            //Maybe at some point it'd be good to check if the formatted text can *fit* but shh

            this.Text = Text.Text;
            this.BG = BG;
            this.FG = FG;
            this.LeftPos = LeftPos;
            this.TopPos = TopPos;
        }

        /// <summary>Draws this label</summary>
        public override void DrawElement() {
            int LineOffset = 0;
            foreach(String Line in Text.Replace("\r","").Split('\n')) {
                Draw.Sprite(Line,BG,FG,Parent.LeftPos + LeftPos,Parent.TopPos + TopPos+LineOffset);
                LineOffset++;
            }
            
        
        }
    }
}
