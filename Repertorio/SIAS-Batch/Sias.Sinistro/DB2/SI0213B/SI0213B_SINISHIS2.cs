using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI0213B
{
    public class SI0213B_SINISHIS2 : QueryBasis<SI0213B_SINISHIS2>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public SI0213B_SINISHIS2() { IsCursor = true; }

        public SI0213B_SINISHIS2(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string SINISHIS_COD_PREST_SERVICO { get; set; }
        public string SINISHIS_SIT_CONTABIL { get; set; }
        public string SINISHIS_NUM_APOL_SINISTRO { get; set; }
        public string SINISHIS_OCORR_HISTORICO { get; set; }
        public string SINISHIS_COD_OPERACAO { get; set; }
        public string SI111_NUM_RESSARC { get; set; }
        public string SI111_SEQ_RESSARC { get; set; }
        public string SI111_NUM_PARCELA { get; set; }
        public string SINISHIS_VAL_OPERACAO { get; set; }
        public string FORNECED_NOME_FORNECEDOR { get; set; }
        public string FORNECED_CGCCPF { get; set; }
        public string FORNECED_TIPO_PESSOA { get; set; }
        public string FORNECED_COD_BANCO { get; set; }
        public string FORNECED_COD_AGENCIA { get; set; }
        public string FORNECED_NUM_CTA_CORRENTE { get; set; }

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


        public override SI0213B_SINISHIS2 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new SI0213B_SINISHIS2();
            var i = 0;

            dta.SINISHIS_COD_PREST_SERVICO = result[i++].Value?.ToString();
            dta.SINISHIS_SIT_CONTABIL = result[i++].Value?.ToString();
            dta.SINISHIS_NUM_APOL_SINISTRO = result[i++].Value?.ToString();
            dta.SINISHIS_OCORR_HISTORICO = result[i++].Value?.ToString();
            dta.SINISHIS_COD_OPERACAO = result[i++].Value?.ToString();
            dta.SI111_NUM_RESSARC = result[i++].Value?.ToString();
            dta.SI111_SEQ_RESSARC = result[i++].Value?.ToString();
            dta.SI111_NUM_PARCELA = result[i++].Value?.ToString();
            dta.SINISHIS_VAL_OPERACAO = result[i++].Value?.ToString();
            dta.FORNECED_NOME_FORNECEDOR = result[i++].Value?.ToString();
            dta.FORNECED_CGCCPF = result[i++].Value?.ToString();
            dta.FORNECED_TIPO_PESSOA = result[i++].Value?.ToString();
            dta.FORNECED_COD_BANCO = result[i++].Value?.ToString();
            dta.FORNECED_COD_AGENCIA = result[i++].Value?.ToString();
            dta.FORNECED_NUM_CTA_CORRENTE = result[i++].Value?.ToString();

            return dta;
        }

    }
}