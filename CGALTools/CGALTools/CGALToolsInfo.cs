using Grasshopper;
using Grasshopper.Kernel;
using System;
using System.Drawing;

namespace CGALTools
{
    public class CGALToolsInfo : GH_AssemblyInfo
    {
        public override string Name => "CGALTools";

        //Return a 24x24 pixel bitmap to represent this GHA library.
        public override Bitmap Icon => null;

        //Return a short string describing the purpose of this GHA library.
        public override string Description => "";

        public override Guid Id => new Guid("e720d179-7a89-45e5-9e30-6510e81fc072");

        //Return a string identifying you or your company.
        public override string AuthorName => "";

        //Return a string representing your preferred contact details.
        public override string AuthorContact => "";
    }
}