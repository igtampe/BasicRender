using System;

namespace Igtampe.BasicWindows.WindowElements {
    /// <summary>Button that signals the window to close when pressed.</summary>
    public class CloseButton:Button {

        /// <summary>Creates a button that interacted with, will close the window</summary>
        /// <param name="Parent"></param>
        /// <param name="Text"></param>
        /// <param name="BG"></param>
        /// <param name="FG"></param>
        /// <param name="HighlightedBG"></param>
        /// <param name="LeftPos"></param>
        /// <param name="TopPos"></param>
        public CloseButton(Window Parent,string Text,ConsoleColor BG,ConsoleColor FG,ConsoleColor HighlightedBG,int LeftPos,int TopPos) : base(Parent,Text,BG,FG,HighlightedBG,LeftPos,TopPos) { }

        /// <summary>Closes the window</summary>
        /// <returns></returns>
        public override KeyPressReturn Action() { return KeyPressReturn.CLOSE; }
    }
}
