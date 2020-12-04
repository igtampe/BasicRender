using System;
using System.Threading;

namespace Igtampe.BasicRender {

    /// <summary>Utilities that BasicRender provides and uses</summary>
    public static class RenderUtils {

        /// <summary>Halt execution of the program for the specified number of miliseconds</summary>
        /// <param name="Time"></param>
        public static void Sleep(int Time) { Thread.Sleep(Time); }

        /// <summary>Halt execution of the program until the user presses a key to continue</summary>
        public static void Pause() { Console.ReadKey(true); }

        /// <summary>displays text at the currentline, without a linebreak. <br></br>WILL LINEBREAK IF ONLY '.' IS SPECIFIED</summary>
        /// <param name="text"></param>
        public static void Echo(String text) { Echo(text,false); }

        /// <summary>displays text at the currentline, possibly with a linebreak if specified. <br></br>WILL LINEBREAK IF ONLY '.' IS SPECIFIED</summary>
        /// <param name="text"></param>
        /// <param name="Linebreak"></param>
        public static void Echo(String text,Boolean Linebreak) {
            if(text == ".") { Echo("",true); return; }
            if(Linebreak) { Console.WriteLine(text); } else { Console.Write(text); }
        }

        /// <summary>Sets the cursor position to the specified one</summary>
        /// <param name="LeftPos"></param>
        /// <param name="TopPos"></param>
        public static void SetPos(int LeftPos,int TopPos) { Console.SetCursorPosition(LeftPos,TopPos); }

        /// <summary>Sets the foreground color of the console</summary>
        /// <param name="FG"></param>
        public static void Color(ConsoleColor FG) { Console.ForegroundColor = FG; }

        /// <summary>sets the background color of the console</summary>
        /// <param name="BG"></param>
        /// <param name="FG"></param>
        public static void Color(ConsoleColor BG,ConsoleColor FG) { Console.BackgroundColor = BG; Console.ForegroundColor = FG; }

        /// <summary>Resizes the console window and buffer together.</summary>
        /// <param name="Width">Width in Columns</param>
        /// <param name="Height">Height in </param>
        public static void ResizeConsole(int Width,int Height) {
            //Determine if the width needs to be bigger or smaller
            if(Width > Console.WindowWidth) {
                //If you need to grow the window, set the buffer first, then the window
                Console.SetBufferSize(Width,Console.BufferHeight);
                Console.SetWindowSize(Width,Console.WindowHeight);
            } else {
                //If we need to shrink the window, set the window size first, then the buffer
                Console.SetWindowSize(Width,Console.WindowHeight);
                Console.SetBufferSize(Width,Console.BufferHeight);
            }

            //Determine if the height needs to be bigger or smaller
            if(Height > Console.WindowHeight) {
                //If you need to grow the window, set the buffer first, then the window
                Console.SetBufferSize(Width,Height);
                Console.SetWindowSize(Width,Height);
            } else {
                //If we need to shrink the window, set the window size first, then the buffer
                Console.SetWindowSize(Width,Height);
                Console.SetBufferSize(Width,Height);
            }
        }

        /// <summary>Types the specified text one character at a time at the default delay of 5ms between each character.</summary>
        /// <param name="Text"></param>
        public static void Type(String Text) { Type(Text,5); }

        /// <summary>Types the specified text one character at a time, with the speciifed delay in miliseconds between each character.</summary>
        /// <param name="Text"></param>
        /// <param name="Delay"></param>
        public static void Type(String Text, int Delay) {
            foreach(char Character in Text) {
                Console.Write(Character);
                Sleep(Delay);
            }
        }

    }
}
