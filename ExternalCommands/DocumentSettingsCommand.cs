using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using BLEANarq.WinForms;

namespace BLEANarq.ExternalCommands
{
    [Transaction(TransactionMode.Manual)]
    public class DocumentSettingsCommand : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            Document doc = commandData.Application.ActiveUIDocument.Document;
            Category linesCat = doc.Settings.Categories.get_Item(BuiltInCategory.OST_Lines);
            LineTypeForm frm = new LineTypeForm(linesCat.SubCategories);

            frm.ShowDialog();




            return Result.Succeeded;
        }
    }
}
