using System;
using Igtampe.BasicRender;

namespace Igtampe.BasicGraphics {

    /// <summary>Holds a HiColorGraphic</summary>
    public abstract class HiColorGraphic:Graphic {
        public override void Draw(int LeftPos,int TopPos) {
            foreach(String Line in Contents) {
                RenderUtils.SetPos(LeftPos,TopPos++);
                if(!string.IsNullOrEmpty(Line)) { HiColorDraw(Line); }
                
            }
        }


        /// <summary>Gets the width of the graphic</summary>
        /// <returns>Length of the first line</returns>
        public override int GetWidth() {
            if(Contents == null) { return 0; }
            if(Contents[0] == null) { return 0; }
            return Contents[0].Split('-').Length ;
        }

        /// <summary>
        /// Draws a HiColorString, an example of which is '0F0-0F1-0F2', where the first character is ColorChar 1, second character is ColorChar 2, and the third character determines the gradient between the two colors
        /// </summary>
        /// <param name="HiColorString"></param>
        public static void HiColorDraw(string HiColorString) {

            //An example would be 0F1-0F2-1F3
            String[] HiColorRow = HiColorString.Split('-');

            foreach(String HiColorBlock in HiColorRow) {
                if(String.IsNullOrWhiteSpace(HiColorBlock) || HiColorBlock.Length < 3) { BasicRender.Draw.Block(Console.BackgroundColor); } else {
                    ConsoleColor BG = GraphicUtils.ColorCharToConsoleColor(HiColorBlock[0]);
                    ConsoleColor FG = GraphicUtils.ColorCharToConsoleColor(HiColorBlock[1]);

                    switch(HiColorBlock[2]) {
                        case '0':
                            BasicRender.Draw.Sprite("░",BG,FG);
                            break;
                        case '1':
                            BasicRender.Draw.Sprite("▒",BG,FG);
                            break;
                        case '2':
                            BasicRender.Draw.Sprite("▓",BG,FG);
                            break;
                        default:
                            BasicRender.Draw.Block(Console.BackgroundColor);
                            break;
                    }
                }

            }

        }

    }

}
