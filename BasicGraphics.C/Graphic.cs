using System;

namespace Igtampe.BasicGraphics
{
    /// <summary>Holder for any type of drawable graphic data</summary>
    public abstract class Graphic {

        /// <summary>Contents of this graphic</summary>
        protected String[] Contents;

        /// <summary>Name of this graphic</summary>
        public String Name { get; set; }

        /// <summary>Draws the graphic on screen</summary>
        /// <param name="LeftPos"></param>
        /// <param name="TopPos"></param>
        public abstract void Draw(int LeftPos,int TopPos);


        /// <summary>Gets the width of the graphic</summary>
        /// <returns>Length of the first line</returns>
        public virtual int GetWidth() {
            if(Contents == null) { return 0; }
            if(Contents[0] == null) { return 0; }
            return Contents[0].Length;
        }

        /// <summary>Gets the height of the graphic</summary>
        /// <returns>Length of the contents array</returns>
        public virtual int GetHeight() {
            if(Contents == null) { return 0; }
            if(Contents[0] == null) { return 0; }
            return Contents.Length;
        }

    }

}
