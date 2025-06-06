using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Bilhetes.DB2.BI0078B
{
    public class BI0078B_C01_RESULT : QueryBasis<BI0078B_C01_RESULT>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public BI0078B_C01_RESULT() { IsCursor = true; }

        public BI0078B_C01_RESULT(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string WF_NUM_PLANO { get; set; }
        public string WF_NUM_SERIE { get; set; }
        public string WF_NUM_TITULO { get; set; }
        public string WF_COD_STA_TITULO { get; set; }
        public string WF_COD_SUB_STATUS { get; set; }
        public string WF_DTH_ATIVACAO { get; set; }
        public string WF_DTH_CADUCACAO { get; set; }
        public string WF_DTH_CRIACAO { get; set; }
        public string WF_DTH_FIM_VIGENCIA { get; set; }
        public string WF_DTH_INI_SORTEIO { get; set; }
        public string WF_DTH_INI_VIGENCIA { get; set; }
        public string WF_DTH_SUSPENSAO { get; set; }
        public string WF_IND_DV { get; set; }
        public string WF_VLR_MENSALIDADE { get; set; }
        public string WF_NUM_PROPOSTA { get; set; }
        public string WF_NUM_MOD_PLANO { get; set; }
        public string WF_DES_COMBINACAO { get; set; }

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


        public override BI0078B_C01_RESULT OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new BI0078B_C01_RESULT();
            var i = 0;

            dta.WF_NUM_PLANO = result[i++].Value?.ToString();
            dta.WF_NUM_SERIE = result[i++].Value?.ToString();
            dta.WF_NUM_TITULO = result[i++].Value?.ToString();
            dta.WF_COD_STA_TITULO = result[i++].Value?.ToString();
            dta.WF_COD_SUB_STATUS = result[i++].Value?.ToString();
            dta.WF_DTH_ATIVACAO = result[i++].Value?.ToString();
            dta.WF_DTH_CADUCACAO = result[i++].Value?.ToString();
            dta.WF_DTH_CRIACAO = result[i++].Value?.ToString();
            dta.WF_DTH_FIM_VIGENCIA = result[i++].Value?.ToString();
            dta.WF_DTH_INI_SORTEIO = result[i++].Value?.ToString();
            dta.WF_DTH_INI_VIGENCIA = result[i++].Value?.ToString();
            dta.WF_DTH_SUSPENSAO = result[i++].Value?.ToString();
            dta.WF_IND_DV = result[i++].Value?.ToString();
            dta.WF_VLR_MENSALIDADE = result[i++].Value?.ToString();
            dta.WF_NUM_PROPOSTA = result[i++].Value?.ToString();
            dta.WF_NUM_MOD_PLANO = result[i++].Value?.ToString();
            dta.WF_DES_COMBINACAO = result[i++].Value?.ToString();

            return dta;
        }

    }
}