using Common;
using Common.Domen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemOperations
{
    public class UcitajListuVozilaPoTipuSadrzajaTransportaSO : SystemOperationBase
    {
        public UcitajListuVozilaPoTipuSadrzajaTransportaSO(TipSadrzajTransporta tipSadrzajTransport)
        {
            this.tipSadrzajTransport = tipSadrzajTransport;
        }
        public List<Vozilo> Result { get; set; }

        private TipSadrzajTransporta tipSadrzajTransport;

        protected override void ExecuteOperation(IEntity entity)
        {
           
            Vozilo vozilo = (Vozilo)entity;
            vozilo.Uslov = $"vs.IdTipSadrzajTransporta = {tipSadrzajTransport.IdTipSadrzajTransporta}";
            Result = repository.GetAllWithCondition(vozilo).OfType<Vozilo>().ToList();

        }
    }
}
