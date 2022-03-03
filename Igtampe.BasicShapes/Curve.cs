using System;
using System.Drawing;
using System.Collections.Generic;

namespace Igtampe.BasicShapes {
    /// <summary>Class that holds a curve</summary>
    public class Curve :Line{

        //-[FIELDS]-------------------------------------------------------------------------------

        /// <summary>Center of the curve</summary>
        public new PointF Center { get; protected set; }

        /// <summary>Radius of the curve</summary>
        public double R { get; protected set; }

        /// <summary>Angle the curve starts at</summary>
        public double A1 { get; protected set; }

        /// <summary>Angle the curve stops at</summary>
        public double A2 { get; protected set; }

        /// <summary>List of all points this line has</summary>
        public new List<Point> Points {
            protected set { points = value; }
            get {
                if(points is null) { points = GeneratePoints(this); }
                return points;
            }
        }

        //-[Constructor]-------------------------------------------------------------------------------

        /// <summary>Creates a curve from points rather than pointFs</summary>
        /// <param name="Center"></param>
        /// <param name="Radius"></param>
        /// <param name="A1"></param>
        /// <param name="A2"></param>
        public Curve(Point Center,double Radius,double A1,double A2) :this(ConvertToPointF(Center),Radius,A1,A2) { }

        /// <summary>Creates a curve</summary>
        /// <param name="Center"></param>
        /// <param name="Radius"></param>
        /// <param name="A1">Start Angle in DEGREES</param>
        /// <param name="A2">End Angle in DEGREES</param>
        public Curve(PointF Center, double Radius, double A1, double A2):base(CalculatePoint(A1,Center,Radius),CalculatePoint(A2,Center,Radius)) {
            this.Center = Center;
            R = Radius;

            if(A2 > A1) { //Ensure A1 is the smaller one
                this.A1 = A1;
                this.A2 = A2;
            } else {
                this.A1 = A2;
                this.A2 = A1;
            }

            //Just for safety, since this curve may be used as a Line object, we'll generate the points now so that the Line Object GeneratePoints isn't used.
            points = GeneratePoints(this);

        }

        //-[Methods]-------------------------------------------------------------------------------

        /// <summary>Returns true if obj is a curve and its A1, A2, and Center are equal to this curve's</summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj) {
            if(obj is Curve C2) {
                return A1 == C2.A1 && A2 == C2.A2 && Center == C2.Center;
            }
            return base.Equals(obj);
        }

        /// <summary>Gets a hashcode for this curve</summary>
        /// <returns>The hashcode of the center point</returns>
        public override int GetHashCode() {
            return Center.GetHashCode() ;
        }

        /// <summary>Returns a string representation of this curve</summary>
        /// <returns></returns>
        public override string ToString() {return "Curve from " + A1 + " to " + A2 + " with center " + Center + " and radius " + R;}

        /// <summary>Generates the points for a curve C</summary>
        /// <param name="C"></param>
        public static List<Point> GeneratePoints(Curve C) {

            List<Point> NPoints = new List<Point>();

            //We're going for a little finer detail here.
            for(double A = C.A1; A <= C.A2; A+=0.5) {
                var P = ConvertToPoint(CalculatePoint(A, C.Center, C.R));
                if (!NPoints.Contains(P)) { NPoints.Add(P); } //Please no duplicates
            }

            return NPoints;
        
        }

        //-[Static Fields]-------------------------------------------------------------------------------

        /// <summary>Converts degrees to radians</summary>
        internal static double DegToRadians(double Degree) { return Degree * (Math.PI / 180); }

        /// <summary>Calculates a point based on its angle (in degrees), a center point, and the radius</summary>
        /// <param name="Angle"></param>
        /// <param name="Center"></param>
        /// <param name="Radius"></param>
        /// <returns></returns>
        internal static PointF CalculatePoint(double Angle,PointF Center,double Radius) {
            return new PointF(Convert.ToSingle(Center.X + (Math.Cos(DegToRadians(Angle))*Radius)),Convert.ToSingle(Center.Y + (Math.Sin(DegToRadians(Angle))*Radius)));
        }

        /// <summary>Returns a line that's been shifted by DX and by DY</summary>
        /// <param name="L"></param>
        /// <param name="DX"></param>
        /// <param name="DY"></param>
        /// <returns></returns>
        public static Curve TranslateCurve(Curve L,float DX,float DY) {return new Curve(new PointF(L.Center.X + DX,L.Center.Y + DY),L.R,L.A1,L.A2);}
    
        /// <summary>Scales a line's length up or down, anchored on a center point P3</summary>
        /// <param name="L"></param>
        /// <param name="scale"></param>
        /// <returns></returns>
        public static Curve ScaleCurve(Curve L,double scale) {return new Curve(L.Center,L.R * scale,L.A1,L.A2);}

    }
}
