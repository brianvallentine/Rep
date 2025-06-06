using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmpresarial.DB2.VE0030B
{
    public class VE0030B_V0COMISSAO : QueryBasis<VE0030B_V0COMISSAO>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public VE0030B_V0COMISSAO() { IsCursor = true; }

        public VE0030B_V0COMISSAO(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string V0COMI_NUM_APOL { get; set; }
        public string V0COMI_NRENDOS { get; set; }
        public string V0COMI_NRCERTIF { get; set; }
        public string V0COMI_DIGCERT { get; set; }
        public string V0COMI_IDTPSEGU { get; set; }
        public string V0COMI_NRPARCEL { get; set; }
        public string V0COMI_OPERACAO { get; set; }
        public string V0COMI_CODPDT { get; set; }
        public string V0COMI_RAMOFR { get; set; }
        public string V0COMI_MODALIFR { get; set; }
        public string V0COMI_OCORHIST { get; set; }
        public string V0COMI_FONTE { get; set; }
        public string V0COMI_CODCLIEN { get; set; }
        public string V0COMI_VLCOMIS { get; set; }
        public string V0COMI_DATCLO { get; set; }
        public string V0COMI_NUMREC { get; set; }
        public string V0COMI_VALBAS { get; set; }
        public string V0COMI_TIPCOM { get; set; }
        public string V0COMI_QTPARCEL { get; set; }
        public string V0COMI_PCCOMCOR { get; set; }
        public string V0COMI_PCDESCON { get; set; }
        public string V0COMI_CODSUBES { get; set; }
        public string V0COMI_DTMOVTO { get; set; }
        public string VIND_DTMOVTO { get; set; }
        public string V0COMI_DATSEL { get; set; }
        public string V0COMI_COD_EMPRESA { get; set; }
        public string VIND_COD_EMP { get; set; }
        public string V0COMI_CODPRP { get; set; }
        public string VIND_CODPRP { get; set; }
        public string V0COMI_NUMBIL { get; set; }
        public string VIND_NUMBIL { get; set; }
        public string V0COMI_VLVARMON { get; set; }
        public string VIND_VLVARMON { get; set; }
        public string V0COMI_DTQITBCO { get; set; }
        public string VIND_DTQITBCO { get; set; }

        public new void Open()
        {
            if (!IsProcedure)
                SetQuery(GetQueryEvent());
            base.Open();
        }


        public new bool Fetch()
        {
            if (!JustACursor)
            {
                var idx = CurrentIndex;
                Open();
                CurrentIndex = idx > -1 ? idx : 0;
            }

            return base.Fetch();
        }


        public override VE0030B_V0COMISSAO OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new VE0030B_V0COMISSAO();
            var i = 0;

            dta.V0COMI_NUM_APOL = result[i++].Value?.ToString();
            dta.V0COMI_NRENDOS = result[i++].Value?.ToString();
            dta.V0COMI_NRCERTIF = result[i++].Value?.ToString();
            dta.V0COMI_DIGCERT = result[i++].Value?.ToString();
            dta.V0COMI_IDTPSEGU = result[i++].Value?.ToString();
            dta.V0COMI_NRPARCEL = result[i++].Value?.ToString();
            dta.V0COMI_OPERACAO = result[i++].Value?.ToString();
            dta.V0COMI_CODPDT = result[i++].Value?.ToString();
            dta.V0COMI_RAMOFR = result[i++].Value?.ToString();
            dta.V0COMI_MODALIFR = result[i++].Value?.ToString();
            dta.V0COMI_OCORHIST = result[i++].Value?.ToString();
            dta.V0COMI_FONTE = result[i++].Value?.ToString();
            dta.V0COMI_CODCLIEN = result[i++].Value?.ToString();
            dta.V0COMI_VLCOMIS = result[i++].Value?.ToString();
            dta.V0COMI_DATCLO = result[i++].Value?.ToString();
            dta.V0COMI_NUMREC = result[i++].Value?.ToString();
            dta.V0COMI_VALBAS = result[i++].Value?.ToString();
            dta.V0COMI_TIPCOM = result[i++].Value?.ToString();
            dta.V0COMI_QTPARCEL = result[i++].Value?.ToString();
            dta.V0COMI_PCCOMCOR = result[i++].Value?.ToString();
            dta.V0COMI_PCDESCON = result[i++].Value?.ToString();
            dta.V0COMI_CODSUBES = result[i++].Value?.ToString();
            dta.V0COMI_DTMOVTO = result[i++].Value?.ToString();
            dta.VIND_DTMOVTO = string.IsNullOrWhiteSpace(dta.V0COMI_DTMOVTO) ? "-1" : "0";
            dta.V0COMI_DATSEL = result[i++].Value?.ToString();
            dta.V0COMI_COD_EMPRESA = result[i++].Value?.ToString();
            dta.VIND_COD_EMP = string.IsNullOrWhiteSpace(dta.V0COMI_COD_EMPRESA) ? "-1" : "0";
            dta.V0COMI_CODPRP = result[i++].Value?.ToString();
            dta.VIND_CODPRP = string.IsNullOrWhiteSpace(dta.V0COMI_CODPRP) ? "-1" : "0";
            dta.V0COMI_NUMBIL = result[i++].Value?.ToString();
            dta.VIND_NUMBIL = string.IsNullOrWhiteSpace(dta.V0COMI_NUMBIL) ? "-1" : "0";
            dta.V0COMI_VLVARMON = result[i++].Value?.ToString();
            dta.VIND_VLVARMON = string.IsNullOrWhiteSpace(dta.V0COMI_VLVARMON) ? "-1" : "0";
            dta.V0COMI_DTQITBCO = result[i++].Value?.ToString();
            dta.VIND_DTQITBCO = string.IsNullOrWhiteSpace(dta.V0COMI_DTQITBCO) ? "-1" : "0";

            return dta;
        }

    }
}