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
    public class SelectRevitElements
    {
        public static List<Element> GridElementsSelector(Document doc)
        {
            FilteredElementCollector collectorGrid = new FilteredElementCollector(doc);
            List<Element> elementosSeleccionados = collectorGrid.OfClass(typeof(Grid)).ToList();

            return elementosSeleccionados;

        }
        public static List<Element> foundationsElementsSelector(Document doc)
        {
            FilteredElementCollector collectorCimentaciones = new FilteredElementCollector(doc);
            ElementClassFilter filtroclase = new ElementClassFilter(typeof(FamilyInstance));
            ElementCategoryFilter categoryFilter = new ElementCategoryFilter(BuiltInCategory.OST_StructuralFoundation);
            LogicalAndFilter logicalAndFilter = new LogicalAndFilter(filtroclase, categoryFilter);
            List<Element> elementosSeleccionados = collectorCimentaciones.WherePasses(logicalAndFilter).ToList();

            return elementosSeleccionados;

        }
        public static List<Element> floorsElementsSelector(Document doc)
        {
            FilteredElementCollector collector = new FilteredElementCollector(doc);
            List<Element> elementosSeleccionados = collector.OfClass(typeof(Floor)).ToList();

            return elementosSeleccionados;

        }

        public static List<Element> wallsElementsSelector(Document doc)
        {
            FilteredElementCollector collector = new FilteredElementCollector(doc);
            List<Element> elementosSeleccionados = collector.OfClass(typeof(Wall)).ToList();

            return elementosSeleccionados;

        }
        public static List<Element> columnsElementsSelector(Document doc)
        {
            FilteredElementCollector collectorcolumns = new FilteredElementCollector(doc);
            ElementClassFilter filtroclase = new ElementClassFilter(typeof(FamilyInstance));
            ElementCategoryFilter categoryFilter = new ElementCategoryFilter(BuiltInCategory.OST_StructuralColumns);
            LogicalAndFilter logicalAndFilter = new LogicalAndFilter(filtroclase, categoryFilter);
            List<Element> elementosSeleccionados = collectorcolumns.WherePasses(logicalAndFilter).ToList();

            return elementosSeleccionados;

        }

        public static List<Element> beamsElementsSelector(Document doc)
        {
            FilteredElementCollector collectorbeams = new FilteredElementCollector(doc);
            ElementClassFilter filtroclase = new ElementClassFilter(typeof(FamilyInstance));
            ElementCategoryFilter categoryFilter = new ElementCategoryFilter(BuiltInCategory.OST_StructuralFraming);
            LogicalAndFilter logicalAndFilter = new LogicalAndFilter(filtroclase, categoryFilter);
            List<Element> elementosSeleccionados = collectorbeams.WherePasses(logicalAndFilter).ToList();

            return elementosSeleccionados;

        }


    }
}
