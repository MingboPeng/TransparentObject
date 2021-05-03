
using Rhino.Display;
using Rhino.Geometry;
using System.Drawing;

namespace TransparentRhinoObject
{
    public class ShadeObject: Rhino.DocObjects.Custom.CustomBrepObject
    {
        public ShadeObject()
        {
        }

        public ShadeObject(Rhino.Geometry.Brep brep) : base(brep)
        {
        }
        public override string ShortDescription(bool plural)
        {
            return plural ? "Honeybee Shades" : "Honeybee Shade";
        }

      
        protected override void OnDraw(DrawEventArgs e)
        {

            if (e.Display.DrawingSurfaces)
            {
                var material = new DisplayMaterial(Color.FromArgb(120, 75, 190), 0.2);
                var mesh = Mesh.CreateFromBrep(this.BrepGeometry, MeshingParameters.Default)[0];
                e.Display.DrawBrepWires(this.BrepGeometry, this.Attributes.DrawColor(e.RhinoDoc), this.Attributes.WireDensity);
                e.Display.DrawMeshShaded(mesh, material);

            }
            else
            {
                base.OnDraw(e);
            }


        }

     

    }
}
