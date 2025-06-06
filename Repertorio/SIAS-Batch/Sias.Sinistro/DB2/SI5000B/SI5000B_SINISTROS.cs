using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI5000B
{
    public class SI5000B_SINISTROS : QueryBasis<SI5000B_SINISTROS>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public SI5000B_SINISTROS() { IsCursor = true; }

        public SI5000B_SINISTROS(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string SINISHIS_NUM_APOLICE { get; set; }
        public string SINISHIS_NUM_APOL_SINISTRO { get; set; }
        public string SINISHIS_COD_OPERACAO { get; set; }
        public string SINISHIS_COD_PRODUTO { get; set; }
        public string SINISHIS_OCORR_HISTORICO { get; set; }
        public string SINISHIS_VAL_OPERACAO { get; set; }
        public string SINISHIS_SIT_REGISTRO { get; set; }
        public string SINILT01_COD_LOT_FENAL { get; set; }
        public string SINILT01_COD_LOT_CEF { get; set; }
        public string SINILT01_COD_CLIENTE { get; set; }
        public string SINILT01_DTINIVIG { get; set; }
        public string CLIENTES_NOME_RAZAO { get; set; }
        public string HOST_VALOR_AVISADO { get; set; }
        public string SINISMES_DATA_OCORRENCIA { get; set; }
        public string PARAMCON_COD_CONVENIO { get; set; }
        public string PARAMCON_COD_PRODUTO { get; set; }
        public string PARAMCON_SIT_REGISTRO { get; set; }
        public string SINISHIS_DATA_MOVIMENTO { get; set; }
        public string CLIENTES_CGCCPF { get; set; }

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


        public override SI5000B_SINISTROS OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new SI5000B_SINISTROS();
            var i = 0;

            dta.SINISHIS_NUM_APOLICE = result[i++].Value?.ToString();
            dta.SINISHIS_NUM_APOL_SINISTRO = result[i++].Value?.ToString();
            dta.SINISHIS_COD_OPERACAO = result[i++].Value?.ToString();
            dta.SINISHIS_COD_PRODUTO = result[i++].Value?.ToString();
            dta.SINISHIS_OCORR_HISTORICO = result[i++].Value?.ToString();
            dta.SINISHIS_VAL_OPERACAO = result[i++].Value?.ToString();
            dta.SINISHIS_SIT_REGISTRO = result[i++].Value?.ToString();
            dta.SINILT01_COD_LOT_FENAL = result[i++].Value?.ToString();
            dta.SINILT01_COD_LOT_CEF = result[i++].Value?.ToString();
            dta.SINILT01_COD_CLIENTE = result[i++].Value?.ToString();
            dta.SINILT01_DTINIVIG = result[i++].Value?.ToString();
            dta.CLIENTES_NOME_RAZAO = result[i++].Value?.ToString();
            dta.HOST_VALOR_AVISADO = result[i++].Value?.ToString();
            dta.SINISMES_DATA_OCORRENCIA = result[i++].Value?.ToString();
            dta.PARAMCON_COD_CONVENIO = result[i++].Value?.ToString();
            dta.PARAMCON_COD_PRODUTO = result[i++].Value?.ToString();
            dta.PARAMCON_SIT_REGISTRO = result[i++].Value?.ToString();
            dta.SINISHIS_DATA_MOVIMENTO = result[i++].Value?.ToString();
            dta.CLIENTES_CGCCPF = result[i++].Value?.ToString();

            return dta;
        }

    }
}