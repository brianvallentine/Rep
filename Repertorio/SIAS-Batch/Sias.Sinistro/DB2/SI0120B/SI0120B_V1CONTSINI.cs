using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI0120B
{
    public class SI0120B_V1CONTSINI : QueryBasis<SI0120B_V1CONTSINI>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public SI0120B_V1CONTSINI() { IsCursor = true; }

        public SI0120B_V1CONTSINI(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string CONTSIN_FONTE { get; set; }
        public string CONTSIN_PROTSINI { get; set; }
        public string CONTSIN_DAC { get; set; }
        public string CONTSIN_APOLICE { get; set; }
        public string CONTSIN_TIMESTAMP { get; set; }

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


        public override SI0120B_V1CONTSINI OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new SI0120B_V1CONTSINI();
            var i = 0;

            dta.CONTSIN_FONTE = result[i++].Value?.ToString();
            dta.CONTSIN_PROTSINI = result[i++].Value?.ToString();
            dta.CONTSIN_DAC = result[i++].Value?.ToString();
            dta.CONTSIN_APOLICE = result[i++].Value?.ToString();
            dta.CONTSIN_TIMESTAMP = result[i++].Value?.ToString();

            return dta;
        }

    }
}