using System;
using System.IO;

namespace Igtampe.BasicGraphics{

    /// <summary>Holds a BasicGraphic from a file</summary>
    public class BasicGraphicFromFile:BasicGraphic {

        /// <summary>Generates a BasicGraphic item from a file</summary>
        public BasicGraphicFromFile(String Filename) {
            if(!File.Exists(Filename)) { throw new FileNotFoundException(); }
            Name = Filename;
            Contents = File.ReadAllLines(Filename);
        }

    }
}
