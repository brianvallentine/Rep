using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SICP001S
{
    public class SICP001S_LE_MOVDEBCE : QueryBasis<SICP001S_LE_MOVDEBCE>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public SICP001S_LE_MOVDEBCE() { IsCursor = true; }

        public SICP001S_LE_MOVDEBCE(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string W_NOME_QUERY { get; set; }
        public string SINISHIS_TIPO_REGISTRO { get; set; }
        public string W_NOME_TIPO_SEGURO { get; set; }
        public string SINISHIS_NUM_APOLICE { get; set; }
        public string SINISHIS_NUM_APOL_SINISTRO { get; set; }
        public string SINISHIS_OCORR_HISTORICO { get; set; }
        public string SINISHIS_COD_OPERACAO { get; set; }
        public string SINISHIS_NOME_FAVORECIDO { get; set; }
        public string W_ANO_OPERACIONAL_MOVIMENTO { get; set; }
        public string W_ANO_CONTABIL_MOVIMENTO { get; set; }
        public string GEOPERAC_FUNCAO_OPERACAO { get; set; }
        public string GEOPERAC_IND_TIPO_FUNCAO { get; set; }
        public string GEOPERAC_DES_OPERACAO { get; set; }
        public string SINISHIS_VAL_OPERACAO { get; set; }
        public string MOVDEBCE_VLR_CREDITO { get; set; }
        public string MOVDEBCE_VALOR_DEBITO { get; set; }
        public string SINISHIS_DATA_MOVIMENTO { get; set; }
        public string SINISHIS_COD_PREST_SERVICO { get; set; }
        public string SINISHIS_COD_SERVICO { get; set; }
        public string SINISHIS_SIT_CONTABIL { get; set; }
        public string W_NOME_FORMA_PAGAMENTO { get; set; }
        public string SINISHIS_NOM_PROGRAMA { get; set; }
        public string NULL_NOM_PROGRAMA { get; set; }
        public string SINISHIS_COD_USUARIO { get; set; }
        public string SINISMES_RAMO { get; set; }
        public string SINISMES_COD_FONTE { get; set; }
        public string W_DATA_AVISO_SIAS { get; set; }
        public string SINISMES_DATA_COMUNICADO { get; set; }
        public string SINISMES_COD_PRODUTO { get; set; }
        public string PRODUTO_DESCR_PRODUTO { get; set; }
        public string CHEQUEMI_NUM_CHEQUE_INTERNO { get; set; }
        public string MOVDEBCE_NUM_APOLICE { get; set; }
        public string MOVDEBCE_NUM_ENDOSSO { get; set; }
        public string MOVDEBCE_NUM_PARCELA { get; set; }
        public string MOVDEBCE_SITUACAO_COBRANCA { get; set; }
        public string W_NOME_SITUACAO_COBRANCA { get; set; }
        public string MOVDEBCE_DATA_VENCIMENTO { get; set; }
        public string MOVDEBCE_DATA_MOVIMENTO { get; set; }
        public string MOVDEBCE_COD_AGENCIA_DEB { get; set; }
        public string MOVDEBCE_OPER_CONTA_DEB { get; set; }
        public string MOVDEBCE_NUM_CONTA_DEB { get; set; }
        public string MOVDEBCE_DIG_CONTA_DEB { get; set; }
        public string MOVDEBCE_COD_CONVENIO { get; set; }
        public string MOVDEBCE_DATA_ENVIO { get; set; }
        public string MOVDEBCE_NSAS { get; set; }
        public string MOVDEBCE_NUM_REQUISICAO { get; set; }
        public string GE369_COD_AGENCIA { get; set; }
        public string NULL_COD_AGENCIA { get; set; }
        public string GE369_COD_BANCO { get; set; }
        public string NULL_COD_BANCO { get; set; }
        public string GE369_NUM_CONTA_CNB { get; set; }
        public string NULL_NUM_CONTA_CNB { get; set; }
        public string GE369_NUM_DV_CONTA_CNB { get; set; }
        public string NULL_NUM_DV_CONTA_CNB { get; set; }
        public string GE369_IND_CONTA_BANCARIA { get; set; }
        public string NULL_IND_CONTA_BANCARIA { get; set; }
        public string PRODUTO_COD_EMPRESA { get; set; }

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


        public override SICP001S_LE_MOVDEBCE OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new SICP001S_LE_MOVDEBCE();
            var i = 0;

            dta.W_NOME_QUERY = result[i++].Value?.ToString();
            dta.SINISHIS_TIPO_REGISTRO = result[i++].Value?.ToString();
            dta.W_NOME_TIPO_SEGURO = result[i++].Value?.ToString();
            dta.SINISHIS_NUM_APOLICE = result[i++].Value?.ToString();
            dta.SINISHIS_NUM_APOL_SINISTRO = result[i++].Value?.ToString();
            dta.SINISHIS_OCORR_HISTORICO = result[i++].Value?.ToString();
            dta.SINISHIS_COD_OPERACAO = result[i++].Value?.ToString();
            dta.SINISHIS_NOME_FAVORECIDO = result[i++].Value?.ToString();
            dta.W_ANO_OPERACIONAL_MOVIMENTO = result[i++].Value?.ToString();
            dta.W_ANO_CONTABIL_MOVIMENTO = result[i++].Value?.ToString();
            dta.GEOPERAC_FUNCAO_OPERACAO = result[i++].Value?.ToString();
            dta.GEOPERAC_IND_TIPO_FUNCAO = result[i++].Value?.ToString();
            dta.GEOPERAC_DES_OPERACAO = result[i++].Value?.ToString();
            dta.SINISHIS_VAL_OPERACAO = result[i++].Value?.ToString();
            dta.MOVDEBCE_VLR_CREDITO = result[i++].Value?.ToString();
            dta.MOVDEBCE_VALOR_DEBITO = result[i++].Value?.ToString();
            dta.SINISHIS_DATA_MOVIMENTO = result[i++].Value?.ToString();
            dta.SINISHIS_COD_PREST_SERVICO = result[i++].Value?.ToString();
            dta.SINISHIS_COD_SERVICO = result[i++].Value?.ToString();
            dta.SINISHIS_SIT_CONTABIL = result[i++].Value?.ToString();
            dta.W_NOME_FORMA_PAGAMENTO = result[i++].Value?.ToString();
            dta.SINISHIS_NOM_PROGRAMA = result[i++].Value?.ToString();
            dta.NULL_NOM_PROGRAMA = string.IsNullOrWhiteSpace(dta.SINISHIS_NOM_PROGRAMA) ? "-1" : "0";
            dta.SINISHIS_COD_USUARIO = result[i++].Value?.ToString();
            dta.SINISMES_RAMO = result[i++].Value?.ToString();
            dta.SINISMES_COD_FONTE = result[i++].Value?.ToString();
            dta.W_DATA_AVISO_SIAS = result[i++].Value?.ToString();
            dta.SINISMES_DATA_COMUNICADO = result[i++].Value?.ToString();
            dta.SINISMES_COD_PRODUTO = result[i++].Value?.ToString();
            dta.PRODUTO_DESCR_PRODUTO = result[i++].Value?.ToString();
            dta.CHEQUEMI_NUM_CHEQUE_INTERNO = result[i++].Value?.ToString();
            dta.MOVDEBCE_NUM_APOLICE = result[i++].Value?.ToString();
            dta.MOVDEBCE_NUM_ENDOSSO = result[i++].Value?.ToString();
            dta.MOVDEBCE_NUM_PARCELA = result[i++].Value?.ToString();
            dta.MOVDEBCE_SITUACAO_COBRANCA = result[i++].Value?.ToString();
            dta.W_NOME_SITUACAO_COBRANCA = result[i++].Value?.ToString();
            dta.MOVDEBCE_DATA_VENCIMENTO = result[i++].Value?.ToString();
            dta.MOVDEBCE_DATA_MOVIMENTO = result[i++].Value?.ToString();
            dta.MOVDEBCE_COD_AGENCIA_DEB = result[i++].Value?.ToString();
            dta.MOVDEBCE_OPER_CONTA_DEB = result[i++].Value?.ToString();
            dta.MOVDEBCE_NUM_CONTA_DEB = result[i++].Value?.ToString();
            dta.MOVDEBCE_DIG_CONTA_DEB = result[i++].Value?.ToString();
            dta.MOVDEBCE_COD_CONVENIO = result[i++].Value?.ToString();
            dta.MOVDEBCE_DATA_ENVIO = result[i++].Value?.ToString();
            dta.MOVDEBCE_NSAS = result[i++].Value?.ToString();
            dta.MOVDEBCE_NUM_REQUISICAO = result[i++].Value?.ToString();
            dta.GE369_COD_AGENCIA = result[i++].Value?.ToString();
            dta.NULL_COD_AGENCIA = string.IsNullOrWhiteSpace(dta.GE369_COD_AGENCIA) ? "-1" : "0";
            dta.GE369_COD_BANCO = result[i++].Value?.ToString();
            dta.NULL_COD_BANCO = string.IsNullOrWhiteSpace(dta.GE369_COD_BANCO) ? "-1" : "0";
            dta.GE369_NUM_CONTA_CNB = result[i++].Value?.ToString();
            dta.NULL_NUM_CONTA_CNB = string.IsNullOrWhiteSpace(dta.GE369_NUM_CONTA_CNB) ? "-1" : "0";
            dta.GE369_NUM_DV_CONTA_CNB = result[i++].Value?.ToString();
            dta.NULL_NUM_DV_CONTA_CNB = string.IsNullOrWhiteSpace(dta.GE369_NUM_DV_CONTA_CNB) ? "-1" : "0";
            dta.GE369_IND_CONTA_BANCARIA = result[i++].Value?.ToString();
            dta.NULL_IND_CONTA_BANCARIA = string.IsNullOrWhiteSpace(dta.GE369_IND_CONTA_BANCARIA) ? "-1" : "0";
            dta.PRODUTO_COD_EMPRESA = result[i++].Value?.ToString();

            return dta;
        }

    }
}