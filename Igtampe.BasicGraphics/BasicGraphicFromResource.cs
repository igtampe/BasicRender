using System;

namespace Igtampe.BasicGraphics {
    /// <summary>Holds a BasicGraphic from a Resource</summary>
    [Obsolete("Use LoadFromResource()")]
    public class BasicGraphicFromResource:BasicGraphic {

        /// <summary>Creates and loads this BasicGraphic</summary>
        /// <param name="Resource"></param>
        [Obsolete("Use LoadFromResource()")]
        public BasicGraphicFromResource(byte[] Resource):this("Graphic From Resource",Resource) { }

        /// <summary>Generates a BasicGraphic item from a file</summary>
        /// <param name="Name">Name of this graphic</param>
        /// <param name="Resource">Resource Byte Array</param>
        [Obsolete("Use LoadFromResource()")]
        public BasicGraphicFromResource(string Name, byte[] Resource):base(GraphicUtils.ResourceToStringArray(Resource),Name) {}

    }
}
