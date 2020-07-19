using System;

namespace Igtampe.BasicGraphics
{
    public abstract class Graphic {
        protected String[] Contents;
        protected String Name;

        public abstract void Draw(int LeftPos,int TopPos);
        public string GetName() { return Name; }

        /// <summary>Gets the width of the graphic</summary>
        /// <returns>Length of the first line</returns>
        public int GetWidth() {
            if(Contents == null) { return 0; }
            if(Contents[0] == null) { return 0; }
            return Contents[0].Length;
        }
    }

}
