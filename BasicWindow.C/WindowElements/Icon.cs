using System;
using Igtampe.BasicRender;

namespace Igtampe.BasicWindows.WindowElements {

    /// <summary>Icon element for dialogboxes (Exclamation, Error, information, or question)</summary>
    public class Icon:WindowElement {

        public enum IconType { ERROR, EXCLAMATION, INFORMATION, QUESTION }

        private readonly IconType Type;

        public Icon(Window Parent,IconType Type,int LeftPos,int TopPos) : base(Parent) {
            this.Type = Type;

            this.LeftPos = LeftPos;
            this.TopPos = TopPos;
        }

        public override void DrawElement(int WindowLeft,int WindowTop) {
            switch(Type) {
                case IconType.ERROR:
                    Draw.Box(ConsoleColor.Red,3,3,WindowLeft + LeftPos,WindowTop + TopPos);
                    Draw.Sprite("X",ConsoleColor.Red,ConsoleColor.White,WindowLeft + LeftPos + 1,WindowTop + TopPos + 1);
                    break;
                case IconType.EXCLAMATION:
                    Draw.Box(ConsoleColor.Yellow,3,3,WindowLeft + LeftPos,WindowTop + TopPos);
                    Draw.Sprite("!",ConsoleColor.Yellow,ConsoleColor.Black,WindowLeft + LeftPos + 1,WindowTop + TopPos + 1);
                    break;
                case IconType.INFORMATION:
                    Draw.Box(ConsoleColor.DarkBlue,3,3,WindowLeft + LeftPos,WindowTop + TopPos);
                    Draw.Sprite("i",ConsoleColor.DarkBlue,ConsoleColor.White,WindowLeft + LeftPos + 1,WindowTop + TopPos + 1);
                    break;
                default:
                    Draw.Box(ConsoleColor.DarkBlue,3,3,WindowLeft + LeftPos,WindowTop + TopPos);
                    Draw.Sprite("?",ConsoleColor.DarkBlue,ConsoleColor.White,WindowLeft + LeftPos + 1,WindowTop + TopPos + 1);
                    break;
            }

        }
    }
}

