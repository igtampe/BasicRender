using Igtampe.BasicWindows.WindowElements;
using System;

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

            //First 
            AllElements.Add(new Icon(this,Icon.IconType.ERROR,1,2));
      
            //Add the Label
            AllElements.Add(new Label(this,WindowUtils.TextFormat(Text,40,3),ConsoleColor.Gray,ConsoleColor.Black,5,2));

            CloseButton OK = new CloseButton(this,"[     O K     ]",ConsoleColor.DarkGray,ConsoleColor.White,ConsoleColor.DarkBlue,Length - "[     O K     ] ".Length,Height - 2);

            AllElements.Add(OK);
            HighlightedElement = OK;
            OK.Highlighted = true;
        
        }

    }
}
