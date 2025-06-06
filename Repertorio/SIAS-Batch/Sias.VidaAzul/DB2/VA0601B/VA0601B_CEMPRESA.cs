using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0601B
{
    public class VA0601B_CEMPRESA : QueryBasis<VA0601B_CEMPRESA>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public VA0601B_CEMPRESA() { IsCursor = true; }

        public VA0601B_CEMPRESA(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string WHOST_COD_CLIENTE { get; set; }

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


        public override VA0601B_CEMPRESA OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new VA0601B_CEMPRESA();
            var i = 0;

            dta.WHOST_COD_CLIENTE = result[i++].Value?.ToString();

            return dta;
        }

    }
}