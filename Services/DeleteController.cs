using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;

namespace BLEANarq.Services
{
    public  class DeleteController
    {
        public UIApplication UiApp { get; }
        public Document Doc { get; }

        public UIDocument UiDoc { get; }


        #region Constructor
        public DeleteController(UIApplication uiapp)
        {
            UiApp = uiapp;
            UiDoc = uiapp.ActiveUIDocument;
            Doc = UiDoc.Document;

        }

        #endregion

        public void Delete()
        {
            UIDocument uidoc = UiDoc;
            Document doc = uidoc.Document;  
            //Selection sel = uidoc.Selection; 
            Element ele = PickElement(uidoc);
            while(ele != null)
            {
                using (Transaction t = new Transaction(doc, "Delete Element"))
                {
                    t.Start();
                    doc.Delete(ele.Id);
                    t.Commit();
                }
                ele = PickElement(uidoc);
            }
        }

        private Element PickElement(UIDocument uidoc)
        {
            Document doc = uidoc.Document;
            Selection sel = uidoc.Selection;
            Element element = null;
            try
            {
                var reference = sel.PickObject(ObjectType.Element);
                element = doc.GetElement(reference);
            }
            catch(Exception ex)
            {

            }
            return element;
           
        }

    }
}
