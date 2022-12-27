using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Architecture;

namespace BLEANarq.InternalClasses
{
    public class SpatialObjectWrapper :INotifyPropertyChanged
    {
        public string Name { get; set; }  
        public double Area { get; set; }    
        public string Number { get; set; }

        public string Level { get; set; }

        public ElementId Id { get; set; }   

        private bool _IsSelected;

        public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public bool IsSelected
        {
            get { return _IsSelected; } 
            set { _IsSelected = value; RaisePropertyChanged(nameof(IsSelected)); }
        }

        public SpatialObjectWrapper(SpatialElement room)
        {
            Name = room.Name;
            Area = room.Area;
            Number = room.Number;
            Level = room.Level.Name;
            Id = room.Id;
        }
    }
}
