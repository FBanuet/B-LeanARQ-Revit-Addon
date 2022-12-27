using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.UI;
using BLEANarq.MVVM;
using BLEANarq.UX;

namespace BLEANarq.InternalClasses
{
    public static class DockablePanelUtils
    {
        public static void RegisterDockablePane(UIControlledApplication app)
        {
            var vm = new DockablePaneViewModel();
            var v = new DockablePanelPage
            {
                DataContext = vm,
            };

            var data = new DockablePaneProviderData()
            {
                FrameworkElement = v,
                InitialState = new DockablePaneState()
                {
                    DockPosition = DockPosition.Tabbed,
                    TabBehind = DockablePanes.BuiltInDockablePanes.ProjectBrowser
                },
                
            };


            var panelId = new DockablePaneId(new Guid("b7364585-9c42-4575-a4b8-4eefa75fd5ec"));
            try
            {
                app.RegisterDockablePane(panelId, "B-LeanApps", v);
            }
            catch (Exception ex)
            {

            }
        }    
        public static void ShowDockablePanel(UIApplication app)
        {

            var panelId = new DockablePaneId(new Guid("b7364585-9c42-4575-a4b8-4eefa75fd5ec"));
            var dp = app.GetDockablePane(panelId);
            if (dp != null && !dp.IsShown())
                dp?.Show();

        }

    }
}
