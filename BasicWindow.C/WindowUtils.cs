using System;
using System.Collections.Generic;

namespace Igtampe.BasicWindows.Windows {
    /// <summary>Utilities for rendering windows</summary>
    public static class WindowUtils {

        /// <summary>Returns a string formatted to fit in a box of with maximum dimensions of specified width/height</summary>
        /// <param name="Text"></param>
        /// <param name="MaxWidth"></param>
        /// <param name="MaxHeight"></param>
        /// <returns></returns>
        public static String TextFormat(String Text, int MaxWidth, int MaxHeight) {
        
            //Split the text with spaces
            String[] Words = Text.Split(' ');
            int CurrentWord = 0;
            List<String> Lines = new List<String>();

            while(CurrentWord < Words.Length && Lines.Count < MaxHeight) {
                String Line = "";
                while(CurrentWord < Words.Length && ((Line.Length + Words[CurrentWord].Length) < MaxWidth)) {
                    //If we have a next word, and the word's length plus whatever we already have is shorter than the maximum width, add it to the line
                    Line += Words[CurrentWord] + " ";
                    CurrentWord++;
                }

                //The line is as long as its going to be.
                Lines.Add(Line);
            }

            return String.Join("\n",Lines.ToArray());

        }
    }
}
