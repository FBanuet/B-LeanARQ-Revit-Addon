using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;

namespace BLEANarq.InternalClasses
{
    public class RevitElementLocations
    {
        public static List<List<XYZ>> FamilyPointLocation(List<Element> selectedElements)
        {
            List<List<XYZ>> locations = new List<List<XYZ>>();
            foreach (Element element in selectedElements)
            {
                LocationPoint lp = element.Location as LocationPoint;
                XYZ punto = lp.Point * 0.3048;

                List<XYZ> points = new List<XYZ>();
                points.Add(punto);

                locations.Add(points);
                
            }

            return locations;
        }

        public static List<List<XYZ>> FloorPointLocations(List<Element> selectedElements, Document doc)
        {
            List<List<XYZ>> locations = new List<List<XYZ>>();
            foreach(Element elemento in selectedElements)
            {
                Transaction temporal = new Transaction(doc);
                temporal.Start("Obteniendo curvas de suelos");
                ElementId eleid = elemento.Id;
                IList<ElementId> idElementos = doc.Delete(eleid) as IList<ElementId>;
                temporal.RollBack();

                List<XYZ> lsPuntos = new List<XYZ>();
                foreach(ElementId id in idElementos)
                {
                    Element ele = doc.GetElement(id);
                    if(ele is ModelLine)
                    {
                        LocationCurve curvafisica = ele.Location as LocationCurve;
                        Curve curva = curvafisica.Curve;
                        XYZ pto = curva.GetEndPoint(0) * 0.3048;
                        lsPuntos.Add(pto);
                    }

                }
                locations.Add(lsPuntos);
            }
            return locations;
        }

        public static List<List<XYZ>> WallorBeamPointLocations(List<Element> selectedElements)
        {
            List<List<XYZ>> locations = new List<List<XYZ>>();
            foreach (Element elemento in selectedElements)
            {
                List<XYZ> lsPuntos = new List<XYZ>();
                LocationCurve lcurve = elemento.Location as LocationCurve;
                Curve curva = lcurve.Curve;
                XYZ coordenada = curva.GetEndPoint(0) * 0.3048;
                XYZ coordenada2 = curva.GetEndPoint(1) * 0.3048;
                lsPuntos.Add(coordenada);
                lsPuntos.Add(coordenada2);
                locations.Add(lsPuntos);
            }
            return locations;
        }



    }
}
