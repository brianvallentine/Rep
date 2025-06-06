using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI0106B
{
    public class SI0106B_THISTSIN1 : QueryBasis<SI0106B_THISTSIN1>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public SI0106B_THISTSIN1() { IsCursor = true; }

        public SI0106B_THISTSIN1(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string THIST_CODPSVI { get; set; }
        public string THIST_NUMOPG { get; set; }
        public string THIST_OPERACAO { get; set; }
        public string THIST_APOL_SINI { get; set; }
        public string THIST_MOVPCS { get; set; }
        public string THIST_NOMFAV { get; set; }
        public string THIST_DTMOVTO { get; set; }
        public string THIST_VAL_OPERACAO { get; set; }

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


        public override SI0106B_THISTSIN1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new SI0106B_THISTSIN1();
            var i = 0;

            dta.THIST_CODPSVI = result[i++].Value?.ToString();
            dta.THIST_NUMOPG = result[i++].Value?.ToString();
            dta.THIST_OPERACAO = result[i++].Value?.ToString();
            dta.THIST_APOL_SINI = result[i++].Value?.ToString();
            dta.THIST_MOVPCS = result[i++].Value?.ToString();
            dta.THIST_NOMFAV = result[i++].Value?.ToString();
            dta.THIST_DTMOVTO = result[i++].Value?.ToString();
            dta.THIST_VAL_OPERACAO = result[i++].Value?.ToString();

            return dta;
        }

    }
}