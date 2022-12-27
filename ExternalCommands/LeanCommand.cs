using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using BLEANarq.MVVM;
using BLEANarq.UX;


namespace BLEANarq.ExternalCommands
{
    [Transaction(TransactionMode.Manual)]
    [Regeneration(RegenerationOption.Manual)]
    public class LeanCommand : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {

            UIApplication uiapp = commandData.Application;
            LeanCommandModel model = new LeanCommandModel(uiapp);
            LeanCommandViewModel viewModel = new LeanCommandViewModel(model);
            LeanCommandViewI view = new LeanCommandViewI();
            view.DataContext = viewModel;

            var _unused = new System.Windows.Interop.WindowInteropHelper(view);
            _unused.Owner = System.Diagnostics.Process.GetCurrentProcess().MainWindowHandle;

            view.ShowDialog();


            return Result.Succeeded;
        }
    }
}
