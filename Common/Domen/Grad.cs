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
    public class Grad : IEntity
    {
        public int ZipCode { get; set; }
        public string NazivGrada { get; set; }

        [Browsable(false)]
        public string TableName => "Grad";

        [Browsable(false)]
        public string TableAlias => "g";

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
        [Browsable(false)]

        public string IdName => "ZipCode";

        public List<IEntity> GetList(SqlDataReader reader)
        {
            List<IEntity> result = new List<IEntity>();
            while (reader.Read())
            {
                result.Add(new Grad
                {
                    ZipCode = (int)reader["ZipCode"],
                    NazivGrada = (string)reader["NazivGrada"],

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
            return $"{NazivGrada}";
        }
    }
}
