using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA5421B
{
    public class VA5421B_CPROPOVA : QueryBasis<VA5421B_CPROPOVA>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public VA5421B_CPROPOVA() { IsCursor = true; }

        public VA5421B_CPROPOVA(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string V0PROP_NRCERTIF { get; set; }
        public string V0PROP_CODCLIEN { get; set; }
        public string V0PROP_CODOPER { get; set; }
        public string V0PROP_SITUACAO { get; set; }
        public string V0PROP_OCORHIST { get; set; }
        public string V0PROP_NUM_MATRICULA { get; set; }
        public string V0PROP_NUM_MATRICULA_I { get; set; }
        public string V0CDGC_DTINICDG { get; set; }
        public string VIND_DTINICDG { get; set; }
        public string V0PROP_DTQITBCO { get; set; }
        public string VIND_DTQITBCO { get; set; }
        public string V0PROP_NUM_APOLICE { get; set; }
        public string V0PROP_CODSUBES { get; set; }
        public string V0SUBG_CODCLIEN { get; set; }

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


        public override VA5421B_CPROPOVA OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new VA5421B_CPROPOVA();
            var i = 0;

            dta.V0PROP_NRCERTIF = result[i++].Value?.ToString();
            dta.V0PROP_CODCLIEN = result[i++].Value?.ToString();
            dta.V0PROP_CODOPER = result[i++].Value?.ToString();
            dta.V0PROP_SITUACAO = result[i++].Value?.ToString();
            dta.V0PROP_OCORHIST = result[i++].Value?.ToString();
            dta.V0PROP_NUM_MATRICULA = result[i++].Value?.ToString();
            dta.V0PROP_NUM_MATRICULA_I = string.IsNullOrWhiteSpace(dta.V0PROP_NUM_MATRICULA) ? "-1" : "0";
            dta.V0CDGC_DTINICDG = result[i++].Value?.ToString();
            dta.VIND_DTINICDG = string.IsNullOrWhiteSpace(dta.V0CDGC_DTINICDG) ? "-1" : "0";
            dta.V0PROP_DTQITBCO = result[i++].Value?.ToString();
            dta.VIND_DTQITBCO = string.IsNullOrWhiteSpace(dta.V0PROP_DTQITBCO) ? "-1" : "0";
            dta.V0PROP_NUM_APOLICE = result[i++].Value?.ToString();
            dta.V0PROP_CODSUBES = result[i++].Value?.ToString();
            dta.V0SUBG_CODCLIEN = result[i++].Value?.ToString();

            return dta;
        }

    }
}