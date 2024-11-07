using Common;
using Common.Domen;
using Repository;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using SystemOperations;

namespace Server
{
    public class Controller
    {
        private static Controller instance;
        public static Controller Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Controller();
                }
                return instance;
            }
        }
        private Controller()
        {

            repository = new GenericDbRepository();
        }
        private IDbRepository<IEntity> repository;


        public AdministratorTransporta Login(AdministratorTransporta administrator)
        {
            LoginSystemOperation so = new LoginSystemOperation();
            so.ExecuteTemplate(administrator);
            return so.Result;
        }

        public List<TipVozila> UcitajListuTipVozila()
        {
            UcitajListuTipVozilaSO so = new UcitajListuTipVozilaSO();
            so.ExecuteTemplate(new TipVozila());
            return (List<TipVozila>)so.Result;
        }

        public List<Grad> UcitajListuGradova()
        {
            UcitajListuGradovaSO so = new UcitajListuGradovaSO();
            so.ExecuteTemplate(new Grad());
            return (List<Grad>)so.Result;
        }

        public List<TipSadrzajTransporta> UcitajListuTipSadrzajTransporta()
        {
            UcitajListuTipSadrzajTransportaSO so = new UcitajListuTipSadrzajTransportaSO();
            so.ExecuteTemplate(new VoziloSadrzaj());
            return (List<TipSadrzajTransporta>)so.Result;
        }

        public void SacuvajVozilo(Vozilo vozilo)
        {
            DodajVoziloSO so = new DodajVoziloSO();
            so.ExecuteTemplate(vozilo);
            
        }

        public List<Vozilo> UcitajListuVozila()
        {
            UcitajListuVozilaSO so = new UcitajListuVozilaSO();
            so.ExecuteTemplate(new Vozilo());
            return (List<Vozilo>)so.Result;
        }

        public void ObrisiVozilo(Vozilo vozilo)
        {
            ObrisiVoziloSO so = new ObrisiVoziloSO();
            so.ExecuteTemplate(vozilo);
        }

        internal List<Vozilo> UcitajListuVozilaPoTipuSadrzajaTransporta(TipSadrzajTransporta tipSadrzajTransport)
        {
            UcitajListuVozilaPoTipuSadrzajaTransportaSO so = new UcitajListuVozilaPoTipuSadrzajaTransportaSO(tipSadrzajTransport);
            so.ExecuteTemplate(new Vozilo()); 
            return (List<Vozilo>)so.Result;
        }

        public void SacuvajUgovor(UgovorTransporta ugovor)
        {
            DodajUgovorTransportaSO so = new DodajUgovorTransportaSO();
            so.ExecuteTemplate(ugovor);
        }

        public List<UgovorTransporta> UcitajListuUgovoraTransporta()
        {
            UcitajListuUgovoraTransportaSO so = new UcitajListuUgovoraTransportaSO();
            so.ExecuteTemplate(new UgovorTransporta());
            return (List<UgovorTransporta>)so.Result;
        }

        public List<UgovorTransporta> PretraziUgovoreTransporta(string pretraga)
        {
            PretraziUgovoreTransportaSO so = new PretraziUgovoreTransportaSO(pretraga);
            so.ExecuteTemplate(new UgovorTransporta());
            return (List<UgovorTransporta>)so.Result;
        }

        internal List<StavkaTransporta> PretraziStavkeTransporta(DateTime datum)
        {
            PretraziStavkeTransportaSO so = new PretraziStavkeTransportaSO(datum);
            so.ExecuteTemplate(new StavkaTransporta());
            return (List<StavkaTransporta>)so.Result;
        }

        public UgovorTransporta UcitajJedanUgovor(int idUgovor)
        {
            UcitajUgovorTransportaSO so = new UcitajUgovorTransportaSO(idUgovor);
            so.ExecuteTemplate(new UgovorTransporta());
            return (UgovorTransporta)so.Result;
        }

        public void IzmeniStavkuTransporta(StavkaTransporta stavka)
        {
            IzmeniStavkuTransportaSO so = new IzmeniStavkuTransportaSO();
            so.ExecuteTemplate(stavka);
        }

        public List<Vozilo> PretraziVozila(TipVozila tipVozila)
        {
            PretraziVozilaSO so = new PretraziVozilaSO(tipVozila);
            so.ExecuteTemplate(new Vozilo());
            return (List<Vozilo>)so.Result;
        }

        public List<TipSadrzajTransporta> UcitajListuTipSadrzajTransportaPoVozilu(Vozilo vozilo)
        {
            UcitajListuTipSadrzajTransportaPoVoziluSO so = new UcitajListuTipSadrzajTransportaPoVoziluSO(vozilo);
            so.ExecuteTemplate(new TipSadrzajTransporta()); 
            return so.Result;
        }

        public void IzmeniVozilo(Vozilo vozilo)
        {
            IzmeniVoziloSO so = new IzmeniVoziloSO();
            so.ExecuteTemplate(vozilo);
        }

        internal bool ProveraDostupnostiVozila(StavkaTransporta stavka)
        {
            ProveraDostupnostiVozilaSO so = new ProveraDostupnostiVozilaSO();
            so.ExecuteTemplate(stavka);
            return so.Result;
            
        }

        public Vozilo UcitajVozilo(Vozilo vozilo)
        {
            UcitajVoziloSO so = new UcitajVoziloSO();
            so.ExecuteTemplate(vozilo);
            return so.Result;
        }

        public StavkaTransporta UcitajStavkuTransporta(StavkaTransporta stavka)
        {
            UcitajStavkuTransportaSO so = new UcitajStavkuTransportaSO();
            so.ExecuteTemplate(stavka);
            return so.Result;
        }
    }
}
