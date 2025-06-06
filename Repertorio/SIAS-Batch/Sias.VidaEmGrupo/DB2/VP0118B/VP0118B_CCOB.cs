using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VP0118B
{
    public class VP0118B_CCOB : QueryBasis<VP0118B_CCOB>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public VP0118B_CCOB() { IsCursor = true; }

        public VP0118B_CCOB(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string HOST_IMPSEGCDC { get; set; }
        public string HOST_IMPMORNATU { get; set; }
        public string HOST_OCORHIST { get; set; }
        public string HOST_DTINIVIG { get; set; }
        public string HOST_DTTERVIG { get; set; }
        public string HOST_VLCUSTCDG { get; set; }
        public string HOST_DTINIVIG_1DAY { get; set; }

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


        public override VP0118B_CCOB OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new VP0118B_CCOB();
            var i = 0;

            dta.HOST_IMPSEGCDC = result[i++].Value?.ToString();
            dta.HOST_IMPMORNATU = result[i++].Value?.ToString();
            dta.HOST_OCORHIST = result[i++].Value?.ToString();
            dta.HOST_DTINIVIG = result[i++].Value?.ToString();
            dta.HOST_DTTERVIG = result[i++].Value?.ToString();
            dta.HOST_VLCUSTCDG = result[i++].Value?.ToString();
            dta.HOST_DTINIVIG_1DAY = result[i++].Value?.ToString();

            return dta;
        }

    }
}