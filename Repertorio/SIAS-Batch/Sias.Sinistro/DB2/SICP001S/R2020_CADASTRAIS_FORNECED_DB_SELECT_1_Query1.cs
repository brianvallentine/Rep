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
    public class R2020_CADASTRAIS_FORNECED_DB_SELECT_1_Query1 : QueryBasis<R2020_CADASTRAIS_FORNECED_DB_SELECT_1_Query1>
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
            F.TIPO_PESSOA AS "TIPO PESSOA",
            CASE F.TIPO_PESSOA
            WHEN 'F' THEN 'PESSOA FISICA  '
            WHEN 'J' THEN 'PESSOA JURIDICA'
            END AS "TIPO DE PESSOA",
            F.CGCCPF AS "CPF / CNPJ DO FAVORECIDO",
            F.NOME_FORNECEDOR AS "NOME FORNECEDOR",
            F.INSC_PREFEITURA AS "INSCRICAO MUNICIPAL",
            F.INSC_ESTADUAL AS "INSCRICAO ESTADUAL",
            F.OPT_SIMPLES_FED AS "OPTANTE SIMPLES FERERAL",
            F.OPT_SIMPLES_MUN AS "OPTANTE SIMPLES MUNICIPAL",
            F.ENDERECO AS "LOGRAD. + NUM IMOVEL + COMPL",
            F.BAIRRO AS "BAIRRO",
            F.CIDADE AS "CIDADE",
            F.CEP AS "CEP",
            F.SIGLA_UF AS "UF",
            H.NOME_FAVORECIDO AS "NOME_FAVORECIDO_HIST",
            OPE.IND_TIPO_FUNCAO AS "TIPO FUNCAO OPERACAO"
            INTO
            :SINISHIS-NUM-APOL-SINISTRO,
            :SINISHIS-OCORR-HISTORICO,
            :SINISHIS-COD-OPERACAO,
            :GEOPERAC-FUNCAO-OPERACAO,
            :GEOPERAC-DES-OPERACAO,
            :FORNECED-TIPO-PESSOA,
            :W-NOME-TIPO-PESSOA,
            :FORNECED-CGCCPF,
            :FORNECED-NOME-FORNECEDOR,
            :FORNECED-INSC-PREFEITURA,
            :FORNECED-INSC-ESTADUAL,
            :FORNECED-OPT-SIMPLES-FED,
            :FORNECED-OPT-SIMPLES-MUN,
            :FORNECED-ENDERECO,
            :FORNECED-BAIRRO,
            :FORNECED-CIDADE,
            :FORNECED-CEP,
            :FORNECED-SIGLA-UF,
            :SINISHIS-NOME-FAVORECIDO,
            :GEOPERAC-IND-TIPO-FUNCAO
            FROM
            SEGUROS.SINISTRO_HISTORICO H,
            SEGUROS.GE_OPERACAO OPE,
            SEGUROS.FORNECEDORES F
            WHERE
            NOT EXISTS
            (SELECT 1 FROM SEGUROS.SI_PESS_SINISTRO SIPES
            WHERE SIPES.NUM_APOL_SINISTRO = H.NUM_APOL_SINISTRO
            AND SIPES.OCORR_HISTORICO = H.OCORR_HISTORICO
            AND SIPES.COD_OPERACAO = H.COD_OPERACAO)
            AND OPE.IDE_SISTEMA = 'SI'
            AND OPE.COD_OPERACAO = H.COD_OPERACAO
            AND H.NUM_APOL_SINISTRO = :SINISHIS-NUM-APOL-SINISTRO
            AND H.OCORR_HISTORICO = :SINISHIS-OCORR-HISTORICO
            AND H.COD_OPERACAO = :SINISHIS-COD-OPERACAO
            AND H.COD_PREST_SERVICO <> 0
            AND F.COD_FORNECEDOR = H.COD_PREST_SERVICO
            AND F.CGCCPF <> 80000000000
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
											F.TIPO_PESSOA AS TIPOPESSOA
							,
											CASE F.TIPO_PESSOA
											WHEN 'F' THEN 'PESSOA FISICA  '
											WHEN 'J' THEN 'PESSOA JURIDICA'
											END AS TIPODEPESSOA
							,
											F.CGCCPF AS CPFCNPJDOFAVORECIDO
							,
											F.NOME_FORNECEDOR AS NOMEFORNECEDOR
							,
											F.INSC_PREFEITURA AS INSCRICAOMUNICIPAL
							,
											F.INSC_ESTADUAL AS INSCRICAOESTADUAL
							,
											F.OPT_SIMPLES_FED AS OPTANTESIMPLESFERERAL
							,
											F.OPT_SIMPLES_MUN AS OPTANTESIMPLESMUNICIPAL
							,
											F.ENDERECO AS LOGRADNUMIMOVELCOMPL
							,
											F.BAIRRO AS BAIRRO
							,
											F.CIDADE AS CIDADE
							,
											F.CEP AS CEP
							,
											F.SIGLA_UF AS UF
							,
											H.NOME_FAVORECIDO AS NOME_FAVORECIDO_HIST
							,
											OPE.IND_TIPO_FUNCAO AS TIPOFUNCAOOPERACAO
											FROM
											SEGUROS.SINISTRO_HISTORICO H
							,
											SEGUROS.GE_OPERACAO OPE
							,
											SEGUROS.FORNECEDORES F
											WHERE
											NOT EXISTS
											(SELECT 1
							FROM SEGUROS.SI_PESS_SINISTRO SIPES
											WHERE SIPES.NUM_APOL_SINISTRO = H.NUM_APOL_SINISTRO
											AND SIPES.OCORR_HISTORICO = H.OCORR_HISTORICO
											AND SIPES.COD_OPERACAO = H.COD_OPERACAO)
											AND OPE.IDE_SISTEMA = 'SI'
											AND OPE.COD_OPERACAO = H.COD_OPERACAO
											AND H.NUM_APOL_SINISTRO = '{this.SINISHIS_NUM_APOL_SINISTRO}'
											AND H.OCORR_HISTORICO = '{this.SINISHIS_OCORR_HISTORICO}'
											AND H.COD_OPERACAO = '{this.SINISHIS_COD_OPERACAO}'
											AND H.COD_PREST_SERVICO <> 0
											AND F.COD_FORNECEDOR = H.COD_PREST_SERVICO
											AND F.CGCCPF <> 80000000000";

            return query;
        }
        public string SINISHIS_NUM_APOL_SINISTRO { get; set; }
        public string SINISHIS_OCORR_HISTORICO { get; set; }
        public string SINISHIS_COD_OPERACAO { get; set; }
        public string GEOPERAC_FUNCAO_OPERACAO { get; set; }
        public string GEOPERAC_DES_OPERACAO { get; set; }
        public string FORNECED_TIPO_PESSOA { get; set; }
        public string W_NOME_TIPO_PESSOA { get; set; }
        public string FORNECED_CGCCPF { get; set; }
        public string FORNECED_NOME_FORNECEDOR { get; set; }
        public string FORNECED_INSC_PREFEITURA { get; set; }
        public string FORNECED_INSC_ESTADUAL { get; set; }
        public string FORNECED_OPT_SIMPLES_FED { get; set; }
        public string FORNECED_OPT_SIMPLES_MUN { get; set; }
        public string FORNECED_ENDERECO { get; set; }
        public string FORNECED_BAIRRO { get; set; }
        public string FORNECED_CIDADE { get; set; }
        public string FORNECED_CEP { get; set; }
        public string FORNECED_SIGLA_UF { get; set; }
        public string SINISHIS_NOME_FAVORECIDO { get; set; }
        public string GEOPERAC_IND_TIPO_FUNCAO { get; set; }

        public static R2020_CADASTRAIS_FORNECED_DB_SELECT_1_Query1 Execute(R2020_CADASTRAIS_FORNECED_DB_SELECT_1_Query1 r2020_CADASTRAIS_FORNECED_DB_SELECT_1_Query1)
        {
            var ths = r2020_CADASTRAIS_FORNECED_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R2020_CADASTRAIS_FORNECED_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R2020_CADASTRAIS_FORNECED_DB_SELECT_1_Query1();
            var i = 0;
            dta.SINISHIS_NUM_APOL_SINISTRO = result[i++].Value?.ToString();
            dta.SINISHIS_OCORR_HISTORICO = result[i++].Value?.ToString();
            dta.SINISHIS_COD_OPERACAO = result[i++].Value?.ToString();
            dta.GEOPERAC_FUNCAO_OPERACAO = result[i++].Value?.ToString();
            dta.GEOPERAC_DES_OPERACAO = result[i++].Value?.ToString();
            dta.FORNECED_TIPO_PESSOA = result[i++].Value?.ToString();
            dta.W_NOME_TIPO_PESSOA = result[i++].Value?.ToString();
            dta.FORNECED_CGCCPF = result[i++].Value?.ToString();
            dta.FORNECED_NOME_FORNECEDOR = result[i++].Value?.ToString();
            dta.FORNECED_INSC_PREFEITURA = result[i++].Value?.ToString();
            dta.FORNECED_INSC_ESTADUAL = result[i++].Value?.ToString();
            dta.FORNECED_OPT_SIMPLES_FED = result[i++].Value?.ToString();
            dta.FORNECED_OPT_SIMPLES_MUN = result[i++].Value?.ToString();
            dta.FORNECED_ENDERECO = result[i++].Value?.ToString();
            dta.FORNECED_BAIRRO = result[i++].Value?.ToString();
            dta.FORNECED_CIDADE = result[i++].Value?.ToString();
            dta.FORNECED_CEP = result[i++].Value?.ToString();
            dta.FORNECED_SIGLA_UF = result[i++].Value?.ToString();
            dta.SINISHIS_NOME_FAVORECIDO = result[i++].Value?.ToString();
            dta.GEOPERAC_IND_TIPO_FUNCAO = result[i++].Value?.ToString();
            return dta;
        }

    }
}