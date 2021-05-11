using System;
using System.Drawing;
using System.Collections.Generic;
using System.Text;

namespace Igtampe.BasicShapes {
    public class Curve :Line{

        /// <summary>Center of the curve</summary>
        public Point Center { get; protected set; }

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


        /// <summary>Creates a curve</summary>
        /// <param name="Center"></param>
        /// <param name="Radius"></param>
        /// <param name="A1">Start Angle in DEGREES</param>
        /// <param name="A2">End Angle in DEGREES</param>
        public Curve(Point Center, double Radius, double A1, double A2):base(CalculatePoint(A1,Center,Radius),CalculatePoint(A2,Center,Radius)) {
            this.Center = Center;
            R = Radius;

            if(A2 > A1) { //Ensure A1 is the smaller one
                this.A1 = A1;
                this.A2 = A2;
            } else {
                this.A1 = A2;
                this.A2 = A1;
            }            

        }

        /// <summary>Returns true if obj is a curve and its A1, A2, and Center are equal to this curve's</summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj) {
            if(obj is Curve C2) {
                return A1 == C2.A1 && A2 == C2.A2 && Center == C2.Center;
            }
            return base.Equals(obj);
        }

        public override string ToString() {return "Curve from " + A1 + " to " + A2 + " with center " + Center + " and radius " + R;}

        /// <summary>Generates the points for a curve C</summary>
        /// <param name="C"></param>
        public static List<Point> GeneratePoints(Curve C) {

            List<Point> Points = new List<Point>();

            //We're going for a little finer detail here.
            for(double A = C.A1; A <= C.A2; A+=0.5) {
                Points.Add(CalculatePoint(A,C.Center,C.R));
            }

            return Points;
        
        }

        /// <summary>Converts degrees to radians</summary>
        private static double DegToRadians(double Degree) { return Degree * (Math.PI / 180); }

        /// <summary>Calculates a point based on its angle (in degrees), a center point, and the radius</summary>
        /// <param name="Angle"></param>
        /// <param name="Center"></param>
        /// <param name="Radius"></param>
        /// <returns></returns>
        private static Point CalculatePoint(double Angle,Point Center,double Radius) {
            return new Point(Convert.ToInt32(Center.X + (Math.Cos(DegToRadians(Angle))*Radius)),Convert.ToInt32(Center.Y + (Math.Sin(DegToRadians(Angle))*Radius)));
        }


    }
}
