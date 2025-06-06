using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI0820B
{
    public class SI0820B_V0HISTSINI : QueryBasis<SI0820B_V0HISTSINI>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public SI0820B_V0HISTSINI() { IsCursor = true; }

        public SI0820B_V0HISTSINI(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string V0HISTSINI_OPERACAO { get; set; }
        public string V0HISTSINI_VAL_OPERACAO { get; set; }
        public string V0HISTSINI_DTMOVTO { get; set; }

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


        public override SI0820B_V0HISTSINI OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new SI0820B_V0HISTSINI();
            var i = 0;

            dta.V0HISTSINI_OPERACAO = result[i++].Value?.ToString();
            dta.V0HISTSINI_VAL_OPERACAO = result[i++].Value?.ToString();
            dta.V0HISTSINI_DTMOVTO = result[i++].Value?.ToString();

            return dta;
        }

    }
}