using System;
using System.Collections;
using System.Collections.Generic;
using Igtampe.BasicRender;

namespace Igtampe.BasicWindows
{

    /// <summary>Position of the header on a window</summary>
    public enum HeaderPosition { 
        /// <summary>Align the header to the left of the window</summary>
        LEFT, 

        /// <summary>Align the header on the center of the window</summary>
        CENTER, 

        /// <summary>Align the header to the right</summary>
        RIGHT }

    /// <summary>Holds the base for a renderable window.</summary>
    public class Window {

        /// <summary>Color the close function will use to clear the window</summary>
        public static ConsoleColor WindowClearColor = ConsoleColor.DarkCyan;

        /// <summary>Indicates whether this window should "animate" itself when being drawn</summary>
        protected readonly bool Animated;

        /// <summary>Indicates whether this window should have a shadow when being drawn</summary>
        protected readonly bool Shadowed;
        
        /// <summary>Left position of this window</summary>
        public int LeftPos {get;}

        /// <summary>Top position of this window</summary>
        public int TopPos { get; }

        /// <summary>Length of this window</summary>
        public int Length { get; protected set; }

        /// <summary>Height of this window.</summary>
        public int Height { get; protected set; }

        /// <summary>Title of this window</summary>
        protected String Title;

        /// <summary>Main background of this window</summary>
        protected ConsoleColor MainBG;

        /// <summary>Background of the header on this window</summary>
        protected ConsoleColor HeaderBG;

        /// <summary>Foreground of the header of this window</summary>
        protected ConsoleColor HeaderFG;
        
        /// <summary>Position of the header in this window</summary>
        protected HeaderPosition HeadPos;

        /// <summary>Currently highlighted element on this window</summary>
        public WindowElement HighlightedElement { get; set; }

        /// <summary>All elements of this window</summary>
        protected List<WindowElement> AllElements;

        /// <summary>Creates an Animated, Shadowed, and centered window with a centered header with the default colors (Gray Main BG, dark blue header, White Header Text)</summary>
        /// <param name="Title"></param>
        /// <param name="Length"></param>
        /// <param name="Height"></param>
        public Window(String Title,int Length,int Height) : this(true,true,ConsoleColor.Gray,ConsoleColor.DarkBlue,ConsoleColor.White,HeaderPosition.CENTER,Title,Length,Height,-1,-1) { }

        /// <summary>Creates an Animated, Shadowed, and Centered window with a centered header with the specified colors.</summary>
        /// <param name="MainBG"></param>
        /// <param name="HeaderBG"></param>
        /// <param name="HeaderFG"></param>
        /// <param name="Title"></param>
        /// <param name="Length"></param>
        /// <param name="Height"></param>
        public Window(ConsoleColor MainBG,ConsoleColor HeaderBG,ConsoleColor HeaderFG,String Title,int Length,int Height) : this(true,true,MainBG,HeaderBG,HeaderFG,HeaderPosition.CENTER,Title,Length,Height,-1,-1) { }

        /// <summary>Creates a centered window with a centered header with the default colors (Gray Main BG, dark blue header, White Header Text)</summary>
        /// <param name="Animated"></param>
        /// <param name="Shadowed"></param>
        /// <param name="Title"></param>
        /// <param name="Length"></param>
        /// <param name="Height"></param>
        public Window(Boolean Animated,Boolean Shadowed,String Title,int Length,int Height) : this(Animated,Shadowed,ConsoleColor.Gray,ConsoleColor.DarkBlue,ConsoleColor.White,HeaderPosition.CENTER,Title,Length,Height,-1,-1) { }

        /// <summary>Creates a centered window with a centered header</summary>
        /// <param name="Animated"></param>
        /// <param name="Shadowed"></param>
        /// <param name="MainBG"></param>
        /// <param name="HeaderBG"></param>
        /// <param name="HeaderFG"></param>
        /// <param name="Title"></param>
        /// <param name="Length"></param>
        /// <param name="Height"></param>
        public Window(Boolean Animated,Boolean Shadowed,ConsoleColor MainBG,ConsoleColor HeaderBG,ConsoleColor HeaderFG,String Title,int Length,int Height) : this(Animated,Shadowed,MainBG,HeaderBG,HeaderFG,HeaderPosition.CENTER,Title,Length,Height,-1,-1) { }

        /// <summary>Creates a window centered on the screen</summary>
        /// <param name="Animated"></param>
        /// <param name="Shadowed"></param>
        /// <param name="MainBG"></param>
        /// <param name="HeaderBG"></param>
        /// <param name="HeaderFG"></param>
        /// <param name="HeadPos"></param>
        /// <param name="Title"></param>
        /// <param name="Length"></param>
        /// <param name="Height"></param>
        public Window(Boolean Animated,Boolean Shadowed,ConsoleColor MainBG,ConsoleColor HeaderBG,ConsoleColor HeaderFG,HeaderPosition HeadPos,String Title,int Length,int Height):this(Animated,Shadowed,MainBG,HeaderBG,HeaderFG,HeadPos,Title,Length,Height,-1,-1) { }

        /// <summary>
        /// Creates a window. You get basically full control of everything with this constructor.
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
        public Window(Boolean Animated,Boolean Shadowed,ConsoleColor MainBG,ConsoleColor HeaderBG,ConsoleColor HeaderFG,HeaderPosition HeadPos,String Title,int Length,int Height,int LeftPos,int TopPos) {

            this.Animated = Animated;
            this.Shadowed = Shadowed;

            this.MainBG = MainBG;
            this.HeaderBG = HeaderBG;
            this.HeaderFG = HeaderFG;
            this.HeadPos = HeadPos;

            this.Title = Title;
            this.Length = Length;
            this.Height = Height;

            if(LeftPos == -1) { this.LeftPos = ((Console.WindowWidth) - Length) / 2; } else { this.LeftPos = LeftPos; }
            if(TopPos == -1) { this.TopPos = ((Console.WindowHeight) - Height) / 2; } else { this.TopPos = TopPos; }

            AllElements = new List<WindowElement>();
        }

        /// <summary>Adds an Element to the Window</summary>
        /// <param name="NewElement"></param>
        public void AddElement(WindowElement NewElement ) {AllElements.Add(NewElement);}

        /// <summary>Adds a range of elements to the window</summary>
        /// <param name="NewElements"></param>
        public void AddElements(IEnumerable<WindowElement> NewElements) { AllElements.AddRange(NewElements); }

        /// <summary>Launches this window</summary>
        public virtual void Execute() {
            DrawWindow(Animated);

            //OnKeyPress returns true if we should continue execution.
            while(OnKeyPress(Console.ReadKey(true))) { }
        }

        /// <summary>Draws the window</summary>
        /// <param name="Animated"></param>
        protected virtual void DrawWindow(Boolean Animated) {

            //Render the shadow
            if(Shadowed) { Draw.Box(ConsoleColor.Black,Length,Height - 1,LeftPos + 2,TopPos + 2); }

            //Do the animation
            if(Animated) {

                //Now we use scale because que lindo.
                for(Double Scale = 0; Scale < 1; Scale+=.05) {
                    int SmallLength = Convert.ToInt32(Math.Max(Length * Scale,1));
                    int SmallHeight = Convert.ToInt32(Math.Max(Height * Scale,1));
                    Draw.Box(MainBG,SmallLength,SmallHeight,LeftPos,TopPos);
                }
            }

            //draw the main box
            Draw.Box(MainBG,Length,Height,LeftPos,TopPos);

            //draw the header
            Draw.Row(HeaderBG,Length,LeftPos,TopPos);

            RenderUtils.SetPos(LeftPos,TopPos);

            RenderUtils.Color(HeaderBG,HeaderFG);

            //Draw the header text.
            switch(HeadPos) {
                case HeaderPosition.LEFT:
                    RenderUtils.Echo("═ " + Title + " ");
                    for(int i = 3 + Title.Length; i < Length; i++) { RenderUtils.Echo("═"); }
                    break;
                case HeaderPosition.CENTER:
                    //calculate lengths of the two side bars.
                    int SidesLength = (Length - (Title.Length + 2)) / 2;

                    //Do the first side
                    for(int i = 0; i < SidesLength; i++) { RenderUtils.Echo("="); }

                    //Echo the title
                    RenderUtils.Echo(" " + Title + " ");

                    //Do the other side
                    for(int i = 0; i < SidesLength; i++) { RenderUtils.Echo("="); }

                    break;
                case HeaderPosition.RIGHT:
                    for(int i = 0; i < Length - 3 + Title.Length; i++) { RenderUtils.Echo("═"); }
                    RenderUtils.Echo(" " + Title + " =");
                    break;
                default:
                    break;
            }

            //Draw the footer
            RenderUtils.Color(MainBG,HeaderFG);
            RenderUtils.SetPos(LeftPos,TopPos + Height - 1);
            for(int i = 0; i < Length; i++) { RenderUtils.Echo("═"); }

            //Draw each subelement.
            foreach(WindowElement element in AllElements) { element.DrawElement(); }
        }

        /// <summary>Triggered when a key is pressed, and handles what to do with it.</summary>
        /// <param name="PressedKey"></param>
        /// <returns>Returns True if the window should remain open, otherwise false.</returns>
        protected virtual bool OnKeyPress(ConsoleKeyInfo PressedKey) {

            if(PressedKey.Modifiers == ConsoleModifiers.Control && PressedKey.Key == ConsoleKey.W) { Close(); return false; }
            switch(HighlightedElement.OnKeyPress(PressedKey)) {
                case KeyPressReturn.NOTHING:
                    break;
                case KeyPressReturn.NEXT_ELEMENT:
                    if(HighlightedElement.NextElement != null) {
                        HighlightedElement.Highlighted= false;
                        HighlightedElement = HighlightedElement.NextElement;
                        HighlightedElement.Highlighted=true;
                    }
                    break;
                case KeyPressReturn.PREV_ELEMENT:
                    if(HighlightedElement.PreviousElement != null) {
                        HighlightedElement.Highlighted=false;
                        HighlightedElement = HighlightedElement.PreviousElement;
                        HighlightedElement.Highlighted= true;
                    }
                    break;
                case KeyPressReturn.CLOSE:
                    Close(); return false;
                default:
                    break;
            }
            return true;

        }

        /// <summary>Redraws the window without animations</summary>
        public virtual void Redraw() { DrawWindow(false); }

        /// <summary>Closes the window</summary>
        public virtual void Close() {
            //Do the animation
            if(Animated) {
                for(Double Scale = 0; Scale < 1; Scale += .05) {
                    int SmallLength = Convert.ToInt32(Math.Max(Length * Scale,1));
                    int SmallHeight = Convert.ToInt32(Math.Max(Height * Scale,1));
                    Draw.Box(WindowClearColor,SmallLength,SmallHeight,LeftPos,TopPos);
                }
            }

            //Delete the mainbox.
            Draw.Box(WindowClearColor,Length,Height,LeftPos,TopPos);

            //if shadowed, delete the main shadow
            if(Shadowed) { Draw.Box(WindowClearColor,Length,Height - 1,LeftPos + 2,TopPos + 2); }

        }
    }

}
