using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Cosseguro.DB2.AC0011B
{
    public class AC0011B_V2HISTOPARC : QueryBasis<AC0011B_V2HISTOPARC>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public AC0011B_V2HISTOPARC() { IsCursor = true; }

        public AC0011B_V2HISTOPARC(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string V2HISP_NUM_APOL { get; set; }
        public string V2HISP_NRENDOS { get; set; }
        public string V2HISP_NRPARCEL { get; set; }
        public string V2HISP_OCORHIST { get; set; }
        public string V2HISP_OPERACAO { get; set; }
        public string V2HISP_DTMOVTO { get; set; }
        public string V2HISP_PRM_TAR { get; set; }
        public string V2HISP_VAL_DES { get; set; }
        public string V2HISP_VLADIFRA { get; set; }
        public string V2HISP_VLCUSEMI { get; set; }
        public string V2HISP_DTQITBCO { get; set; }
        public string VIND_DTQITBCO { get; set; }
        public string V2PARC_PRM_TAR { get; set; }
        public string V2PARC_VAL_DES { get; set; }
        public string V2PARC_OTNADFRA { get; set; }
        public string V2PARC_OTNCUSTO { get; set; }

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


        public override AC0011B_V2HISTOPARC OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new AC0011B_V2HISTOPARC();
            var i = 0;

            dta.V2HISP_NUM_APOL = result[i++].Value?.ToString();
            dta.V2HISP_NRENDOS = result[i++].Value?.ToString();
            dta.V2HISP_NRPARCEL = result[i++].Value?.ToString();
            dta.V2HISP_OCORHIST = result[i++].Value?.ToString();
            dta.V2HISP_OPERACAO = result[i++].Value?.ToString();
            dta.V2HISP_DTMOVTO = result[i++].Value?.ToString();
            dta.V2HISP_PRM_TAR = result[i++].Value?.ToString();
            dta.V2HISP_VAL_DES = result[i++].Value?.ToString();
            dta.V2HISP_VLADIFRA = result[i++].Value?.ToString();
            dta.V2HISP_VLCUSEMI = result[i++].Value?.ToString();
            dta.V2HISP_DTQITBCO = result[i++].Value?.ToString();
            dta.VIND_DTQITBCO = string.IsNullOrWhiteSpace(dta.V2HISP_DTQITBCO) ? "-1" : "0";
            dta.V2PARC_PRM_TAR = result[i++].Value?.ToString();
            dta.V2PARC_VAL_DES = result[i++].Value?.ToString();
            dta.V2PARC_OTNADFRA = result[i++].Value?.ToString();
            dta.V2PARC_OTNCUSTO = result[i++].Value?.ToString();

            return dta;
        }

    }
}