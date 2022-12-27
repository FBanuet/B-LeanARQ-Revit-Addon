using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using BLEANarq.InternalClasses;

namespace BLEANarq.ExternalCommands
{
    public class FourthButtonCommand : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {

            try
            {
                var app = commandData.Application;
                DockablePanelUtils.ShowDockablePanel(app);
            }
            catch (Exception ex)
            {
                TaskDialog.Show("FAILED!", ex.Message);
                return Result.Failed;
            }



            return Result.Succeeded;
        }
    }
}
