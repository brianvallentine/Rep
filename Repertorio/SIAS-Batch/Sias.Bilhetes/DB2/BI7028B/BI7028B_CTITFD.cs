using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Bilhetes.DB2.BI7028B
{
    public class BI7028B_CTITFD : QueryBasis<BI7028B_CTITFD>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public BI7028B_CTITFD() { IsCursor = true; }

        public BI7028B_CTITFD(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string V0TITF_NRSORTEIO { get; set; }

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


        public override BI7028B_CTITFD OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new BI7028B_CTITFD();
            var i = 0;

            dta.V0TITF_NRSORTEIO = result[i++].Value?.ToString();

            return dta;
        }

    }
}