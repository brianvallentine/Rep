using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0126B
{
    public class R0170_00_LER_CERTIFICADO_DB_SELECT_1_Query1 : QueryBasis<R0170_00_LER_CERTIFICADO_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT NUM_CERTIFICADO
            , COD_PRODUTO
            , COD_CLIENTE
            , OCOREND
            , COD_FONTE
            , AGE_COBRANCA
            , OPCAO_COBERTURA
            , DATA_QUITACAO
            , COD_AGE_VENDEDOR
            , OPE_CONTA_VENDEDOR
            , NUM_CONTA_VENDEDOR
            , DIG_CONTA_VENDEDOR
            , NUM_MATRI_VENDEDOR
            , COD_OPERACAO
            , PROFISSAO
            , DTINCLUS
            , DATA_MOVIMENTO
            , SIT_REGISTRO
            , NUM_APOLICE
            , COD_SUBGRUPO
            , OCORR_HISTORICO
            , NRPRIPARATZ
            , QTDPARATZ
            , DTPROXVEN
            , NUM_PARCELA
            , DATA_VENCIMENTO
            , SIT_INTERFACE
            , DTFENAE
            , COD_USUARIO
            , TIMESTAMP
            , IDADE
            , IDE_SEXO
            , ESTADO_CIVIL
            , APOS_INVALIDEZ
            , NOME_ESPOSA
            , DTNASC_ESPOSA
            , PROFIS_ESPOSA
            , DPS_TITULAR
            , DPS_ESPOSA
            , NUM_MATRICULA
            , FAIXA_RENDA_IND
            , FAIXA_RENDA_FAM
            , COD_ORIGEM_PROPOSTA
            , NUM_PRAZO_FIN
            , STA_ANTECIPACAO
            , STA_MUDANCA_PLANO
            INTO :PROPOVA-NUM-CERTIFICADO
            ,:PROPOVA-COD-PRODUTO
            ,:PROPOVA-COD-CLIENTE
            ,:PROPOVA-OCOREND
            ,:PROPOVA-COD-FONTE
            ,:PROPOVA-AGE-COBRANCA
            ,:PROPOVA-OPCAO-COBERTURA
            ,:PROPOVA-DATA-QUITACAO
            ,:PROPOVA-COD-AGE-VENDEDOR
            ,:PROPOVA-OPE-CONTA-VENDEDOR
            ,:PROPOVA-NUM-CONTA-VENDEDOR
            ,:PROPOVA-DIG-CONTA-VENDEDOR
            ,:PROPOVA-NUM-MATRI-VENDEDOR
            ,:PROPOVA-COD-OPERACAO
            ,:PROPOVA-PROFISSAO
            ,:PROPOVA-DTINCLUS
            ,:PROPOVA-DATA-MOVIMENTO
            ,:PROPOVA-SIT-REGISTRO
            ,:PROPOVA-NUM-APOLICE
            ,:PROPOVA-COD-SUBGRUPO
            ,:PROPOVA-OCORR-HISTORICO
            ,:PROPOVA-NRPRIPARATZ
            ,:PROPOVA-QTDPARATZ
            ,:PROPOVA-DTPROXVEN
            ,:PROPOVA-NUM-PARCELA
            ,:PROPOVA-DATA-VENCIMENTO
            ,:PROPOVA-SIT-INTERFACE
            ,:PROPOVA-DTFENAE
            ,:PROPOVA-COD-USUARIO
            ,:PROPOVA-TIMESTAMP
            ,:PROPOVA-IDADE
            ,:PROPOVA-IDE-SEXO
            ,:PROPOVA-ESTADO-CIVIL
            ,:PROPOVA-APOS-INVALIDEZ:VIND-APOS-INVALIDEZ
            ,:PROPOVA-NOME-ESPOSA:VIND-NOME-ESPOSA
            ,:PROPOVA-DTNASC-ESPOSA:VIND-DTNASC-ESPOSA
            ,:PROPOVA-PROFIS-ESPOSA:VIND-PROFIS-ESPOSA
            ,:PROPOVA-DPS-TITULAR:VIND-DPS-TITULAR
            ,:PROPOVA-DPS-ESPOSA:VIND-DPS-ESPOSA
            ,:PROPOVA-NUM-MATRICULA:VIND-NUM-MATRICULA
            ,:PROPOVA-FAIXA-RENDA-IND:VIND-FAIXA-RENDA-IND
            ,:PROPOVA-FAIXA-RENDA-FAM:VIND-FAIXA-RENDA-FAM
            ,:PROPOVA-COD-ORIGEM-PROPOSTA
            :VIND-COD-ORIGEM-PROP
            ,:PROPOVA-NUM-PRAZO-FIN:VIND-NUM-PRAZO-FIN
            ,:PROPOVA-STA-ANTECIPACAO:VIND-STA-ANTECIPACAO
            ,:PROPOVA-STA-MUDANCA-PLANO:VIND-STA-MUDANCA
            FROM SEGUROS.PROPOSTAS_VA
            WHERE NUM_CERTIFICADO = :RELATORI-NUM-CERTIFICADO
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT NUM_CERTIFICADO
											, COD_PRODUTO
											, COD_CLIENTE
											, OCOREND
											, COD_FONTE
											, AGE_COBRANCA
											, OPCAO_COBERTURA
											, DATA_QUITACAO
											, COD_AGE_VENDEDOR
											, OPE_CONTA_VENDEDOR
											, NUM_CONTA_VENDEDOR
											, DIG_CONTA_VENDEDOR
											, NUM_MATRI_VENDEDOR
											, COD_OPERACAO
											, PROFISSAO
											, DTINCLUS
											, DATA_MOVIMENTO
											, SIT_REGISTRO
											, NUM_APOLICE
											, COD_SUBGRUPO
											, OCORR_HISTORICO
											, NRPRIPARATZ
											, QTDPARATZ
											, DTPROXVEN
											, NUM_PARCELA
											, DATA_VENCIMENTO
											, SIT_INTERFACE
											, DTFENAE
											, COD_USUARIO
											, TIMESTAMP
											, IDADE
											, IDE_SEXO
											, ESTADO_CIVIL
											, APOS_INVALIDEZ
											, NOME_ESPOSA
											, DTNASC_ESPOSA
											, PROFIS_ESPOSA
											, DPS_TITULAR
											, DPS_ESPOSA
											, NUM_MATRICULA
											, FAIXA_RENDA_IND
											, FAIXA_RENDA_FAM
											, COD_ORIGEM_PROPOSTA
											, NUM_PRAZO_FIN
											, STA_ANTECIPACAO
											, STA_MUDANCA_PLANO
											FROM SEGUROS.PROPOSTAS_VA
											WHERE NUM_CERTIFICADO = '{this.RELATORI_NUM_CERTIFICADO}'";

            return query;
        }
        public string PROPOVA_NUM_CERTIFICADO { get; set; }
        public string PROPOVA_COD_PRODUTO { get; set; }
        public string PROPOVA_COD_CLIENTE { get; set; }
        public string PROPOVA_OCOREND { get; set; }
        public string PROPOVA_COD_FONTE { get; set; }
        public string PROPOVA_AGE_COBRANCA { get; set; }
        public string PROPOVA_OPCAO_COBERTURA { get; set; }
        public string PROPOVA_DATA_QUITACAO { get; set; }
        public string PROPOVA_COD_AGE_VENDEDOR { get; set; }
        public string PROPOVA_OPE_CONTA_VENDEDOR { get; set; }
        public string PROPOVA_NUM_CONTA_VENDEDOR { get; set; }
        public string PROPOVA_DIG_CONTA_VENDEDOR { get; set; }
        public string PROPOVA_NUM_MATRI_VENDEDOR { get; set; }
        public string PROPOVA_COD_OPERACAO { get; set; }
        public string PROPOVA_PROFISSAO { get; set; }
        public string PROPOVA_DTINCLUS { get; set; }
        public string PROPOVA_DATA_MOVIMENTO { get; set; }
        public string PROPOVA_SIT_REGISTRO { get; set; }
        public string PROPOVA_NUM_APOLICE { get; set; }
        public string PROPOVA_COD_SUBGRUPO { get; set; }
        public string PROPOVA_OCORR_HISTORICO { get; set; }
        public string PROPOVA_NRPRIPARATZ { get; set; }
        public string PROPOVA_QTDPARATZ { get; set; }
        public string PROPOVA_DTPROXVEN { get; set; }
        public string PROPOVA_NUM_PARCELA { get; set; }
        public string PROPOVA_DATA_VENCIMENTO { get; set; }
        public string PROPOVA_SIT_INTERFACE { get; set; }
        public string PROPOVA_DTFENAE { get; set; }
        public string PROPOVA_COD_USUARIO { get; set; }
        public string PROPOVA_TIMESTAMP { get; set; }
        public string PROPOVA_IDADE { get; set; }
        public string PROPOVA_IDE_SEXO { get; set; }
        public string PROPOVA_ESTADO_CIVIL { get; set; }
        public string PROPOVA_APOS_INVALIDEZ { get; set; }
        public string VIND_APOS_INVALIDEZ { get; set; }
        public string PROPOVA_NOME_ESPOSA { get; set; }
        public string VIND_NOME_ESPOSA { get; set; }
        public string PROPOVA_DTNASC_ESPOSA { get; set; }
        public string VIND_DTNASC_ESPOSA { get; set; }
        public string PROPOVA_PROFIS_ESPOSA { get; set; }
        public string VIND_PROFIS_ESPOSA { get; set; }
        public string PROPOVA_DPS_TITULAR { get; set; }
        public string VIND_DPS_TITULAR { get; set; }
        public string PROPOVA_DPS_ESPOSA { get; set; }
        public string VIND_DPS_ESPOSA { get; set; }
        public string PROPOVA_NUM_MATRICULA { get; set; }
        public string VIND_NUM_MATRICULA { get; set; }
        public string PROPOVA_FAIXA_RENDA_IND { get; set; }
        public string VIND_FAIXA_RENDA_IND { get; set; }
        public string PROPOVA_FAIXA_RENDA_FAM { get; set; }
        public string VIND_FAIXA_RENDA_FAM { get; set; }
        public string PROPOVA_COD_ORIGEM_PROPOSTA { get; set; }
        public string VIND_COD_ORIGEM_PROP { get; set; }
        public string PROPOVA_NUM_PRAZO_FIN { get; set; }
        public string VIND_NUM_PRAZO_FIN { get; set; }
        public string PROPOVA_STA_ANTECIPACAO { get; set; }
        public string VIND_STA_ANTECIPACAO { get; set; }
        public string PROPOVA_STA_MUDANCA_PLANO { get; set; }
        public string VIND_STA_MUDANCA { get; set; }
        public string RELATORI_NUM_CERTIFICADO { get; set; }

        public static R0170_00_LER_CERTIFICADO_DB_SELECT_1_Query1 Execute(R0170_00_LER_CERTIFICADO_DB_SELECT_1_Query1 r0170_00_LER_CERTIFICADO_DB_SELECT_1_Query1)
        {
            var ths = r0170_00_LER_CERTIFICADO_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0170_00_LER_CERTIFICADO_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0170_00_LER_CERTIFICADO_DB_SELECT_1_Query1();
            var i = 0;
            dta.PROPOVA_NUM_CERTIFICADO = result[i++].Value?.ToString();
            dta.PROPOVA_COD_PRODUTO = result[i++].Value?.ToString();
            dta.PROPOVA_COD_CLIENTE = result[i++].Value?.ToString();
            dta.PROPOVA_OCOREND = result[i++].Value?.ToString();
            dta.PROPOVA_COD_FONTE = result[i++].Value?.ToString();
            dta.PROPOVA_AGE_COBRANCA = result[i++].Value?.ToString();
            dta.PROPOVA_OPCAO_COBERTURA = result[i++].Value?.ToString();
            dta.PROPOVA_DATA_QUITACAO = result[i++].Value?.ToString();
            dta.PROPOVA_COD_AGE_VENDEDOR = result[i++].Value?.ToString();
            dta.PROPOVA_OPE_CONTA_VENDEDOR = result[i++].Value?.ToString();
            dta.PROPOVA_NUM_CONTA_VENDEDOR = result[i++].Value?.ToString();
            dta.PROPOVA_DIG_CONTA_VENDEDOR = result[i++].Value?.ToString();
            dta.PROPOVA_NUM_MATRI_VENDEDOR = result[i++].Value?.ToString();
            dta.PROPOVA_COD_OPERACAO = result[i++].Value?.ToString();
            dta.PROPOVA_PROFISSAO = result[i++].Value?.ToString();
            dta.PROPOVA_DTINCLUS = result[i++].Value?.ToString();
            dta.PROPOVA_DATA_MOVIMENTO = result[i++].Value?.ToString();
            dta.PROPOVA_SIT_REGISTRO = result[i++].Value?.ToString();
            dta.PROPOVA_NUM_APOLICE = result[i++].Value?.ToString();
            dta.PROPOVA_COD_SUBGRUPO = result[i++].Value?.ToString();
            dta.PROPOVA_OCORR_HISTORICO = result[i++].Value?.ToString();
            dta.PROPOVA_NRPRIPARATZ = result[i++].Value?.ToString();
            dta.PROPOVA_QTDPARATZ = result[i++].Value?.ToString();
            dta.PROPOVA_DTPROXVEN = result[i++].Value?.ToString();
            dta.PROPOVA_NUM_PARCELA = result[i++].Value?.ToString();
            dta.PROPOVA_DATA_VENCIMENTO = result[i++].Value?.ToString();
            dta.PROPOVA_SIT_INTERFACE = result[i++].Value?.ToString();
            dta.PROPOVA_DTFENAE = result[i++].Value?.ToString();
            dta.PROPOVA_COD_USUARIO = result[i++].Value?.ToString();
            dta.PROPOVA_TIMESTAMP = result[i++].Value?.ToString();
            dta.PROPOVA_IDADE = result[i++].Value?.ToString();
            dta.PROPOVA_IDE_SEXO = result[i++].Value?.ToString();
            dta.PROPOVA_ESTADO_CIVIL = result[i++].Value?.ToString();
            dta.PROPOVA_APOS_INVALIDEZ = result[i++].Value?.ToString();
            dta.VIND_APOS_INVALIDEZ = string.IsNullOrWhiteSpace(dta.PROPOVA_APOS_INVALIDEZ) ? "-1" : "0";
            dta.PROPOVA_NOME_ESPOSA = result[i++].Value?.ToString();
            dta.VIND_NOME_ESPOSA = string.IsNullOrWhiteSpace(dta.PROPOVA_NOME_ESPOSA) ? "-1" : "0";
            dta.PROPOVA_DTNASC_ESPOSA = result[i++].Value?.ToString();
            dta.VIND_DTNASC_ESPOSA = string.IsNullOrWhiteSpace(dta.PROPOVA_DTNASC_ESPOSA) ? "-1" : "0";
            dta.PROPOVA_PROFIS_ESPOSA = result[i++].Value?.ToString();
            dta.VIND_PROFIS_ESPOSA = string.IsNullOrWhiteSpace(dta.PROPOVA_PROFIS_ESPOSA) ? "-1" : "0";
            dta.PROPOVA_DPS_TITULAR = result[i++].Value?.ToString();
            dta.VIND_DPS_TITULAR = string.IsNullOrWhiteSpace(dta.PROPOVA_DPS_TITULAR) ? "-1" : "0";
            dta.PROPOVA_DPS_ESPOSA = result[i++].Value?.ToString();
            dta.VIND_DPS_ESPOSA = string.IsNullOrWhiteSpace(dta.PROPOVA_DPS_ESPOSA) ? "-1" : "0";
            dta.PROPOVA_NUM_MATRICULA = result[i++].Value?.ToString();
            dta.VIND_NUM_MATRICULA = string.IsNullOrWhiteSpace(dta.PROPOVA_NUM_MATRICULA) ? "-1" : "0";
            dta.PROPOVA_FAIXA_RENDA_IND = result[i++].Value?.ToString();
            dta.VIND_FAIXA_RENDA_IND = string.IsNullOrWhiteSpace(dta.PROPOVA_FAIXA_RENDA_IND) ? "-1" : "0";
            dta.PROPOVA_FAIXA_RENDA_FAM = result[i++].Value?.ToString();
            dta.VIND_FAIXA_RENDA_FAM = string.IsNullOrWhiteSpace(dta.PROPOVA_FAIXA_RENDA_FAM) ? "-1" : "0";
            dta.PROPOVA_COD_ORIGEM_PROPOSTA = result[i++].Value?.ToString();
            dta.VIND_COD_ORIGEM_PROP = string.IsNullOrWhiteSpace(dta.PROPOVA_COD_ORIGEM_PROPOSTA) ? "-1" : "0";
            dta.PROPOVA_NUM_PRAZO_FIN = result[i++].Value?.ToString();
            dta.VIND_NUM_PRAZO_FIN = string.IsNullOrWhiteSpace(dta.PROPOVA_NUM_PRAZO_FIN) ? "-1" : "0";
            dta.PROPOVA_STA_ANTECIPACAO = result[i++].Value?.ToString();
            dta.VIND_STA_ANTECIPACAO = string.IsNullOrWhiteSpace(dta.PROPOVA_STA_ANTECIPACAO) ? "-1" : "0";
            dta.PROPOVA_STA_MUDANCA_PLANO = result[i++].Value?.ToString();
            dta.VIND_STA_MUDANCA = string.IsNullOrWhiteSpace(dta.PROPOVA_STA_MUDANCA_PLANO) ? "-1" : "0";
            return dta;
        }

    }
}