using Client.Forms;
using Client.ServerCommunication;
using Client.UserControls;
using Common.Communication;
using Common.Domen;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Runtime.Remoting;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client.GuiController
{
    public class FrmVoziloController
    {
        public FrmVozilo FrmVozilo { get; set; }
        private BindingList<VoziloSadrzaj> voziloSadrzaj;
        public  BindingList<TipSadrzajTransporta> tipoviSadrzajTransporta;
        

        public FrmVozilo CreateFrmVozilo()
        {
            FrmVozilo = new FrmVozilo();
            tipoviSadrzajTransporta = new BindingList<TipSadrzajTransporta>();
            voziloSadrzaj = new BindingList<VoziloSadrzaj>();

            FrmVozilo.cmbTipVozila.DataSource = Communication.Instance.UcitajListuTipVozila();
            FrmVozilo.cmbNazivSadrzaja.DataSource = Communication.Instance.UcitajListuTipSadrzajTransporta();

            
            FrmVozilo.dgvTipSadrzajaTransporta.DataSource = tipoviSadrzajTransporta;
            FrmVozilo.dgvTipSadrzajaTransporta.Columns[0].Visible = false;
           

            FrmVozilo.cmbNazivSadrzaja.SelectedIndex = -1;
            FrmVozilo.cmbTipVozila.SelectedIndex = -1;

            FrmVozilo.btnDodajVozilo.Click += btnDodajVozilo_Click; 

            FrmVozilo.btnDodajTipSadrzaja.Click += btnDodajTipSadrzaja_Click;
            FrmVozilo.btnObrisiTipSadrzaja.Click += btnObrisiTipSadrzaja_Click;
            


            return FrmVozilo;
        }
      
        private void btnObrisiTipSadrzaja_Click(object sender, EventArgs e)
        {
            if(tipoviSadrzajTransporta.Count == 0)
            {
                MessageBox.Show("Greska prilikom brisanja!");
                return;
            }
            if(FrmVozilo.dgvTipSadrzajaTransporta.SelectedRows.Count == 0)
            {
                MessageBox.Show("Izaberite tip sadrzaja transporta za brisanje!");
                return;
            }
            tipoviSadrzajTransporta.Remove((TipSadrzajTransporta)FrmVozilo.dgvTipSadrzajaTransporta.SelectedRows[0].DataBoundItem);
            FrmVozilo.dgvTipSadrzajaTransporta.DataSource = tipoviSadrzajTransporta;
        }

        private void btnDodajTipSadrzaja_Click(object sender, EventArgs e)
        {
            if(FrmVozilo.cmbNazivSadrzaja.SelectedIndex == -1)
            {
                MessageBox.Show("Izaberite tip sadrzaja transporta!");
                return;
            }

            TipSadrzajTransporta tipSadrzaj = (TipSadrzajTransporta)FrmVozilo.cmbNazivSadrzaja.SelectedItem;
            foreach (TipSadrzajTransporta tst in tipoviSadrzajTransporta)
            {

                if(tst.IdTipSadrzajTransporta == tipSadrzaj.IdTipSadrzajTransporta)
                {
                    MessageBox.Show($"Tip sadrzaja: {tipSadrzaj.NazivTipSadrzajTransport} ste vec dodali!");
                    return;
                }
            }

            tipoviSadrzajTransporta.Add(tipSadrzaj);
        }

        private void btnDodajVozilo_Click(object sender, EventArgs e)
        {
            if (!PopunjenaPolja())
            {
               return;
            }
            if(!ValidacijaPolja())
            {
                return;
            }
            if (!ProveraRegistracije())
            {
                return;
            }
            if (!ValidacijaTipovaSadrzajaTransporta())
            {
                return;
            }
        
            Vozilo vozilo = new Vozilo()
            {
                Kapacitet = double.Parse(FrmVozilo.txtKapacitet.Text),
                Model = FrmVozilo.txtModel.Text,
                Registracija = FrmVozilo.txtRegistracija.Text,
                TipVozila = (TipVozila)FrmVozilo.cmbTipVozila.SelectedItem,
                TipoviSadrzajTransporta = tipoviSadrzajTransporta.ToList()
            };
            try
            {

                Communication.Instance.DodajVozilo(vozilo);

                MessageBox.Show("Sistem je zapamtio vozilo.", "Transport", MessageBoxButtons.OK);
     
                FrmVozilo.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Sistem ne može da zapamti vozilo.\n" + ex.Message, "Transport", MessageBoxButtons.OK, MessageBoxIcon.Error);

               

            }

        }

        private bool ValidacijaTipovaSadrzajaTransporta()
        {
            bool validacija = true;
            if (tipoviSadrzajTransporta.Count == 0)
            {
                MessageBox.Show("Sistem ne moze da zapamati vozilo. Vozilo mora imati definisani tip sadrzaja transporta!", "Transport", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false ;
            }
           
            return validacija;
        }
        private bool ValidacijaPolja()
        {
            bool validacija = true;
            string pattern = @"^[A-Z]{2}\d{4}-[A-Z]{2}$";

            if (!(double.TryParse(FrmVozilo.txtKapacitet.Text, out double kapacitet)) || kapacitet <= 0)
            {
                MessageBox.Show("Kapacitet vozila mora imati pozitivnu numeričku vrednost!", "Transport", MessageBoxButtons.OK, MessageBoxIcon.Error);
                validacija = false;
                FrmVozilo.txtKapacitet.BackColor = Color.Salmon;
            }
            else
            {

                FrmVozilo.txtKapacitet.BackColor = Color.White;
            }

            if(!Regex.IsMatch(FrmVozilo.txtRegistracija.Text, pattern))
            {
                MessageBox.Show("Registraciona oznaka vozila mora biti u obliku: BG1234-DD", "Transport", MessageBoxButtons.OK, MessageBoxIcon.Error);
                validacija = false;
                FrmVozilo.txtRegistracija.BackColor = Color.Salmon;
            }
            else
            {
                FrmVozilo.txtRegistracija.BackColor = Color.White;

            }


            return validacija;
        }
        private bool PopunjenaPolja()
        {
            bool popunjeno = true;

            if (string.IsNullOrEmpty(FrmVozilo.txtKapacitet.Text) ||
                string.IsNullOrEmpty(FrmVozilo.txtModel.Text) ||
                string.IsNullOrEmpty(FrmVozilo.txtRegistracija.Text) ||
                FrmVozilo.cmbTipVozila.SelectedItem == null)
            {
                MessageBox.Show("Sva polja moraju biti popunjena! ", "Transport", MessageBoxButtons.OK, MessageBoxIcon.Error);

                if (string.IsNullOrEmpty(FrmVozilo.txtKapacitet.Text))
                {
                    FrmVozilo.txtKapacitet.BackColor = Color.Salmon;
                }
                else
                {
                    FrmVozilo.txtKapacitet.BackColor = Color.White;  
                }
                if (string.IsNullOrEmpty(FrmVozilo.txtModel.Text))
                {               
                    FrmVozilo.txtModel.BackColor = Color.Salmon;
                }
                else
                {               
                    FrmVozilo.txtModel.BackColor = Color.White;
                }
                if (string.IsNullOrEmpty(FrmVozilo.txtRegistracija.Text))
                {
                    FrmVozilo.txtRegistracija.BackColor = Color.Salmon;
                }
                else
                {                  
                    FrmVozilo.txtRegistracija.BackColor = Color.White;
                }
                if (FrmVozilo.cmbTipVozila.SelectedItem == null)
                {                   
                    FrmVozilo.cmbTipVozila.BackColor = Color.Salmon;
                }
                else
                {
                    FrmVozilo.cmbTipVozila.BackColor = Color.White;
                }
                popunjeno = false;
            }
            else
            {
                FrmVozilo.txtKapacitet.BackColor = Color.White;
                FrmVozilo.txtRegistracija.BackColor = Color.White;
                FrmVozilo.txtModel.BackColor = Color.White;
                FrmVozilo.cmbTipVozila.BackColor = Color.White;
            }

            return popunjeno;
        }
        private bool ProveraRegistracije()
        {
            List<Vozilo> vozila = Communication.Instance.UcitajListuVozila(); // da li mi ovde treba try catch

            foreach (Vozilo v in vozila)
            {
                if (v.Registracija.Equals(FrmVozilo.txtRegistracija.Text))
                {
                    MessageBox.Show("Vozilo sa unetom registracijom postoji u sistemu!", "Transport", MessageBoxButtons.OK, MessageBoxIcon.Error);    
                    return false;
                }
            }
            return true;

        }
    }

}
