using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI0803B
{
    public class SI0803B_V1RELATSINI : QueryBasis<SI0803B_V1RELATSINI>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public SI0803B_V1RELATSINI() { IsCursor = true; }

        public SI0803B_V1RELATSINI(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string RELSIN_APOLICE { get; set; }
        public string RELSIN_ANO_REF { get; set; }
        public string RELSIN_MES_REF { get; set; }

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


        public override SI0803B_V1RELATSINI OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new SI0803B_V1RELATSINI();
            var i = 0;

            dta.RELSIN_APOLICE = result[i++].Value?.ToString();
            dta.RELSIN_ANO_REF = result[i++].Value?.ToString();
            dta.RELSIN_MES_REF = result[i++].Value?.ToString();

            return dta;
        }

    }
}