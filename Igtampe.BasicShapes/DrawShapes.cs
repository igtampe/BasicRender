using System;
using System.Collections.Generic;
using System.Drawing;
using Igtampe.BasicRender;


namespace Igtampe.BasicShapes {

    /// <summary>Holds all BasicShapes functions</summary>
    public static class DrawShapes {

        //-[DrawLine]-------------------------------------------------------------------------------

        /// <summary>Draws a line between the two points with the specified color.<br></br>
        /// <br></br>
        /// <b>NOTE:</b><br></br>
        /// Coordinates are given as CONSOLE coordinates. 0,0 is the TOP-LEFT-MOST coordinate on the console.<br></br>
        /// </summary>
        /// <param name="P1"></param>
        /// <param name="P2"></param>
        /// <param name="C"></param>
        public static void DrawLine(Point P1,Point P2,ConsoleColor C) {DrawLine(new Line(P1,P2),C);}

        /// <summary>Draws a line between the two points with the specified color.<br></br>
        /// <br></br>
        /// <b>NOTE:</b><br></br>
        /// Coordinates are given as CONSOLE coordinates. 0,0 is the TOP-LEFT-MOST coordinate on the console.<br></br>        /// <param name="X1"></param>
        /// <param name="Y1"></param>
        /// <param name="X2"></param>
        /// <param name="Y2"></param>
        /// <param name="C"></param>
        public static void DrawLine(int X1,int Y1,int X2,int Y2,ConsoleColor C) {DrawLine(new Point(X1,Y1),new Point(X2,Y2),C);}

        /// <summary>Draws Line L with the specified color<br></br>
        /// <br></br>
        /// <b>NOTE:</b><br></br>
        /// Coordinates are given as CONSOLE coordinates. 0,0 is the TOP-LEFT-MOST coordinate on the console.</summary>
        /// <param name="L"></param>
        /// <param name="C"></param>
        public static void DrawLine(Line L,ConsoleColor C) {foreach(Point p in L.Points) {DrawBlockAt(p,C);}}

        //-[DrawCurve]-------------------------------------------------------------------------------

        /// <summary>Draws a curve with specified color</summary>
        /// <param name="C"></param>
        /// <param name="C"></param>
        public static void DrawCurve(Curve Cu,ConsoleColor C) { foreach(Point p in Cu.Points) { DrawBlockAt(p,C); } }

        //-[DrawBlockAt]-------------------------------------------------------------------------------

        /// <summary>Draws a block at the specified position</summary>
        /// <param name="X"></param>
        /// <param name="Y"></param>
        /// <param name="C"></param>
        public static void DrawBlockAt(int X,int Y,ConsoleColor C) {

            //Save the current position
            Point P = new Point(Console.CursorLeft,Console.CursorTop);

            //Set the position
            RenderUtils.SetPos(X,Y);

            //Draw the block
            Draw.Block(C);

            //Go back to the old position
            RenderUtils.SetPos(P.X,P.Y);

        }

        /// <summary>Draws a block of color C at point P</summary>
        /// <param name="P"></param>
        /// <param name="C"></param>
        public static void DrawBlockAt(Point P,ConsoleColor C) {DrawBlockAt(P.X,P.Y,C);}

        //-[DrawRectangle]-------------------------------------------------------------------------------

        /// <summary>Draws a rectangle on-screen, but does not fill it.</summary>
        /// <param name="R"></param>
        /// <param name="C"></param>
        public static void DrawRectangle(Rectangle R,ConsoleColor C){

            //We need to draw 4 lines.
            DrawLine(R.X,R.Y,R.X + R.Width,R.Y,C);
            DrawLine(R.X + R.Width,R.Y,R.X + R.Width,R.Y + R.Height,C);
            DrawLine(R.X + R.Width,R.Y+R.Height,R.X,R.Y + R.Height,C);
            DrawLine(R.X,R.Y + R.Height,R.X,R.Y,C);

            //And done
        }

        //-[FillRectangle]-------------------------------------------------------------------------------

        /// <summary>Alias for Draw.Box() in BasicRender</summary>
        /// <param name="R"></param>
        /// <param name="C"></param>
        public static void FillRectangle(Rectangle R,ConsoleColor C) {Draw.Box(C,R.Width,R.Height,R.X,R.Y);}

        //-[DrawPolygon]-------------------------------------------------------------------------------

        /// <summary>Draws a polygon with points P</summary>
        /// <param name="Ps"></param>
        /// <param name="C"></param>
        public static void DrawPolygon(Point[] Ps,ConsoleColor C) {DrawPolygon(new Polygon(Ps),C);}

        /// <summary>Draws a polygon with lines Ls</summary>
        /// <param name="Ls"></param>
        /// <param name="C"></param>
        public static void DrawPolygon(Line[] Ls,ConsoleColor C) {DrawPolygon(new Polygon(Ls),C);}

        /// <summary>Draws polygon P with color C (Does not fill it)</summary>
        /// <param name="P"></param>
        /// <param name="C"></param>
        public static void DrawPolygon(Polygon P,ConsoleColor C) {foreach(Line L in P.Lines) {DrawLine(L,C);}}

        //-[FillPolygon]-------------------------------------------------------------------------------

        /// <summary>Fills Polygon with points P</summary>
        public static void FillPolygon(Point[] Ps, ConsoleColor C) { FillPolygon(new Polygon(Ps),C); }

        /// <summary>Fills Polygon with points P</summary>
        /// <param name="Ls"></param>
        /// <param name="C"></param>
        public static void FillPolygon(Line[] Ls,ConsoleColor C) { FillPolygon(new Polygon(Ls),C); }

        /// <summary>Fills Polygon with Points P</summary>
        /// <param name="P"></param>
        /// <param name="C"></param>
        public static void FillPolygon(Polygon P,ConsoleColor C) {

            int TopY = 99999999;
            int BottomY = 0;

            //Get all the points
            List<Point> AllPoints = new List<Point>();
            foreach(Line L in P.Lines) {AllPoints.AddRange(L.Points);}

            //Find the topY (least Y on console) and bottomY (highest Y on console)
            foreach(Point p in AllPoints) {
                TopY = Math.Min(TopY,p.Y);
                BottomY = Math.Max(BottomY,p.Y);
            }

            //Now that we have our bounds let's make an array
            List<Point>[] PointsAtYLevel = new List<Point>[BottomY+1];

            //Go through each point again and sort them to their places
            foreach(Point p in AllPoints) {
                if(PointsAtYLevel[p.Y] == null) { PointsAtYLevel[p.Y] = new List<Point>(); }
                PointsAtYLevel[p.Y].Add(p);
            }


            //Now we're going to go through the points again in a for loop, looking only at points in the specific Y
            for(int Y = TopY; Y <= BottomY; Y++) {

                int MinX = 999999999;
                int MaxX = 0;

                //Get the points that are specifically at this Y level. Find the min X and max X.
                foreach(Point p in PointsAtYLevel[Y]) {
                    MinX = Math.Min(MinX,p.X);
                    MaxX = Math.Max(MaxX,p.X);
                }

                //Now that we have our bounds we can *finally* begin to fill after like 20 Foreach loops.
                for(int X = MinX; X <= MaxX; X++) {DrawBlockAt(X,Y,C);}

            }
            
        
        }


    }
}
