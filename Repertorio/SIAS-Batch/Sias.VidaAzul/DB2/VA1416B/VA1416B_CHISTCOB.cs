using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA1416B
{
    public class VA1416B_CHISTCOB : QueryBasis<VA1416B_CHISTCOB>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public VA1416B_CHISTCOB() { IsCursor = true; }

        public VA1416B_CHISTCOB(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string V0HCOB_NRCERTIF { get; set; }
        public string V0HCOB_NRPARCEL { get; set; }
        public string V0HCOB_NRTIT { get; set; }
        public string V0HCOB_DTVENCTO { get; set; }
        public string V0HCOB_OCORHIST { get; set; }

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


        public override VA1416B_CHISTCOB OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new VA1416B_CHISTCOB();
            var i = 0;

            dta.V0HCOB_NRCERTIF = result[i++].Value?.ToString();
            dta.V0HCOB_NRPARCEL = result[i++].Value?.ToString();
            dta.V0HCOB_NRTIT = result[i++].Value?.ToString();
            dta.V0HCOB_DTVENCTO = result[i++].Value?.ToString();
            dta.V0HCOB_OCORHIST = result[i++].Value?.ToString();

            return dta;
        }

    }
}