using System;

namespace Igtampe.BasicWindows {

    /// <summary>Small Enum that tells what the parent window should do once this element is done being interacted with.</summary>
    public enum KeyPressReturn { 
        
        /// <summary>No response</summary>
        NOTHING, 

        /// <summary>Go to the next Element</summary>
        NEXT_ELEMENT, 

        /// <summary>Go back to the previous element</summary>
        PREV_ELEMENT, 

        /// <summary>Close the form</summary>
        CLOSE}

    /// <summary>Generic WindowElement</summary>
    public abstract class WindowElement {

        /// <summary>Element to move to when hitting right arrow, or tab</summary>
        public WindowElement NextElement { get; set; }

        /// <summary>Element to move to when hitting the left or SHIFT+TAB</summary>
        public WindowElement PreviousElement { get; set; }

        /// <summary>Parent of this window element</summary>
        protected Window Parent;

        /// <summary>Left position of this element with reference to the window's left position</summary>
        protected int LeftPos;

        /// <summary>Top position of this element with reference to the window's top position</summary>
        protected int TopPos;

        private Boolean highlighted;

        /// <summary>Specifies whether or not this element is highlighted</summary>
        public Boolean Highlighted {
            get { return highlighted; }
            set { 
                highlighted = value;
                DrawElement();
            }
        }


        /// <summary>Most basic constructor for any window element</summary>
        /// <param name="Parent"></param>
        public WindowElement(Window Parent) { this.Parent = Parent; }
        
        /// <summary>Triggered when a key is hit, and handles any user interaction with this element</summary>
        /// <param name="Key"></param>
        /// <returns></returns>
        public virtual KeyPressReturn OnKeyPress(ConsoleKeyInfo Key) { return KeyPressReturn.NOTHING; }
        
        /// <summary>Draws the element</summary>
        public abstract void DrawElement();

    }
}
