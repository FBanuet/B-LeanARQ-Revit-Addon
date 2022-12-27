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
    public class ElementIntersector
    {
        #region VARIABLES

        static double x1_1 = 0;
        static double y1_1 = 0;

        static double x2_1 = 0;
        static double y2_1 = 0;

        static double x1_2 = 0;
        static double y1_2 = 0;

        static double x2_2 = 0;
        static double y2_2 = 0;

        static double m = 0;
        static double n = 0;
        static double coordenada_x = 0;
        static double coordenada_y = 0;
        #endregion


        public static (List<XYZ>, List<string>) CoordenadasInterseccionGrid(Document doc,List<Element> grids )
        {
            List<List<string>> lstIntersectGroupGeneral= new List<List<string>>();  

            foreach(Element element in grids)
            {
                for (int i = 0; i < grids.Count; i++)
                {
                    List<string> lstIntersectGroup = new List<string>();

                    if (grids[i] != element)
                    {
                        Grid eje = element as Grid;
                        Curve curva01 = eje.Curve;

                        Grid eje02 = grids[i] as Grid;
                        Curve curva02 = eje02.Curve;


                        if (curva01.Intersect(curva02) == SetComparisonResult.Overlap)
                        {
                            lstIntersectGroup.Add(element.Name);
                            lstIntersectGroup.Add(grids[i].Name);
                        }
                    }

                    if (lstIntersectGroup.Count != 0)
                    {
                        lstIntersectGroupGeneral.Add(lstIntersectGroup);
                    }
                }
            }


            ///obteniendo los indices de ejes que intersectan unicos
            ///

            List<int> lstIndices = new List<int>();
            foreach(List<string> lstText in lstIntersectGroupGeneral)
            {
                List<int> indices = new List<int>();
                for (int i = 0; i < lstIntersectGroupGeneral.Count; i++)
                {
                    if(lstText[0] == lstIntersectGroupGeneral[i][0] && lstText[1] == lstIntersectGroupGeneral[i][1]
                        || lstText[0] == lstIntersectGroupGeneral[i][1] && lstText[1] == lstIntersectGroupGeneral[i][0])
                    {
                        indices.Add(i);
                    }
                }
                lstIndices.Add(indices[0]);
            }

            // Obteniendo las coordenadas de las intersecciones de los ejes

            List<XYZ> lstIntersectGridPoints = new List<XYZ>();

            foreach (int indice in lstIndices.Distinct())
            {
                List<Curve> curves = new List<Curve>();
                foreach(string nombre in lstIntersectGroupGeneral[indice])
                {
                    foreach(Element grilla in grids)
                    {
                        if(nombre == grilla.Name)
                        {
                            Grid eje1 = grilla as Grid;
                            curves.Add(eje1.Curve);


                        }
                    }
                }

                lstIntersectGridPoints.Add(CurveIntersector(doc,curves[0],curves[1]));  
            }
            //OBTENIENDO LOS NOMBRES DE LAS INTERSECCIONES DE LOS EJES

            List<string> lstNombresInterseccionesEjes = new List<string>();
            foreach(int indice in lstIndices.Distinct())
            {
                lstNombresInterseccionesEjes.Add(lstIntersectGroupGeneral[indice][0] + "-" + lstIntersectGroupGeneral[indice][1]);
            }

            return (lstIntersectGridPoints, lstNombresInterseccionesEjes);
        }
        


        public static XYZ CurveIntersector(Document doc, Curve crv1, Curve crv2)
        {
            ///TRABAJANDO CON LA CURVA 1 CRV1
            ///
            XYZ ptInicial01 = crv1.GetEndPoint(0) * 0.3048;
            x1_1 = ptInicial01.X;
            y1_1 = ptInicial01.Y;

            XYZ ptFinal01= crv1.GetEndPoint(1) * 0.3048;
            x2_1 = ptFinal01.X;
            y2_1 = ptFinal01.Y;

            ///TRABAJANDO CON LA CURVA 2 CRV2
            ///
            XYZ ptInicial02 = crv2.GetEndPoint(0) * 0.3048;
            x1_2 = ptInicial02.X;
            y1_2 = ptInicial02.Y;

            XYZ ptFinal02 = crv2.GetEndPoint(1) * 0.3048;
            x2_2 = ptFinal02.X;
            y2_2 = ptFinal02.Y;



            //Obteniendo la pendeiente m

            m = (y2_1 - y1_1) / (x2_1 - x1_1);


            //Obteniendo la pendeiente n

            n = (y2_2 - y1_2) / (x2_2 - x1_2);

            //Calculando el valor de la coordenada X
            coordenada_x = (y1_2 - n * x1_2 - y1_1 + m * x1_1) / (m - n);
            coordenada_y = y1_2 - n * x1_2 + n * ((y1_2 - n * x1_2 - y1_1 + m * x1_1) /(m - n));

            // creando el punto de interseccion XYZ de los ejes

            XYZ coordenadasXYZ = doc.Application.Create.NewXYZ(Math.Round(coordenada_x,2) , Math.Round(coordenada_y,2), 0);

            return coordenadasXYZ;
        }

    }
}
