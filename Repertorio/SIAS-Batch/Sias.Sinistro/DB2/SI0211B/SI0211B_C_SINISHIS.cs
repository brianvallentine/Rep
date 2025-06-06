using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI0211B
{
    public class SI0211B_C_SINISHIS : QueryBasis<SI0211B_C_SINISHIS>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public SI0211B_C_SINISHIS() { IsCursor = true; }

        public SI0211B_C_SINISHIS(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string H_SINISHIS_COD_EMPRESA { get; set; }
        public string H_SINISHIS_TIPO_REGISTRO { get; set; }
        public string H_SINISHIS_COD_OPERACAO { get; set; }
        public string H_SINISHIS_DATA_MOVIMENTO { get; set; }
        public string H_SINISHIS_HORA_OPERACAO { get; set; }
        public string H_SINISHIS_NOME_FAVORECIDO { get; set; }
        public string H_SINISHIS_VAL_OPERACAO { get; set; }
        public string H_SINISHIS_DATA_LIM_CORRECAO { get; set; }
        public string H_SINISHIS_TIPO_FAVORECIDO { get; set; }
        public string H_SINISHIS_DATA_NEGOCIADA { get; set; }
        public string H_SINISHIS_FONTE_PAGAMENTO { get; set; }
        public string H_SINISHIS_COD_PREST_SERVICO { get; set; }
        public string H_SINISHIS_COD_SERVICO { get; set; }
        public string H_SINISHIS_ORDEM_PAGAMENTO { get; set; }
        public string H_SINISHIS_NUM_RECIBO { get; set; }
        public string H_SINISHIS_NUM_MOV_SINISTRO { get; set; }
        public string H_SINISHIS_COD_USUARIO { get; set; }
        public string H_SINISHIS_SIT_CONTABIL { get; set; }
        public string H_SINISHIS_SIT_REGISTRO { get; set; }
        public string H_SINISHIS_NUM_APOLICE { get; set; }
        public string H_SINISHIS_COD_PRODUTO { get; set; }
        public string H_SINISHIS_TIMESTAMP { get; set; }

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


        public override SI0211B_C_SINISHIS OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new SI0211B_C_SINISHIS();
            var i = 0;

            dta.H_SINISHIS_COD_EMPRESA = result[i++].Value?.ToString();
            dta.H_SINISHIS_TIPO_REGISTRO = result[i++].Value?.ToString();
            dta.H_SINISHIS_COD_OPERACAO = result[i++].Value?.ToString();
            dta.H_SINISHIS_DATA_MOVIMENTO = result[i++].Value?.ToString();
            dta.H_SINISHIS_HORA_OPERACAO = result[i++].Value?.ToString();
            dta.H_SINISHIS_NOME_FAVORECIDO = result[i++].Value?.ToString();
            dta.H_SINISHIS_VAL_OPERACAO = result[i++].Value?.ToString();
            dta.H_SINISHIS_DATA_LIM_CORRECAO = result[i++].Value?.ToString();
            dta.H_SINISHIS_TIPO_FAVORECIDO = result[i++].Value?.ToString();
            dta.H_SINISHIS_DATA_NEGOCIADA = result[i++].Value?.ToString();
            dta.H_SINISHIS_FONTE_PAGAMENTO = result[i++].Value?.ToString();
            dta.H_SINISHIS_COD_PREST_SERVICO = result[i++].Value?.ToString();
            dta.H_SINISHIS_COD_SERVICO = result[i++].Value?.ToString();
            dta.H_SINISHIS_ORDEM_PAGAMENTO = result[i++].Value?.ToString();
            dta.H_SINISHIS_NUM_RECIBO = result[i++].Value?.ToString();
            dta.H_SINISHIS_NUM_MOV_SINISTRO = result[i++].Value?.ToString();
            dta.H_SINISHIS_COD_USUARIO = result[i++].Value?.ToString();
            dta.H_SINISHIS_SIT_CONTABIL = result[i++].Value?.ToString();
            dta.H_SINISHIS_SIT_REGISTRO = result[i++].Value?.ToString();
            dta.H_SINISHIS_NUM_APOLICE = result[i++].Value?.ToString();
            dta.H_SINISHIS_COD_PRODUTO = result[i++].Value?.ToString();
            dta.H_SINISHIS_TIMESTAMP = result[i++].Value?.ToString();

            return dta;
        }

    }
}