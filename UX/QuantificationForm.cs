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
    public partial class QuantificationForm : Form
    {
        public QuantificationForm()
        {
            InitializeComponent();
            
        }

        #region WINDOW STATE BEHAVIOR EVENTS



        private void pcb_Close_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pcb_minimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void QuantificationForm_Load(object sender, EventArgs e)
        {

        }

       

        private void label1_Click(object sender, EventArgs e)
        {

        }


        #endregion

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
