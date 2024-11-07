using Client.Forms;
using Client.ServerCommunication;
using Client.UserControls;
using Common.Domen;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client.GuiController
{
    public class UCDnevneStavkeController
    {
        public UCDnevneStavkeTransporta UCDnevneStavke { get; set; }
        private  BindingList<StavkaTransporta> stavke;
        public StavkaTransporta StavkaTransporta { get; set; }
        internal UserControl CreateUCDnevneStavke()
        {
            UCDnevneStavke = new UCDnevneStavkeTransporta();
            UCDnevneStavke.Dock = DockStyle.Fill;

            stavke = new BindingList<StavkaTransporta>( Communication.Instance.PretraziStavkeTransporta(DateTime.Now));
        

            UCDnevneStavke.dgvDnevneStavke.DataSource = stavke;
            UCDnevneStavke.dgvDnevneStavke.Columns[0].Visible = false;
            UCDnevneStavke.btnPretrazi.Click += btnPretrazi_Click;
            UCDnevneStavke.btnAzuriraj.Click += btnAzuriraj_Click;
            
            return UCDnevneStavke;
        }

        private void btnAzuriraj_Click(object sender, EventArgs e)
        {
           
            if (stavke.Count == 0) 
            {
                MessageBox.Show("Ne postoje dnevne stavke transporta za uneti datum!\nGreska prilikom azuriranja!");
                return;
            }
            if (UCDnevneStavke.dgvDnevneStavke.SelectedRows.Count == 0)
            {
                MessageBox.Show("Izaberite stavku transporta koju zelite da azurirate ");
                return;
            }
            try
            {
                
                StavkaTransporta stavka = (StavkaTransporta)UCDnevneStavke.dgvDnevneStavke.SelectedRows[0].DataBoundItem;
                StavkaTransporta = Communication.Instance.UcitajStavkuTransporta(stavka);
                Coordinator.Instance.OpenFrmStavkaTransporta(StavkaTransporta);
                stavke = new BindingList<StavkaTransporta>(Communication.Instance.PretraziStavkeTransporta(StavkaTransporta.Datum));
                UCDnevneStavke.dgvDnevneStavke.DataSource = stavke;
            }
            catch (Exception ex)
            {

                MessageBox.Show("Sistem ne moze da ucita stavku transporta!" + ex.Message);
            }


        }

        private void btnPretrazi_Click(object sender, EventArgs e)
        {
            DateTime datum = UCDnevneStavke.dtpDatumPretrage.Value;

            try
            {
                stavke = new BindingList<StavkaTransporta>(Communication.Instance.PretraziStavkeTransporta(datum.Date));
                UCDnevneStavke.dgvDnevneStavke.DataSource = stavke;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Sistem ne može da nađe stavke transporta po zadatoj vrednosti.\n" + ex.Message, "Transport", MessageBoxButtons.OK, MessageBoxIcon.Error);

            
            }
        }
    }
}
