using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0970B
{
    public class R2100_00_SELECT_SINISHIS_DB_SELECT_1_Query1 : QueryBasis<R2100_00_SELECT_SINISHIS_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT
            VALUE(SUM(A.VAL_OPERACAO),0) AS VAL_TOT_PRE_LIB
            INTO
            :SINISHIS-VAL-OPERACAO
            FROM
            SEGUROS.SINISTRO_HISTORICO A
            WHERE
            A.NUM_APOL_SINISTRO = :SINISHIS-NUM-APOL-SINISTRO
            AND A.COD_OPERACAO IN (1181, 1182, 1183, 1184)
            AND NOT EXISTS (
            SELECT NUM_APOL_SINISTRO
            FROM SEGUROS.SINISTRO_HISTORICO B
            WHERE B.NUM_APOL_SINISTRO = A.NUM_APOL_SINISTRO
            AND B.COD_OPERACAO = A.COD_OPERACAO + 10
            AND B.OCORR_HISTORICO = A.OCORR_HISTORICO)
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT
											VALUE(SUM(A.VAL_OPERACAO)
							,0) AS VAL_TOT_PRE_LIB
											FROM
											SEGUROS.SINISTRO_HISTORICO A
											WHERE
											A.NUM_APOL_SINISTRO = '{this.SINISHIS_NUM_APOL_SINISTRO}'
											AND A.COD_OPERACAO IN (1181
							, 1182
							, 1183
							, 1184)
											AND NOT EXISTS (
											SELECT NUM_APOL_SINISTRO
											FROM SEGUROS.SINISTRO_HISTORICO B
											WHERE B.NUM_APOL_SINISTRO = A.NUM_APOL_SINISTRO
											AND B.COD_OPERACAO = A.COD_OPERACAO + 10
											AND B.OCORR_HISTORICO = A.OCORR_HISTORICO)";

            return query;
        }
        public string SINISHIS_VAL_OPERACAO { get; set; }
        public string SINISHIS_NUM_APOL_SINISTRO { get; set; }

        public static R2100_00_SELECT_SINISHIS_DB_SELECT_1_Query1 Execute(R2100_00_SELECT_SINISHIS_DB_SELECT_1_Query1 r2100_00_SELECT_SINISHIS_DB_SELECT_1_Query1)
        {
            var ths = r2100_00_SELECT_SINISHIS_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R2100_00_SELECT_SINISHIS_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R2100_00_SELECT_SINISHIS_DB_SELECT_1_Query1();
            var i = 0;
            dta.SINISHIS_VAL_OPERACAO = result[i++].Value?.ToString();
            return dta;
        }

    }
}