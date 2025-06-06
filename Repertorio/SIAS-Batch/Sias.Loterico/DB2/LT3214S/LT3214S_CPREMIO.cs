using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Loterico.DB2.LT3214S
{
    public class LT3214S_CPREMIO : QueryBasis<LT3214S_CPREMIO>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public LT3214S_CPREMIO() { IsCursor = true; }

        public LT3214S_CPREMIO(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string LT028_NUM_PROPOSTA_SIM { get; set; }
        public string LT028_IND_TIPO_VIGENCIA { get; set; }
        public string LT028_DTA_INI_VIGENCIA { get; set; }
        public string LT028_DTA_FIM_VIGENCIA { get; set; }
        public string LT028_IND_FORMA_COBRANCA_SEG { get; set; }
        public string LT028_IND_FORMA_PGTO_PRIM_PARC { get; set; }
        public string LT028_IND_FORMA_PGTO_DEM_PARC { get; set; }
        public string LT028_VLR_PRIM_PARCELA { get; set; }
        public string LT028_VLR_DEMAIS_PARCELAS { get; set; }
        public string LT028_DTA_VENC_PRIM_PARCELA { get; set; }
        public string LT028_DIA_VENC_DEMAIS_PARCELAS { get; set; }
        public string LT028_QTD_PARCELA { get; set; }
        public string LT028_VLR_IOF_PRIM_PARCELA { get; set; }
        public string LT028_VLR_IOF_DEMAIS_PARCELAS { get; set; }
        public string LT028_VLR_DESCONTO_FIDELIDADE { get; set; }
        public string LT028_VLR_DESCONTO_COB_ADIC { get; set; }
        public string LT028_VLR_DESCONTO_RENOVACAO { get; set; }
        public string LT028_VLR_DESCONTO_EXPERIENCIA { get; set; }
        public string LT028_VLR_DESCONTO_COFRE_INT { get; set; }
        public string LT028_VLR_DESCONTO_BLINDAGEM { get; set; }
        public string LT028_VLR_DESCONTO_PLURIANUAL { get; set; }
        public string LT028_VLR_PREMIO_TARIFARIO { get; set; }
        public string LT028_VLR_DESCONTO_TOTAL { get; set; }
        public string LT028_VLR_PREMIO_LIQUIDO { get; set; }
        public string LT028_VLR_ADICIONAL_FRACIONA { get; set; }
        public string LT028_VLR_CUSTO_EMISSAO { get; set; }
        public string LT028_VLR_IOF { get; set; }
        public string LT028_VLR_PREMIO_TOTAL { get; set; }
        public string LT028_QTD_DIAS_VIGENCIA { get; set; }
        public string LT028_VLR_PREMIO_LIQ_PRIM_PARC { get; set; }
        public string LT028_VLR_ADICIONAL_PRIM_PARC { get; set; }
        public string LT028_VLR_PREMIO_LIQ_DEM_PARC { get; set; }
        public string LT028_VLR_ADICIONAL_DEM_PARC { get; set; }

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


        public override LT3214S_CPREMIO OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new LT3214S_CPREMIO();
            var i = 0;

            dta.LT028_NUM_PROPOSTA_SIM = result[i++].Value?.ToString();
            dta.LT028_IND_TIPO_VIGENCIA = result[i++].Value?.ToString();
            dta.LT028_DTA_INI_VIGENCIA = result[i++].Value?.ToString();
            dta.LT028_DTA_FIM_VIGENCIA = result[i++].Value?.ToString();
            dta.LT028_IND_FORMA_COBRANCA_SEG = result[i++].Value?.ToString();
            dta.LT028_IND_FORMA_PGTO_PRIM_PARC = result[i++].Value?.ToString();
            dta.LT028_IND_FORMA_PGTO_DEM_PARC = result[i++].Value?.ToString();
            dta.LT028_VLR_PRIM_PARCELA = result[i++].Value?.ToString();
            dta.LT028_VLR_DEMAIS_PARCELAS = result[i++].Value?.ToString();
            dta.LT028_DTA_VENC_PRIM_PARCELA = result[i++].Value?.ToString();
            dta.LT028_DIA_VENC_DEMAIS_PARCELAS = result[i++].Value?.ToString();
            dta.LT028_QTD_PARCELA = result[i++].Value?.ToString();
            dta.LT028_VLR_IOF_PRIM_PARCELA = result[i++].Value?.ToString();
            dta.LT028_VLR_IOF_DEMAIS_PARCELAS = result[i++].Value?.ToString();
            dta.LT028_VLR_DESCONTO_FIDELIDADE = result[i++].Value?.ToString();
            dta.LT028_VLR_DESCONTO_COB_ADIC = result[i++].Value?.ToString();
            dta.LT028_VLR_DESCONTO_RENOVACAO = result[i++].Value?.ToString();
            dta.LT028_VLR_DESCONTO_EXPERIENCIA = result[i++].Value?.ToString();
            dta.LT028_VLR_DESCONTO_COFRE_INT = result[i++].Value?.ToString();
            dta.LT028_VLR_DESCONTO_BLINDAGEM = result[i++].Value?.ToString();
            dta.LT028_VLR_DESCONTO_PLURIANUAL = result[i++].Value?.ToString();
            dta.LT028_VLR_PREMIO_TARIFARIO = result[i++].Value?.ToString();
            dta.LT028_VLR_DESCONTO_TOTAL = result[i++].Value?.ToString();
            dta.LT028_VLR_PREMIO_LIQUIDO = result[i++].Value?.ToString();
            dta.LT028_VLR_ADICIONAL_FRACIONA = result[i++].Value?.ToString();
            dta.LT028_VLR_CUSTO_EMISSAO = result[i++].Value?.ToString();
            dta.LT028_VLR_IOF = result[i++].Value?.ToString();
            dta.LT028_VLR_PREMIO_TOTAL = result[i++].Value?.ToString();
            dta.LT028_QTD_DIAS_VIGENCIA = result[i++].Value?.ToString();
            dta.LT028_VLR_PREMIO_LIQ_PRIM_PARC = result[i++].Value?.ToString();
            dta.LT028_VLR_ADICIONAL_PRIM_PARC = result[i++].Value?.ToString();
            dta.LT028_VLR_PREMIO_LIQ_DEM_PARC = result[i++].Value?.ToString();
            dta.LT028_VLR_ADICIONAL_DEM_PARC = result[i++].Value?.ToString();

            return dta;
        }

    }
}