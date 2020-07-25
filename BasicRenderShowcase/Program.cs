using System;
using Igtampe.BasicGraphics;
using Igtampe.BasicRender;
using Igtampe.BasicRenderShowcase.Properties;
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

            new HelloWorldWindow().Execute();

            WelcomeWindow Hello = new WelcomeWindow();
            Hello.Execute();


        }
    }


}