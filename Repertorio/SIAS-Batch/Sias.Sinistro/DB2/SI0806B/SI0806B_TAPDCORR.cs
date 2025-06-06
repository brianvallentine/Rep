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
    public class SI0806B_TAPDCORR : QueryBasis<SI0806B_TAPDCORR>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public SI0806B_TAPDCORR() { IsCursor = true; }

        public SI0806B_TAPDCORR(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string APDCORR_NUM_APOL { get; set; }
        public string APDCORR_CODCORR { get; set; }
        public string APDCORR_DTINIVIG { get; set; }
        public string APDCORR_DTTERVIG { get; set; }

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


        public override SI0806B_TAPDCORR OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new SI0806B_TAPDCORR();
            var i = 0;

            dta.APDCORR_NUM_APOL = result[i++].Value?.ToString();
            dta.APDCORR_CODCORR = result[i++].Value?.ToString();
            dta.APDCORR_DTINIVIG = result[i++].Value?.ToString();
            dta.APDCORR_DTTERVIG = result[i++].Value?.ToString();

            return dta;
        }

    }
}