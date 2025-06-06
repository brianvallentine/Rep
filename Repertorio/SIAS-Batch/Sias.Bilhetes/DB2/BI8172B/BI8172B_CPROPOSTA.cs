using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Bilhetes.DB2.BI8172B
{
    public class BI8172B_CPROPOSTA : QueryBasis<BI8172B_CPROPOSTA>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public BI8172B_CPROPOSTA() { IsCursor = true; }

        public BI8172B_CPROPOSTA(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string WS_COD_PRODUTO { get; set; }
        public string WS_REG_DET_EXTRATO { get; set; }

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


        public override BI8172B_CPROPOSTA OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new BI8172B_CPROPOSTA();
            var i = 0;

            dta.WS_COD_PRODUTO = result[i++].Value?.ToString();
            dta.WS_REG_DET_EXTRATO = result[i++].Value?.ToString();

            return dta;
        }

    }
}