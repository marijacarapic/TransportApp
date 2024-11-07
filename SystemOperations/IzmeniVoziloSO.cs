using Common;
using Common.Domen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemOperations
{
    public class IzmeniVoziloSO : SystemOperationBase
    {
        protected override void ExecuteOperation(IEntity entity)
        {
            Vozilo vozilo = (Vozilo)entity;
            vozilo.WhereUslov = $"IdVozilo={vozilo.IdVozilo}";
            repository.Update(vozilo);
            VoziloSadrzaj vs = new VoziloSadrzaj()
            {
                Vozilo = vozilo
            };

            repository.Delete(vs);

            foreach(TipSadrzajTransporta tst in vozilo.TipoviSadrzajTransporta)
            {
                VoziloSadrzaj vozSad = new VoziloSadrzaj()
                {
                    Vozilo = vozilo,
                    TipSadrzajTransporta = tst
                };
                repository.Save(vozSad);
            }
        }
    }
}
