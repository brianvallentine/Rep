using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI0808B
{
    public class SI0808B_ANT : QueryBasis<SI0808B_ANT>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public SI0808B_ANT() { IsCursor = true; }

        public SI0808B_ANT(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string V0HIST_VAL_OPERACAO { get; set; }
        public string V0HIST_DTMOVTO { get; set; }

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


        public override SI0808B_ANT OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new SI0808B_ANT();
            var i = 0;

            dta.V0HIST_VAL_OPERACAO = result[i++].Value?.ToString();
            dta.V0HIST_DTMOVTO = result[i++].Value?.ToString();

            return dta;
        }

    }
}