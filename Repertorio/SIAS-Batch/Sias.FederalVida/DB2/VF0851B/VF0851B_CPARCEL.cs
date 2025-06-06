using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.FederalVida.DB2.VF0851B
{
    public class VF0851B_CPARCEL : QueryBasis<VF0851B_CPARCEL>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public VF0851B_CPARCEL() { IsCursor = true; }

        public VF0851B_CPARCEL(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string V0PARC_NRPARCEL { get; set; }
        public string V0PARC_PRMVG { get; set; }
        public string V0PARC_PRMAP { get; set; }
        public string V0PARC_VLPRMTOT { get; set; }
        public string V0PARC_OCORHIST { get; set; }
        public string V0PARC_DTPROXVEN { get; set; }
        public string V0PARC_DTVENCTO { get; set; }

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


        public override VF0851B_CPARCEL OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new VF0851B_CPARCEL();
            var i = 0;

            dta.V0PARC_NRPARCEL = result[i++].Value?.ToString();
            dta.V0PARC_PRMVG = result[i++].Value?.ToString();
            dta.V0PARC_PRMAP = result[i++].Value?.ToString();
            dta.V0PARC_VLPRMTOT = result[i++].Value?.ToString();
            dta.V0PARC_OCORHIST = result[i++].Value?.ToString();
            dta.V0PARC_DTPROXVEN = result[i++].Value?.ToString();
            dta.V0PARC_DTVENCTO = result[i++].Value?.ToString();

            return dta;
        }

    }
}