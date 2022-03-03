namespace Igtampe.BasicGraphics {
    /// <summary>Holder for any type of drawable graphic data</summary>
    public class Graphic {

        /// <summary>Contents of this graphic</summary>
        protected string[] Contents;

        /// <summary>Name of this graphic</summary>
        public string Name { get; set; }

        /// <summary>Creates a graphic with specified contents and name</summary>
        public Graphic(string[] Contents, string Name) {
            this.Contents = Contents;
            this.Name = Name;
        }

        /// <summary>Draws the graphic on screen</summary>
        /// <param name="LeftPos"></param>
        /// <param name="TopPos"></param>
        public virtual void Draw(int LeftPos, int TopPos) => throw new System.NotImplementedException("Graphic should not be used this way! You must set Draw");

        /// <summary>Gets the width of the graphic</summary>
        /// <returns>Length of the first line</returns>
        public virtual int GetWidth() => Contents == null || Contents[0] == null ? 0 : Contents[0].Length;

        /// <summary>Gets the height of the graphic</summary>
        /// <returns>Length of the contents array</returns>
        public virtual int GetHeight() => Contents == null || Contents[0] == null ? 0 : Contents.Length;
    }
}
