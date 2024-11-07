using Client.Forms;
using Client.ServerCommunication;
using Common.Domen;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using Newtonsoft.Json.Linq;
using System.Globalization;
using System.Net.Http;
using static GMap.NET.Entity.OpenStreetMapRouteEntity;

namespace Client.GuiController
{
    public class FrmUgovorTransportaController
    {
        public FrmUgovorTransporta FrmUgovorTransporta { get; set; }
        public double PredvidjenaDistanca { get; set; }
        public double PredvidjenoTrajanje { get; set; }
        public static UgovorTransporta Dodat { get; internal set; }

        private BindingList<StavkaTransporta> stavkeTransporta;

  

        private GMapOverlay routesOverlay;

        public FrmUgovorTransporta CreateFrmUgovorTransporta()
        {
            FrmUgovorTransporta = new FrmUgovorTransporta();
            FrmUgovorTransporta.Dock = DockStyle.Fill;
            
            FrmUgovorTransporta.gbDodavanjeStavki.Visible = false;
            FrmUgovorTransporta.btnDodajUgovor.Visible = false;

            stavkeTransporta = new BindingList<StavkaTransporta>();
            FrmUgovorTransporta.dgvStavke.DataSource = stavkeTransporta;
            FrmUgovorTransporta.dgvStavke.Columns["IzvrsenTransport"].Visible = false;
            FrmUgovorTransporta.dgvStavke.Columns["PredjeniPut"].Visible = false;


            FrmUgovorTransporta.cmbGradDo.DataSource = Communication.Instance.UcitajListuGradova();
            FrmUgovorTransporta.cmbGradOd.DataSource = Communication.Instance.UcitajListuGradova();
            FrmUgovorTransporta.cmbTipSadrzajaTransporta.DataSource = Communication.Instance.UcitajListuTipSadrzajTransporta();


            FrmUgovorTransporta.lblNapomena.Text = "";
            FrmUgovorTransporta.cmbTipSadrzajaTransporta.SelectedIndex = -1;
            FrmUgovorTransporta.cmbGradOd.SelectedIndex = -1;
            FrmUgovorTransporta.cmbGradDo.SelectedIndex = -1;

           
            MapLoad(); // kreiranje mape

            FrmUgovorTransporta.cmbTipSadrzajaTransporta.SelectedIndexChanged += cmbTipSadrzajaTransporta_SelectedIndexChanged;

            FrmUgovorTransporta.btnDodajStavkeUgovora.Click += btnDodajStavkeUgovora_Click;
            FrmUgovorTransporta.btnDodajStavku.Click += btnDodajStavku_Click;
            FrmUgovorTransporta.btnObrisiStavku.Click += btnObrisiStavku_Click;

            FrmUgovorTransporta.btnDodajUgovor.Click += btnDodajUgovor_Click;
            FrmUgovorTransporta.cmbVozilo.SelectedIndexChanged += cmbVozilo_SelectedIndexChanged;

            return FrmUgovorTransporta;
        }

        private void cmbVozilo_SelectedIndexChanged(object sender, EventArgs e)
        {
            Vozilo vozilo = (Vozilo)FrmUgovorTransporta.cmbVozilo.SelectedItem;
            FrmUgovorTransporta.lblNosivost.Text = $"{vozilo.Kapacitet} kg";
        }
        private void btnDodajStavkeUgovora_Click(object sender, EventArgs e)
        {
            if(!PopunjenaPoljaUgovora())
            {
                return;
            }
            if(!ValidacijaPoljaUgovora())
            {
                MessageBox.Show("Upozorenje! Da bi dodali stavke transporta ovog ugovora sva polja moraju biti validna i odgovarajucem opsegu");
                return;
            }
            DialogResult result = MessageBox.Show("Proverite ispravnost informacija koje ste uneli za dati ugovor. Da li želite da nastavite sa dodavanjem stavki transporta?", "Transport", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                FrmUgovorTransporta.txtNarucilacTransporta.ReadOnly = true;
                FrmUgovorTransporta.txtKontaktTelefon.ReadOnly = true;
                FrmUgovorTransporta.txtUlicaOd.ReadOnly = true;
                FrmUgovorTransporta.txtUlicaDo.ReadOnly = true;
                FrmUgovorTransporta.txtBrojOd.ReadOnly = true;
                FrmUgovorTransporta.txtBrojDo.ReadOnly = true;
                FrmUgovorTransporta.cmbGradOd.Enabled = false;
                FrmUgovorTransporta.cmbGradDo.Enabled = false;
                FrmUgovorTransporta.cmbTipSadrzajaTransporta.Enabled = false;
                FrmUgovorTransporta.txtUkupnaKolicina.ReadOnly = true;
                FrmUgovorTransporta.dtpDatumKreiranja.Enabled = false;


                FrmUgovorTransporta.btnDodajStavkeUgovora.Enabled = false;
                FrmUgovorTransporta.gbDodavanjeStavki.Visible = true;
                FrmUgovorTransporta.btnDodajUgovor.Visible = true;

                string pocetnaAdresa = FrmUgovorTransporta.cmbGradOd.SelectedItem.ToString() + " " + FrmUgovorTransporta.txtUlicaOd.Text + " " + FrmUgovorTransporta.txtBrojOd.Text;
                string krajnjaAdresa = FrmUgovorTransporta.cmbGradDo.SelectedItem.ToString() + " " + FrmUgovorTransporta.txtUlicaDo.Text + " " + FrmUgovorTransporta.txtBrojDo.Text;
                KreirajRutu(pocetnaAdresa, krajnjaAdresa);

                FrmUgovorTransporta.lblNapomena.Text = $"Predvidjena distanca izmedju {pocetnaAdresa} i {krajnjaAdresa}\nIznosi {Math.Round(PredvidjenaDistanca/1000,2)} kilometara." +
                    $"\nPredvidjeno vreme obavljanja stavke transporta je {Math.Round(PredvidjenoTrajanje,2)} minuta." +
                    $"\nNapomena: Vreme trajanja voznje ne moze biti manje od predvidjenog vremena obavljanja \nStavke transporta.";
            }
            else if (result == DialogResult.No)
            {
                return;
            }

          


        }

        private void KreirajRutu(string pocetna, string krajnja)
        {
            
            var pocetnaKoordinata = Geokodiranje(pocetna);
            if (pocetnaKoordinata == null)
            {
               // MessageBox.Show("Geokodiranje pocetne adrese je neuspesno.");
                return;
            }

            var krajnjaKoordinata = Geokodiranje(krajnja);
            if (krajnjaKoordinata == null)
            {
               // MessageBox.Show("Geokodiranje kranje adrese je neuspesno.");
                return;
            }

            string url = $"http://router.project-osrm.org/route/v1/driving/{pocetnaKoordinata.Value.Lng.ToString(CultureInfo.InvariantCulture)}" +
                $",{pocetnaKoordinata.Value.Lat.ToString(CultureInfo.InvariantCulture)};{krajnjaKoordinata.Value.Lng.ToString(CultureInfo.InvariantCulture)}" +
                $",{krajnjaKoordinata.Value.Lat.ToString(CultureInfo.InvariantCulture)}?overview=full&geometries=geojson";

            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = client.GetAsync(url).Result;
                if (response.IsSuccessStatusCode)
                {
                    string result = response.Content.ReadAsStringAsync().Result;
                    JObject json = JObject.Parse(result);
                    var route = json["routes"][0];
                    var geometry = route["geometry"]["coordinates"];

                    PredvidjenaDistanca = route["distance"].Value<double>();
                    PredvidjenoTrajanje = route["duration"].Value<double>() / 60;

                    var points = new List<PointLatLng>();
                    foreach (var coord in geometry)
                    {
                        points.Add(new PointLatLng((double)coord[1], (double)coord[0]));
                    }

                    var r = new GMapRoute(points, "My Route")
                    {
                        Stroke = new Pen(Color.Red, 3)
                    };
                    routesOverlay.Routes.Clear();
                    routesOverlay.Routes.Add(r);
                    FrmUgovorTransporta.gMap.ZoomAndCenterRoutes("routes");
                }
                else
                {
                    MessageBox.Show("Nespesno rutiranje!");
                }
            }
        }
        private PointLatLng? Geokodiranje(string address)
        {
            string url = $"https://api.geoapify.com/v1/geocode/search?text={Uri.EscapeDataString(address)}&apiKey={AppConfig.GeoapifyApiKey}";

            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = client.GetAsync(url).Result;
                if (response.IsSuccessStatusCode)
                {
                    string result = response.Content.ReadAsStringAsync().Result;
                    JObject json = JObject.Parse(result);
                    var features = json["features"];
                    if (features != null && features.HasValues)
                    {
                        var firstFeature = features.First;
                        var coordinates = firstFeature["geometry"]["coordinates"];
                        double lng = coordinates[0].Value<double>();
                        double lat = coordinates[1].Value<double>();
                        return new PointLatLng(lat, lng);
                    }
                }
                else
                {
                    MessageBox.Show("Neuspešno geokodiranje.");
                }
            }

            return null;
        }

        private void MapLoad()
        {

            FrmUgovorTransporta.gMap.MapProvider = GMapProviders.OpenStreetMap;
            GMaps.Instance.Mode = AccessMode.ServerOnly;
            FrmUgovorTransporta.gMap.Position = new PointLatLng(44.772530, 20.475957); 
            FrmUgovorTransporta.gMap.MinZoom = 1;
            FrmUgovorTransporta.gMap.MaxZoom = 20;
            FrmUgovorTransporta.gMap.Zoom = 15;
            FrmUgovorTransporta.gMap.ShowCenter = false;
            routesOverlay = new GMapOverlay("routes");
            FrmUgovorTransporta.gMap.Overlays.Add(routesOverlay);


        }

        private void btnObrisiStavku_Click(object sender, EventArgs e)
        {
            if (stavkeTransporta.Count == 0)
            {
                MessageBox.Show("Greska prilikom brisanja stavke!");
                return;
            };
            if (FrmUgovorTransporta.dgvStavke.SelectedRows.Count == 0)
            {
                MessageBox.Show("Izaberite stavku transporta za brisanje!");
                return;
            }
            DialogResult result = MessageBox.Show("Da li ste sigurni da zelite da obrisete stavku transporta?", "Transport", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                stavkeTransporta.Remove((StavkaTransporta)FrmUgovorTransporta.dgvStavke.SelectedRows[0].DataBoundItem);
                FrmUgovorTransporta.dgvStavke.DataSource = stavkeTransporta;
            }
            else
            {
                return;
            }
        }
        private void btnDodajStavku_Click(object sender, EventArgs e)
        {
           
            if(!PopunjenaPoljaStavkiTransporta())
            {
                return;
            }
            if (!ValidacijaDodavanjaStavke())
            {
                return;
            }
            if(!ProveraKapacitetaVozila())
            {
                return;
            }
            if(!ProveraKolicine())
            {
                return;
            }
            if (!ProveraVremenaObavljanjaVoznje())
            {
                return;
            }

            StavkaTransporta stavka = new StavkaTransporta();

                stavka.Rb = stavkeTransporta.Count + 1;
                stavka.Vozilo = (Vozilo)FrmUgovorTransporta.cmbVozilo.SelectedItem;
                stavka.Kolicina = double.Parse(FrmUgovorTransporta.txtKolicina.Text);
                stavka.Datum = FrmUgovorTransporta.dtpDatumIzvrsavanjaTransporta.Value;
             
                stavka.VremePolaska = new TimeSpan(FrmUgovorTransporta.dtpVremePolaska.Value.Hour, FrmUgovorTransporta.dtpVremePolaska.Value.Minute, FrmUgovorTransporta.dtpVremePolaska.Value.Second);
                stavka.VremeDolaska = new TimeSpan(FrmUgovorTransporta.dtpVremeDolaska.Value.Hour, FrmUgovorTransporta.dtpVremeDolaska.Value.Minute, FrmUgovorTransporta.dtpVremeDolaska.Value.Second);

            if (DostupnostVozila(stavka))
            {
                MessageBox.Show("Vozilo nije dostupno u unetom terminu!");
                return;
            }
            foreach (StavkaTransporta st in stavkeTransporta)
            {
                if (st.Vozilo.IdVozilo == stavka.Vozilo.IdVozilo)
                {
                    if (st.Datum.Date == stavka.Datum.Date)
                    {
                        if ((stavka.VremePolaska >= st.VremePolaska && stavka.VremePolaska < st.VremeDolaska) ||
                             (stavka.VremeDolaska > st.VremePolaska && stavka.VremeDolaska <= st.VremeDolaska) ||
                              (st.VremePolaska >= stavka.VremePolaska && st.VremeDolaska <= stavka.VremeDolaska)) {

                            MessageBox.Show("Greska! Postoje preklapanje termina za uneto vozilo!");
                            return;
                        }
                    }
                }
            }

            stavkeTransporta.Add(stavka);

        }
        private bool ProveraKapacitetaVozila()
        {
            Vozilo vozilo = (Vozilo)FrmUgovorTransporta.cmbVozilo.SelectedItem;
            double kolicina = double.Parse(FrmUgovorTransporta.txtKolicina.Text);
            if(vozilo.Kapacitet < kolicina)
            {
                MessageBox.Show("Uneta kolicina transporta je veca od nosivosti vozila!");
                return false;
            }
            return true;
        }
        private bool ProveraKolicine()
        {
            bool provera = true;
            double ukupno = 0;
            double ukupnaKol = double.Parse(FrmUgovorTransporta.txtUkupnaKolicina.Text);
            double kol = double.Parse(FrmUgovorTransporta.txtKolicina.Text);

            if(stavkeTransporta.Count == 0)
            {
                if(kol > ukupnaKol)
                {
                    MessageBox.Show("Uneta kolicina je veca od ukupne kolicine!");
                    provera = false;
                }
               
            } else
            {
                foreach(StavkaTransporta st in stavkeTransporta)
                {
                    ukupno += st.Kolicina;
                }

                ukupno += kol;
                if(ukupno > ukupnaKol)
                {
                    MessageBox.Show($"Smanjite kolicinu transporta stavke koje unosite! Premasena je ukupna kolicina po ugovoru.");
                    provera = false;
                }
            }
            return provera;
        }
        private bool PopunjenaPoljaStavkiTransporta()
        {
            bool popunjeno = true;

            //ovde opet kako izvrsiti validaciju za datum?
            Control[] kontrole = {
                FrmUgovorTransporta.txtKolicina,
                FrmUgovorTransporta.cmbVozilo
                
            };

            foreach (Control kontrola in kontrole)
            {
                if (kontrola is TextBox textbox && string.IsNullOrEmpty(textbox.Text))
                {
                    textbox.BackColor = Color.Salmon;
                    popunjeno = false;
                }
                else if (kontrola is ComboBox combobox && combobox.SelectedItem == null)
                {
                    combobox.BackColor = Color.Salmon;
                    popunjeno = false;
                }
                else
                {
                    kontrola.BackColor = Color.White;
                }
            }
            if (!popunjeno)
            {
                MessageBox.Show("Sva polja stavke transporta moraju biti popunjena! ", "Transport", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return popunjeno;
        }
        private bool ValidacijaDodavanjaStavke()
        {
            bool validacija = true;
            if (!(double.TryParse(FrmUgovorTransporta.txtKolicina.Text, out double kapacitet)) || kapacitet <= 0)
            {
                MessageBox.Show("Kolicina koja se transportuje mora imati pozitivnu numeričku vrednost!", "Transport", MessageBoxButtons.OK, MessageBoxIcon.Error);
                validacija = false;
                FrmUgovorTransporta.txtKolicina.BackColor = Color.Salmon;
            }
            else
            {

                FrmUgovorTransporta.txtKolicina.BackColor = Color.White;
            }
            if(FrmUgovorTransporta.dtpDatumKreiranja.Value > FrmUgovorTransporta.dtpDatumIzvrsavanjaTransporta.Value)
            {
                MessageBox.Show("Datum Izvrsenja stavke transporta ne moze biti pre datuma kreiranja ugovora!", "Transport", MessageBoxButtons.OK, MessageBoxIcon.Error);
                validacija = false;
            }

            return validacija;
        }
        private void btnDodajUgovor_Click(object sender, EventArgs e)
        {
       

            if (!ValidacijaStavkiTransporta())
            {
                return;
            }
            if (!ProveraUkupneKolicine())
            {
                return;
            }
          
            UgovorTransporta ugovorTransporta = new UgovorTransporta()
            {
                NarucilacTransporta = FrmUgovorTransporta.txtNarucilacTransporta.Text,
                KontaktTelefon = FrmUgovorTransporta.txtKontaktTelefon.Text,
                GradOd = (Grad)FrmUgovorTransporta.cmbGradOd.SelectedItem,
                GradDo = (Grad)FrmUgovorTransporta.cmbGradDo.SelectedItem,
                AdresaOd = FrmUgovorTransporta.txtUlicaOd.Text + " " + FrmUgovorTransporta.txtBrojOd.Text,
                AdresaDo = FrmUgovorTransporta.txtUlicaDo.Text + " " + FrmUgovorTransporta.txtBrojDo.Text,
                TipSadrzajTransporta = (TipSadrzajTransporta)FrmUgovorTransporta.cmbTipSadrzajaTransporta.SelectedItem,
                UkupnaKolicina = double.Parse(FrmUgovorTransporta.txtUkupnaKolicina.Text),
                DatumKreiranja = FrmUgovorTransporta.dtpDatumKreiranja.Value,
                StavkeTransporta = stavkeTransporta.ToList(),
               // UkupanPredjeniPut = PredvidjenaDistanca TODO
             
            };

            try
            {
                
                Communication.Instance.DodajUgovor(ugovorTransporta);
                MessageBox.Show("Sistem je zapamtio ugovor transporta", "Transport", MessageBoxButtons.OK);
                Dodat = ugovorTransporta;

                stavkeTransporta.Clear();
                FrmUgovorTransporta.Dispose();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Sistem ne može da zapamti ugovor transporta.\n" + ex.Message, "Transport", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ProveraVremenaObavljanjaVoznje()
        {
            TimeSpan trajanjeVoznje = FrmUgovorTransporta.dtpVremeDolaska.Value - FrmUgovorTransporta.dtpVremePolaska.Value;
            double trajanjeVoznjeUMinutima = trajanjeVoznje.TotalMinutes;

            if (trajanjeVoznjeUMinutima < PredvidjenoTrajanje)
            {
                MessageBox.Show("Trajanje voznje ne moze trajati manje od predvidjene voznje!");
                return false;
            }
            return true;
        }

        private bool DostupnostVozila(StavkaTransporta stavka)
        {
           
            return Communication.Instance.ProveraDostupnostiVozila(stavka);
        }

        //hmmm da li mi sada treba ova provera jer sam proverila za dodavanje stavki
        private bool ProveraUkupneKolicine()
        {
            double ukupno = 0;
            if(stavkeTransporta.Count == 0)
            {
                return false;
            }

            foreach(StavkaTransporta st in stavkeTransporta)
            {
                ukupno += st.Kolicina;
               
            }
             if(ukupno != double.Parse(FrmUgovorTransporta.txtUkupnaKolicina.Text))
            {
                MessageBox.Show("Ukupna kolicina transporta se ne slaze sa svim kolicinama stavki transporta!");
                return false;
            }
            return true;
        }
        private bool ValidacijaStavkiTransporta()
        {
            bool validacija = true;
            if (stavkeTransporta.Count == 0)
            {
                MessageBox.Show("Sistem ne moze da zapamati ugovor transporta. Ugovor mora imati definisane stavke transporta!", "Transport", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return validacija;
        }
        private bool ValidacijaPoljaUgovora()
        {
            bool validacija = true;
            

            if (!FrmUgovorTransporta.txtNarucilacTransporta.Text.All(c => char.IsLetter(c) || c == ' '))
            {
                MessageBox.Show("Neispravan unos narucioca transporta!", "Transport", MessageBoxButtons.OK, MessageBoxIcon.Error);
                validacija = false;
                FrmUgovorTransporta.txtNarucilacTransporta.BackColor = Color.Salmon;
            } else
            {
                FrmUgovorTransporta.txtNarucilacTransporta.BackColor = Color.White;
            }

            if (!FrmUgovorTransporta.txtKontaktTelefon.Text.All(c => char.IsDigit(c)) || FrmUgovorTransporta.txtKontaktTelefon.Text.Length > 10)
            {
                MessageBox.Show("Kontakt telefon mora sadrzati samo brojeve!\n Maksimalna duzina kontakt telefona je 10!", "Transport", MessageBoxButtons.OK, MessageBoxIcon.Error);
                validacija = false;
                FrmUgovorTransporta.txtKontaktTelefon.BackColor = Color.Salmon;
            }
            else
            {
                FrmUgovorTransporta.txtKontaktTelefon.BackColor = Color.White;
            }
            if (FrmUgovorTransporta.txtUlicaOd.Text.All(c => char.IsLetter(c) || c == ' ') && FrmUgovorTransporta.txtBrojOd.Text.All(c => char.IsDigit(c)))
            {
                
                FrmUgovorTransporta.txtUlicaOd.BackColor = Color.White;
                FrmUgovorTransporta.txtBrojOd.BackColor = Color.White;
            }
            else
            {
                MessageBox.Show("Neispravan unos adrese polaska! Ulica sadrzi slovne vrednosti dok broj numericke!", "Transport", MessageBoxButtons.OK, MessageBoxIcon.Error);
                validacija = false;
                FrmUgovorTransporta.txtUlicaOd.BackColor = Color.Salmon;
                FrmUgovorTransporta.txtBrojOd.BackColor = Color.Salmon;
            }
            if (FrmUgovorTransporta.txtUlicaDo.Text.All(c => char.IsLetter(c) || c == ' ') && FrmUgovorTransporta.txtBrojDo.Text.All(c => char.IsDigit(c)))
            {

                FrmUgovorTransporta.txtUlicaDo.BackColor = Color.White;
                FrmUgovorTransporta.txtBrojDo.BackColor = Color.White;
            }
            else
            {
                MessageBox.Show("Neispravan unos adrese dolaska! Ulica sadrzi slovne vrednosti dok broj numericke!", "Transport", MessageBoxButtons.OK, MessageBoxIcon.Error);
                validacija = false;
                FrmUgovorTransporta.txtUlicaDo.BackColor = Color.Salmon;
                FrmUgovorTransporta.txtBrojDo.BackColor = Color.Salmon;
            }
            if (!(double.TryParse(FrmUgovorTransporta.txtUkupnaKolicina.Text, out double kapacitet)) || kapacitet <= 0)
            {
                MessageBox.Show("Ukupna kolicina koja se transportuje mora imati pozitivnu numeričku vrednost!", "Transport", MessageBoxButtons.OK, MessageBoxIcon.Error);
                validacija = false;
                FrmUgovorTransporta.txtUkupnaKolicina.BackColor = Color.Salmon;
            }
            else
            {

                FrmUgovorTransporta.txtUkupnaKolicina.BackColor = Color.White;
            }
            return validacija;
        }
        private bool PopunjenaPoljaUgovora()
        {
            bool popunjeno = true;

            
            Control[] kontrole = {
                FrmUgovorTransporta.txtNarucilacTransporta,
                FrmUgovorTransporta.txtKontaktTelefon,
                FrmUgovorTransporta.txtUlicaOd,
                FrmUgovorTransporta.txtUlicaDo,
                FrmUgovorTransporta.txtBrojOd,
                FrmUgovorTransporta.txtBrojDo,
                FrmUgovorTransporta.cmbGradOd,
                FrmUgovorTransporta.cmbGradDo,
                FrmUgovorTransporta.cmbTipSadrzajaTransporta,
                FrmUgovorTransporta.txtUkupnaKolicina
            };

          
            foreach (Control kontrola in kontrole)
            {
                if (kontrola is TextBox textbox && string.IsNullOrEmpty(textbox.Text))
                {
                    textbox.BackColor = Color.Salmon;
                    popunjeno = false;
                }
                else if (kontrola is ComboBox combobox && combobox.SelectedItem == null)
                {
                    combobox.BackColor = Color.Salmon;
                    popunjeno = false;
                }
                else
                {
                    kontrola.BackColor = Color.White;
                }
            }
            if (!popunjeno)
            {
                MessageBox.Show("Sva polja ugovora moraju biti popunjena! ", "Transport", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return popunjeno;
        }
        private void cmbTipSadrzajaTransporta_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            TipSadrzajTransporta izabraniTip = (TipSadrzajTransporta)FrmUgovorTransporta.cmbTipSadrzajaTransporta.SelectedItem;
            FrmUgovorTransporta.cmbVozilo.DataSource = Communication.Instance.UcitajListuVozilaPoTipuSadrzajaTransporta(izabraniTip);
           
          
        }
    }
}
