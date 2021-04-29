using System;
using System.Collections.Generic;

namespace Igtampe.BasicWindows.WindowElements {

    /// <summary>WindowElement that allows a user to select from a list of strings by using the left or right arrow keys</summary>
    public class LeftRightSelect:Textbox {

        /// <summary>List of strings a user can select from this LeftRightSelect</summary>
        private readonly List<String> Items;
        private int selectedItemIndex;

        /// <summary>Selected item index of this LeftRightSelect</summary>
        public int SelectedItemIndex {
            get { return selectedItemIndex; }
            set {

                //Unlike the one in Henja, this means no wrap-around, but I think that's ok. We need to test this eventually.
                selectedItemIndex = Math.Min(Items.Count - 1,Math.Max(0,value));
                Text = Items[selectedItemIndex];
            }
        }

        /// <summary>Creates a LeftRightSelect with the given items</summary>
        /// <param name="Parent"></param>
        /// <param name="Items"></param>
        /// <param name="Length"></param>
        /// <param name="LeftPos"></param>
        /// <param name="TopPos"></param>
        /// <param name="BG"></param>
        /// <param name="HighlightedBG"></param>
        /// <param name="FG"></param>
        public LeftRightSelect(Window Parent, List<String> Items, int Length,int LeftPos,int TopPos,ConsoleColor BG,ConsoleColor HighlightedBG,ConsoleColor FG) : base(Parent,Length,LeftPos,TopPos,BG,HighlightedBG,FG) {
            this.Items = Items;
            SelectedItemIndex = 0;
        }

        /// <summary>Handles a keypress on this LeftRightSelect</summary>
        /// <param name="Key"></param>
        /// <returns></returns>
        public override KeyPressReturn OnKeyPress(ConsoleKeyInfo Key) {
            switch(Key.Key) {
                case ConsoleKey.LeftArrow:
                    SelectedItemIndex--;
                    break;
                case ConsoleKey.RightArrow:
                    SelectedItemIndex++;
                    break;
                case ConsoleKey.Enter:
                case ConsoleKey.DownArrow:
                    return KeyPressReturn.NEXT_ELEMENT;
                case ConsoleKey.UpArrow:
                    return KeyPressReturn.PREV_ELEMENT;
                case ConsoleKey.Tab:
                    if(Key.Modifiers == ConsoleModifiers.Shift) { return KeyPressReturn.PREV_ELEMENT; }
                    return KeyPressReturn.NEXT_ELEMENT;
                default:
                    return KeyPressReturn.NOTHING;
            }
            DrawElement();
            return KeyPressReturn.NOTHING;

        }

    }
}
