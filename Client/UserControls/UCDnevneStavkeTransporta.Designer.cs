namespace Client.UserControls
{
    partial class UCDnevneStavkeTransporta
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnAzuriraj = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpDatumPretrage = new System.Windows.Forms.DateTimePicker();
            this.btnPretrazi = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.pnlHeaderVozilo = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dgvDnevneStavke = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            this.pnlHeaderVozilo.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDnevneStavke)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.GrayText;
            this.panel1.Controls.Add(this.btnAzuriraj);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 475);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(826, 114);
            this.panel1.TabIndex = 3;
            // 
            // btnAzuriraj
            // 
            this.btnAzuriraj.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAzuriraj.Location = new System.Drawing.Point(678, 11);
            this.btnAzuriraj.Name = "btnAzuriraj";
            this.btnAzuriraj.Size = new System.Drawing.Size(135, 26);
            this.btnAzuriraj.TabIndex = 8;
            this.btnAzuriraj.Text = "Azuriraj stavku";
            this.btnAzuriraj.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(188, 40);
            this.label1.TabIndex = 0;
            this.label1.Text = "Upravljanje dnevnim\r\nstavkama transporta";
            // 
            // dtpDatumPretrage
            // 
            this.dtpDatumPretrage.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dtpDatumPretrage.Location = new System.Drawing.Point(306, 35);
            this.dtpDatumPretrage.Name = "dtpDatumPretrage";
            this.dtpDatumPretrage.Size = new System.Drawing.Size(244, 22);
            this.dtpDatumPretrage.TabIndex = 7;
            // 
            // btnPretrazi
            // 
            this.btnPretrazi.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnPretrazi.Location = new System.Drawing.Point(392, 60);
            this.btnPretrazi.Name = "btnPretrazi";
            this.btnPretrazi.Size = new System.Drawing.Size(75, 23);
            this.btnPretrazi.TabIndex = 6;
            this.btnPretrazi.Text = "Pretrazi";
            this.btnPretrazi.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(335, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(182, 18);
            this.label3.TabIndex = 5;
            this.label3.Text = "Pretraga dnevnih stavki";
            // 
            // pnlHeaderVozilo
            // 
            this.pnlHeaderVozilo.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.pnlHeaderVozilo.Controls.Add(this.dtpDatumPretrage);
            this.pnlHeaderVozilo.Controls.Add(this.btnPretrazi);
            this.pnlHeaderVozilo.Controls.Add(this.label3);
            this.pnlHeaderVozilo.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeaderVozilo.Location = new System.Drawing.Point(0, 0);
            this.pnlHeaderVozilo.Name = "pnlHeaderVozilo";
            this.pnlHeaderVozilo.Size = new System.Drawing.Size(826, 88);
            this.pnlHeaderVozilo.TabIndex = 5;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dgvDnevneStavke);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 88);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(826, 387);
            this.panel2.TabIndex = 6;
            // 
            // dgvDnevneStavke
            // 
            this.dgvDnevneStavke.AllowUserToAddRows = false;
            this.dgvDnevneStavke.AllowUserToDeleteRows = false;
            this.dgvDnevneStavke.AllowUserToOrderColumns = true;
            this.dgvDnevneStavke.AllowUserToResizeColumns = false;
            this.dgvDnevneStavke.AllowUserToResizeRows = false;
            this.dgvDnevneStavke.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDnevneStavke.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dgvDnevneStavke.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDnevneStavke.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDnevneStavke.Location = new System.Drawing.Point(0, 0);
            this.dgvDnevneStavke.Name = "dgvDnevneStavke";
            this.dgvDnevneStavke.RowHeadersWidth = 51;
            this.dgvDnevneStavke.RowTemplate.Height = 24;
            this.dgvDnevneStavke.Size = new System.Drawing.Size(826, 387);
            this.dgvDnevneStavke.TabIndex = 0;
            // 
            // UCDnevneStavkeTransporta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.pnlHeaderVozilo);
            this.Controls.Add(this.panel1);
            this.Name = "UCDnevneStavkeTransporta";
            this.Size = new System.Drawing.Size(826, 589);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.pnlHeaderVozilo.ResumeLayout(false);
            this.pnlHeaderVozilo.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDnevneStavke)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.Button btnPretrazi;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.DateTimePicker dtpDatumPretrage;
        public System.Windows.Forms.Button btnAzuriraj;
        private System.Windows.Forms.Panel pnlHeaderVozilo;
        private System.Windows.Forms.Panel panel2;
        public System.Windows.Forms.DataGridView dgvDnevneStavke;
    }
}
