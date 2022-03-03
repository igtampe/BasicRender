using System;
using System.Threading;

namespace Igtampe.BasicRender {

    /// <summary>Utilities that BasicRender provides and uses</summary>
    public static class RenderUtils {

        /// <summary>Halt execution of the program for the specified number of miliseconds</summary>
        /// <param name="Time"></param>
        public static void Sleep(int Time) => Thread.Sleep(Time);

        /// <summary>Halt execution of the program until the user presses a key to continue</summary>
        public static void Pause() => Console.ReadKey(true);

        /// <summary>displays text at the currentline, without a linebreak. <br></br>WILL LINEBREAK IF ONLY '.' IS SPECIFIED</summary>
        /// <param name="text"></param>
        public static void Echo(string text) => Echo(text, false);

        /// <summary>displays text at the currentline, possibly with a linebreak if specified. <br></br>WILL LINEBREAK IF ONLY '.' IS SPECIFIED</summary>
        /// <param name="text"></param>
        /// <param name="Linebreak"></param>
        public static void Echo(string text, bool Linebreak) {
            if (text == ".") { Echo("", true); return; }
            if (Linebreak) { Console.WriteLine(text); } else { Console.Write(text); }
        }

        /// <summary>Sets the cursor position to the specified one</summary>
        /// <param name="LeftPos"></param>
        /// <param name="TopPos"></param>
        /// <returns>Returns true if it was possible to set the position, false otherwise</returns>
        public static bool SetPos(int LeftPos, int TopPos) {
            try {
                Console.SetCursorPosition(LeftPos, TopPos);
                return true;
            } catch (ArgumentOutOfRangeException) { return false; }
        }

        /// <summary>Sets the foreground color of the console</summary>
        /// <param name="FG"></param>
        public static void Color(ConsoleColor FG) => Console.ForegroundColor = FG;

        /// <summary>sets the background color of the console</summary>
        /// <param name="BG"></param>
        /// <param name="FG"></param>
        public static void Color(ConsoleColor BG, ConsoleColor FG) { Console.BackgroundColor = BG; Console.ForegroundColor = FG; }

        /// <summary>Resizes the console window and buffer together.</summary>
        /// <param name="Width">Width in Columns</param>
        /// <param name="Height">Height in Rows</param>
        public static void ResizeConsole(int Width, int Height) {

            //We may be calling this method far too much and more than necessary, but it's two Ifs Michael,
            //How much computational power can they cost? 2ms?

            /***AdjustCursor(Width,Height);*/

            //OK instead of adjsuting the cursor during the resize here's what we're going to do:
            int OldLeft = Console.CursorLeft;
            int OldTop = Console.CursorTop;

            //Now 
            SetPos(0, 0);

            //Then: 

            //Determine if the width needs to be bigger or smaller
            if (Width > Console.WindowWidth) {
                //If you need to grow the window, set the buffer first, then the window
                Console.SetBufferSize(Width, Console.BufferHeight);
                Console.SetWindowSize(Width, Console.WindowHeight);
            } else {
                //If we need to shrink the window, set the window size first, then the buffer
                Console.SetWindowSize(Width, Console.WindowHeight);
                Console.SetBufferSize(Width, Console.BufferHeight);
            }

            //Determine if the height needs to be bigger or smaller
            if (Height > Console.WindowHeight) {
                //If you need to grow the window, set the buffer first, then the window
                Console.SetBufferSize(Width, Height);
                Console.SetWindowSize(Width, Height);
            } else {
                //If we need to shrink the window, set the window size first, then the buffer
                Console.SetWindowSize(Width, Height);
                Console.SetBufferSize(Width, Height);
            }

            //Finally:
            Console.CursorLeft = OldLeft >= Width ? Width - 1 : OldLeft;
            Console.CursorTop = OldTop >= Height ? Height - 1 : OldTop;

            //again this may be a bit much for just resizing the console under most conditions pero sabes que:
            //We have to be as compatible as possible for a graphics library like this, even if it means sacrificing some computational power per operation.

            //But even then, It's two variables, 2 setpos-es, and 2 ifs. It's not that much.

        }

        /// <summary>Tries to resize the console window and buffer</summary>
        /// <param name="Width">Width in columns</param>
        /// <param name="Height">Height in Rows</param>
        /// <returns>True if the change occurred, False otherwise</returns>
        public static bool TryResizeConsole(int Width, int Height) {
            try { ResizeConsole(Width, Height); } catch (Exception) { return false; }
            return true;
        }

        /// <summary>Alias for ResizeConsole</summary>
        /// <param name="Width"></param>
        /// <param name="Height"></param>
        public static void SetSize(int Width, int Height) => ResizeConsole(Width, Height);

        /// <summary>Alias for TryResizeConsole</summary>
        /// <param name="Width"></param>
        /// <param name="Height"></param>
        /// <returns></returns>
        public static bool TrySetSize(int Width, int Height) => TryResizeConsole(Width, Height);

        /// <summary>Types the specified text one character at a time at the default delay of 5ms between each character.</summary>
        /// <param name="Text"></param>
        public static void Type(string Text) => Type(Text, 5);

        /// <summary>Types the specified text one character at a time, with the speciifed delay in miliseconds between each character.</summary>
        /// <param name="Text"></param>
        /// <param name="Delay"></param>
        public static void Type(string Text, int Delay) {
            foreach (char Character in Text) {
                Console.Write(Character);
                Sleep(Delay);
            }
        }

        /// <summary>Repeats the specified characer for the specified amount of times.</summary>
        /// <param name="Repeat">Character to repeat</param>
        /// <param name="Amount">Times to repeat it</param>
        /// <returns>
        /// The character, repeated Amount times. IE: <br></br>
        /// Repeater('-',4) --> "----"
        /// </returns>
        [Obsolete("DO NOT USE THIS! THERE IS AN ACTUAL INBUILT STRING FUNCTION FOR THIS. WE LITERALLY EXCHANGED IT FOR THAT ONE")]
        public static string Repeater(char Repeat, int Amount) => new string(Repeat, Amount);
    }
}
