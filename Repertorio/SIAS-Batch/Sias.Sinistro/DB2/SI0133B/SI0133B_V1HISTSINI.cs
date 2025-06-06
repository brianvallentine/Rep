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
    public class SI0133B_V1HISTSINI : QueryBasis<SI0133B_V1HISTSINI>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public SI0133B_V1HISTSINI() { IsCursor = true; }

        public SI0133B_V1HISTSINI(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string THIST_VALPRI { get; set; }
        public string THIST_OCORHIST { get; set; }
        public string THIST_DTMOVTO { get; set; }
        public string THIST_SITUACAO { get; set; }
        public string THIST_OPERACAO { get; set; }
        public string THIST_FONPAG { get; set; }
        public string WVARIAV_IND { get; set; }
        public string THIST_NOMFAV { get; set; }
        public string THIST_CODPSVI { get; set; }
        public string THIST_TIPFAV { get; set; }
        public string THIST_LIMCRR { get; set; }
        public string THIST_MOVPCS { get; set; }
        public string THIST_NUMOPG { get; set; }
        public string GEOPERAC_FUNCAO_OPERACAO { get; set; }

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


        public override SI0133B_V1HISTSINI OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new SI0133B_V1HISTSINI();
            var i = 0;

            dta.THIST_VALPRI = result[i++].Value?.ToString();
            dta.THIST_OCORHIST = result[i++].Value?.ToString();
            dta.THIST_DTMOVTO = result[i++].Value?.ToString();
            dta.THIST_SITUACAO = result[i++].Value?.ToString();
            dta.THIST_OPERACAO = result[i++].Value?.ToString();
            dta.THIST_FONPAG = result[i++].Value?.ToString();
            dta.WVARIAV_IND = string.IsNullOrWhiteSpace(dta.THIST_FONPAG) ? "-1" : "0";
            dta.THIST_NOMFAV = result[i++].Value?.ToString();
            dta.THIST_CODPSVI = result[i++].Value?.ToString();
            dta.THIST_TIPFAV = result[i++].Value?.ToString();
            dta.THIST_LIMCRR = result[i++].Value?.ToString();
            dta.THIST_MOVPCS = result[i++].Value?.ToString();
            dta.THIST_NUMOPG = result[i++].Value?.ToString();
            dta.GEOPERAC_FUNCAO_OPERACAO = result[i++].Value?.ToString();

            return dta;
        }

    }
}