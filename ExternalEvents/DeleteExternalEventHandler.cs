using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Events;
using BLEANarq.Services;

namespace BLEANarq.ExternalEvents
{
    public class DeleteExternalEventHandler : IExternalEventHandler
    {
        public void Execute(UIApplication app)
        {
            //throw new NotImplementedException();
            new DeleteController(app).Delete();
        }

        public string GetName()
        {
            return this.GetType().Name;
        }

        public static ExternalEvent Create()
        {
            return ExternalEvent.Create(new DeleteExternalEventHandler());
        }
    }
}
