using Client.Forms;
using Client.ServerCommunication;
using Client.UserControls;
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
    public class FrmStavkaTransportaController
    {
        public FrmStavkaTransporta FrmStavkaTransporta  { get; set; }
        public UgovorTransporta UgovorStavkeTransporta { get; set; }
        public StavkaTransporta Stavka { get; set; }
        public FrmStavkaTransporta CreateFrmStavkaTransporta(StavkaTransporta stavkaZaAzuriranje)
        {
            FrmStavkaTransporta = new FrmStavkaTransporta();

            Stavka = stavkaZaAzuriranje;

            try
            {
                UgovorStavkeTransporta = Communication.Instance.UcitajUgovorTransporta(Stavka.IdUgovorTransporta);
            }
            catch (Exception ex)
            {

                MessageBox.Show("Sistem ne moze da ucita ugovor transporta!"  + ex.Message);
            } 

          //  FrmStavkaTransporta.txtKolicina.Text = Stavka.Kolicina.ToString(); dal da vratim ovo
            FrmStavkaTransporta.txtVozilo.Text = Stavka.Vozilo.ToString();
            FrmStavkaTransporta.txtNarucilac.Text = UgovorStavkeTransporta.NarucilacTransporta;
            FrmStavkaTransporta.txtSadrzajTransporta.Text = UgovorStavkeTransporta.TipSadrzajTransporta.NazivTipSadrzajTransport;
            FrmStavkaTransporta.txtAdresaOd.Text = UgovorStavkeTransporta.GradOd + " " + UgovorStavkeTransporta.AdresaOd;
            FrmStavkaTransporta.txtAdresaDo.Text = UgovorStavkeTransporta.GradDo + " " + UgovorStavkeTransporta.AdresaDo;

          
            FrmStavkaTransporta.btnAzurirajStavku.Click += btnAzurirajStavku_Click;
            return FrmStavkaTransporta;
        }

        private void btnAzurirajStavku_Click(object sender, EventArgs e)
        {
            if(!Validacija())
            {
                return;
            }
            Stavka.IzvrsenTransport = true;
            Stavka.PredjeniPut = double.Parse(FrmStavkaTransporta.txtPredjeniPut.Text);


            try
            {
               

                Communication.Instance.IzmeniStavkuTransporta(Stavka); // treba da azuriram u dgvu
                MessageBox.Show("Sistem je zapamtio stavku transporta!", "Transport", MessageBoxButtons.OK);
              

                FrmStavkaTransporta.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Sistem ne moze da zapamti stavku transporta.\n" + ex.Message, "Transport", MessageBoxButtons.OK, MessageBoxIcon.Error);

               

            }

        }

        private bool Validacija()
        {
            bool validacija = true;
            
            if(!FrmStavkaTransporta.cbIzvrsenTransport.Checked)
            {
                MessageBox.Show("Ne mozete uneti kilometrazu ukoliko transport nije zavrsen!");
                return false;
            }

            if (!(double.TryParse(FrmStavkaTransporta.txtPredjeniPut.Text, out double kilometri)) || kilometri <= 0)
            {
                MessageBox.Show("Vrednost unetih kilometara mora biti pozitivna numericka vrednost");
                FrmStavkaTransporta.txtPredjeniPut.BackColor = Color.Salmon;
                validacija = false;
            }
            else
            {
                FrmStavkaTransporta.txtPredjeniPut.BackColor = Color.White;

            }

            return validacija;
        }
    }
}
