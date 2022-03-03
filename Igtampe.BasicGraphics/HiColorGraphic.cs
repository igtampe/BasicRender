using System;
using System.IO;
using Igtampe.BasicRender;

namespace Igtampe.BasicGraphics {

    /// <summary>Holds a HiColorGraphic</summary>
    public class HiColorGraphic : Graphic {

        /// <summary>Creates a basicGraphic with specified contents and name</summary>
        /// <param name="Contents"></param>
        /// <param name="Name"></param>
        public HiColorGraphic(string[] Contents, string Name) : base(Contents, Name) { }

        /// <summary>Draws this hicolor graphic at the specified position.</summary>
        /// <param name="LeftPos"></param>
        /// <param name="TopPos"></param>
        public override void Draw(int LeftPos, int TopPos) {
            foreach (string Line in Contents) {

                if (!string.IsNullOrEmpty(Line)) { HiColorDraw(Line, LeftPos, TopPos); }
                TopPos++;

            }
        }

        /// <summary>Gets the width of the graphic</summary>
        /// <returns>Length of the first line</returns>
        public override int GetWidth() => Contents == null || Contents[0] == null ? 0 : Contents[0].Split('-').Length;

        /// <summary>
        /// Draws a HiColorString, an example of which is '0F0-0F1-0F2', where the first character is ColorChar 1, second character is ColorChar 2, and the third character determines the gradient between the two colors
        /// </summary>
        /// <param name="HiColorString"></param>
        public static void HiColorDraw(string HiColorString) => HiColorDraw(HiColorString, Console.CursorLeft, Console.CursorTop);

        /// <summary>
        /// Draws a HiColorString at position LeftPos, TopPos, an example of which is '0F0-0F1-0F2', where the first character is ColorChar 1, second character is ColorChar 2, and the third character determines the gradient between the two colors
        /// </summary>
        /// <param name="HiColorString"></param>
        /// <param name="leftpos">LeftPosition of this HiColorString</param>
        /// <param name="toppos">TopPosition of this HiColorString</param>
        public static void HiColorDraw(string HiColorString, int leftpos, int toppos) {

            //An example would be 0F1-0F2-1F3
            string[] HiColorRow = HiColorString.Split('-');

            foreach (string HiColorBlock in HiColorRow) {
                if (string.IsNullOrWhiteSpace(HiColorBlock) || HiColorBlock.Length < 3) { BasicRender.Draw.Block(Console.BackgroundColor); } else {
                    ConsoleColor BG = ConsoleColor.Black;
                    ConsoleColor FG = ConsoleColor.White;

                    try {
                        BG = GraphicUtils.ColorCharToConsoleColor(HiColorBlock[0]);
                        FG = GraphicUtils.ColorCharToConsoleColor(HiColorBlock[1]);
                    } catch (ArgumentException) { }

                    switch (HiColorBlock[2]) {
                        case '0':
                            BasicRender.Draw.Sprite("░", BG, FG, leftpos, toppos);
                            break;
                        case '1':
                            BasicRender.Draw.Sprite("▒", BG, FG, leftpos, toppos);
                            break;
                        case '2':
                            BasicRender.Draw.Sprite("▓", BG, FG, leftpos, toppos);
                            break;
                        default:
                            BasicRender.Draw.Block(Console.BackgroundColor, leftpos, toppos);
                            break;
                    }
                }
                leftpos++;

            }
        }

        /// <summary>Generates a HiColorGraphic item from a file. Supersedes HiColorGraphicFromFile.</summary>
        public static HiColorGraphic LoadFromFile(string Filename) => !File.Exists(Filename)
            ? throw new FileNotFoundException()
            : new HiColorGraphic(File.ReadAllLines(Filename), Filename);

        /// <summary>Generates a HiColorGraphic item from a Resource. Supersedes HiColorGraphicFromResource.</summary>
        public static HiColorGraphic LoadFromResource(byte[] Resource) => new HiColorGraphic(GraphicUtils.ResourceToStringArray(Resource), "Graphic From Resource");
    }
}
