using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI0101B
{
    public class SI0101B_TMESTSIN1 : QueryBasis<SI0101B_TMESTSIN1>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public SI0101B_TMESTSIN1() { IsCursor = true; }

        public SI0101B_TMESTSIN1(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string MEST_APOL_SINI { get; set; }
        public string MEST_DATCMD { get; set; }
        public string MEST_DATORR { get; set; }
        public string MEST_FONTE { get; set; }
        public string MEST_CODSUBES { get; set; }
        public string THIST_DTMOVTO1 { get; set; }
        public string THIST_VALPRI1 { get; set; }
        public string MEST_MOEDA_SIN { get; set; }
        public string MEST_RAMO { get; set; }
        public string MEST_CODCAU { get; set; }

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


        public override SI0101B_TMESTSIN1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new SI0101B_TMESTSIN1();
            var i = 0;

            dta.MEST_APOL_SINI = result[i++].Value?.ToString();
            dta.MEST_DATCMD = result[i++].Value?.ToString();
            dta.MEST_DATORR = result[i++].Value?.ToString();
            dta.MEST_FONTE = result[i++].Value?.ToString();
            dta.MEST_CODSUBES = result[i++].Value?.ToString();
            dta.THIST_DTMOVTO1 = result[i++].Value?.ToString();
            dta.THIST_VALPRI1 = result[i++].Value?.ToString();
            dta.MEST_MOEDA_SIN = result[i++].Value?.ToString();
            dta.MEST_RAMO = result[i++].Value?.ToString();
            dta.MEST_CODCAU = result[i++].Value?.ToString();

            return dta;
        }

    }
}