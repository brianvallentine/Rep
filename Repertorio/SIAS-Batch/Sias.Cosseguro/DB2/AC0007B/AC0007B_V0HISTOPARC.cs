using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Cosseguro.DB2.AC0007B
{
    public class AC0007B_V0HISTOPARC : QueryBasis<AC0007B_V0HISTOPARC>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public AC0007B_V0HISTOPARC() { IsCursor = true; }

        public AC0007B_V0HISTOPARC(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string V0HISP_NUM_APOL { get; set; }
        public string V0HISP_NRENDOS { get; set; }
        public string V0HISP_NRPARCEL { get; set; }
        public string V0HISP_OCORHIST { get; set; }
        public string V0HISP_PRM_TAR { get; set; }
        public string V0APOL_RAMO { get; set; }
        public string V0APOL_MODALIDA { get; set; }
        public string V0APOL_CODPRODU { get; set; }
        public string V0APOL_COD_EMPR { get; set; }

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


        public override AC0007B_V0HISTOPARC OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new AC0007B_V0HISTOPARC();
            var i = 0;

            dta.V0HISP_NUM_APOL = result[i++].Value?.ToString();
            dta.V0HISP_NRENDOS = result[i++].Value?.ToString();
            dta.V0HISP_NRPARCEL = result[i++].Value?.ToString();
            dta.V0HISP_OCORHIST = result[i++].Value?.ToString();
            dta.V0HISP_PRM_TAR = result[i++].Value?.ToString();
            dta.V0APOL_RAMO = result[i++].Value?.ToString();
            dta.V0APOL_MODALIDA = result[i++].Value?.ToString();
            dta.V0APOL_CODPRODU = result[i++].Value?.ToString();
            dta.V0APOL_COD_EMPR = result[i++].Value?.ToString();

            return dta;
        }

    }
}