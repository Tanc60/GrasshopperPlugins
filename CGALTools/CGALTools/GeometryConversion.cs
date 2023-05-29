using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CGALDotNet;
using CGALDotNet.Polygons;
using Grasshopper.Kernel;
using Rhino.Geometry;
using CGALDotNetGeometry;

namespace CGALTools
{
    class GeometryConversion
    {
        public static CGALDotNetGeometry.Numerics.Point2d RhinoPoint3d2CGALPoint2d(Point3d point)
        {
            return new CGALDotNetGeometry.Numerics.Point2d(point.X, point.Y);
        }
        public static CGALDotNetGeometry.Numerics.Point2d[] RhinoPoint3ds2CGALPoint2ds(Point3d[] points)
        {
            var CGALPoints = new CGALDotNetGeometry.Numerics.Point2d[points.Length];
            for (int i = 0; i < points.Length; i++)
            {
                CGALPoints[i]= RhinoPoint3d2CGALPoint2d(points[i]);
            }
            return CGALPoints;
        }

        public static Rhino.Geometry.Point3d CGALPoint2d2RhinoPoint3d(CGALDotNetGeometry.Numerics.Point2d point)
        {
            return new Rhino.Geometry.Point3d(point.x, point.y,0);
        }
        public static Rhino.Geometry.Point3d[] CGALPoint2ds2RhinoPoint3ds(CGALDotNetGeometry.Numerics.Point2d[] points)
        {
            var RhinoPoints = new Rhino.Geometry.Point3d[points.Length];
            for (int i = 0; i < points.Length; i++)
            {
                RhinoPoints[i] = CGALPoint2d2RhinoPoint3d(points[i]);
            }
            return RhinoPoints;
        }
        public static Rhino.Geometry.Point3d[] CGALPolygon22RhinoPoint3ds(Polygon2<EIK> polygon)
        {
            return CGALPoint2ds2RhinoPoint3ds(polygon.ToArray());
        }
    }
}
