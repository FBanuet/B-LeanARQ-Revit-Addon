using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;


namespace BLEANarq.ExternalCommands
{
    [Transaction(TransactionMode.Manual)]
    public class AutomaticVoidLineCommand : IExternalCommand

    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIApplication uiapp = commandData.Application;
            UIDocument uidoc = commandData.Application.ActiveUIDocument;
            Document doc = uidoc.Document;

            #region TOPOLOGY
            XYZ PT1 = uidoc.Selection.PickPoint("SELECCIONE DE FAVOR EL PRIMER VERTICE");
            XYZ PT2 = uidoc.Selection.PickPoint("SELECCIONE DE FAVOR EL SEGUNDO VERTICE");

            XYZ PT3 = new XYZ(PT1.X, PT2.Y, PT1.Z);
            XYZ PT4 = new XYZ(PT2.X, PT1.Y, PT1.Z);

            Line firstLine = Line.CreateBound(PT1, PT2);
            Line secondLine = Line.CreateBound(PT3, PT4);

            #endregion

            Category lineCate = doc.Settings.Categories.get_Item(BuiltInCategory.OST_Lines);
            string lineStyleName = (string)Properties.Settings.Default["NombreLinea"];
            
            try
            {
               lineCate.SubCategories.get_Item(lineStyleName);
            }
            catch (Exception ex)
            {
                TaskDialog.Show("ERROR!!", ex.Message);
                return Result.Cancelled;
            }
            Category cat = lineCate.SubCategories.get_Item(lineStyleName);
            GraphicsStyle estiloGrafico = cat.GetGraphicsStyle(GraphicsStyleType.Projection);   


            using(Transaction t = new Transaction(doc,"DIBUJANDO LINEAS"))
            {
                t.Start();

                try
                {
                    DetailCurve crv1 =  doc.Create.NewDetailCurve(doc.ActiveView, firstLine);
                    DetailCurve crv2 = doc.Create.NewDetailCurve(doc.ActiveView, secondLine);

                    crv1.LineStyle = estiloGrafico;
                    crv2.LineStyle = estiloGrafico;


                    t.Commit();
                }
                catch ( Exception ex)
                {

                    TaskDialog.Show("ERROR!!", ex.Message);
                    t.RollBack();
                }

                
            }

            return Result.Succeeded;
        }
    }
}
