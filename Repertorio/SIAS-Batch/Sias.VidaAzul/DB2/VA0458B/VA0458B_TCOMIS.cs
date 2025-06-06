using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0458B
{
    public class VA0458B_TCOMIS : QueryBasis<VA0458B_TCOMIS>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public VA0458B_TCOMIS() { IsCursor = true; }

        public VA0458B_TCOMIS(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string V0PROP_APOLICE { get; set; }
        public string V0PROP_CODSUBES { get; set; }
        public string V0PROP_NRCERTIF { get; set; }
        public string V0PROP_DTQITBCO { get; set; }
        public string V0PROP_DTQITBCO15 { get; set; }
        public string V0PROP_SITUACAO { get; set; }
        public string V0PROP_DPS_TITULAR { get; set; }
        public string VIND_DPS_TITULAR { get; set; }
        public string V0PROP_DPS_CONJUGE { get; set; }
        public string VIND_DPS_CONJUGE { get; set; }
        public string V0PROP_DTA_DECLINIO { get; set; }
        public string VIND_DTA_DECLINIO { get; set; }
        public string V0PROP_ACATAMENTO { get; set; }
        public string VIND_ACATAMENTO { get; set; }
        public string WHOST_ORIG_PRODU { get; set; }
        public string VIND_ORIG_PRODU { get; set; }
        public string V0PROP_CODPRODU { get; set; }

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


        public override VA0458B_TCOMIS OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new VA0458B_TCOMIS();
            var i = 0;

            dta.V0PROP_APOLICE = result[i++].Value?.ToString();
            dta.V0PROP_CODSUBES = result[i++].Value?.ToString();
            dta.V0PROP_NRCERTIF = result[i++].Value?.ToString();
            dta.V0PROP_DTQITBCO = result[i++].Value?.ToString();
            dta.V0PROP_DTQITBCO15 = result[i++].Value?.ToString();
            dta.V0PROP_SITUACAO = result[i++].Value?.ToString();
            dta.V0PROP_DPS_TITULAR = result[i++].Value?.ToString();
            dta.VIND_DPS_TITULAR = string.IsNullOrWhiteSpace(dta.V0PROP_DPS_TITULAR) ? "-1" : "0";
            dta.V0PROP_DPS_CONJUGE = result[i++].Value?.ToString();
            dta.VIND_DPS_CONJUGE = string.IsNullOrWhiteSpace(dta.V0PROP_DPS_CONJUGE) ? "-1" : "0";
            dta.V0PROP_DTA_DECLINIO = result[i++].Value?.ToString();
            dta.VIND_DTA_DECLINIO = string.IsNullOrWhiteSpace(dta.V0PROP_DTA_DECLINIO) ? "-1" : "0";
            dta.V0PROP_ACATAMENTO = result[i++].Value?.ToString();
            dta.VIND_ACATAMENTO = string.IsNullOrWhiteSpace(dta.V0PROP_ACATAMENTO) ? "-1" : "0";
            dta.WHOST_ORIG_PRODU = result[i++].Value?.ToString();
            dta.VIND_ORIG_PRODU = string.IsNullOrWhiteSpace(dta.WHOST_ORIG_PRODU) ? "-1" : "0";
            dta.V0PROP_CODPRODU = result[i++].Value?.ToString();

            return dta;
        }

    }
}