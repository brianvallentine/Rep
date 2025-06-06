using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Emissao.DB2.EM0914S
{
    public class EM0914S_CSR_MR026 : QueryBasis<EM0914S_CSR_MR026>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public EM0914S_CSR_MR026() { IsCursor = true; }

        public EM0914S_CSR_MR026(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string MR026_COD_FONTE { get; set; }
        public string MR026_COD_COBERTURA { get; set; }
        public string MR026_NUM_PROPOSTA { get; set; }
        public string MR026_NUM_ITEM { get; set; }
        public string MR026_NUM_SUB_ITEM { get; set; }
        public string MR026_COD_RUBRICA { get; set; }
        public string MR026_COD_SUB_RUBRICA { get; set; }
        public string MR026_DTH_INI_VIGENCIA { get; set; }
        public string MR026_DTH_FIM_VIGENCIA { get; set; }
        public string MR026_VLR_IMP_SEGUR_IX { get; set; }
        public string MR026_VLR_IMP_SEGUR_VAR { get; set; }
        public string MR026_NUM_TAXA_IS_COBER { get; set; }
        public string MR026_VLR_TARIFARIO_IX { get; set; }
        public string MR026_VLR_TARIFARIO_VAR { get; set; }
        public string MR026_PCT_FRANQUIA { get; set; }
        public string MR026_VLR_MIN_INDENIZ { get; set; }
        public string MR026_VLR_MAX_INDENIZ { get; set; }
        public string MR026_VLR_FRANQ_OBR_IX { get; set; }
        public string MR026_STA_REGISTRO { get; set; }

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


        public override EM0914S_CSR_MR026 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new EM0914S_CSR_MR026();
            var i = 0;

            dta.MR026_COD_FONTE = result[i++].Value?.ToString();
            dta.MR026_COD_COBERTURA = result[i++].Value?.ToString();
            dta.MR026_NUM_PROPOSTA = result[i++].Value?.ToString();
            dta.MR026_NUM_ITEM = result[i++].Value?.ToString();
            dta.MR026_NUM_SUB_ITEM = result[i++].Value?.ToString();
            dta.MR026_COD_RUBRICA = result[i++].Value?.ToString();
            dta.MR026_COD_SUB_RUBRICA = result[i++].Value?.ToString();
            dta.MR026_DTH_INI_VIGENCIA = result[i++].Value?.ToString();
            dta.MR026_DTH_FIM_VIGENCIA = result[i++].Value?.ToString();
            dta.MR026_VLR_IMP_SEGUR_IX = result[i++].Value?.ToString();
            dta.MR026_VLR_IMP_SEGUR_VAR = result[i++].Value?.ToString();
            dta.MR026_NUM_TAXA_IS_COBER = result[i++].Value?.ToString();
            dta.MR026_VLR_TARIFARIO_IX = result[i++].Value?.ToString();
            dta.MR026_VLR_TARIFARIO_VAR = result[i++].Value?.ToString();
            dta.MR026_PCT_FRANQUIA = result[i++].Value?.ToString();
            dta.MR026_VLR_MIN_INDENIZ = result[i++].Value?.ToString();
            dta.MR026_VLR_MAX_INDENIZ = result[i++].Value?.ToString();
            dta.MR026_VLR_FRANQ_OBR_IX = result[i++].Value?.ToString();
            dta.MR026_STA_REGISTRO = result[i++].Value?.ToString();

            return dta;
        }

    }
}