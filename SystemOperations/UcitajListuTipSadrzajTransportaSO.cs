using Common;
using Common.Domen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemOperations
{
    public class UcitajListuTipSadrzajTransportaSO : SystemOperationBase
    {
        public List<TipSadrzajTransporta> Result { get; set; }
        protected override void ExecuteOperation(IEntity entity)
        { 
            Result = repository.GetAll(new TipSadrzajTransporta()).OfType<TipSadrzajTransporta>().ToList();

        }
    }
}
