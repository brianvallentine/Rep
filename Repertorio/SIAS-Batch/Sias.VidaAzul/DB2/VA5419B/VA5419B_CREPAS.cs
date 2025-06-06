using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA5419B
{
    public class VA5419B_CREPAS : QueryBasis<VA5419B_CREPAS>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public VA5419B_CREPAS() { IsCursor = true; }

        public VA5419B_CREPAS(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string V0RSAF_NUM_APOLICE { get; set; }
        public string V0RSAF_CODSUBES { get; set; }
        public string V0RSAF_DTQITBCO { get; set; }
        public string V0RSAF_CODCLIEN_SUB { get; set; }
        public string V0RSAF_CODCLIEN { get; set; }
        public string V0RSAF_DTREF { get; set; }
        public string V0RSAF_NRCERTIF { get; set; }
        public string V0RSAF_NRPARCEL { get; set; }
        public string V0RSAF_NRMATRFUN { get; set; }
        public string V0RSAF_VLCUSTAUXF { get; set; }
        public string V0RSAF_CODOPER { get; set; }
        public string V0RSAF_DTMOVTO { get; set; }
        public string VIND_DTMOVTO { get; set; }

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


        public override VA5419B_CREPAS OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new VA5419B_CREPAS();
            var i = 0;

            dta.V0RSAF_NUM_APOLICE = result[i++].Value?.ToString();
            dta.V0RSAF_CODSUBES = result[i++].Value?.ToString();
            dta.V0RSAF_DTQITBCO = result[i++].Value?.ToString();
            dta.V0RSAF_CODCLIEN_SUB = result[i++].Value?.ToString();
            dta.V0RSAF_CODCLIEN = result[i++].Value?.ToString();
            dta.V0RSAF_DTREF = result[i++].Value?.ToString();
            dta.V0RSAF_NRCERTIF = result[i++].Value?.ToString();
            dta.V0RSAF_NRPARCEL = result[i++].Value?.ToString();
            dta.V0RSAF_NRMATRFUN = result[i++].Value?.ToString();
            dta.V0RSAF_VLCUSTAUXF = result[i++].Value?.ToString();
            dta.V0RSAF_CODOPER = result[i++].Value?.ToString();
            dta.V0RSAF_DTMOVTO = result[i++].Value?.ToString();
            dta.VIND_DTMOVTO = string.IsNullOrWhiteSpace(dta.V0RSAF_DTMOVTO) ? "-1" : "0";

            return dta;
        }

    }
}