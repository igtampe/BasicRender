namespace Igtampe.BasicRender {

    /// <summary>
    /// Class that holds special characters for extended rendering. <br></br>
    /// <br></br>
    /// N     D     D-S   S-D<br></br>
    /// ┌─┬┐  ╔═╦╗  ╓─╥╖  ╒═╤╕<br></br>
    /// ├─┼┤  ╠═╬╣  ╟─╫╢  ╞═╪╡<br></br>
    /// └─┴┘  ╚═╩╝  ╙─╨╜  ╘═╧╛<br></br>
    /// <br></br>
    /// N : single box characters<br></br>
    /// D : double box characters<br></br>
    /// DS: Double vertical, Single Horizontal Box Characters<br></br>
    /// SD: Single Vertical, Double Horizontal Box Characters<br></br>
    /// </summary>
    public static class SpecialChars {

        //-[Regular]---------------------------------------------------------------------

        /// <summary>┌</summary>
        public const char TOP_LEFT = '┌';

        /// <summary>┐</summary>
        public const char TOP_RIGHT = '┐';

        /// <summary>└</summary>
        public const char BOTTOM_LEFT = '└';

        /// <summary>┘</summary>
        public const char BOTTOM_RIGHT = '┘';

        /// <summary>│</summary>
        public const char VERTICAL = '│';

        /// <summary>─</summary>
        public const char HORIZONTAL = '─';

        /// <summary>├</summary>
        public const char T_LEFT = '├';

        /// <summary>┤</summary>
        public const char T_RIGHT = '┤';

        /// <summary>┴</summary>
        public const char T_BOTTOM = '┴';

        /// <summary>┬</summary>
        public const char T_TOP = '┬';

        /// <summary>┼</summary>
        public const char T = '┼';

        //-[Double]---------------------------------------------------------------------

        /// <summary>╔</summary>
        public const char DOUBLE_TOP_LEFT = '╔';

        /// <summary>╗</summary>
        public const char DOUBLE_TOP_RIGHT = '╗';

        /// <summary>╚</summary>
        public const char DOUBLE_BOTTOM_LEFT = '╚';

        /// <summary>╝</summary>
        public const char DOUBLE_BOTTOM_RIGHT = '╝';

        /// <summary>║</summary>
        public const char DOUBLE_VERTICAL = '║';

        /// <summary>═</summary>
        public const char DOUBLE_HORIZONTAL = '═';

        /// <summary>╠</summary>
        public const char DOUBLE_T_LEFT = '╠';

        /// <summary>╣</summary>
        public const char DOUBLE_T_RIGHT = '╣';

        /// <summary>╩</summary>
        public const char DOUBLE_T_BOTTOM = '╩';

        /// <summary>╦</summary>
        public const char DOUBLE_T_TOP = '╦';

        /// <summary>╬</summary>
        public const char DOUBLE_T = '╬';

        //-[Double Single (Double Vertical, Single Horizontal)]---------------------------------------------------------------------

        /// <summary>╓</summary>
        public const char DOUBLE_SINGLE_TOP_LEFT = '╓';

        /// <summary>╖</summary>
        public const char DOUBLE_SINGLE_TOP_RIGHT = '╖';

        /// <summary>╙</summary>
        public const char DOUBLE_SINGLE_BOTTOM_LEFT = '╙';

        /// <summary>╜</summary>
        public const char DOUBLE_SINGLE_BOTTOM_RIGHT = '╜';

        /// <summary>║</summary>
        public const char DOUBLE_SINGLE_VERTICAL = DOUBLE_VERTICAL;

        /// <summary>─</summary>
        public const char DOUBLE_SINGLE_HORIZONTAL = HORIZONTAL;

        /// <summary>╟</summary>
        public const char DOUBLE_SINGLE_T_LEFT = '╟';

        /// <summary>╢</summary>
        public const char DOUBLE_SINGLE_T_RIGHT = '╢';

        /// <summary>╥</summary>
        public const char DOUBLE_SINGLE_T_TOP = '╥';

        /// <summary>╨</summary>
        public const char DOUBLE_SINGLE_T_BOTTOM = '╨';

        /// <summary>╫</summary>
        public const char DOUBLE_SINGLE_T = '╫';

        //-[Single Double (Single Vertical, Double Horizontal)]---------------------------------------------------------------------

        /// <summary>╒</summary>
        public const char SINGLE_DOUBLE_TOP_LEFT = '╒';

        /// <summary>╕</summary>
        public const char SINGLE_DOUBLE_TOP_RIGHT = '╕';

        /// <summary>╘</summary>
        public const char SINGLE_DOUBLE_BOTTOM_LEFT = '╘';

        /// <summary>╛</summary>
        public const char SINGLE_DOUBLE_BOTTOM_RIGHT = '╛';

        /// <summary>│</summary>
        public const char SINGLE_DOUBLE_VERTICAL = VERTICAL;

        /// <summary>═</summary>
        public const char SINGLE_DOUBLE_HORIZONTAL = DOUBLE_HORIZONTAL;

        /// <summary>╞</summary>
        public const char SINGLE_DOUBLE_T_LEFT = '╞';

        /// <summary>╡</summary>
        public const char SINGLE_DOUBLE_T_RIGHT = '╡';

        /// <summary>╤</summary>
        public const char SINGLE_DOUBLE_T_TOP = '╤';

        /// <summary>╧</summary>
        public const char SINGLE_DOUBLE_T_BOTTOM = '╧';

        /// <summary>╪</summary>
        public const char SINGLE_DOUBLE_T = '╪';

        //-[Blocks]---------------------------------------------------------------------

        /// <summary>Bottom half of a block</summary>
        public const char BOTTOM_HALF_BLOCK = '▄';

        /// <summary>Full block</summary>
        public const char BLOCK = '█';

        /// <summary>Left half of a block</summary>
        public const char LEFT_HALF_BLOCK = '▌';

        //-[Arrows]---------------------------------------------------------------------

        //▲▼◄► ↑↓←→ ↕↔ «»

        /// <summary>▲</summary>
        public const char TRIANGLE_UP = '▲';

        /// <summary>▼</summary>
        public const char TRIANGLE_DOWN = '▼';

        /// <summary>◄</summary>
        public const char TRIANGLE_LEFT = '◄';

        /// <summary>►</summary>
        public const char TRIANGLE_RIGHT = '►';

        /// <summary>↑</summary>
        public const char ARROW_UP = '↑';

        /// <summary>↓</summary>
        public const char ARROW_DOWN = '↓';

        /// <summary>←</summary>
        public const char ARROW_LEFT = '←';

        /// <summary>→</summary>
        public const char ARROW_RIGHT = '→';

        /// <summary>↕</summary>
        public const char ARROW_UP_DOWN = '↕';

        /// <summary>↔</summary>
        public const char ARROW_LEFT_RIGHT = '↔';

        /// <summary>«</summary>
        public const char ARROW_DOUBLE_LEFT = '«';

        /// <summary>»</summary>
        public const char ARROW_DOUBLE_RIGHT = '»';

        //-[Other]---------------------------------------------------------------------

        /// <summary>☺</summary>
        public const char HOLLOW_SMILEY = '☺';

        /// <summary>☻</summary>
        public const char FULL_SMILEY = '☻';

        /// <summary></summary>
        public const char HEART = '♥';

        /// <summary>♦</summary>
        public const char DIAMOND = '♦';

        /// <summary>♣</summary>
        public const char CLOVER = '♣';

        /// <summary>♠</summary>
        public const char SPADE = '♠';

        /// <summary>♫</summary>
        public const char NOTE = '♫';

        /// <summary>☼</summary>
        public const char SUN = '☼';

        /// <summary>§</summary>
        public const char SECTION_SIGN = '§';

        /// <summary>¼</summary>
        public const char QUARTER = '¼';

        /// <summary>½</summary>
        public const char HALF = '½';

        /// <summary>°</summary>
        public const char DEGREE = '°';

        /// <summary>±</summary>
        public const char PLUS_MINUS = '±';

        /// <summary>²</summary>
        public const char SQUARE = '²';

        //-[Other]---------------------------------------------------------------------

        /// <summary>Writelines all test characters</summary>
        public static void TestChars() {
            System.Console.WriteLine("" +
                TOP_LEFT + TOP_RIGHT + BOTTOM_LEFT + BOTTOM_RIGHT + HORIZONTAL + VERTICAL + T_LEFT + T_RIGHT + T_BOTTOM + T_TOP + T +
                DOUBLE_TOP_LEFT + DOUBLE_TOP_RIGHT + DOUBLE_BOTTOM_LEFT + DOUBLE_BOTTOM_RIGHT + DOUBLE_HORIZONTAL + DOUBLE_VERTICAL + DOUBLE_T_LEFT + DOUBLE_T_RIGHT + DOUBLE_T_BOTTOM + DOUBLE_T_TOP + DOUBLE_T +
                DOUBLE_SINGLE_TOP_LEFT + DOUBLE_SINGLE_TOP_RIGHT + DOUBLE_SINGLE_BOTTOM_LEFT + DOUBLE_SINGLE_BOTTOM_RIGHT + DOUBLE_SINGLE_HORIZONTAL + DOUBLE_SINGLE_VERTICAL + DOUBLE_SINGLE_T_LEFT + DOUBLE_SINGLE_T_RIGHT + DOUBLE_SINGLE_T_BOTTOM + DOUBLE_SINGLE_T_TOP + DOUBLE_SINGLE_T +
                SINGLE_DOUBLE_TOP_LEFT + SINGLE_DOUBLE_TOP_RIGHT + SINGLE_DOUBLE_BOTTOM_LEFT + SINGLE_DOUBLE_BOTTOM_RIGHT + SINGLE_DOUBLE_HORIZONTAL + SINGLE_DOUBLE_VERTICAL + SINGLE_DOUBLE_T_LEFT + SINGLE_DOUBLE_T_RIGHT + SINGLE_DOUBLE_T_BOTTOM + SINGLE_DOUBLE_T_TOP + SINGLE_DOUBLE_T +
                BOTTOM_HALF_BLOCK + LEFT_HALF_BLOCK + BLOCK +
                HOLLOW_SMILEY + FULL_SMILEY +
                HEART + DIAMOND + CLOVER + SPADE +
                NOTE + SUN + SECTION_SIGN + QUARTER + SQUARE + DEGREE + PLUS_MINUS + SQUARE +
                TRIANGLE_UP + TRIANGLE_DOWN + TRIANGLE_LEFT + TRIANGLE_RIGHT +
                ARROW_UP + ARROW_DOWN + ARROW_LEFT + ARROW_RIGHT +
                ARROW_UP_DOWN + ARROW_LEFT_RIGHT +
                ARROW_DOUBLE_LEFT + ARROW_DOUBLE_RIGHT +
                "");
        }
    }
}
