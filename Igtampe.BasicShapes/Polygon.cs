using System;
using System.Collections.Generic;
using System.Drawing;

namespace Igtampe.BasicShapes {
    public class Polygon {
        
        //-[FIELDS]-------------------------------------------------------------------------------

        /// <summary>All the lines that make up this polygon</summary>
        public Line[] Lines { protected set; get; }

        /// <summary>Cache for the center</summary>
        private PointF center = PointF.Empty;

        /// <summary>Holds a point for the center of the rectangle</summary>
        public PointF Center {
            get {
                if(center == PointF.Empty) { center = GetPolygonCenter(this); }
                return center;
            }
        }

        private RectangleF boundingRectangle = Rectangle.Empty;

        /// <summary>Holds a rectangle that bounds this polygon</summary>
        public RectangleF BoundingRectangle { get {
                if(boundingRectangle == RectangleF.Empty) {boundingRectangle = GetBoundingRectangle(this);  }
                return boundingRectangle;
            } 
        }

        //-[Constructors]-------------------------------------------------------------------------------
        
        /// <summary>Creates a polygon from a set of lines and verifies that it is valid.</summary>
        /// <param name="AllLines"></param>
        public Polygon(Line[] AllLines) {
            Lines = AllLines;

            //All lines SHOULD intersect at the endpoints with the next one
            for(int i = 0; i < Lines.Length-1; i++) {
                if(!Lines[i].Intersects(Lines[i + 1])) { throw new ArgumentException("Polygon is not closed or is not sequential"); }
            }

            //Check the start and end too.
            if(!Lines[0].Intersects(Lines[Lines.Length - 1])) { throw new ArgumentException("Polygon is not closed or is not sequential"); }

            //OK now we're done we have a valid polygon. Let's go.

        }

        /// <summary>Creates a Polygon from a list of points, creating lines to and from them sequentially.</summary>
        /// <param name="Points"></param>
        public Polygon(Point[] Points) {
            //Make the lines then pass it off to the next one.
            List<Line> L = new List<Line>();
            for(int i = 0; i < Points.Length - 1; i++) { L.Add(new Line(Points[i],Points[i + 1])); }

            L.Add(new Line(Points[0],Points[Points.Length - 1]));
            Lines = L.ToArray();

            //I would check but this procedure works so shh
        }

        /// <summary>Creates a Polygon from a list of points, creating lines to and from them sequentially.</summary>
        /// <param name="Points"></param>
        public Polygon(PointF[] Points) {
            //Make the lines then pass it off to the next one.
            List<Line> L = new List<Line>();
            for (int i = 0; i < Points.Length - 1; i++) { L.Add(new Line(Points[i], Points[i + 1])); }

            L.Add(new Line(Points[0], Points[Points.Length - 1]));
            Lines = L.ToArray();

            //I would check but this procedure works so shh
        }

        //-[Constructors]-------------------------------------------------------------------------------


        /// <summary>Translates a Polygon P by DX and DY, by individually moving each line within it.</summary>
        /// <param name="P"></param>
        /// <param name="DX"></param>
        /// <param name="DY"></param>
        /// <returns></returns>
        public static Polygon TranslatePolygon(Polygon P,int DX,int DY) {

            List<Line> NewLines = new List<Line>();
            foreach(Line L in P.Lines) {NewLines.Add(Line.TranslateLine(L,DX,DY));}

            return new Polygon(NewLines.ToArray());

        }

        /// <summary>Scales a polygon anchored at its center</summary>
        /// <param name="P"></param>
        /// <param name="Scale"></param>
        /// <returns></returns>
        public static Polygon ScalePolygon(Polygon P,double Scale) {

            //OK INSTEAD OF DOING THIS LINE BY LINE MAYHAPS WE SHOULD DO THIS BY POINTS INSTEAD.

            //The only problem with this will be if someone makes a polygon with a curve in it.
            //Maybe we should do a check for that.
            List<PointF> NewCornerPoints = new List<PointF>();
            List<PointF> VisitedPoints = new List<PointF>();

            foreach (Line l in P.Lines) {
                if (l is Curve) { throw new NotSupportedException("Polygons with Curves are curently not supported by ScalePolygon"); }

                if (!VisitedPoints.Contains(l.P1F)) {
                    VisitedPoints.Add(l.P1F);
                    NewCornerPoints.Add(ScalePointOut(P, l.P1F, Scale));
                } 
                
                if (!VisitedPoints.Contains(l.P2F)) {
                    VisitedPoints.Add(l.P2F);
                    NewCornerPoints.Add(ScalePointOut(P, l.P2F, Scale));
                }
            }

            //Now make a new polygon using the points:
            return new Polygon(NewCornerPoints.ToArray());

            /**
            //List<Line> NewLines = new List<Line>();

            ////For each line:
            //foreach(Line L in P.Lines) {
            //    //Create a new line from the center of the polygon to the line's center
            //    Line CL = new Line(P.Center,L.Center,true);

            //    //Scale it up by Scale, anchored at the center of the polygon (P1)
            //    Line ScaledCL = Line.P1ScaleLine(CL,Scale);

            //    //Translate the Line itself by the difference between CL and ScaledCL
            //    Line NewLine = Line.TranslateLine(L,ScaledCL.DXF - CL.DXF,ScaledCL.DYF - CL.DYF);

            //    //Scale the line itself  anchored at its own center.
            //    NewLines.Add(Line.CenterScaleLine(NewLine,Scale));
            //}

            ////Now that we have all the lines, we should ensure they all intersect.

            ////Line[] RealNewLines = new Line[NewLines.Count] ;
            //List<Line> RealNewLines = new List<Line>();

            //for (int i = 0; i < NewLines.Count-1; i++) {
            //    RealNewLines.Add(new Line(NewLines[i].P1F, NewLines[i + 1].P1F));
            //}

            ////Lastly add one line from the last line's P1 to the first line's P1
            //RealNewLines.Add(new Line(NewLines[NewLines.Count - 1].P1F, NewLines[0].P1F));

            //return new Polygon(RealNewLines.ToArray());
            **/
        }

        protected static PointF ScalePointOut(Polygon P, PointF PointToScale, double Scale) {
            //OK make a line from the center of the polygon to the P1 of this line
            Line CL = new Line(P.Center, PointToScale, true);

            //Scale it up by Scale, anchored at the center of the polygon (P1)
            Line ScaledCL = Line.P1ScaleLine(CL, Scale);

            //Now add P2 (the new corner point to New Corner Points
            if (ScaledCL.P2F != P.Center) { return ScaledCL.P2F; } else { return ScaledCL.P1F; }

        }

        /// <summary>gets a Polygon's center point.</summary>
        /// <param name="P"></param>
        /// <returns></returns>
        private static PointF GetPolygonCenter(Polygon P) {


            RectangleF R = P.BoundingRectangle;

            //once we find the middle of the bounding rectangle, we'll have the middle of the polygon 
            float X = Convert.ToSingle(R.X + (R.Width * .5));
            float Y = Convert.ToSingle(R.Y + (R.Height * .5));

            return new PointF(X,Y);

        }

        /// <summary>Calculates the bounding rectangle of the given polygon.</summary>
        /// <param name="P"></param>
        /// <returns></returns>
        private static RectangleF GetBoundingRectangle(Polygon P) {
            //Itterate through all the points on this thing and find the largest Minimum X, Maximum X, Minimum Y, and Maximum Y
            float MaxY = 0;
            float MinY = 99999999;
            float MaxX = 0;
            float MinX = 99999999;

            foreach(Line L in P.Lines) {
                foreach(Point p in L.Points) {
                    MaxY = Math.Max(p.Y,MaxY);
                    MinY = Math.Min(p.Y,MinY);

                    MaxX = Math.Max(p.X,MaxX);
                    MinX = Math.Min(p.X,MinX);
                }
            }

            //Now that we have that we can build a rectangle:
            return new RectangleF(MinX,MinY,MaxX - MinX,MaxY - MinY);

        }


    }
}
