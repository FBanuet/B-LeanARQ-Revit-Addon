using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLEANarq.Views;
using BLEANarq.Services;

namespace BLEANarq.ExternalCommands
{
    [Transaction(TransactionMode.Manual)]
    public class ViewCommandExtEvent : IExternalCommand
    {
        private static DeleteView _deleteView { get; set; }
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIApplication uiapp = commandData.Application;


            if(_deleteView != null)
            {
                _deleteView.Close();
            }



            _deleteView = new DeleteView();
            _deleteView.Show();

            //DeleteController delController  =  new DeleteController(uiapp);
            //delController.Delete();

            return Result.Succeeded;
        }
    }
}
