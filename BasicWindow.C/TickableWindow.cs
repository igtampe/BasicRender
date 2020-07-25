using Igtampe.BasicRender;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Igtampe.BasicWindows {

    /// <summary>Creates a window that can "Tick". A tick subroutine is called every 250 ms.</summary>
    public class TickableWindow:Window {

        /// <summary>Creates an Animated, Shadowed, and centered tickable window with a centered header with the default colors (Gray Main BG, dark blue header, White Header Text)</summary>
        /// <param name="Title"></param>
        /// <param name="Length"></param>
        /// <param name="Height"></param>
        public TickableWindow(String Title,int Length,int Height) : base(true,true,ConsoleColor.Gray,ConsoleColor.DarkBlue,ConsoleColor.White,HeaderPosition.CENTER,Title,Length,Height,-1,-1) { }

        /// <summary>Creates an Animated, Shadowed, and Centered tickable window with a centered header with the specified colors.</summary>
        /// <param name="MainBG"></param>
        /// <param name="HeaderBG"></param>
        /// <param name="HeaderFG"></param>
        /// <param name="Title"></param>
        /// <param name="Length"></param>
        /// <param name="Height"></param>
        public TickableWindow(ConsoleColor MainBG,ConsoleColor HeaderBG,ConsoleColor HeaderFG,String Title,int Length,int Height) : base(true,true,MainBG,HeaderBG,HeaderFG,HeaderPosition.CENTER,Title,Length,Height,-1,-1) { }

        /// <summary>Creates a centered tickable window with a centered header with the default colors (Gray Main BG, dark blue header, White Header Text)</summary>
        /// <param name="Animated"></param>
        /// <param name="Shadowed"></param>
        /// <param name="Title"></param>
        /// <param name="Length"></param>
        /// <param name="Height"></param>
        public TickableWindow(Boolean Animated,Boolean Shadowed,String Title,int Length,int Height) : base(Animated,Shadowed,ConsoleColor.Gray,ConsoleColor.DarkBlue,ConsoleColor.White,HeaderPosition.CENTER,Title,Length,Height,-1,-1) { }

        /// <summary>Creates a centered tickable window with a centered header</summary>
        /// <param name="Animated"></param>
        /// <param name="Shadowed"></param>
        /// <param name="MainBG"></param>
        /// <param name="HeaderBG"></param>
        /// <param name="HeaderFG"></param>
        /// <param name="Title"></param>
        /// <param name="Length"></param>
        /// <param name="Height"></param>
        public TickableWindow(Boolean Animated,Boolean Shadowed,ConsoleColor MainBG,ConsoleColor HeaderBG,ConsoleColor HeaderFG,String Title,int Length,int Height) : base(Animated,Shadowed,MainBG,HeaderBG,HeaderFG,HeaderPosition.CENTER,Title,Length,Height,-1,-1) { }

        /// <summary>Creates a Tickable Window centered on the screen</summary>
        /// <param name="Animated"></param>
        /// <param name="Shadowed"></param>
        /// <param name="MainBG"></param>
        /// <param name="HeaderBG"></param>
        /// <param name="HeaderFG"></param>
        /// <param name="HeadPos"></param>
        /// <param name="Title"></param>
        /// <param name="Length"></param>
        /// <param name="Height"></param>
        public TickableWindow(Boolean Animated,Boolean Shadowed,ConsoleColor MainBG,ConsoleColor HeaderBG,ConsoleColor HeaderFG,HeaderPosition HeadPos,String Title,int Length,int Height) : base(Animated,Shadowed,MainBG,HeaderBG,HeaderFG,HeadPos,Title,Length,Height,-1,-1) { }

        /// <summary>
        /// Creates a Tickable Window. You get basically full control of everything with base constructor.
        /// </summary>
        /// <param name="Animated"></param>
        /// <param name="Shadowed"></param>
        /// <param name="MainBG"></param>
        /// <param name="HeaderBG"></param>
        /// <param name="HeaderFG"></param>
        /// <param name="HeadPos"></param>
        /// <param name="Title"></param>
        /// <param name="Length"></param>
        /// <param name="Height"></param>
        /// <param name="LeftPos"></param>
        /// <param name="TopPos"></param>
        public TickableWindow(Boolean Animated,Boolean Shadowed,ConsoleColor MainBG,ConsoleColor HeaderBG,ConsoleColor HeaderFG,HeaderPosition HeadPos,String Title,int Length,int Height,int LeftPos,int TopPos):base(Animated,Shadowed,MainBG,HeaderBG,HeaderFG,HeadPos,Title,Length,Height,LeftPos,TopPos) {}

        /// <summary>Executes this tickable window</summary>
        public override void Execute() {
            DrawWindow(Animated);

            //OnKeyPress returns true if we should continue execution.
            while(true) {

                //If there's a key to read, read it, otherwise, do not.
                if(Console.KeyAvailable) {
                    if(!OnKeyPress(Console.ReadKey(true))) {
                        Close();
                        return; 
                    }
                }
                if(!Tick()) {
                    Close();
                    return;
                }
                RenderUtils.Sleep(250);
                
            }
        }

        /// <summary>
        /// Subroutine that runs every 250ms while the window is waiting for user input.
        /// At Base, it ticks every tickable element.
        /// </summary>
        /// <returns>True if execution should continue</returns>
        protected virtual bool Tick() {

            //tick each element.
            foreach(WindowElement element in AllElements) {

                //Look at us making some nice code and using the question mark cosa
                TickableWindowElement TickableElement = element as TickableWindowElement;
                bool? cont = TickableElement?.Tick();
                if(cont ==false) { return false; }
            }

            return true;
        }

    }
}
