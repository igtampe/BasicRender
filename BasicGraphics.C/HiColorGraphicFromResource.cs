using System;

namespace Igtampe.BasicGraphics {

    /// <summary>Holds a HiColorGraphic from a resource</summary>
    [Obsolete("Use LoadFromResource()")]
    public class HiColorGraphicFromResource:HiColorGraphic {

        /// <summary>Creates and loads this hicolor graphic.</summary>
        /// <param name="Resource"></param>
       [Obsolete("Use LoadFromResource()")]
        public HiColorGraphicFromResource(byte[] Resource) : this("Graphic From Resource",Resource) { }

        /// <summary>Generates a HiColorGraphic item from a file</summary>
        [Obsolete("Use LoadFromResource()")]
        public HiColorGraphicFromResource(string Name,byte[] Resource):base(GraphicUtils.ResourceToStringArray(Resource),Name) {}

    }
}
