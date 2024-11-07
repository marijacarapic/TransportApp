namespace Client.Forms
{
    partial class FrmStavkaTransporta
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
            this.txtSadrzajTransporta = new System.Windows.Forms.TextBox();
            this.txtVozilo = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtNarucilac = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtPredjeniPut = new System.Windows.Forms.TextBox();
            this.cbIzvrsenTransport = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnAzurirajStavku = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.txtAdresaOd = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtAdresaDo = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.txtAdresaOd);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtAdresaDo);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txtSadrzajTransporta);
            this.groupBox1.Controls.Add(this.txtVozilo);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtNarucilac);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtPredjeniPut);
            this.groupBox1.Controls.Add(this.cbIzvrsenTransport);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btnAzurirajStavku);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Location = new System.Drawing.Point(15, 21);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(395, 401);
            this.groupBox1.TabIndex = 59;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Azuriranje stavke transporta";
            // 
            // txtSadrzajTransporta
            // 
            this.txtSadrzajTransporta.Location = new System.Drawing.Point(197, 155);
            this.txtSadrzajTransporta.Name = "txtSadrzajTransporta";
            this.txtSadrzajTransporta.ReadOnly = true;
            this.txtSadrzajTransporta.Size = new System.Drawing.Size(164, 22);
            this.txtSadrzajTransporta.TabIndex = 38;
            // 
            // txtVozilo
            // 
            this.txtVozilo.Location = new System.Drawing.Point(197, 204);
            this.txtVozilo.Name = "txtVozilo";
            this.txtVozilo.ReadOnly = true;
            this.txtVozilo.Size = new System.Drawing.Size(164, 22);
            this.txtVozilo.TabIndex = 37;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(33, 161);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(122, 16);
            this.label3.TabIndex = 36;
            this.label3.Text = " Sadrzaj transporta:";
            // 
            // txtNarucilac
            // 
            this.txtNarucilac.Location = new System.Drawing.Point(195, 32);
            this.txtNarucilac.Name = "txtNarucilac";
            this.txtNarucilac.ReadOnly = true;
            this.txtNarucilac.Size = new System.Drawing.Size(164, 22);
            this.txtNarucilac.TabIndex = 34;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(37, 32);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(130, 16);
            this.label4.TabIndex = 33;
            this.label4.Text = "Narucilac transporta:";
            // 
            // txtPredjeniPut
            // 
            this.txtPredjeniPut.Location = new System.Drawing.Point(197, 295);
            this.txtPredjeniPut.Name = "txtPredjeniPut";
            this.txtPredjeniPut.Size = new System.Drawing.Size(164, 22);
            this.txtPredjeniPut.TabIndex = 32;
            // 
            // cbIzvrsenTransport
            // 
            this.cbIzvrsenTransport.AutoSize = true;
            this.cbIzvrsenTransport.Location = new System.Drawing.Point(197, 244);
            this.cbIzvrsenTransport.Name = "cbIzvrsenTransport";
            this.cbIzvrsenTransport.Size = new System.Drawing.Size(79, 20);
            this.cbIzvrsenTransport.TabIndex = 31;
            this.cbIzvrsenTransport.Text = "Izvrseno";
            this.cbIzvrsenTransport.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(39, 298);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 16);
            this.label2.TabIndex = 30;
            this.label2.Text = "Predjeni put:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(39, 248);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(116, 16);
            this.label1.TabIndex = 29;
            this.label1.Text = "Usluga transporta:";
            // 
            // btnAzurirajStavku
            // 
            this.btnAzurirajStavku.Location = new System.Drawing.Point(230, 344);
            this.btnAzurirajStavku.Name = "btnAzurirajStavku";
            this.btnAzurirajStavku.Size = new System.Drawing.Size(102, 30);
            this.btnAzurirajStavku.TabIndex = 15;
            this.btnAzurirajStavku.Text = "Azuriraj stavku";
            this.btnAzurirajStavku.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(39, 355);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(47, 16);
            this.label8.TabIndex = 2;
            this.label8.Text = "Vozilo:";
            // 
            // txtAdresaOd
            // 
            this.txtAdresaOd.Location = new System.Drawing.Point(195, 71);
            this.txtAdresaOd.Name = "txtAdresaOd";
            this.txtAdresaOd.ReadOnly = true;
            this.txtAdresaOd.Size = new System.Drawing.Size(164, 22);
            this.txtAdresaOd.TabIndex = 42;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(37, 116);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(72, 16);
            this.label5.TabIndex = 41;
            this.label5.Text = "AdreseDo:";
            // 
            // txtAdresaDo
            // 
            this.txtAdresaDo.Location = new System.Drawing.Point(195, 110);
            this.txtAdresaDo.Name = "txtAdresaDo";
            this.txtAdresaDo.ReadOnly = true;
            this.txtAdresaDo.Size = new System.Drawing.Size(164, 22);
            this.txtAdresaDo.TabIndex = 40;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(37, 77);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(72, 16);
            this.label6.TabIndex = 39;
            this.label6.Text = "AdresaOd:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(39, 210);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(47, 16);
            this.label7.TabIndex = 43;
            this.label7.Text = "Vozilo:";
            // 
            // FrmStavkaTransporta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(433, 438);
            this.Controls.Add(this.groupBox1);
            this.Name = "FrmStavkaTransporta";
            this.RightToLeftLayout = true;
            this.Text = "Azuriranje";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        public System.Windows.Forms.Button btnAzurirajStavku;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.TextBox txtNarucilac;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.TextBox txtPredjeniPut;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.CheckBox cbIzvrsenTransport;
        public System.Windows.Forms.TextBox txtVozilo;
        public System.Windows.Forms.TextBox txtSadrzajTransporta;
        public System.Windows.Forms.TextBox txtAdresaOd;
        private System.Windows.Forms.Label label5;
        public System.Windows.Forms.TextBox txtAdresaDo;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
    }
}