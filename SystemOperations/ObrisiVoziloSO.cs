using Common;
using Common.Domen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SystemOperations
{
    public class ObrisiVoziloSO : SystemOperationBase
    {
        private List<StavkaTransporta> stavke {  get; set; }
        private VoziloSadrzaj VoziloSadrzaj { get; set; }
        protected override void ExecuteOperation(IEntity entity)
        {
            Vozilo vozilo  = (Vozilo)entity;
            VoziloSadrzaj = new VoziloSadrzaj()
            {
                Vozilo = vozilo
            };

            StavkaTransporta st = new StavkaTransporta()
            {
                Vozilo = vozilo
            };
            st.Uslov = $"st.IdVozilo = {vozilo.IdVozilo}";
            stavke = repository.GetAllWithCondition(st).OfType<StavkaTransporta>().ToList();
            if (stavke.Count == 0)
            {

                repository.Delete(VoziloSadrzaj);
                vozilo.WhereUslov = $"IdVozilo={vozilo.IdVozilo}";
                repository.Delete(vozilo);
            }
            else
            {
                throw new Exception("Vozilo je vezano za obavljanje stavke transporta!");
            }

        }
    }
}
