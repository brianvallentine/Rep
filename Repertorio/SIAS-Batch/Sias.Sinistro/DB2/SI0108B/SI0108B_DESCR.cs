using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI0108B
{
    public class SI0108B_DESCR : QueryBasis<SI0108B_DESCR>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public SI0108B_DESCR() { IsCursor = true; }

        public SI0108B_DESCR(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string THIST_APOL_SINI { get; set; }
        public string THIST_OPERACAO { get; set; }
        public string THIST_DTMOVTO { get; set; }
        public string THIST_VAL_OPERACAO { get; set; }
        public string THIST_SITUACAO { get; set; }
        public string THIST_LIMCRR { get; set; }
        public string TMEST_FONTE { get; set; }

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


        public override SI0108B_DESCR OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new SI0108B_DESCR();
            var i = 0;

            dta.THIST_APOL_SINI = result[i++].Value?.ToString();
            dta.THIST_OPERACAO = result[i++].Value?.ToString();
            dta.THIST_DTMOVTO = result[i++].Value?.ToString();
            dta.THIST_VAL_OPERACAO = result[i++].Value?.ToString();
            dta.THIST_SITUACAO = result[i++].Value?.ToString();
            dta.THIST_LIMCRR = result[i++].Value?.ToString();
            dta.TMEST_FONTE = result[i++].Value?.ToString();

            return dta;
        }

    }
}