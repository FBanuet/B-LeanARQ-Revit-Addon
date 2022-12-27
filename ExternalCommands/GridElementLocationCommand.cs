using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLEANarq.UX;
using BLEANarq.InternalClasses;


namespace BLEANarq.ExternalCommands
{
    [Transaction(TransactionMode.Manual)]
    [Regeneration(RegenerationOption.Manual)]
    public class GridElementLocationCommand : IExternalCommand
    {
        public Document doc;
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {

            UIDocument uidoc = commandData.Application.ActiveUIDocument;
            doc = uidoc.Document;




            #region LLAMANDO ALA INTERFAZ DE USUARIO

            Grid_Form gform = new Grid_Form();
            gform.ShowDialog();

            #endregion

            if(gform.locate)
            {
                // SELECCIONANDO LOS EJES
                List<Element> lstGrids = SelectRevitElements.GridElementsSelector(doc);


                //OBTENIENDO COORDENADAS DE INTERSECCIONES ENTRE EJES Y SUS NOMBRES DE ENTREEJES
                var (lstCoordinateIntersectGrid, lstNameIntersectGrid) = ElementIntersector.CoordenadasInterseccionGrid(doc, lstGrids);

                if (gform.cimientos)
                {
                    List<Element> lstCimentaciones = SelectRevitElements.foundationsElementsSelector(doc);
                    List<List<XYZ>> lstCimentacionesXYZ = RevitElementLocations.FamilyPointLocation(lstCimentaciones);
                    LocateElements(lstCimentaciones,lstCimentacionesXYZ,lstCoordinateIntersectGrid,lstNameIntersectGrid);
                }
                if (gform.suelos)
                {
                    List<Element> lstSuelos = SelectRevitElements.floorsElementsSelector(doc);
                    List<List<XYZ>> lstSuelosCimentacionesXYZ = RevitElementLocations.FloorPointLocations(lstSuelos,doc);
                    LocateElements(lstSuelos, lstSuelosCimentacionesXYZ, lstCoordinateIntersectGrid, lstNameIntersectGrid);
                }
                if (gform.muros)
                {
                    List<Element> lstSMuros = SelectRevitElements.wallsElementsSelector(doc);
                    List<List<XYZ>> lstMurosXYZ = RevitElementLocations.WallorBeamPointLocations(lstSMuros);
                    LocateElements(lstSMuros, lstMurosXYZ, lstCoordinateIntersectGrid, lstNameIntersectGrid);
                }
                if (gform.columnas)
                {
                    List<Element> lstColumns = SelectRevitElements.columnsElementsSelector(doc);
                    List<List<XYZ>> lstColumnXYZ = RevitElementLocations.FamilyPointLocation(lstColumns);
                    LocateElements(lstColumns, lstColumnXYZ, lstCoordinateIntersectGrid, lstNameIntersectGrid);
                }
                if (gform.trabes)
                {
                    List<Element> lstTrabes = SelectRevitElements.beamsElementsSelector(doc);
                    List<List<XYZ>> lstTrabesXYZ = RevitElementLocations.WallorBeamPointLocations(lstTrabes);
                    LocateElements(lstTrabes, lstTrabesXYZ, lstCoordinateIntersectGrid, lstNameIntersectGrid);
                }
            }



            return Result.Succeeded;
        }

        private void LocateElements( List<Element> lstElementos, List<List<XYZ>> lstPuntosElementosXYZ, 
            List<XYZ> lstCoordinateIntersectGrid, List<string> lstNameIntersectGrid)
        {
            for(int i = 0; i < lstPuntosElementosXYZ.Count; i++)
            {
                List<string> ubicaciones = new List<string>();
                foreach(XYZ coords in lstPuntosElementosXYZ[i])
                {
                    List<double> distanciaPts = new List<double>(); 
                    foreach(XYZ xyzGrid in lstCoordinateIntersectGrid)
                    {
                        distanciaPts.Add(coords.DistanceTo(xyzGrid));
                    }

                    ubicaciones.Add(lstNameIntersectGrid[distanciaPts.FindIndex(x => x == distanciaPts.Min())]);

                }

                Parameter coments = lstElementos[i].get_Parameter(BuiltInParameter.ALL_MODEL_INSTANCE_COMMENTS);

                using(Transaction trans = new Transaction(doc))
                {
                    trans.Start("INYECCION PARAMETRO GRID");

                    try
                    {
                        string info = "";
                        foreach(string name in ubicaciones)
                        {
                            info += "Eje " + name + ", ";
                        }
                        coments.Set(info);
                    }
                    catch(Exception ex)
                    {
                        TaskDialog.Show("ERROR!",ex.Message);
                        trans.RollBack();
                    }


                    trans.Commit();
                }
            }
        }
    }
}
