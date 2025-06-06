using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI1000B
{
    public class SI1000B_V1MESTSINI : QueryBasis<SI1000B_V1MESTSINI>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public SI1000B_V1MESTSINI() { IsCursor = true; }

        public SI1000B_V1MESTSINI(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string V1MSIN_TIPREG { get; set; }
        public string V1MSIN_NUM_SINI { get; set; }
        public string V1MSIN_NUM_APOL { get; set; }
        public string V1MSIN_CODPRODU { get; set; }
        public string V1MSIN_IDTPSEGU { get; set; }
        public string V1MSIN_OCORHIST { get; set; }
        public string V1MSIN_DATCMD { get; set; }
        public string V1MSIN_COD_MOEDA { get; set; }
        public string V1MSIN_SDOPAGBT { get; set; }
        public string V1HSIN_DTMOVTO { get; set; }

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


        public override SI1000B_V1MESTSINI OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new SI1000B_V1MESTSINI();
            var i = 0;

            dta.V1MSIN_TIPREG = result[i++].Value?.ToString();
            dta.V1MSIN_NUM_SINI = result[i++].Value?.ToString();
            dta.V1MSIN_NUM_APOL = result[i++].Value?.ToString();
            dta.V1MSIN_CODPRODU = result[i++].Value?.ToString();
            dta.V1MSIN_IDTPSEGU = result[i++].Value?.ToString();
            dta.V1MSIN_OCORHIST = result[i++].Value?.ToString();
            dta.V1MSIN_DATCMD = result[i++].Value?.ToString();
            dta.V1MSIN_COD_MOEDA = result[i++].Value?.ToString();
            dta.V1MSIN_SDOPAGBT = result[i++].Value?.ToString();
            dta.V1HSIN_DTMOVTO = result[i++].Value?.ToString();

            return dta;
        }

    }
}