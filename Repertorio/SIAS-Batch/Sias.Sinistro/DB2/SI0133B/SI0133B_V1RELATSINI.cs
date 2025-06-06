using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI0133B
{
    public class SI0133B_V1RELATSINI : QueryBasis<SI0133B_V1RELATSINI>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public SI0133B_V1RELATSINI() { IsCursor = true; }

        public SI0133B_V1RELATSINI(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string RELSIN_APOL_SINI { get; set; }
        public string RELSIN_DTMOVTO { get; set; }
        public string RELSIN_OPERACAO { get; set; }
        public string RELSIN_OCORHIST { get; set; }
        public string RELSIN_CODPSI { get; set; }
        public string RELSIN_CODUSU { get; set; }
        public string RELSIN_MOVPCS { get; set; }
        public string MEST_TIPREG { get; set; }
        public string MEST_NUM_APOL { get; set; }
        public string MEST_NRENDOS { get; set; }
        public string MEST_NRCERTIF { get; set; }
        public string MEST_DIGCERT { get; set; }
        public string MEST_IDTPSEGU { get; set; }
        public string MEST_DATCMD { get; set; }
        public string MEST_DATTEC { get; set; }
        public string MEST_DATORR { get; set; }
        public string MEST_FONTE { get; set; }
        public string MEST_DAC { get; set; }
        public string MEST_PCPARTIC { get; set; }
        public string MEST_PCTRES { get; set; }
        public string MEST_TOTPAGBT { get; set; }
        public string MEST_TOTDSABT { get; set; }
        public string MEST_TOTHONBT { get; set; }
        public string MEST_TOTRSDBT { get; set; }
        public string MEST_SDORCPBT { get; set; }
        public string MEST_SDOADTBT { get; set; }
        public string MEST_CODCAU { get; set; }
        public string MEST_PROTSINI { get; set; }
        public string MEST_CODSUBES { get; set; }
        public string MEST_OCORHIST { get; set; }
        public string MEST_COD_MOEDA_SIN { get; set; }
        public string MEST_NUMIRB { get; set; }
        public string MEST_CODPRODU { get; set; }
        public string MEST_RAMO { get; set; }
        public string PRODUTO_DESCR_PRODUTO { get; set; }

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


        public override SI0133B_V1RELATSINI OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new SI0133B_V1RELATSINI();
            var i = 0;

            dta.RELSIN_APOL_SINI = result[i++].Value?.ToString();
            dta.RELSIN_DTMOVTO = result[i++].Value?.ToString();
            dta.RELSIN_OPERACAO = result[i++].Value?.ToString();
            dta.RELSIN_OCORHIST = result[i++].Value?.ToString();
            dta.RELSIN_CODPSI = result[i++].Value?.ToString();
            dta.RELSIN_CODUSU = result[i++].Value?.ToString();
            dta.RELSIN_MOVPCS = result[i++].Value?.ToString();
            dta.MEST_TIPREG = result[i++].Value?.ToString();
            dta.MEST_NUM_APOL = result[i++].Value?.ToString();
            dta.MEST_NRENDOS = result[i++].Value?.ToString();
            dta.MEST_NRCERTIF = result[i++].Value?.ToString();
            dta.MEST_DIGCERT = result[i++].Value?.ToString();
            dta.MEST_IDTPSEGU = result[i++].Value?.ToString();
            dta.MEST_DATCMD = result[i++].Value?.ToString();
            dta.MEST_DATTEC = result[i++].Value?.ToString();
            dta.MEST_DATORR = result[i++].Value?.ToString();
            dta.MEST_FONTE = result[i++].Value?.ToString();
            dta.MEST_DAC = result[i++].Value?.ToString();
            dta.MEST_PCPARTIC = result[i++].Value?.ToString();
            dta.MEST_PCTRES = result[i++].Value?.ToString();
            dta.MEST_TOTPAGBT = result[i++].Value?.ToString();
            dta.MEST_TOTDSABT = result[i++].Value?.ToString();
            dta.MEST_TOTHONBT = result[i++].Value?.ToString();
            dta.MEST_TOTRSDBT = result[i++].Value?.ToString();
            dta.MEST_SDORCPBT = result[i++].Value?.ToString();
            dta.MEST_SDOADTBT = result[i++].Value?.ToString();
            dta.MEST_CODCAU = result[i++].Value?.ToString();
            dta.MEST_PROTSINI = result[i++].Value?.ToString();
            dta.MEST_CODSUBES = result[i++].Value?.ToString();
            dta.MEST_OCORHIST = result[i++].Value?.ToString();
            dta.MEST_COD_MOEDA_SIN = result[i++].Value?.ToString();
            dta.MEST_NUMIRB = result[i++].Value?.ToString();
            dta.MEST_CODPRODU = result[i++].Value?.ToString();
            dta.MEST_RAMO = result[i++].Value?.ToString();
            dta.PRODUTO_DESCR_PRODUTO = result[i++].Value?.ToString();

            return dta;
        }

    }
}