using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Emissao.DB2.EM0911S
{
    public class EM0911S_V1OUTRBENSPROP : QueryBasis<EM0911S_V1OUTRBENSPROP>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public EM0911S_V1OUTRBENSPROP() { IsCursor = true; }

        public EM0911S_V1OUTRBENSPROP(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string V1PROB_COD_EMPRESA { get; set; }
        public string V1PROB_FONTE { get; set; }
        public string V1PROB_NRPROPOS { get; set; }
        public string V1PROB_NRRISCO { get; set; }
        public string V1PROB_DTINIVIG { get; set; }
        public string V1PROB_DTTERVIG { get; set; }
        public string V1PROB_NRBEM { get; set; }
        public string V1PROB_DESCRBEM { get; set; }
        public string V1PROB_NRSERIE { get; set; }
        public string V1PROB_IMP_SEG_IX { get; set; }

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


        public override EM0911S_V1OUTRBENSPROP OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new EM0911S_V1OUTRBENSPROP();
            var i = 0;

            dta.V1PROB_COD_EMPRESA = result[i++].Value?.ToString();
            dta.V1PROB_FONTE = result[i++].Value?.ToString();
            dta.V1PROB_NRPROPOS = result[i++].Value?.ToString();
            dta.V1PROB_NRRISCO = result[i++].Value?.ToString();
            dta.V1PROB_DTINIVIG = result[i++].Value?.ToString();
            dta.V1PROB_DTTERVIG = result[i++].Value?.ToString();
            dta.V1PROB_NRBEM = result[i++].Value?.ToString();
            dta.V1PROB_DESCRBEM = result[i++].Value?.ToString();
            dta.V1PROB_NRSERIE = result[i++].Value?.ToString();
            dta.V1PROB_IMP_SEG_IX = result[i++].Value?.ToString();

            return dta;
        }

    }
}