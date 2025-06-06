using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0952B
{
    public class VA0952B_CESCNEG : QueryBasis<VA0952B_CESCNEG>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public VA0952B_CESCNEG() { IsCursor = true; }

        public VA0952B_CESCNEG(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string V0ESCN_CODESC { get; set; }
        public string V0ESCN_NOMEESC { get; set; }
        public string V0ESCN_FONTE { get; set; }

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


        public override VA0952B_CESCNEG OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new VA0952B_CESCNEG();
            var i = 0;

            dta.V0ESCN_CODESC = result[i++].Value?.ToString();
            dta.V0ESCN_NOMEESC = result[i++].Value?.ToString();
            dta.V0ESCN_FONTE = result[i++].Value?.ToString();

            return dta;
        }

    }
}