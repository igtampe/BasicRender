using Igtampe.BasicGraphics;

namespace Igtampe.BasicWindows.WindowElements {

    /// <summary>Image that holds a BasicRenderGraphic</summary>
    public class Image:WindowElement {

        private readonly Graphic Graphic;

        public Image(Window Parent, Graphic Graphic,int LeftPos,int TopPos) : base(Parent) {
            this.Graphic = Graphic;
            this.LeftPos = LeftPos;
            this.TopPos = TopPos;
        }

        public override void DrawElement(int WindowLeft,int WindowTop) { Graphic.draw(WindowLeft + LeftPos,WindowTop + TopPos); }

    }
}
