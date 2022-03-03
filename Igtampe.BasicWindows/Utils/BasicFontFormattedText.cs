using System;
using Igtampe.BasicFonts;
using System.Collections.Generic;

namespace Igtampe.BasicWindows.Utils {
    /// <summary>Utilities for rendering windows</summary>
    public class BasicFontFormattedText {

        /// <summary>The text, but formatted</summary>
        public string Text { get; }

        /// <summary>The actual width of this text</summary>
        public int ActualWidth { get; }

        /// <summary>The actual height of this text</summary>
        public int ActualHeight { get; }

        /// <summary>Creates an object to hold the text, but formatted to the given maximum width and maximum height (Based on the provided BasicFont)</summary>
        /// <param name="Text"></param>
        /// <param name="MaxWidth"></param>
        /// <param name="MaxHeight"></param>
        /// <param name="Font"></param>
        public BasicFontFormattedText(string Text, BasicFont Font, int MaxWidth, int MaxHeight) {

            //this is so we can handle \n
            Text = Text.Replace("\n", " \n ");

            //Split text into words
            string[] Words = Text.Split(' ');

            //Some variables we will need
            int CurrentWord = 0;
            List<string> Lines = new List<string>();
            int LongestLine = 0;

            while (CurrentWord < Words.Length && (Lines.Count * Font.Height) < MaxHeight) {
                string Line = "";
                if (Words[CurrentWord].Length * Font.Width > MaxWidth) { Words[CurrentWord] = Words[CurrentWord].Substring(0, MaxWidth - 1); }
                while (CurrentWord < Words.Length && (((Line.Length + Words[CurrentWord].Replace("\n", "").Length) * Font.Width) < MaxWidth)) {
                    //If we have a next word, and the word's length plus whatever we already have is shorter than the maximum width, add it to the line
                    if (Words[CurrentWord] == "\n") {
                        CurrentWord++;
                        break;
                    }
                    Line += Words[CurrentWord] + " ";
                    CurrentWord++;
                }

                //The line is as long as its going to be.
                Lines.Add(Line);
                LongestLine = Math.Max(LongestLine, Line.Length);

            }

            this.Text = string.Join("\n", Lines.ToArray());
            ActualHeight = Lines.Count;
            ActualWidth = LongestLine;
        }

        /// <summary>Returns a string formatted to fit in a box of with maximum dimensions of specified width/height</summary>
        /// <param name="Text"></param>
        /// <param name="MaxWidth"></param>
        /// <param name="MaxHeight"></param>
        /// <param name="Font"></param>
        /// <returns></returns>
        public static string Format(string Text, BasicFont Font, int MaxWidth, int MaxHeight) => new BasicFontFormattedText(Text, Font, MaxWidth, MaxHeight).Text;
    }
}
