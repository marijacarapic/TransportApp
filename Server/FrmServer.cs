using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Server
{
    public partial class FrmServer : Form
    {
        Server server;
        public FrmServer()
        {
            InitializeComponent();
            btnStop.Enabled = false;
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            server = new Server();
            server.Start();
            btnStart.Enabled = false;
            btnStop.Enabled = true;
            lblServer.Text = "Server je pokrenut!";

            Thread thread = new Thread(server.PoveziKlijente);
            thread.Start();
            
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            server?.Stop();
            btnStart.Enabled = true;
            btnStop.Enabled = false;
            lblServer.Text = "Server je zaustavljen!";
        }

        private void FrmServer_FormClosed(object sender, FormClosedEventArgs e)
        {
            Environment.Exit(0);
        }

        private void FrmServer_FormClosing(object sender, FormClosingEventArgs e)
        {
            Environment.Exit(0);

        }
    }
}
