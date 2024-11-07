using Common;
using Common.Domen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemOperations
{
    public class UcitajListuVozilaSO : SystemOperationBase
    {
        public List<Vozilo> Result { get; set; }

        protected override void ExecuteOperation(IEntity entity)
        {
            Result = repository.GetAll(new Vozilo()).OfType<Vozilo>().ToList();

        }
    }
}
