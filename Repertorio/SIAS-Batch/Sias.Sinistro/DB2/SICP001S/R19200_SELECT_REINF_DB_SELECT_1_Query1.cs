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
    public class R19200_SELECT_REINF_DB_SELECT_1_Query1 : QueryBasis<R19200_SELECT_REINF_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT
            SINISLAN.COD_FONTE
            ,SINISLAN.NUM_LOTE
            ,SINISLAN.NUM_APOL_SINISTRO
            ,SINISLAN.OCORR_HISTORICO
            ,SINISLAN.COD_OPERACAO
            ,SINISLAN.VAL_OPERACAO
            ,VALUE(SINISLAN.COD_PROCESSO_JURID, ' ' )
            ,VALUE(SINISLAN.SEQ_TP_SERVICO_INSS,0)
            ,VALUE(SINISLAN.SEQ_INDICATIVO_OBRA,0)
            ,VALUE(SINISLAN.COD_NACIONAL_OBRA, 0)
            ,VALUE(SINISLAN.VLR_CUSTO_N_BASE_INSS, 0)
            ,VALUE(SINISLAN.VLR_BASE_CALCULO_INSS, 0)
            ,VALUE(SINISLAN.VLR_INSS_SUBCONTRATO, 0)
            ,VALUE(SINISCAP.NUM_DOCF_INTERNO, 0)
            ,VALUE(SINISCAP.NUM_CPF_CNPJ_FAVOREC, 0)
            ,VALUE(SINISCAP.NUM_CPF_CNPJ_TOMADOR, 0)
            ,VALUE(SINISCAP.SEQ_CNAE_CPRB, 0)
            ,VALUE(SINISCAP.VLR_TOTAL_DOCUMENTO, 0)
            ,VALUE(SINISCAP.IND_GRUPO_LANCAMENTO, ' ' )
            ,VALUE(SINISCAP.IND_ISENCAO_TRIBUTO, ' ' )
            ,VALUE(SINISCAP.COD_IMPOSTO_LIMINAR, 0)
            ,LTRIM(VALUE(SINISCAP.COD_PROCESSO_ISENCAO, ' ' ))
            ,VALUE(SINISCAP.VLR_RET_N_EFETUADO, 0)
            ,VALUE(SINISCAP.PCT_CPRB, 0)
            ,VALUE(SINISCAP.IND_DESC_INSS, 'S' )
            ,VALUE(SINISCAP.COD_SERVICO_CONTABIL, '' )
            ,VALUE(SINISCAP.COD_NAT_RENDIMENTO,0)
            ,VALUE(SINISCAP.COD_IMPOSTO_ISS, '' )
            ,VALUE(SINISCAP.PCT_ALIQ_ISS,0)
            INTO :SINISLAN-COD-FONTE
            ,:SINISLAN-NUM-LOTE
            ,:SINISLAN-NUM-APOL-SINISTRO
            ,:SINISLAN-OCORR-HISTORICO
            ,:SINISLAN-COD-OPERACAO
            ,:SINISLAN-VAL-OPERACAO
            ,:SINISLAN-COD-PROCESSO-JURID
            ,:SINISLAN-SEQ-TP-SERVICO-INSS
            ,:SINISLAN-SEQ-INDICATIVO-OBRA
            ,:SINISLAN-COD-NACIONAL-OBRA
            ,:SINISLAN-VLR-CUSTO-N-BASE-INSS
            ,:SINISLAN-VLR-BASE-CALCULO-INSS
            ,:SINISLAN-VLR-INSS-SUBCONTRATO
            ,:SINISCAP-NUM-DOCF-INTERNO
            ,:SINISCAP-NUM-CPF-CNPJ-FAVOREC
            ,:SINISCAP-NUM-CPF-CNPJ-TOMADOR
            ,:SINISCAP-SEQ-CNAE-CPRB
            ,:SINISCAP-VLR-TOTAL-DOCUMENTO
            ,:SINISCAP-IND-GRUPO-LANCAMENTO
            ,:SINISCAP-IND-ISENCAO-TRIBUTO
            ,:SINISCAP-COD-IMPOSTO-LIMINAR
            ,:SINISCAP-COD-PROCESSO-ISENCAO
            ,:SINISCAP-VLR-RET-N-EFETUADO
            ,:SINISCAP-PCT-CPRB
            ,:SINISCAP-IND-DESC-INSS
            ,:SINISCAP-COD-SERVICO-CONTABIL
            ,:SINISCAP-COD-NAT-RENDIMENTO
            ,:SINISCAP-COD-IMPOSTO-ISS
            ,:SINISCAP-PCT-ALIQ-ISS
            FROM SEGUROS.SINISTRO_CAPALOTE1 SINISCAP
            ,SEGUROS.SINISTRO_LANCLOTE1 SINISLAN
            ,SEGUROS.GE_OPERACAO O
            WHERE SINISLAN.NUM_APOL_SINISTRO =
            :SINISHIS-NUM-APOL-SINISTRO
            AND SINISLAN.OCORR_HISTORICO =
            :SINISHIS-OCORR-HISTORICO
            AND O.COD_OPERACAO = SINISLAN.COD_OPERACAO
            AND O.IDE_SISTEMA = 'SI'
            AND O.IND_TIPO_FUNCAO = :W-LIB
            AND SINISCAP.COD_FONTE = SINISLAN.COD_FONTE
            AND SINISCAP.NUM_LOTE = SINISLAN.NUM_LOTE
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT
											SINISLAN.COD_FONTE
											,SINISLAN.NUM_LOTE
											,SINISLAN.NUM_APOL_SINISTRO
											,SINISLAN.OCORR_HISTORICO
											,SINISLAN.COD_OPERACAO
											,SINISLAN.VAL_OPERACAO
											,VALUE(SINISLAN.COD_PROCESSO_JURID
							, ' ' )
											,VALUE(SINISLAN.SEQ_TP_SERVICO_INSS
							,0)
											,VALUE(SINISLAN.SEQ_INDICATIVO_OBRA
							,0)
											,VALUE(SINISLAN.COD_NACIONAL_OBRA
							, 0)
											,VALUE(SINISLAN.VLR_CUSTO_N_BASE_INSS
							, 0)
											,VALUE(SINISLAN.VLR_BASE_CALCULO_INSS
							, 0)
											,VALUE(SINISLAN.VLR_INSS_SUBCONTRATO
							, 0)
											,VALUE(SINISCAP.NUM_DOCF_INTERNO
							, 0)
											,VALUE(SINISCAP.NUM_CPF_CNPJ_FAVOREC
							, 0)
											,VALUE(SINISCAP.NUM_CPF_CNPJ_TOMADOR
							, 0)
											,VALUE(SINISCAP.SEQ_CNAE_CPRB
							, 0)
											,VALUE(SINISCAP.VLR_TOTAL_DOCUMENTO
							, 0)
											,VALUE(SINISCAP.IND_GRUPO_LANCAMENTO
							, ' ' )
											,VALUE(SINISCAP.IND_ISENCAO_TRIBUTO
							, ' ' )
											,VALUE(SINISCAP.COD_IMPOSTO_LIMINAR
							, 0)
											,LTRIM(VALUE(SINISCAP.COD_PROCESSO_ISENCAO
							, ' ' ))
											,VALUE(SINISCAP.VLR_RET_N_EFETUADO
							, 0)
											,VALUE(SINISCAP.PCT_CPRB
							, 0)
											,VALUE(SINISCAP.IND_DESC_INSS
							, 'S' )
											,VALUE(SINISCAP.COD_SERVICO_CONTABIL
							, '' )
											,VALUE(SINISCAP.COD_NAT_RENDIMENTO
							,0)
											,VALUE(SINISCAP.COD_IMPOSTO_ISS
							, '' )
											,VALUE(SINISCAP.PCT_ALIQ_ISS
							,0)
											FROM SEGUROS.SINISTRO_CAPALOTE1 SINISCAP
											,SEGUROS.SINISTRO_LANCLOTE1 SINISLAN
											,SEGUROS.GE_OPERACAO O
											WHERE SINISLAN.NUM_APOL_SINISTRO =
											'{this.SINISHIS_NUM_APOL_SINISTRO}'
											AND SINISLAN.OCORR_HISTORICO =
											'{this.SINISHIS_OCORR_HISTORICO}'
											AND O.COD_OPERACAO = SINISLAN.COD_OPERACAO
											AND O.IDE_SISTEMA = 'SI'
											AND O.IND_TIPO_FUNCAO = '{this.W_LIB}'
											AND SINISCAP.COD_FONTE = SINISLAN.COD_FONTE
											AND SINISCAP.NUM_LOTE = SINISLAN.NUM_LOTE";

            return query;
        }
        public string SINISLAN_COD_FONTE { get; set; }
        public string SINISLAN_NUM_LOTE { get; set; }
        public string SINISLAN_NUM_APOL_SINISTRO { get; set; }
        public string SINISLAN_OCORR_HISTORICO { get; set; }
        public string SINISLAN_COD_OPERACAO { get; set; }
        public string SINISLAN_VAL_OPERACAO { get; set; }
        public string SINISLAN_COD_PROCESSO_JURID { get; set; }
        public string SINISLAN_SEQ_TP_SERVICO_INSS { get; set; }
        public string SINISLAN_SEQ_INDICATIVO_OBRA { get; set; }
        public string SINISLAN_COD_NACIONAL_OBRA { get; set; }
        public string SINISLAN_VLR_CUSTO_N_BASE_INSS { get; set; }
        public string SINISLAN_VLR_BASE_CALCULO_INSS { get; set; }
        public string SINISLAN_VLR_INSS_SUBCONTRATO { get; set; }
        public string SINISCAP_NUM_DOCF_INTERNO { get; set; }
        public string SINISCAP_NUM_CPF_CNPJ_FAVOREC { get; set; }
        public string SINISCAP_NUM_CPF_CNPJ_TOMADOR { get; set; }
        public string SINISCAP_SEQ_CNAE_CPRB { get; set; }
        public string SINISCAP_VLR_TOTAL_DOCUMENTO { get; set; }
        public string SINISCAP_IND_GRUPO_LANCAMENTO { get; set; }
        public string SINISCAP_IND_ISENCAO_TRIBUTO { get; set; }
        public string SINISCAP_COD_IMPOSTO_LIMINAR { get; set; }
        public string SINISCAP_COD_PROCESSO_ISENCAO { get; set; }
        public string SINISCAP_VLR_RET_N_EFETUADO { get; set; }
        public string SINISCAP_PCT_CPRB { get; set; }
        public string SINISCAP_IND_DESC_INSS { get; set; }
        public string SINISCAP_COD_SERVICO_CONTABIL { get; set; }
        public string SINISCAP_COD_NAT_RENDIMENTO { get; set; }
        public string SINISCAP_COD_IMPOSTO_ISS { get; set; }
        public string SINISCAP_PCT_ALIQ_ISS { get; set; }
        public string SINISHIS_NUM_APOL_SINISTRO { get; set; }
        public string SINISHIS_OCORR_HISTORICO { get; set; }
        public string W_LIB { get; set; }

        public static R19200_SELECT_REINF_DB_SELECT_1_Query1 Execute(R19200_SELECT_REINF_DB_SELECT_1_Query1 r19200_SELECT_REINF_DB_SELECT_1_Query1)
        {
            var ths = r19200_SELECT_REINF_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R19200_SELECT_REINF_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R19200_SELECT_REINF_DB_SELECT_1_Query1();
            var i = 0;
            dta.SINISLAN_COD_FONTE = result[i++].Value?.ToString();
            dta.SINISLAN_NUM_LOTE = result[i++].Value?.ToString();
            dta.SINISLAN_NUM_APOL_SINISTRO = result[i++].Value?.ToString();
            dta.SINISLAN_OCORR_HISTORICO = result[i++].Value?.ToString();
            dta.SINISLAN_COD_OPERACAO = result[i++].Value?.ToString();
            dta.SINISLAN_VAL_OPERACAO = result[i++].Value?.ToString();
            dta.SINISLAN_COD_PROCESSO_JURID = result[i++].Value?.ToString();
            dta.SINISLAN_SEQ_TP_SERVICO_INSS = result[i++].Value?.ToString();
            dta.SINISLAN_SEQ_INDICATIVO_OBRA = result[i++].Value?.ToString();
            dta.SINISLAN_COD_NACIONAL_OBRA = result[i++].Value?.ToString();
            dta.SINISLAN_VLR_CUSTO_N_BASE_INSS = result[i++].Value?.ToString();
            dta.SINISLAN_VLR_BASE_CALCULO_INSS = result[i++].Value?.ToString();
            dta.SINISLAN_VLR_INSS_SUBCONTRATO = result[i++].Value?.ToString();
            dta.SINISCAP_NUM_DOCF_INTERNO = result[i++].Value?.ToString();
            dta.SINISCAP_NUM_CPF_CNPJ_FAVOREC = result[i++].Value?.ToString();
            dta.SINISCAP_NUM_CPF_CNPJ_TOMADOR = result[i++].Value?.ToString();
            dta.SINISCAP_SEQ_CNAE_CPRB = result[i++].Value?.ToString();
            dta.SINISCAP_VLR_TOTAL_DOCUMENTO = result[i++].Value?.ToString();
            dta.SINISCAP_IND_GRUPO_LANCAMENTO = result[i++].Value?.ToString();
            dta.SINISCAP_IND_ISENCAO_TRIBUTO = result[i++].Value?.ToString();
            dta.SINISCAP_COD_IMPOSTO_LIMINAR = result[i++].Value?.ToString();
            dta.SINISCAP_COD_PROCESSO_ISENCAO = result[i++].Value?.ToString();
            dta.SINISCAP_VLR_RET_N_EFETUADO = result[i++].Value?.ToString();
            dta.SINISCAP_PCT_CPRB = result[i++].Value?.ToString();
            dta.SINISCAP_IND_DESC_INSS = result[i++].Value?.ToString();
            dta.SINISCAP_COD_SERVICO_CONTABIL = result[i++].Value?.ToString();
            dta.SINISCAP_COD_NAT_RENDIMENTO = result[i++].Value?.ToString();
            dta.SINISCAP_COD_IMPOSTO_ISS = result[i++].Value?.ToString();
            dta.SINISCAP_PCT_ALIQ_ISS = result[i++].Value?.ToString();
            return dta;
        }

    }
}