using Rhino;
using Rhino.Commands;
using Rhino.DocObjects;
using Rhino.Geometry;
using Rhino.Input;
using Rhino.Input.Custom;
using System;
using System.Collections.Generic;
using System.Linq;

namespace TestPlugin
{
    public class TestCommand : Command
    {
        public TestCommand()
        {
            // Rhino only creates one instance of each command class defined in a
            // plug-in, so it is safe to store a refence in a static property.
            Instance = this;
        }

        ///<summary>The only instance of this command.</summary>
        public static TestCommand Instance { get; private set; }

        ///<returns>The command name as it appears on the Rhino command line.</returns>
        public override string EnglishName => "TestCommand";

        protected override Result RunCommand(RhinoDoc doc, RunMode mode)
        {
            Rhino.DocObjects.ObjRef objref;
            var rc = RhinoGet.GetOneObject("Select Curve", false, ObjectType.Curve, out objref);
            if (rc != Result.Success)
                return rc;
            var curve = objref.Curve();
            var a = new Mybox(10);
            RhinoApp.WriteLine( a.GetVolumn().ToString());

            var view = doc.Views.ActiveView;
            var plane = view.ActiveViewport.ConstructionPlane();
            // Create a construction plane aligned bounding box
            var bbox = curve.GetBoundingBox(plane);

            if (bbox.IsDegenerate(doc.ModelAbsoluteTolerance) > 0)
            {
                RhinoApp.WriteLine("the curve's bounding box is degenerate (flat) in at least one direction so a box cannot be created.");
                return Result.Failure;
            }
            var brep = Brep.CreateFromBox(bbox);
            doc.Objects.AddBrep(brep);
            doc.Views.Redraw();
            return Result.Success;
        }
    }
    class Mybox
    {
        public double Size { get; set; }
        public Mybox(double size) 
        {
            Size = size;
        }
        public double GetVolumn()
        {
            return Math.Pow(Size, 3);
        }
    }
}
