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
    public class VoziloSadrzaj : IEntity
    {
        public Vozilo Vozilo { get; set; }
        public TipSadrzajTransporta TipSadrzajTransporta { get; set; }

        public string Uslov { get; set; }
        [Browsable(false)]
        public string TableName => "VoziloSadrzaj";
        [Browsable(false)]
        public string TableAlias => "vs";
        [Browsable(false)]
        public string JoinTable => "join Vozilo v on (vs.IdVozilo=v.IdVozilo) join TipSadrzajTransporta tst on (vs.IdTipSadrzajTransporta=tst.IdTipSadrzajTransporta) join TipVozila tv on (v.IdTipVozila = tv.IdTipVozila)";
        [Browsable(false)]
        public string JoinCondition => "";
        [Browsable(false)]
        public string WhereCondition => $"IdVozilo = {Vozilo.IdVozilo}";
        [Browsable(false)]
        public string GeneralCondition => $"{Uslov}";
        [Browsable(false)]
        public object SelectValues => "*";
        [Browsable(false)]
        public string UpdateValues => $"IdVozilo = {Vozilo.IdVozilo} , IdTipSadrzajTransporta = {TipSadrzajTransporta.IdTipSadrzajTransporta}";
        [Browsable(false)]
        public string InsertValues => $"{Vozilo.IdVozilo}, {TipSadrzajTransporta.IdTipSadrzajTransporta}";

        public string IdName => $" {Vozilo.IdVozilo}, {TipSadrzajTransporta.IdTipSadrzajTransporta}";

        public List<IEntity> GetList(SqlDataReader reader)
        {
            List<IEntity> result = new List<IEntity>();
            while (reader.Read())
            {
                result.Add(new VoziloSadrzaj
                {
                    Vozilo = new Vozilo()
                    {
                        IdVozilo = (int)reader["IdVozilo"],
                      
                        Registracija = (string)reader["Registracija"],
                        Kapacitet = (double)reader["Kapacitet"],
                        Model = (string)reader["Model"],
                        
                        TipVozila = new TipVozila()
                         {
                             IdTipVozila = (int)reader["IdTipVozila"],
                             NazivTipaVozila = (string)reader["NazivTipaVozila"]
                         }
                    },
                    TipSadrzajTransporta = new TipSadrzajTransporta()
                    {
                        IdTipSadrzajTransporta = (int)reader["IdTipSadrzajTransporta"],
                        NazivTipSadrzajTransport = (string)reader["NazivTipSadrzajTransporta"],
                    }

                });
            }
            reader.Close();
            return result;
        }

        public IEntity GetOne(SqlDataReader reader)
        {
            throw new NotImplementedException();
        }
    }
}
