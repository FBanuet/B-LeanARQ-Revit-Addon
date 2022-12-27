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
    public class QuantificationsCommand : IExternalCommand
    {
        private static UIDocument _uidoc;
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            #region GLOBAL REVIT API PARAMETERS FOR EXTERNAL COMMANDS
            _uidoc = commandData.Application.ActiveUIDocument;
            Document doc = _uidoc.Document;
            #endregion



            #region Collecionando y agrupando bloques por nivel y categoria de elementos Revit
            
            //seleccionando los elementos
            List<Element> elemntosSeleccionados = SeleccionElementos(doc);

            //obteniendo los parametros de niveles a los cuales los elementos estan referenciados

            BuiltInParameter builtInParameterSuelosyCimentaciones = BuiltInParameter.SCHEDULE_LEVEL_PARAM;
            BuiltInParameter builtInParameterMuros = BuiltInParameter.WALL_BASE_CONSTRAINT;
            BuiltInParameter builtInParameterColumnas = BuiltInParameter.SCHEDULE_BASE_LEVEL_PARAM;
            BuiltInParameter builtInParameterVigas = BuiltInParameter.INSTANCE_REFERENCE_LEVEL_PARAM;

            //listas para almacenar los valores de los parametros
            List<string> nivelElementos = new List<string>();

            foreach (Element element in elemntosSeleccionados)
            {
                if ((BuiltInCategory)element.Category.Id.IntegerValue == BuiltInCategory.OST_StructuralFoundation
                    || (BuiltInCategory)element.Category.Id.IntegerValue == BuiltInCategory.OST_Floors)
                {
                    nivelElementos.Add(element.get_Parameter(builtInParameterSuelosyCimentaciones).AsValueString());

                }
                else if((BuiltInCategory)element.Category.Id.IntegerValue == BuiltInCategory.OST_Walls)
                {
                    nivelElementos.Add(element.get_Parameter(builtInParameterMuros).AsValueString());
                }
                else if ((BuiltInCategory)element.Category.Id.IntegerValue == BuiltInCategory.OST_StructuralColumns)
                {
                    nivelElementos.Add(element.get_Parameter(builtInParameterColumnas).AsValueString());
                }
                else if ((BuiltInCategory)element.Category.Id.IntegerValue == BuiltInCategory.OST_StructuralFraming)
                {
                    nivelElementos.Add(element.get_Parameter(builtInParameterVigas).AsValueString());
                }
            }

            // obteniendo niveles unicos

            List<string> nivelElementosUnicos = new List<string>();
            nivelElementosUnicos.AddRange(nivelElementos.Distinct());

            // OBTENIENDO LAS DISTINTAS CATEGORIAS POR NIVELES

            Dictionary<string,List<string>> tiposElementosNivel = new Dictionary<string,List<string>>();

            foreach (string nivel in nivelElementosUnicos)
            {
                List<string> categoriasExistentes = new List<string>();

                foreach (Element element in elemntosSeleccionados)
                {
                    if ((BuiltInCategory)element.Category.Id.IntegerValue == BuiltInCategory.OST_StructuralFoundation
                        || (BuiltInCategory)element.Category.Id.IntegerValue == BuiltInCategory.OST_Floors)
                    {
                        if(element.get_Parameter(builtInParameterSuelosyCimentaciones).AsValueString() == nivel)
                        {
                            categoriasExistentes.Add(element.Category.Name);    

                        }
                    }
                    else if ((BuiltInCategory)element.Category.Id.IntegerValue == BuiltInCategory.OST_Walls)
                    {
                        if (element.get_Parameter(builtInParameterMuros).AsValueString() == nivel)
                        {
                            categoriasExistentes.Add(element.Category.Name);

                        }
                    }
                    else if ((BuiltInCategory)element.Category.Id.IntegerValue == BuiltInCategory.OST_StructuralColumns)
                    {
                        if (element.get_Parameter(builtInParameterColumnas).AsValueString() == nivel)
                        {
                            categoriasExistentes.Add(element.Category.Name);

                        }
                    }
                    else if ((BuiltInCategory)element.Category.Id.IntegerValue == BuiltInCategory.OST_StructuralFraming)
                    {
                        if (element.get_Parameter(builtInParameterVigas).AsValueString() == nivel)
                        {
                            categoriasExistentes.Add(element.Category.Name);

                        }
                    }
                }
                tiposElementosNivel.Add(nivel,categoriasExistentes.Distinct().ToList());
            }
            #endregion


            #region implementando la interfaz de usuario mediante el formulario

            // CREANDO LA LISTA CON LOS OBJETOS QUE CONTIENEN LA INFORMACIÓN DE LA TABLA
            List<TableContent> contenidoTablas = new List<TableContent>();
            for(int i = 0; i < elemntosSeleccionados.Count; i++)
            {
                //aqui creamos un objeto dentro de este bloque de còdigo y cambiamos las propiedades de la clase 
                //desde un For Loop
                contenidoTablas.Add(new TableContent
                {
                    ID = elemntosSeleccionados[i].Id.ToString(),
                    NIVEL = nivelElementos[i],
                    CATEGORY = elemntosSeleccionados[i].Category.Name,
                    VOLUME = elemntosSeleccionados[i].get_Parameter(BuiltInParameter.HOST_VOLUME_COMPUTED).AsValueString(),
                });

                //Aqui creamos una instancia de la clase como un nuevo objeto mediante su constructor mas bàsio
                //y asignamos manualmente sus propiedades para posteriormente agregarlo a la lista de objetos de su tipo
                //TableContent contenido = new TableContent();
                //contenido.ID = elemntosSeleccionados[i].Id.ToString();
                //contenidoTablas.Add(contenido);

            }


            QEX_form q_form = new QEX_form(tiposElementosNivel, contenidoTablas);
            q_form.Show();

            #endregion

            return Result.Succeeded;

            
        }


        //metodo externo o de utilidad para collecionar elementos de ñla base de datos revit.

        private List<Element> SeleccionElementos(Document doc)
        {
            //Lista de Muros
            FilteredElementCollector collectorMuros = new FilteredElementCollector(doc);
            List<Element> murosSelected = collectorMuros.OfClass(typeof(Wall)).ToList();

            //Lista de Suelos
            List<Element> suelosSelected = new FilteredElementCollector(doc).OfClass(typeof(Floor)).ToList();

            //lista de Family Instances

            List<Element> familyInstances = new FilteredElementCollector(doc).OfClass(typeof(FamilyInstance)).ToList();

            List<Element> elementos = new List<Element>();

            elementos.AddRange(murosSelected);
            elementos.AddRange(suelosSelected);
            elementos.AddRange(familyInstances);

            return elementos;   


        }

        #region REACCIONANDO AL EVENTO MOUSEUP DEL DATA GRID VIEW

        public static void SeleccionElementosRevitUI(List<string> ids)
        {
            ICollection<ElementId> elementsIds = _uidoc.Selection.GetElementIds();
            elementsIds.Clear();
            foreach (string id in ids)
            {
                ElementId elementId = new ElementId(Convert.ToInt32(id));
                elementsIds.Add(elementId); 
            }
            _uidoc.Selection.SetElementIds(elementsIds);    
        }







        #endregion
    }
}
