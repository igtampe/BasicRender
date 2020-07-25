using System;
using Igtampe.BasicRender;

namespace Igtampe.BasicGraphics {
    /// <summary>Holds a BasicGraphic</summary>
    public abstract class BasicGraphic:Graphic {

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


    }



}
