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
    public class EM0910S_V1COBERPROP : QueryBasis<EM0910S_V1COBERPROP>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public EM0910S_V1COBERPROP() { IsCursor = true; }

        public EM0910S_V1COBERPROP(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string V1COBP_FONTE { get; set; }
        public string V1COBP_NRPROPOS { get; set; }
        public string V1COBP_NUM_ITEM { get; set; }
        public string V1COBP_RAMOFR { get; set; }
        public string V1COBP_MODALIFR { get; set; }
        public string V1COBP_COD_COBER { get; set; }
        public string V1COBP_IMP_SEG_IX { get; set; }
        public string V1COBP_IMP_SEG_VR { get; set; }
        public string V1COBP_PRM_TAR_IX { get; set; }
        public string V1COBP_PRM_TAR_VR { get; set; }
        public string V1COBP_DAT_INIVIG { get; set; }
        public string V1COBP_DAT_TERVIG { get; set; }

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


        public override EM0910S_V1COBERPROP OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new EM0910S_V1COBERPROP();
            var i = 0;

            dta.V1COBP_FONTE = result[i++].Value?.ToString();
            dta.V1COBP_NRPROPOS = result[i++].Value?.ToString();
            dta.V1COBP_NUM_ITEM = result[i++].Value?.ToString();
            dta.V1COBP_RAMOFR = result[i++].Value?.ToString();
            dta.V1COBP_MODALIFR = result[i++].Value?.ToString();
            dta.V1COBP_COD_COBER = result[i++].Value?.ToString();
            dta.V1COBP_IMP_SEG_IX = result[i++].Value?.ToString();
            dta.V1COBP_IMP_SEG_VR = result[i++].Value?.ToString();
            dta.V1COBP_PRM_TAR_IX = result[i++].Value?.ToString();
            dta.V1COBP_PRM_TAR_VR = result[i++].Value?.ToString();
            dta.V1COBP_DAT_INIVIG = result[i++].Value?.ToString();
            dta.V1COBP_DAT_TERVIG = result[i++].Value?.ToString();

            return dta;
        }

    }
}