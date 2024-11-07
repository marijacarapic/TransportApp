using Common;
using Common.Domen;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemOperations
{
    public class LoginSystemOperation : SystemOperationBase
    {

        public AdministratorTransporta Result { get; set; }

  

        protected override void ExecuteOperation(IEntity entity)
        {
            AdministratorTransporta administrator = (AdministratorTransporta)entity;

            foreach (AdministratorTransporta at in repository.GetAll(new AdministratorTransporta()))
            {
                if (at.Username == administrator.Username && at.Password == administrator.Password)
                {
                    Result = at;
                }
            }
        }
    }
}
