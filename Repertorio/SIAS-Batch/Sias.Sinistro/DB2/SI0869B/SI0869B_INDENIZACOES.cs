using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI0869B
{
    public class SI0869B_INDENIZACOES : QueryBasis<SI0869B_INDENIZACOES>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public SI0869B_INDENIZACOES() { IsCursor = true; }

        public SI0869B_INDENIZACOES(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string SINISHIS_NUM_APOL_SINISTRO { get; set; }
        public string SINISMES_NUM_APOLICE { get; set; }
        public string SINISMES_DATA_OCORRENCIA { get; set; }
        public string SINISMES_COD_CAUSA { get; set; }
        public string SINISCAU_DESCR_CAUSA { get; set; }
        public string SINISHIS_COD_OPERACAO { get; set; }
        public string SINISHIS_COD_PRODUTO { get; set; }
        public string SINISHIS_DATA_MOVIMENTO { get; set; }
        public string SINISHIS_OCORR_HISTORICO { get; set; }
        public string SINISHIS_VAL_OPERACAO { get; set; }
        public string SINISHIS_SIT_CONTABIL { get; set; }
        public string SINILT01_COD_CLIENTE { get; set; }
        public string CLIENTES_NOME_RAZAO { get; set; }
        public string CLIENTES_CGCCPF { get; set; }
        public string CLIENTES_TIPO_PESSOA { get; set; }
        public string SINILT01_COD_LOT_FENAL { get; set; }
        public string SINILT01_COD_LOT_CEF { get; set; }
        public string SINILT01_COD_COBERTURA { get; set; }
        public string SIMOLOT1_VALOR_INFORMADO { get; set; }
        public string SIMOLOT1_VALOR_REGISTRADO { get; set; }
        public string SIMOLOT1_VAL_IS { get; set; }
        public string SIMOLOT1_DATA_AVISO { get; set; }
        public string SIMOLOT1_VAL_ADIANTAMENTO { get; set; }

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


        public override SI0869B_INDENIZACOES OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new SI0869B_INDENIZACOES();
            var i = 0;

            dta.SINISHIS_NUM_APOL_SINISTRO = result[i++].Value?.ToString();
            dta.SINISMES_NUM_APOLICE = result[i++].Value?.ToString();
            dta.SINISMES_DATA_OCORRENCIA = result[i++].Value?.ToString();
            dta.SINISMES_COD_CAUSA = result[i++].Value?.ToString();
            dta.SINISCAU_DESCR_CAUSA = result[i++].Value?.ToString();
            dta.SINISHIS_COD_OPERACAO = result[i++].Value?.ToString();
            dta.SINISHIS_COD_PRODUTO = result[i++].Value?.ToString();
            dta.SINISHIS_DATA_MOVIMENTO = result[i++].Value?.ToString();
            dta.SINISHIS_OCORR_HISTORICO = result[i++].Value?.ToString();
            dta.SINISHIS_VAL_OPERACAO = result[i++].Value?.ToString();
            dta.SINISHIS_SIT_CONTABIL = result[i++].Value?.ToString();
            dta.SINILT01_COD_CLIENTE = result[i++].Value?.ToString();
            dta.CLIENTES_NOME_RAZAO = result[i++].Value?.ToString();
            dta.CLIENTES_CGCCPF = result[i++].Value?.ToString();
            dta.CLIENTES_TIPO_PESSOA = result[i++].Value?.ToString();
            dta.SINILT01_COD_LOT_FENAL = result[i++].Value?.ToString();
            dta.SINILT01_COD_LOT_CEF = result[i++].Value?.ToString();
            dta.SINILT01_COD_COBERTURA = result[i++].Value?.ToString();
            dta.SIMOLOT1_VALOR_INFORMADO = result[i++].Value?.ToString();
            dta.SIMOLOT1_VALOR_REGISTRADO = result[i++].Value?.ToString();
            dta.SIMOLOT1_VAL_IS = result[i++].Value?.ToString();
            dta.SIMOLOT1_DATA_AVISO = result[i++].Value?.ToString();
            dta.SIMOLOT1_VAL_ADIANTAMENTO = result[i++].Value?.ToString();

            return dta;
        }

    }
}