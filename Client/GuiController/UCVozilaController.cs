using Client.Forms;
using Client.ServerCommunication;
using Client.UserControls;
using Common.Domen;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Remoting;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client.GuiController
{
    public class UCVozilaController
    {
        public UCVozila UCVozila { get; set; }
        public  BindingList<Vozilo> vozila;
        public Vozilo Vozilo { get; set; }
       // public FrmVozilo FrmVozilo { get; set; }
        public UCVozila CreateUCVozilo()
        {
            UCVozila = new UCVozila();
            UCVozila.Dock = DockStyle.Fill;


            FrmVoziloController frmVoziloController = new FrmVoziloController();
     

            UCVozila.btnDodajVozilo.Click += btnDodajVozilo_Click;
            UCVozila.btnObrisiVozilo.Click += btnObrisiVozilo_Click;
            UCVozila.btnAzuriraj.Click += btnAzuriraj_Click;
            vozila =  new BindingList<Vozilo>(Communication.Instance.UcitajListuVozila());
            UCVozila.dgvVozila.DataSource = vozila;

            UCVozila.cmbPretragaPoTipu.DataSource = Communication.Instance.UcitajListuTipVozila();
            UCVozila.cmbPretragaPoTipu.SelectedIndex = -1;
            UCVozila.cmbPretragaPoTipu.SelectedIndexChanged += cmbPretragaPoTipu_SelectedIndexChanged;

            UCVozila.dgvVozila.Columns[0].Visible = false;
            

            return UCVozila;
        }


        private void cmbPretragaPoTipu_SelectedIndexChanged(object sender, EventArgs e)
        {
            TipVozila tip = (TipVozila)UCVozila.cmbPretragaPoTipu.SelectedItem;

            try
            {
                
                UCVozila.dgvVozila.DataSource = Communication.Instance.PretraziVozila(tip);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Sistem ne može da nađe vozila po zadatoj vrednosti.\n" + ex.Message, "Transport", MessageBoxButtons.OK, MessageBoxIcon.Error);

                
            }
        }

        private void btnAzuriraj_Click(object sender, EventArgs e)
        {

            if (UCVozila.dgvVozila.SelectedRows.Count == 0)
            {
                MessageBox.Show("Niste izabrali vozilo za ažuriranje!");
                return;
            }

            Vozilo voziloZaAzuriranje = (Vozilo)UCVozila.dgvVozila.SelectedRows[0].DataBoundItem;
            try
            {
                Vozilo = Communication.Instance.UcitajVozilo(voziloZaAzuriranje);
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Sistem ne može da učita vozilo.\n" + ex.Message, "Transport", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
                
            }

            Coordinator.Instance.OpenFrmAzuriranjeVozila(Vozilo);
            vozila = new BindingList<Vozilo>(Communication.Instance.UcitajListuVozila());
            UCVozila.dgvVozila.DataSource = vozila;
         
        }

        private void btnObrisiVozilo_Click(object sender, EventArgs e)
        {
            //OVO NE RADI - kako drugacije????
           if(UCVozila.dgvVozila.RowCount == 0)
            {
                MessageBox.Show("U sistemu nije upisano nijedno vozilo! Greska prilikom brisanja!"); //ako je dataGridView prazan validacija
                return;
            }

            if (UCVozila.dgvVozila.SelectedRows.Count == 0)
            {
                MessageBox.Show("Niste izabrali vozilo!");
                return;
            }
            DialogResult dg = MessageBox.Show("Da li ste sigurni da zelite da obrisete vozilo? Napomena: Obrisace se sav tip sadrzaja transporta ovog vozila!", "Transport", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dg == DialogResult.No) return;

            Vozilo voziloZaBrisanje =(Vozilo)UCVozila.dgvVozila.SelectedRows[0].DataBoundItem;
            
            try
            {
              
                Communication.Instance.ObrisiVozilo(voziloZaBrisanje);
                MessageBox.Show("Sistem je obrisao vozilo.", "Transport", MessageBoxButtons.OK);
                vozila.Remove(voziloZaBrisanje);
                UCVozila.dgvVozila.Refresh();

            }

            catch (Exception ex)
            {
                MessageBox.Show("Sistem ne može da obriše vozilo.\n" + ex.Message, "Transport", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
         

        }

        private void btnDodajVozilo_Click(object sender, EventArgs e)
        {
            Coordinator.Instance.OpenFrmVozilo();
            vozila = new BindingList<Vozilo>(Communication.Instance.UcitajListuVozila());
            UCVozila.dgvVozila.DataSource = vozila;
            
        }

        
        
    }
}
