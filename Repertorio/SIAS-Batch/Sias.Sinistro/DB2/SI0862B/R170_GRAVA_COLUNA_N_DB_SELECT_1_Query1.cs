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
    public class R170_GRAVA_COLUNA_N_DB_SELECT_1_Query1 : QueryBasis<R170_GRAVA_COLUNA_N_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT VALUE(SUM(H.VAL_OPERACAO),0)
            INTO :HOST-VALOR
            FROM SEGUROS.SINI_LOTERICO01 SL,
            SEGUROS.SINISTRO_HISTORICO H
            WHERE H.DATA_MOVIMENTO BETWEEN :HOST-DATA-INICIAL
            AND :HOST-DATA-FINAL
            AND H.COD_OPERACAO = 101
            AND H.NUM_APOLICE = :HOST-APOLICE
            AND SL.NUM_APOL_SINISTRO = H.NUM_APOL_SINISTRO
            AND SL.COD_COBERTURA = 4
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT VALUE(SUM(H.VAL_OPERACAO)
							,0)
											FROM SEGUROS.SINI_LOTERICO01 SL
							,
											SEGUROS.SINISTRO_HISTORICO H
											WHERE H.DATA_MOVIMENTO BETWEEN '{this.HOST_DATA_INICIAL}'
											AND '{this.HOST_DATA_FINAL}'
											AND H.COD_OPERACAO = 101
											AND H.NUM_APOLICE = '{this.HOST_APOLICE}'
											AND SL.NUM_APOL_SINISTRO = H.NUM_APOL_SINISTRO
											AND SL.COD_COBERTURA = 4";

            return query;
        }
        public string HOST_VALOR { get; set; }
        public string HOST_DATA_INICIAL { get; set; }
        public string HOST_DATA_FINAL { get; set; }
        public string HOST_APOLICE { get; set; }

        public static R170_GRAVA_COLUNA_N_DB_SELECT_1_Query1 Execute(R170_GRAVA_COLUNA_N_DB_SELECT_1_Query1 r170_GRAVA_COLUNA_N_DB_SELECT_1_Query1)
        {
            var ths = r170_GRAVA_COLUNA_N_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R170_GRAVA_COLUNA_N_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R170_GRAVA_COLUNA_N_DB_SELECT_1_Query1();
            var i = 0;
            dta.HOST_VALOR = result[i++].Value?.ToString();
            return dta;
        }

    }
}