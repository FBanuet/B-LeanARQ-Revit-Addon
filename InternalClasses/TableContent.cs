using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLEANarq.InternalClasses
{
    public class TableContent
    {
        private string _ID;
        private string _NIVEL;
        private string _CATEGORY;
        private string _VOLUME;

        public string ID 
        { 
            get => _ID; set => _ID = value; 
        }
        public string NIVEL 
        {
            get => _NIVEL; set => _NIVEL = value;
        }
        public string CATEGORY 
        {
            get => _CATEGORY; set => _CATEGORY = value; 
        }
        public string VOLUME 
        {
            get => _VOLUME; set => _VOLUME = value;
        }
    }
}
