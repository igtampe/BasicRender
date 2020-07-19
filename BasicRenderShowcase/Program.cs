using System;
using Igtampe.BasicRender;
using Igtampe.BasicGraphics;
using Igtampe.BasicWindows;
using Igtampe.BasicGraphics.ExampleGraphics;
using Igtampe.BasicRenderShowcase.Properties;
using Igtampe.BasicWindows.ExampleWindows;

namespace Igtampe.BasicRenderShowcase {
    class Program {
        static void Main(string[] args) {
            RenderUtils.Echo("Hello");
            RenderUtils.Pause();

            Console.Clear();

            new Cloud().draw(2,2);
            RenderUtils.Pause();

            Console.Clear();

            Graphic LPLogo = new BasicGraphicFromResource(Resources.LandingPadLogo);
            LPLogo.draw(1,1);
            RenderUtils.Pause();

            RenderUtils.Color(ConsoleColor.DarkCyan,ConsoleColor.White);
            Console.Clear();

            HelloWorldWindow Hello = new HelloWorldWindow();
            Hello.Execute();


        }
    }
}
