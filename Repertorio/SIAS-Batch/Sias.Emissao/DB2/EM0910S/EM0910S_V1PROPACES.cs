using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Emissao.DB2.EM0910S
{
    public class EM0910S_V1PROPACES : QueryBasis<EM0910S_V1PROPACES>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public EM0910S_V1PROPACES() { IsCursor = true; }

        public EM0910S_V1PROPACES(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string V1PRAC_FONTE { get; set; }
        public string V1PRAC_NRPROPOS { get; set; }
        public string V1PRAC_NRITEM { get; set; }
        public string V1PRAC_CDACESS { get; set; }
        public string V1PRAC_VRACESS { get; set; }
        public string V1PRAC_DTINIVIG { get; set; }
        public string V1PRAC_DTTERVIG { get; set; }
        public string V1PRAC_VRPLACES { get; set; }
        public string V1PRAC_VRPAACES { get; set; }
        public string V1PRAC_VRPLAACE { get; set; }
        public string V1PRAC_VRPRBACE { get; set; }
        public string V1PRAC_TPMOVTO { get; set; }
        public string V1PRAC_TTXISACE { get; set; }
        public string V1PRAC_IDEACESS { get; set; }
        public string VIND_IDEACESS { get; set; }

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


        public override EM0910S_V1PROPACES OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new EM0910S_V1PROPACES();
            var i = 0;

            dta.V1PRAC_FONTE = result[i++].Value?.ToString();
            dta.V1PRAC_NRPROPOS = result[i++].Value?.ToString();
            dta.V1PRAC_NRITEM = result[i++].Value?.ToString();
            dta.V1PRAC_CDACESS = result[i++].Value?.ToString();
            dta.V1PRAC_VRACESS = result[i++].Value?.ToString();
            dta.V1PRAC_DTINIVIG = result[i++].Value?.ToString();
            dta.V1PRAC_DTTERVIG = result[i++].Value?.ToString();
            dta.V1PRAC_VRPLACES = result[i++].Value?.ToString();
            dta.V1PRAC_VRPAACES = result[i++].Value?.ToString();
            dta.V1PRAC_VRPLAACE = result[i++].Value?.ToString();
            dta.V1PRAC_VRPRBACE = result[i++].Value?.ToString();
            dta.V1PRAC_TPMOVTO = result[i++].Value?.ToString();
            dta.V1PRAC_TTXISACE = result[i++].Value?.ToString();
            dta.V1PRAC_IDEACESS = result[i++].Value?.ToString();
            dta.VIND_IDEACESS = string.IsNullOrWhiteSpace(dta.V1PRAC_IDEACESS) ? "-1" : "0";

            return dta;
        }

    }
}