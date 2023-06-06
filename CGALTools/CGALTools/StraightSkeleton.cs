using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CGALDotNet;
using CGALDotNetGeometry;
using CGALDotNet.Polygons;
using CGALDotNetGeometry.Shapes;

namespace CGALTools
{
    class StraightSkeleton
    {
        private PolygonWithHoles2<EIK> _polygon;

        public void CreateSkeleton()
        {
            var instance = PolygonOffset2<EIK>.Instance;
            var skeleton = new List<Segment2d>();
            instance.CreateInteriorSkeleton(_polygon, false, skeleton);
        }
    }
}
