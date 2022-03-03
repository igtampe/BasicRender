using System;

namespace Igtampe.BasicWindows.WindowElements {
    /// <summary>Close button that includes a flag variable that's activated when it is triggered.</summary>
    public class FlaggedCloseButton : CloseButton {

        /// <summary>The flag of this FlaggedButton. Should be true if this element was triggered </summary>
        public bool Flag { get; private set; }

        /// <summary>Creates a Flagged Close Button</summary>
        /// <param name="Parent"></param>
        /// <param name="Text"></param>
        /// <param name="BG"></param>
        /// <param name="FG"></param>
        /// <param name="HighlightedBG"></param>
        /// <param name="LeftPos"></param>
        /// <param name="TopPos"></param>
        public FlaggedCloseButton(Window Parent, string Text, ConsoleColor BG, ConsoleColor FG, ConsoleColor HighlightedBG, int LeftPos, int TopPos) : base(Parent, Text, BG, FG, HighlightedBG, LeftPos, TopPos) => Flag = false;

        /// <summary>Closes the window, and sets the FLAG on this button to true</summary>
        /// <returns>The base's result, which in this case is CLOSE</returns>
        public override KeyPressReturn Action() {
            Flag = true;
            return base.Action();
        }
    }
}
