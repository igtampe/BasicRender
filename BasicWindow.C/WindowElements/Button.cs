using System;
using Igtampe.BasicRender;

namespace Igtampe.BasicWindows.WindowElements {
    /// <summary>Button, though it may as well be a clickable link.</summary>
    public abstract class Button:WindowElement {
        protected ConsoleColor HighlightedBG;
        protected ConsoleColor BG;
        protected ConsoleColor FG;
        protected String Text;

        public Button(Window Parent,String Text,ConsoleColor BG,ConsoleColor FG,ConsoleColor HighlightedBG,int LeftPos,int TopPos) : base(Parent) {
            this.Text = Text;
            this.BG = BG;
            this.FG = FG;
            this.HighlightedBG = HighlightedBG;
            this.LeftPos = LeftPos;
            this.TopPos = TopPos;
        }

        public override void DrawElement(int WindowLeft,int WindowTop) {
            if(Highlighted) { Draw.Sprite(Text,HighlightedBG,FG,WindowLeft + LeftPos,WindowTop + TopPos); } else { Draw.Sprite(Text,BG,FG,WindowLeft + LeftPos,WindowTop + TopPos); }
        }

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
        public abstract KeyPressReturn Action();
    }

    /// <summary>Button that signals the window to close when pressed.</summary>
    public class CloseButton:Button {
        public CloseButton(Window Parent,string Text,ConsoleColor BG,ConsoleColor FG,ConsoleColor HighlightedBG,int LeftPos,int TopPos) : base(Parent,Text,BG,FG,HighlightedBG,LeftPos,TopPos) { }
        public override KeyPressReturn Action() { return KeyPressReturn.CLOSE; }
    }


}
