using System;
using Igtampe.BasicRender;

namespace Igtampe.BasicRenderShowcase {
    class Program {
        static void Main(string[] args) {

            RenderUtils.Color(ConsoleColor.DarkCyan,ConsoleColor.White);
            Console.Clear();

            WelcomeWindow Hello = new WelcomeWindow();
            Hello.Execute();


        }
    }


}