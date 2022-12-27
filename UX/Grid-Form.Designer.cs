namespace BLEANarq.UX
{
    partial class Grid_Form
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.close_btn = new System.Windows.Forms.PictureBox();
            this.minimize_btn = new System.Windows.Forms.PictureBox();
            this.maximize_btn = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.slabs_chk = new System.Windows.Forms.CheckBox();
            this.trabes_chk = new System.Windows.Forms.CheckBox();
            this.columns_chk = new System.Windows.Forms.CheckBox();
            this.walls_chk = new System.Windows.Forms.CheckBox();
            this.cimientos_chk = new System.Windows.Forms.CheckBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.close_btn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.minimize_btn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.maximize_btn)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.AutoSize = true;
            this.panel1.BackColor = System.Drawing.Color.Black;
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Location = new System.Drawing.Point(0, 37);
            this.panel1.Name = "panel1";
            this.panel1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.panel1.Size = new System.Drawing.Size(800, 107);
            this.panel1.TabIndex = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Black;
            this.pictureBox1.Image = global::BLEANarq.Resource1.DATARCHCSimgwhite1;
            this.pictureBox1.Location = new System.Drawing.Point(3, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(111, 83);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // close_btn
            // 
            this.close_btn.Image = global::BLEANarq.Resource1.close__1_;
            this.close_btn.Location = new System.Drawing.Point(760, 1);
            this.close_btn.Name = "close_btn";
            this.close_btn.Size = new System.Drawing.Size(32, 33);
            this.close_btn.TabIndex = 1;
            this.close_btn.TabStop = false;
            this.close_btn.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // minimize_btn
            // 
            this.minimize_btn.Image = global::BLEANarq.Resource1.minimize__1_;
            this.minimize_btn.Location = new System.Drawing.Point(722, 1);
            this.minimize_btn.Name = "minimize_btn";
            this.minimize_btn.Size = new System.Drawing.Size(32, 33);
            this.minimize_btn.TabIndex = 2;
            this.minimize_btn.TabStop = false;
            this.minimize_btn.Click += new System.EventHandler(this.minimize_btn_Click);
            // 
            // maximize_btn
            // 
            this.maximize_btn.Image = global::BLEANarq.Resource1.exit_to_app_button;
            this.maximize_btn.Location = new System.Drawing.Point(684, 1);
            this.maximize_btn.Name = "maximize_btn";
            this.maximize_btn.Size = new System.Drawing.Size(32, 33);
            this.maximize_btn.TabIndex = 3;
            this.maximize_btn.TabStop = false;
            this.maximize_btn.Click += new System.EventHandler(this.maximize_btn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Myanmar Text", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.InfoText;
            this.label1.Location = new System.Drawing.Point(12, 156);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(255, 34);
            this.label1.TabIndex = 4;
            this.label1.Text = "R E V I T   C A T E G O R I E S ";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(625, 397);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(147, 70);
            this.button1.TabIndex = 5;
            this.button1.Text = "ASIGNAR VALORES";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.slabs_chk);
            this.groupBox1.Controls.Add(this.trabes_chk);
            this.groupBox1.Controls.Add(this.columns_chk);
            this.groupBox1.Controls.Add(this.walls_chk);
            this.groupBox1.Controls.Add(this.cimientos_chk);
            this.groupBox1.Font = new System.Drawing.Font("Myriad Pro", 9.749999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(19, 200);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(530, 266);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "S e l e c t e d   I t e m s ";
            // 
            // slabs_chk
            // 
            this.slabs_chk.AutoSize = true;
            this.slabs_chk.Checked = true;
            this.slabs_chk.CheckState = System.Windows.Forms.CheckState.Checked;
            this.slabs_chk.Font = new System.Drawing.Font("Poppins", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.slabs_chk.ForeColor = System.Drawing.SystemColors.InfoText;
            this.slabs_chk.Location = new System.Drawing.Point(271, 125);
            this.slabs_chk.Name = "slabs_chk";
            this.slabs_chk.Size = new System.Drawing.Size(192, 27);
            this.slabs_chk.TabIndex = 4;
            this.slabs_chk.Text = "Structural Floors (slabs)";
            this.slabs_chk.UseVisualStyleBackColor = true;
            // 
            // trabes_chk
            // 
            this.trabes_chk.AutoSize = true;
            this.trabes_chk.Checked = true;
            this.trabes_chk.CheckState = System.Windows.Forms.CheckState.Checked;
            this.trabes_chk.Font = new System.Drawing.Font("Poppins", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.trabes_chk.ForeColor = System.Drawing.SystemColors.InfoText;
            this.trabes_chk.Location = new System.Drawing.Point(271, 48);
            this.trabes_chk.Name = "trabes_chk";
            this.trabes_chk.Size = new System.Drawing.Size(159, 27);
            this.trabes_chk.TabIndex = 3;
            this.trabes_chk.Text = "Structural Framing";
            this.trabes_chk.UseVisualStyleBackColor = true;
            // 
            // columns_chk
            // 
            this.columns_chk.AutoSize = true;
            this.columns_chk.Checked = true;
            this.columns_chk.CheckState = System.Windows.Forms.CheckState.Checked;
            this.columns_chk.Font = new System.Drawing.Font("Poppins", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.columns_chk.ForeColor = System.Drawing.SystemColors.InfoText;
            this.columns_chk.Location = new System.Drawing.Point(21, 197);
            this.columns_chk.Name = "columns_chk";
            this.columns_chk.Size = new System.Drawing.Size(162, 27);
            this.columns_chk.TabIndex = 2;
            this.columns_chk.Text = "Structural Columns";
            this.columns_chk.UseVisualStyleBackColor = true;
            // 
            // walls_chk
            // 
            this.walls_chk.AutoSize = true;
            this.walls_chk.Checked = true;
            this.walls_chk.CheckState = System.Windows.Forms.CheckState.Checked;
            this.walls_chk.Font = new System.Drawing.Font("Poppins", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.walls_chk.ForeColor = System.Drawing.SystemColors.InfoText;
            this.walls_chk.Location = new System.Drawing.Point(21, 125);
            this.walls_chk.Name = "walls_chk";
            this.walls_chk.Size = new System.Drawing.Size(67, 27);
            this.walls_chk.TabIndex = 1;
            this.walls_chk.Text = "Walls";
            this.walls_chk.UseVisualStyleBackColor = true;
            this.walls_chk.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // cimientos_chk
            // 
            this.cimientos_chk.AutoSize = true;
            this.cimientos_chk.Checked = true;
            this.cimientos_chk.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cimientos_chk.Font = new System.Drawing.Font("Poppins", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cimientos_chk.ForeColor = System.Drawing.SystemColors.InfoText;
            this.cimientos_chk.Location = new System.Drawing.Point(21, 48);
            this.cimientos_chk.Name = "cimientos_chk";
            this.cimientos_chk.Size = new System.Drawing.Size(185, 27);
            this.cimientos_chk.TabIndex = 0;
            this.cimientos_chk.Text = "Structural Foundations";
            this.cimientos_chk.UseVisualStyleBackColor = true;
            this.cimientos_chk.CheckedChanged += new System.EventHandler(this.cimientos_chk_CheckedChanged);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.MenuText;
            this.panel2.ForeColor = System.Drawing.SystemColors.MenuText;
            this.panel2.Location = new System.Drawing.Point(0, 1);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(678, 36);
            this.panel2.TabIndex = 7;
            // 
            // Grid_Form
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ClientSize = new System.Drawing.Size(800, 500);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.maximize_btn);
            this.Controls.Add(this.minimize_btn);
            this.Controls.Add(this.close_btn);
            this.Controls.Add(this.panel1);
            this.ForeColor = System.Drawing.SystemColors.Window;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Grid_Form";
            this.Text = "Grid_Form";
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.close_btn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.minimize_btn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.maximize_btn)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox close_btn;
        private System.Windows.Forms.PictureBox minimize_btn;
        private System.Windows.Forms.PictureBox maximize_btn;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox cimientos_chk;
        private System.Windows.Forms.CheckBox slabs_chk;
        private System.Windows.Forms.CheckBox trabes_chk;
        private System.Windows.Forms.CheckBox columns_chk;
        private System.Windows.Forms.CheckBox walls_chk;
        private System.Windows.Forms.Panel panel2;
    }
}