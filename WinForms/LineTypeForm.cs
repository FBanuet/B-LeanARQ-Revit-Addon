using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;

namespace BLEANarq.WinForms
{
    public partial class LineTypeForm : System.Windows.Forms.Form   
    {
        public static string selectedLineStyle;
        
        public LineTypeForm(CategoryNameMap lineStyles)
        {
            InitializeComponent();
            string saveLineStyle = (string)Properties.Settings.Default["NombreLinea"];

            selectedLineStyle = "";

            foreach(Category lineStyle in lineStyles)
            {
                cmbLinesTypes.Items.Add(lineStyle.Name);
                cmbLinesTypes.SelectedIndex = 0;

            }
            try
            {
                lineStyles.get_Item(saveLineStyle);
                cmbLinesTypes.SelectedIndex = cmbLinesTypes.Items
                    .IndexOf(lineStyles.get_Item(saveLineStyle)
                    .Name);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void LineTypeForm_Load(object sender, EventArgs e)
        {

        }

        private void cmbLinesTypes_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedLineStyle = cmbLinesTypes.SelectedItem.ToString();  
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default["NombreLinea"] = selectedLineStyle;
            Close();
        }

        private void btnCANCEL_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
