using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Cosseguro.DB2.AC0041B
{
    public class AC0041B_V0COSCEDCHQ : QueryBasis<AC0041B_V0COSCEDCHQ>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public AC0041B_V0COSCEDCHQ() { IsCursor = true; }

        public AC0041B_V0COSCEDCHQ(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string V0CCCH_COD_EMPR { get; set; }
        public string V0CCCH_CONGENER { get; set; }
        public string V0CCCH_DTMOVTAC { get; set; }
        public string V0CCCH_CODUSUAC { get; set; }
        public string V0CCCH_DTLIBERA { get; set; }
        public string V0CCCH_NRCHQINT { get; set; }
        public string V0CCCH_DVCHQINT { get; set; }
        public string V0CCCH_VLPREMIO { get; set; }
        public string V0CCCH_VLDESCON { get; set; }
        public string V0CCCH_VLADIFRA { get; set; }
        public string V0CCCH_VLRCOMIS { get; set; }
        public string V0CCCH_VLRSINI { get; set; }
        public string V0CCCH_VLDESPESA { get; set; }
        public string V0CCCH_VLRHONOR { get; set; }
        public string V0CCCH_VLRSALVD { get; set; }
        public string V0CCCH_VLRESSARC { get; set; }
        public string V0CCCH_VALOR_EDI { get; set; }
        public string V0CCCH_VALOR_USS { get; set; }
        public string V0CCCH_VLEQPVNDA { get; set; }
        public string V0CCCH_VLDESPADM { get; set; }
        public string V0CCCH_OUTRDEBIT { get; set; }
        public string V0CCCH_OUTRCREDT { get; set; }
        public string V0CCCH_VLRSLDANT { get; set; }
        public string V0CCCH_SITUACAO { get; set; }
        public string V0CCCH_DTMOVTFI { get; set; }

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


        public override AC0041B_V0COSCEDCHQ OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new AC0041B_V0COSCEDCHQ();
            var i = 0;

            dta.V0CCCH_COD_EMPR = result[i++].Value?.ToString();
            dta.V0CCCH_CONGENER = result[i++].Value?.ToString();
            dta.V0CCCH_DTMOVTAC = result[i++].Value?.ToString();
            dta.V0CCCH_CODUSUAC = result[i++].Value?.ToString();
            dta.V0CCCH_DTLIBERA = result[i++].Value?.ToString();
            dta.V0CCCH_NRCHQINT = result[i++].Value?.ToString();
            dta.V0CCCH_DVCHQINT = result[i++].Value?.ToString();
            dta.V0CCCH_VLPREMIO = result[i++].Value?.ToString();
            dta.V0CCCH_VLDESCON = result[i++].Value?.ToString();
            dta.V0CCCH_VLADIFRA = result[i++].Value?.ToString();
            dta.V0CCCH_VLRCOMIS = result[i++].Value?.ToString();
            dta.V0CCCH_VLRSINI = result[i++].Value?.ToString();
            dta.V0CCCH_VLDESPESA = result[i++].Value?.ToString();
            dta.V0CCCH_VLRHONOR = result[i++].Value?.ToString();
            dta.V0CCCH_VLRSALVD = result[i++].Value?.ToString();
            dta.V0CCCH_VLRESSARC = result[i++].Value?.ToString();
            dta.V0CCCH_VALOR_EDI = result[i++].Value?.ToString();
            dta.V0CCCH_VALOR_USS = result[i++].Value?.ToString();
            dta.V0CCCH_VLEQPVNDA = result[i++].Value?.ToString();
            dta.V0CCCH_VLDESPADM = result[i++].Value?.ToString();
            dta.V0CCCH_OUTRDEBIT = result[i++].Value?.ToString();
            dta.V0CCCH_OUTRCREDT = result[i++].Value?.ToString();
            dta.V0CCCH_VLRSLDANT = result[i++].Value?.ToString();
            dta.V0CCCH_SITUACAO = result[i++].Value?.ToString();
            dta.V0CCCH_DTMOVTFI = result[i++].Value?.ToString();

            return dta;
        }

    }
}