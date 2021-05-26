using System;
using System.Collections.Generic;
using System.Drawing;

namespace Igtampe.BasicShapes {
    public class Polygon {
        
        //-[FIELDS]-------------------------------------------------------------------------------

        /// <summary>All the lines that make up this polygon</summary>
        public Line[] Lines { protected set; get; }

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

        //-[Constructors]-------------------------------------------------------------------------------


        /// <summary>Translates a Polygon P by DX and DY, by individually moving each line within it.</summary>
        /// <param name="P"></param>
        /// <param name="DX"></param>
        /// <param name="DY"></param>
        /// <returns></returns>
        public static Polygon TranslatePolygon(Polygon P,int DX,int DY) {

            List<Line> NewLines = new List<Line>();
            foreach(Line L in Lines) {NewLines.Add(Line.TranslateLine(L,DX,DY));}

            return new Polygon(NewLines.ToArray());

        }


    }
}
