using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI0120B
{
    public class SI0120B_V1RELATSINI : QueryBasis<SI0120B_V1RELATSINI>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public SI0120B_V1RELATSINI() { IsCursor = true; }

        public SI0120B_V1RELATSINI(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string RELATO_DTINIVIG { get; set; }
        public string RELATO_DTTERVIG { get; set; }
        public string RELATO_FONTE { get; set; }

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


        public override SI0120B_V1RELATSINI OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new SI0120B_V1RELATSINI();
            var i = 0;

            dta.RELATO_DTINIVIG = result[i++].Value?.ToString();
            dta.RELATO_DTTERVIG = result[i++].Value?.ToString();
            dta.RELATO_FONTE = result[i++].Value?.ToString();

            return dta;
        }

    }
}