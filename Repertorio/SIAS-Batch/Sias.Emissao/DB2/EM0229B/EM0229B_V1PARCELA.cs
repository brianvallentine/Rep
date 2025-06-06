using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Emissao.DB2.EM0229B
{
    public class EM0229B_V1PARCELA : QueryBasis<EM0229B_V1PARCELA>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public EM0229B_V1PARCELA() { IsCursor = true; }

        public EM0229B_V1PARCELA(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string V0PARC_NRTIT { get; set; }
        public string V0PARC_NRPARCEL { get; set; }
        public string V0PARC_DTVENCTO { get; set; }
        public string V0PARC_OTNTOTAL { get; set; }
        public string V0PARC_VLPRMTOT { get; set; }

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


        public override EM0229B_V1PARCELA OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new EM0229B_V1PARCELA();
            var i = 0;

            dta.V0PARC_NRTIT = result[i++].Value?.ToString();
            dta.V0PARC_NRPARCEL = result[i++].Value?.ToString();
            dta.V0PARC_DTVENCTO = result[i++].Value?.ToString();
            dta.V0PARC_OTNTOTAL = result[i++].Value?.ToString();
            dta.V0PARC_VLPRMTOT = result[i++].Value?.ToString();

            return dta;
        }

    }
}