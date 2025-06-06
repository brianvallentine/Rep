using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Bilhetes.DB2.BI8173B
{
    public class BI8173B_CPROPOSTA_TOT : QueryBasis<BI8173B_CPROPOSTA_TOT>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public BI8173B_CPROPOSTA_TOT() { IsCursor = true; }

        public BI8173B_CPROPOSTA_TOT(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string WS_REG_MES_TOT { get; set; }
        public string WS_REG_ANO_TOT { get; set; }
        public string WS_VALOR_RCAP { get; set; }
        public string WS_QUANT_PROP { get; set; }

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


        public override BI8173B_CPROPOSTA_TOT OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new BI8173B_CPROPOSTA_TOT();
            var i = 0;

            dta.WS_REG_MES_TOT = result[i++].Value?.ToString();
            dta.WS_REG_ANO_TOT = result[i++].Value?.ToString();
            dta.WS_VALOR_RCAP = result[i++].Value?.ToString();
            dta.WS_QUANT_PROP = result[i++].Value?.ToString();

            return dta;
        }

    }
}