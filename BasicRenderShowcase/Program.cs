using System;
using Igtampe.BasicGraphics;
using Igtampe.BasicRender;
using Igtampe.BasicRenderShowcase.Properties;
using Igtampe.BasicWindows;
using Igtampe.BasicWindows.TickableWindowElements;
using Igtampe.BasicWindows.WindowElements;
using Igtampe.BasicWindows.Windows;
using Igtampe.BasicFonts;
using Igtampe.BasicShapes;

namespace Igtampe.BasicRenderShowcase {
    public static class Program {
        static void Main() {

            ShapesDemo();
            OverscanTest();

            RenderUtils.Echo("Stand by...\n\n");
            SpecialChars.TestChars();

            RenderUtils.ResizeConsole(100,50);
            RenderUtils.ResizeConsole(50,25);
            RenderUtils.ResizeConsole(Console.LargestWindowWidth,Console.LargestWindowHeight);
            RenderUtils.ResizeConsole(30,15);
            RenderUtils.ResizeConsole(80,25);


            //Draw the splash
            BasicRenderSplash();
            RenderUtils.Sleep(2000);
            RenderUtils.Pause();

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

            Window FakeWelcomeWindow = new WelcomeWindow(-20,-3);

            FakeWelcomeWindow.Redraw();

            RenderUtils.Sleep(2000);
            DialogBox.ShowDialogBox(Icon.IconType.INFORMATION, DialogBox.DialogBoxButtons.OK, "Wait a minute, that's not right. Let's redraw that in the center.");

            FakeWelcomeWindow.Close();

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

            Graphic Rainbow = HiColorGraphic.LoadFromResource(Resources.Rainbow);

            Draw.Box(ConsoleColor.Black,Rainbow.GetWidth(),Rainbow.GetHeight() - 1,19,11);

            Rainbow.Draw(17,10);
            Draw.CenterText("BasicRender",12,ConsoleColor.White,ConsoleColor.Black);

            Draw.CenterText("P r e s s     a     k e y",20,ConsoleColor.DarkGray,ConsoleColor.White);

        }

        /// <summary>Tests DialogBoxes by running a quiz. Is this America?</summary>
        static void Quiz() {
            if(DialogBox.ShowDialogBox(Icon.IconType.QUESTION,DialogBox.DialogBoxButtons.YesNo,"Is this America?") == DialogBox.DialogBoxResult.Yes) {
                if(DialogBox.ShowDialogBox(Icon.IconType.EXCLAMATION,DialogBox.DialogBoxButtons.OKCancel,"This is America")==DialogBox.DialogBoxResult.Cancel) {
                    Quiz(); 
                }
            } else {

                switch(DialogBox.ShowDialogBox(Icon.IconType.QUESTION,DialogBox.DialogBoxButtons.YesNoCancel,"Are you absolutely sure?")) {
                    case DialogBox.DialogBoxResult.Yes:
                        if(DialogBox.ShowDialogBox(Icon.IconType.ERROR,DialogBox.DialogBoxButtons.AbortRetryIgnore,"Incorrect. According to the Childish Gambino song:\n\nThis is America (woo, ayy) Don't catch you slippin' now(woo,woo,don't catch you slippin',now) Don't catch you slippin' now(ayy,woah) Look what I'm whippin' now(Slime!) This is America(yeah, yeah) Don't catch you slippin' now(woah,ayy) Don't catch you slippin' now(ayy,woo) Look what I'm whippin' now(ayy) Look how I'm geekin' out (hey)I'm so fitted (I'm so fitted,woo)I'm on Gucci (I'm on Gucci)I'm so pretty (yeah, yeah)I'm gon' get it(ayy,I'm gon' get it)Watch me move(blaow)This a celly(ha)That's a tool (yeah)On my Kodak(woo,Black)Ooh, know that(yeah,know that,hold on)Get it(get it,get it)Ooh, work it(21)Hunnid bands, hunnid bands, hunnid bands(hunnid bands)Contraband, contraband, contraband(contraband)I got the plug on Oaxaca(woah)They gonna find you like blocka(blaow)'")==DialogBox.DialogBoxResult.Retry) {
                            Quiz();
                            return;
                        }
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

        /// <summary>Demo the shapes package</summary>
        static void ShapesDemo() {
            //Let's draw a box.

            //good lord why did we have to call a WindowElement Icon. Now we have an ambiguity with System.Drawing. 

            ConsoleColor C = ConsoleColor.Red;
            ConsoleColor W = ConsoleColor.White;
            ConsoleColor G = ConsoleColor.Green;
            ConsoleColor Y = ConsoleColor.Yellow;
            ConsoleColor B = ConsoleColor.Blue;

            System.Drawing.Rectangle R = new System.Drawing.Rectangle(4,1,30,5);
            System.Drawing.Point[] Ps = {
                new System.Drawing.Point(30,10),
                new System.Drawing.Point(30,20),
                new System.Drawing.Point(10,15)
            };

            System.Drawing.Point[] Cube1 = {
                new System.Drawing.Point(45,4),
                new System.Drawing.Point(65,4),
                new System.Drawing.Point(65,14),
                new System.Drawing.Point(45,14),
            };

            int CA = 7;

            System.Drawing.Point[] Cube2 = {
                new System.Drawing.Point(45-CA,4+CA),
                new System.Drawing.Point(65-CA,4+CA),
                new System.Drawing.Point(65-CA,14+CA),
                new System.Drawing.Point(45-CA,14+CA),
            };

            System.Drawing.Point[] Cube3 = {
                new System.Drawing.Point(65,4),
                new System.Drawing.Point(65,14),
                new System.Drawing.Point(65-CA,14+CA),
                new System.Drawing.Point(65-CA,4+CA),
            };

            System.Drawing.Point[] Cube4 = {
                new System.Drawing.Point(45,4),
                new System.Drawing.Point(65,4),
                new System.Drawing.Point(65-CA,4+CA),
                new System.Drawing.Point(45-CA,4+CA),
            };

            System.Drawing.Point[] Cube5 = {
                new System.Drawing.Point(45,4),
                new System.Drawing.Point(45,14),
                new System.Drawing.Point(45-CA,14+CA),
                new System.Drawing.Point(45-CA,4+CA),
            };

            DrawShapes.DrawLine(2,2,8,20,C);
            DrawShapes.DrawLine(20,2,2,20,W);
            DrawShapes.DrawLine(2,2,60,20,G);
            DrawShapes.DrawRectangle(R,Y);
            DrawShapes.DrawPolygon(Ps,B);
            
            //We're gonna draw two squares
            DrawShapes.DrawPolygon(Cube1,W);
            DrawShapes.DrawPolygon(Cube2,W);
            DrawShapes.DrawPolygon(Cube3,W);
            DrawShapes.DrawPolygon(Cube4,W);
            DrawShapes.DrawPolygon(Cube5,W);

            DrawShapes.FillPolygon(Cube4,ConsoleColor.Gray);
            DrawShapes.FillPolygon(Cube3,ConsoleColor.DarkGray);
            DrawShapes.FillPolygon(Cube2,ConsoleColor.White);

            DrawShapes.FillPolygon(Ps,B);

            Curve C1 = new Curve(new System.Drawing.Point(20,13),10,0,180);
            Curve C2 = new Curve(new System.Drawing.Point(20,13),10,180,360);

            DrawShapes.DrawCurve(C1,ConsoleColor.Cyan);
            DrawShapes.DrawCurve(C2,ConsoleColor.Cyan);

            //now turn it into a polygon
            Line[] CircleCurves = { C1,C2};

            Polygon Circle = new Polygon(CircleCurves);

            DrawShapes.FillPolygon(Circle,ConsoleColor.Cyan);

            Console.Clear();

            //Let's make a line:

            Line ScaleLine = new Line(5, 5, 25, 10);
            DrawShapes.DrawLine(ScaleLine, ConsoleColor.Red);

            //Let's scale it Down by 50%
            DrawShapes.DrawLine(Line.TranslateLine(Line.CenterScaleLine(ScaleLine, 0.5), 0,3), ConsoleColor.Blue);

            //Let's scale it up by 25%
            DrawShapes.DrawLine(Line.TranslateLine(Line.CenterScaleLine(ScaleLine, 1.25), 0, -2), ConsoleColor.Green);

            //Let's make Cube 1 an actual polygon so we can do some funky stuff with it.
            Polygon S = new Polygon(Cube1);

            //Let's redraw Cube 1
            DrawShapes.DrawPolygon(S, ConsoleColor.Red);

            //I don't like where it is so let's draw it to the right and slightly down.
            DrawShapes.DrawPolygon(Polygon.TranslatePolygon(S,40,5), ConsoleColor.Red);

            //And now, let's scale this thing up

            for (double scale = 0.5; scale < 2; scale+=.1) {
                Random ColorRandomizer = new Random();
                DrawShapes.DrawPolygon(Polygon.TranslatePolygon(Polygon.ScalePolygon(S, scale), 40, 5), GraphicUtils.ColorCharToConsoleColor(char.Parse(ColorRandomizer.Next(10)+"")));
            }
        }

        static void OverscanTest() {
            Draw.Block(ConsoleColor.Red, -1, -1);
            Draw.Row(ConsoleColor.Red, 200, -20, 5);
            Draw.Box(ConsoleColor.Red, 200, 200, -50, 10);
            new BasicGraphics.ExampleGraphics.Cloud().Draw(-5, -10);
            new BasicGraphics.ExampleGraphics.Cloud().Draw(75, 20);
            new BasicGraphics.ExampleGraphics.Cloud().Draw(100, -5);

            Window FakeWelcomeWindow = new WelcomeWindow(-20, -3);
            FakeWelcomeWindow.Redraw();
        }

    }


}