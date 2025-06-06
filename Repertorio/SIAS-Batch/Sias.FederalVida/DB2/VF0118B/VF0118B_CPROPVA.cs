using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.FederalVida.DB2.VF0118B
{
    public class VF0118B_CPROPVA : QueryBasis<VF0118B_CPROPVA>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public VF0118B_CPROPVA() { IsCursor = true; }

        public VF0118B_CPROPVA(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string PROPVA_NRCERTIF { get; set; }
        public string PROPVA_CODPRODU { get; set; }
        public string PROPVA_CODCLIEN { get; set; }
        public string PROPVA_OCOREND { get; set; }
        public string PROPVA_FONTE { get; set; }
        public string PROPVA_OPCAO_COBER { get; set; }
        public string PROPVA_DTQITBCO { get; set; }
        public string VIND_DTQITBCO { get; set; }
        public string PROPVA_DTINIVIG { get; set; }
        public string VIND_DTINIVIG { get; set; }
        public string PROPVA_DTPROXVEN { get; set; }
        public string VIND_DTPROXVEN { get; set; }
        public string PROPVA_DTMINVEN { get; set; }
        public string VIND_DTMINVEN { get; set; }
        public string PROPVA_CODOPER { get; set; }
        public string PROPVA_DTMOVTO { get; set; }
        public string VIND_DTMOVTO { get; set; }
        public string PROPVA_SITUACAO { get; set; }
        public string PROPVA_NUM_APOLICE { get; set; }
        public string PROPVA_CODSUBES { get; set; }
        public string PROPVA_OCORHIST { get; set; }
        public string PROPVA_NRPARCEL { get; set; }
        public string PROPVA_DTVENCTO { get; set; }
        public string VIND_DTVENCTO { get; set; }
        public string PROPVA_TIMESTAMP { get; set; }
        public string PROPVA_IDADE { get; set; }
        public string PROPVA_SEXO { get; set; }
        public string PROPVA_CODUSU { get; set; }

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


        public override VF0118B_CPROPVA OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new VF0118B_CPROPVA();
            var i = 0;

            dta.PROPVA_NRCERTIF = result[i++].Value?.ToString();
            dta.PROPVA_CODPRODU = result[i++].Value?.ToString();
            dta.PROPVA_CODCLIEN = result[i++].Value?.ToString();
            dta.PROPVA_OCOREND = result[i++].Value?.ToString();
            dta.PROPVA_FONTE = result[i++].Value?.ToString();
            dta.PROPVA_OPCAO_COBER = result[i++].Value?.ToString();
            dta.PROPVA_DTQITBCO = result[i++].Value?.ToString();
            dta.VIND_DTQITBCO = string.IsNullOrWhiteSpace(dta.PROPVA_DTQITBCO) ? "-1" : "0";
            dta.PROPVA_DTINIVIG = result[i++].Value?.ToString();
            dta.VIND_DTINIVIG = string.IsNullOrWhiteSpace(dta.PROPVA_DTINIVIG) ? "-1" : "0";
            dta.PROPVA_DTPROXVEN = result[i++].Value?.ToString();
            dta.VIND_DTPROXVEN = string.IsNullOrWhiteSpace(dta.PROPVA_DTPROXVEN) ? "-1" : "0";
            dta.PROPVA_DTMINVEN = result[i++].Value?.ToString();
            dta.VIND_DTMINVEN = string.IsNullOrWhiteSpace(dta.PROPVA_DTMINVEN) ? "-1" : "0";
            dta.PROPVA_CODOPER = result[i++].Value?.ToString();
            dta.PROPVA_DTMOVTO = result[i++].Value?.ToString();
            dta.VIND_DTMOVTO = string.IsNullOrWhiteSpace(dta.PROPVA_DTMOVTO) ? "-1" : "0";
            dta.PROPVA_SITUACAO = result[i++].Value?.ToString();
            dta.PROPVA_NUM_APOLICE = result[i++].Value?.ToString();
            dta.PROPVA_CODSUBES = result[i++].Value?.ToString();
            dta.PROPVA_OCORHIST = result[i++].Value?.ToString();
            dta.PROPVA_NRPARCEL = result[i++].Value?.ToString();
            dta.PROPVA_DTVENCTO = result[i++].Value?.ToString();
            dta.VIND_DTVENCTO = string.IsNullOrWhiteSpace(dta.PROPVA_DTVENCTO) ? "-1" : "0";
            dta.PROPVA_TIMESTAMP = result[i++].Value?.ToString();
            dta.PROPVA_IDADE = result[i++].Value?.ToString();
            dta.PROPVA_SEXO = result[i++].Value?.ToString();
            dta.PROPVA_CODUSU = result[i++].Value?.ToString();

            return dta;
        }

    }
}