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
    public class UgovorTransporta : IEntity
    {
        [Browsable(false)]
        public int IdUgovorTransporta { get; set; }
        public string NarucilacTransporta { get; set; }
        public string KontaktTelefon { get; set; }
        public DateTime DatumKreiranja { get; set; }
        public  Grad GradOd{ get; set; }
        public  Grad GradDo { get; set; }
        public string AdresaOd{ get; set; }
        public string AdresaDo { get; set; }
        public TipSadrzajTransporta TipSadrzajTransporta { get; set; }
        public double UkupnaKolicina { get; set; }
        public double UkupanPredjeniPut {  get; set; }
        public List<StavkaTransporta> StavkeTransporta { get; set; }

        [Browsable(false)]
        public string Uslov { get; set; }
        [Browsable(false)]

        public string TableName => "UgovorTransporta";
        [Browsable(false)]
        
        public string TableAlias => "ut";
        [Browsable(false)]

        public string JoinTable => "join Grad g1 on (ut.IdGradOd = g1.ZipCode) join Grad g2 on (ut.IdGradDo = g2.ZipCode) join TipSadrzajTransporta tst on (ut.IdTipSadrzajTransporta = tst.IdTipSadrzajTransporta)";
        [Browsable(false)]

        public string JoinCondition => "";
        [Browsable(false)]

        public string WhereCondition => $"IdUgovorTransporta = {IdUgovorTransporta}";
        [Browsable(false)]

        public string GeneralCondition => $"{Uslov}";
        [Browsable(false)]

        public object SelectValues => "ut.*, g1.nazivGrada as nazivGradaOd, g2.nazivGrada as nazivGradaDo, tst.*";
        [Browsable(false)]

        public string UpdateValues => "";
        [Browsable(false)]

        public string InsertValues => $"'{NarucilacTransporta}', '{KontaktTelefon}', '{DatumKreiranja:yyyy-MM-dd}', {GradOd.ZipCode}, {GradDo.ZipCode}, '{AdresaOd}', '{AdresaDo}', {TipSadrzajTransporta.IdTipSadrzajTransporta}, '{UkupnaKolicina}', '{UkupanPredjeniPut}'";
        [Browsable(false)]

        public string IdName => "IdUgovorTransporta";

        public List<IEntity> GetList(SqlDataReader reader)
        {
            List<IEntity> result = new List<IEntity>();

            while (reader.Read())
            {
                UgovorTransporta ugovor = new UgovorTransporta();
                ugovor.IdUgovorTransporta = (int)reader["IdUgovorTransporta"];
                ugovor.NarucilacTransporta = (string)reader["NarucilacTransporta"];
                ugovor.KontaktTelefon = (string)reader["KontaktTelefon"];
                ugovor.DatumKreiranja = (DateTime)reader["DatumKreiranja"];
                ugovor.GradOd = new Grad()
                {
                    ZipCode = (int)reader["IdGradOd"],
                    NazivGrada = (string)reader["nazivGradaOd"]
                };
                ugovor.GradDo = new Grad()
                {
                    ZipCode = (int)reader["IdGradDo"],
                    NazivGrada = (string)reader["nazivGradaDo"]
                };
                ugovor.AdresaOd = (string)reader["AdresaOd"];
                ugovor.AdresaDo = (string)reader["AdresaDo"];
                ugovor.TipSadrzajTransporta = new TipSadrzajTransporta()
                {
                    IdTipSadrzajTransporta = (int)reader["IdTipSadrzajTransporta"],
                    NazivTipSadrzajTransport = (string)reader["NazivTipSadrzajTransporta"]
                };
                ugovor.UkupnaKolicina = (double)reader["UkupnaKolicina"];
                ugovor.UkupanPredjeniPut = (double)reader["UkupanPredjeniPut"];



                result.Add(ugovor);
            }
            reader.Close();
            return result;
        }

        public IEntity GetOne(SqlDataReader reader)
        {
            UgovorTransporta ugovor = new UgovorTransporta();
            using (reader)
            {
                if (reader.Read())
                {
                    ugovor.IdUgovorTransporta = (int)reader["IdUgovorTransporta"];
                    ugovor.NarucilacTransporta = (string)reader["NarucilacTransporta"];
                    ugovor.KontaktTelefon = (string)reader["KontaktTelefon"];
                    ugovor.DatumKreiranja = (DateTime)reader["DatumKreiranja"];
                    ugovor.GradOd = new Grad()
                    {
                        ZipCode = (int)reader["IdGradOd"],
                        NazivGrada = (string)reader["nazivGradaOd"]
                    };
                    ugovor.GradDo = new Grad()
                    {
                        ZipCode = (int)reader["IdGradDo"],
                        NazivGrada = (string)reader["nazivGradaDo"]
                    };
                    ugovor.AdresaOd = (string)reader["AdresaOd"];
                    ugovor.AdresaDo = (string)reader["AdresaDo"];
                    ugovor.TipSadrzajTransporta = new TipSadrzajTransporta()
                    {
                        IdTipSadrzajTransporta = (int)reader["IdTipSadrzajTransporta"],
                        NazivTipSadrzajTransport = (string)reader["NazivTipSadrzajTransporta"]
                    };
                    ugovor.UkupnaKolicina = (double)reader["UkupnaKolicina"];
                    ugovor.UkupanPredjeniPut = (double)reader["UkupanPredjeniPut"];
                }
            }
            return ugovor;
        }
    }
}
