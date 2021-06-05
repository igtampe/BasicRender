using System;
using System.Collections.Generic;
using System.Drawing;

namespace Igtampe.BasicShapes {
    /// <summary>Holds a Line (two points) and can do some basic stuff with it.</summary>
    public class Line {

        //-[FIELDS]-------------------------------------------------------------------------------

        /// <summary>Leftmost point of the line</summary>
        public Point P1 { protected set; get; }

        /// <summary>Leftmost point of the line (Floating Point)</summary>
        public PointF P1F { protected set; get; }

        /// <summary>Rightmost point of the line.</summary>
        public Point P2 { protected set; get; }

        /// <summary>Rightmost point of the line (Floating Point)</summary>
        public PointF P2F { protected set; get; }

        /// <summary>Private points holder</summary>
        protected List<Point> points;

        /// <summary>List of all points this line has (NOT FLOATING POINT)</summary>
        public List<Point> Points {
            protected set { points = value; }
            get {
                if(points is null) { points = GeneratePoints(this); }
                return points;
            }
        }

        //-[PROPERTIES]-------------------------------------------------------------------------------

        /// <summary>Slope of the line</summary>
        public double M {
            get {
                if(DX == 0) { return float.PositiveInfinity; }
                return (DY + 0.0) / (DX + 0.0);
            }
        }

        /// <summary>Delta X</summary>
        public int DX { get { return Convert.ToInt32(DXF); } }

        public float DXF { get { return P2F.X - P1F.X; } }

        /// <summary>Delta Y</summary>
        public int DY { get { return Convert.ToInt32(DYF); } }

        public float DYF { get { return P2F.Y - P1F.Y; } }

        /// <summary>Length of the line using the ancient power of Pythagorean Theorem</summary>
        public double Length {
            get { return Math.Sqrt(Math.Pow(DXF,2) + Math.Pow(DYF,2)); }
        }

        /// <summary>Returns the center point on this line</summary>
        public PointF Center { get {
                float P3X = Convert.ToSingle(P1.X + (DX * 0.5));
                float P3Y = Convert.ToSingle(P1.Y + (DY * 0.5));
                return new PointF(P3X,P3Y);
            }
        }

        //-[Constructor]-------------------------------------------------------------------------------

        /// <summary>Creates a line</summary>
        public Line(int X1,int Y1,int X2,int Y2) : this(new PointF(X1,Y1),new PointF(X2,Y2)) { }

        public Line(float X1,float Y1,float X2,float Y2) : this(new PointF(X1,Y1),new PointF(X2,Y2)) { }

        /// <summary>Creates a line</summary>
        /// <param name="P1"></param>
        /// <param name="P2"></param>
        public Line(Point P1,Point P2):this(ConvertToPointF(P1),ConvertToPointF(P2)) {}

        /// <summary>Creates a line with Floating Point precision</summary>
        /// <param name="P1"></param>
        /// <param name="P2F"></param>
        public Line(PointF P1,PointF P2):this(P1,P2,false) {}

        /// <summary>Creates a line with floating point precision. Skips sorting P1 and P2 by X if SkipSort is true</summary>
        /// <param name="P1"></param>
        /// <param name="P2"></param>
        /// <param name="SkipSort"></param>
        public Line(PointF P1,PointF P2,bool SkipSort) {
            if(P1.X < P2.X || SkipSort) {
                this.P1F = P1;
                this.P1 = ConvertToPoint(P1);
                this.P2F = P2;
                this.P2 = ConvertToPoint(P2);
            } else {
                this.P1F = P2;
                this.P1 = ConvertToPoint(P2);
                this.P2F = P1;
                this.P2 = ConvertToPoint(P1);
            }
        }

        //-[Methods]-------------------------------------------------------------------------------

        /// <summary>Returns true if this point is in the line. </summary>
        /// <param name="P"></param>
        /// <returns></returns>
        public bool ContainsPoint(Point P) { return Points.Contains(P); }

        /// <summary>Verifies if a line intersects with another</summary>
        /// <param name="L"></param>
        /// <returns></returns>
        public bool Intersects(Line L) {
            if(Equals(L)) { return true; }

            //Before we check every point:
            if (P1F == L.P1F || P1F == L.P2F || P2F == L.P1F || P2F == L.P2F) {
                return true;
            }

            //Sabes this may be inefficient pero it is super neat and when we're dealing (at least with the console which is where this is meant to be used) a line can't be super big so it won't take too long.
            foreach(Point p in L.Points) { if(ContainsPoint(p)) { return true; } }

            return false;
        }

        /// <summary>Returns true if obj is a Line and their points are the same</summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj) {
            if(obj is Line L2) { return P1F.Equals(L2.P1F) && P2F.Equals(L2.P2F); }
            return false;
        }

        /// <summary>returns a string representation of this line</summary>
        /// <returns></returns>
        public override string ToString() {
            return string.Format("({0},{1}) -> ({2},{3})",P1F.X,P1F.Y,P2F.X,P2F.Y);
        }

        //-[Overridable Generate Points]-------------------------------------------------------------------------------

        /// <summary>Generates a list of points in this line for drawing or for checking.</summary>
        /// <returns></returns>
        public virtual List<Point> GeneratePoints(Line L) {

            List<Point> Points = new List<Point>();

            //OK so uh.... Three special cases:

            //Just a point
            if(L.P1.Equals(L.P2)) {
                Points.Add(L.P1);
                return Points;
            }

            //Vertical Line
            if(double.IsInfinity(L.M)) {
                for(int i = Math.Min(L.P1.Y,L.P2.Y); i < Math.Max(L.P2.Y,L.P1.Y) + 1; i++) { Points.Add(new Point(L.P1.X,i)); }
                return Points;
            }

            //Horizontal Line
            if(L.M == 0) {
                for(int X = L.P1.X; X <= L.P2.X; X++) { Points.Add(new Point(X,L.P1.Y)); }
                return Points;
            }

            //OK, no shortcuts. Let's figure this out.

            //Place a point on each side
            Points.Add(L.P1);
            Points.Add(L.P2);

            int PrevY = L.P1.Y;

            for(int DX = 0; DX < L.DX + 1; DX++) {

                int NewY = L.P1.Y + Convert.ToInt32(L.M * DX);

                //Use DrawLine. If there's only one block then this will make one block. If not, it'll make a line to connect it.
                //However an adjustment needs to be made. This will make *thick* lines which we don't want.
                if(NewY < PrevY) { //If new Y is lower than PrevY, use -1
                    Points.AddRange(GeneratePoints(new Line(L.P1.X + DX,PrevY - 1,L.P1.X + DX,NewY)));
                } else if(NewY > PrevY) {//If NewY is higher than PrevY, use +1
                    Points.AddRange(GeneratePoints(new Line(L.P1.X + DX,PrevY + 1,L.P1.X + DX,NewY)));
                } else { //Else, they're the same. Just use DrawBlockAt.
                    Points.Add(new Point(L.P1.X + DX,NewY));
                }
                PrevY = NewY;
            }

            return Points;
        }

        //-[Static Utilities]-------------------------------------------------------------------------------

        /// <summary>Returns a line that's been shifted by DX and by DY</summary>
        /// <param name="L"></param>
        /// <param name="DX"></param>
        /// <param name="DY"></param>
        /// <returns></returns>
        public static Line TranslateLine(Line L,float DX,float DY) {
            if(L is Curve C) { return Curve.TranslateCurve(C,DX,DY); }
            return new Line(L.P1F.X + DX,L.P1F.Y + DY,
                            L.P2F.X + DX,L.P2F.Y + DY);
        }

        /// <summary>Scales a line's length up or down, anchored on P1</summary>
        /// <param name="L"></param>
        /// <param name="scale"></param>
        /// <returns></returns>
        public static Line P1ScaleLine(Line L, double scale) {
            if(L is Curve) { throw new NotSupportedException(); }

            //Actually soy un bobo this is easy
            float NewP2X = Convert.ToSingle(L.P1F.X + (L.DX * scale));
            float NewP2Y = Convert.ToSingle(L.P1F.Y + (L.DY * scale));
            return new Line(L.P1F,new PointF(NewP2X,NewP2Y));
        }

        /// <summary>Scales a line's length up or down, anchored on P2</summary>
        /// <param name="L"></param>
        /// <param name="scale"></param>
        /// <returns></returns>
        public static Line P2ScaleLine(Line L,double scale) {
            if(L is Curve) { throw new NotSupportedException(); }

            float NewP1X = Convert.ToSingle(L.P2F.X - (L.DX * scale));
            float NewP1Y = Convert.ToSingle(L.P2F.Y - (L.DY * scale));
            return new Line(new PointF(NewP1X,NewP1Y),L.P2F); 
        }

        /// <summary>Scales a line's length up or down, anchored on a center point P3</summary>
        /// <param name="L"></param>
        /// <param name="scale"></param>
        /// <returns></returns>
        public static Line CenterScaleLine(Line L,double scale) {

            if(L is Curve C) { return Curve.ScaleCurve(C,scale); }

            //Let's find the center by doing this:
            PointF P3 = L.Center;

            //We'll keep it as doubles just for extra precision for later.

            //Get  half the scale. This will be useful later.
            double ScaleHalf = scale * .5;

            //We're essentially going to concatenate two lines of half length, one starting from a new P1 to P3, and P3 to a new P2
            //but we're not creating one line. We're going to use these imaginary lines to find where P1 and P2 are.

            //P1
            float X1 = Convert.ToSingle(P3.X - (L.DX * ScaleHalf));
            float Y1 = Convert.ToSingle(P3.Y - (L.DY * ScaleHalf));

            //P2
            float X2 = Convert.ToSingle(P3.X + (L.DX * ScaleHalf));
            float Y2 = Convert.ToSingle(P3.Y + (L.DY * ScaleHalf));

            //Using scalehalf we avoid having to divide DX and DY by half. They're mathematically equivalent.

            //Now that we have our points we can build the new line
            return new Line(X1,Y1,X2,Y2);

            //And bada bing bada boom we're done.

        }

        /// <summary>Converts a PointF to Point</summary>
        /// <returns></returns>
        internal static Point ConvertToPoint(PointF PF) {return new Point(Convert.ToInt32(PF.X),Convert.ToInt32(PF.Y));}

        /// <summary>Converts a  Point to PointF</summary>
        /// <returns></returns>
        internal static PointF ConvertToPointF(Point P) { return new PointF(P.X,P.Y); }

    }
}
