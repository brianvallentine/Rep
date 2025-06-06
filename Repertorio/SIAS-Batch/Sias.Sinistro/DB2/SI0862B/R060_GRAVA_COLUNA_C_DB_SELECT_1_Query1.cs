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
    public class R060_GRAVA_COLUNA_C_DB_SELECT_1_Query1 : QueryBasis<R060_GRAVA_COLUNA_C_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT VALUE(COUNT(DISTINCT M.NUM_APOL_SINISTRO),0)
            INTO :HOST-QTDE
            FROM SEGUROS.SINISTRO_MESTRE M,
            SEGUROS.SINI_LOTERICO01 SL,
            SEGUROS.SINISTRO_HISTORICO H
            WHERE M.COD_PRODUTO = 7105
            AND M.NUM_APOLICE = :HOST-APOLICE
            AND M.NUM_APOL_SINISTRO = H.NUM_APOL_SINISTRO
            AND M.NUM_APOL_SINISTRO = SL.NUM_APOL_SINISTRO
            AND SL.COD_COBERTURA = 4
            AND M.COD_CAUSA = 31
            AND H.COD_OPERACAO IN (1003,1004)
            AND H.DATA_MOVIMENTO BETWEEN :HOST-DATA-INICIAL
            AND :HOST-DATA-FINAL
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT VALUE(COUNT(DISTINCT M.NUM_APOL_SINISTRO)
							,0)
											FROM SEGUROS.SINISTRO_MESTRE M
							,
											SEGUROS.SINI_LOTERICO01 SL
							,
											SEGUROS.SINISTRO_HISTORICO H
											WHERE M.COD_PRODUTO = 7105
											AND M.NUM_APOLICE = '{this.HOST_APOLICE}'
											AND M.NUM_APOL_SINISTRO = H.NUM_APOL_SINISTRO
											AND M.NUM_APOL_SINISTRO = SL.NUM_APOL_SINISTRO
											AND SL.COD_COBERTURA = 4
											AND M.COD_CAUSA = 31
											AND H.COD_OPERACAO IN (1003
							,1004)
											AND H.DATA_MOVIMENTO BETWEEN '{this.HOST_DATA_INICIAL}'
											AND '{this.HOST_DATA_FINAL}'";

            return query;
        }
        public string HOST_QTDE { get; set; }
        public string HOST_DATA_INICIAL { get; set; }
        public string HOST_DATA_FINAL { get; set; }
        public string HOST_APOLICE { get; set; }

        public static R060_GRAVA_COLUNA_C_DB_SELECT_1_Query1 Execute(R060_GRAVA_COLUNA_C_DB_SELECT_1_Query1 r060_GRAVA_COLUNA_C_DB_SELECT_1_Query1)
        {
            var ths = r060_GRAVA_COLUNA_C_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R060_GRAVA_COLUNA_C_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R060_GRAVA_COLUNA_C_DB_SELECT_1_Query1();
            var i = 0;
            dta.HOST_QTDE = result[i++].Value?.ToString();
            return dta;
        }

    }
}