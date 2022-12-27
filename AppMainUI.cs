using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Events;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using BLEANarq.InternalClasses;

namespace BLEANarq
{
    public class AppMainUI : IExternalApplication
    {
        public Result OnShutdown(UIControlledApplication application)
        {
            return Result.Succeeded;
        }

        public Result OnStartup(UIControlledApplication application)
        {
            #region Global Parameters
            string RibbonPanelName = "Quantities";
            string RibbonPanelName2 = "Misc";
            string RibbonPanelName3 = "CloudDB";
            string RibbonTabName = "B-Lean";

            Assembly assembly = Assembly.GetExecutingAssembly();
            string assemblyPath = assembly.Location;


            application.CreateRibbonTab(RibbonTabName);
            RibbonPanel ribbonpanel = application.CreateRibbonPanel(RibbonTabName, RibbonPanelName);
            RibbonPanel ribbonpanel2 = application.CreateRibbonPanel(RibbonTabName, RibbonPanelName2);
            RibbonPanel ribbonpanel3 = application.CreateRibbonPanel(RibbonTabName, RibbonPanelName3);
            #endregion


            #region Buttons
            // Create Here Buttons

            PushButton ButtonOne = ribbonpanel.AddItem(new PushButtonData("Button01", "Cuantificar", assemblyPath, "BLEANarq.ExternalCommands.QuantificationsCommand")) as PushButton;
            ButtonOne.ToolTip = "Con ayuda de este comando obtendremos cuantificaciones de manera automàtica";
            ButtonOne.LongDescription = "El comando genera una interfaz gràfica de usuario para el control y analisis de los metrados del proyecto y podremos exportar a excel dichas cantidades";
            ButtonOne.ToolTipImage = GetResourceImage(assembly, "BLEANarq.Resources.PNG-DATARCHCSimgwhite1.png");
            ContextualHelp ayuda = new ContextualHelp(ContextualHelpType.Url, "https://www.datarchitects.com.mx/");
            ButtonOne.SetContextualHelp(ayuda);
            ButtonOne.LargeImage = GetResourceImage(assembly, "BLEANarq.Resources.DATA32.png");
            ButtonOne.Image = GetResourceImage(assembly, "BLEANarq.Resources.DATA16.png");

            

            PushButton ButtonTwo = ribbonpanel2.AddItem(new PushButtonData("Button02", "ElementGrids", assemblyPath, "BLEANarq.ExternalCommands.GridElementLocationCommand")) as PushButton;
            ButtonTwo.ToolTip = "Con ayuda de este comando asignaremos al paràmetro comments la ubicacion de los elementos respecto a los entre ejes";
            ButtonTwo.LongDescription = "El comando aplica la ubicacion de los entre ejes que intersectan con los elementos seleccionados en la interfaz grafica";
            ButtonTwo.ToolTipImage = GetResourceImage(assembly, "BLEANarq.Resources.PNG-DATARCHCSimgwhite1.png");
            ContextualHelp ayuda2 = new ContextualHelp(ContextualHelpType.Url, "https://www.datarchitects.com.mx/");
            ButtonTwo.SetContextualHelp(ayuda2);
            ButtonTwo.LargeImage = GetResourceImage(assembly, "BLEANarq.Resources.DATA32.png");
            ButtonTwo.Image = GetResourceImage(assembly, "BLEANarq.Resources.DATA16.png");

            PushButton ButtonThree = ribbonpanel2.AddItem(new PushButtonData("Button03", "MVVM", assemblyPath, "BLEANarq.ExternalCommands.LeanCommand")) as PushButton;
            ButtonThree.ToolTip = "Con ayuda de este comando asignaremos al paràmetro comments la ubicacion de los elementos respecto a los entre ejes";
            ButtonThree.LongDescription = "El comando aplica la ubicacion de los entre ejes que intersectan con los elementos seleccionados en la interfaz grafica";
            ButtonThree.ToolTipImage = GetResourceImage(assembly, "BLEANarq.Resources.PNG-DATARCHCSimgwhite1.png");
            ContextualHelp ayuda3 = new ContextualHelp(ContextualHelpType.Url, "https://www.datarchitects.com.mx/");
            ButtonThree.SetContextualHelp(ayuda3);
            ButtonThree.LargeImage = GetResourceImage(assembly, "BLEANarq.Resources.DATA32.png");
            ButtonThree.Image = GetResourceImage(assembly, "BLEANarq.Resources.DATA16.png");

            PushButton Buttonfour = ribbonpanel2.AddItem(new PushButtonData("Button04", "DeleteApp", assemblyPath, "BLEANarq.ExternalCommands.ViewCommandExtEvent")) as PushButton;
            Buttonfour.ToolTip = "Movel View Controller Example App using External APP Events";
            Buttonfour.LongDescription = "Seleccionar elementos y borrarlos";
            Buttonfour.ToolTipImage = GetResourceImage(assembly, "BLEANarq.Resources.PNG-DATARCHCSimgwhite1.png");
            ContextualHelp ayuda4 = new ContextualHelp(ContextualHelpType.Url, "https://www.datarchitects.com.mx/");
            Buttonfour.SetContextualHelp(ayuda4);
            Buttonfour.LargeImage = GetResourceImage(assembly, "BLEANarq.Resources.DATA32.png");
            Buttonfour.Image = GetResourceImage(assembly, "BLEANarq.Resources.DATA16.png");

            PushButton ButtonFive = ribbonpanel2.AddItem(new PushButtonData("Button05", "3DDimention", assemblyPath, "BLEANarq.ExternalCommands.IsoDimentioningCommand")) as PushButton;
            ButtonFive.ToolTip = "Acota Trabes, vigas y columnas en una vista 3D";
            ButtonFive.LongDescription = "Seleccionar elementos y acotarlos en vista 3d";
            ButtonFive.ToolTipImage = GetResourceImage(assembly, "BLEANarq.Resources.PNG-DATARCHCSimgwhite1.png");
            ContextualHelp ayuda5 = new ContextualHelp(ContextualHelpType.Url, "https://www.datarchitects.com.mx/");
            ButtonFive.SetContextualHelp(ayuda5);
            ButtonFive.LargeImage = GetResourceImage(assembly, "BLEANarq.Resources.DATA32.png");
            ButtonFive.Image = GetResourceImage(assembly, "BLEANarq.Resources.DATA16.png");

            PushButton BtnSix = ribbonpanel2.AddItem(new PushButtonData("Button06", "AutoVoidLines", assemblyPath, "BLEANarq.ExternalCommands.AutomaticVoidLineCommand")) as PushButton;
            BtnSix.ToolTip = "Dibuje las lineas de vacio de manera automatica en sus vanos y pasos en losas";
            BtnSix.LongDescription = "seleccione 2 vertices o 2 puntos de su vano o paso en losa y automaticamente se dibujaran las lineas de vacio";
            BtnSix.ToolTipImage = GetResourceImage(assembly, "BLEANarq.Resources.PNG-DATARCHCSimgwhite1.png");
            
            BtnSix.SetContextualHelp(ayuda5);
            BtnSix.LargeImage = GetResourceImage(assembly, "BLEANarq.Resources.DATA32.png");
            BtnSix.Image = GetResourceImage(assembly, "BLEANarq.Resources.DATA16.png");

            PushButton BtnSeven = ribbonpanel2.AddItem(new PushButtonData("Button07", "LineStyleSettings", assemblyPath, "BLEANarq.ExternalCommands.DocumentSettingsCommand")) as PushButton;
            BtnSeven.ToolTip = "Configure los estilos de linea a dibujar con el comando";
            BtnSeven.LongDescription = "seleccione 2 vertices o 2 puntos de su vano o paso en losa y automaticamente se dibujaran las lineas de vacio";
            BtnSeven.ToolTipImage = GetResourceImage(assembly, "BLEANarq.Resources.PNG-DATARCHCSimgwhite1.png");

            BtnSeven.SetContextualHelp(ayuda5);
            BtnSeven.LargeImage = GetResourceImage(assembly, "BLEANarq.Resources.DATA32.png");
            BtnSeven.Image = GetResourceImage(assembly, "BLEANarq.Resources.DATA16.png");

            #endregion  

            #region CLOUD BUTTON COMMANDS


            PushButton Cloudbnt1 = ribbonpanel3.AddItem(new PushButtonData("Button06", "Export Data", assemblyPath, "BLEANarq.Cloud.CloudDBExportCommand")) as PushButton;
            Cloudbnt1.ToolTip = "Export Revit selected Element Data to a Mongo DB ATlas CLoud Data Base";
            Cloudbnt1.LongDescription = "Cloud To Revit API - Rest API FORGE";
            Cloudbnt1.ToolTipImage = GetResourceImage(assembly, "BLEANarq.Resources.PNG-DATARCHCSimgwhite1.png");
            ContextualHelp ayuda6 = new ContextualHelp(ContextualHelpType.Url, "https://www.datarchitects.com.mx/");
            Cloudbnt1.SetContextualHelp(ayuda6);
            Cloudbnt1.LargeImage = GetResourceImage(assembly, "BLEANarq.Resources.DATA32.png");
            Cloudbnt1.Image = GetResourceImage(assembly, "BLEANarq.Resources.DATA16.png");

            PushButton Cloudbnt2 = ribbonpanel3.AddItem(new PushButtonData("Button07", "Import Data", assemblyPath, "BLEANarq.Cloud.CloudDBImportCommand")) as PushButton;
            Cloudbnt2.ToolTip = "Import to this Revit Model the Data you connected to an Atlas Mongo DB Cloud Service";
            Cloudbnt2.LongDescription = "Cloud To Revit API - Rest API FORGE";
            Cloudbnt2.ToolTipImage = GetResourceImage(assembly, "BLEANarq.Resources.PNG-DATARCHCSimgwhite1.png");
            ContextualHelp ayuda7 = new ContextualHelp(ContextualHelpType.Url, "https://www.datarchitects.com.mx/");
            Cloudbnt2.SetContextualHelp(ayuda7);
            Cloudbnt2.LargeImage = GetResourceImage(assembly, "BLEANarq.Resources.DATA32.png");
            Cloudbnt2.Image = GetResourceImage(assembly, "BLEANarq.Resources.DATA16.png");

            #endregion

            #region  DOCKABLE PANEL COMMANDS

            PushButton dockablePaneBTN = ribbonpanel3.AddItem(new PushButtonData("ButtonFourth", "ShowDockablePane", assemblyPath, "BLEANarq.ExternalCommands.FourthButtonCommand")) as PushButton;
            dockablePaneBTN.ToolTip = "Export Revit selected Element Data to a Mongo DB ATlas CLoud Data Base";
            dockablePaneBTN.LongDescription = "Cloud To Revit API - Rest API FORGE";
            dockablePaneBTN.ToolTipImage = GetResourceImage(assembly, "BLEANarq.Resources.PNG-DATARCHCSimgwhite1.png");
            ContextualHelp ayuda8 = new ContextualHelp(ContextualHelpType.Url, "https://www.datarchitects.com.mx/");
            dockablePaneBTN.SetContextualHelp(ayuda8);
            dockablePaneBTN.LargeImage = GetResourceImage(assembly, "BLEANarq.Resources.DATA32.png");
            dockablePaneBTN.Image = GetResourceImage(assembly, "BLEANarq.Resources.DATA16.png");

            DockablePanelUtils.RegisterDockablePane(application);

            #endregion





            return Result.Succeeded;
        }

        #region Manejo de recursos externor
        public ImageSource GetResourceImage(Assembly assembly, string imageName)
        {
            try
            {
                Stream resource = assembly.GetManifestResourceStream(imageName);
                return BitmapFrame.Create(resource);

            }
            catch
            {
                return null;
            }
        }

        #endregion
    }
}