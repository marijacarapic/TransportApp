using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using System.Windows.Forms;
using Client.ServerCommunication;
using System.Net.Sockets;

namespace Client.GuiController
{
    public class FrmMainController
    {
        public FrmMain FrmMain { get; set; }

        internal FrmMain CreateMainForm()
        {
            FrmMain = new FrmMain();
            FrmMain.FormBorderStyle = FormBorderStyle.Sizable;
            FrmMain.StartPosition = FormStartPosition.CenterScreen;
           

            FrmMain.btnVozila.Click += (s, a) => Coordinator.Instance.ShowUCVozila();
            FrmMain.btnUgovori.Click += (s, a) => Coordinator.Instance.ShowUCUgovoriTransporta();
            FrmMain.btnDnevneStavke.Click += (s, a) => Coordinator.Instance.ShowUCDnevneStavke();

            return FrmMain;
        }

        public void ChangePanel(UserControl userControl)
        {
            FrmMain.pnlMain.Controls.Clear();
            userControl.Parent = FrmMain.pnlMain;
            userControl.Dock = DockStyle.Fill;
        }

    }
}
