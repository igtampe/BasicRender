using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Igtampe.BasicWindows {
    public enum KeyPressReturn { NOTHING, NEXT_ELEMENT, PREV_ELEMENT, CLOSE, PROCEED }

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
        public void setHighlighted(Boolean Highlighted) { this.Highlighted = Highlighted; }
        public abstract void DrawElement(int WindowLeft,int WindowTop);

    }
}
