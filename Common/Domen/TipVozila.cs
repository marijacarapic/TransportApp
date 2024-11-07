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
    public class TipVozila : IEntity
    {
        public int IdTipVozila { get; set; }
        public string NazivTipaVozila { get; set; }

        [Browsable(false)]

        public string TableName => "TipVozila";
        [Browsable(false)]

        public string TableAlias => "tv";
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

        public string UpdateValues => $"NazivTipaVozila = '{NazivTipaVozila}'";
        [Browsable(false)]

        public string InsertValues => $"'{NazivTipaVozila}'";

        public string IdName => "IdTipVozila";

        public List<IEntity> GetList(SqlDataReader reader)
        {
            List<IEntity> result = new List<IEntity>();
            while (reader.Read())
            {
                result.Add(new TipVozila
                {
                    IdTipVozila = (int)reader["IdTipVozila"],
                    NazivTipaVozila = (string)reader["NazivTipaVozila"],
                   
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
            return $"{NazivTipaVozila}";
        }
    }
}
