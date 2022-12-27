using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.DB.Structure;

namespace BLEANarq.UX
{
    public partial class CadForm : System.Windows.Forms.Form
    {
        Document Doc;
        private IList<PolyLine> pLines = new List<PolyLine>();  
        public CadForm(Document doc)
        {
            InitializeComponent();
            Doc = doc;
        }

        private void CadForm_Load(object sender, EventArgs e)
        {
            IList<ElementId> cadImports = (IList<ElementId>)new FilteredElementCollector(Doc).
                OfClass(typeof(ImportInstance)).
                WhereElementIsNotElementType().ToElementIds();

            IList<string> layerNames = new List<string>();

            if(cadImports.Count > 0)
            {
                ImportInstance import = Doc.GetElement(cadImports.First()) as ImportInstance;
                GeometryElement geoEle = import.get_Geometry(new Options());    

                foreach(GeometryObject geObj in geoEle)
                {
                    if(geObj is GeometryInstance)
                    {
                        GeometryInstance geoInst = geObj as GeometryInstance;   
                        GeometryElement geoElement = geoInst.GetInstanceGeometry();
                        if(geoElement != null)
                        {
                            foreach(GeometryObject obj in geoElement)
                            {
                                if(obj is PolyLine)
                                {
                                    GraphicsStyle gStyle = Doc.GetElement(obj.GraphicsStyleId) as GraphicsStyle;
                                    string layer = gStyle.GraphicsStyleCategory.Name;
                                    layerNames.Add(layer);
                                    pLines.Add(obj as PolyLine);
                                }
                            }
                        }

                    }
                }

                LayerCombo.DataSource = layerNames.Distinct().ToList();
                IList<Element> columns = new FilteredElementCollector(Doc)
                    .OfCategory(BuiltInCategory.OST_StructuralColumns)
                    .WhereElementIsElementType().ToElements();

                IList<string> columnTypes = new List<string>();

                foreach(Element columnType in columns)
                {
                    columnTypes.Add(columnType.Name);
                }

                ColumnTypeCombo.DataSource = columnTypes;
            }
            else
            {
                TaskDialog.Show("ERROR", "NO IMPORT INSTANCE FOUNDED");
                DialogResult = DialogResult.OK;
                Close();
            }
        }

        private void ColumnTypeCombo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btn_Create_Click(object sender, EventArgs e)
        {
            string selectedLayer = this.LayerCombo.SelectedItem.ToString();

            foreach(PolyLine plines in pLines)
            {
                GraphicsStyle style = Doc.GetElement(plines.GraphicsStyleId) as GraphicsStyle;
                string layer = style.GraphicsStyleCategory.Name;

                if(layer == selectedLayer)
                {
                    Outline pOutline = plines.GetOutline();


                    XYZ firstP = pOutline.MaximumPoint;
                    XYZ secondP = pOutline.MinimumPoint;    
                    XYZ lineMid = MidPoint(firstP.X, secondP.X, firstP.Y, secondP.Y, firstP.Z,secondP.Z);

                    IList<Element> scolumns = new FilteredElementCollector(Doc).OfCategory(BuiltInCategory.OST_StructuralColumns)
                        .WhereElementIsElementType().ToElements();

                    IList<Level> levels = new FilteredElementCollector(Doc).OfClass(typeof(Level)).Cast<Level>().ToList();


                    Level colLevel = null;
                    foreach(Level level in levels)
                    {
                        if (level.Name == "Level 0")
                        {
                            colLevel = level;
                        }
                    }

                    FamilySymbol fsymbol = null;
                    string selectedColumnType = this.ColumnTypeCombo.SelectedItem.ToString();   
                    foreach(Element ele in scolumns)
                    {
                        if(ele.Name == selectedColumnType)
                        {
                            fsymbol = ele as FamilySymbol;
                        }
                    }

                    using(Transaction t = new Transaction(Doc,"MakingColumnsCAD"))
                    {
                        t.Start();
                        try
                        {
                            if(!fsymbol.IsActive)
                            { 
                                fsymbol.Activate();


                            }

                            Doc.Create.NewFamilyInstance(lineMid, fsymbol, StructuralType.Column);
                        }catch(Exception ex)
                        {
                            TaskDialog.Show(ex.Message, ex.ToString());
                        }

                        t.Commit();
                    }

                }
            }

            DialogResult = DialogResult.OK;
            Close();
        }

        private static XYZ MidPoint(double x1, double x2, double y1, double y2 , double z1, double z2)
        {
            XYZ midPoint = new XYZ ((x1+x2)/2, (y1+y2)/2, (z1+z2)/2);
            return midPoint;
        }
    }
}
