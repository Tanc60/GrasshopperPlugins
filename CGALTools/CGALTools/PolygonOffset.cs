using CGALDotNet;
using CGALDotNet.Polygons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CGALDotNetGeometry.Numerics;
using Rhino.Runtime;

namespace CGALTools
{
    class PolygonOffset
    {
        public static List<Polygon2<EIK>> OffsetPolygon(Point2d[] points,double distance)
        {

            //Create a polygon to offset.
            Polygon2<EIK> polygon = new Polygon2<EIK>(points);

            //Get the instance to the offset algorithm.
            var instance = PolygonOffset2<EIK>.Instance;

            //If you know the input is good then checking 
            //can be disabled which can increase perform.
            //instance.CheckInput = false;

            //The amount to offset.

            if (distance < 0)
            {
                var interior = new List<Polygon2<EIK>>();
                instance.CreateInteriorOffset(polygon, -distance, interior);

                for (int i = 0; i < interior.Count; i++)
                    interior[i].Print();
                return interior;
            }
            else
            {
                var exterior = new List<Polygon2<EIK>>();
                instance.CreateExteriorOffset(polygon, distance, exterior);
                //The first polygon is the bounding box so ignore.
                exterior.RemoveAt(0);

/*                for (int i = 1; i < exterior.Count; i++)
                    exterior[i].Print();*/
                return exterior;
            }
        }
    }
}
