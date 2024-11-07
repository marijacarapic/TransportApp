using Common;
using Common.Domen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemOperations
{
    public class UcitajListuTipSadrzajTransportaPoVoziluSO : SystemOperationBase
    {
        private Vozilo vozilo;

        public UcitajListuTipSadrzajTransportaPoVoziluSO(Vozilo vozilo)
        {
            this.vozilo = vozilo;
        }

        public List<TipSadrzajTransporta> Result { get; set; }

        protected override void ExecuteOperation(IEntity entity)
        {

            TipSadrzajTransporta tipSadrzaja = (TipSadrzajTransporta)entity;
            tipSadrzaja.Uslov = $"vs.IdVozilo = {vozilo.IdVozilo}";
            Result = repository.GetAllWithCondition(tipSadrzaja).OfType<TipSadrzajTransporta>().ToList();

        }
    }
}
