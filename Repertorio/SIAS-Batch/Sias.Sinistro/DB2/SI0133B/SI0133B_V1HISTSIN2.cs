using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI0133B
{
    public class SI0133B_V1HISTSIN2 : QueryBasis<SI0133B_V1HISTSIN2>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public SI0133B_V1HISTSIN2() { IsCursor = true; }

        public SI0133B_V1HISTSIN2(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string THIST_VALPRI4 { get; set; }
        public string THIST_DTMOVTO2 { get; set; }
        public string THIST_OPERACAO2 { get; set; }
        public string THIST_OCORHIST2 { get; set; }
        public string THIST_TIMESTAMP { get; set; }

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


        public override SI0133B_V1HISTSIN2 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new SI0133B_V1HISTSIN2();
            var i = 0;

            dta.THIST_VALPRI4 = result[i++].Value?.ToString();
            dta.THIST_DTMOVTO2 = result[i++].Value?.ToString();
            dta.THIST_OPERACAO2 = result[i++].Value?.ToString();
            dta.THIST_OCORHIST2 = result[i++].Value?.ToString();
            dta.THIST_TIMESTAMP = result[i++].Value?.ToString();

            return dta;
        }

    }
}