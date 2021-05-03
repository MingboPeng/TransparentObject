
using Rhino.Display;
using Rhino.Geometry;
using System.Drawing;

namespace TransparentRhinoObject
{
    public class RoomObject: Rhino.DocObjects.Custom.CustomBrepObject
    {
        public RoomObject()
        {
        }

        public RoomObject(Rhino.Geometry.Brep brep) : base(brep)
        {
        }
        public override string ShortDescription(bool plural)
        {
            return plural ? "Honeybee Rooms" : "Honeybee Room";
        }

      
        protected override void OnDraw(DrawEventArgs e)
        {

            if (e.Display.DrawingSurfaces)
            {

                var material = new DisplayMaterial(Color.FromArgb(230, 180, 60), 0.2);
                material.BackDiffuse = Color.FromArgb(230, 180, 60);
                material.IsTwoSided = true;
                var m = new Mesh();
                var meshs = Mesh.CreateFromBrep(this.BrepGeometry, MeshingParameters.Default);
                m.Append(meshs);
                e.Display.DrawBrepWires(this.BrepGeometry, this.Attributes.DrawColor(e.RhinoDoc), this.Attributes.WireDensity);
                e.Display.DrawMeshShaded(m, material);

            }
            else
            {
                base.OnDraw(e);
            }


        }

     

    }
}
