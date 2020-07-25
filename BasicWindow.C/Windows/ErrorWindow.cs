using Igtampe.BasicWindows.WindowElements;
using System;
using System.Collections.Generic;

namespace Igtampe.BasicWindows.Windows {

    /// <summary>Window that displays an error, and closes when the user hits enter on the OK Button</summary>
    public class ErrorWindow:Window {

        /// <summary>
        /// Creates an Error Window that displays the specified text. <br></br><br></br>
        /// 
        /// <b>NOTE!</b><br></br>
        /// ErrorWindow will only display the first three lines of text that it can fit.
        /// 
        /// </summary>
        /// <param name="Text"></param>
        public ErrorWindow(string Text):base(false,true,ConsoleColor.Gray,ConsoleColor.Red,ConsoleColor.White,"Error",46,8) {

            //First lets add each element.
            AllElements.Add(new Icon(this,Icon.IconType.ERROR,1,2));
            //now lets calculate a label

            //Split the text with spaces
            String[] Words = Text.Split(' ');
            int CurrentWord=0;
            List<String> Lines = new List<String>();
            int LongestLine = 0;

            while(CurrentWord<Words.Length && Lines.Count<3) {
                String Line = "";
                while(CurrentWord<Words.Length&&((Line.Length+Words[CurrentWord].Length) < 40)){
                    //If we have a next word, and the word's length is less than 
                    Line += Words[CurrentWord] + " ";
                    CurrentWord++;
                }

                LongestLine = Math.Max(LongestLine,Line.Length);

                //The line is as long as its going to be.
                Lines.Add(Line);
            }

            AllElements.Add(new Label(this,String.Join("\n",Lines.ToArray()),ConsoleColor.Gray,ConsoleColor.Black,5,2));

            CloseButton OK = new CloseButton(this,"[     O K     ]",ConsoleColor.DarkGray,ConsoleColor.White,ConsoleColor.DarkBlue,Length - "[     O K     ] ".Length,Height - 2);

            AllElements.Add(OK);
            HighlightedElement = OK;
            OK.Highlighted = true;
        
        }

    }
}
