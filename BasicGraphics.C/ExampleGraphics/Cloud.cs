//Look ma! No dependencies!

namespace Igtampe.BasicGraphics.ExampleGraphics {
    /// <summary>A Cloud graphic, used for testing.</summary>
    public class Cloud:BasicGraphic {

        private static readonly string[] CloudContent = {
                "111111111111111111111111",
                "111111111111111111111111",
                "111111111111111111111111",
                "111111111111111111111111",
                "111111177771111111111111",
                "111117777777711111111111",
                "111177777777777777111111",
                "111777777777777777771111",
                "117777777777777777777711",
                "111111111111111111111111",
                "111111111111111111111111",
                "111111111111111111111111",
                "111111111111111111111111",
            };


        /// <summary>Creates an instance of this cloud graphic</summary>
        public Cloud() : base(CloudContent,"Cloud Graphic"){}


    }
}
