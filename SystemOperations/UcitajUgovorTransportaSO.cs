using Common;
using Common.Domen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemOperations
{
 
    public class UcitajUgovorTransportaSO : SystemOperationBase
    {
        public UcitajUgovorTransportaSO(int idUgovor)
        {
            IdUgovor = idUgovor;
        }

        public UgovorTransporta Result { get; set; }
        public int IdUgovor { get; }

        protected override void ExecuteOperation(IEntity entity)
        {
            UgovorTransporta ut = new UgovorTransporta()
            {
                IdUgovorTransporta = IdUgovor
            };

            Result = (UgovorTransporta)repository.GetSpecific(ut);

        }
    }
}
