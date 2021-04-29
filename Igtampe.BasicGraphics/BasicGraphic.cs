using System;
using System.IO;
using Igtampe.BasicRender;

namespace Igtampe.BasicGraphics {
    /// <summary>Holds a BasicGraphic</summary>
    public class BasicGraphic:Graphic {

        /// <summary>Creates a basicGraphic with specified contents and name</summary>
        /// <param name="Contents"></param>
        /// <param name="Name"></param>
        public BasicGraphic(string[] Contents,string Name) : base(Contents,Name) { }

        /// <summary>Draws this BasicGraphic</summary>
        /// <param name="LeftPos"></param>
        /// <param name="TopPos"></param>
        public override void Draw(int LeftPos,int TopPos) {
            foreach(String Line in Contents) {
                RenderUtils.SetPos(LeftPos,TopPos++);
                if(!string.IsNullOrEmpty(Line)) { DrawColorString(Line); }
            }
        }

        /// <summary>Draws a ColorString comprised of ColorChars.<br></br><br></br>
        /// For example, the colorstring '0123456789ABCDEF' will render a rainbow.
        /// </summary>
        /// <param name="ColorString"></param>
        public static void DrawColorString(string ColorString) { 
            foreach(char ColorChar in ColorString) {
                try {BasicRender.Draw.Block(GraphicUtils.ColorCharToConsoleColor(ColorChar));} catch(ArgumentException) {} //only catch argument exception.
                
            }
        }

        /// <summary>Loads a BasicGraphic from a file. Supersedes BasicGraphicFromFile</summary>
        /// <param name="Filename"></param>
        /// <returns></returns>
        public static BasicGraphic LoadFromFile(string Filename) {
             if(!File.Exists(Filename)) { throw new FileNotFoundException(); }
            return new BasicGraphic(File.ReadAllLines(Filename),Filename);
        }

        /// <summary>Loads a BasicGraphic from a Resource. Supersedes BasicGraphicFromResource</summary>
        /// <param name="Resource"></param>
        /// <returns></returns>
        public static BasicGraphic LoadFromResource(byte[] Resource) {return new BasicGraphic(GraphicUtils.ResourceToStringArray(Resource),"Graphic from Resource");}


    }



}
