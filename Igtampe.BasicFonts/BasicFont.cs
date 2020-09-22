using System;
using System.Collections.Generic;

using Igtampe.DictionaryOnDisk;
using Igtampe.BasicGraphics;
using Igtampe.BasicRender;
using Igtampe.BasicFonts.Properties;

namespace Igtampe.BasicFonts{
    public class BasicFont {

        //-[Variable and Properties]---------------------------------------------------------------------

        /// <summary>Dictionary that holds all the relevant data for the font.</summary>
        private readonly Dictionary<string,string> FontDictionary;

        /// <summary>Name of this font</summary>
        public string Name { get { return FontDictionary["Name"]; } }

        /// <summary>Author of this font</summary>
        public string Author { get { return FontDictionary["Author"]; } }

        /// <summary>Width of this font's characters</summary>
        public int Width { get { return int.Parse(FontDictionary["CharWidth"]); } }

        /// <summary>Height of this font's characters</summary>
        public int Height { get { return int.Parse(FontDictionary["CharHeight"]); } }

        /// <summary>Creates a BasicFont.</summary>
        /// <param name="FontDictionary">Dictionary that holds all font data. MUST Include the keys Name, Author, CharWidth, CharHeight and Chars.</param>
        public BasicFont(Dictionary<string,string> FontDictionary) {
            this.FontDictionary = FontDictionary;

            //Check that the font has all the required keys
            if(!FontDictionary.ContainsKey("Name") |
                !FontDictionary.ContainsKey("Author") |
                !FontDictionary.ContainsKey("CharWidth") |
                !FontDictionary.ContainsKey("CharHeight")) { throw new ArgumentException("Dictionary is not a Font Dictionary."); }

        }

        //-[Non-static methods]---------------------------------------------------------------------

        /// <summary>Checks if a font has the given character.</summary>
        /// <param name="C"></param>
        /// <returns></returns>
        public bool ContainsChar(Char C) {
            if(C == ':') { return FontDictionary.ContainsKey("Char" + "Colon"); }
            return FontDictionary.ContainsKey("Char" + C); 
        }

        /// <summary>Writes text on screen using this font with the current color and 1 column of space between each character.</summary>
        /// <param name="Text">Text to write </param>
        public void DrawText(string Text) {DrawText(Text,Console.CursorLeft,Console.CursorTop);}

        /// <summary>Writes text on screen using this font with the current color and 1 column of space between each character</summary>
        /// <param name="Text">Text to write</param>
        /// <param name="Leftpos">Leftpos of the text</param>
        /// <param name="Toppos">Toppos of the text</param>
        public void DrawText(string Text,int Leftpos,int Toppos) {DrawText(Text,Leftpos,Toppos,Console.ForegroundColor);}

        /// <summary>Writes text on screen with this font with 1 console column of space between each character</summary>
        /// <param name="Text">Text to write</param>
        /// <param name="Leftpos">Leftpos of the text</param>
        /// <param name="Toppos">Toppos of the text</param>
        /// <param name="FG">Color of this text</param>
        public void DrawText(string Text, int Leftpos, int Toppos, ConsoleColor FG){DrawText(Text,Leftpos,Toppos,FG,1);}

        /// <summary>Writes text on screen with this font.</summary>
        /// <param name="Text">Text to write.</param>
        /// <param name="Leftpos">Leftpos of the text</param>
        /// <param name="Toppos">TopPos of the text </param>
        /// <param name="FG">Foreground color of the text</param>
        /// <param name="Spacing">Spacing between characters (In cols)</param>
        public void DrawText(string Text, int Leftpos, int Toppos, ConsoleColor FG, int Spacing) {
            int HorizontalOffset = 0;
            int VerticalOffset = 0;

            foreach(Char C in Text) {
                if(C == '\n') { 
                    VerticalOffset += Height + 1;
                    HorizontalOffset = 0;
                } else { 
                    DrawChar(C,Leftpos + HorizontalOffset,Toppos + VerticalOffset,FG);
                    HorizontalOffset += Width + Spacing;
                }
                
            }
        
        }

        /// <summary>Gets character BasicFontData</summary>
        /// <param name="C"></param>
        /// <returns></returns>
        private string GetChar(Char C) {
            if(C == ':') { return FontDictionary["Char" + "Colon"]; }
            return FontDictionary["Char" + C];
        }

        /// <summary>Gets and converts BasicFontData to a BasicGraphic, then draws it.</summary>
        /// <param name="C"></param>
        /// <param name="Leftpos"></param>
        /// <param name="Toppos"></param>
        /// <param name="FG"></param>
        /// <returns></returns>
        private void DrawChar(Char C,int Leftpos,int Toppos,ConsoleColor FG) {

            //Draw a space
            if(C == ' ') { return; }

            //If the character is not in this font, draw a box.
            if(!ContainsChar(C)) {DrawNullChar(Leftpos,Toppos,FG); return;}

            //Turn the BasicFontData into BasicGraphic
            BasicGraphic Character = new CharacterGraphic(GetChar(C),FG);

            //Draw it
            Character.Draw(Leftpos,Toppos);

        }

        /// <summary>Draw a null character in case it isn't included in this font.</summary>
        /// <param name="Leftpos"></param>
        /// <param name="Toppos"></param>
        /// <param name="FG"></param>
        private void DrawNullChar(int Leftpos,int Toppos,ConsoleColor FG) {Draw.Box(FG,Width,Height,Leftpos,Toppos);}

        //-[Static methods]---------------------------------------------------------------------

        /// <summary>Creates a BasicFont from a file</summary>
        /// <param name="Filename"></param>
        /// <returns></returns>
        public static BasicFont LoadFromFile(string Filename) { return new BasicFont(DOD.Load(Filename)); }

        /// <summary>Creates a BasicFont from a resource</summary>
        /// <param name="Resource"></param>
        /// <returns></returns>
        public static BasicFont LoadFromResource(Byte[] Resource) { return new BasicFont(DOD.Parse(GraphicUtils.ResourceToStringArray(Resource))); }

        /// <summary>Reverse function for ColorCharToConsoleColor</summary>
        /// <param name="color"></param>
        /// <returns></returns>
        public static char ConsoleColorToColorChar(ConsoleColor color) {
            switch(color) {
                case ConsoleColor.Black:
                    return '0';
                case ConsoleColor.DarkBlue:
                    return '1';
                case ConsoleColor.DarkGreen:
                    return '2';
                case ConsoleColor.DarkCyan:
                    return '3';
                case ConsoleColor.DarkRed:
                    return '4';
                case ConsoleColor.DarkMagenta:
                    return '5';
                case ConsoleColor.DarkYellow:
                    return '6';
                case ConsoleColor.Gray:
                    return '7';
                case ConsoleColor.DarkGray:
                    return '8';
                case ConsoleColor.Blue:
                    return '9';
                case ConsoleColor.Green:
                    return 'A';
                case ConsoleColor.Cyan:
                    return 'B';
                case ConsoleColor.Red:
                    return 'C';
                case ConsoleColor.Magenta:
                    return 'D';
                case ConsoleColor.Yellow:
                    return 'E';
                case ConsoleColor.White:
                    return 'F';
                default:
                    return '0';
            }
        }

        /// <summary>Holder for the default font</summary>
        private static BasicFont defaultFont;

        /// <summary>Default Font from the BasicFont Package (5x6)</summary>
        public static BasicFont DefaultFont { get {
                if(defaultFont == null) { defaultFont = LoadFromResource(Resources.DefaultFont); } //LazyLoad the whole thing
                return defaultFont;
            } }

        //-[Internal Graphic Class]---------------------------------------------------------------------

        /// <summary>Private graphic file to turn Character Data to a BasicGraphic</summary>
        private class CharacterGraphic:BasicGraphic {
            public CharacterGraphic(string CharacterData, ConsoleColor FG) {
                Name = "TempCharacter";
                Contents = CharacterData.Replace('#',ConsoleColorToColorChar(FG)).Split('\n');
            }               
        }

    }
}
