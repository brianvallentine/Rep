using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Outros.DB2.PR0011B
{
    public class PR0011B_V1ACOMPROP : QueryBasis<PR0011B_V1ACOMPROP>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public PR0011B_V1ACOMPROP() { IsCursor = true; }

        public PR0011B_V1ACOMPROP(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string V1ACOMPR_FONTE { get; set; }
        public string V1ACOMPR_NRPROPOS { get; set; }

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


        public override PR0011B_V1ACOMPROP OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new PR0011B_V1ACOMPROP();
            var i = 0;

            dta.V1ACOMPR_FONTE = result[i++].Value?.ToString();
            dta.V1ACOMPR_NRPROPOS = result[i++].Value?.ToString();

            return dta;
        }

    }
}