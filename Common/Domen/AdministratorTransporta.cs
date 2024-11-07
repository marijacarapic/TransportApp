using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Domen
{
    [Serializable]
    public class AdministratorTransporta : IEntity
    {
        public int IdAdministrator {  get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Kontakt { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        [Browsable(false)]
        public string TableName => "AdministratorTransporta";

        [Browsable(false)]
        public string TableAlias => "at";

        [Browsable(false)]
        public string JoinTable => "";

        [Browsable(false)]
        public string JoinCondition => "";
        [Browsable(false)]

        public string WhereCondition => "";
        [Browsable(false)]

        public string GeneralCondition => "";
        [Browsable(false)]

        public object SelectValues => "*";
        [Browsable(false)]

        public string UpdateValues => "";
        [Browsable(false)]

        public string InsertValues => "";

        public string IdName => "IdAdministrator";

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        public List<IEntity> GetList(SqlDataReader reader)
        {
            List<IEntity> result = new List<IEntity>();
            while (reader.Read())
            {
                result.Add(new AdministratorTransporta
                {
                    IdAdministrator = (int)reader["IdAdministratorTransporta"],
                    Ime = (string)reader["Ime"],
                    Prezime = (string)reader["Prezime"],
                    Kontakt = (string)reader["Kontakt"],
                    Username = (string)reader["Username"],
                    Password = (string)reader["Password"]
                });
            }
            reader.Close();
            return result;
        }

        public IEntity GetOne(SqlDataReader reader)
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return $"{Ime} { Prezime}";
        }
    }
}
