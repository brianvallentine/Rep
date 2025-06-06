using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI0108B
{
    public class SI0108B_RELSIN : QueryBasis<SI0108B_RELSIN>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public SI0108B_RELSIN() { IsCursor = true; }

        public SI0108B_RELSIN(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string RELSIN_DTINIVIG { get; set; }
        public string RELSIN_DTTERVIG { get; set; }

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


        public override SI0108B_RELSIN OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new SI0108B_RELSIN();
            var i = 0;

            dta.RELSIN_DTINIVIG = result[i++].Value?.ToString();
            dta.RELSIN_DTTERVIG = result[i++].Value?.ToString();

            return dta;
        }

    }
}