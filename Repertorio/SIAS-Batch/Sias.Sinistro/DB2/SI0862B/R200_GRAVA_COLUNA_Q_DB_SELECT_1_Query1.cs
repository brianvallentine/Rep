using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI0862B
{
    public class R200_GRAVA_COLUNA_Q_DB_SELECT_1_Query1 : QueryBasis<R200_GRAVA_COLUNA_Q_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT VALUE(SUM(H.VAL_OPERACAO),0)
            INTO :HOST-VALOR
            FROM SEGUROS.SINISTRO_HISTORICO H
            WHERE H.COD_PRODUTO = 7105
            AND H.NUM_APOLICE = :HOST-APOLICE
            AND H.DATA_MOVIMENTO BETWEEN :HOST-DATA-INICIAL
            AND :HOST-DATA-FINAL
            AND H.COD_OPERACAO = 1070
            AND EXISTS
            (SELECT S.NUM_APOL_SINISTRO
            FROM SEGUROS.SINISTRO_HISTORICO S
            WHERE S.NUM_APOL_SINISTRO = H.NUM_APOL_SINISTRO
            AND S.OCORR_HISTORICO = H.OCORR_HISTORICO
            AND S.COD_OPERACAO = 1050)
            AND NOT EXISTS
            (SELECT S.NUM_APOL_SINISTRO
            FROM SEGUROS.SINISTRO_HISTORICO S
            WHERE S.NUM_APOL_SINISTRO = H.NUM_APOL_SINISTRO
            AND S.COD_OPERACAO IN (1003,1004)
            AND S.SIT_REGISTRO <> '2' )
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT VALUE(SUM(H.VAL_OPERACAO)
							,0)
											FROM SEGUROS.SINISTRO_HISTORICO H
											WHERE H.COD_PRODUTO = 7105
											AND H.NUM_APOLICE = '{this.HOST_APOLICE}'
											AND H.DATA_MOVIMENTO BETWEEN '{this.HOST_DATA_INICIAL}'
											AND '{this.HOST_DATA_FINAL}'
											AND H.COD_OPERACAO = 1070
											AND EXISTS
											(SELECT S.NUM_APOL_SINISTRO
											FROM SEGUROS.SINISTRO_HISTORICO S
											WHERE S.NUM_APOL_SINISTRO = H.NUM_APOL_SINISTRO
											AND S.OCORR_HISTORICO = H.OCORR_HISTORICO
											AND S.COD_OPERACAO = 1050)
											AND NOT EXISTS
											(SELECT S.NUM_APOL_SINISTRO
											FROM SEGUROS.SINISTRO_HISTORICO S
											WHERE S.NUM_APOL_SINISTRO = H.NUM_APOL_SINISTRO
											AND S.COD_OPERACAO IN (1003
							,1004)
											AND S.SIT_REGISTRO <> '2' )";

            return query;
        }
        public string HOST_VALOR { get; set; }
        public string HOST_DATA_INICIAL { get; set; }
        public string HOST_DATA_FINAL { get; set; }
        public string HOST_APOLICE { get; set; }

        public static R200_GRAVA_COLUNA_Q_DB_SELECT_1_Query1 Execute(R200_GRAVA_COLUNA_Q_DB_SELECT_1_Query1 r200_GRAVA_COLUNA_Q_DB_SELECT_1_Query1)
        {
            var ths = r200_GRAVA_COLUNA_Q_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R200_GRAVA_COLUNA_Q_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R200_GRAVA_COLUNA_Q_DB_SELECT_1_Query1();
            var i = 0;
            dta.HOST_VALOR = result[i++].Value?.ToString();
            return dta;
        }

    }
}