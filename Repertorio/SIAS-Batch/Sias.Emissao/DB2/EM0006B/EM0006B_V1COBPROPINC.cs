using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Emissao.DB2.EM0006B
{
    public class EM0006B_V1COBPROPINC : QueryBasis<EM0006B_V1COBPROPINC>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public EM0006B_V1COBPROPINC() { IsCursor = true; }

        public EM0006B_V1COBPROPINC(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string V1COBP_COD_EMPRESA { get; set; }
        public string V1COBP_FONTE { get; set; }
        public string V1COBP_NRPROPOS { get; set; }
        public string V1COBP_NUM_RISCO { get; set; }
        public string V1COBP_SUBRIS { get; set; }
        public string V1COBP_NRITEM { get; set; }
        public string V1COBP_CODCOBINC { get; set; }
        public string V1COBP_IMP_SEG_IX { get; set; }
        public string V1COBP_TIPCOBINC { get; set; }
        public string V1COBP_PRM_TAR_IX { get; set; }

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


        public override EM0006B_V1COBPROPINC OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new EM0006B_V1COBPROPINC();
            var i = 0;

            dta.V1COBP_COD_EMPRESA = result[i++].Value?.ToString();
            dta.V1COBP_FONTE = result[i++].Value?.ToString();
            dta.V1COBP_NRPROPOS = result[i++].Value?.ToString();
            dta.V1COBP_NUM_RISCO = result[i++].Value?.ToString();
            dta.V1COBP_SUBRIS = result[i++].Value?.ToString();
            dta.V1COBP_NRITEM = result[i++].Value?.ToString();
            dta.V1COBP_CODCOBINC = result[i++].Value?.ToString();
            dta.V1COBP_IMP_SEG_IX = result[i++].Value?.ToString();
            dta.V1COBP_TIPCOBINC = result[i++].Value?.ToString();
            dta.V1COBP_PRM_TAR_IX = result[i++].Value?.ToString();

            return dta;
        }

    }
}