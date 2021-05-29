using System;

namespace Igtampe.BasicRender {

    /// <summary>Class that handles BasicRender's rendering capabilities.</summary>
    public static class Draw{

        //--------------------------------[Sprite]--------------------------------

        /// <summary>Renders a sprite at the current cursor position</summary>
        /// <param name="sprite">Sprite to draw</param>
        /// <param name="BackgroundColor">Background color</param>
        /// <param name="ForegroundColor">Foreground color</param>
        public static void Sprite(string sprite,ConsoleColor BackgroundColor,ConsoleColor ForegroundColor) { Sprite(sprite,BackgroundColor,ForegroundColor,-1,-1); }

        /// <summary>renders a sprite at the specified cursor position</summary>
        /// <param name="sprite"></param>
        /// <param name="BackgroundColor"></param>
        /// <param name="ForegroundColor"></param>
        /// <param name="LeftPos"></param>
        /// <param name="TopPos"></param>
        public static void Sprite(string sprite,ConsoleColor BackgroundColor,ConsoleColor ForegroundColor,int LeftPos,int TopPos) {

            //If we get a position, move the cursor to that position
            if(LeftPos == -1 && TopPos == -1) {
                //Set the leftpos and toppos to the current cursor position
                LeftPos = Console.CursorLeft;
                TopPos = Console.CursorTop;
            }

            //OK now that we have our leftpos and toppos let's split these by line and just go from there
            if (sprite.Split('\n').Length > 1) {
                int LineOffset = 0;
                foreach (string S in sprite.Split('\n')) {
                    Sprite(S, BackgroundColor, ForegroundColor, LeftPos, TopPos + LineOffset);
                    TopPos++;
                }
                return; //The sprite is now done, Get out.
            }

            //Now, a few checks to make sure we can space this singular line of text:
            if (TopPos < 0 || TopPos >= Console.WindowHeight || LeftPos>=Console.WindowWidth) {return;} //If the topppos or leftpos (Only to the right) is out of range, just don't draw the line at all.

            //Check the left 
            if (LeftPos < 0) {
                //verify that there's any string we can actually draw
                if (sprite.Length <= LeftPos * -1) {return; } //If the sprite's length is less than or equal to the amount of string we're going to have to trim, then don't draw it at all
                sprite = sprite.Substring(LeftPos * -1); //Trim the text to start at the leftpos times negative 1. IE: If the leftpos is -8, then we trim 8 characters from the start
                LeftPos = 0; //Set the leftpos to 0 so that we can draw the trimmed text
            }

            //Now check the right:
            if (LeftPos + sprite.Length > Console.WindowWidth) {
                //If the sprite goes over the left side, we need to trim the end.
                //We've already made sure the string has *something* to draw, since otherwise, LeftPos would be out of range to the right

                //We need to get a substring from 0 to the maximum it can take up.
                sprite = sprite.Substring(0, Console.WindowWidth - LeftPos);
            }

            //If somehow we still have an out of range render position, just return.
            if (!RenderUtils.SetPos(LeftPos, TopPos)){return;}

            //Now we can *finally* do the actual drawing of the sprite.

            //Save the current colors of the console
            ConsoleColor OldBG = Console.BackgroundColor;
            ConsoleColor OldFG = Console.ForegroundColor;

            //Set the color to whatever the colors of the sprite will be
            RenderUtils.Color(BackgroundColor,ForegroundColor);
            
            //Write the sprite
            Console.Write(sprite);

            //Change back to the old colors.
            RenderUtils.Color(OldBG,OldFG);
            

        }

        //--------------------------------[Block]--------------------------------

        /// <summary>Draws a block of a certain color at the current cursor position</summary>
        /// <param name="Color">Color of the block</param>
        public static void Block(ConsoleColor Color) { Block(Color,-1,-1); }

        /// <summary>Draws a block of a certain color at the specified position</summary>
        /// <param name="Color"></param>
        /// <param name="LeftPos"></param>
        /// <param name="TopPos"></param>
        public static void Block(ConsoleColor Color,int LeftPos,int TopPos) { Sprite(" ",Color,Color,LeftPos,TopPos); }

        //--------------------------------[Box]--------------------------------

        /// <summary>Draws a box of the specified color of the specified height and width at the specified position</summary>
        /// <param name="Color"></param>
        /// <param name="Length"></param>
        /// <param name="Height"></param>
        /// <param name="LeftPos"></param>
        /// <param name="TopPos"></param>
        public static void Box(ConsoleColor Color,int Length,int Height,int LeftPos,int TopPos) { for(int i = 0; i < Height; i++) { Row(Color,Length,LeftPos,TopPos + i); } }

        //--------------------------------[Row]--------------------------------

        /// <summary>Draws a row of blocks of the specified color of specified length at the current cursor position</summary>
        /// <param name="RowColor"></param>
        /// <param name="Length"></param>
        public static void Row(ConsoleColor RowColor,int Length) { Row(RowColor,Length,-1,-1); }

        /// <summary>Draws a row of blocks of the specified color of specified length at the specified position</summary>
        /// <param name="RowColor"></param>
        /// <param name="Length"></param>
        /// <param name="LeftPos"></param>
        /// <param name="TopPos"></param>
        public static void Row(ConsoleColor RowColor,int Length,int LeftPos,int TopPos) {

            //You know what, in order to save us the trouble of building another overscan implementation,
            //let's do what we should've done when we first coded this thing and just prepare a row string and pass that to Sprite just like Block does.

            string Row = "";
            while (Row.Length!=Length) {Row += " ";}
            Sprite(Row, RowColor, RowColor, LeftPos, TopPos);

            ////If we get a position, move the cursor to that position
            //if (LeftPos == -1 && TopPos == -1) {
            //    //Set the leftpos and toppos to the current cursor position
            //    LeftPos = Console.CursorLeft;
            //    TopPos = Console.CursorTop;
            //}


            ////If we get a position, move to that position.
            //if (LeftPos != -1 && TopPos != -1) {if(!RenderUtils.SetPos(LeftPos,TopPos)) { return; }}

            ////Save the current colors of the console
            //ConsoleColor OldBG = Console.BackgroundColor;
            //ConsoleColor OldFG = Console.ForegroundColor;

            ////Set the color to the color this row will be
            //RenderUtils.Color(RowColor,RowColor);

            ////Draw the row
            //for(int i = 0; i < Length; i++) { Console.Write(SpecialChars.BLOCK); }

            ////Set the color back to whatever it was.
            //RenderUtils.Color(OldBG,OldFG);
        }

        //--------------------------------[Clearline]--------------------------------

        /// <summary>Clears the specified line using the Console's current background color</summary>
        /// <param name="TopPos"></param>
        public static void ClearLine(int TopPos) { Row(Console.BackgroundColor,Console.WindowWidth - 1,0,TopPos); }

        //--------------------------------[CenterText]--------------------------------

        /// <summary>Draws text centered on the screen at the current row, and with curent colors</summary>
        /// <param name="Text"></param>
        public static void CenterText(string Text) { CenterText(Text,Console.CursorTop,Console.BackgroundColor,Console.ForegroundColor); }

        /// <summary>Draws text centered on the screen at the specified row, with the current colors</summary>
        /// <param name="Text"></param>
        /// <param name="TopPos"></param>
        public static void CenterText(string Text,int TopPos) { CenterText(Text,TopPos,Console.BackgroundColor,Console.ForegroundColor); }

        /// <summary>Draws text centered on the screen at the specified row, with the specified colors</summary>
        /// <param name="Text"></param>
        /// <param name="TopPos"></param>
        /// <param name="BG"></param>
        /// <param name="FG"></param>
        public static void CenterText(string Text,int TopPos,ConsoleColor BG,ConsoleColor FG) {

            //Find the position of this text where its centered. -1 so that it preffers left center rather than right center.
            int leftpos = (Console.WindowWidth - Text.Length - 1) / 2; ;
            while(leftpos < 0) {
                Text.Substring(0,Text.Length - 1);
                leftpos = (Console.WindowWidth - Text.Length - 1) / 2; ;
                
                if(leftpos < 0) { break; }
                
                Text.Substring(1,Text.Length - 1);
                leftpos = (Console.WindowWidth - Text.Length - 1) / 2; ;
            } //Peacock Shake the text until it fits

            //Save the current console colors
            ConsoleColor OldBG = Console.BackgroundColor;
            ConsoleColor OldFG = Console.ForegroundColor;

            //set the color to the specified colors
            RenderUtils.Color(BG,FG);

            //Put the cursor in the right position and draw the centered text.
            if(!RenderUtils.SetPos(leftpos,TopPos)) { return; }
            Console.Write(Text);

            //Set the colors back to the old colors
            RenderUtils.Color(OldBG,OldFG);

        }

    }


}
