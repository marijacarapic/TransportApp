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
    public class TipSadrzajTransporta : IEntity
    {
        public int IdTipSadrzajTransporta { get; set; }
        public string NazivTipSadrzajTransport { get; set; }

        [Browsable(false)]
        public string Uslov { get; set; }
        [Browsable(false)]
        public string TableName => "TipSadrzajTransporta";

        [Browsable(false)]
        public string TableAlias => "tst";

        [Browsable(false)]
        public string JoinTable => "join VoziloSadrzaj vs on (tst.IdTipSadrzajTransporta = vs.IdTipSadrzajTransporta)";

        [Browsable(false)]
        public string JoinCondition => "";
        [Browsable(false)]

        public string WhereCondition => "";
        [Browsable(false)]

        public string GeneralCondition => $"{Uslov}";
        [Browsable(false)]

        public object SelectValues => "distinct tst.*";
        [Browsable(false)]

        public string UpdateValues => "";
        [Browsable(false)]

        public string InsertValues => "";
        [Browsable(false)]

        public string IdName => "IdTipSadrzajTransporta";

        public List<IEntity> GetList(SqlDataReader reader)
        {
            List<IEntity> result = new List<IEntity>();
            while (reader.Read())
            {
                result.Add(new TipSadrzajTransporta
                {
                    IdTipSadrzajTransporta = (int)reader["IdTipSadrzajTransporta"],
                    NazivTipSadrzajTransport = (string)reader["NazivTipSadrzajTransporta"],

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
            return $"{NazivTipSadrzajTransport}";
        }

      
    }
}
