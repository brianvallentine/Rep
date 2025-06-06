using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Bilhetes.DB2.BI0031B
{
    public class BI0031B_V0PARAMC : QueryBasis<BI0031B_V0PARAMC>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public BI0031B_V0PARAMC() { IsCursor = true; }

        public BI0031B_V0PARAMC(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string V0PARAMC_TIPO_MOVTOCC { get; set; }
        public string V0PARAMC_CODPRODU { get; set; }
        public string V0PARAMC_COD_CONVENIO { get; set; }
        public string V0PARAMC_NSAS { get; set; }
        public string V0PARAMC_COD_AGENCIA_SASS { get; set; }
        public string V0PARAMC_DTPROX_DEB { get; set; }
        public string V0PARAMC_DIA_DEBITO { get; set; }

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


        public override BI0031B_V0PARAMC OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new BI0031B_V0PARAMC();
            var i = 0;

            dta.V0PARAMC_TIPO_MOVTOCC = result[i++].Value?.ToString();
            dta.V0PARAMC_CODPRODU = result[i++].Value?.ToString();
            dta.V0PARAMC_COD_CONVENIO = result[i++].Value?.ToString();
            dta.V0PARAMC_NSAS = result[i++].Value?.ToString();
            dta.V0PARAMC_COD_AGENCIA_SASS = result[i++].Value?.ToString();
            dta.V0PARAMC_DTPROX_DEB = result[i++].Value?.ToString();
            dta.V0PARAMC_DIA_DEBITO = result[i++].Value?.ToString();

            return dta;
        }

    }
}