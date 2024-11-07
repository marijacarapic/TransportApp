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
    public class UCUgovoriTransportaController
    {
        public UCUgovoriTransporta UCUgovoriTransporta { get; set; }
        private BindingList<UgovorTransporta> ugovoriTransporta;
        public UserControl CreateUCUgovoriTransporta()
        {
            UCUgovoriTransporta = new UCUgovoriTransporta();
            UCUgovoriTransporta.Dock = DockStyle.Fill;


            UCUgovoriTransporta.btnDodajUgovor.Click += btnDodajUgovor_CLick;
            UCUgovoriTransporta.btnPretrazi.Click += btnPretrazi_Click;

            ugovoriTransporta = new BindingList<UgovorTransporta>(Communication.Instance.UcitajListuUgovoraTransporta());

            UCUgovoriTransporta.dgvUgovori.DataSource = ugovoriTransporta;
            UCUgovoriTransporta.dgvUgovori.Columns[9].Visible = false;


            return UCUgovoriTransporta;
        }

        private void btnPretrazi_Click(object sender, EventArgs e)
        {
            if(!ValidacijaPretrazivanja())
            {
                return;
            }
          
            string pretraga = UCUgovoriTransporta.txtNarucilac.Text;
            try
            {
                UCUgovoriTransporta.dgvUgovori.DataSource = new BindingList<UgovorTransporta>(Communication.Instance.PretraziUgovoreTransporta(pretraga));
            }
            catch (Exception ex)
            {
                MessageBox.Show("Sistem ne može da nađe ugovore transporta po zadatoj vrednosti.\n" + ex.Message, "Transport", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            
        }

        private bool ValidacijaPretrazivanja()
        {
            bool validacija = true;

            return validacija;
        }

        private void btnDodajUgovor_CLick(object sender, EventArgs e)
        {
            Coordinator.Instance.OpenFrmUgovorTransporta();

            ugovoriTransporta = new BindingList<UgovorTransporta>(Communication.Instance.UcitajListuUgovoraTransporta());
            UCUgovoriTransporta.dgvUgovori.DataSource = ugovoriTransporta;

        }
    }
}
