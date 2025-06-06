using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Bilhetes.DB2.BI0073B
{
    public class R0430_00_SELECT_BILHETE_DB_SELECT_1_Query1 : QueryBasis<R0430_00_SELECT_BILHETE_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT NUM_BILHETE ,
            NUM_APOLICE ,
            FONTE ,
            AGE_COBRANCA ,
            NUM_MATRICULA ,
            COD_AGENCIA ,
            OPERACAO_CONTA ,
            NUM_CONTA ,
            DIG_CONTA ,
            COD_CLIENTE ,
            PROFISSAO ,
            IDE_SEXO ,
            ESTADO_CIVIL ,
            OCORR_ENDERECO ,
            COD_AGENCIA_DEB ,
            OPERACAO_CONTA_DEB ,
            NUM_CONTA_DEB ,
            DIG_CONTA_DEB ,
            OPC_COBERTURA ,
            DATA_QUITACAO ,
            VAL_RCAP ,
            RAMO ,
            DATA_VENDA ,
            DATA_MOVIMENTO ,
            NUM_APOL_ANTERIOR ,
            SITUACAO ,
            TIP_CANCELAMENTO ,
            SIT_SINISTRO ,
            COD_USUARIO ,
            TIMESTAMP ,
            DATA_CANCELAMENTO ,
            BI_FAIXA_RENDA_IND ,
            BI_FAIXA_RENDA_FAM
            INTO :BILHETE-NUM-BILHETE ,
            :BILHETE-NUM-APOLICE ,
            :BILHETE-FONTE ,
            :BILHETE-AGE-COBRANCA ,
            :BILHETE-NUM-MATRICULA ,
            :BILHETE-COD-AGENCIA ,
            :BILHETE-OPERACAO-CONTA ,
            :BILHETE-NUM-CONTA ,
            :BILHETE-DIG-CONTA ,
            :BILHETE-COD-CLIENTE ,
            :BILHETE-PROFISSAO ,
            :BILHETE-IDE-SEXO ,
            :BILHETE-ESTADO-CIVIL ,
            :BILHETE-OCORR-ENDERECO ,
            :BILHETE-COD-AGENCIA-DEB ,
            :BILHETE-OPERACAO-CONTA-DEB ,
            :BILHETE-NUM-CONTA-DEB ,
            :BILHETE-DIG-CONTA-DEB ,
            :BILHETE-OPC-COBERTURA ,
            :BILHETE-DATA-QUITACAO ,
            :BILHETE-VAL-RCAP ,
            :BILHETE-RAMO ,
            :BILHETE-DATA-VENDA ,
            :BILHETE-DATA-MOVIMENTO ,
            :BILHETE-NUM-APOL-ANTERIOR ,
            :BILHETE-SITUACAO ,
            :BILHETE-TIP-CANCELAMENTO ,
            :BILHETE-SIT-SINISTRO ,
            :BILHETE-COD-USUARIO ,
            :BILHETE-TIMESTAMP ,
            :BILHETE-DATA-CANCELAMENTO:VIND-NULL01 ,
            :BILHETE-BI-FAIXA-RENDA-IND ,
            :BILHETE-BI-FAIXA-RENDA-FAM
            FROM SEGUROS.BILHETE
            WHERE NUM_BILHETE >=
            :WSHOST-NUMSIV01
            AND NUM_BILHETE <=
            :WSHOST-NUMSIV02
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT NUM_BILHETE 
							,
											NUM_APOLICE 
							,
											FONTE 
							,
											AGE_COBRANCA 
							,
											NUM_MATRICULA 
							,
											COD_AGENCIA 
							,
											OPERACAO_CONTA 
							,
											NUM_CONTA 
							,
											DIG_CONTA 
							,
											COD_CLIENTE 
							,
											PROFISSAO 
							,
											IDE_SEXO 
							,
											ESTADO_CIVIL 
							,
											OCORR_ENDERECO 
							,
											COD_AGENCIA_DEB 
							,
											OPERACAO_CONTA_DEB 
							,
											NUM_CONTA_DEB 
							,
											DIG_CONTA_DEB 
							,
											OPC_COBERTURA 
							,
											DATA_QUITACAO 
							,
											VAL_RCAP 
							,
											RAMO 
							,
											DATA_VENDA 
							,
											DATA_MOVIMENTO 
							,
											NUM_APOL_ANTERIOR 
							,
											SITUACAO 
							,
											TIP_CANCELAMENTO 
							,
											SIT_SINISTRO 
							,
											COD_USUARIO 
							,
											TIMESTAMP 
							,
											DATA_CANCELAMENTO 
							,
											BI_FAIXA_RENDA_IND 
							,
											BI_FAIXA_RENDA_FAM
											FROM SEGUROS.BILHETE
											WHERE NUM_BILHETE >=
											'{this.WSHOST_NUMSIV01}'
											AND NUM_BILHETE <=
											'{this.WSHOST_NUMSIV02}'
											WITH UR";

            return query;
        }
        public string BILHETE_NUM_BILHETE { get; set; }
        public string BILHETE_NUM_APOLICE { get; set; }
        public string BILHETE_FONTE { get; set; }
        public string BILHETE_AGE_COBRANCA { get; set; }
        public string BILHETE_NUM_MATRICULA { get; set; }
        public string BILHETE_COD_AGENCIA { get; set; }
        public string BILHETE_OPERACAO_CONTA { get; set; }
        public string BILHETE_NUM_CONTA { get; set; }
        public string BILHETE_DIG_CONTA { get; set; }
        public string BILHETE_COD_CLIENTE { get; set; }
        public string BILHETE_PROFISSAO { get; set; }
        public string BILHETE_IDE_SEXO { get; set; }
        public string BILHETE_ESTADO_CIVIL { get; set; }
        public string BILHETE_OCORR_ENDERECO { get; set; }
        public string BILHETE_COD_AGENCIA_DEB { get; set; }
        public string BILHETE_OPERACAO_CONTA_DEB { get; set; }
        public string BILHETE_NUM_CONTA_DEB { get; set; }
        public string BILHETE_DIG_CONTA_DEB { get; set; }
        public string BILHETE_OPC_COBERTURA { get; set; }
        public string BILHETE_DATA_QUITACAO { get; set; }
        public string BILHETE_VAL_RCAP { get; set; }
        public string BILHETE_RAMO { get; set; }
        public string BILHETE_DATA_VENDA { get; set; }
        public string BILHETE_DATA_MOVIMENTO { get; set; }
        public string BILHETE_NUM_APOL_ANTERIOR { get; set; }
        public string BILHETE_SITUACAO { get; set; }
        public string BILHETE_TIP_CANCELAMENTO { get; set; }
        public string BILHETE_SIT_SINISTRO { get; set; }
        public string BILHETE_COD_USUARIO { get; set; }
        public string BILHETE_TIMESTAMP { get; set; }
        public string BILHETE_DATA_CANCELAMENTO { get; set; }
        public string VIND_NULL01 { get; set; }
        public string BILHETE_BI_FAIXA_RENDA_IND { get; set; }
        public string BILHETE_BI_FAIXA_RENDA_FAM { get; set; }
        public string WSHOST_NUMSIV01 { get; set; }
        public string WSHOST_NUMSIV02 { get; set; }

        public static R0430_00_SELECT_BILHETE_DB_SELECT_1_Query1 Execute(R0430_00_SELECT_BILHETE_DB_SELECT_1_Query1 r0430_00_SELECT_BILHETE_DB_SELECT_1_Query1)
        {
            var ths = r0430_00_SELECT_BILHETE_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0430_00_SELECT_BILHETE_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0430_00_SELECT_BILHETE_DB_SELECT_1_Query1();
            var i = 0;
            dta.BILHETE_NUM_BILHETE = result[i++].Value?.ToString();
            dta.BILHETE_NUM_APOLICE = result[i++].Value?.ToString();
            dta.BILHETE_FONTE = result[i++].Value?.ToString();
            dta.BILHETE_AGE_COBRANCA = result[i++].Value?.ToString();
            dta.BILHETE_NUM_MATRICULA = result[i++].Value?.ToString();
            dta.BILHETE_COD_AGENCIA = result[i++].Value?.ToString();
            dta.BILHETE_OPERACAO_CONTA = result[i++].Value?.ToString();
            dta.BILHETE_NUM_CONTA = result[i++].Value?.ToString();
            dta.BILHETE_DIG_CONTA = result[i++].Value?.ToString();
            dta.BILHETE_COD_CLIENTE = result[i++].Value?.ToString();
            dta.BILHETE_PROFISSAO = result[i++].Value?.ToString();
            dta.BILHETE_IDE_SEXO = result[i++].Value?.ToString();
            dta.BILHETE_ESTADO_CIVIL = result[i++].Value?.ToString();
            dta.BILHETE_OCORR_ENDERECO = result[i++].Value?.ToString();
            dta.BILHETE_COD_AGENCIA_DEB = result[i++].Value?.ToString();
            dta.BILHETE_OPERACAO_CONTA_DEB = result[i++].Value?.ToString();
            dta.BILHETE_NUM_CONTA_DEB = result[i++].Value?.ToString();
            dta.BILHETE_DIG_CONTA_DEB = result[i++].Value?.ToString();
            dta.BILHETE_OPC_COBERTURA = result[i++].Value?.ToString();
            dta.BILHETE_DATA_QUITACAO = result[i++].Value?.ToString();
            dta.BILHETE_VAL_RCAP = result[i++].Value?.ToString();
            dta.BILHETE_RAMO = result[i++].Value?.ToString();
            dta.BILHETE_DATA_VENDA = result[i++].Value?.ToString();
            dta.BILHETE_DATA_MOVIMENTO = result[i++].Value?.ToString();
            dta.BILHETE_NUM_APOL_ANTERIOR = result[i++].Value?.ToString();
            dta.BILHETE_SITUACAO = result[i++].Value?.ToString();
            dta.BILHETE_TIP_CANCELAMENTO = result[i++].Value?.ToString();
            dta.BILHETE_SIT_SINISTRO = result[i++].Value?.ToString();
            dta.BILHETE_COD_USUARIO = result[i++].Value?.ToString();
            dta.BILHETE_TIMESTAMP = result[i++].Value?.ToString();
            dta.BILHETE_DATA_CANCELAMENTO = result[i++].Value?.ToString();
            dta.VIND_NULL01 = string.IsNullOrWhiteSpace(dta.BILHETE_DATA_CANCELAMENTO) ? "-1" : "0";
            dta.BILHETE_BI_FAIXA_RENDA_IND = result[i++].Value?.ToString();
            dta.BILHETE_BI_FAIXA_RENDA_FAM = result[i++].Value?.ToString();
            return dta;
        }

    }
}