using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.PessoaFisica.DB2.PF0648B
{
    public class R0250_00_LER_PROPOSTAVA_DB_SELECT_1_Query1 : QueryBasis<R0250_00_LER_PROPOSTAVA_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT
            NUM_CERTIFICADO ,
            COD_PRODUTO ,
            COD_CLIENTE ,
            OCOREND ,
            COD_FONTE ,
            AGE_COBRANCA ,
            OPCAO_COBERTURA ,
            DATA_QUITACAO ,
            COD_AGE_VENDEDOR ,
            OPE_CONTA_VENDEDOR ,
            NUM_CONTA_VENDEDOR ,
            DIG_CONTA_VENDEDOR ,
            NUM_MATRI_VENDEDOR ,
            COD_OPERACAO ,
            PROFISSAO ,
            DTINCLUS ,
            DATA_MOVIMENTO ,
            SIT_REGISTRO ,
            NUM_APOLICE ,
            COD_SUBGRUPO ,
            OCORR_HISTORICO ,
            NRPRIPARATZ ,
            QTDPARATZ ,
            DTPROXVEN ,
            NUM_PARCELA ,
            DATA_VENCIMENTO ,
            SIT_INTERFACE ,
            DTFENAE ,
            COD_USUARIO ,
            TIMESTAMP ,
            IDADE ,
            IDE_SEXO ,
            ESTADO_CIVIL ,
            APOS_INVALIDEZ ,
            NOME_ESPOSA ,
            DTNASC_ESPOSA ,
            PROFIS_ESPOSA ,
            DPS_TITULAR ,
            DPS_ESPOSA ,
            INFO_COMPLEMENTAR ,
            COD_CCT,
            FAIXA_RENDA_IND,
            FAIXA_RENDA_FAM
            INTO
            :DCLPROPOSTAS-VA.NUM-CERTIFICADO ,
            :DCLPROPOSTAS-VA.COD-PRODUTO ,
            :DCLPROPOSTAS-VA.COD-CLIENTE ,
            :DCLPROPOSTAS-VA.OCOREND ,
            :DCLPROPOSTAS-VA.COD-FONTE ,
            :DCLPROPOSTAS-VA.AGE-COBRANCA ,
            :DCLPROPOSTAS-VA.OPCAO-COBERTURA ,
            :DCLPROPOSTAS-VA.DATA-QUITACAO ,
            :DCLPROPOSTAS-VA.COD-AGE-VENDEDOR ,
            :DCLPROPOSTAS-VA.OPE-CONTA-VENDEDOR ,
            :DCLPROPOSTAS-VA.NUM-CONTA-VENDEDOR ,
            :DCLPROPOSTAS-VA.DIG-CONTA-VENDEDOR ,
            :DCLPROPOSTAS-VA.NUM-MATRI-VENDEDOR ,
            :DCLPROPOSTAS-VA.COD-OPERACAO ,
            :DCLPROPOSTAS-VA.PROFISSAO ,
            :DCLPROPOSTAS-VA.DTINCLUS ,
            :DCLPROPOSTAS-VA.DATA-MOVIMENTO ,
            :DCLPROPOSTAS-VA.SIT-REGISTRO ,
            :DCLPROPOSTAS-VA.NUM-APOLICE ,
            :DCLPROPOSTAS-VA.COD-SUBGRUPO ,
            :DCLPROPOSTAS-VA.OCORR-HISTORICO ,
            :DCLPROPOSTAS-VA.NRPRIPARATZ ,
            :DCLPROPOSTAS-VA.QTDPARATZ ,
            :DCLPROPOSTAS-VA.DTPROXVEN ,
            :DCLPROPOSTAS-VA.NUM-PARCELA ,
            :DCLPROPOSTAS-VA.DATA-VENCIMENTO ,
            :DCLPROPOSTAS-VA.SIT-INTERFACE ,
            :DCLPROPOSTAS-VA.DTFENAE ,
            :DCLPROPOSTAS-VA.COD-USUARIO ,
            :DCLPROPOSTAS-VA.TIMESTAMP ,
            :DCLPROPOSTAS-VA.IDADE ,
            :DCLPROPOSTAS-VA.IDE-SEXO ,
            :DCLPROPOSTAS-VA.ESTADO-CIVIL ,
            :DCLPROPOSTAS-VA.APOS-INVALIDEZ:VIND-APOS-INVALIDEZ,
            :DCLPROPOSTAS-VA.NOME-ESPOSA:VIND-NOME-ESPOSA,
            :DCLPROPOSTAS-VA.DTNASC-ESPOSA:VIND-DTNASC-ESPOSA,
            :DCLPROPOSTAS-VA.PROFIS-ESPOSA:VIND-PROFIS-ESPOSA,
            :DCLPROPOSTAS-VA.DPS-TITULAR:VIND-DPS-TITULAR,
            :DCLPROPOSTAS-VA.DPS-ESPOSA:VIND-DPS-ESPOSA,
            :DCLPROPOSTAS-VA.INFO-COMPLEMENTAR:VIND-INFO-COMP,
            :DCLPROPOSTAS-VA.COD-CCT:VIND-COD-CCT,
            :DCLPROPOSTAS-VA.FAIXA-RENDA-IND:VIND-FAIXA-RENDA-IND,
            :DCLPROPOSTAS-VA.FAIXA-RENDA-FAM:VIND-FAIXA-RENDA-FAM
            FROM SEGUROS.PROPOSTAS_VA
            WHERE NUM_CERTIFICADO =
            :DCLPROPOSTAS-VA.NUM-CERTIFICADO
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT
											NUM_CERTIFICADO 
							,
											COD_PRODUTO 
							,
											COD_CLIENTE 
							,
											OCOREND 
							,
											COD_FONTE 
							,
											AGE_COBRANCA 
							,
											OPCAO_COBERTURA 
							,
											DATA_QUITACAO 
							,
											COD_AGE_VENDEDOR 
							,
											OPE_CONTA_VENDEDOR 
							,
											NUM_CONTA_VENDEDOR 
							,
											DIG_CONTA_VENDEDOR 
							,
											NUM_MATRI_VENDEDOR 
							,
											COD_OPERACAO 
							,
											PROFISSAO 
							,
											DTINCLUS 
							,
											DATA_MOVIMENTO 
							,
											SIT_REGISTRO 
							,
											NUM_APOLICE 
							,
											COD_SUBGRUPO 
							,
											OCORR_HISTORICO 
							,
											NRPRIPARATZ 
							,
											QTDPARATZ 
							,
											DTPROXVEN 
							,
											NUM_PARCELA 
							,
											DATA_VENCIMENTO 
							,
											SIT_INTERFACE 
							,
											DTFENAE 
							,
											COD_USUARIO 
							,
											TIMESTAMP 
							,
											IDADE 
							,
											IDE_SEXO 
							,
											ESTADO_CIVIL 
							,
											APOS_INVALIDEZ 
							,
											NOME_ESPOSA 
							,
											DTNASC_ESPOSA 
							,
											PROFIS_ESPOSA 
							,
											DPS_TITULAR 
							,
											DPS_ESPOSA 
							,
											INFO_COMPLEMENTAR 
							,
											COD_CCT
							,
											FAIXA_RENDA_IND
							,
											FAIXA_RENDA_FAM
											FROM SEGUROS.PROPOSTAS_VA
											WHERE NUM_CERTIFICADO =
											'{this.NUM_CERTIFICADO}'
											WITH UR";

            return query;
        }
        public string NUM_CERTIFICADO { get; set; }
        public string COD_PRODUTO { get; set; }
        public string COD_CLIENTE { get; set; }
        public string OCOREND { get; set; }
        public string COD_FONTE { get; set; }
        public string AGE_COBRANCA { get; set; }
        public string OPCAO_COBERTURA { get; set; }
        public string DATA_QUITACAO { get; set; }
        public string COD_AGE_VENDEDOR { get; set; }
        public string OPE_CONTA_VENDEDOR { get; set; }
        public string NUM_CONTA_VENDEDOR { get; set; }
        public string DIG_CONTA_VENDEDOR { get; set; }
        public string NUM_MATRI_VENDEDOR { get; set; }
        public string COD_OPERACAO { get; set; }
        public string PROFISSAO { get; set; }
        public string DTINCLUS { get; set; }
        public string DATA_MOVIMENTO { get; set; }
        public string SIT_REGISTRO { get; set; }
        public string NUM_APOLICE { get; set; }
        public string COD_SUBGRUPO { get; set; }
        public string OCORR_HISTORICO { get; set; }
        public string NRPRIPARATZ { get; set; }
        public string QTDPARATZ { get; set; }
        public string DTPROXVEN { get; set; }
        public string NUM_PARCELA { get; set; }
        public string DATA_VENCIMENTO { get; set; }
        public string SIT_INTERFACE { get; set; }
        public string DTFENAE { get; set; }
        public string COD_USUARIO { get; set; }
        public string TIMESTAMP { get; set; }
        public string IDADE { get; set; }
        public string IDE_SEXO { get; set; }
        public string ESTADO_CIVIL { get; set; }
        public string APOS_INVALIDEZ { get; set; }
        public string VIND_APOS_INVALIDEZ { get; set; }
        public string NOME_ESPOSA { get; set; }
        public string VIND_NOME_ESPOSA { get; set; }
        public string DTNASC_ESPOSA { get; set; }
        public string VIND_DTNASC_ESPOSA { get; set; }
        public string PROFIS_ESPOSA { get; set; }
        public string VIND_PROFIS_ESPOSA { get; set; }
        public string DPS_TITULAR { get; set; }
        public string VIND_DPS_TITULAR { get; set; }
        public string DPS_ESPOSA { get; set; }
        public string VIND_DPS_ESPOSA { get; set; }
        public string INFO_COMPLEMENTAR { get; set; }
        public string VIND_INFO_COMP { get; set; }
        public string COD_CCT { get; set; }
        public string VIND_COD_CCT { get; set; }
        public string FAIXA_RENDA_IND { get; set; }
        public string VIND_FAIXA_RENDA_IND { get; set; }
        public string FAIXA_RENDA_FAM { get; set; }
        public string VIND_FAIXA_RENDA_FAM { get; set; }

        public static R0250_00_LER_PROPOSTAVA_DB_SELECT_1_Query1 Execute(R0250_00_LER_PROPOSTAVA_DB_SELECT_1_Query1 r0250_00_LER_PROPOSTAVA_DB_SELECT_1_Query1)
        {
            var ths = r0250_00_LER_PROPOSTAVA_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0250_00_LER_PROPOSTAVA_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0250_00_LER_PROPOSTAVA_DB_SELECT_1_Query1();
            var i = 0;
            dta.NUM_CERTIFICADO = result[i++].Value?.ToString();
            dta.COD_PRODUTO = result[i++].Value?.ToString();
            dta.COD_CLIENTE = result[i++].Value?.ToString();
            dta.OCOREND = result[i++].Value?.ToString();
            dta.COD_FONTE = result[i++].Value?.ToString();
            dta.AGE_COBRANCA = result[i++].Value?.ToString();
            dta.OPCAO_COBERTURA = result[i++].Value?.ToString();
            dta.DATA_QUITACAO = result[i++].Value?.ToString();
            dta.COD_AGE_VENDEDOR = result[i++].Value?.ToString();
            dta.OPE_CONTA_VENDEDOR = result[i++].Value?.ToString();
            dta.NUM_CONTA_VENDEDOR = result[i++].Value?.ToString();
            dta.DIG_CONTA_VENDEDOR = result[i++].Value?.ToString();
            dta.NUM_MATRI_VENDEDOR = result[i++].Value?.ToString();
            dta.COD_OPERACAO = result[i++].Value?.ToString();
            dta.PROFISSAO = result[i++].Value?.ToString();
            dta.DTINCLUS = result[i++].Value?.ToString();
            dta.DATA_MOVIMENTO = result[i++].Value?.ToString();
            dta.SIT_REGISTRO = result[i++].Value?.ToString();
            dta.NUM_APOLICE = result[i++].Value?.ToString();
            dta.COD_SUBGRUPO = result[i++].Value?.ToString();
            dta.OCORR_HISTORICO = result[i++].Value?.ToString();
            dta.NRPRIPARATZ = result[i++].Value?.ToString();
            dta.QTDPARATZ = result[i++].Value?.ToString();
            dta.DTPROXVEN = result[i++].Value?.ToString();
            dta.NUM_PARCELA = result[i++].Value?.ToString();
            dta.DATA_VENCIMENTO = result[i++].Value?.ToString();
            dta.SIT_INTERFACE = result[i++].Value?.ToString();
            dta.DTFENAE = result[i++].Value?.ToString();
            dta.COD_USUARIO = result[i++].Value?.ToString();
            dta.TIMESTAMP = result[i++].Value?.ToString();
            dta.IDADE = result[i++].Value?.ToString();
            dta.IDE_SEXO = result[i++].Value?.ToString();
            dta.ESTADO_CIVIL = result[i++].Value?.ToString();
            dta.APOS_INVALIDEZ = result[i++].Value?.ToString();
            dta.VIND_APOS_INVALIDEZ = string.IsNullOrWhiteSpace(dta.APOS_INVALIDEZ) ? "-1" : "0";
            dta.NOME_ESPOSA = result[i++].Value?.ToString();
            dta.VIND_NOME_ESPOSA = string.IsNullOrWhiteSpace(dta.NOME_ESPOSA) ? "-1" : "0";
            dta.DTNASC_ESPOSA = result[i++].Value?.ToString();
            dta.VIND_DTNASC_ESPOSA = string.IsNullOrWhiteSpace(dta.DTNASC_ESPOSA) ? "-1" : "0";
            dta.PROFIS_ESPOSA = result[i++].Value?.ToString();
            dta.VIND_PROFIS_ESPOSA = string.IsNullOrWhiteSpace(dta.PROFIS_ESPOSA) ? "-1" : "0";
            dta.DPS_TITULAR = result[i++].Value?.ToString();
            dta.VIND_DPS_TITULAR = string.IsNullOrWhiteSpace(dta.DPS_TITULAR) ? "-1" : "0";
            dta.DPS_ESPOSA = result[i++].Value?.ToString();
            dta.VIND_DPS_ESPOSA = string.IsNullOrWhiteSpace(dta.DPS_ESPOSA) ? "-1" : "0";
            dta.INFO_COMPLEMENTAR = result[i++].Value?.ToString();
            dta.VIND_INFO_COMP = string.IsNullOrWhiteSpace(dta.INFO_COMPLEMENTAR) ? "-1" : "0";
            dta.COD_CCT = result[i++].Value?.ToString();
            dta.VIND_COD_CCT = string.IsNullOrWhiteSpace(dta.COD_CCT) ? "-1" : "0";
            dta.FAIXA_RENDA_IND = result[i++].Value?.ToString();
            dta.VIND_FAIXA_RENDA_IND = string.IsNullOrWhiteSpace(dta.FAIXA_RENDA_IND) ? "-1" : "0";
            dta.FAIXA_RENDA_FAM = result[i++].Value?.ToString();
            dta.VIND_FAIXA_RENDA_FAM = string.IsNullOrWhiteSpace(dta.FAIXA_RENDA_FAM) ? "-1" : "0";
            return dta;
        }

    }
}