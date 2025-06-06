using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0280B
{
    public class VA0280B_V0PRODUTO : QueryBasis<VA0280B_V0PRODUTO>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public VA0280B_V0PRODUTO() { IsCursor = true; }

        public VA0280B_V0PRODUTO(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string V0PROD_CODPRODU { get; set; }

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


        public override VA0280B_V0PRODUTO OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new VA0280B_V0PRODUTO();
            var i = 0;

            dta.V0PROD_CODPRODU = result[i++].Value?.ToString();

            return dta;
        }

    }
}