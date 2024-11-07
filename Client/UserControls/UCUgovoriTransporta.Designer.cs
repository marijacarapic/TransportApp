namespace Client.UserControls
{
    partial class UCUgovoriTransporta
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnDodajUgovor = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnPretrazi = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txtNarucilac = new System.Windows.Forms.TextBox();
            this.dgvUgovori = new System.Windows.Forms.DataGridView();
            this.pnlHeaderUgovor = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUgovori)).BeginInit();
            this.pnlHeaderUgovor.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(881, 490);
            this.dataGridView1.TabIndex = 3;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.GrayText;
            this.panel1.Controls.Add(this.btnDodajUgovor);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 490);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(881, 114);
            this.panel1.TabIndex = 2;
            // 
            // btnDodajUgovor
            // 
            this.btnDodajUgovor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDodajUgovor.Location = new System.Drawing.Point(734, 11);
            this.btnDodajUgovor.Name = "btnDodajUgovor";
            this.btnDodajUgovor.Size = new System.Drawing.Size(135, 26);
            this.btnDodajUgovor.TabIndex = 2;
            this.btnDodajUgovor.Text = "Dodaj ugovor";
            this.btnDodajUgovor.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(195, 40);
            this.label1.TabIndex = 0;
            this.label1.Text = "Upravljanje \r\nugovorima transporta";
            // 
            // btnPretrazi
            // 
            this.btnPretrazi.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnPretrazi.Location = new System.Drawing.Point(420, 59);
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
            this.label3.Location = new System.Drawing.Point(341, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(238, 18);
            this.label3.TabIndex = 5;
            this.label3.Text = "Pretraga ugovora po naruciocu";
            // 
            // txtNarucilac
            // 
            this.txtNarucilac.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtNarucilac.Location = new System.Drawing.Point(370, 35);
            this.txtNarucilac.Name = "txtNarucilac";
            this.txtNarucilac.Size = new System.Drawing.Size(178, 22);
            this.txtNarucilac.TabIndex = 3;
            // 
            // dgvUgovori
            // 
            this.dgvUgovori.AllowUserToAddRows = false;
            this.dgvUgovori.AllowUserToDeleteRows = false;
            this.dgvUgovori.AllowUserToOrderColumns = true;
            this.dgvUgovori.AllowUserToResizeColumns = false;
            this.dgvUgovori.AllowUserToResizeRows = false;
            this.dgvUgovori.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvUgovori.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dgvUgovori.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUgovori.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvUgovori.Location = new System.Drawing.Point(0, 0);
            this.dgvUgovori.Name = "dgvUgovori";
            this.dgvUgovori.RowHeadersWidth = 51;
            this.dgvUgovori.RowTemplate.Height = 24;
            this.dgvUgovori.Size = new System.Drawing.Size(881, 402);
            this.dgvUgovori.TabIndex = 4;
            // 
            // pnlHeaderUgovor
            // 
            this.pnlHeaderUgovor.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.pnlHeaderUgovor.Controls.Add(this.btnPretrazi);
            this.pnlHeaderUgovor.Controls.Add(this.label3);
            this.pnlHeaderUgovor.Controls.Add(this.txtNarucilac);
            this.pnlHeaderUgovor.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeaderUgovor.Location = new System.Drawing.Point(0, 0);
            this.pnlHeaderUgovor.Name = "pnlHeaderUgovor";
            this.pnlHeaderUgovor.Size = new System.Drawing.Size(881, 88);
            this.pnlHeaderUgovor.TabIndex = 4;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dgvUgovori);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 88);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(881, 402);
            this.panel2.TabIndex = 5;
            // 
            // UCUgovoriTransporta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.pnlHeaderUgovor);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panel1);
            this.Name = "UCUgovoriTransporta";
            this.Size = new System.Drawing.Size(881, 604);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUgovori)).EndInit();
            this.pnlHeaderUgovor.ResumeLayout(false);
            this.pnlHeaderUgovor.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.DataGridView dgvUgovori;
        public System.Windows.Forms.Button btnDodajUgovor;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.TextBox txtNarucilac;
        public System.Windows.Forms.Button btnPretrazi;
        private System.Windows.Forms.Panel pnlHeaderUgovor;
        private System.Windows.Forms.Panel panel2;
    }
}
