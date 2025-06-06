using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI0220B
{
    public class SI0220B_PROVISAO : QueryBasis<SI0220B_PROVISAO>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public SI0220B_PROVISAO() { IsCursor = true; }

        public SI0220B_PROVISAO(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string HOST_COD_AGENCIA_CONTRATO { get; set; }
        public string SI111_NUM_APOL_SINISTRO { get; set; }
        public string SI111_NUM_RESSARC { get; set; }
        public string SI111_NUM_PARCELA { get; set; }
        public string SI111_NUM_NOSSO_TITULO { get; set; }
        public string SI111_DTH_VENCIMENTO { get; set; }
        public string SI111_DTH_PAGAMENTO { get; set; }
        public string SI112_DTH_ACORDO { get; set; }
        public string SI112_QTD_PARCELAS { get; set; }
        public string SINISHIS_OCORR_HISTORICO { get; set; }
        public string HOST_VALOR_RECEBIDO { get; set; }
        public string HOST_DATA_BAIXA_SIAS { get; set; }
        public string HOST_VALOR_PRELIB_REPASSE { get; set; }
        public string SINISHIS_COD_PRODUTO { get; set; }
        public string PRODUTO_DESCR_PRODUTO { get; set; }

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


        public override SI0220B_PROVISAO OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new SI0220B_PROVISAO();
            var i = 0;

            dta.HOST_COD_AGENCIA_CONTRATO = result[i++].Value?.ToString();
            dta.SI111_NUM_APOL_SINISTRO = result[i++].Value?.ToString();
            dta.SI111_NUM_RESSARC = result[i++].Value?.ToString();
            dta.SI111_NUM_PARCELA = result[i++].Value?.ToString();
            dta.SI111_NUM_NOSSO_TITULO = result[i++].Value?.ToString();
            dta.SI111_DTH_VENCIMENTO = result[i++].Value?.ToString();
            dta.SI111_DTH_PAGAMENTO = result[i++].Value?.ToString();
            dta.SI112_DTH_ACORDO = result[i++].Value?.ToString();
            dta.SI112_QTD_PARCELAS = result[i++].Value?.ToString();
            dta.SINISHIS_OCORR_HISTORICO = result[i++].Value?.ToString();
            dta.HOST_VALOR_RECEBIDO = result[i++].Value?.ToString();
            dta.HOST_DATA_BAIXA_SIAS = result[i++].Value?.ToString();
            dta.HOST_VALOR_PRELIB_REPASSE = result[i++].Value?.ToString();
            dta.SINISHIS_COD_PRODUTO = result[i++].Value?.ToString();
            dta.PRODUTO_DESCR_PRODUTO = result[i++].Value?.ToString();

            return dta;
        }

    }
}