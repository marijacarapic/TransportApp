using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public interface IDbRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        void Commit();
        void Rollback();
        void Close();
    }
}
