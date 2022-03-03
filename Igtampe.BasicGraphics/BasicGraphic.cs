using System;
using System.IO;
using Igtampe.BasicRender;

namespace Igtampe.BasicGraphics {
    /// <summary>Holds a BasicGraphic</summary>
    public class BasicGraphic : Graphic {

        /// <summary>Creates a basicGraphic with specified contents and name</summary>
        /// <param name="Contents"></param>
        /// <param name="Name"></param>
        public BasicGraphic(string[] Contents, string Name) : base(Contents, Name) { }

        /// <summary>Draws this BasicGraphic</summary>
        /// <param name="LeftPos"></param>
        /// <param name="TopPos"></param>
        public override void Draw(int LeftPos, int TopPos) {
            foreach (string Line in Contents) {

                //Ok for this we're going to need to rework this just a tad.
                //We're going to use Draw.Block's ability to take in a leftpos and toppos parameter to overscan the heck out of this.

                if (!string.IsNullOrEmpty(Line)) {
                    DrawColorString(Line, LeftPos, TopPos);
                    TopPos++;
                }
            }
        }

        /// <summary>Draws a ColorString comprised of ColorChars at the current cursor position<br></br><br></br>
        /// For example, the colorstring '0123456789ABCDEF' will render all available colors.
        /// </summary>
        /// <param name="ColorString"></param>
        public static void DrawColorString(string ColorString) => DrawColorString(ColorString, Console.CursorLeft, Console.CursorTop);

        /// <summary>Draws the colorstring comprised of ColorChars provided at the specified Left and Top pos</summary>
        /// <param name="ColorString"></param>
        /// <param name="LeftPos"></param>
        /// <param name="TopPos"></param>
        public static void DrawColorString(string ColorString, int LeftPos, int TopPos) {
            foreach (char ColorChar in ColorString) {
                try {
                    BasicRender.Draw.Block(GraphicUtils.ColorCharToConsoleColor(ColorChar), LeftPos, TopPos);
                } catch (ArgumentException) {/*Only catch arg exception*/ }
                LeftPos++;
            }
        }

        /// <summary>Loads a BasicGraphic from a file. Supersedes BasicGraphicFromFile</summary>
        /// <param name="Filename"></param>
        /// <returns></returns>
        public static BasicGraphic LoadFromFile(string Filename) => !File.Exists(Filename) 
            ? throw new FileNotFoundException() 
            : new BasicGraphic(File.ReadAllLines(Filename), Filename);

        /// <summary>Loads a BasicGraphic from a Resource. Supersedes BasicGraphicFromResource</summary>
        /// <param name="Resource"></param>
        /// <returns></returns>
        public static BasicGraphic LoadFromResource(byte[] Resource) => new BasicGraphic(GraphicUtils.ResourceToStringArray(Resource), "Graphic from Resource");
    }
}
