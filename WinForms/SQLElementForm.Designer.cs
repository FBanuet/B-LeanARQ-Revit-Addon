namespace BLEANarq.WinForms
{
    partial class SQLElementForm
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
            this.sqlbtncreate = new System.Windows.Forms.Button();
            this.btnExport = new System.Windows.Forms.Button();
            this.btnImport = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // sqlbtncreate
            // 
            this.sqlbtncreate.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.sqlbtncreate.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.sqlbtncreate.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.sqlbtncreate.Location = new System.Drawing.Point(68, 25);
            this.sqlbtncreate.Name = "sqlbtncreate";
            this.sqlbtncreate.Size = new System.Drawing.Size(343, 47);
            this.sqlbtncreate.TabIndex = 0;
            this.sqlbtncreate.Text = "SQL Generator";
            this.sqlbtncreate.UseVisualStyleBackColor = false;
            // 
            // btnExport
            // 
            this.btnExport.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnExport.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnExport.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnExport.Location = new System.Drawing.Point(68, 95);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(343, 47);
            this.btnExport.TabIndex = 1;
            this.btnExport.Text = "SQL Exporter";
            this.btnExport.UseVisualStyleBackColor = false;
            // 
            // btnImport
            // 
            this.btnImport.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnImport.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnImport.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnImport.Location = new System.Drawing.Point(68, 172);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(343, 47);
            this.btnImport.TabIndex = 2;
            this.btnImport.Text = "SQL Import Data";
            this.btnImport.UseVisualStyleBackColor = false;
            // 
            // SQLElementForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(453, 241);
            this.Controls.Add(this.btnImport);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.sqlbtncreate);
            this.Name = "SQLElementForm";
            this.Text = "SQLElementForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button sqlbtncreate;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Button btnImport;
    }
}