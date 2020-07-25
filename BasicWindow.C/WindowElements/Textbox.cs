using Igtampe.BasicRender;
using System;

namespace Igtampe.BasicWindows.WindowElements {

    /// <summary>Textbox that accepts text when a user hits a key</summary>
    public class Textbox:WindowElement {

        /// <summary>Length of this textbox</summary>
        protected readonly int Length;

        /// <summary>Background Color of this textbox</summary>
        protected readonly ConsoleColor BG;

        /// <summary>Highlighted Color of this Textbox</summary>
        protected readonly ConsoleColor HighlightedBG;

        /// <summary>Foreground (Text) color of this textbox</summary>
        protected readonly ConsoleColor FG;

        /// <summary>Text this TextBox contains</summary>
        public string Text { get; set; }

        /// <summary>Creates a textbox windowelement</summary>
        /// <param name="Parent"></param>
        /// <param name="Length"></param>
        /// <param name="LeftPos"></param>
        /// <param name="TopPos"></param>
        /// <param name="BG"></param>
        /// <param name="HighlightedBG"></param>
        /// <param name="FG"></param>
        public Textbox(Window Parent,int Length, int LeftPos, int TopPos, ConsoleColor BG, ConsoleColor HighlightedBG, ConsoleColor FG) : base(Parent) {
            this.Length = Length;
            this.LeftPos = LeftPos;
            this.TopPos = TopPos;
            this.BG = BG;
            this.HighlightedBG = HighlightedBG;
            this.FG = FG;
            Text = "";
        }

        /// <summary>Accepts Key Input, and if needed, modifies the text in this textbox</summary>
        /// <param name="Key"></param>
        /// <returns></returns>
        public override KeyPressReturn OnKeyPress(ConsoleKeyInfo Key) {

            switch(Key.Key) {
                case ConsoleKey.Backspace:
                    if(Text.Length > 0) { Text = Text.Remove(Text.Length - 1); }
                    break;
                case ConsoleKey.Enter:
                case ConsoleKey.RightArrow:
                case ConsoleKey.DownArrow:
                    return KeyPressReturn.NEXT_ELEMENT;
                case ConsoleKey.LeftArrow:
                case ConsoleKey.UpArrow:
                    return KeyPressReturn.PREV_ELEMENT;
                case ConsoleKey.Tab:
                    if(Key.Modifiers == ConsoleModifiers.Shift) { return KeyPressReturn.PREV_ELEMENT; }
                    return KeyPressReturn.NEXT_ELEMENT;
                default:
                    Text += Key.KeyChar;
                    break;
            }
            DrawElement();
            return KeyPressReturn.NOTHING;
        }

        /// <summary>Draws this textbox</summary>
        public override void DrawElement() {

            ConsoleColor Color = BG;
            if(Highlighted) {Color = HighlightedBG;}

            Draw.Box(Color,Length,1,Parent.LeftPos + LeftPos,Parent.TopPos + TopPos);

            String DrawText = Text;
            if(DrawText.Length > Length) { DrawText = DrawText.Remove(0,DrawText.Length-Length); }

            Draw.Sprite(DrawText,Color,FG,LeftPos+Parent.LeftPos,TopPos+Parent.TopPos);

        }
    }

    

}
