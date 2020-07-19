using System;
using System.IO;

namespace Igtampe.BasicGraphics {
    /// <summary>Holds a HiColorGraphic from a file</summary>
    public class HiColorGraphicFromFile:HiColorGraphic {

        /// <summary>Generates a HiColorGraphic item from a file</summary>
        public HiColorGraphicFromFile(String Filename) {

            if(!File.Exists(Filename)) { throw new FileNotFoundException(); }
            Name = Filename;
            Contents = File.ReadAllLines(Filename);
        }
    }

}
