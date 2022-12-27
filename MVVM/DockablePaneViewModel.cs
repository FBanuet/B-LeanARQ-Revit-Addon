using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using BLEANarq.InternalClasses;

namespace BLEANarq.MVVM
{
    public class DockablePaneViewModel : ViewModelBase
    {
        public RelayCommand LoadRequirements { get; set; }
        public DockablePaneViewModel()
        {
            LoadRequirements = new RelayCommand(OnLoadRequirements);

        }

        private void OnLoadRequirements()
        {
            var filePath = DialogUtils.SelectFile();
            if (string.IsNullOrWhiteSpace(filePath))
                return;
        }
    }
}
