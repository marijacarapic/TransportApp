using Common;
using Common.Domen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemOperations
{
    public class PretraziStavkeTransportaSO : SystemOperationBase
    {
        public PretraziStavkeTransportaSO(DateTime datum)
        {
            Datum = datum;
        }

        public List<StavkaTransporta> Result { get; set; }
        public DateTime Datum { get; }

        protected override void ExecuteOperation(IEntity entity)
        {
            StavkaTransporta st = new StavkaTransporta();
            st.Uslov = $"st.Datum = '{Datum:yyyy-MM-dd}'";
            Result = repository.GetAllWithCondition(st).OfType<StavkaTransporta>().ToList();
        }
    }
}
