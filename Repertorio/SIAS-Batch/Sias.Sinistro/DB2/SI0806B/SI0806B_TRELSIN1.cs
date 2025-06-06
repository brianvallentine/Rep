using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI0806B
{
    public class SI0806B_TRELSIN1 : QueryBasis<SI0806B_TRELSIN1>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public SI0806B_TRELSIN1() { IsCursor = true; }

        public SI0806B_TRELSIN1(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string RELSIN_APOL_SINI { get; set; }
        public string RELSIN_DTMOVTO { get; set; }
        public string RELSIN_OPERACAO { get; set; }
        public string RELSIN_OCORHIST { get; set; }
        public string RELSIN_FONTE { get; set; }
        public string MEST_MOEDA_SINI { get; set; }
        public string THIST_LIMCRR { get; set; }

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


        public override SI0806B_TRELSIN1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new SI0806B_TRELSIN1();
            var i = 0;

            dta.RELSIN_APOL_SINI = result[i++].Value?.ToString();
            dta.RELSIN_DTMOVTO = result[i++].Value?.ToString();
            dta.RELSIN_OPERACAO = result[i++].Value?.ToString();
            dta.RELSIN_OCORHIST = result[i++].Value?.ToString();
            dta.RELSIN_FONTE = result[i++].Value?.ToString();
            dta.MEST_MOEDA_SINI = result[i++].Value?.ToString();
            dta.THIST_LIMCRR = result[i++].Value?.ToString();

            return dta;
        }

    }
}