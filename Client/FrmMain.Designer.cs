namespace Client
{
    partial class FrmMain
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
            this.components = new System.ComponentModel.Container();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.pnlFoother = new System.Windows.Forms.Panel();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btnUgovori = new System.Windows.Forms.Button();
            this.btnVozila = new System.Windows.Forms.Button();
            this.btnDnevneStavke = new System.Windows.Forms.Button();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.pnlHeader.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // pnlFoother
            // 
            this.pnlFoother.BackColor = System.Drawing.SystemColors.GrayText;
            this.pnlFoother.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlFoother.Location = new System.Drawing.Point(0, 430);
            this.pnlFoother.Name = "pnlFoother";
            this.pnlFoother.Size = new System.Drawing.Size(800, 20);
            this.pnlFoother.TabIndex = 2;
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.pnlHeader.Controls.Add(this.panel1);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(800, 78);
            this.pnlHeader.TabIndex = 3;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tableLayoutPanel1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 78);
            this.panel1.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.tableLayoutPanel1.ColumnCount = 5;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.Controls.Add(this.btnUgovori, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnVozila, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnDnevneStavke, 2, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(800, 78);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // btnUgovori
            // 
            this.btnUgovori.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnUgovori.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.btnUgovori.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUgovori.Location = new System.Drawing.Point(487, 12);
            this.btnUgovori.Name = "btnUgovori";
            this.btnUgovori.Size = new System.Drawing.Size(145, 53);
            this.btnUgovori.TabIndex = 2;
            this.btnUgovori.Text = "Ugovori transporta";
            this.btnUgovori.UseVisualStyleBackColor = false;
            // 
            // btnVozila
            // 
            this.btnVozila.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnVozila.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.btnVozila.Location = new System.Drawing.Point(167, 12);
            this.btnVozila.Name = "btnVozila";
            this.btnVozila.Size = new System.Drawing.Size(145, 53);
            this.btnVozila.TabIndex = 1;
            this.btnVozila.Text = "Vozila";
            this.btnVozila.UseVisualStyleBackColor = false;
            // 
            // btnDnevneStavke
            // 
            this.btnDnevneStavke.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnDnevneStavke.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.btnDnevneStavke.Location = new System.Drawing.Point(327, 12);
            this.btnDnevneStavke.Name = "btnDnevneStavke";
            this.btnDnevneStavke.Size = new System.Drawing.Size(145, 53);
            this.btnDnevneStavke.TabIndex = 0;
            this.btnDnevneStavke.Text = "Dnevne stavke";
            this.btnDnevneStavke.UseVisualStyleBackColor = false;
            // 
            // pnlMain
            // 
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 78);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(800, 352);
            this.pnlMain.TabIndex = 4;
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.pnlHeader);
            this.Controls.Add(this.pnlFoother);
            this.Name = "FrmMain";
            this.Text = "TransportApp";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.pnlHeader.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.Panel pnlFoother;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.Button btnUgovori;
        public System.Windows.Forms.Button btnVozila;
        public System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        public System.Windows.Forms.Button btnDnevneStavke;
    }
}

