using System;
using Igtampe.BasicGraphics;
using Igtampe.BasicRender;
using Igtampe.BasicRenderShowcase.Properties;
using Igtampe.BasicWindows;
using Igtampe.BasicWindows.TickableWindowElements;
using Igtampe.BasicWindows.WindowElements;
using Igtampe.BasicWindows.Windows;
using Igtampe.BasicFonts;

namespace Igtampe.BasicRenderShowcase {
    class Program {
        static void Main() {

            Console.SetWindowSize(80,25);
            Console.SetBufferSize(80,25);

            //Draw the splash
            BasicRenderSplash();
            RenderUtils.Sleep(2000);


            Window WelcomeSplash = new Window(false,true,"Welcome",47,10);
            CloseButton SplashWelcomeBTN = new CloseButton(WelcomeSplash,"[   OK   ]",ConsoleColor.DarkGray,ConsoleColor.White,ConsoleColor.DarkBlue,19,8);

            WindowElement[] SplashElements = {
                new BasicFontLabel(WelcomeSplash,"WELCOME",BasicFont.DefaultFont,ConsoleColor.Black,3,1),
                SplashWelcomeBTN
            };

            WelcomeSplash.AddElements(SplashElements);

            WelcomeSplash.HighlightedElement = SplashWelcomeBTN;
            SplashWelcomeBTN.Highlighted = true;
            WelcomeSplash.Execute();

            //5x6

            //Clear the screen, set up for the "window Environment"
            RenderUtils.Color(ConsoleColor.DarkCyan,ConsoleColor.White);
            Console.Clear();

            //Time to test the tickable timer window and a new label.
            TickableWindow LoadWindow = new TickableWindow(true,true,"Please Wait",42,7);

            WindowElement[] Elements = {
                new Icon(LoadWindow,Icon.IconType.INFORMATION,1,2),
                new Label(LoadWindow,"Please Wait, BasicRender is loading",ConsoleColor.Gray,ConsoleColor.Black,5,2),
                new Spinner(LoadWindow,ConsoleColor.Gray,ConsoleColor.Black,5,4),
                new Timer(LoadWindow,5,new Progressbar(LoadWindow,33,7,4)){BackToFront=true}
            };

            LoadWindow.AddElements(Elements);

            //Test Tickable Window
            LoadWindow.Execute();

            //Test DialogBox
            DialogBox.ShowDialogBox(Icon.IconType.INFORMATION,DialogBox.DialogBoxButtons.OK,"Test I hope this works.");

            //More Extensively test Dialogbox
            Quiz();

            //Test HelloWorld
            //new HelloWorldWindow().Execute(); //We no longer really need to test HelloWorld. Windows are just windows now

            //Show the welcome window
            new WelcomeWindow().Execute();

            //
            DialogBox.ShowDialogBox(Icon.IconType.INFORMATION,DialogBox.DialogBoxButtons.OK,"The system will now attempt to divide by 0 to showcase error screens.");
            try { GenerateStackedError(7); } catch(Exception E) {
                ErrorWindow.ShowErrorWindow(E.Message);
                DialogBox.ShowExceptionError(E);
                GuruMeditationErrorScreen.Show(E,true);
            }

        }

        /// <summary>Generates a stacked error by dividing by zero after calling itself LENGTH times</summary>
        /// <param name="Length"></param>
        static void GenerateStackedError(int Length) {if(Length > 0) { GenerateStackedError(Length - 1); } else { decimal _ = 1 / Length; }}

        /// <summary>Shows the BasicRender SplashScreen (which also shows the logo)</summary>
        static void BasicRenderSplash() {
            RenderUtils.Color(ConsoleColor.DarkGray,ConsoleColor.White);
            Console.Clear();

            Graphic Rainbow = new HiColorGraphicFromResource(Resources.Rainbow);

            Draw.Box(ConsoleColor.Black,Rainbow.GetWidth(),Rainbow.GetHeight() - 1,19,11);

            Rainbow.Draw(17,10);
            Draw.CenterText("BasicRender",12,ConsoleColor.White,ConsoleColor.Black);

        }

        /// <summary>Tests DialogBoxes by running a quiz. Is this America?</summary>
        static void Quiz() {
            if(DialogBox.ShowDialogBox(Icon.IconType.QUESTION,DialogBox.DialogBoxButtons.YesNo,"Is this America?") == DialogBox.DialogBoxResult.Yes) {
                if(DialogBox.ShowDialogBox(Icon.IconType.EXCLAMATION,DialogBox.DialogBoxButtons.OKCancel,"This is America")==DialogBox.DialogBoxResult.Cancel) {
                    Quiz();
                    return;
                }
            } else {

                switch(DialogBox.ShowDialogBox(Icon.IconType.QUESTION,DialogBox.DialogBoxButtons.YesNoCancel,"Are you absolutely sure?")) {
                    case DialogBox.DialogBoxResult.Yes:
                        if(DialogBox.ShowDialogBox(Icon.IconType.ERROR,DialogBox.DialogBoxButtons.AbortRetryIgnore,"Incorrect. According to the Childish Gambino song:\n\nThis is America (woo, ayy) Don't catch you slippin' now(woo,woo,don't catch you slippin',now) Don't catch you slippin' now(ayy,woah) Look what I'm whippin' now(Slime!) This is America(yeah, yeah) Don't catch you slippin' now(woah,ayy) Don't catch you slippin' now(ayy,woo) Look what I'm whippin' now(ayy) Look how I'm geekin' out (hey)I'm so fitted (I'm so fitted,woo)I'm on Gucci (I'm on Gucci)I'm so pretty (yeah, yeah)I'm gon' get it(ayy,I'm gon' get it)Watch me move(blaow)This a celly(ha)That's a tool (yeah)On my Kodak(woo,Black)Ooh, know that(yeah,know that,hold on)Get it(get it,get it)Ooh, work it(21)Hunnid bands, hunnid bands, hunnid bands(hunnid bands)Contraband, contraband, contraband(contraband)I got the plug on Oaxaca(woah)They gonna find you like blocka(blaow)'")==DialogBox.DialogBoxResult.Retry) {
                            Quiz();
                            return;
                        };
                        break;
                    case DialogBox.DialogBoxResult.No:
                        if(DialogBox.ShowDialogBox(Icon.IconType.EXCLAMATION,DialogBox.DialogBoxButtons.OKCancel,"This is America") == DialogBox.DialogBoxResult.Cancel) {
                            Quiz();
                            return;
                        }
                        break;
                    case DialogBox.DialogBoxResult.Nothing:
                    case DialogBox.DialogBoxResult.OK:
                    case DialogBox.DialogBoxResult.Cancel:
                    case DialogBox.DialogBoxResult.Abort:
                    case DialogBox.DialogBoxResult.Retry:
                    case DialogBox.DialogBoxResult.Ignore:
                    default:
                        break;
                }
            }


        }
    }


}