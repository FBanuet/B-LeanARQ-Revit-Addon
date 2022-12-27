namespace BLEANarq.UX
{
    partial class CadForm
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
            this.layerLaber = new System.Windows.Forms.Label();
            this.LayerCombo = new System.Windows.Forms.ComboBox();
            this.ColumnTypeCombo = new System.Windows.Forms.ComboBox();
            this.LabelColumn = new System.Windows.Forms.Label();
            this.btn_Create = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // layerLaber
            // 
            this.layerLaber.AutoSize = true;
            this.layerLaber.Location = new System.Drawing.Point(7, 22);
            this.layerLaber.Name = "layerLaber";
            this.layerLaber.Size = new System.Drawing.Size(66, 13);
            this.layerLaber.TabIndex = 0;
            this.layerLaber.Text = "Select Layer";
            // 
            // LayerCombo
            // 
            this.LayerCombo.FormattingEnabled = true;
            this.LayerCombo.Location = new System.Drawing.Point(10, 53);
            this.LayerCombo.Name = "LayerCombo";
            this.LayerCombo.Size = new System.Drawing.Size(467, 21);
            this.LayerCombo.TabIndex = 1;
            // 
            // ColumnTypeCombo
            // 
            this.ColumnTypeCombo.FormattingEnabled = true;
            this.ColumnTypeCombo.Location = new System.Drawing.Point(15, 145);
            this.ColumnTypeCombo.Name = "ColumnTypeCombo";
            this.ColumnTypeCombo.Size = new System.Drawing.Size(467, 21);
            this.ColumnTypeCombo.TabIndex = 3;
            this.ColumnTypeCombo.SelectedIndexChanged += new System.EventHandler(this.ColumnTypeCombo_SelectedIndexChanged);
            // 
            // LabelColumn
            // 
            this.LabelColumn.AutoSize = true;
            this.LabelColumn.Location = new System.Drawing.Point(12, 114);
            this.LabelColumn.Name = "LabelColumn";
            this.LabelColumn.Size = new System.Drawing.Size(102, 13);
            this.LabelColumn.TabIndex = 2;
            this.LabelColumn.Text = "Select Column Type";
            // 
            // btn_Create
            // 
            this.btn_Create.Location = new System.Drawing.Point(20, 202);
            this.btn_Create.Name = "btn_Create";
            this.btn_Create.Size = new System.Drawing.Size(146, 34);
            this.btn_Create.TabIndex = 4;
            this.btn_Create.Text = "Create";
            this.btn_Create.UseVisualStyleBackColor = true;
            this.btn_Create.Click += new System.EventHandler(this.btn_Create_Click);
            // 
            // CadForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(494, 251);
            this.Controls.Add(this.btn_Create);
            this.Controls.Add(this.ColumnTypeCombo);
            this.Controls.Add(this.LabelColumn);
            this.Controls.Add(this.LayerCombo);
            this.Controls.Add(this.layerLaber);
            this.Name = "CadForm";
            this.Text = "CadForm";
            this.Load += new System.EventHandler(this.CadForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label layerLaber;
        private System.Windows.Forms.ComboBox LayerCombo;
        private System.Windows.Forms.ComboBox ColumnTypeCombo;
        private System.Windows.Forms.Label LabelColumn;
        private System.Windows.Forms.Button btn_Create;
    }
}