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
    public class EM0006B_V1PROPDESINC : QueryBasis<EM0006B_V1PROPDESINC>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public EM0006B_V1PROPDESINC() { IsCursor = true; }

        public EM0006B_V1PROPDESINC(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string V1PRDI_COD_EMPRESA { get; set; }
        public string V1PRDI_FONTE { get; set; }
        public string V1PRDI_NRPROPOS { get; set; }
        public string V1PRDI_NUM_RISCO { get; set; }
        public string V1PRDI_NRITEM { get; set; }
        public string V1PRDI_COD_PLANTA { get; set; }
        public string V1PRDI_NRLINHA { get; set; }
        public string V1PRDI_DESC_LINHA { get; set; }

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


        public override EM0006B_V1PROPDESINC OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new EM0006B_V1PROPDESINC();
            var i = 0;

            dta.V1PRDI_COD_EMPRESA = result[i++].Value?.ToString();
            dta.V1PRDI_FONTE = result[i++].Value?.ToString();
            dta.V1PRDI_NRPROPOS = result[i++].Value?.ToString();
            dta.V1PRDI_NUM_RISCO = result[i++].Value?.ToString();
            dta.V1PRDI_NRITEM = result[i++].Value?.ToString();
            dta.V1PRDI_COD_PLANTA = result[i++].Value?.ToString();
            dta.V1PRDI_NRLINHA = result[i++].Value?.ToString();
            dta.V1PRDI_DESC_LINHA = result[i++].Value?.ToString();

            return dta;
        }

    }
}