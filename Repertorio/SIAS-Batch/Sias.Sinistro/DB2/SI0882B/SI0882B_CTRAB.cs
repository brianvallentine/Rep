using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI0882B
{
    public class SI0882B_CTRAB : QueryBasis<SI0882B_CTRAB>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public SI0882B_CTRAB() { IsCursor = true; }

        public SI0882B_CTRAB(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string PRODUTO_COD_PRODUTO { get; set; }
        public string PRODUTO_DESCR_PRODUTO { get; set; }
        public string SINIPLAN_DT_PRI_PREST_PAGA { get; set; }
        public string NL_DT_PRI_PREST_PAGA { get; set; }
        public string SINIPLAN_DT_ULT_PREST_PAGA { get; set; }
        public string NL_DT_ULT_PREST_PAGA { get; set; }
        public string SINIHAB1_COD_COBERTURA { get; set; }
        public string SINIPLAN_NUM_APOL_SINISTRO { get; set; }
        public string SINIHAB1_NOME_SEGURADO { get; set; }
        public string SINIPLAN_PERC_PARTICIPACAO { get; set; }
        public string SINIPLAN_VAL_SALDO_DEVEDOR { get; set; }
        public string SINIPLAN_VAL_INDENIZACAO { get; set; }
        public string SINIPLAN_QTD_PRE_ARECUPERAR { get; set; }
        public string SINIPLAN_NUM_ULT_PREST_PAGA { get; set; }
        public string NL_NUM_ULT_PREST_PAGA { get; set; }
        public string HOST_NUM_CONTRATO { get; set; }
        public string SINIPLAN_DATA_INDENIZACAO { get; set; }
        public string SINIPLAN_VAL_PREMIO { get; set; }
        public string RALCHEDO_NUMERO_SIVAT { get; set; }

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


        public override SI0882B_CTRAB OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new SI0882B_CTRAB();
            var i = 0;

            dta.PRODUTO_COD_PRODUTO = result[i++].Value?.ToString();
            dta.PRODUTO_DESCR_PRODUTO = result[i++].Value?.ToString();
            dta.SINIPLAN_DT_PRI_PREST_PAGA = result[i++].Value?.ToString();
            dta.NL_DT_PRI_PREST_PAGA = string.IsNullOrWhiteSpace(dta.SINIPLAN_DT_PRI_PREST_PAGA) ? "-1" : "0";
            dta.SINIPLAN_DT_ULT_PREST_PAGA = result[i++].Value?.ToString();
            dta.NL_DT_ULT_PREST_PAGA = string.IsNullOrWhiteSpace(dta.SINIPLAN_DT_ULT_PREST_PAGA) ? "-1" : "0";
            dta.SINIHAB1_COD_COBERTURA = result[i++].Value?.ToString();
            dta.SINIPLAN_NUM_APOL_SINISTRO = result[i++].Value?.ToString();
            dta.SINIHAB1_NOME_SEGURADO = result[i++].Value?.ToString();
            dta.SINIPLAN_PERC_PARTICIPACAO = result[i++].Value?.ToString();
            dta.SINIPLAN_VAL_SALDO_DEVEDOR = result[i++].Value?.ToString();
            dta.SINIPLAN_VAL_INDENIZACAO = result[i++].Value?.ToString();
            dta.SINIPLAN_QTD_PRE_ARECUPERAR = result[i++].Value?.ToString();
            dta.SINIPLAN_NUM_ULT_PREST_PAGA = result[i++].Value?.ToString();
            dta.NL_NUM_ULT_PREST_PAGA = string.IsNullOrWhiteSpace(dta.SINIPLAN_NUM_ULT_PREST_PAGA) ? "-1" : "0";
            dta.HOST_NUM_CONTRATO = result[i++].Value?.ToString();
            dta.SINIPLAN_DATA_INDENIZACAO = result[i++].Value?.ToString();
            dta.SINIPLAN_VAL_PREMIO = result[i++].Value?.ToString();
            dta.RALCHEDO_NUMERO_SIVAT = result[i++].Value?.ToString();

            return dta;
        }

    }
}