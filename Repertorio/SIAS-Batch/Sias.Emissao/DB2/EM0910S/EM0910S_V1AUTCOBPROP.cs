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
    public class EM0910S_V1AUTCOBPROP : QueryBasis<EM0910S_V1AUTCOBPROP>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public EM0910S_V1AUTCOBPROP() { IsCursor = true; }

        public EM0910S_V1AUTCOBPROP(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string V1AUCP_COD_EMPRESA { get; set; }
        public string V1AUCP_FONTE { get; set; }
        public string V1AUCP_NRPROPOS { get; set; }
        public string V1AUCP_NRITEM { get; set; }
        public string V1AUCP_RAMOFR { get; set; }
        public string V1AUCP_MODALIFR { get; set; }
        public string V1AUCP_COD_COBER { get; set; }
        public string V1AUCP_DTINIVIG { get; set; }
        public string V1AUCP_DTTERVIG { get; set; }
        public string V1AUCP_IMP_SEG_IX { get; set; }
        public string V1AUCP_IMP_SEG_VR { get; set; }
        public string V1AUCP_TAXA_IS { get; set; }
        public string V1AUCP_PRM_ANU_IX { get; set; }
        public string V1AUCP_PRM_TAR_IX { get; set; }
        public string V1AUCP_PRM_TAR_VR { get; set; }
        public string V1AUCP_SITUACAO { get; set; }

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


        public override EM0910S_V1AUTCOBPROP OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new EM0910S_V1AUTCOBPROP();
            var i = 0;

            dta.V1AUCP_COD_EMPRESA = result[i++].Value?.ToString();
            dta.V1AUCP_FONTE = result[i++].Value?.ToString();
            dta.V1AUCP_NRPROPOS = result[i++].Value?.ToString();
            dta.V1AUCP_NRITEM = result[i++].Value?.ToString();
            dta.V1AUCP_RAMOFR = result[i++].Value?.ToString();
            dta.V1AUCP_MODALIFR = result[i++].Value?.ToString();
            dta.V1AUCP_COD_COBER = result[i++].Value?.ToString();
            dta.V1AUCP_DTINIVIG = result[i++].Value?.ToString();
            dta.V1AUCP_DTTERVIG = result[i++].Value?.ToString();
            dta.V1AUCP_IMP_SEG_IX = result[i++].Value?.ToString();
            dta.V1AUCP_IMP_SEG_VR = result[i++].Value?.ToString();
            dta.V1AUCP_TAXA_IS = result[i++].Value?.ToString();
            dta.V1AUCP_PRM_ANU_IX = result[i++].Value?.ToString();
            dta.V1AUCP_PRM_TAR_IX = result[i++].Value?.ToString();
            dta.V1AUCP_PRM_TAR_VR = result[i++].Value?.ToString();
            dta.V1AUCP_SITUACAO = result[i++].Value?.ToString();

            return dta;
        }

    }
}