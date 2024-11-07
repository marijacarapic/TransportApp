using Common;
using Common.Domen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemOperations
{
    public class DodajVoziloSO : SystemOperationBase
    {
       

        protected override void ExecuteOperation(IEntity entity)
        {
            Vozilo vozilo = (Vozilo)entity;
            vozilo.IdVozilo = repository.SaveAndGetID(vozilo);
            foreach (TipSadrzajTransporta t in vozilo.TipoviSadrzajTransporta)
            {
                VoziloSadrzaj voziloSadrzaj = new VoziloSadrzaj()
                {
                    Vozilo = vozilo,
                    TipSadrzajTransporta = t
                };
                repository.Save(voziloSadrzaj);
            }

        }
    }
}
