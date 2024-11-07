    using Common;
using Common.Domen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemOperations
{
    public class DodajUgovorTransportaSO : SystemOperationBase
    {
      
        protected override void ExecuteOperation(IEntity entity)
        {

            UgovorTransporta ugovor = (UgovorTransporta)entity;
            ugovor.IdUgovorTransporta = repository.SaveAndGetID(entity);
            foreach (StavkaTransporta st in ugovor.StavkeTransporta)
            {
                st.IdUgovorTransporta = ugovor.IdUgovorTransporta;
                repository.Save(st);
            };


            

        }
    }
}
