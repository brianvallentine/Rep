using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI0078B
{
    public class SI0078B_V0HISTSINI : QueryBasis<SI0078B_V0HISTSINI>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public SI0078B_V0HISTSINI() { IsCursor = true; }

        public SI0078B_V0HISTSINI(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string V0HISTSINI_NUM_APOL_SINISTRO { get; set; }

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


        public override SI0078B_V0HISTSINI OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new SI0078B_V0HISTSINI();
            var i = 0;

            dta.V0HISTSINI_NUM_APOL_SINISTRO = result[i++].Value?.ToString();

            return dta;
        }

    }
}