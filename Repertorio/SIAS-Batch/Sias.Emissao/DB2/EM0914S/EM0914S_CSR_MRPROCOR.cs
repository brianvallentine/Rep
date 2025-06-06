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
    public class EM0914S_CSR_MRPROCOR : QueryBasis<EM0914S_CSR_MRPROCOR>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public EM0914S_CSR_MRPROCOR() { IsCursor = true; }

        public EM0914S_CSR_MRPROCOR(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string MRPROCOR_COD_COBERTURA { get; set; }
        public string MRPROCOR_NUM_ITEM { get; set; }
        public string MRPROCOR_RAMO_COBERTURA { get; set; }
        public string MRPROCOR_MODALI_COBERTURA { get; set; }
        public string MRPROCOR_DTH_INI_VIGENCIA { get; set; }
        public string MRPROCOR_DTH_FIM_VIGENCIA { get; set; }
        public string MRPROCOR_IMP_SEGURADA_IX { get; set; }
        public string MRPROCOR_IMP_SEGURADA_VAR { get; set; }
        public string MRPROCOR_TAXA_IS_COBER { get; set; }
        public string MRPROCOR_PRM_TARIFARIO_IX { get; set; }
        public string MRPROCOR_PRM_TARIFARIO_VAR { get; set; }
        public string MRPROCOR_PCT_FRANQUIA { get; set; }
        public string MRPROCOR_VAL_FRANQ_OBR_IX { get; set; }
        public string MRPROCOR_SIT_REGISTRO { get; set; }
        public string MRPROCOR_COD_EMPRESA { get; set; }

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


        public override EM0914S_CSR_MRPROCOR OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new EM0914S_CSR_MRPROCOR();
            var i = 0;

            dta.MRPROCOR_COD_COBERTURA = result[i++].Value?.ToString();
            dta.MRPROCOR_NUM_ITEM = result[i++].Value?.ToString();
            dta.MRPROCOR_RAMO_COBERTURA = result[i++].Value?.ToString();
            dta.MRPROCOR_MODALI_COBERTURA = result[i++].Value?.ToString();
            dta.MRPROCOR_DTH_INI_VIGENCIA = result[i++].Value?.ToString();
            dta.MRPROCOR_DTH_FIM_VIGENCIA = result[i++].Value?.ToString();
            dta.MRPROCOR_IMP_SEGURADA_IX = result[i++].Value?.ToString();
            dta.MRPROCOR_IMP_SEGURADA_VAR = result[i++].Value?.ToString();
            dta.MRPROCOR_TAXA_IS_COBER = result[i++].Value?.ToString();
            dta.MRPROCOR_PRM_TARIFARIO_IX = result[i++].Value?.ToString();
            dta.MRPROCOR_PRM_TARIFARIO_VAR = result[i++].Value?.ToString();
            dta.MRPROCOR_PCT_FRANQUIA = result[i++].Value?.ToString();
            dta.MRPROCOR_VAL_FRANQ_OBR_IX = result[i++].Value?.ToString();
            dta.MRPROCOR_SIT_REGISTRO = result[i++].Value?.ToString();
            dta.MRPROCOR_COD_EMPRESA = result[i++].Value?.ToString();

            return dta;
        }

    }
}