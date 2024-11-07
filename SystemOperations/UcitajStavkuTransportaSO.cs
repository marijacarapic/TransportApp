using Common;
using Common.Domen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemOperations
{
    public class UcitajStavkuTransportaSO : SystemOperationBase
    {
        public StavkaTransporta Result { get; set; }
        protected override void ExecuteOperation(IEntity entity)
        {
            StavkaTransporta st = (StavkaTransporta)entity;
            st.WhereUslov = $"ut.IdUgovorTransporta = {st.IdUgovorTransporta} and st.Rb = {st.Rb}";
            Result = (StavkaTransporta)repository.GetSpecific(st);
        }
    }
}
