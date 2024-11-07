using Common;
using Common.Domen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemOperations
{
    public class PretraziUgovoreTransportaSO : SystemOperationBase
    {
        public PretraziUgovoreTransportaSO(string pretraga)
        {
            Pretraga = pretraga;
        }

        public List<UgovorTransporta> Result { get; set; }
        public string Pretraga { get; }

        protected override void ExecuteOperation(IEntity entity)
        {
            UgovorTransporta ut = new UgovorTransporta();
            ut.Uslov = $"ut.NarucilacTransporta like '{Pretraga}%'";
            Result = repository.GetAllWithCondition(ut).OfType<UgovorTransporta>().ToList();
        }
    }
}
