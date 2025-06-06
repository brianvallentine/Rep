using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI0112B
{
    public class SI0112B_TAPOCOS : QueryBasis<SI0112B_TAPOCOS>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public SI0112B_TAPOCOS() { IsCursor = true; }

        public SI0112B_TAPOCOS(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string APCOSSC_PCPARTIC { get; set; }
        public string APCOSSC_DTINIVIG { get; set; }

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


        public override SI0112B_TAPOCOS OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new SI0112B_TAPOCOS();
            var i = 0;

            dta.APCOSSC_PCPARTIC = result[i++].Value?.ToString();
            dta.APCOSSC_DTINIVIG = result[i++].Value?.ToString();

            return dta;
        }

    }
}