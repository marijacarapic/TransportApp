using Common;
using Common.Domen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemOperations
{
    public class PretraziVozilaSO : SystemOperationBase
    {
        private TipVozila tipVozila;

        public PretraziVozilaSO(TipVozila tipVozila)
        {
            this.tipVozila = tipVozila;
        }

        public List<Vozilo> Result { get; set; }

        protected override void ExecuteOperation(IEntity entity)
        {
            Vozilo vozilo = (Vozilo)entity;
            vozilo.TipVozila = tipVozila;
            vozilo.Uslov = $"v.IdTipVozila = {vozilo.TipVozila.IdTipVozila}";
        
            Result = repository.GetAllWithCondition(vozilo).OfType<Vozilo>().ToList();

        }
    }
}
