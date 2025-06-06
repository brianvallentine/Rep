using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Cosseguro.DB2.AC0815B
{
    public class AC0815B_V0COSCEDCHEQUE : QueryBasis<AC0815B_V0COSCEDCHEQUE>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public AC0815B_V0COSCEDCHEQUE() { IsCursor = true; }

        public AC0815B_V0COSCEDCHEQUE(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string V1CCHQ_CONGENER { get; set; }
        public string V1CCHQ_DTLIBERA { get; set; }

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


        public override AC0815B_V0COSCEDCHEQUE OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new AC0815B_V0COSCEDCHEQUE();
            var i = 0;

            dta.V1CCHQ_CONGENER = result[i++].Value?.ToString();
            dta.V1CCHQ_DTLIBERA = result[i++].Value?.ToString();

            return dta;
        }

    }
}