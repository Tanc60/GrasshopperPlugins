using Grasshopper.Kernel;
using Grasshopper.Kernel.Types;
using Rhino.Geometry;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CGALTools
{
    public class CGALToolsComponent : GH_Component
    {
        public CGALToolsComponent()
          : base("CGALOffset", "CGALOffset",
            "Offset Tool",
            "CGAL", "Tools")
        {
        }

        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            pManager.AddCurveParameter("Polygon", "P", "Offset Polygon", GH_ParamAccess.item);
            pManager.AddNumberParameter("Distance", "D", "Amount to offset", GH_ParamAccess.item, 1);
        }

        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {
            pManager.AddCurveParameter("OffsetResult", "R", "Offset Result", GH_ParamAccess.list);
        }

        protected override void SolveInstance(IGH_DataAccess DA)
        {
            Curve polygonCrv = null;
            double distance = 1;

            if (!DA.GetData(0, ref polygonCrv)) return;
            if (!DA.GetData(1, ref distance)) return;

            if (!polygonCrv.IsClosed) return;
            if (!polygonCrv.IsPolyline()) return;
            var polygon = polygonCrv as PolylineCurve;

            //transform the polygon
            var pts = polygon.ToPolyline().ToArray();
            Plane.FitPlaneToPoints(pts, out Plane plane0);
            var t = Transform.PlaneToPlane(plane0, Plane.WorldXY);
            if (!polygon.Transform(t)) return;

            var points = polygon.ToPolyline().ToArray();

            //check the direction
            if (IsClockwise(points))
            {
                points = points.Reverse().ToArray();
            }
            Array.Resize(ref points, points.Length - 1);

            //calculator the offset result
            var interiorList = PolygonOffset.OffsetPolygon(GeometryConversion.RhinoPoint3ds2CGALPoint2ds(points), distance);
            List<GH_Curve> result = new List<GH_Curve>();
            foreach (var interior in interiorList)
            {
                var pointArray = GeometryConversion.CGALPolygon22RhinoPoint3ds(interior);
                Array.Resize(ref pointArray, pointArray.Length + 1);
                pointArray[pointArray.Length - 1] = pointArray[0];
                var resPolygon = new PolylineCurve(pointArray);

                //transform back
                if (!resPolygon.Transform(Transform.PlaneToPlane(Plane.WorldXY, plane0))) return;
                result.Add(new GH_Curve(resPolygon));
            }

            // Finally assign the spiral to the output parameter.
            DA.SetDataList(0, result);
        }

        private bool IsClockwise(Point3d[] polygon)
        {
            double signedArea = 0.0;

            for (int i = 0; i < polygon.Length; i++)
            {
                Point3d current = polygon[i];
                Point3d next = polygon[(i + 1) % polygon.Length];
                signedArea += (next.X - current.X) * (next.Y + current.Y);
            }

            return signedArea >= 0;
        }

        /// <summary>
        /// The Exposure property controls where in the panel a component icon
        /// will appear. There are seven possible locations (primary to septenary),
        /// each of which can be combined with the GH_Exposure.obscure flag, which
        /// ensures the component will only be visible on panel dropdowns.
        /// </summary>
        public override GH_Exposure Exposure => GH_Exposure.primary;

        /// <summary>
        /// Provides an Icon for every component that will be visible in the User Interface.
        /// Icons need to be 24x24 pixels.
        /// You can add image files to your project resources and access them like this:
        /// return Resources.IconForThisComponent;
        /// </summary>
        protected override System.Drawing.Bitmap Icon
        {
            get { return Properties.Resources.icon; }
        }

        /// <summary>
        /// Each component must have a unique Guid to identify it.
        /// It is vital this Guid doesn't change otherwise old ghx files
        /// that use the old ID will partially fail during loading.
        /// </summary>
        public override Guid ComponentGuid => new Guid("810a89a8-c839-49f3-82ac-d9701c007049");
    }
}