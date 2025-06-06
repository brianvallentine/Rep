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
    public class AC0011B_V1HISTOPARC : QueryBasis<AC0011B_V1HISTOPARC>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public AC0011B_V1HISTOPARC() { IsCursor = true; }

        public AC0011B_V1HISTOPARC(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string V1HISP_NUM_APOL { get; set; }
        public string V1HISP_NRENDOS { get; set; }
        public string V1HISP_NRPARCEL { get; set; }
        public string V1HISP_OCORHIST { get; set; }
        public string V1HISP_OPERACAO { get; set; }
        public string V1HISP_DTMOVTO { get; set; }
        public string V1HISP_PRM_TAR { get; set; }
        public string V1HISP_VAL_DES { get; set; }
        public string V1HISP_VLADIFRA { get; set; }
        public string V1HISP_VLCUSEMI { get; set; }
        public string V1HISP_DTQITBCO { get; set; }
        public string VIND_DAT_QTBC { get; set; }
        public string V0APOL_ORGAO { get; set; }
        public string V0APOL_RAMO { get; set; }
        public string V0APOL_CODPRODU { get; set; }

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


        public override AC0011B_V1HISTOPARC OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new AC0011B_V1HISTOPARC();
            var i = 0;

            dta.V1HISP_NUM_APOL = result[i++].Value?.ToString();
            dta.V1HISP_NRENDOS = result[i++].Value?.ToString();
            dta.V1HISP_NRPARCEL = result[i++].Value?.ToString();
            dta.V1HISP_OCORHIST = result[i++].Value?.ToString();
            dta.V1HISP_OPERACAO = result[i++].Value?.ToString();
            dta.V1HISP_DTMOVTO = result[i++].Value?.ToString();
            dta.V1HISP_PRM_TAR = result[i++].Value?.ToString();
            dta.V1HISP_VAL_DES = result[i++].Value?.ToString();
            dta.V1HISP_VLADIFRA = result[i++].Value?.ToString();
            dta.V1HISP_VLCUSEMI = result[i++].Value?.ToString();
            dta.V1HISP_DTQITBCO = result[i++].Value?.ToString();
            dta.VIND_DAT_QTBC = string.IsNullOrWhiteSpace(dta.V1HISP_DTQITBCO) ? "-1" : "0";
            dta.V0APOL_ORGAO = result[i++].Value?.ToString();
            dta.V0APOL_RAMO = result[i++].Value?.ToString();
            dta.V0APOL_CODPRODU = result[i++].Value?.ToString();

            return dta;
        }

    }
}