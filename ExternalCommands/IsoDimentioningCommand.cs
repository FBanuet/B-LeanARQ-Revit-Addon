using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using BLEANarq.Services;


namespace BLEANarq.ExternalCommands
{
    [Transaction(TransactionMode.Manual)]
    public class IsoDimentioningCommand : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIDocument uidoc = commandData.Application.ActiveUIDocument;
            Document doc = uidoc.Document;


             IList<Reference> references =  uidoc.Selection.PickObjects(ObjectType.Element, "selecciona elemeentos a acotar en vista 3D");

            foreach(Reference refe in references)
            {
                //FILTRADO PARA OBTENER UNICAMENTE LOS ELEMENTOS DE TIPO VIGAS DEL MODELO 
               // if ((BuiltInCategory)doc.GetElement(refe).Category.Id.IntegerValue != BuiltInCategory.OST_StructuralFraming) continue;
               // else if ((BuiltInCategory)doc.GetElement(refe).Category.Id.IntegerValue != BuiltInCategory.OST_StructuralColumns)
                           // continue;

                #region obteniendo la topologia de ubicacion del elemento filtrado posterior ala seleccion de usuario
                Element ele = doc.GetElement(refe);

                LocationCurve lc = ele.Location as LocationCurve;
                Curve beamcurve = lc.Curve;

                XYZ BeamStartPoint = beamcurve.GetEndPoint(0);
                XYZ BeamEndPoint = beamcurve.GetEndPoint(1);


                Line BeamLine = Line.CreateBound(BeamStartPoint, BeamEndPoint); 
                Plane plano =  Plane.CreateByThreePoints(BeamStartPoint,BeamEndPoint, new XYZ(0,0,BeamStartPoint.Z));

                ReferenceArray rarray = new ReferenceArray();

                if(ele != null)
                {
                    Options op = doc.Application.Create.NewGeometryOptions();
                    op.ComputeReferences = true;
                    op.View = doc.ActiveView;
                    op.IncludeNonVisibleObjects = true;

                    Reference r1 = null;
                    Reference r2 = null;    

                    foreach(var geoObj in ele.get_Geometry(op))
                    {
                        Curve c  = geoObj as Curve; 
                        if(c != null)
                        {
                            r1 = c.GetEndPointReference(0);
                            r2 = c.GetEndPointReference(1);
                        }
                    }

                    rarray.Append(r1);
                    rarray.Append(r2);
                }

                #endregion

                #region Creando las Cotas

                using (Transaction trans = new Transaction(doc, "Creando Cotas"))
                {
                    trans.Start();

                    SketchPlane skplane = SketchPlane.Create(doc,plano);
                    uidoc.ActiveView.SketchPlane = skplane;
                    doc.Create.NewDimension(doc.ActiveView, BeamLine, rarray);
    

                    trans.Commit();
                }


                #endregion

            }






            return Result.Succeeded;
        }
    }
}
