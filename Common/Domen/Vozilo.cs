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
    public class Vozilo  : IEntity
    {
        public int IdVozilo { get; set; }
        public string  Model { get; set; } 
        public double Kapacitet { get; set; }
        public string Registracija { get; set; }
        public TipVozila TipVozila { get; set; }
        public List<TipSadrzajTransporta> TipoviSadrzajTransporta { get; set; }

        [Browsable(false)]

        public String WhereUslov { get; set; }

        [Browsable(false)]

        public string Uslov { get; set; }
        [Browsable(false)]

        public string TableName => "Vozilo";
        [Browsable(false)]

        public string TableAlias => "v";
        [Browsable(false)]

        public string JoinTable => "join TipVozila tv on (v.IdTipVozila=tv.IdTipVozila) join VoziloSadrzaj vs on(v.IdVozilo = vs.IdVozilo)";
        [Browsable(false)]

        public string JoinCondition => "";
        [Browsable(false)]

        public string WhereCondition => $"{WhereUslov}";
        [Browsable(false)] 

        public string GeneralCondition => $"{Uslov}";
        [Browsable(false)]

        public object SelectValues => "distinct v.IdVozilo, v.Registracija, v.Model, v.Kapacitet, v.IdTipVozila, tv.NazivTipaVozila ";
        [Browsable(false)]

        public string UpdateValues => $"Kapacitet = {Kapacitet}";
        [Browsable(false)]

        public string InsertValues => $"'{Registracija}', '{Kapacitet}', '{Model}', {TipVozila.IdTipVozila} ";
        [Browsable(false)]

        public string IdName => "IdVozilo";

        public List<IEntity> GetList(SqlDataReader reader)
        {
            List<IEntity> result = new List<IEntity>();

            while (reader.Read())
            {
                Vozilo vozilo = new Vozilo();
                vozilo.IdVozilo = (int)reader["IdVozilo"];
                vozilo.Registracija = (string)reader["Registracija"];
                vozilo.Kapacitet = (double)reader["Kapacitet"];
                vozilo.Model = (string)reader["Model"];
                vozilo.TipVozila = new TipVozila();
                vozilo.TipVozila.IdTipVozila = (int)reader["IdTipVozila"];
                vozilo.TipVozila.NazivTipaVozila = (string)reader["NazivTipaVozila"];
                
              

                result.Add(vozilo);
            }
            reader.Close();

            return result;
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        public override string ToString()
        {
            return $"{TipVozila} {Registracija}";
        }

        public override bool Equals(object obj)
        {
   
            if (obj is Vozilo v) return v.IdVozilo == IdVozilo;
            return false;
        }

        public IEntity GetOne(SqlDataReader reader)
        {
            Vozilo vozilo = new Vozilo();
            using (reader)
            {
                if (reader.Read())
                {
                    vozilo.IdVozilo = (int)reader["IdVozilo"];
                    vozilo.Registracija = (string)reader["Registracija"];
                    vozilo.Kapacitet = (double)reader["Kapacitet"];
                    vozilo.Model = (string)reader["Model"];
                    vozilo.TipVozila = new TipVozila();
                    vozilo.TipVozila.IdTipVozila = (int)reader["IdTipVozila"];
                    vozilo.TipVozila.NazivTipaVozila = (string)reader["NazivTipaVozila"];
                }
            }

            return vozilo;
        }
    }
}
