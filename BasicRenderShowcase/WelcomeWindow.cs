using System;
using Igtampe.BasicWindows;
using Igtampe.BasicWindows.WindowElements;
using Igtampe.BasicRender;
using Igtampe.BasicGraphics;
using Igtampe.BasicGraphics.ExampleGraphics;
using Igtampe.BasicRenderShowcase.Properties;

namespace Igtampe.BasicRenderShowcase {
    public class WelcomeWindow:Window {

        public WelcomeWindow() : base(ConsoleColor.Gray,ConsoleColor.DarkMagenta,ConsoleColor.White,"Welcome to BasicRender!",44,10) {

            AllElements.Add(new Label(this,"Welcome to the BasicRender showcase \n " +
                                           "program! We hope you enjoy the super \n " + 
                                           "tiny story we have created to show \n " +
                                           "some of the things this class \n " + 
                                           "library can do."
                ,ConsoleColor.Gray,ConsoleColor.Black,1,2));

            Button OKButton = new CloseButton(this,"[      Close      ]",ConsoleColor.DarkGray,ConsoleColor.White,ConsoleColor.DarkBlue,Length-21,Height-2);
            AllElements.Add(OKButton);

            Button ShowcaseButton = new LaunchShowcaseButton(this,2,Height-2);
            AllElements.Add(ShowcaseButton);

            ShowcaseButton.NextElement=OKButton;
            OKButton.PreviousElement=ShowcaseButton;

            HighlightedElement = ShowcaseButton;
            ShowcaseButton.Highlighted=true;

        }

        private class LaunchShowcaseButton:Button {

            public LaunchShowcaseButton(Window Parent,int leftpos, int toppos):base(Parent,"[ Launch Showcase ]",ConsoleColor.DarkGray,ConsoleColor.White,ConsoleColor.DarkBlue,leftpos,toppos) { }

            public override KeyPressReturn Action() {
                //Launch the showcase

                RenderUtils.Color(ConsoleColor.Black,ConsoleColor.Gray);
                Console.Clear();

                RenderUtils.Echo("Hello!",true);
                RenderUtils.Sleep(3000);
                
                RenderUtils.Type("...",500);
                RenderUtils.Sleep(2000);
                
                RenderUtils.Type("Hello?\n",30);
                RenderUtils.Sleep(1000);
                
                RenderUtils.Echo("It is cloudy: \n\n",true);
                new Cloud().Draw(Console.CursorLeft,Console.CursorTop);
                RenderUtils.Sleep(3000);
                
                RenderUtils.Type("\n\nCool I didn't care\n",30);
                RenderUtils.Sleep(1000);
                
                Draw.Sprite("H o w   d a r e   y o u",ConsoleColor.Black,ConsoleColor.Red);
                RenderUtils.Sleep(5000);

                Console.Clear();
                RenderUtils.Sleep(3000);

                Graphic Landscape = new BasicGraphicFromResource(Resources.Landscape);
                
                Landscape.Draw(0,0);
                RenderUtils.Sleep(5000);

                Graphic TextBox = new HiColorGraphicFromResource(Resources.Textbox);
                TextBox.Draw(Landscape.GetWidth()-TextBox.GetWidth()-2,2);

                RenderUtils.Color(ConsoleColor.Gray,ConsoleColor.Black);
                RenderUtils.SetPos(Landscape.GetWidth() - TextBox.GetWidth() - 2 + 6,2);
                RenderUtils.Type("And so the man died.");
                RenderUtils.Sleep(3000);

                RenderUtils.SetPos(Landscape.GetWidth() - TextBox.GetWidth() - 2 + 6,3);
                RenderUtils.Type("  t h e      e n d  ",100);
                RenderUtils.Sleep(5000);

                RenderUtils.Color(ConsoleColor.DarkCyan,ConsoleColor.White);
                Console.Clear();
                Parent.Redraw();
                return KeyPressReturn.NOTHING;
            }
        }


    }
}
