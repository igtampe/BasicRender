using System;

namespace Igtampe.BasicWindows.WindowElements {

    /// <summary>Textbox that only accepts numerical values</summary>
    public class NumericalTextBox:Textbox {

        private int val;

        /// <summary>Value of the text this NumericalTextBox Holds</summary>
        public int Value {
            get { return val; }
            set { val = Math.Min(value,MaximumVal);
                Text = val.ToString();
            }
        }

        private readonly int MaximumVal;

        /// <summary>Creates a Numerical TextBox</summary>
        /// <param name="Parent"></param>
        /// <param name="MaximumVal"></param>
        /// <param name="Length"></param>
        /// <param name="LeftPos"></param>
        /// <param name="TopPos"></param>
        /// <param name="BG"></param>
        /// <param name="HighlightedBG"></param>
        /// <param name="FG"></param>
        public NumericalTextBox(Window Parent,int MaximumVal,int Length,int LeftPos,int TopPos,ConsoleColor BG,ConsoleColor HighlightedBG,ConsoleColor FG) : base(Parent,Length,LeftPos,TopPos,BG,HighlightedBG,FG) {
            this.MaximumVal = MaximumVal;
            Value = 0;
        }

        /// <summary>Handles the key press of this numerical textbox.</summary>
        /// <param name="Key"></param>
        /// <returns></returns>
        public override KeyPressReturn OnKeyPress(ConsoleKeyInfo Key) {
            if(!char.IsLetter(Key.KeyChar)) {
                KeyPressReturn Return;
                String OldText = Text;
                Return = base.OnKeyPress(Key);

                if(OldText != Text) {
                    //if the text was modified update value
                    if(Int32.TryParse(Text,out int tempval)) { Value = tempval; }

                } 
                DrawElement();
                return Return;

            }
            return KeyPressReturn.NOTHING;
        }



    }
}
