using Client.Forms;
using Client.GuiController;
using Client.ServerCommunication;
using Client.UserControls;
using Common.Domen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    public class Coordinator
    {
        //mora da ima promenljiu sa sakog GUIkontrolera

        private FrmMainController frmMainController;
        private FrmLoginController frmLoginController;

        private UCUgovoriTransportaController uCUgovoriTransportaController;
        private UCVozilaController uCVozilaController;
        private UCDnevneStavkeController uCDnevneStavkeController;

        private FrmVoziloController frmVoziloController;
        private FrmUgovorTransportaController frmUgovorTransportaController;
        private FrmStavkaTransportaController frmStavkaTransportaController;
        private FrmAzuriranjeVozilaController frmAzuriranjeVozilaController;

        //properti za svaku formu mora da postoji
        //sluzi za menjanje formi
        public FrmLogin FrmLogin { get; set; }
        public FrmMain FrmMain { get; set; }

        public UCVozila UCVozila { get; set; }
        public UCUgovoriTransporta UCUgovoriTransporta { get; set; }
        public UCDnevneStavkeTransporta UCDnevneStavke { get; set; }

        public FrmVozilo FrmVozilo { get; set; }
        public FrmUgovorTransporta FrmUgovorTransporta { get; set; }
        public FrmStavkaTransporta FrmStavkaTransporta { get; set; }
        public FrmAzuriranjeVozila FrmAzuriranjeVozila { get; set; }

        private static Coordinator instance;
        public static Coordinator Instance
        {
            get
            {
                if(instance == null)
                {
                    instance = new Coordinator();
                    
                }
                return instance;
            }
        }

        private Coordinator()
        {
            frmLoginController = new FrmLoginController();
            frmMainController = new FrmMainController();
            uCUgovoriTransportaController= new UCUgovoriTransportaController();
            uCVozilaController = new UCVozilaController();
            frmVoziloController = new FrmVoziloController();
            frmUgovorTransportaController = new FrmUgovorTransportaController();
            uCDnevneStavkeController = new UCDnevneStavkeController();
            frmStavkaTransportaController = new FrmStavkaTransportaController();
            frmAzuriranjeVozilaController = new FrmAzuriranjeVozilaController();
        }

        public void OpenLoginForm()
        {
            try
            {
                Communication.Instance.Connect();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Sistem ne moze da se poveze na server" + ex.Message);
                return;
            }

            FrmLogin = frmLoginController.CreateLoginForm();
            FrmLogin.Show();
        }

        public void OpenMainForm()
        {
            FrmMain = frmMainController.CreateMainForm();

            FrmMain.Show();

        }

        public void ShowUCVozila()
        {
            
            frmMainController.ChangePanel(uCVozilaController.CreateUCVozilo());

        }

        public void ShowUCUgovoriTransporta()
        {
            frmMainController.ChangePanel(uCUgovoriTransportaController.CreateUCUgovoriTransporta());

        }

        public void OpenFrmVozilo()
        {
            FrmVozilo = frmVoziloController.CreateFrmVozilo();
            FrmVozilo.ShowDialog();
          
        }
       

        public void OpenFrmUgovorTransporta()
        {
            FrmUgovorTransporta = frmUgovorTransportaController.CreateFrmUgovorTransporta();
            FrmUgovorTransporta.ShowDialog();
        }

        public void ShowUCDnevneStavke()
        {
            frmMainController.ChangePanel(uCDnevneStavkeController.CreateUCDnevneStavke());

        }

        public void OpenFrmStavkaTransporta(StavkaTransporta stavkaZaAzuriranje)
        {
            FrmStavkaTransporta = frmStavkaTransportaController.CreateFrmStavkaTransporta(stavkaZaAzuriranje);
            FrmStavkaTransporta.ShowDialog();

        }

        public void OpenFrmAzuriranjeVozila(Vozilo vozilo)
        {
            FrmAzuriranjeVozila = frmAzuriranjeVozilaController.CreateFrmAzuriranjeVozila(vozilo);
            FrmAzuriranjeVozila.ShowDialog();

        }
    }
}
