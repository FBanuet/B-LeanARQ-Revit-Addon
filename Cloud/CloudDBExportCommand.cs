using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.Attributes;
using System.Net;

using BLEANarq.InternalClasses;

namespace BLEANarq.Cloud
{
    [Transaction(TransactionMode.ReadOnly)]
    public class CloudDBExportCommand : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {

            UIApplication uiapp = commandData.Application;
            UIDocument uidoc = commandData.Application.ActiveUIDocument;
            Document doc = uidoc.Document;

            FilteredElementCollector collector = new FilteredElementCollector(doc).OfClass(typeof(FamilyInstance))
                .OfCategory(BuiltInCategory.OST_Doors);
            Result result = ExportBatch(collector, ref message);

            if(result == Result.Succeeded)
            {
                TaskDialog.Show("DOOOOOOR", "PRUEBA UNO FINALIZADA CON EXITO");
            }
            else
            {
                TaskDialog.Show("DOOOOOOR", "ALGO FALLO!!!!!!, UN ERROR FATAL");
            }

            return Result.Succeeded;
        }

        public static Result ExportBatch(FilteredElementCollector doors, ref string message)
        {
            List<DoorClass> Datadoors = new List<DoorClass>();


            HttpStatusCode statusCode;
            string jsonResponse, errorMessage;
            Result result = Result.Succeeded;

            foreach (Element ele in doors)
            {
                Datadoors.Add(new DoorData(ele));

            }
            statusCode = DoorAPIcs.PostBatch(out jsonResponse, out errorMessage, "doors", Datadoors);

            if((int) statusCode ==0)
            {
                message = errorMessage;
                result = Result.Failed;
            }

            return result;
        }
    }
}
