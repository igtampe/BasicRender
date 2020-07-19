using System;

namespace Igtampe.BasicGraphics {

    /// <summary>Holds a HiColorGraphic from a resource</summary>
    public class HiColorGraphicFromResource:HiColorGraphic {

        public HiColorGraphicFromResource(byte[] Resource) : this("Graphic From Resource",Resource) { }

        /// <summary>Generates a BasicGraphic item from a file</summary>
        public HiColorGraphicFromResource(String Name,byte[] Resource) {
            this.Name = Name;
            Contents = GraphicUtils.ResourceToStringArray(Resource);
        }

    }
}
