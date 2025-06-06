using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA1815B
{
    public class VA1815B_CHCONTA3 : QueryBasis<VA1815B_CHCONTA3>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public VA1815B_CHCONTA3() { IsCursor = true; }

        public VA1815B_CHCONTA3(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string V0HCTA_NRCERTIF { get; set; }
        public string V0HCTA_NRPARCEL { get; set; }
        public string V0HCTA_OCORHISTCTA { get; set; }
        public string V0HCTA_TIPLANC { get; set; }

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


        public override VA1815B_CHCONTA3 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new VA1815B_CHCONTA3();
            var i = 0;

            dta.V0HCTA_NRCERTIF = result[i++].Value?.ToString();
            dta.V0HCTA_NRPARCEL = result[i++].Value?.ToString();
            dta.V0HCTA_OCORHISTCTA = result[i++].Value?.ToString();
            dta.V0HCTA_TIPLANC = result[i++].Value?.ToString();

            return dta;
        }

    }
}