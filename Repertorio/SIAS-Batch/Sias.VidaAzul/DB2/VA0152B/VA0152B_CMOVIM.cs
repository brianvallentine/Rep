using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0152B
{
    public class VA0152B_CMOVIM : QueryBasis<VA0152B_CMOVIM>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public VA0152B_CMOVIM() { IsCursor = true; }

        public VA0152B_CMOVIM(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string NRCERTIF { get; set; }
        public string DTMOVTO { get; set; }

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


        public override VA0152B_CMOVIM OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new VA0152B_CMOVIM();
            var i = 0;

            dta.NRCERTIF = result[i++].Value?.ToString();
            dta.DTMOVTO = result[i++].Value?.ToString();

            return dta;
        }

    }
}