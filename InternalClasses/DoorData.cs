using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.DB;

namespace BLEANarq.InternalClasses
{
    public  class DoorData : DoorClass
    {
        public DoorData(Element door)
        {
            Parameter par = door.get_Parameter(BuiltInParameter.DOOR_FINISH);
            string dFinish;

            if(par.HasValue == true)
            {
                dFinish = par.AsString();
            }
            else
            {
                dFinish = "";
            }

            _id = door.UniqueId;
            FamilyType = door.Name;
            Mark = door.get_Parameter(BuiltInParameter.ALL_MODEL_MARK).AsString();
            DoorFinish = dFinish;
        }

    }
}
