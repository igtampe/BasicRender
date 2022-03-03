using Igtampe.BasicRender;
using System;

namespace Igtampe.BasicWindows.WindowElements {

    /// <summary>Slider element that is controlled with left and right arrow keys</summary>
    public class Slider : Textbox {

        private int sliderPosition;

        /// <summary>Position of the slider along the length of the element.</summary>
        public int SliderPosition {
            get => sliderPosition;
            set => sliderPosition = Math.Min(Length - 1, Math.Max(0, value));
        }

        /// <summary>Creates a slider with as many positions as the length of the element</summary>
        /// <param name="Parent"></param>
        /// <param name="Length"></param>
        /// <param name="LeftPos"></param>
        /// <param name="TopPos"></param>
        /// <param name="BG"></param>
        /// <param name="HighlightedBG"></param>
        /// <param name="FG"></param>
        public Slider(Window Parent, int Length, int LeftPos, int TopPos, ConsoleColor BG, ConsoleColor HighlightedBG, ConsoleColor FG) 
            : base(Parent, Length, LeftPos, TopPos, BG, HighlightedBG, FG) => SliderPosition = 0;

        /// <summary>Handles a keypress of this element.</summary>
        /// <param name="Key"></param>
        /// <returns></returns>
        public override KeyPressReturn OnKeyPress(ConsoleKeyInfo Key) {
            switch (Key.Key) {
                case ConsoleKey.LeftArrow:
                    SliderPosition--;
                    break;
                case ConsoleKey.RightArrow:
                    SliderPosition++;
                    break;
                case ConsoleKey.Enter:
                case ConsoleKey.DownArrow:
                    return KeyPressReturn.NEXT_ELEMENT;
                case ConsoleKey.UpArrow:
                    return KeyPressReturn.PREV_ELEMENT;
                case ConsoleKey.Tab:
                    if (Key.Modifiers == ConsoleModifiers.Shift) { return KeyPressReturn.PREV_ELEMENT; }
                    return KeyPressReturn.NEXT_ELEMENT;
                default:
                    return KeyPressReturn.NOTHING;
            }
            DrawElement();
            return KeyPressReturn.NOTHING;

        }

        /// <summary>Draws this element</summary>
        public override void DrawElement() {
            base.DrawElement();

            //Draw the slider bit.
            Draw.Block(FG, Parent.LeftPos + LeftPos + SliderPosition, TopPos + Parent.TopPos);

        }
    }
}
