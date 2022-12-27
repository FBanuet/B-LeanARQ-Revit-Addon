using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLEANarq.InternalClasses;
using BLEANarq.ExternalCommands;
using Microsoft.Office.Interop.Excel;

namespace BLEANarq.UX
{
    public partial class QEX_form : Form
    {
        List<TableContent> tableContent = new List<TableContent>();
        public QEX_form(Dictionary<string, List<string>> tiposelementosNivel, List<TableContent> contenidoTabla)
        {
            InitializeComponent();
            llenarTreeView(tiposelementosNivel);
            tableContent = contenidoTabla;
            dgridview.DataSource = contenidoTabla;

            L1.Text = dgridview.Rows.Count.ToString();
            L2.Text = VolumeCalc(dgridview).ToString();
        }

        private void QEX_form_Load(object sender, EventArgs e)
        {

        }
        private void llenarTreeView(Dictionary<string, List<string>> tiposelementosNivel)
        {
            arbol.Nodes.Clear();
            int indice = 0;
            foreach (KeyValuePair<string, List<string>> nivel in tiposelementosNivel)
            {
                arbol.Nodes.Add(nivel.Key); 
                foreach(string cate in nivel.Value)
                {
                    arbol.Nodes[indice].Nodes.Add(cate);
                }
                indice += 1;
            }
        }

        private void arbol_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Parent != null)
            {
                List<TableContent> content_list = new List<TableContent>();

                foreach (TableContent content in tableContent)
                {
                    if (content.NIVEL == e.Node.Parent.Text && content.CATEGORY == e.Node.Text)
                    {
                        content_list.Add(content);
                    }
                }

                dgridview.DataSource = content_list;

            }
            else
            {
                List<TableContent> content_list = new List<TableContent>();

                foreach (TableContent content in tableContent)
                {
                    if (content.NIVEL == e.Node.Text)
                    {
                        content_list.Add(content);
                    }
                }
                dgridview.DataSource = content_list;
            }

            L3.Text = dgridview.Rows.Count.ToString();  
            L4.Text =  VolumeCalc(dgridview).ToString();
        }

        private double VolumeCalc(DataGridView drgidview)
        {
            double vol = 0;

            foreach(DataGridViewRow fila in dgridview.Rows)
            {
                vol += double.Parse(fila.Cells[3].Value.ToString().Substring(0, fila.Cells[3].Value.ToString().Length - 3));
            }
            return Math.Round(vol,2);
        }

        private void dgridview_MouseUp(object sender, MouseEventArgs e)
        {
            List<string> ids = new List<string>();

            if(dgridview.SelectedRows.Count != 0)
            {
                for(int i = 0; i < dgridview.SelectedRows.Count; i++)
                {
                    ids.Add(dgridview.SelectedRows[i].Cells[0].Value.ToString());
                }
            }
            QuantificationsCommand.SeleccionElementosRevitUI(ids);
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();
            excel.Workbooks.Add(true);

            int indiceColumna = 1;
            int indiceFila = 1;

            foreach(DataGridViewColumn columna in dgridview.Columns)
            {
                excel.Cells[indiceFila, indiceColumna] = columna.Name;
                indiceColumna++;
            }

            foreach(DataGridViewRow filas in dgridview.Rows)
            {
                indiceFila++;
                indiceColumna = 1;

                foreach(DataGridViewColumn columna in dgridview.Columns)
                {
                    excel.Cells[indiceFila, indiceColumna] = filas.Cells[columna.Name].Value;
                    indiceColumna++;
                }
            }

            excel.Visible = true;

        }
    }
}
