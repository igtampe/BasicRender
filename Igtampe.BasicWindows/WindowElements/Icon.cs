using System;
using Igtampe.BasicRender;

namespace Igtampe.BasicWindows.WindowElements {

    /// <summary>Icon element for dialogboxes (Exclamation, Error, information, or question)</summary>
    public class Icon:WindowElement {

        /// <summary>Type of icon</summary>
        public enum IconType { 
            /// <summary>Error icon that's a red box with an X in the center</summary>
            ERROR, 

            /// <summary>Exclamation icon that's a yellow box with a ! in the center</summary>
            EXCLAMATION, 

            /// <summary>Information icon that's a blue box with an i in the center</summary>
            INFORMATION, 

            /// <summary>Question icon that's a blue box with a ? in the center</summary>
            QUESTION }

        private readonly IconType Type;

        /// <summary>Creates an Icon window element</summary>
        /// <param name="Parent"></param>
        /// <param name="Type"></param>
        /// <param name="LeftPos"></param>
        /// <param name="TopPos"></param>
        public Icon(Window Parent,IconType Type,int LeftPos,int TopPos) : base(Parent) {
            this.Type = Type;

            this.LeftPos = LeftPos;
            this.TopPos = TopPos;
        }

        /// <summary>Draws this icon</summary>
        public override void DrawElement() {
            switch(Type) {
                case IconType.ERROR:
                    Draw.Box(ConsoleColor.Red,3,3,Parent.LeftPos + LeftPos,Parent.TopPos + TopPos);
                    Draw.Sprite("X",ConsoleColor.Red,ConsoleColor.White,Parent.LeftPos + LeftPos + 1,Parent.TopPos + TopPos + 1);
                    break;
                case IconType.EXCLAMATION:
                    Draw.Box(ConsoleColor.Yellow,3,3,Parent.LeftPos + LeftPos,Parent.TopPos + TopPos);
                    Draw.Sprite("!",ConsoleColor.Yellow,ConsoleColor.Black,Parent.LeftPos + LeftPos + 1,Parent.TopPos + TopPos + 1);
                    break;
                case IconType.INFORMATION:
                    Draw.Box(ConsoleColor.DarkBlue,3,3,Parent.LeftPos + LeftPos,Parent.TopPos + TopPos);
                    Draw.Sprite("i",ConsoleColor.DarkBlue,ConsoleColor.White,Parent.LeftPos + LeftPos + 1,Parent.TopPos + TopPos + 1);
                    break;
                default:
                    Draw.Box(ConsoleColor.DarkBlue,3,3,Parent.LeftPos + LeftPos,Parent.TopPos + TopPos);
                    Draw.Sprite("?",ConsoleColor.DarkBlue,ConsoleColor.White,Parent.LeftPos + LeftPos + 1,Parent.TopPos + TopPos + 1);
                    break;
            }

        }
    }
}

