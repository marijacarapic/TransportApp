namespace Client.Forms
{
    partial class FrmVozilo
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnObrisiTipSadrzaja = new System.Windows.Forms.Button();
            this.btnDodajTipSadrzaja = new System.Windows.Forms.Button();
            this.cmbNazivSadrzaja = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.dgvTipSadrzajaTransporta = new System.Windows.Forms.DataGridView();
            this.btnDodajVozilo = new System.Windows.Forms.Button();
            this.cmbTipVozila = new System.Windows.Forms.ComboBox();
            this.txtKapacitet = new System.Windows.Forms.TextBox();
            this.txtRegistracija = new System.Windows.Forms.TextBox();
            this.txtModel = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTipSadrzajaTransporta)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.groupBox1.Controls.Add(this.btnObrisiTipSadrzaja);
            this.groupBox1.Controls.Add(this.btnDodajTipSadrzaja);
            this.groupBox1.Controls.Add(this.cmbNazivSadrzaja);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.dgvTipSadrzajaTransporta);
            this.groupBox1.Location = new System.Drawing.Point(78, 229);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(519, 225);
            this.groupBox1.TabIndex = 39;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Dodavanje sadrzaja transporta";
            // 
            // btnObrisiTipSadrzaja
            // 
            this.btnObrisiTipSadrzaja.Location = new System.Drawing.Point(401, 109);
            this.btnObrisiTipSadrzaja.Name = "btnObrisiTipSadrzaja";
            this.btnObrisiTipSadrzaja.Size = new System.Drawing.Size(75, 23);
            this.btnObrisiTipSadrzaja.TabIndex = 4;
            this.btnObrisiTipSadrzaja.Text = "Obrisi tip";
            this.btnObrisiTipSadrzaja.UseVisualStyleBackColor = true;
            // 
            // btnDodajTipSadrzaja
            // 
            this.btnDodajTipSadrzaja.Location = new System.Drawing.Point(401, 80);
            this.btnDodajTipSadrzaja.Name = "btnDodajTipSadrzaja";
            this.btnDodajTipSadrzaja.Size = new System.Drawing.Size(75, 23);
            this.btnDodajTipSadrzaja.TabIndex = 3;
            this.btnDodajTipSadrzaja.Text = "Dodaj tip";
            this.btnDodajTipSadrzaja.UseVisualStyleBackColor = true;
            // 
            // cmbNazivSadrzaja
            // 
            this.cmbNazivSadrzaja.FormattingEnabled = true;
            this.cmbNazivSadrzaja.Location = new System.Drawing.Point(175, 35);
            this.cmbNazivSadrzaja.Name = "cmbNazivSadrzaja";
            this.cmbNazivSadrzaja.Size = new System.Drawing.Size(188, 24);
            this.cmbNazivSadrzaja.TabIndex = 2;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(36, 38);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(133, 16);
            this.label5.TabIndex = 1;
            this.label5.Text = "Izaberite tip sadrzaja:";
            // 
            // dgvTipSadrzajaTransporta
            // 
            this.dgvTipSadrzajaTransporta.AllowUserToAddRows = false;
            this.dgvTipSadrzajaTransporta.AllowUserToDeleteRows = false;
            this.dgvTipSadrzajaTransporta.AllowUserToResizeColumns = false;
            this.dgvTipSadrzajaTransporta.AllowUserToResizeRows = false;
            this.dgvTipSadrzajaTransporta.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvTipSadrzajaTransporta.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dgvTipSadrzajaTransporta.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTipSadrzajaTransporta.Location = new System.Drawing.Point(16, 80);
            this.dgvTipSadrzajaTransporta.Name = "dgvTipSadrzajaTransporta";
            this.dgvTipSadrzajaTransporta.RowHeadersWidth = 51;
            this.dgvTipSadrzajaTransporta.RowTemplate.Height = 24;
            this.dgvTipSadrzajaTransporta.Size = new System.Drawing.Size(357, 139);
            this.dgvTipSadrzajaTransporta.TabIndex = 0;
            // 
            // btnDodajVozilo
            // 
            this.btnDodajVozilo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnDodajVozilo.Location = new System.Drawing.Point(494, 482);
            this.btnDodajVozilo.Name = "btnDodajVozilo";
            this.btnDodajVozilo.Size = new System.Drawing.Size(103, 32);
            this.btnDodajVozilo.TabIndex = 38;
            this.btnDodajVozilo.Text = "Dodaj vozilo";
            this.btnDodajVozilo.UseVisualStyleBackColor = true;
            // 
            // cmbTipVozila
            // 
            this.cmbTipVozila.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cmbTipVozila.FormattingEnabled = true;
            this.cmbTipVozila.Location = new System.Drawing.Point(230, 70);
            this.cmbTipVozila.Name = "cmbTipVozila";
            this.cmbTipVozila.Size = new System.Drawing.Size(196, 24);
            this.cmbTipVozila.TabIndex = 37;
            // 
            // txtKapacitet
            // 
            this.txtKapacitet.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtKapacitet.Location = new System.Drawing.Point(230, 170);
            this.txtKapacitet.Name = "txtKapacitet";
            this.txtKapacitet.Size = new System.Drawing.Size(196, 22);
            this.txtKapacitet.TabIndex = 36;
            // 
            // txtRegistracija
            // 
            this.txtRegistracija.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtRegistracija.Location = new System.Drawing.Point(230, 31);
            this.txtRegistracija.Name = "txtRegistracija";
            this.txtRegistracija.Size = new System.Drawing.Size(196, 22);
            this.txtRegistracija.TabIndex = 35;
            // 
            // txtModel
            // 
            this.txtModel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtModel.Location = new System.Drawing.Point(230, 119);
            this.txtModel.Name = "txtModel";
            this.txtModel.Size = new System.Drawing.Size(196, 22);
            this.txtModel.TabIndex = 34;
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(75, 78);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 16);
            this.label4.TabIndex = 33;
            this.label4.Text = "Tip vozila:";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(77, 176);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 16);
            this.label3.TabIndex = 32;
            this.label3.Text = "Kapacitet:";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(75, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 16);
            this.label2.TabIndex = 31;
            this.label2.Text = "Registracija:";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(77, 125);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 16);
            this.label1.TabIndex = 30;
            this.label1.Text = "Model vozila:";
            // 
            // FrmVozilo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(644, 533);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnDodajVozilo);
            this.Controls.Add(this.cmbTipVozila);
            this.Controls.Add(this.txtKapacitet);
            this.Controls.Add(this.txtRegistracija);
            this.Controls.Add(this.txtModel);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "FrmVozilo";
            this.Text = "Dodavanje vozila";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTipSadrzajaTransporta)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label5;
        public System.Windows.Forms.ComboBox cmbTipVozila;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.Button btnObrisiTipSadrzaja;
        public System.Windows.Forms.Button btnDodajTipSadrzaja;
        public System.Windows.Forms.ComboBox cmbNazivSadrzaja;
        public System.Windows.Forms.Button btnDodajVozilo;
        public System.Windows.Forms.TextBox txtKapacitet;
        public System.Windows.Forms.TextBox txtRegistracija;
        public System.Windows.Forms.TextBox txtModel;
        public System.Windows.Forms.DataGridView dgvTipSadrzajaTransporta;
    }
}