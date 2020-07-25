using System;
using System.Collections.Generic;
using Igtampe.BasicGraphics;
using Igtampe.BasicRender;
using Igtampe.BasicRenderShowcase.Properties;
using Igtampe.BasicWindows;
using Igtampe.BasicWindows.TickableWindowElements;
using Igtampe.BasicWindows.WindowElements;
using Igtampe.BasicWindows.Windows;

namespace Igtampe.BasicRenderShowcase {
    class Program {
        static void Main() {

            Console.SetWindowSize(80,25);
            Console.SetBufferSize(80,25);

            RenderUtils.Color(ConsoleColor.DarkGray,ConsoleColor.White);
            Console.Clear();

            Graphic Rainbow = new HiColorGraphicFromResource(Resources.Rainbow);

            Draw.Box(ConsoleColor.Black,Rainbow.GetWidth(),Rainbow.GetHeight() - 1,19,11);

            Rainbow.Draw(17,10);
            Draw.CenterText("BasicRender",12,ConsoleColor.White,ConsoleColor.Black);
            RenderUtils.Sleep(5000);

            RenderUtils.Color(ConsoleColor.DarkCyan,ConsoleColor.White);
            Console.Clear();

            //Time to test the tickable timer window and a new label.
            TickableWindow LoadWindow = new TickableWindow(true,true,"Please Wait",42,7);

            WindowElement[] Elements = {
                new Icon(LoadWindow,Icon.IconType.INFORMATION,1,2),
                new Label(LoadWindow,"Please Wait, BasicRender is Loading",ConsoleColor.Gray,ConsoleColor.Black,5,2),
                new Timer(LoadWindow,10,new Progressbar(LoadWindow,35,5,4))
            };

            LoadWindow.AddElements(Elements);

            //LoadWindow should have a DialogBox pop up saying it's done.

            LoadWindow.Execute();

            new HelloWorldWindow().Execute();

            WelcomeWindow Hello = new WelcomeWindow();
            Hello.Execute();


        }
    }


}