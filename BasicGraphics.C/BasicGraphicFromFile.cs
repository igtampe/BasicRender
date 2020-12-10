using System;
using System.IO;

namespace Igtampe.BasicGraphics {

    /// <summary>Holds a BasicGraphic from a file</summary>
    [Obsolete("Use LoadFromFile()")]
    public class BasicGraphicFromFile:BasicGraphic {
        /// <summary>Generates a BasicGraphic item from a file</summary>
        [Obsolete("Use LoadFromFile()")]
        public BasicGraphicFromFile(String Filename):base(File.ReadAllLines(Filename),Filename) {}
    }
}
