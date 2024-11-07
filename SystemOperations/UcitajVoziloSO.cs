using Common;
using Common.Domen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemOperations
{
    public class UcitajVoziloSO : SystemOperationBase
    {
        public Vozilo Result { get; set; }
        protected override void ExecuteOperation(IEntity entity)
        {

            Vozilo v = (Vozilo)entity;
            v.WhereUslov = $"v.IdVozilo={v.IdVozilo}";
            Result = (Vozilo)repository.GetSpecific(v);
        }
    }
}
