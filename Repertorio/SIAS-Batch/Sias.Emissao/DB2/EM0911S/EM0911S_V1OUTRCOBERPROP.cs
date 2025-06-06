using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Emissao.DB2.EM0911S
{
    public class EM0911S_V1OUTRCOBERPROP : QueryBasis<EM0911S_V1OUTRCOBERPROP>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public EM0911S_V1OUTRCOBERPROP() { IsCursor = true; }

        public EM0911S_V1OUTRCOBERPROP(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string V1PRCO_COD_EMPRESA { get; set; }
        public string V1PRCO_FONTE { get; set; }
        public string V1PRCO_NRPROPOS { get; set; }
        public string V1PRCO_NRRISCO { get; set; }
        public string V1PRCO_RAMOFR { get; set; }
        public string V1PRCO_MODALIFR { get; set; }
        public string V1PRCO_COD_COBER { get; set; }
        public string V1PRCO_DTINIVIG { get; set; }
        public string V1PRCO_DTTERVIG { get; set; }
        public string V1PRCO_IMP_SEG_IX { get; set; }
        public string V1PRCO_IMP_SEG_VR { get; set; }
        public string V1PRCO_TAXA_IS { get; set; }
        public string V1PRCO_PRM_ANU_IX { get; set; }
        public string V1PRCO_PRM_TAR_IX { get; set; }
        public string V1PRCO_PRM_TAR_VR { get; set; }
        public string V1PRCO_VRFROBR_IX { get; set; }
        public string V1PRCO_LIM_IND_IX { get; set; }
        public string V1PRCO_SITUACAO { get; set; }

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


        public override EM0911S_V1OUTRCOBERPROP OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new EM0911S_V1OUTRCOBERPROP();
            var i = 0;

            dta.V1PRCO_COD_EMPRESA = result[i++].Value?.ToString();
            dta.V1PRCO_FONTE = result[i++].Value?.ToString();
            dta.V1PRCO_NRPROPOS = result[i++].Value?.ToString();
            dta.V1PRCO_NRRISCO = result[i++].Value?.ToString();
            dta.V1PRCO_RAMOFR = result[i++].Value?.ToString();
            dta.V1PRCO_MODALIFR = result[i++].Value?.ToString();
            dta.V1PRCO_COD_COBER = result[i++].Value?.ToString();
            dta.V1PRCO_DTINIVIG = result[i++].Value?.ToString();
            dta.V1PRCO_DTTERVIG = result[i++].Value?.ToString();
            dta.V1PRCO_IMP_SEG_IX = result[i++].Value?.ToString();
            dta.V1PRCO_IMP_SEG_VR = result[i++].Value?.ToString();
            dta.V1PRCO_TAXA_IS = result[i++].Value?.ToString();
            dta.V1PRCO_PRM_ANU_IX = result[i++].Value?.ToString();
            dta.V1PRCO_PRM_TAR_IX = result[i++].Value?.ToString();
            dta.V1PRCO_PRM_TAR_VR = result[i++].Value?.ToString();
            dta.V1PRCO_VRFROBR_IX = result[i++].Value?.ToString();
            dta.V1PRCO_LIM_IND_IX = result[i++].Value?.ToString();
            dta.V1PRCO_SITUACAO = result[i++].Value?.ToString();

            return dta;
        }

    }
}