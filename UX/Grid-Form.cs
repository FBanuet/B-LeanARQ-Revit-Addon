using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BLEANarq.UX
{
    public partial class Grid_Form : Form
    {
        public Grid_Form()
        {
            InitializeComponent();
        }
        #region COMPORTAMIENTO DE LA INTERFAZ MEDIANTE PICTURE BOXES
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            //button close
            Application.Exit();
        }

        private void maximize_btn_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }

        private void minimize_btn_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        #endregion

        public bool cimientos = false;
        public bool muros = false;
        public bool columnas = false;
        public bool suelos = false;
        public bool trabes = false;
        public bool locate = false;

        private void button1_Click(object sender, EventArgs e)
        {
            if(cimientos_chk.Checked == true)
            {
                cimientos = true;
            }
            if (walls_chk.Checked == true)
            {
                muros = true;
            }
            if(columns_chk.Checked == true)
            {
                columnas = true;
            }
            if (slabs_chk.Checked == true)
            {
                suelos = true;
            }
            if (trabes_chk.Checked == true)
            {
                trabes = true;
            }
            locate = true;
            this.Close();

        }

        private void cimientos_chk_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
