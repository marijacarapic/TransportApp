using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{

    public interface IRepository<TEntity> where TEntity : class
    {
        int SaveAndGetID(IEntity entity);
        void Save(IEntity entity);
        void Update(IEntity entity);
        List<IEntity> GetAll(IEntity entity);
        List<IEntity> GetAllWithCondition(IEntity entity);
        IEntity GetSpecific(IEntity entity);
        void Delete(IEntity entity);

    }
}
