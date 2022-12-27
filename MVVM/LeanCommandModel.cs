using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Architecture;
using Autodesk.Revit.UI;
using BLEANarq.InternalClasses;

namespace BLEANarq.MVVM
{
    public class LeanCommandModel
    {
        public UIApplication UiApp { get;}
        public Document Doc { get; }
        public LeanCommandModel(UIApplication uiapp)
        {
            UiApp = uiapp;
            Doc = uiapp.ActiveUIDocument.Document;
        }

        public ObservableCollection<SpatialObjectWrapper> CollectSpatialObjects()
        {
            /// to be continueeeeeee....
            /// var 
            /// 
            var spatialObjs = new FilteredElementCollector(Doc)
                .OfClass(typeof(SpatialElement))
                .WhereElementIsNotElementType()
                .Cast<SpatialElement>()
                .Where(x => x is Room)
                .Select(x => new SpatialObjectWrapper(x));

            return new ObservableCollection<SpatialObjectWrapper>(spatialObjs); 

        }

        public void Delete(List<SpatialObjectWrapper> selected)
        {
            var ids = selected.Select(x => x.Id).ToList();  
            using(Transaction trans = new Transaction(Doc,"Deleting Rooms"))
            {
                trans.Start();
                Doc.Delete(ids);
                trans.Commit();
            }
                
        }



    }
}
