using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI9211B
{
    public class R1510_00_CONSULTA_SINI_DB_SELECT_1_Query1 : QueryBasis<R1510_00_CONSULTA_SINI_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT
            H.NOME_FAVORECIDO ,
            H.VAL_OPERACAO ,
            H.TIPO_FAVORECIDO ,
            H.DATA_NEGOCIADA ,
            H.FONTE_PAGAMENTO ,
            H.COD_PREST_SERVICO ,
            H.COD_SERVICO ,
            H.ORDEM_PAGAMENTO ,
            H.NUM_RECIBO ,
            H.NUM_MOV_SINISTRO ,
            H.SIT_CONTABIL ,
            H.SIT_REGISTRO ,
            H.COD_PRODUTO
            INTO
            :SINISHIS-NOME-FAVORECIDO ,
            :SINISHIS-VAL-OPERACAO ,
            :SINISHIS-TIPO-FAVORECIDO ,
            :SINISHIS-DATA-NEGOCIADA ,
            :SINISHIS-FONTE-PAGAMENTO ,
            :SINISHIS-COD-PREST-SERVICO,
            :SINISHIS-COD-SERVICO ,
            :SINISHIS-ORDEM-PAGAMENTO ,
            :SINISHIS-NUM-RECIBO ,
            :SINISHIS-NUM-MOV-SINISTRO ,
            :SINISHIS-SIT-CONTABIL ,
            :SINISHIS-SIT-REGISTRO ,
            :SINISHIS-COD-PRODUTO
            FROM SEGUROS.SINISTRO_HISTORICO H
            WHERE H.NUM_APOL_SINISTRO = :SIARDEVC-NUM-APOL-SINISTRO
            AND H.OCORR_HISTORICO = :SIARDEVC-OCORR-HISTORICO
            AND H.COD_OPERACAO = :SIARDEVC-COD-OPERACAO
            AND NOT EXISTS
            (SELECT H1.NUM_APOL_SINISTRO
            FROM SEGUROS.SINISTRO_HISTORICO H1
            WHERE H1.NUM_APOL_SINISTRO = H.NUM_APOL_SINISTRO
            AND H1.OCORR_HISTORICO = H.OCORR_HISTORICO
            AND H1.COD_OPERACAO IN (1091,1191,1050)
            )
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT
											H.NOME_FAVORECIDO 
							,
											H.VAL_OPERACAO 
							,
											H.TIPO_FAVORECIDO 
							,
											H.DATA_NEGOCIADA 
							,
											H.FONTE_PAGAMENTO 
							,
											H.COD_PREST_SERVICO 
							,
											H.COD_SERVICO 
							,
											H.ORDEM_PAGAMENTO 
							,
											H.NUM_RECIBO 
							,
											H.NUM_MOV_SINISTRO 
							,
											H.SIT_CONTABIL 
							,
											H.SIT_REGISTRO 
							,
											H.COD_PRODUTO
											FROM SEGUROS.SINISTRO_HISTORICO H
											WHERE H.NUM_APOL_SINISTRO = '{this.SIARDEVC_NUM_APOL_SINISTRO}'
											AND H.OCORR_HISTORICO = '{this.SIARDEVC_OCORR_HISTORICO}'
											AND H.COD_OPERACAO = '{this.SIARDEVC_COD_OPERACAO}'
											AND NOT EXISTS
											(SELECT H1.NUM_APOL_SINISTRO
											FROM SEGUROS.SINISTRO_HISTORICO H1
											WHERE H1.NUM_APOL_SINISTRO = H.NUM_APOL_SINISTRO
											AND H1.OCORR_HISTORICO = H.OCORR_HISTORICO
											AND H1.COD_OPERACAO IN (1091
							,1191
							,1050)
											)
											WITH UR";

            return query;
        }
        public string SINISHIS_NOME_FAVORECIDO { get; set; }
        public string SINISHIS_VAL_OPERACAO { get; set; }
        public string SINISHIS_TIPO_FAVORECIDO { get; set; }
        public string SINISHIS_DATA_NEGOCIADA { get; set; }
        public string SINISHIS_FONTE_PAGAMENTO { get; set; }
        public string SINISHIS_COD_PREST_SERVICO { get; set; }
        public string SINISHIS_COD_SERVICO { get; set; }
        public string SINISHIS_ORDEM_PAGAMENTO { get; set; }
        public string SINISHIS_NUM_RECIBO { get; set; }
        public string SINISHIS_NUM_MOV_SINISTRO { get; set; }
        public string SINISHIS_SIT_CONTABIL { get; set; }
        public string SINISHIS_SIT_REGISTRO { get; set; }
        public string SINISHIS_COD_PRODUTO { get; set; }
        public string SIARDEVC_NUM_APOL_SINISTRO { get; set; }
        public string SIARDEVC_OCORR_HISTORICO { get; set; }
        public string SIARDEVC_COD_OPERACAO { get; set; }

        public static R1510_00_CONSULTA_SINI_DB_SELECT_1_Query1 Execute(R1510_00_CONSULTA_SINI_DB_SELECT_1_Query1 r1510_00_CONSULTA_SINI_DB_SELECT_1_Query1)
        {
            var ths = r1510_00_CONSULTA_SINI_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1510_00_CONSULTA_SINI_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1510_00_CONSULTA_SINI_DB_SELECT_1_Query1();
            var i = 0;
            dta.SINISHIS_NOME_FAVORECIDO = result[i++].Value?.ToString();
            dta.SINISHIS_VAL_OPERACAO = result[i++].Value?.ToString();
            dta.SINISHIS_TIPO_FAVORECIDO = result[i++].Value?.ToString();
            dta.SINISHIS_DATA_NEGOCIADA = result[i++].Value?.ToString();
            dta.SINISHIS_FONTE_PAGAMENTO = result[i++].Value?.ToString();
            dta.SINISHIS_COD_PREST_SERVICO = result[i++].Value?.ToString();
            dta.SINISHIS_COD_SERVICO = result[i++].Value?.ToString();
            dta.SINISHIS_ORDEM_PAGAMENTO = result[i++].Value?.ToString();
            dta.SINISHIS_NUM_RECIBO = result[i++].Value?.ToString();
            dta.SINISHIS_NUM_MOV_SINISTRO = result[i++].Value?.ToString();
            dta.SINISHIS_SIT_CONTABIL = result[i++].Value?.ToString();
            dta.SINISHIS_SIT_REGISTRO = result[i++].Value?.ToString();
            dta.SINISHIS_COD_PRODUTO = result[i++].Value?.ToString();
            return dta;
        }

    }
}