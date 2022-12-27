using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using BLEANarq.ExternalEvents;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Events;

namespace BLEANarq.Views
{
    /// <summary>
    /// Lógica de interacción para DeleteView.xaml
    /// </summary>
    public partial class DeleteView : Window
    {
        public ExternalEvent deleteExternalEvent { get; set; } = DeleteExternalEventHandler.Create();
        public DeleteView()
        {
            InitializeComponent();
            InitializeSize();
            InitializeButtons();


        }
        private void InitializeButtons()
        {
            ButtonDelete.Height = 24;
            ButtonDelete.Width = 128;
            ButtonDelete.Content = "Delete";
            ButtonDelete.Click += (s, e) =>
            {
                deleteExternalEvent.Raise();
            };
        }
        public void InitializeSize()
        {
            this.SizeToContent = SizeToContent.WidthAndHeight;
            this.Topmost = true;
            this.ShowInTaskbar = false; 
            this.ResizeMode = ResizeMode.NoResize;  
            this.WindowStartupLocation = WindowStartupLocation.CenterOwner;
        }
    }
}
