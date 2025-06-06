using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmpresarial.DB2.VE2640B
{
    public class DB136_INCLUI_PROPOSTASVA_DB_INSERT_1_Insert1 : QueryBasis<DB136_INCLUI_PROPOSTASVA_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            INSERT INTO SEGUROS.PROPOSTAS_VA
            (NUM_CERTIFICADO
            ,COD_PRODUTO
            ,COD_CLIENTE
            ,OCOREND
            ,COD_FONTE
            ,AGE_COBRANCA
            ,OPCAO_COBERTURA
            ,DATA_QUITACAO
            ,COD_AGE_VENDEDOR
            ,OPE_CONTA_VENDEDOR
            ,NUM_CONTA_VENDEDOR
            ,DIG_CONTA_VENDEDOR
            ,NUM_MATRI_VENDEDOR
            ,COD_OPERACAO
            ,PROFISSAO
            ,DTINCLUS
            ,DATA_MOVIMENTO
            ,SIT_REGISTRO
            ,NUM_APOLICE
            ,COD_SUBGRUPO
            ,OCORR_HISTORICO
            ,NRPRIPARATZ
            ,QTDPARATZ
            ,DTPROXVEN
            ,NUM_PARCELA
            ,DATA_VENCIMENTO
            ,SIT_INTERFACE
            ,DTFENAE
            ,COD_USUARIO
            ,TIMESTAMP
            ,IDADE
            ,IDE_SEXO
            ,ESTADO_CIVIL
            ,OPCAO_MARCADA
            ,SIGLA_CRM
            ,COD_CRM
            ,APOS_INVALIDEZ
            ,ASSINATURA
            ,ACATAMENTO
            ,NOME_ESPOSA
            ,DTNASC_ESPOSA
            ,PROFIS_ESPOSA
            ,DPS_TITULAR
            ,DPS_ESPOSA
            ,NUM_MATRICULA
            ,GRAU_PARENTESCO
            ,DATA_ADMISSAO
            ,NUM_PROPOSTA
            ,EM_ATIVIDADE
            ,LOC_ATIVIDADE
            ,INFO_COMPLEMENTAR
            ,NRMALADIR
            ,NRCERTIFANT
            ,COD_CCT
            ,FAIXA_RENDA_IND
            ,FAIXA_RENDA_FAM
            ,COD_CORRESP_BANC
            ,STA_ANTECIPACAO
            ,STA_MUDANCA_PLANO
            ,DTA_DECLINIO
            )
            VALUES (:NUMEROUT-NUM-CERT-VGAP
            ,:PROPOVA-COD-PRODUTO
            ,:SUBGVGAP-COD-CLIENTE
            ,:SUBGVGAP-OCORR-ENDERECO
            ,:SUBGVGAP-COD-FONTE
            ,:PROPOVA-AGE-COBRANCA
            , ' '
            ,:PROPOVA-DATA-QUITACAO
            ,:TERMOADE-COD-AGENCIA-VEN
            ,:TERMOADE-OPERACAO-CONTA-VEN
            ,:TERMOADE-NUM-CONTA-VEN
            ,:TERMOADE-DIG-CONTA-VEN
            ,:TERMOADE-NUM-MATRICULA-VEN
            , 101
            , ' '
            ,:H-DT-MOV-ABERTO-2610
            ,:H-DT-MOV-ABERTO-2610
            ,:PROPOVA-SIT-REGISTRO
            ,:VGSOLFAT-NUM-APOLICE
            ,:VGSOLFAT-COD-SUBGRUPO
            , 1
            , 0
            , 0
            ,:PROPOVA-DTPROXVEN
            ,:PROPOVA-NUM-PARCELA
            ,:PROPOVA-DATA-VENCIMENTO
            , ' '
            , '9999-12-31'
            , 'VE2640B'
            , CURRENT TIMESTAMP
            , 0
            , ' '
            , ' '
            , ' '
            , NULL
            , NULL
            , NULL
            , NULL
            , NULL
            , NULL
            , NULL
            , NULL
            , NULL
            , NULL
            , 0
            , NULL
            , NULL
            ,:ENDOSSOS-NUM-PROPOSTA
            , NULL
            , NULL
            ,:PROPOVA-INFO-COMPLEMENTAR
            , NULL
            , NULL
            , NULL
            ,:H-FAIXA-RENDA
            ,:H-FAIXA-RENDA
            ,:PROPOVA-COD-CORRESP-BANC:N-COD-CORRESP-BANC
            ,:PROPOVA-STA-ANTECIPACAO:N-STA-ANTECIPACAO
            , NULL
            ,:PROPOVA-DTA-DECLINIO:N-DTA-DECLINIO
            )
            END-EXEC
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.PROPOSTAS_VA (NUM_CERTIFICADO ,COD_PRODUTO ,COD_CLIENTE ,OCOREND ,COD_FONTE ,AGE_COBRANCA ,OPCAO_COBERTURA ,DATA_QUITACAO ,COD_AGE_VENDEDOR ,OPE_CONTA_VENDEDOR ,NUM_CONTA_VENDEDOR ,DIG_CONTA_VENDEDOR ,NUM_MATRI_VENDEDOR ,COD_OPERACAO ,PROFISSAO ,DTINCLUS ,DATA_MOVIMENTO ,SIT_REGISTRO ,NUM_APOLICE ,COD_SUBGRUPO ,OCORR_HISTORICO ,NRPRIPARATZ ,QTDPARATZ ,DTPROXVEN ,NUM_PARCELA ,DATA_VENCIMENTO ,SIT_INTERFACE ,DTFENAE ,COD_USUARIO ,TIMESTAMP ,IDADE ,IDE_SEXO ,ESTADO_CIVIL ,OPCAO_MARCADA ,SIGLA_CRM ,COD_CRM ,APOS_INVALIDEZ ,ASSINATURA ,ACATAMENTO ,NOME_ESPOSA ,DTNASC_ESPOSA ,PROFIS_ESPOSA ,DPS_TITULAR ,DPS_ESPOSA ,NUM_MATRICULA ,GRAU_PARENTESCO ,DATA_ADMISSAO ,NUM_PROPOSTA ,EM_ATIVIDADE ,LOC_ATIVIDADE ,INFO_COMPLEMENTAR ,NRMALADIR ,NRCERTIFANT ,COD_CCT ,FAIXA_RENDA_IND ,FAIXA_RENDA_FAM ,COD_CORRESP_BANC ,STA_ANTECIPACAO ,STA_MUDANCA_PLANO ,DTA_DECLINIO ) VALUES ({FieldThreatment(this.NUMEROUT_NUM_CERT_VGAP)} ,{FieldThreatment(this.PROPOVA_COD_PRODUTO)} ,{FieldThreatment(this.SUBGVGAP_COD_CLIENTE)} ,{FieldThreatment(this.SUBGVGAP_OCORR_ENDERECO)} ,{FieldThreatment(this.SUBGVGAP_COD_FONTE)} ,{FieldThreatment(this.PROPOVA_AGE_COBRANCA)} , ' ' ,{FieldThreatment(this.PROPOVA_DATA_QUITACAO)} ,{FieldThreatment(this.TERMOADE_COD_AGENCIA_VEN)} ,{FieldThreatment(this.TERMOADE_OPERACAO_CONTA_VEN)} ,{FieldThreatment(this.TERMOADE_NUM_CONTA_VEN)} ,{FieldThreatment(this.TERMOADE_DIG_CONTA_VEN)} ,{FieldThreatment(this.TERMOADE_NUM_MATRICULA_VEN)} , 101 , ' ' ,{FieldThreatment(this.H_DT_MOV_ABERTO_2610)} ,{FieldThreatment(this.H_DT_MOV_ABERTO_2610)} ,{FieldThreatment(this.PROPOVA_SIT_REGISTRO)} ,{FieldThreatment(this.VGSOLFAT_NUM_APOLICE)} ,{FieldThreatment(this.VGSOLFAT_COD_SUBGRUPO)} , 1 , 0 , 0 ,{FieldThreatment(this.PROPOVA_DTPROXVEN)} ,{FieldThreatment(this.PROPOVA_NUM_PARCELA)} ,{FieldThreatment(this.PROPOVA_DATA_VENCIMENTO)} , ' ' , '9999-12-31' , 'VE2640B' , CURRENT TIMESTAMP , 0 , ' ' , ' ' , ' ' , NULL , NULL , NULL , NULL , NULL , NULL , NULL , NULL , NULL , NULL , 0 , NULL , NULL ,{FieldThreatment(this.ENDOSSOS_NUM_PROPOSTA)} , NULL , NULL ,{FieldThreatment(this.PROPOVA_INFO_COMPLEMENTAR)} , NULL , NULL , NULL ,{FieldThreatment(this.H_FAIXA_RENDA)} ,{FieldThreatment(this.H_FAIXA_RENDA)} , {FieldThreatment((this.N_COD_CORRESP_BANC?.ToInt() == -1 ? null : this.PROPOVA_COD_CORRESP_BANC))} , {FieldThreatment((this.N_STA_ANTECIPACAO?.ToInt() == -1 ? null : this.PROPOVA_STA_ANTECIPACAO))} , NULL , {FieldThreatment((this.N_DTA_DECLINIO?.ToInt() == -1 ? null : this.PROPOVA_DTA_DECLINIO))} )";

            return query;
        }
        public string NUMEROUT_NUM_CERT_VGAP { get; set; }
        public string PROPOVA_COD_PRODUTO { get; set; }
        public string SUBGVGAP_COD_CLIENTE { get; set; }
        public string SUBGVGAP_OCORR_ENDERECO { get; set; }
        public string SUBGVGAP_COD_FONTE { get; set; }
        public string PROPOVA_AGE_COBRANCA { get; set; }
        public string PROPOVA_DATA_QUITACAO { get; set; }
        public string TERMOADE_COD_AGENCIA_VEN { get; set; }
        public string TERMOADE_OPERACAO_CONTA_VEN { get; set; }
        public string TERMOADE_NUM_CONTA_VEN { get; set; }
        public string TERMOADE_DIG_CONTA_VEN { get; set; }
        public string TERMOADE_NUM_MATRICULA_VEN { get; set; }
        public string H_DT_MOV_ABERTO_2610 { get; set; }
        public string PROPOVA_SIT_REGISTRO { get; set; }
        public string VGSOLFAT_NUM_APOLICE { get; set; }
        public string VGSOLFAT_COD_SUBGRUPO { get; set; }
        public string PROPOVA_DTPROXVEN { get; set; }
        public string PROPOVA_NUM_PARCELA { get; set; }
        public string PROPOVA_DATA_VENCIMENTO { get; set; }
        public string ENDOSSOS_NUM_PROPOSTA { get; set; }
        public string PROPOVA_INFO_COMPLEMENTAR { get; set; }
        public string H_FAIXA_RENDA { get; set; }
        public string PROPOVA_COD_CORRESP_BANC { get; set; }
        public string N_COD_CORRESP_BANC { get; set; }
        public string PROPOVA_STA_ANTECIPACAO { get; set; }
        public string N_STA_ANTECIPACAO { get; set; }
        public string PROPOVA_DTA_DECLINIO { get; set; }
        public string N_DTA_DECLINIO { get; set; }

        public static void Execute(DB136_INCLUI_PROPOSTASVA_DB_INSERT_1_Insert1 dB136_INCLUI_PROPOSTASVA_DB_INSERT_1_Insert1)
        {
            var ths = dB136_INCLUI_PROPOSTASVA_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override DB136_INCLUI_PROPOSTASVA_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}