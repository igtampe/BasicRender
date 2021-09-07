using System;

namespace Igtampe.BasicWindows {

    /// <summary>Tickable window element that will tick on a tickable window every 250ms</summary>
    public abstract class TickableWindowElement:WindowElement {

        /// <summary>Creates a tickable window element</summary>
        /// <param name="Parent"></param>
        protected TickableWindowElement(Window Parent) : base(Parent) { }

        /// <summary>Makes the element "tick". Should occur every 250ms</summary>
        /// <returns>True if execution should continue</returns>
        public abstract Boolean Tick();

    }
}
