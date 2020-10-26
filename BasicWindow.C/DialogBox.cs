using Igtampe.BasicWindows.Utils;
using Igtampe.BasicWindows.WindowElements;
using System;

namespace Igtampe.BasicWindows {
    /// <summary>Class that can create Dialog Boxes</summary>
    public class DialogBox {

        /// <summary>Maximum width of dialogboxes</summary>
        public static int MaxWidth { get { return Console.WindowWidth - 5; } }


        /// <summary>Maximum height of dialogboxes</summary>
        public static int MaxHeight { get { return Console.WindowHeight - 3; } }

        /// <summary>Enum that holds available button combinations for dialog boxes</summary>
        public enum DialogBoxButtons { 
            /// <summary>OK Only</summary>
            OK,
            /// <summary>OK and Cancel buttons</summary>
            OKCancel,
            /// <summary>Yes and No buttons</summary>
            YesNo,
            /// <summary>Yes, No, and Cancel buttons</summary>
            YesNoCancel,
            /// <summary>Abort Retry and Ignore buttons</summary>
            AbortRetryIgnore
        }

        /// <summary>Enum that holds available dialog box results</summary>
        public enum DialogBoxResult { 
            /// <summary>Nothing, returned when no button was pressed but the window was closed</summary>
            Nothing,
            /// <summary>OK</summary>
            OK,
            /// <summary>Cancel</summary>
            Cancel,
            /// <summary>Yes</summary>
            Yes,
            /// <summary>No</summary>
            No,
            /// <summary>Abort</summary>
            Abort,
            /// <summary>Retry</summary>
            Retry,
            /// <summary>Ignore</summary>
            Ignore

        }

        //-[All the buttons]-----------------------------------
        private readonly FlaggedCloseButton OKButton;     //[    OK    ]
        private readonly FlaggedCloseButton CancelButton; //[  CANCEL  ]
        private readonly FlaggedCloseButton YesButton;    //[   YES    ]
        private readonly FlaggedCloseButton NoButton;     //[    NO    ]
        private readonly FlaggedCloseButton AbortButton;  //[  ABORT   ]
        private readonly FlaggedCloseButton RetryButton;  //[  RETRY   ]
        private readonly FlaggedCloseButton IgnoreButton; //[  IGNORE  ]
        //Buttons have a length of 12.

        private const string OKButtonText= "[    OK    ]";
        private const string CancelButtonText = "[  CANCEL  ]";
        private const string YesButtonText = "[   YES    ]";
        private const string NoButtonText = "[    NO    ]";
        private const string AbortButtonText = "[  ABORT   ]";
        private const string RetryButtonText = "[  RETRY   ]";
        private const string IgnoreButtonText = "[  IGNORE  ]";

        //the window that we will render
        private readonly Window MainWindow;

        /// <summary>Creates a dialog box</summary>
        /// <param name="Type"></param>
        /// <param name="Text"></param>
        /// <param name="Buttons"></param>
        public DialogBox(Icon.IconType Type,DialogBoxButtons Buttons,String Text) {

            //time to set up a window

            //MaxWidth-6 because 3 for the icon, 1 for spacing between icon and left, icon and text, and text and right
            //MaxHeight-5 because 1 for header, 1 for space between header and text, 1 for space between text and button, 1 for button, and 1 for footer
            FormattedText TextButFormatted = new FormattedText(Text,MaxWidth - 6,MaxHeight - 5);

            //find the minimum width of the window given the buttons:
            //5 is the base because that's the width of the icon;
            int MinWidth = 5;
            switch(Buttons) {
                case DialogBoxButtons.OK:
                    //Single button (length of button, plus spacing with the left side of the window
                    MinWidth += 12 + 1;
                    break;
                case DialogBoxButtons.OKCancel:
                case DialogBoxButtons.YesNo:
                    //two buttons
                    //two single buttons
                    MinWidth += 13 + 13;
                    break;
                case DialogBoxButtons.YesNoCancel:
                case DialogBoxButtons.AbortRetryIgnore:
                    //Three buttons
                    //Three single buttons
                    MinWidth += 13 * 3;
                    break;
                default:
                    break;
            }

            //Get the actual width of the window.
            //Max in case the text's width or height is smaller than the minimum required to display other elements.
            int WindowWidth = Math.Max(MinWidth,TextButFormatted.ActualWidth + 6);
            int WindowHeight = Math.Max(6,TextButFormatted.ActualHeight + 5);

            //OK now lets figure out which title/icon this will have.
            String Title;
            ConsoleColor HeaderBG = ConsoleColor.DarkBlue;

            switch(Type) {
                case Icon.IconType.ERROR:
                    Title = "Error";
                    HeaderBG = ConsoleColor.DarkRed;
                    break;
                case Icon.IconType.EXCLAMATION:
                    Title = "Warning";
                    break;
                case Icon.IconType.INFORMATION:
                    Title = "Information";
                    break;
                case Icon.IconType.QUESTION:
                    Title = "Question";
                    break;
                default:
                    Title = "Uh...";
                    break;
            }

            //Now we're ready to create the window
            MainWindow = new Window(false,true,ConsoleColor.Gray,HeaderBG,ConsoleColor.White,Title,WindowWidth,WindowHeight);

            //Now let's go ahead and populate the window
            MainWindow.AddElement(new Icon(MainWindow,Type,1,2));
            MainWindow.AddElement(new Label(MainWindow,TextButFormatted,ConsoleColor.Gray,ConsoleColor.Black,5,2));

            switch(Buttons) {
                case DialogBoxButtons.OK:
                    OKButton = new FlaggedCloseButton(MainWindow,OKButtonText,ConsoleColor.DarkGray,ConsoleColor.White,ConsoleColor.DarkBlue,MainWindow.Length - 13,MainWindow.Height - 2);
                    
                    MainWindow.AddElement(OKButton);
                    
                    MainWindow.HighlightedElement = OKButton;
                    OKButton.Highlighted = true;
                    break;
                case DialogBoxButtons.OKCancel:
                    OKButton = new FlaggedCloseButton(MainWindow,OKButtonText,ConsoleColor.DarkGray,ConsoleColor.White,ConsoleColor.DarkBlue,MainWindow.Length - 26,MainWindow.Height - 2);
                    CancelButton = new FlaggedCloseButton(MainWindow,CancelButtonText,ConsoleColor.DarkGray,ConsoleColor.White,ConsoleColor.DarkBlue,MainWindow.Length - 13,MainWindow.Height - 2);

                    MainWindow.AddElement(OKButton);
                    MainWindow.AddElement(CancelButton);

                    OKButton.NextElement = CancelButton;
                    CancelButton.PreviousElement = OKButton;

                    MainWindow.HighlightedElement = OKButton;
                    OKButton.Highlighted = true;
                    break;
                case DialogBoxButtons.YesNo:
                    YesButton = new FlaggedCloseButton(MainWindow,YesButtonText,ConsoleColor.DarkGray,ConsoleColor.White,ConsoleColor.DarkBlue,MainWindow.Length - 26,MainWindow.Height - 2);
                    NoButton = new FlaggedCloseButton(MainWindow,NoButtonText,ConsoleColor.DarkGray,ConsoleColor.White,ConsoleColor.DarkBlue,MainWindow.Length - 13,MainWindow.Height - 2);

                    MainWindow.AddElement(YesButton);
                    MainWindow.AddElement(NoButton);

                    YesButton.NextElement = NoButton;
                    NoButton.PreviousElement = YesButton; 

                    MainWindow.HighlightedElement = YesButton;
                    YesButton.Highlighted = true;

                    break;
                case DialogBoxButtons.YesNoCancel:
                    YesButton = new FlaggedCloseButton(MainWindow,YesButtonText,ConsoleColor.DarkGray,ConsoleColor.White,ConsoleColor.DarkBlue,MainWindow.Length - 39,MainWindow.Height - 2);
                    NoButton = new FlaggedCloseButton(MainWindow,NoButtonText,ConsoleColor.DarkGray,ConsoleColor.White,ConsoleColor.DarkBlue,MainWindow.Length - 26,MainWindow.Height - 2);
                    CancelButton = new FlaggedCloseButton(MainWindow,CancelButtonText,ConsoleColor.DarkGray,ConsoleColor.White,ConsoleColor.DarkBlue,MainWindow.Length - 13,MainWindow.Height - 2);

                    MainWindow.AddElement(YesButton);
                    MainWindow.AddElement(NoButton);
                    MainWindow.AddElement(CancelButton);

                    YesButton.NextElement = NoButton;
                    NoButton.PreviousElement = YesButton;
                    NoButton.NextElement = CancelButton;
                    CancelButton.PreviousElement = NoButton;

                    MainWindow.HighlightedElement = YesButton;
                    YesButton.Highlighted = true;

                    break;
                case DialogBoxButtons.AbortRetryIgnore:
                    AbortButton = new FlaggedCloseButton(MainWindow,AbortButtonText,ConsoleColor.DarkGray,ConsoleColor.White,ConsoleColor.DarkBlue,MainWindow.Length - 39,MainWindow.Height - 2);
                    RetryButton = new FlaggedCloseButton(MainWindow,RetryButtonText,ConsoleColor.DarkGray,ConsoleColor.White,ConsoleColor.DarkBlue,MainWindow.Length - 26,MainWindow.Height - 2);
                    IgnoreButton = new FlaggedCloseButton(MainWindow,IgnoreButtonText,ConsoleColor.DarkGray,ConsoleColor.White,ConsoleColor.DarkBlue,MainWindow.Length - 13,MainWindow.Height - 2);

                    MainWindow.AddElement(AbortButton);
                    MainWindow.AddElement(RetryButton);
                    MainWindow.AddElement(IgnoreButton);

                    AbortButton.NextElement = RetryButton;
                    RetryButton.PreviousElement = AbortButton;
                    RetryButton.NextElement = IgnoreButton;
                    IgnoreButton.PreviousElement = RetryButton;

                    MainWindow.HighlightedElement = AbortButton;
                    AbortButton.Highlighted = true;

                    break;
                default:
                    break;
            }

        }

        /// <summary>Executes the dialogbox</summary>
        /// <returns>Returns a DialogBoxResult based on whichever button was pressed.</returns>
        public DialogBoxResult Execute() {
            MainWindow.Execute();

            //Time for a nasty else-if. But you know what? it's ok.
            if(OKButton?.Flag == true) { return DialogBoxResult.OK; } 
            else if(CancelButton?.Flag == true) { return DialogBoxResult.Cancel; } 
            else if(YesButton?.Flag == true) { return DialogBoxResult.Yes; }
            else if(NoButton?.Flag == true) { return DialogBoxResult.No; }
            else if(AbortButton?.Flag == true) { return DialogBoxResult.Abort; }
            else if(RetryButton?.Flag == true) { return DialogBoxResult.Retry; }
            else if(IgnoreButton?.Flag == true) { return DialogBoxResult.Ignore; }
            else { return DialogBoxResult.Nothing; }

        }

        /// <summary>Shows a dialog box by first creating it, executing it, then disposing of it.</summary>
        /// <param name="Type"></param>
        /// <param name="Buttons"></param>
        /// <param name="Text"></param>
        /// <returns>Returns a DialogBoxResult based on whichever button was pressed.</returns>
        public static DialogBoxResult ShowDialogBox(Icon.IconType Type,DialogBoxButtons Buttons,String Text) {return new DialogBox(Type,Buttons,Text).Execute();}

        /// <summary>Shows an error dialog box by using the data in the provided exception.</summary>
        /// <param name="E"></param>
        /// <returns></returns>
        public static DialogBoxResult ShowExceptionError(Exception E) {return new DialogBox(Icon.IconType.ERROR,DialogBoxButtons.OK,"An unhandled exception has occurred: " + E.Message + "\n\n" + StrippedStackTrace(E)).Execute();}

        /// <summary>Strips the stacktrace of an exception of long paths to classes and files.</summary>
        /// <param name="E"></param>
        /// <returns></returns>
        public static String StrippedStackTrace(Exception E) {

            String StackTrace = E.StackTrace.Replace("   at","at");

            //Split text into words
            String[] Words = StackTrace.Replace("\n"," \n ").Split(' ');

            for(int i = 0; i < Words.Length; i++) {
                if(Words[i].Contains("\\")) {
                    Words[i] = Words[i].Split('\\')[Words[i].Split('\\').Length - 1];
                } //only the file name, not the path
                else if(Words[i].Contains(".")) {
                    Words[i] = Words[i].Split('.')[Words[i].Split('.').Length - 1];
                } //Only the method name, not the path
            }

            return String.Join(" ",Words);

        }

    }
}
