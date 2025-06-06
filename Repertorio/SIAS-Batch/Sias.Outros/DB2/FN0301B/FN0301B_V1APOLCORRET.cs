using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Outros.DB2.FN0301B
{
    public class FN0301B_V1APOLCORRET : QueryBasis<FN0301B_V1APOLCORRET>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public FN0301B_V1APOLCORRET() { IsCursor = true; }

        public FN0301B_V1APOLCORRET(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string V1APCR_NUM_APOL { get; set; }
        public string V1APCR_CODSUBES { get; set; }
        public string V1APCR_RAMOFR { get; set; }
        public string V1APCR_CODCORR { get; set; }
        public string V1APCR_PCCOMCOR { get; set; }
        public string V1APCR_PCPARCOR { get; set; }
        public string V1APCR_TIPCOM { get; set; }

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


        public override FN0301B_V1APOLCORRET OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new FN0301B_V1APOLCORRET();
            var i = 0;

            dta.V1APCR_NUM_APOL = result[i++].Value?.ToString();
            dta.V1APCR_CODSUBES = result[i++].Value?.ToString();
            dta.V1APCR_RAMOFR = result[i++].Value?.ToString();
            dta.V1APCR_CODCORR = result[i++].Value?.ToString();
            dta.V1APCR_PCCOMCOR = result[i++].Value?.ToString();
            dta.V1APCR_PCPARCOR = result[i++].Value?.ToString();
            dta.V1APCR_TIPCOM = result[i++].Value?.ToString();

            return dta;
        }

    }
}