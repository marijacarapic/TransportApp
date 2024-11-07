using Common;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemOperations
{
    public abstract class SystemOperationBase
    {
        protected IDbRepository<IEntity> repository;

        public SystemOperationBase()
        {
            repository = new GenericDbRepository();
        }

        public void ExecuteTemplate(IEntity entity)
        {
            try
            {
                //transakcije
                ExecuteOperation(entity);
                repository.Commit();
            }
            catch (Exception)
            {
                repository.Rollback();
                throw;
            }
            finally
            {
                repository.Close();
            }
        }

        protected abstract void ExecuteOperation(IEntity entity);
    }
}
