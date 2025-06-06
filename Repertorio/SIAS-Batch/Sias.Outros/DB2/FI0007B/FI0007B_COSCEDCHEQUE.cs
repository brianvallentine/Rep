using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Outros.DB2.FI0007B
{
    public class FI0007B_COSCEDCHEQUE : QueryBasis<FI0007B_COSCEDCHEQUE>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public FI0007B_COSCEDCHEQUE() { IsCursor = true; }

        public FI0007B_COSCEDCHEQUE(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string V0CCHQ_COD_EMPR { get; set; }
        public string V0CCHQ_CONGENER { get; set; }
        public string V0CCHQ_DTMOVTO_AC { get; set; }
        public string V0CCHQ_VLPREMIO { get; set; }
        public string V0CCHQ_VLRDESCON { get; set; }
        public string V0CCHQ_VLRADIFRA { get; set; }
        public string V0CCHQ_VLRCOMIS { get; set; }
        public string V0CCHQ_VLRSINI { get; set; }
        public string V0CCHQ_VLDESPESA { get; set; }
        public string V0CCHQ_VLRHONOR { get; set; }
        public string V0CCHQ_VLRSALVD { get; set; }
        public string V0CCHQ_VLRESSARC { get; set; }
        public string V0CCHQ_VALOR_EDI { get; set; }
        public string V0CCHQ_VALOR_USS { get; set; }
        public string V0CCHQ_VLEQPVNDA { get; set; }
        public string V0CCHQ_VLDESPADM { get; set; }
        public string V0CCHQ_OUTRDEBIT { get; set; }
        public string V0CCHQ_OUTRCREDT { get; set; }
        public string V0CCHQ_VLRSLDANT { get; set; }

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


        public override FI0007B_COSCEDCHEQUE OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new FI0007B_COSCEDCHEQUE();
            var i = 0;

            dta.V0CCHQ_COD_EMPR = result[i++].Value?.ToString();
            dta.V0CCHQ_CONGENER = result[i++].Value?.ToString();
            dta.V0CCHQ_DTMOVTO_AC = result[i++].Value?.ToString();
            dta.V0CCHQ_VLPREMIO = result[i++].Value?.ToString();
            dta.V0CCHQ_VLRDESCON = result[i++].Value?.ToString();
            dta.V0CCHQ_VLRADIFRA = result[i++].Value?.ToString();
            dta.V0CCHQ_VLRCOMIS = result[i++].Value?.ToString();
            dta.V0CCHQ_VLRSINI = result[i++].Value?.ToString();
            dta.V0CCHQ_VLDESPESA = result[i++].Value?.ToString();
            dta.V0CCHQ_VLRHONOR = result[i++].Value?.ToString();
            dta.V0CCHQ_VLRSALVD = result[i++].Value?.ToString();
            dta.V0CCHQ_VLRESSARC = result[i++].Value?.ToString();
            dta.V0CCHQ_VALOR_EDI = result[i++].Value?.ToString();
            dta.V0CCHQ_VALOR_USS = result[i++].Value?.ToString();
            dta.V0CCHQ_VLEQPVNDA = result[i++].Value?.ToString();
            dta.V0CCHQ_VLDESPADM = result[i++].Value?.ToString();
            dta.V0CCHQ_OUTRDEBIT = result[i++].Value?.ToString();
            dta.V0CCHQ_OUTRCREDT = result[i++].Value?.ToString();
            dta.V0CCHQ_VLRSLDANT = result[i++].Value?.ToString();

            return dta;
        }

    }
}