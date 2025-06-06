using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI0101B
{
    public class SI0101B_V1HISTSINI : QueryBasis<SI0101B_V1HISTSINI>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public SI0101B_V1HISTSINI() { IsCursor = true; }

        public SI0101B_V1HISTSINI(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string THIST_DTMOVTO { get; set; }
        public string THIST_VALPRI { get; set; }
        public string THIST_OPERACAO { get; set; }

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


        public override SI0101B_V1HISTSINI OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new SI0101B_V1HISTSINI();
            var i = 0;

            dta.THIST_DTMOVTO = result[i++].Value?.ToString();
            dta.THIST_VALPRI = result[i++].Value?.ToString();
            dta.THIST_OPERACAO = result[i++].Value?.ToString();

            return dta;
        }

    }
}