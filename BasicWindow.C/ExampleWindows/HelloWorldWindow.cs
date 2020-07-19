using System;
using Igtampe.BasicWindows.WindowElements;

namespace Igtampe.BasicWindows.ExampleWindows {
    public class HelloWorldWindow:Window {
        public HelloWorldWindow() : base(true,true,ConsoleColor.Gray,ConsoleColor.DarkBlue,ConsoleColor.White,HeaderPosition.CENTER,"Hello World!",20,6,-1,-1) {

            AllElements.Add(new Icon(this,Icon.IconType.INFORMATION,1,2));
            AllElements.Add(new Label(this,"Hello World!",ConsoleColor.Gray,ConsoleColor.Black,6,2));

            Button OKButton = new CloseButton(this,"[    OK    ]",ConsoleColor.DarkGray,ConsoleColor.White,ConsoleColor.DarkBlue,6,4);
            AllElements.Add(OKButton);

            HighlightedElement = OKButton;
            OKButton.SetHighlighted(true);

        }

    }
}
