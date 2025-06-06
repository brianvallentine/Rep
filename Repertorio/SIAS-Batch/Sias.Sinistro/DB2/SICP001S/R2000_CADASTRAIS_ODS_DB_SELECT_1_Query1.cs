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
    public class R2000_CADASTRAIS_ODS_DB_SELECT_1_Query1 : QueryBasis<R2000_CADASTRAIS_ODS_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT
            H.NUM_APOL_SINISTRO AS "NUM SINISTRO",
            H.OCORR_HISTORICO AS "OCORRHIST",
            H.COD_OPERACAO AS "OPERACAO",
            OPE.FUNCAO_OPERACAO AS "FUNCAO OPERACAO",
            SUBSTR(OPE.DES_OPERACAO,1,30)
            AS "NOME OPERACAO",
            LEGPES.NUM_OCORR_MOVTO AS "NUM_OCORR_MOVTO",
            LEGPES.NUM_PESSOA AS "NUM. PESSOA",
            PE.IND_PESSOA AS "TIPO PESSOA",
            DIGITS(DECIMAL(PF.NUM_CPF,9,0))
            ||DIGITS(DECIMAL(PF.NUM_DV_CPF,2,0))
            AS "CPF DO FAVORECIDO",
            SUBSTR(PF.NOM_PESSOA,1,100)
            AS "NOME_FAVORECIDO",
            0 AS "INSCRICAO MUNICIPAL",
            0 AS "INSCRICAO ESTADUAL",
            PF.NUM_INSC_SOCIAL AS "INSCRICAO SOCIAL",
            PF.NUM_DV_INSC_SOCIAL AS "DV INSCRICAO SOCIAL",
            DIGITS(DECIMAL(PJ.NUM_CNPJ,8,0))
            ||DIGITS(DECIMAL(PJ.NUM_FILIAL,4,0))
            ||DIGITS(DECIMAL(PJ.NUM_DV_CNPJ,2,0))
            AS "CNPJ DO FAVORECIDO",
            SUBSTR(PJ.NOM_RAZAO_SOCIAL,1,100)
            AS "RAZAO SOCIAL",
            PJ.NUM_INSC_MUNICIPAL AS "INSCRICAO MUNICIPAL",
            PJ.NUM_INSC_ESTADUAL AS "INSCRICAO ESTADUAL",
            0 AS "INSCRICAO SOCIAL",
            0 AS "DV INSCRICAO SOCIAL",
            PESEND.NOM_LOGRADOURO AS "LOGRADOURO",
            PESEND.DES_NUM_IMOVEL AS "NUM IMOVEL",
            PESEND.DES_COMPL_ENDERECO
            AS "COMPLEMENTO",
            PESEND.NOM_BAIRRO AS "BAIRRO",
            PESEND.NOM_CIDADE AS "CIDADE",
            PESEND.COD_CEP AS "CEP",
            PESEND.COD_UF AS "UF",
            H.NOME_FAVORECIDO AS "NOME_FAVORECIDO_HIST",
            OPE.IND_TIPO_FUNCAO AS "TIPO FUNCAO OPERACAO"
            INTO
            :SINISHIS-NUM-APOL-SINISTRO,
            :SINISHIS-OCORR-HISTORICO,
            :SINISHIS-COD-OPERACAO,
            :GEOPERAC-FUNCAO-OPERACAO,
            :GEOPERAC-DES-OPERACAO,
            :GE368-NUM-OCORR-MOVTO,
            :GE368-NUM-PESSOA,
            :OD001-IND-PESSOA,
            :W-NUMERO-CPF-BASE:NULL-NUM-CPF,
            :OD002-NOM-PESSOA:NULL-NOM-PESSOA,
            :W-PF-INSC-PREFEITURA:NULL-PF-INSC-PREFEITURA,
            :W-PF-INSC-ESTADUAL:NULL-PF-INSC-ESTADUAL,
            :W-PF-NUM-INSC-SOCIAL:NULL-PF-NUM-INSC-SOCIAL,
            :W-PF-NUM-DV-INSC-SOCIAL:NULL-PF-NUM-DV-INSC-SOCIAL,
            :W-NUMERO-CNPJ-BASE:NULL-NUM-CNPJ,
            :OD003-NOM-RAZAO-SOCIAL:NULL-NOM-RAZAO-SOCIAL,
            :W-PJ-INSC-PREFEITURA:NULL-PJ-INSC-PREFEITURA,
            :W-PJ-INSC-ESTADUAL:NULL-PJ-INSC-ESTADUAL,
            :W-PJ-NUM-INSC-SOCIAL:NULL-PJ-NUM-INSC-SOCIAL,
            :W-PJ-NUM-DV-INSC-SOCIAL:NULL-PJ-NUM-DV-INSC-SOCIAL,
            :OD007-NOM-LOGRADOURO:NULL-NOM-LOGRADOURO,
            :OD007-DES-NUM-IMOVEL:NULL-DES-NUM-IMOVEL,
            :OD007-DES-COMPL-ENDERECO:NULL-DES-COMPL-ENDERECO,
            :OD007-NOM-BAIRRO:NULL-NOM-BAIRRO,
            :OD007-NOM-CIDADE:NULL-NOM-CIDADE,
            :OD007-COD-CEP:NULL-COD-CEP,
            :OD007-COD-UF:NULL-COD-UF,
            :SINISHIS-NOME-FAVORECIDO,
            :GEOPERAC-IND-TIPO-FUNCAO
            FROM
            SEGUROS.SINISTRO_HISTORICO H,
            SEGUROS.GE_OPERACAO OPE,
            SEGUROS.SI_PESS_SINISTRO SIPES,
            SEGUROS.GE_LEG_PESS_EVENTO LEGPES
            LEFT JOIN ODS.OD_PESSOA PE
            ON PE.NUM_PESSOA = LEGPES.NUM_PESSOA
            LEFT JOIN ODS.OD_PESSOA_FISICA PF
            ON PF.NUM_PESSOA = LEGPES.NUM_PESSOA
            LEFT JOIN ODS.OD_PESSOA_JURIDICA PJ
            ON PJ.NUM_PESSOA = LEGPES.NUM_PESSOA
            LEFT JOIN ODS.OD_PESSOA_ENDERECO PESEND
            ON PESEND.NUM_PESSOA = LEGPES.NUM_PESSOA
            AND PESEND.SEQ_ENDERECO = LEGPES.SEQ_ENTIDADE
            WHERE SIPES.NUM_APOL_SINISTRO = H.NUM_APOL_SINISTRO
            AND SIPES.OCORR_HISTORICO = H.OCORR_HISTORICO
            AND SIPES.COD_OPERACAO = H.COD_OPERACAO
            AND LEGPES.NUM_OCORR_MOVTO = SIPES.NUM_OCORR_MOVTO
            AND LEGPES.IND_ENTIDADE = 1
            AND OPE.IDE_SISTEMA = 'SI'
            AND OPE.COD_OPERACAO = H.COD_OPERACAO
            AND H.NUM_APOL_SINISTRO = :SINISHIS-NUM-APOL-SINISTRO
            AND H.OCORR_HISTORICO = :SINISHIS-OCORR-HISTORICO
            AND H.COD_PREST_SERVICO <> 891733
            AND H.NOME_FAVORECIDO <> 'CAIXA SEGURADORA S A'
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT
											H.NUM_APOL_SINISTRO AS NUMSINISTRO
							,
											H.OCORR_HISTORICO AS OCORRHIST
							,
											H.COD_OPERACAO AS OPERACAO
							,
											OPE.FUNCAO_OPERACAO AS FUNCAOOPERACAO
							,
											SUBSTR(OPE.DES_OPERACAO
							,1
							,30)
											AS NOMEOPERACAO
							,
											LEGPES.NUM_OCORR_MOVTO AS NUM_OCORR_MOVTO
							,
											LEGPES.NUM_PESSOA AS NUMPESSOA
							,
											PE.IND_PESSOA AS TIPOPESSOA
							,
											DIGITS(DECIMAL(PF.NUM_CPF
							,9
							,0))
											||DIGITS(DECIMAL(PF.NUM_DV_CPF
							,2
							,0))
											AS CPFDOFAVORECIDO
							,
											SUBSTR(PF.NOM_PESSOA
							,1
							,100)
											AS NOME_FAVORECIDO
							,
											0 AS INSCRICAOMUNICIPAL
							,
											0 AS INSCRICAOESTADUAL
							,
											PF.NUM_INSC_SOCIAL AS INSCRICAOSOCIAL
							,
											PF.NUM_DV_INSC_SOCIAL AS DVINSCRICAOSOCIAL
							,
											DIGITS(DECIMAL(PJ.NUM_CNPJ
							,8
							,0))
											||DIGITS(DECIMAL(PJ.NUM_FILIAL
							,4
							,0))
											||DIGITS(DECIMAL(PJ.NUM_DV_CNPJ
							,2
							,0))
											AS CNPJDOFAVORECIDO
							,
											SUBSTR(PJ.NOM_RAZAO_SOCIAL
							,1
							,100)
											AS RAZAOSOCIAL
							,
											PJ.NUM_INSC_MUNICIPAL AS INSCRICAOMUNICIPAL
							,
											PJ.NUM_INSC_ESTADUAL AS INSCRICAOESTADUAL
							,
											0 AS INSCRICAOSOCIAL
							,
											0 AS DVINSCRICAOSOCIAL
							,
											PESEND.NOM_LOGRADOURO AS LOGRADOURO
							,
											PESEND.DES_NUM_IMOVEL AS NUMIMOVEL
							,
											PESEND.DES_COMPL_ENDERECO
											AS COMPLEMENTO
							,
											PESEND.NOM_BAIRRO AS BAIRRO
							,
											PESEND.NOM_CIDADE AS CIDADE
							,
											PESEND.COD_CEP AS CEP
							,
											PESEND.COD_UF AS UF
							,
											H.NOME_FAVORECIDO AS NOME_FAVORECIDO_HIST
							,
											OPE.IND_TIPO_FUNCAO AS TIPOFUNCAOOPERACAO
											FROM
											SEGUROS.SINISTRO_HISTORICO H
							,
											SEGUROS.GE_OPERACAO OPE
							,
											SEGUROS.SI_PESS_SINISTRO SIPES
							,
											SEGUROS.GE_LEG_PESS_EVENTO LEGPES
											LEFT
							JOIN ODS.OD_PESSOA PE
											ON PE.NUM_PESSOA = LEGPES.NUM_PESSOA
											LEFT
							JOIN ODS.OD_PESSOA_FISICA PF
											ON PF.NUM_PESSOA = LEGPES.NUM_PESSOA
											LEFT
							JOIN ODS.OD_PESSOA_JURIDICA PJ
											ON PJ.NUM_PESSOA = LEGPES.NUM_PESSOA
											LEFT
							JOIN ODS.OD_PESSOA_ENDERECO PESEND
											ON PESEND.NUM_PESSOA = LEGPES.NUM_PESSOA
											AND PESEND.SEQ_ENDERECO = LEGPES.SEQ_ENTIDADE
											WHERE SIPES.NUM_APOL_SINISTRO = H.NUM_APOL_SINISTRO
											AND SIPES.OCORR_HISTORICO = H.OCORR_HISTORICO
											AND SIPES.COD_OPERACAO = H.COD_OPERACAO
											AND LEGPES.NUM_OCORR_MOVTO = SIPES.NUM_OCORR_MOVTO
											AND LEGPES.IND_ENTIDADE = 1
											AND OPE.IDE_SISTEMA = 'SI'
											AND OPE.COD_OPERACAO = H.COD_OPERACAO
											AND H.NUM_APOL_SINISTRO = '{this.SINISHIS_NUM_APOL_SINISTRO}'
											AND H.OCORR_HISTORICO = '{this.SINISHIS_OCORR_HISTORICO}'
											AND H.COD_PREST_SERVICO <> 891733
											AND H.NOME_FAVORECIDO <> 'CAIXA SEGURADORA S A'";

            return query;
        }
        public string SINISHIS_NUM_APOL_SINISTRO { get; set; }
        public string SINISHIS_OCORR_HISTORICO { get; set; }
        public string SINISHIS_COD_OPERACAO { get; set; }
        public string GEOPERAC_FUNCAO_OPERACAO { get; set; }
        public string GEOPERAC_DES_OPERACAO { get; set; }
        public string GE368_NUM_OCORR_MOVTO { get; set; }
        public string GE368_NUM_PESSOA { get; set; }
        public string OD001_IND_PESSOA { get; set; }
        public string W_NUMERO_CPF_BASE { get; set; }
        public string NULL_NUM_CPF { get; set; }
        public string OD002_NOM_PESSOA { get; set; }
        public string NULL_NOM_PESSOA { get; set; }
        public string W_PF_INSC_PREFEITURA { get; set; }
        public string NULL_PF_INSC_PREFEITURA { get; set; }
        public string W_PF_INSC_ESTADUAL { get; set; }
        public string NULL_PF_INSC_ESTADUAL { get; set; }
        public string W_PF_NUM_INSC_SOCIAL { get; set; }
        public string NULL_PF_NUM_INSC_SOCIAL { get; set; }
        public string W_PF_NUM_DV_INSC_SOCIAL { get; set; }
        public string NULL_PF_NUM_DV_INSC_SOCIAL { get; set; }
        public string W_NUMERO_CNPJ_BASE { get; set; }
        public string NULL_NUM_CNPJ { get; set; }
        public string OD003_NOM_RAZAO_SOCIAL { get; set; }
        public string NULL_NOM_RAZAO_SOCIAL { get; set; }
        public string W_PJ_INSC_PREFEITURA { get; set; }
        public string NULL_PJ_INSC_PREFEITURA { get; set; }
        public string W_PJ_INSC_ESTADUAL { get; set; }
        public string NULL_PJ_INSC_ESTADUAL { get; set; }
        public string W_PJ_NUM_INSC_SOCIAL { get; set; }
        public string NULL_PJ_NUM_INSC_SOCIAL { get; set; }
        public string W_PJ_NUM_DV_INSC_SOCIAL { get; set; }
        public string NULL_PJ_NUM_DV_INSC_SOCIAL { get; set; }
        public string OD007_NOM_LOGRADOURO { get; set; }
        public string NULL_NOM_LOGRADOURO { get; set; }
        public string OD007_DES_NUM_IMOVEL { get; set; }
        public string NULL_DES_NUM_IMOVEL { get; set; }
        public string OD007_DES_COMPL_ENDERECO { get; set; }
        public string NULL_DES_COMPL_ENDERECO { get; set; }
        public string OD007_NOM_BAIRRO { get; set; }
        public string NULL_NOM_BAIRRO { get; set; }
        public string OD007_NOM_CIDADE { get; set; }
        public string NULL_NOM_CIDADE { get; set; }
        public string OD007_COD_CEP { get; set; }
        public string NULL_COD_CEP { get; set; }
        public string OD007_COD_UF { get; set; }
        public string NULL_COD_UF { get; set; }
        public string SINISHIS_NOME_FAVORECIDO { get; set; }
        public string GEOPERAC_IND_TIPO_FUNCAO { get; set; }

        public static R2000_CADASTRAIS_ODS_DB_SELECT_1_Query1 Execute(R2000_CADASTRAIS_ODS_DB_SELECT_1_Query1 r2000_CADASTRAIS_ODS_DB_SELECT_1_Query1)
        {
            var ths = r2000_CADASTRAIS_ODS_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R2000_CADASTRAIS_ODS_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R2000_CADASTRAIS_ODS_DB_SELECT_1_Query1();
            var i = 0;
            dta.SINISHIS_NUM_APOL_SINISTRO = result[i++].Value?.ToString();
            dta.SINISHIS_OCORR_HISTORICO = result[i++].Value?.ToString();
            dta.SINISHIS_COD_OPERACAO = result[i++].Value?.ToString();
            dta.GEOPERAC_FUNCAO_OPERACAO = result[i++].Value?.ToString();
            dta.GEOPERAC_DES_OPERACAO = result[i++].Value?.ToString();
            dta.GE368_NUM_OCORR_MOVTO = result[i++].Value?.ToString();
            dta.GE368_NUM_PESSOA = result[i++].Value?.ToString();
            dta.OD001_IND_PESSOA = result[i++].Value?.ToString();
            dta.W_NUMERO_CPF_BASE = result[i++].Value?.ToString();
            dta.NULL_NUM_CPF = string.IsNullOrWhiteSpace(dta.W_NUMERO_CPF_BASE) ? "-1" : "0";
            dta.OD002_NOM_PESSOA = result[i++].Value?.ToString();
            dta.NULL_NOM_PESSOA = string.IsNullOrWhiteSpace(dta.OD002_NOM_PESSOA) ? "-1" : "0";
            dta.W_PF_INSC_PREFEITURA = result[i++].Value?.ToString();
            dta.NULL_PF_INSC_PREFEITURA = string.IsNullOrWhiteSpace(dta.W_PF_INSC_PREFEITURA) ? "-1" : "0";
            dta.W_PF_INSC_ESTADUAL = result[i++].Value?.ToString();
            dta.NULL_PF_INSC_ESTADUAL = string.IsNullOrWhiteSpace(dta.W_PF_INSC_ESTADUAL) ? "-1" : "0";
            dta.W_PF_NUM_INSC_SOCIAL = result[i++].Value?.ToString();
            dta.NULL_PF_NUM_INSC_SOCIAL = string.IsNullOrWhiteSpace(dta.W_PF_NUM_INSC_SOCIAL) ? "-1" : "0";
            dta.W_PF_NUM_DV_INSC_SOCIAL = result[i++].Value?.ToString();
            dta.NULL_PF_NUM_DV_INSC_SOCIAL = string.IsNullOrWhiteSpace(dta.W_PF_NUM_DV_INSC_SOCIAL) ? "-1" : "0";
            dta.W_NUMERO_CNPJ_BASE = result[i++].Value?.ToString();
            dta.NULL_NUM_CNPJ = string.IsNullOrWhiteSpace(dta.W_NUMERO_CNPJ_BASE) ? "-1" : "0";
            dta.OD003_NOM_RAZAO_SOCIAL = result[i++].Value?.ToString();
            dta.NULL_NOM_RAZAO_SOCIAL = string.IsNullOrWhiteSpace(dta.OD003_NOM_RAZAO_SOCIAL) ? "-1" : "0";
            dta.W_PJ_INSC_PREFEITURA = result[i++].Value?.ToString();
            dta.NULL_PJ_INSC_PREFEITURA = string.IsNullOrWhiteSpace(dta.W_PJ_INSC_PREFEITURA) ? "-1" : "0";
            dta.W_PJ_INSC_ESTADUAL = result[i++].Value?.ToString();
            dta.NULL_PJ_INSC_ESTADUAL = string.IsNullOrWhiteSpace(dta.W_PJ_INSC_ESTADUAL) ? "-1" : "0";
            dta.W_PJ_NUM_INSC_SOCIAL = result[i++].Value?.ToString();
            dta.NULL_PJ_NUM_INSC_SOCIAL = string.IsNullOrWhiteSpace(dta.W_PJ_NUM_INSC_SOCIAL) ? "-1" : "0";
            dta.W_PJ_NUM_DV_INSC_SOCIAL = result[i++].Value?.ToString();
            dta.NULL_PJ_NUM_DV_INSC_SOCIAL = string.IsNullOrWhiteSpace(dta.W_PJ_NUM_DV_INSC_SOCIAL) ? "-1" : "0";
            dta.OD007_NOM_LOGRADOURO = result[i++].Value?.ToString();
            dta.NULL_NOM_LOGRADOURO = string.IsNullOrWhiteSpace(dta.OD007_NOM_LOGRADOURO) ? "-1" : "0";
            dta.OD007_DES_NUM_IMOVEL = result[i++].Value?.ToString();
            dta.NULL_DES_NUM_IMOVEL = string.IsNullOrWhiteSpace(dta.OD007_DES_NUM_IMOVEL) ? "-1" : "0";
            dta.OD007_DES_COMPL_ENDERECO = result[i++].Value?.ToString();
            dta.NULL_DES_COMPL_ENDERECO = string.IsNullOrWhiteSpace(dta.OD007_DES_COMPL_ENDERECO) ? "-1" : "0";
            dta.OD007_NOM_BAIRRO = result[i++].Value?.ToString();
            dta.NULL_NOM_BAIRRO = string.IsNullOrWhiteSpace(dta.OD007_NOM_BAIRRO) ? "-1" : "0";
            dta.OD007_NOM_CIDADE = result[i++].Value?.ToString();
            dta.NULL_NOM_CIDADE = string.IsNullOrWhiteSpace(dta.OD007_NOM_CIDADE) ? "-1" : "0";
            dta.OD007_COD_CEP = result[i++].Value?.ToString();
            dta.NULL_COD_CEP = string.IsNullOrWhiteSpace(dta.OD007_COD_CEP) ? "-1" : "0";
            dta.OD007_COD_UF = result[i++].Value?.ToString();
            dta.NULL_COD_UF = string.IsNullOrWhiteSpace(dta.OD007_COD_UF) ? "-1" : "0";
            dta.SINISHIS_NOME_FAVORECIDO = result[i++].Value?.ToString();
            dta.GEOPERAC_IND_TIPO_FUNCAO = result[i++].Value?.ToString();
            return dta;
        }

    }
}