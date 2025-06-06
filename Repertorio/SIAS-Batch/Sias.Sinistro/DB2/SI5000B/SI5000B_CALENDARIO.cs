using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI5000B
{
    public class SI5000B_CALENDARIO : QueryBasis<SI5000B_CALENDARIO>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public SI5000B_CALENDARIO() { IsCursor = true; }

        public SI5000B_CALENDARIO(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string CALENDAR_DATA_CALENDARIO { get; set; }
        public string CALENDAR_DIA_SEMANA { get; set; }
        public string CALENDAR_FERIADO { get; set; }

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


        public override SI5000B_CALENDARIO OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new SI5000B_CALENDARIO();
            var i = 0;

            dta.CALENDAR_DATA_CALENDARIO = result[i++].Value?.ToString();
            dta.CALENDAR_DIA_SEMANA = result[i++].Value?.ToString();
            dta.CALENDAR_FERIADO = result[i++].Value?.ToString();

            return dta;
        }

    }
}