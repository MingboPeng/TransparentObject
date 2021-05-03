using Rhino;
using Rhino.Commands;
using Rhino.Geometry;
using Rhino.Input;
using Rhino.DocObjects;
using System;
using System.Collections.Generic;

namespace TransparentRhinoObject
{
    public class TransparentRhinoObjectCommand : Command
    {
        public TransparentRhinoObjectCommand()
        {
            // Rhino only creates one instance of each command class defined in a
            // plug-in, so it is safe to store a refence in a static property.
            Instance = this;
        }

        ///<summary>The only instance of this command.</summary>
        public static TransparentRhinoObjectCommand Instance
        {
            get; private set;
        }

        ///<returns>The command name as it appears on the Rhino command line.</returns>
        public override string EnglishName
        {
            get { return "TransparentRhinoObjectCommand"; }
        }

        protected override Result RunCommand(RhinoDoc doc, RunMode mode)
        {

            var objs = doc.Objects;
            foreach (var item in objs)
            {
                var brep = item as BrepObject;
                if (brep == null) continue;

                var geo = brep.BrepGeometry;
                if (brep.BrepGeometry.Faces.Count > 1)
                {
                    var room = new RoomObject(geo);
                    doc.Objects.Replace(new ObjRef(brep.Id), room);
                }
                else
                {
                    var shade = new ShadeObject(geo);
                    doc.Objects.Replace(new ObjRef(brep.Id), shade);
                }
            }

            doc.Views.Redraw();

            return Result.Success;
        }
    }
}
