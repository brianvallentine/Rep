using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0850B
{
    public class VA0850B_CHISTCB : QueryBasis<VA0850B_CHISTCB>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public VA0850B_CHISTCB() { IsCursor = true; }

        public VA0850B_CHISTCB(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string V0HCOB_NRCERTIF { get; set; }
        public string V0HCOB_COUNT { get; set; }

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


        public override VA0850B_CHISTCB OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new VA0850B_CHISTCB();
            var i = 0;

            dta.V0HCOB_NRCERTIF = result[i++].Value?.ToString();
            dta.V0HCOB_COUNT = result[i++].Value?.ToString();

            return dta;
        }

    }
}