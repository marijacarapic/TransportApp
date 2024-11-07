using Common;
using Common.Domen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemOperations
{
    public class IzmeniStavkuTransportaSO : SystemOperationBase
    {
    

        protected override void ExecuteOperation(IEntity entity)
        {
           StavkaTransporta st = (StavkaTransporta)entity;
            st.WhereUslov = $"IdUgovorTransporta = {st.IdUgovorTransporta} and Rb = {st.Rb}";
            repository.Update(entity);
        }
    }
}
