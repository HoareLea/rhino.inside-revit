using System;
using System.Linq;
using Grasshopper.Kernel;
using DB = Autodesk.Revit.DB;
namespace RhinoInside.Revit.GH.Components
{
  public class ActiveDocument : DocumentComponent
  {
    public override Guid ComponentGuid => new Guid("36c6c47c-6469-4e94-a848-1b14fc50eb14");
    public override GH_Exposure Exposure => GH_Exposure.primary;
    protected override DB.ElementFilter ElementFilter => new Autodesk.Revit.DB.ElementIsElementTypeFilter(true);

    public ActiveDocument() : base(
      "ActiveDocument", "ActiveDocument",
      "Get active Document",
      "Revit", "Document")
    {
    }

    protected override void RegisterInputParams(GH_InputParamManager manager)
    {
      
    }

    protected override void RegisterOutputParams(GH_OutputParamManager manager)
    {
      manager.AddGenericParameter("ActiveDocument", "ActiveDocument", "Active Document", GH_ParamAccess.item);
    }

    protected override void TrySolveInstance(IGH_DataAccess DA)
    {
      DA.DisableGapLogic();
      DA.SetData("ActiveDocument", Revit.ActiveDBDocument);
    }
  }
}
