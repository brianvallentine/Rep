using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA5437B
{
    public class VA5437B_CTITFEDCA : QueryBasis<VA5437B_CTITFEDCA>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public VA5437B_CTITFEDCA() { IsCursor = true; }

        public VA5437B_CTITFEDCA(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string TITFEDCA_NRTITFDCAP { get; set; }
        public string TITFEDCA_NRSORTEIO { get; set; }

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


        public override VA5437B_CTITFEDCA OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new VA5437B_CTITFEDCA();
            var i = 0;

            dta.TITFEDCA_NRTITFDCAP = result[i++].Value?.ToString();
            dta.TITFEDCA_NRSORTEIO = result[i++].Value?.ToString();

            return dta;
        }

    }
}