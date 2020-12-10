using System;
using Igtampe.BasicGraphics;
using Igtampe.BasicFonts;
using Igtampe.BasicRender;
using Igtampe.BasicWindows.Utils;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Igtampe.BasicWindows {

    /// <summary>Guru Meditation Error Screen to display an exception</summary>
    public class GuruMeditationErrorScreen {

        /// <summary>Exception we'll show</summary>
        private readonly Exception E;
        private readonly Boolean Stripped;

        /// <summary>Creates a Guru Meditation Error Screen</summary>
        /// <param name="E"></param>
        /// <param name="Stripped">Used the "STRIPPED" Exception stack trace</param>
        public GuruMeditationErrorScreen(Exception E,Boolean Stripped) {
            this.E = E;
            this.Stripped = Stripped;
        }

        /// <summary>Draws the screen</summary>
        public void Render() {

            try {

                if(Console.WindowWidth < 80 || Console.WindowHeight < 25) {
                    DialogBox.ShowDialogBox(WindowElements.Icon.IconType.EXCLAMATION,DialogBox.DialogBoxButtons.OK,"Unable to show STOP error. Window too small. Error Dialog Box to be shown instead.");
                    DialogBox.ShowExceptionError(E);
                    return;
                }

                //Minimum width is like 40x20
                //30x15 + STOP           

                RenderUtils.Color(ConsoleColor.Black,ConsoleColor.White);

                //Draw a box
                Draw.Box(ConsoleColor.Black,Console.WindowWidth,Console.WindowHeight - 4,0,2);

                //Draw the stop sign
                BasicGraphic StopSign = BasicGraphic.LoadFromResource(Properties.Resources.Stop);
                StopSign.Draw(1,3);

                //Draw STOP!
                BasicFont.DefaultFont.DrawText("STOP",StopSign.GetWidth() + 2,3,ConsoleColor.White);

                //Render Text
                Draw.Sprite("An unhandled exception has caused this program to crash.",ConsoleColor.Black,ConsoleColor.White,StopSign.GetWidth() + 2,9);
                Draw.Sprite(E.Message,ConsoleColor.Black,ConsoleColor.White,1,StopSign.GetHeight() + 3);

                //Render the Exception Stack Trace
                string StackTrace = E.StackTrace;
                if(Stripped) { StackTrace = DialogBox.StrippedStackTrace(E); }
                Draw.Sprite(FormattedText.Format(StackTrace,Console.WindowWidth - 1,Console.WindowHeight - 4 - StopSign.GetHeight() - 6).Replace("\n","\n "),ConsoleColor.Black,ConsoleColor.White,0,StopSign.GetHeight() + 5);

                //Draw writing.
                Draw.CenterText("Writing to disk",Console.WindowHeight - 4,ConsoleColor.Black,ConsoleColor.Red);

                File.AppendAllText("Errors.log","\nERROR ON [" + DateTime.Now + "] " + E.Message + ": \n\n" + E.StackTrace);


                //Draw the last bit of text
                Draw.CenterText("Press a key to attempt to continue execution, or CTRL+C to close this program",Console.WindowHeight - 4,ConsoleColor.Black,ConsoleColor.Red);

                //Pause
                RenderUtils.Pause();

                //Draw a box again to clear
                Draw.Box(ConsoleColor.Black,Console.WindowWidth,Console.WindowHeight - 4,0,2);

            } catch(Exception F) {
                DialogBox.ShowDialogBox(WindowElements.Icon.IconType.EXCLAMATION,DialogBox.DialogBoxButtons.OK,"There was an error rendering the error, the following exception is the original error");
                DialogBox.ShowExceptionError(E);
                DialogBox.ShowDialogBox(WindowElements.Icon.IconType.EXCLAMATION,DialogBox.DialogBoxButtons.OK,"The following error occurred when rendering STOP");
                DialogBox.ShowExceptionError(F);
            }

        }

        /// <summary>Shows a Guru Meditation Error Screen for the specified Exception</summary>
        /// <param name="E"></param>
        /// <param name="Stripped">Whether or not to use the "Stripped" exception stack trace.</param>
        public static void Show(Exception E, Boolean Stripped) {new GuruMeditationErrorScreen(E, Stripped).Render();}
    }

}
