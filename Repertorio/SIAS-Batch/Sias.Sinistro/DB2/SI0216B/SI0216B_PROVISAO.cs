using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI0216B
{
    public class SI0216B_PROVISAO : QueryBasis<SI0216B_PROVISAO>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public SI0216B_PROVISAO() { IsCursor = true; }

        public SI0216B_PROVISAO(bool justACursor)
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
        public string SINISHIS_DATA_MOVIMENTO { get; set; }
        public string HOST_VALOR_HONORARIO { get; set; }
        public string HOST_VALOR_REPASSE { get; set; }

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


        public override SI0216B_PROVISAO OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new SI0216B_PROVISAO();
            var i = 0;

            dta.SI111_NUM_APOL_SINISTRO = result[i++].Value?.ToString();
            dta.SI111_NUM_RESSARC = result[i++].Value?.ToString();
            dta.SI111_NUM_PARCELA = result[i++].Value?.ToString();
            dta.SI111_NUM_NOSSO_TITULO = result[i++].Value?.ToString();
            dta.SI111_DTH_VENCIMENTO = result[i++].Value?.ToString();
            dta.SINISHIS_OCORR_HISTORICO = result[i++].Value?.ToString();
            dta.SINISHIS_COD_OPERACAO = result[i++].Value?.ToString();
            dta.SINISHIS_VAL_OPERACAO = result[i++].Value?.ToString();
            dta.SINISHIS_DATA_MOVIMENTO = result[i++].Value?.ToString();
            dta.HOST_VALOR_HONORARIO = result[i++].Value?.ToString();
            dta.HOST_VALOR_REPASSE = result[i++].Value?.ToString();

            return dta;
        }

    }
}