using System;

namespace Igtampe.BasicWindows {
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

        protected WindowElement NextElement;
        protected WindowElement PreviousElement;
        protected Window Parent;

        protected int LeftPos;
        protected int TopPos;
        protected Boolean Highlighted;

        public WindowElement(Window Parent) { this.Parent = Parent; }

        public WindowElement GetNextElement() { return NextElement; }
        public WindowElement GetPrevElement() { return PreviousElement; }
        public void SetNextElement(WindowElement NextElement) { this.NextElement = NextElement; }
        public void SetPrevElement(WindowElement PrevElement) { this.PreviousElement = PrevElement; }

        public virtual KeyPressReturn OnKeyPress(ConsoleKeyInfo Key) { return KeyPressReturn.NOTHING; }
        public void SetHighlighted(Boolean Highlighted) { this.Highlighted = Highlighted; }
        public abstract void DrawElement(int WindowLeft,int WindowTop);

    }
}
