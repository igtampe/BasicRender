﻿using System;

namespace Igtampe.BasicGraphics {
    /// <summary>Holds a BasicGraphic from a Resource</summary>
    public class BasicGraphicFromResource:BasicGraphic {

        public BasicGraphicFromResource(byte[] Resource):this("Graphic From Resource",Resource) { }

        /// <summary>Generates a BasicGraphic item from a file</summary>
        public BasicGraphicFromResource(String Name, byte[] Resource) {
            this.Name = Name;
            Contents = GraphicUtils.ResourceToStringArray(Resource);
        }

    }
}