using Igtampe.BasicGraphics;

namespace Igtampe.BasicWindows.WindowElements {

    /// <summary>Image that holds a BasicRenderGraphic</summary>
    public class Image : WindowElement {

        private readonly Graphic Graphic;

        /// <summary>Creates an image window element</summary>
        /// <param name="Parent"></param>
        /// <param name="Graphic"></param>
        /// <param name="LeftPos"></param>
        /// <param name="TopPos"></param>
        public Image(Window Parent, Graphic Graphic, int LeftPos, int TopPos) : base(Parent) {
            this.Graphic = Graphic;
            this.LeftPos = LeftPos;
            this.TopPos = TopPos;
        }

        /// <summary>Draws this image window element</summary>
        public override void DrawElement() => Graphic.Draw(Parent.LeftPos + LeftPos, Parent.TopPos + TopPos);
    }
}
