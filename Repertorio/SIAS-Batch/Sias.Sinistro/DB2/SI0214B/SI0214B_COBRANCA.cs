using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI0214B
{
    public class SI0214B_COBRANCA : QueryBasis<SI0214B_COBRANCA>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public SI0214B_COBRANCA() { IsCursor = true; }

        public SI0214B_COBRANCA(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string SI111_NUM_APOL_SINISTRO { get; set; }
        public string SI111_NUM_RESSARC { get; set; }
        public string SI111_NUM_PARCELA { get; set; }
        public string SI111_NUM_NOSSO_TITULO { get; set; }
        public string SI111_DTH_VENCIMENTO { get; set; }
        public string SINISHIS_OCORR_HISTORICO { get; set; }
        public string SINISHIS_COD_OPERACAO { get; set; }
        public string SINISHIS_VAL_OPERACAO { get; set; }
        public string SINISHIS_COD_PREST_SERVICO { get; set; }
        public string SI111_DTH_PAGAMENTO { get; set; }
        public string SINISHIS_DATA_MOVIMENTO { get; set; }
        public string GE284_COD_SISTEMA_ORIGEM { get; set; }
        public string GE284_NOM_SISTEMA { get; set; }
        public string SI111_NUM_TITULO_SIGCB { get; set; }
        public string SI111_IND_FORMA_BAIXA { get; set; }
        public string HOST_TEXTO_FORMA_BAIXA { get; set; }
        public string HOST_IND_TIPO_BAIXA { get; set; }
        public string HOST_TEXTO_TIPO_BAIXA { get; set; }

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


        public override SI0214B_COBRANCA OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new SI0214B_COBRANCA();
            var i = 0;

            dta.SI111_NUM_APOL_SINISTRO = result[i++].Value?.ToString();
            dta.SI111_NUM_RESSARC = result[i++].Value?.ToString();
            dta.SI111_NUM_PARCELA = result[i++].Value?.ToString();
            dta.SI111_NUM_NOSSO_TITULO = result[i++].Value?.ToString();
            dta.SI111_DTH_VENCIMENTO = result[i++].Value?.ToString();
            dta.SINISHIS_OCORR_HISTORICO = result[i++].Value?.ToString();
            dta.SINISHIS_COD_OPERACAO = result[i++].Value?.ToString();
            dta.SINISHIS_VAL_OPERACAO = result[i++].Value?.ToString();
            dta.SINISHIS_COD_PREST_SERVICO = result[i++].Value?.ToString();
            dta.SI111_DTH_PAGAMENTO = result[i++].Value?.ToString();
            dta.SINISHIS_DATA_MOVIMENTO = result[i++].Value?.ToString();
            dta.GE284_COD_SISTEMA_ORIGEM = result[i++].Value?.ToString();
            dta.GE284_NOM_SISTEMA = result[i++].Value?.ToString();
            dta.SI111_NUM_TITULO_SIGCB = result[i++].Value?.ToString();
            dta.SI111_IND_FORMA_BAIXA = result[i++].Value?.ToString();
            dta.HOST_TEXTO_FORMA_BAIXA = result[i++].Value?.ToString();
            dta.HOST_IND_TIPO_BAIXA = result[i++].Value?.ToString();
            dta.HOST_TEXTO_TIPO_BAIXA = result[i++].Value?.ToString();

            return dta;
        }

    }
}