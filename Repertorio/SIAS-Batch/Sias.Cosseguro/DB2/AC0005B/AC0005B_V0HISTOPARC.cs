using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Cosseguro.DB2.AC0005B
{
    public class AC0005B_V0HISTOPARC : QueryBasis<AC0005B_V0HISTOPARC>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public AC0005B_V0HISTOPARC() { IsCursor = true; }

        public AC0005B_V0HISTOPARC(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string V0HISP_NUM_APOL { get; set; }
        public string V0HISP_NRENDOS { get; set; }
        public string V0HISP_NRPARCEL { get; set; }
        public string V0HISP_OCORHIST { get; set; }
        public string V0HISP_OPERACAO { get; set; }
        public string V0HISP_DTMOVTO { get; set; }
        public string V0HISP_PRM_TAR { get; set; }
        public string V0HISP_VAL_DESC { get; set; }
        public string V0HISP_VLPRMLIQ { get; set; }
        public string V0HISP_VLADIFRA { get; set; }
        public string V0HISP_VLCUSEMI { get; set; }
        public string V0HISP_VLIOCC { get; set; }
        public string V0HISP_VLPRMTOT { get; set; }
        public string V0HISP_VLPREMIO { get; set; }
        public string V0HISP_DTVENCTO { get; set; }
        public string V0HISP_BCOCOBR { get; set; }
        public string V0HISP_AGECOBR { get; set; }
        public string V0HISP_NRAVISO { get; set; }
        public string V0HISP_NRENDOCA { get; set; }
        public string V0HISP_DTQITBCO { get; set; }
        public string VIND_DAT_QTBC { get; set; }

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


        public override AC0005B_V0HISTOPARC OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new AC0005B_V0HISTOPARC();
            var i = 0;

            dta.V0HISP_NUM_APOL = result[i++].Value?.ToString();
            dta.V0HISP_NRENDOS = result[i++].Value?.ToString();
            dta.V0HISP_NRPARCEL = result[i++].Value?.ToString();
            dta.V0HISP_OCORHIST = result[i++].Value?.ToString();
            dta.V0HISP_OPERACAO = result[i++].Value?.ToString();
            dta.V0HISP_DTMOVTO = result[i++].Value?.ToString();
            dta.V0HISP_PRM_TAR = result[i++].Value?.ToString();
            dta.V0HISP_VAL_DESC = result[i++].Value?.ToString();
            dta.V0HISP_VLPRMLIQ = result[i++].Value?.ToString();
            dta.V0HISP_VLADIFRA = result[i++].Value?.ToString();
            dta.V0HISP_VLCUSEMI = result[i++].Value?.ToString();
            dta.V0HISP_VLIOCC = result[i++].Value?.ToString();
            dta.V0HISP_VLPRMTOT = result[i++].Value?.ToString();
            dta.V0HISP_VLPREMIO = result[i++].Value?.ToString();
            dta.V0HISP_DTVENCTO = result[i++].Value?.ToString();
            dta.V0HISP_BCOCOBR = result[i++].Value?.ToString();
            dta.V0HISP_AGECOBR = result[i++].Value?.ToString();
            dta.V0HISP_NRAVISO = result[i++].Value?.ToString();
            dta.V0HISP_NRENDOCA = result[i++].Value?.ToString();
            dta.V0HISP_DTQITBCO = result[i++].Value?.ToString();
            dta.VIND_DAT_QTBC = string.IsNullOrWhiteSpace(dta.V0HISP_DTQITBCO) ? "-1" : "0";

            return dta;
        }

    }
}