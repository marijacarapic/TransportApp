using Common;
using Common.Domen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemOperations
{
    public class ProveraDostupnostiVozilaSO : SystemOperationBase
    {
        public bool Result { get; set; }
        protected override void ExecuteOperation(IEntity entity)
        {
            StavkaTransporta stavka = (StavkaTransporta)entity;



            //stavka.Uslov = $"st.IdVozilo = {stavka.Vozilo.IdVozilo} AND st.Datum = '{stavka.Datum:yyyy-MM-dd}' AND (CAST('{stavka.VremePolaska}' AS TIME) BETWEEN CAST(st.VremePolaska AS TIME) AND CAST(st.VremeDolaska AS TIME) OR CAST('{stavka.VremeDolaska}' AS TIME) BETWEEN CAST(st.VremePolaska AS TIME) AND CAST(st.VremeDolaska AS TIME))";
            stavka.Uslov = $@"st.IdVozilo = {stavka.Vozilo.IdVozilo} AND st.Datum = '{stavka.Datum:yyyy-MM-dd}' AND (
    (CAST('{stavka.VremePolaska}' AS TIME) BETWEEN CAST(st.VremePolaska AS TIME) AND CAST(st.VremeDolaska AS TIME)) OR
    (CAST('{stavka.VremeDolaska}' AS TIME) BETWEEN CAST(st.VremePolaska AS TIME) AND CAST(st.VremeDolaska AS TIME)) OR
    (CAST(st.VremePolaska AS TIME) >= CAST('{stavka.VremePolaska}' AS TIME) AND CAST(st.VremeDolaska AS TIME) <= CAST('{stavka.VremeDolaska}' AS TIME))
)"; 


            int brojStavki = repository.GetAllWithCondition(stavka).OfType<StavkaTransporta>().ToList().Count();

            if (brojStavki > 0)
            {
                
                Result = true;

            }
            else
            {

                Result = false;
            }
        }
    }
}
