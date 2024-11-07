namespace Client.UserControls
{
    partial class UCVozila
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.btnDodajVozilo = new System.Windows.Forms.Button();
            this.btnObrisiVozilo = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dgvVozila = new System.Windows.Forms.DataGridView();
            this.btnAzuriraj = new System.Windows.Forms.Button();
            this.pnlHeaderVozila = new System.Windows.Forms.Panel();
            this.cmbPretragaPoTipu = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVozila)).BeginInit();
            this.pnlHeaderVozila.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(184, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Upravljanje vozilima";
            // 
            // btnDodajVozilo
            // 
            this.btnDodajVozilo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDodajVozilo.Location = new System.Drawing.Point(1010, 43);
            this.btnDodajVozilo.Name = "btnDodajVozilo";
            this.btnDodajVozilo.Size = new System.Drawing.Size(135, 26);
            this.btnDodajVozilo.TabIndex = 1;
            this.btnDodajVozilo.Text = "Dodaj vozilo";
            this.btnDodajVozilo.UseVisualStyleBackColor = true;
            // 
            // btnObrisiVozilo
            // 
            this.btnObrisiVozilo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnObrisiVozilo.Location = new System.Drawing.Point(1010, 75);
            this.btnObrisiVozilo.Name = "btnObrisiVozilo";
            this.btnObrisiVozilo.Size = new System.Drawing.Size(135, 26);
            this.btnObrisiVozilo.TabIndex = 2;
            this.btnObrisiVozilo.Text = "Obrisi vozilo";
            this.btnObrisiVozilo.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.GrayText;
            this.panel1.Controls.Add(this.btnObrisiVozilo);
            this.panel1.Controls.Add(this.btnDodajVozilo);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 630);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1162, 114);
            this.panel1.TabIndex = 0;
            // 
            // dgvVozila
            // 
            this.dgvVozila.AllowUserToAddRows = false;
            this.dgvVozila.AllowUserToDeleteRows = false;
            this.dgvVozila.AllowUserToResizeColumns = false;
            this.dgvVozila.AllowUserToResizeRows = false;
            this.dgvVozila.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvVozila.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dgvVozila.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvVozila.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvVozila.Location = new System.Drawing.Point(0, 0);
            this.dgvVozila.Name = "dgvVozila";
            this.dgvVozila.RowHeadersWidth = 51;
            this.dgvVozila.RowTemplate.Height = 24;
            this.dgvVozila.Size = new System.Drawing.Size(1162, 542);
            this.dgvVozila.TabIndex = 1;
            // 
            // btnAzuriraj
            // 
            this.btnAzuriraj.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAzuriraj.Location = new System.Drawing.Point(1010, 641);
            this.btnAzuriraj.Name = "btnAzuriraj";
            this.btnAzuriraj.Size = new System.Drawing.Size(135, 26);
            this.btnAzuriraj.TabIndex = 3;
            this.btnAzuriraj.Text = "Azuriraj vozilo";
            this.btnAzuriraj.UseVisualStyleBackColor = true;
            // 
            // pnlHeaderVozila
            // 
            this.pnlHeaderVozila.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.pnlHeaderVozila.Controls.Add(this.cmbPretragaPoTipu);
            this.pnlHeaderVozila.Controls.Add(this.label3);
            this.pnlHeaderVozila.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeaderVozila.Location = new System.Drawing.Point(0, 0);
            this.pnlHeaderVozila.Name = "pnlHeaderVozila";
            this.pnlHeaderVozila.Size = new System.Drawing.Size(1162, 88);
            this.pnlHeaderVozila.TabIndex = 4;
            // 
            // cmbPretragaPoTipu
            // 
            this.cmbPretragaPoTipu.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cmbPretragaPoTipu.FormattingEnabled = true;
            this.cmbPretragaPoTipu.Location = new System.Drawing.Point(489, 36);
            this.cmbPretragaPoTipu.Name = "cmbPretragaPoTipu";
            this.cmbPretragaPoTipu.Size = new System.Drawing.Size(160, 24);
            this.cmbPretragaPoTipu.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(483, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(175, 18);
            this.label3.TabIndex = 6;
            this.label3.Text = "Pretraga vozila po tipu";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dgvVozila);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 88);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1162, 542);
            this.panel2.TabIndex = 5;
            // 
            // UCVozila
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.pnlHeaderVozila);
            this.Controls.Add(this.btnAzuriraj);
            this.Controls.Add(this.panel1);
            this.Name = "UCVozila";
            this.Size = new System.Drawing.Size(1162, 744);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVozila)).EndInit();
            this.pnlHeaderVozila.ResumeLayout(false);
            this.pnlHeaderVozila.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.Button btnDodajVozilo;
        public System.Windows.Forms.DataGridView dgvVozila;
        public System.Windows.Forms.Button btnObrisiVozilo;
        public System.Windows.Forms.Button btnAzuriraj;
        private System.Windows.Forms.Panel pnlHeaderVozila;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.ComboBox cmbPretragaPoTipu;
        private System.Windows.Forms.Panel panel2;
    }
}
