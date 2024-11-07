using Client.Forms;
using Client.ServerCommunication;
using Common.Domen;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client.GuiController
{
    public class FrmAzuriranjeVozilaController
    {
        public FrmAzuriranjeVozila FrmAzuriranjeVozila { get; set; }
        public Vozilo Vozilo { get; set; }
       
        private BindingList<TipSadrzajTransporta> tipoviSadrzajaTransporta;
        public FrmAzuriranjeVozila CreateFrmAzuriranjeVozila(Vozilo vozilo)
        {
            FrmAzuriranjeVozila = new FrmAzuriranjeVozila();
            Vozilo = vozilo;
            

            tipoviSadrzajaTransporta = new BindingList<TipSadrzajTransporta>(Communication.Instance.UcitajListuTipSadrzajTransportaPoVozilu(Vozilo));
            FrmAzuriranjeVozila.dgvTipSadrzajaTransporta.DataSource = tipoviSadrzajaTransporta;
            FrmAzuriranjeVozila.cmbNazivSadrzaja.DataSource = Communication.Instance.UcitajListuTipSadrzajTransporta();
            

            FrmAzuriranjeVozila.dgvTipSadrzajaTransporta.Columns[0].Visible = false;

            FrmAzuriranjeVozila.txtModel.Text = Vozilo.Model;
            FrmAzuriranjeVozila.txtRegistracija.Text = Vozilo.Registracija;
            FrmAzuriranjeVozila.txtTipVozila.Text = Vozilo.TipVozila.NazivTipaVozila;
            FrmAzuriranjeVozila.txtKapacitet.Text = Vozilo.Kapacitet.ToString();

            FrmAzuriranjeVozila.btnAzurirajVozilo.Click += btnAzurirajVozilo_Click;
            FrmAzuriranjeVozila.btnDodajTipSadrzaja.Click += btnDodajTipSadrzaja_Click;
            FrmAzuriranjeVozila.btnObrisiTipSadrzaja.Click += btnObrisiTipSadrzaja_Click;

            return FrmAzuriranjeVozila;
        }

        private void btnObrisiTipSadrzaja_Click(object sender, EventArgs e)
        {
            if (tipoviSadrzajaTransporta.Count == 0)
            {
                MessageBox.Show("Greska prilikom brisanja stavke!");
                return;
            };
            if (FrmAzuriranjeVozila.dgvTipSadrzajaTransporta.SelectedRows.Count == 0)
            {
                MessageBox.Show("Izaberite stavku transporta za brisanje!");
                return;
            }
            DialogResult result = MessageBox.Show("Da li ste sigurni da zelite da obrisete stavku transporta?", "Transport", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                tipoviSadrzajaTransporta.Remove((TipSadrzajTransporta)FrmAzuriranjeVozila.dgvTipSadrzajaTransporta.SelectedRows[0].DataBoundItem);
               
            }
            else
            {
                return;
            }
        }
        private void btnDodajTipSadrzaja_Click(object sender, EventArgs e)
        {
            if (FrmAzuriranjeVozila.cmbNazivSadrzaja.SelectedIndex == -1)
            {
                MessageBox.Show("Izaberite tip sadrzaja transporta!");
                return;
            }

            TipSadrzajTransporta tipSadrzaj = (TipSadrzajTransporta)FrmAzuriranjeVozila.cmbNazivSadrzaja.SelectedItem;
            foreach (TipSadrzajTransporta tst in tipoviSadrzajaTransporta)
            {

                if (tst.IdTipSadrzajTransporta == tipSadrzaj.IdTipSadrzajTransporta)
                {
                    MessageBox.Show($"Tip sadrzaja: {tipSadrzaj.NazivTipSadrzajTransport} ste vec dodali!");
                    return;
                }
            }

            tipoviSadrzajaTransporta.Add(tipSadrzaj);
        }
        private void btnAzurirajVozilo_Click(object sender, EventArgs e)
        {
            if(!Validacija())
            {
                return;
            }
            if(!ValidacijaUnetogKapaciteta())
            {
                return;
            }
            if(tipoviSadrzajaTransporta.Count == 0)
            {
                MessageBox.Show("Da bi azurirali vozilo morate izabrati tipove sadrzaja koje ono moze da prevozi!");
                return;
            }

            Vozilo.Kapacitet = double.Parse(FrmAzuriranjeVozila.txtKapacitet.Text);
            Vozilo.TipoviSadrzajTransporta = tipoviSadrzajaTransporta.ToList();

            try
            {
                Communication.Instance.IzmeniVozilo(Vozilo);
                MessageBox.Show("Sistem je zapamtio vozilo.", "Transport", MessageBoxButtons.OK);


                FrmAzuriranjeVozila.Close();
            }
            catch (Exception ex)
            {

                MessageBox.Show("Sistem ne može da zapamti vozilo.\n" + ex.Message, "Transport", MessageBoxButtons.OK, MessageBoxIcon.Error);


            }
        }

        private bool ValidacijaUnetogKapaciteta()
        {
            bool validacija = true;
            if (double.Parse(FrmAzuriranjeVozila.txtKapacitet.Text) < Vozilo.Kapacitet)
            {
                FrmAzuriranjeVozila.txtKapacitet.BackColor = Color.Salmon;
                MessageBox.Show($"Uneti kapacitet ne moze biti manji od {Vozilo.Kapacitet}");
                validacija = false;
            }
            else
            {
                FrmAzuriranjeVozila.txtKapacitet.BackColor = Color.White;
            }

            return validacija;
        }
        private bool Validacija()
        {
            bool validacija = true;
          
            if(string.IsNullOrEmpty(FrmAzuriranjeVozila.txtKapacitet.Text))
            {
                FrmAzuriranjeVozila.txtKapacitet.BackColor = Color.Salmon;
                MessageBox.Show("Popunite kapacitet vozila!");
                validacija = false;
            }
            else
            {
                FrmAzuriranjeVozila.txtKapacitet.BackColor = Color.White;
                if (!(double.TryParse(FrmAzuriranjeVozila.txtKapacitet.Text, out double kapacitet)) || kapacitet <= 0)
                {
                    FrmAzuriranjeVozila.txtKapacitet.BackColor = Color.Salmon;
                    MessageBox.Show("Kapacitet vozila mora biti pozitivna numericka vrednost!");
                    validacija = false;
                }
                else
                {
                    FrmAzuriranjeVozila.txtKapacitet.BackColor = Color.White;

                }
            }
          
          

            return validacija;
        }
    }
}
