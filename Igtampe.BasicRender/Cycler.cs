namespace Igtampe.BasicRender {

    /// <summary>Holds a cycler object, which holds an array of strings to cycle through</summary>
    public class Cycler {
        private readonly string[] Objects;
        private int Pos=-1;

        /// <summary>Creates a cycler with a specified array of strings to cycle through</summary>
        /// <param name="SpinnerObjects"></param>
        public Cycler(string[] SpinnerObjects) {Objects = SpinnerObjects;}

        /// <summary>Gets the next string from this cycler's list, and cycles it one position forward</summary>
        /// <returns></returns>
        public string Cycle() {
            Pos++;
            if(Pos >= Objects.Length) { Pos = 0; }
            return Objects[Pos];
        }

    }
}
