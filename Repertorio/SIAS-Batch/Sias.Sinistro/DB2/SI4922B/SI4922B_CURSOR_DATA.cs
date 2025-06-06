using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI4922B
{
    public class SI4922B_CURSOR_DATA : QueryBasis<SI4922B_CURSOR_DATA>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public SI4922B_CURSOR_DATA() { IsCursor = true; }

        public SI4922B_CURSOR_DATA(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string CALENDAR_DATA_CALENDARIO { get; set; }

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


        public override SI4922B_CURSOR_DATA OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new SI4922B_CURSOR_DATA();
            var i = 0;

            dta.CALENDAR_DATA_CALENDARIO = result[i++].Value?.ToString();

            return dta;
        }

    }
}