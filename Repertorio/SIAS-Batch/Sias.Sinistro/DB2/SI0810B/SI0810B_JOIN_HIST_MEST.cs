using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI0810B
{
    public class SI0810B_JOIN_HIST_MEST : QueryBasis<SI0810B_JOIN_HIST_MEST>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public SI0810B_JOIN_HIST_MEST() { IsCursor = true; }

        public SI0810B_JOIN_HIST_MEST(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string V0MEST_NUM_APOLICE { get; set; }
        public string V0MEST_NUM_APOL_SINI { get; set; }
        public string V0MEST_RAMO { get; set; }
        public string V0MEST_NRCERTIF { get; set; }
        public string V0MEST_SITUACAO { get; set; }
        public string V0MEST_DATCMD { get; set; }
        public string V0MEST_DTULTMOV { get; set; }
        public string V0APOL_RAMO { get; set; }

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


        public override SI0810B_JOIN_HIST_MEST OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new SI0810B_JOIN_HIST_MEST();
            var i = 0;

            dta.V0MEST_NUM_APOLICE = result[i++].Value?.ToString();
            dta.V0MEST_NUM_APOL_SINI = result[i++].Value?.ToString();
            dta.V0MEST_RAMO = result[i++].Value?.ToString();
            dta.V0MEST_NRCERTIF = result[i++].Value?.ToString();
            dta.V0MEST_SITUACAO = result[i++].Value?.ToString();
            dta.V0MEST_DATCMD = result[i++].Value?.ToString();
            dta.V0MEST_DTULTMOV = result[i++].Value?.ToString();
            dta.V0APOL_RAMO = result[i++].Value?.ToString();

            return dta;
        }

    }
}