using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI9247B
{
    public class SI9247B_C01_SIARDEVC : QueryBasis<SI9247B_C01_SIARDEVC>
    {
        [JsonIgnore] public bool JustACursor { get; set; } = false;

        public delegate string GetQueryDelegateHandler();
        public event GetQueryDelegateHandler GetQueryEvent;

        //ESTE CONSTRUTOR NÃO DEVE SER USADO ( CUIDADO )
        public SI9247B_C01_SIARDEVC() { IsCursor = true; }

        public SI9247B_C01_SIARDEVC(bool justACursor)
        {
            JustACursor = justACursor;
            IsCursor = true;
        }

        public string SIARDEVC_NOM_ARQUIVO { get; set; }
        public string SIARDEVC_SEQ_GERACAO { get; set; }
        public string SIARDEVC_TIPO_REGISTRO { get; set; }
        public string SIARDEVC_SEQ_REGISTRO { get; set; }
        public string SIARDEVC_COD_OPERACAO { get; set; }
        public string SIARDEVC_OCORR_HISTORICO { get; set; }
        public string SIARDEVC_NUM_SINISTRO_VC { get; set; }
        public string SIARDEVC_NUM_EXPEDIENTE_VC { get; set; }
        public string SIARDEVC_NUM_APOLICE { get; set; }
        public string SIARDEVC_NUM_ENDOSSO { get; set; }
        public string SIARDEVC_NUM_ITEM { get; set; }
        public string SIARDEVC_COD_RAMO { get; set; }
        public string SIARDEVC_COD_COBERTURA { get; set; }
        public string SIARDEVC_COD_CAUSA { get; set; }
        public string SIARDEVC_DATA_COMUNICADO { get; set; }
        public string SIARDEVC_DATA_OCORRENCIA { get; set; }
        public string SIARDEVC_HORA_OCORRENCIA { get; set; }
        public string SIARDEVC_DATA_MOVIMENTO { get; set; }
        public string SIARDEVC_IND_FAVORECIDO { get; set; }
        public string SIARDEVC_VAL_TOT_MOVIMENTO { get; set; }
        public string SIARDEVC_VAL_PECAS { get; set; }
        public string SIARDEVC_VAL_MAO_OBRA { get; set; }
        public string SIARDEVC_VAL_PARCELA_PEND { get; set; }
        public string SIARDEVC_QTD_PARCELA_PEND { get; set; }
        public string SIARDEVC_VAL_DESC_PARC_PEND { get; set; }
        public string SIARDEVC_DATA_NEGOCIADA { get; set; }
        public string SIARDEVC_VAL_IRF { get; set; }
        public string SIARDEVC_VAL_ISS { get; set; }
        public string SIARDEVC_VAL_INSS { get; set; }
        public string SIARDEVC_VAL_LIQUIDO_PAGTO { get; set; }
        public string SIARDEVC_CGCCPF { get; set; }
        public string SIARDEVC_TIPO_PESSOA { get; set; }
        public string SIARDEVC_NOM_FAVORECIDO { get; set; }
        public string SIARDEVC_IND_DOC_FISCAL { get; set; }
        public string SIARDEVC_NUM_DOC_FISCAL { get; set; }
        public string SIARDEVC_SERIE_DOC_FISCAL { get; set; }
        public string SIARDEVC_DATA_EMISSAO { get; set; }
        public string SIARDEVC_DES_ENDERECO { get; set; }
        public string SIARDEVC_NOM_BAIRRO { get; set; }
        public string SIARDEVC_NOM_CIDADE { get; set; }
        public string SIARDEVC_COD_UF { get; set; }
        public string SIARDEVC_NUM_CEP { get; set; }
        public string SIARDEVC_NUM_DDD { get; set; }
        public string SIARDEVC_NUM_TELEFONE { get; set; }
        public string SIARDEVC_IND_FORMA_PAGTO { get; set; }
        public string SIARDEVC_NUM_IDENTIFICADOR { get; set; }
        public string SIARDEVC_NUM_CHEQUE_INTERNO { get; set; }
        public string SIARDEVC_ORDEM_PAGAMENTO_VC { get; set; }
        public string SIARDEVC_ORDEM_PAGAMENTO { get; set; }
        public string SIARDEVC_COD_BANCO { get; set; }
        public string SIARDEVC_COD_AGENCIA { get; set; }
        public string SIARDEVC_OPERACAO_CONTA { get; set; }
        public string SIARDEVC_COD_CONTA { get; set; }
        public string SIARDEVC_DV_CONTA { get; set; }
        public string SIARDEVC_COD_FAVORECIDO { get; set; }
        public string SIARDEVC_NUM_APOL_SINISTRO { get; set; }
        public string SIARDEVC_STA_PROCESSAMENTO { get; set; }
        public string SIARDEVC_COD_ERRO { get; set; }
        public string SIARDEVC_VAL_PISPASEP { get; set; }
        public string SIARDEVC_VAL_COFINS { get; set; }
        public string SIARDEVC_VAL_CSLL { get; set; }
        public string SIARDEVC_COD_FONTE { get; set; }
        public string SIARDEVC_NUM_RESSARC { get; set; }
        public string SIARDEVC_IND_PESSOA_ACORDO { get; set; }
        public string SIARDEVC_NUM_CPFCGC_ACORDO { get; set; }
        public string SIARDEVC_NOM_RESP_ACORDO { get; set; }
        public string SIARDEVC_STA_ACORDO { get; set; }
        public string SIARDEVC_DTH_INDENIZACAO { get; set; }
        public string SIARDEVC_VLR_INDENIZACAO { get; set; }
        public string SIARDEVC_VLR_PART_TERCEIROS { get; set; }
        public string SIARDEVC_VLR_DIVIDA { get; set; }
        public string SIARDEVC_PCT_DESCONTO { get; set; }
        public string SIARDEVC_VLR_TOTAL_DESCONTO { get; set; }
        public string SIARDEVC_VLR_TOTAL_ACORDO { get; set; }
        public string SIARDEVC_COD_MOEDA_ACORDO { get; set; }
        public string SIARDEVC_DTH_ACORDO { get; set; }
        public string SIARDEVC_QTD_PARCELAS_ACORDO { get; set; }
        public string SIARDEVC_NUM_PARCELA_ACORDO { get; set; }
        public string SIARDEVC_COD_AGENCIA_CEDENT { get; set; }
        public string SIARDEVC_NUM_CEDENTE { get; set; }
        public string SIARDEVC_NUM_CEDENTE_DV { get; set; }
        public string SIARDEVC_DTH_VENCIMENTO { get; set; }
        public string SIARDEVC_NUM_NOSSO_TITULO { get; set; }
        public string SIARDEVC_VLR_TITULO { get; set; }
        public string SIARDEVC_NUM_CPFCGC_RECLAMANTE { get; set; }
        public string SIARDEVC_NOM_RECLAMANTE { get; set; }
        public string SIARDEVC_VLR_RECLAMADO { get; set; }
        public string SIARDEVC_VLR_PROVISIONADO { get; set; }
        public string SIARDEVC_NUM_SINISTRO_CONV { get; set; }
        public string SIARDEVC_NUM_IDENT_CONV { get; set; }
        public string SIARDEVC_NUM_IDE_COBR_CONV { get; set; }
        public string SIARDEVC_COD_CFOP { get; set; }
        public string SIARDEVC_COD_CEST { get; set; }
        public string SIARDEVC_NUM_INSCR_ESTADUAL { get; set; }
        public string SIARDEVC_NUM_NCM { get; set; }
        public string SIARDEVC_NUM_CPF_CNPJ_TOMADOR { get; set; }
        public string SIARDEVC_IND_ISENCAO_TRIBUTO { get; set; }
        public string SIARDEVC_COD_IMPOSTO_LIMINAR { get; set; }
        public string SIARDEVC_COD_PROCESSO_ISENCAO { get; set; }
        public string SIARDEVC_VLR_RET_N_EFETUADO { get; set; }

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


        public override SI9247B_C01_SIARDEVC OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new SI9247B_C01_SIARDEVC();
            var i = 0;

            dta.SIARDEVC_NOM_ARQUIVO = result[i++].Value?.ToString();
            dta.SIARDEVC_SEQ_GERACAO = result[i++].Value?.ToString();
            dta.SIARDEVC_TIPO_REGISTRO = result[i++].Value?.ToString();
            dta.SIARDEVC_SEQ_REGISTRO = result[i++].Value?.ToString();
            dta.SIARDEVC_COD_OPERACAO = result[i++].Value?.ToString();
            dta.SIARDEVC_OCORR_HISTORICO = result[i++].Value?.ToString();
            dta.SIARDEVC_NUM_SINISTRO_VC = result[i++].Value?.ToString();
            dta.SIARDEVC_NUM_EXPEDIENTE_VC = result[i++].Value?.ToString();
            dta.SIARDEVC_NUM_APOLICE = result[i++].Value?.ToString();
            dta.SIARDEVC_NUM_ENDOSSO = result[i++].Value?.ToString();
            dta.SIARDEVC_NUM_ITEM = result[i++].Value?.ToString();
            dta.SIARDEVC_COD_RAMO = result[i++].Value?.ToString();
            dta.SIARDEVC_COD_COBERTURA = result[i++].Value?.ToString();
            dta.SIARDEVC_COD_CAUSA = result[i++].Value?.ToString();
            dta.SIARDEVC_DATA_COMUNICADO = result[i++].Value?.ToString();
            dta.SIARDEVC_DATA_OCORRENCIA = result[i++].Value?.ToString();
            dta.SIARDEVC_HORA_OCORRENCIA = result[i++].Value?.ToString();
            dta.SIARDEVC_DATA_MOVIMENTO = result[i++].Value?.ToString();
            dta.SIARDEVC_IND_FAVORECIDO = result[i++].Value?.ToString();
            dta.SIARDEVC_VAL_TOT_MOVIMENTO = result[i++].Value?.ToString();
            dta.SIARDEVC_VAL_PECAS = result[i++].Value?.ToString();
            dta.SIARDEVC_VAL_MAO_OBRA = result[i++].Value?.ToString();
            dta.SIARDEVC_VAL_PARCELA_PEND = result[i++].Value?.ToString();
            dta.SIARDEVC_QTD_PARCELA_PEND = result[i++].Value?.ToString();
            dta.SIARDEVC_VAL_DESC_PARC_PEND = result[i++].Value?.ToString();
            dta.SIARDEVC_DATA_NEGOCIADA = result[i++].Value?.ToString();
            dta.SIARDEVC_VAL_IRF = result[i++].Value?.ToString();
            dta.SIARDEVC_VAL_ISS = result[i++].Value?.ToString();
            dta.SIARDEVC_VAL_INSS = result[i++].Value?.ToString();
            dta.SIARDEVC_VAL_LIQUIDO_PAGTO = result[i++].Value?.ToString();
            dta.SIARDEVC_CGCCPF = result[i++].Value?.ToString();
            dta.SIARDEVC_TIPO_PESSOA = result[i++].Value?.ToString();
            dta.SIARDEVC_NOM_FAVORECIDO = result[i++].Value?.ToString();
            dta.SIARDEVC_IND_DOC_FISCAL = result[i++].Value?.ToString();
            dta.SIARDEVC_NUM_DOC_FISCAL = result[i++].Value?.ToString();
            dta.SIARDEVC_SERIE_DOC_FISCAL = result[i++].Value?.ToString();
            dta.SIARDEVC_DATA_EMISSAO = result[i++].Value?.ToString();
            dta.SIARDEVC_DES_ENDERECO = result[i++].Value?.ToString();
            dta.SIARDEVC_NOM_BAIRRO = result[i++].Value?.ToString();
            dta.SIARDEVC_NOM_CIDADE = result[i++].Value?.ToString();
            dta.SIARDEVC_COD_UF = result[i++].Value?.ToString();
            dta.SIARDEVC_NUM_CEP = result[i++].Value?.ToString();
            dta.SIARDEVC_NUM_DDD = result[i++].Value?.ToString();
            dta.SIARDEVC_NUM_TELEFONE = result[i++].Value?.ToString();
            dta.SIARDEVC_IND_FORMA_PAGTO = result[i++].Value?.ToString();
            dta.SIARDEVC_NUM_IDENTIFICADOR = result[i++].Value?.ToString();
            dta.SIARDEVC_NUM_CHEQUE_INTERNO = result[i++].Value?.ToString();
            dta.SIARDEVC_ORDEM_PAGAMENTO_VC = result[i++].Value?.ToString();
            dta.SIARDEVC_ORDEM_PAGAMENTO = result[i++].Value?.ToString();
            dta.SIARDEVC_COD_BANCO = result[i++].Value?.ToString();
            dta.SIARDEVC_COD_AGENCIA = result[i++].Value?.ToString();
            dta.SIARDEVC_OPERACAO_CONTA = result[i++].Value?.ToString();
            dta.SIARDEVC_COD_CONTA = result[i++].Value?.ToString();
            dta.SIARDEVC_DV_CONTA = result[i++].Value?.ToString();
            dta.SIARDEVC_COD_FAVORECIDO = result[i++].Value?.ToString();
            dta.SIARDEVC_NUM_APOL_SINISTRO = result[i++].Value?.ToString();
            dta.SIARDEVC_STA_PROCESSAMENTO = result[i++].Value?.ToString();
            dta.SIARDEVC_COD_ERRO = result[i++].Value?.ToString();
            dta.SIARDEVC_VAL_PISPASEP = result[i++].Value?.ToString();
            dta.SIARDEVC_VAL_COFINS = result[i++].Value?.ToString();
            dta.SIARDEVC_VAL_CSLL = result[i++].Value?.ToString();
            dta.SIARDEVC_COD_FONTE = result[i++].Value?.ToString();
            dta.SIARDEVC_NUM_RESSARC = result[i++].Value?.ToString();
            dta.SIARDEVC_IND_PESSOA_ACORDO = result[i++].Value?.ToString();
            dta.SIARDEVC_NUM_CPFCGC_ACORDO = result[i++].Value?.ToString();
            dta.SIARDEVC_NOM_RESP_ACORDO = result[i++].Value?.ToString();
            dta.SIARDEVC_STA_ACORDO = result[i++].Value?.ToString();
            dta.SIARDEVC_DTH_INDENIZACAO = result[i++].Value?.ToString();
            dta.SIARDEVC_VLR_INDENIZACAO = result[i++].Value?.ToString();
            dta.SIARDEVC_VLR_PART_TERCEIROS = result[i++].Value?.ToString();
            dta.SIARDEVC_VLR_DIVIDA = result[i++].Value?.ToString();
            dta.SIARDEVC_PCT_DESCONTO = result[i++].Value?.ToString();
            dta.SIARDEVC_VLR_TOTAL_DESCONTO = result[i++].Value?.ToString();
            dta.SIARDEVC_VLR_TOTAL_ACORDO = result[i++].Value?.ToString();
            dta.SIARDEVC_COD_MOEDA_ACORDO = result[i++].Value?.ToString();
            dta.SIARDEVC_DTH_ACORDO = result[i++].Value?.ToString();
            dta.SIARDEVC_QTD_PARCELAS_ACORDO = result[i++].Value?.ToString();
            dta.SIARDEVC_NUM_PARCELA_ACORDO = result[i++].Value?.ToString();
            dta.SIARDEVC_COD_AGENCIA_CEDENT = result[i++].Value?.ToString();
            dta.SIARDEVC_NUM_CEDENTE = result[i++].Value?.ToString();
            dta.SIARDEVC_NUM_CEDENTE_DV = result[i++].Value?.ToString();
            dta.SIARDEVC_DTH_VENCIMENTO = result[i++].Value?.ToString();
            dta.SIARDEVC_NUM_NOSSO_TITULO = result[i++].Value?.ToString();
            dta.SIARDEVC_VLR_TITULO = result[i++].Value?.ToString();
            dta.SIARDEVC_NUM_CPFCGC_RECLAMANTE = result[i++].Value?.ToString();
            dta.SIARDEVC_NOM_RECLAMANTE = result[i++].Value?.ToString();
            dta.SIARDEVC_VLR_RECLAMADO = result[i++].Value?.ToString();
            dta.SIARDEVC_VLR_PROVISIONADO = result[i++].Value?.ToString();
            dta.SIARDEVC_NUM_SINISTRO_CONV = result[i++].Value?.ToString();
            dta.SIARDEVC_NUM_IDENT_CONV = result[i++].Value?.ToString();
            dta.SIARDEVC_NUM_IDE_COBR_CONV = result[i++].Value?.ToString();
            dta.SIARDEVC_COD_CFOP = result[i++].Value?.ToString();
            dta.SIARDEVC_COD_CEST = result[i++].Value?.ToString();
            dta.SIARDEVC_NUM_INSCR_ESTADUAL = result[i++].Value?.ToString();
            dta.SIARDEVC_NUM_NCM = result[i++].Value?.ToString();
            dta.SIARDEVC_NUM_CPF_CNPJ_TOMADOR = result[i++].Value?.ToString();
            dta.SIARDEVC_IND_ISENCAO_TRIBUTO = result[i++].Value?.ToString();
            dta.SIARDEVC_COD_IMPOSTO_LIMINAR = result[i++].Value?.ToString();
            dta.SIARDEVC_COD_PROCESSO_ISENCAO = result[i++].Value?.ToString();
            dta.SIARDEVC_VLR_RET_N_EFETUADO = result[i++].Value?.ToString();

            return dta;
        }

    }
}