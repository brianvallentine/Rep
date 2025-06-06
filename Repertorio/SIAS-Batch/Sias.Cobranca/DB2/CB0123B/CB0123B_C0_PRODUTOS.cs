using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Cobranca.DB2.CB0123B
{
    public class CB0123B_C0_PRODUTOS : QueryBasis<CB0123B_C0_PRODUTOS>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public CB0123B_C0_PRODUTOS() { IsCursor = true; }

        public CB0123B_C0_PRODUTOS(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string PRODUTO_COD_PRODUTO { get; set; }

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


        public override CB0123B_C0_PRODUTOS OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new CB0123B_C0_PRODUTOS();
            var i = 0;

            dta.PRODUTO_COD_PRODUTO = result[i++].Value?.ToString();

            return dta;
        }

    }
}