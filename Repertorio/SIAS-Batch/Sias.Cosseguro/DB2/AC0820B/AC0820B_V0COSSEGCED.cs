using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Cosseguro.DB2.AC0820B
{
    public class AC0820B_V0COSSEGCED : QueryBasis<AC0820B_V0COSSEGCED>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public AC0820B_V0COSSEGCED() { IsCursor = true; }

        public AC0820B_V0COSSEGCED(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string WHOST_COD_RAMO { get; set; }

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


        public override AC0820B_V0COSSEGCED OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new AC0820B_V0COSSEGCED();
            var i = 0;

            dta.WHOST_COD_RAMO = result[i++].Value?.ToString();

            return dta;
        }

    }
}