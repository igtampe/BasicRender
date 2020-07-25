using System;
using Igtampe.BasicRender;

namespace Igtampe.BasicWindows.WindowElements {
    /// <summary>Button, though it may as well be a clickable link.</summary>
    public abstract class Button:WindowElement {

        /// <summary>Background when this button is highlighted</summary>
        protected ConsoleColor HighlightedBG;

        /// <summary>Background of this Button when it isn't highlighted</summary>
        protected ConsoleColor BG;

        /// <summary>Foreground of thie element</summary>
        protected ConsoleColor FG;

        /// <summary>Text on this button</summary>
        protected String Text;

        /// <summary>Creates a button</summary>
        /// <param name="Parent"></param>
        /// <param name="Text"></param>
        /// <param name="BG"></param>
        /// <param name="FG"></param>
        /// <param name="HighlightedBG"></param>
        /// <param name="LeftPos"></param>
        /// <param name="TopPos"></param>
        public Button(Window Parent,String Text,ConsoleColor BG,ConsoleColor FG,ConsoleColor HighlightedBG,int LeftPos,int TopPos) : base(Parent) {
            this.Text = Text;
            this.BG = BG;
            this.FG = FG;
            this.HighlightedBG = HighlightedBG;
            this.LeftPos = LeftPos;
            this.TopPos = TopPos;
        }

        /// <summary>Draws this button</summary>
        public override void DrawElement() {
            if(Highlighted) { Draw.Sprite(Text,HighlightedBG,FG,Parent.LeftPos + LeftPos,Parent.TopPos + TopPos); } else { Draw.Sprite(Text,BG,FG,Parent.LeftPos + LeftPos,Parent.TopPos + TopPos); }
        }

        /// <summary>Handles what happens when a key is pressed and this button is highlighted</summary>
        /// <param name="Key"></param>
        /// <returns></returns>
        public override KeyPressReturn OnKeyPress(ConsoleKeyInfo Key) {
            switch(Key.Key) {
                case ConsoleKey.Enter:
                    return Action();
                case ConsoleKey.LeftArrow:
                    return KeyPressReturn.PREV_ELEMENT;
                case ConsoleKey.RightArrow:
                    return KeyPressReturn.NEXT_ELEMENT;
                case ConsoleKey.Tab:
                    if(Key.Modifiers == ConsoleModifiers.Shift) { return KeyPressReturn.PREV_ELEMENT; } else { return KeyPressReturn.NEXT_ELEMENT; }
                default:
                    return KeyPressReturn.NOTHING;
            }
        }

        /// <summary>Abstract method that an actual button needs to override, so that an action happens when you hit enter.</summary>
        /// <returns></returns>
        public abstract KeyPressReturn Action();
    }

}
