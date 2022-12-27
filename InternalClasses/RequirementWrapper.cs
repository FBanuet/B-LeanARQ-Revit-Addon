using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLEANarq.InternalClasses
{
    public class RequirementWrapper
    {
        public string FamilyName { get; set; }  
        public string FamilyType { get; set; }

        public int RequiredCount { get; set; }

        public RequirementWrapper(string famname, string famtype, int reqcount)
        {
            FamilyName = famname;
            FamilyType = famtype;
            RequiredCount = reqcount;   

        }
    }
}
