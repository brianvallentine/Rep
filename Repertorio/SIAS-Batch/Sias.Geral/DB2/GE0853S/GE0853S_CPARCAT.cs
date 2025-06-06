using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Geral.DB2.GE0853S
{
    public class GE0853S_CPARCAT : QueryBasis<GE0853S_CPARCAT>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public GE0853S_CPARCAT() { IsCursor = true; }

        public GE0853S_CPARCAT(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string WS_NUM_PARC_AT { get; set; }
        public string WS_NUM_TITULO_AT { get; set; }

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


        public override GE0853S_CPARCAT OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new GE0853S_CPARCAT();
            var i = 0;

            dta.WS_NUM_PARC_AT = result[i++].Value?.ToString();
            dta.WS_NUM_TITULO_AT = result[i++].Value?.ToString();

            return dta;
        }

    }
}