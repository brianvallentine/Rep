using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI0102B
{
    public class SI0102B_V1APOLCORRET : QueryBasis<SI0102B_V1APOLCORRET>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public SI0102B_V1APOLCORRET() { IsCursor = true; }

        public SI0102B_V1APOLCORRET(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string TAPDCORR_NUM_APOL { get; set; }
        public string TMESTSIN_DATCMD { get; set; }
        public string TMESTSIN_APOL_SINI { get; set; }
        public string TAPDCORR_CODCORR { get; set; }
        public string TMESTSIN_MOEDA_SIN { get; set; }
        public string TMESTSIN_CODSUBES { get; set; }
        public string TMESTSIN_NRCERTIF { get; set; }
        public string TMESTSIN_IDTPSEGU { get; set; }

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


        public override SI0102B_V1APOLCORRET OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new SI0102B_V1APOLCORRET();
            var i = 0;

            dta.TAPDCORR_NUM_APOL = result[i++].Value?.ToString();
            dta.TMESTSIN_DATCMD = result[i++].Value?.ToString();
            dta.TMESTSIN_APOL_SINI = result[i++].Value?.ToString();
            dta.TAPDCORR_CODCORR = result[i++].Value?.ToString();
            dta.TMESTSIN_MOEDA_SIN = result[i++].Value?.ToString();
            dta.TMESTSIN_CODSUBES = result[i++].Value?.ToString();
            dta.TMESTSIN_NRCERTIF = result[i++].Value?.ToString();
            dta.TMESTSIN_IDTPSEGU = result[i++].Value?.ToString();

            return dta;
        }

    }
}