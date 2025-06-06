using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA3118B
{
    public class VA3118B_CPROPVA : QueryBasis<VA3118B_CPROPVA>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public VA3118B_CPROPVA() { IsCursor = true; }

        public VA3118B_CPROPVA(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string PROPVA_NUM_APOLICE { get; set; }
        public string PROPVA_CODSUBES { get; set; }
        public string PROPVA_NRCERTIF { get; set; }
        public string PROPVA_CODPRODU { get; set; }
        public string PROPVA_CODCLIEN { get; set; }
        public string PROPVA_OCOREND { get; set; }
        public string PROPVA_FONTE { get; set; }
        public string PROPVA_AGECOBR { get; set; }
        public string PROPVA_OPCAO_COBER { get; set; }
        public string PROPVA_DTQITBCO { get; set; }
        public string PROPVA_DTINICDG { get; set; }
        public string PROPVA_DTINISAF { get; set; }
        public string PROPVA_DTPROXVEN { get; set; }
        public string PROPVA_DTMINVEN { get; set; }
        public string PROPVA_NRMATRVEN { get; set; }
        public string PROPVA_CODOPER { get; set; }
        public string PROPVA_DTMOVTO { get; set; }
        public string PROPVA_SITUACAO { get; set; }
        public string PROPVA_OCORHIST { get; set; }
        public string PROPVA_NRPARCEL { get; set; }
        public string PROPVA_SIT_INTERF { get; set; }
        public string PROPVA_TIMESTAMP { get; set; }
        public string PROPVA_IDADE { get; set; }
        public string PROPVA_SEXO { get; set; }
        public string PROPVA_EST_CIV { get; set; }
        public string PROPVA_COD_CRM { get; set; }
        public string VIND_COD_CRM { get; set; }
        public string PROPVA_NRMATRFUN { get; set; }
        public string PROPVA_INRMATRFUN { get; set; }
        public string PROPVA_DTADMIS { get; set; }
        public string PROPVA_IDTADMIS { get; set; }
        public string PROPVA_NRPROPOS { get; set; }
        public string PROPVA_INRPROPOS { get; set; }
        public string PROPVA_CODCCT { get; set; }
        public string PROPVA_ICODCCT { get; set; }
        public string PROPVA_CODUSU { get; set; }
        public string PROPVA_DTVENCTO { get; set; }
        public string PROPVA_FAIXA_RENDA_IND { get; set; }
        public string VIND_FAIXA_RENDA { get; set; }
        public string PROPVA_DATA { get; set; }
        public string PROPVA_DPS_TITULAR { get; set; }

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


        public override VA3118B_CPROPVA OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new VA3118B_CPROPVA();
            var i = 0;

            dta.PROPVA_NUM_APOLICE = result[i++].Value?.ToString();
            dta.PROPVA_CODSUBES = result[i++].Value?.ToString();
            dta.PROPVA_NRCERTIF = result[i++].Value?.ToString();
            dta.PROPVA_CODPRODU = result[i++].Value?.ToString();
            dta.PROPVA_CODCLIEN = result[i++].Value?.ToString();
            dta.PROPVA_OCOREND = result[i++].Value?.ToString();
            dta.PROPVA_FONTE = result[i++].Value?.ToString();
            dta.PROPVA_AGECOBR = result[i++].Value?.ToString();
            dta.PROPVA_OPCAO_COBER = result[i++].Value?.ToString();
            dta.PROPVA_DTQITBCO = result[i++].Value?.ToString();
            dta.PROPVA_DTINICDG = result[i++].Value?.ToString();
            dta.PROPVA_DTINISAF = result[i++].Value?.ToString();
            dta.PROPVA_DTPROXVEN = result[i++].Value?.ToString();
            dta.PROPVA_DTMINVEN = result[i++].Value?.ToString();
            dta.PROPVA_NRMATRVEN = result[i++].Value?.ToString();
            dta.PROPVA_CODOPER = result[i++].Value?.ToString();
            dta.PROPVA_DTMOVTO = result[i++].Value?.ToString();
            dta.PROPVA_SITUACAO = result[i++].Value?.ToString();
            dta.PROPVA_NUM_APOLICE = result[i++].Value?.ToString();
            dta.PROPVA_CODSUBES = result[i++].Value?.ToString();
            dta.PROPVA_OCORHIST = result[i++].Value?.ToString();
            dta.PROPVA_NRPARCEL = result[i++].Value?.ToString();
            dta.PROPVA_SIT_INTERF = result[i++].Value?.ToString();
            dta.PROPVA_TIMESTAMP = result[i++].Value?.ToString();
            dta.PROPVA_IDADE = result[i++].Value?.ToString();
            dta.PROPVA_SEXO = result[i++].Value?.ToString();
            dta.PROPVA_EST_CIV = result[i++].Value?.ToString();
            dta.PROPVA_COD_CRM = result[i++].Value?.ToString();
            dta.VIND_COD_CRM = string.IsNullOrWhiteSpace(dta.PROPVA_COD_CRM) ? "-1" : "0";
            dta.PROPVA_NRMATRFUN = result[i++].Value?.ToString();
            dta.PROPVA_INRMATRFUN = string.IsNullOrWhiteSpace(dta.PROPVA_NRMATRFUN) ? "-1" : "0";
            dta.PROPVA_DTADMIS = result[i++].Value?.ToString();
            dta.PROPVA_IDTADMIS = string.IsNullOrWhiteSpace(dta.PROPVA_DTADMIS) ? "-1" : "0";
            dta.PROPVA_NRPROPOS = result[i++].Value?.ToString();
            dta.PROPVA_INRPROPOS = string.IsNullOrWhiteSpace(dta.PROPVA_NRPROPOS) ? "-1" : "0";
            dta.PROPVA_CODCCT = result[i++].Value?.ToString();
            dta.PROPVA_ICODCCT = string.IsNullOrWhiteSpace(dta.PROPVA_CODCCT) ? "-1" : "0";
            dta.PROPVA_CODUSU = result[i++].Value?.ToString();
            dta.PROPVA_DTVENCTO = result[i++].Value?.ToString();
            dta.PROPVA_FAIXA_RENDA_IND = result[i++].Value?.ToString();
            dta.VIND_FAIXA_RENDA = string.IsNullOrWhiteSpace(dta.PROPVA_FAIXA_RENDA_IND) ? "-1" : "0";
            dta.PROPVA_DATA = result[i++].Value?.ToString();
            dta.PROPVA_DPS_TITULAR = result[i++].Value?.ToString();

            return dta;
        }

    }
}