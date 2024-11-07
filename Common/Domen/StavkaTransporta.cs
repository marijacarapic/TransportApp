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
    public class StavkaTransporta : IEntity
    {
         
        [Browsable(false)]
        public int IdUgovorTransporta { get; set; }
        public int Rb{ get; set; }
        public Vozilo Vozilo { get; set; }
        public double Kolicina { get; set; }
        public DateTime Datum { get; set; }
        public TimeSpan VremePolaska { get; set; } 
        public TimeSpan VremeDolaska { get; set; }
        public bool IzvrsenTransport { get; set; }
        public double PredjeniPut { get; set; } 

        [Browsable(false)]

        public string WhereUslov { get; set; }

        [Browsable(false)]

        
        public string Uslov { get; set; }
        [Browsable(false)]
        public string TableName => "StavkaTransporta";
        [Browsable(false)]
        public string TableAlias => "st";
        [Browsable(false)]
        public string JoinTable => "join Vozilo v on (st.IdVozilo = v.IdVozilo) join UgovorTransporta ut on (st.IdUgovorTransporta = ut.IdUgovorTransporta) join TipVozila tv on(v.IdTipVozila = tv.IdTipVozila)";
        [Browsable(false)]
        public string JoinCondition => "";
        [Browsable(false)]
        public string WhereCondition => $"{WhereUslov}";
        [Browsable(false)]
        public string GeneralCondition => $"{Uslov}";
        [Browsable(false)]

        public object SelectValues => "*";
        [Browsable(false)]

        public string UpdateValues => $"IzvrsenTransport = {Convert.ToByte(IzvrsenTransport)}, PredjeniPut = {PredjeniPut}";
        [Browsable(false)]

        public string InsertValues => $"{IdUgovorTransporta}, {Rb}, {Vozilo.IdVozilo}, {Kolicina}, '{Datum:yyyy-MM-dd}', '{VremePolaska}',  '{VremeDolaska}', '{IzvrsenTransport}' , {PredjeniPut}";
        [Browsable(false)]

        public string IdName => $"{IdUgovorTransporta}, {Rb}";

        public List<IEntity> GetList(SqlDataReader reader)
        {
            List<IEntity> result = new List<IEntity>();
            while (reader.Read())
            {
                StavkaTransporta stavka = new StavkaTransporta();
                stavka.IdUgovorTransporta = (int)reader["IdUgovorTransporta"]; 
                stavka.Rb = (int)reader["Rb"];
                stavka.Vozilo = new Vozilo() {

                    IdVozilo = (int)reader["IdVozilo"],
                    Registracija = (string)reader["Registracija"],
                    Kapacitet = (double)reader["Kapacitet"],
                    Model = (string)reader["Model"],
              
                    };
                stavka.Vozilo.TipVozila = new TipVozila();
                stavka.Vozilo.TipVozila.IdTipVozila = (int)reader["IdTipVozila"];
                stavka.Vozilo.TipVozila.NazivTipaVozila = (string)reader["NazivTipaVozila"];
                stavka.Kolicina = (double)reader["Kolicina"];
                stavka.Datum = (DateTime)reader["Datum"];
                stavka.VremePolaska = (TimeSpan)reader["VremePolaska"];
                stavka.VremeDolaska = (TimeSpan)reader["VremeDolaska"];
                stavka.IzvrsenTransport = (bool)reader["IzvrsenTransport"];
                stavka.PredjeniPut = (double)reader["PredjeniPut"];

                result.Add(stavka);
                    

            }
            reader.Close();
            return result;
        }

        public IEntity GetOne(SqlDataReader reader)
        {
            StavkaTransporta stavka = new StavkaTransporta();
            using (reader)
            {
                if (reader.Read())
                {
                    stavka.IdUgovorTransporta = (int)reader["IdUgovorTransporta"];
                    stavka.Rb = (int)reader["Rb"];
                    stavka.Vozilo = new Vozilo()
                    {

                        IdVozilo = (int)reader["IdVozilo"],
                        Registracija = (string)reader["Registracija"],
                        Kapacitet = (double)reader["Kapacitet"],
                        Model = (string)reader["Model"],

                    };
                    stavka.Vozilo.TipVozila = new TipVozila();
                    stavka.Vozilo.TipVozila.IdTipVozila = (int)reader["IdTipVozila"];
                    stavka.Vozilo.TipVozila.NazivTipaVozila = (string)reader["NazivTipaVozila"];
                    stavka.Kolicina = (double)reader["Kolicina"];
                    stavka.Datum = (DateTime)reader["Datum"];
                    stavka.VremePolaska = (TimeSpan)reader["VremePolaska"];
                    stavka.VremeDolaska = (TimeSpan)reader["VremeDolaska"];
                    stavka.IzvrsenTransport = (bool)reader["IzvrsenTransport"];
                    stavka.PredjeniPut = (double)reader["PredjeniPut"];
                }
            }
            return stavka;
        }
        }
    }
