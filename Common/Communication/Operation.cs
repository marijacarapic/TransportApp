using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Communication
{
    public enum Operation
    {
        Login,
        UcitajListuTipVozila,
        UcitajListuGradova,
        UcitajListuTipSadrzajTransporta,
        UcitajListuVozila,
        DodajVozilo,
        ObrisiVozilo,
        UcitajListuVozilaSadrzajPoVozilu,
        UcitajListuVozilaPoTipuSadrzajaTransporta,
        DodajUgovorTransporta,
        UcitajListuUgovoraTransporta,
        PretraziUgovoreTransporta,
        PretraziStavkeTransporta,
        UcitajJedanUgovor,
        IzmeniStavkuTransporta,
        PretraziVozila,
        UcitajListuTipSadrzajTransportaPoVozilu,
        IzmeniVozilo,
        ProveraDostupnostiVozila,
        UcitajVozilo,
        UcitajStavkuTransporta,
    }
}
