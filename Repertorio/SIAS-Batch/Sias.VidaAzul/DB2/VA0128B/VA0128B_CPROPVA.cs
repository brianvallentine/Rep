using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0128B
{
    public class VA0128B_CPROPVA : QueryBasis<VA0128B_CPROPVA>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public VA0128B_CPROPVA() { IsCursor = true; }

        public VA0128B_CPROPVA(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string PROPVA_NUM_APOLICE { get; set; }
        public string PROPVA_CODSUBES { get; set; }
        public string PROPVA_NRCERTIF { get; set; }
        public string PROPVA_CODCLIEN { get; set; }
        public string PROPVA_OCOREND { get; set; }
        public string PROPVA_FONTE { get; set; }
        public string PROPVA_AGECOBR { get; set; }
        public string PROPVA_OPCAO_COBER { get; set; }
        public string PROPVA_DTPROXVEN { get; set; }
        public string PROPVA_CODOPER { get; set; }
        public string PROPVA_DTMOVTO { get; set; }
        public string PROPVA_OCORHIST { get; set; }
        public string PROPVA_SIT_INTERF { get; set; }
        public string PROPVA_TIMESTAMP { get; set; }
        public string PROPVA_SEXO { get; set; }
        public string PROPVA_EST_CIV { get; set; }
        public string PROPVA_DTQITBCO_1YEAR { get; set; }
        public string PROPVA_DTQITBCO { get; set; }
        public string PROPVA_IDADE { get; set; }

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


        public override VA0128B_CPROPVA OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new VA0128B_CPROPVA();
            var i = 0;

            dta.PROPVA_NUM_APOLICE = result[i++].Value?.ToString();
            dta.PROPVA_CODSUBES = result[i++].Value?.ToString();
            dta.PROPVA_NRCERTIF = result[i++].Value?.ToString();
            dta.PROPVA_CODCLIEN = result[i++].Value?.ToString();
            dta.PROPVA_OCOREND = result[i++].Value?.ToString();
            dta.PROPVA_FONTE = result[i++].Value?.ToString();
            dta.PROPVA_AGECOBR = result[i++].Value?.ToString();
            dta.PROPVA_OPCAO_COBER = result[i++].Value?.ToString();
            dta.PROPVA_DTPROXVEN = result[i++].Value?.ToString();
            dta.PROPVA_CODOPER = result[i++].Value?.ToString();
            dta.PROPVA_DTMOVTO = result[i++].Value?.ToString();
            dta.PROPVA_NUM_APOLICE = result[i++].Value?.ToString();
            dta.PROPVA_CODSUBES = result[i++].Value?.ToString();
            dta.PROPVA_OCORHIST = result[i++].Value?.ToString();
            dta.PROPVA_SIT_INTERF = result[i++].Value?.ToString();
            dta.PROPVA_TIMESTAMP = result[i++].Value?.ToString();
            dta.PROPVA_SEXO = result[i++].Value?.ToString();
            dta.PROPVA_EST_CIV = result[i++].Value?.ToString();
            dta.PROPVA_DTQITBCO_1YEAR = result[i++].Value?.ToString();
            dta.PROPVA_DTQITBCO = result[i++].Value?.ToString();
            dta.PROPVA_IDADE = result[i++].Value?.ToString();

            return dta;
        }

    }
}