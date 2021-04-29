using System;
using System.IO;

namespace Igtampe.BasicGraphics {
    /// <summary>Holds a HiColorGraphic from a file</summary>
    [Obsolete("Use LoadFromFile()")]
    public class HiColorGraphicFromFile:HiColorGraphic {

        /// <summary>Generates a HiColorGraphic item from a file</summary>
        [Obsolete("Use LoadFromFile()")]
        public HiColorGraphicFromFile(string Filename):base(File.ReadAllLines(Filename),Filename) {}
    }

}
