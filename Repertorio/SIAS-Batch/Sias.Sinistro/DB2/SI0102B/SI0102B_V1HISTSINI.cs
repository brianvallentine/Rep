using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI0102B
{
    public class SI0102B_V1HISTSINI : QueryBasis<SI0102B_V1HISTSINI>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public SI0102B_V1HISTSINI() { IsCursor = true; }

        public SI0102B_V1HISTSINI(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string THISTSIN_DTMOVTO { get; set; }
        public string THISTSIN_VAL_OPER { get; set; }
        public string THISTSIN_OPERACAO { get; set; }

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


        public override SI0102B_V1HISTSINI OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new SI0102B_V1HISTSINI();
            var i = 0;

            dta.THISTSIN_DTMOVTO = result[i++].Value?.ToString();
            dta.THISTSIN_VAL_OPER = result[i++].Value?.ToString();
            dta.THISTSIN_OPERACAO = result[i++].Value?.ToString();

            return dta;
        }

    }
}