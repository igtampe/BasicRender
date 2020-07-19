using Igtampe.BasicGraphics.Properties;
using System;
using System.Text;

namespace Igtampe.BasicGraphics{
    public static class GraphicUtils {

        /// <summary>Takes a ColorCharacter and turns it into a consolecolor. The dictionary is as follows
        /// <list type="table">
        /// <listheader><term>Char</term><term>Color</term></listheader>
        /// <item><term>0</term><term>Black</term></item>
        /// <item><term>1</term><term>Blue</term></item>
        /// <item><term>2</term><term>Green</term></item>
        /// <item><term>3</term><term>Aqua</term></item>
        /// <item><term>4</term><term>Red</term></item>
        /// <item><term>5</term><term>Purple</term></item>
        /// <item><term>6</term><term>Yellow</term></item>
        /// <item><term>7</term><term>White</term></item>
        /// <item><term>8</term><term>Gray</term></item>
        /// <item><term>9</term><term>Light Blue</term></item>
        /// <item><term>A</term><term>Light Green</term></item>
        /// <item><term>B</term><term>Light Aqua</term></item>
        /// <item><term>C</term><term>Light Red</term></item>
        /// <item><term>D</term><term>Light Purple</term></item>
        /// <item><term>E</term><term>Light Yellow</term></item>
        /// <item><term>F</term><term>Bright White</term></item>
        /// </list>
        /// </summary>
        /// <param name="ColorChar"></param>
        /// <returns>The corresponding consolecolor</returns>
        public static ConsoleColor ColorCharToConsoleColor(char ColorChar) {

            switch(ColorChar) {
                case '0':
                    return ConsoleColor.Black;
                case '1':
                    return ConsoleColor.DarkBlue;
                case '2':
                    return ConsoleColor.DarkGreen;
                case '3':
                    return ConsoleColor.DarkCyan;
                case '4':
                    return ConsoleColor.DarkRed;
                case '5':
                    return ConsoleColor.DarkMagenta;
                case '6':
                    return ConsoleColor.DarkYellow;
                case '7':
                    return ConsoleColor.Gray;
                case '8':
                    return ConsoleColor.DarkGray;
                case '9':
                    return ConsoleColor.Blue;
                case 'A':
                    return ConsoleColor.Green;
                case 'B':
                    return ConsoleColor.Cyan;
                case 'C':
                    return ConsoleColor.Red;
                case 'D':
                    return ConsoleColor.Magenta;
                case 'E':
                    return ConsoleColor.Yellow;
                case 'F':
                    return ConsoleColor.White;
                case ' ':
                    return Console.BackgroundColor;
                default:
                    throw new ArgumentException();
            }

        }

        /// <summary>Turns a resource into a string array split by lines</summary>
        public static String[] ResourceToStringArray(byte[] Resource) {return Encoding.ASCII.GetString(Resource).Split('\n');}

    }
}
