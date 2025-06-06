using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI0810B
{
    public class SI0810B_PARCIAL : QueryBasis<SI0810B_PARCIAL>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public SI0810B_PARCIAL() { IsCursor = true; }

        public SI0810B_PARCIAL(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string V0HIST_VAL_OPERACAO_3 { get; set; }
        public string V0HIST_DTMOVTO_3 { get; set; }
        public string V0HIST_operacao_3 { get; set; }

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


        public override SI0810B_PARCIAL OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new SI0810B_PARCIAL();
            var i = 0;

            dta.V0HIST_VAL_OPERACAO_3 = result[i++].Value?.ToString();
            dta.V0HIST_DTMOVTO_3 = result[i++].Value?.ToString();
            dta.V0HIST_operacao_3 = result[i++].Value?.ToString();

            return dta;
        }

    }
}