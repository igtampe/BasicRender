using System;

namespace Igtampe.BasicGraphics {
    /// <summary>Holds a BasicGraphic from a Resource</summary>
    public class BasicGraphicFromResource:BasicGraphic {

        /// <summary>Creates and loads this BasicGraphic</summary>
        /// <param name="Resource"></param>
        public BasicGraphicFromResource(byte[] Resource):this("Graphic From Resource",Resource) { }

        /// <summary>Generates a BasicGraphic item from a file</summary>
        public BasicGraphicFromResource(String Name, byte[] Resource) {
            this.Name = Name;
            Contents = GraphicUtils.ResourceToStringArray(Resource);
        }

    }
}
