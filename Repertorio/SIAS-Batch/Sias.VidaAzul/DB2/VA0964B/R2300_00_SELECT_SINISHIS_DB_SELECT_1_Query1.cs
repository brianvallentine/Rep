using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0964B
{
    public class R2300_00_SELECT_SINISHIS_DB_SELECT_1_Query1 : QueryBasis<R2300_00_SELECT_SINISHIS_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT
            SUM (VAL_OPERACAO) AS VAL_TOT_PRE_LIB
            INTO
            :SINISHIS-VAL-OPERACAO
            FROM
            SEGUROS.SINISTRO_HISTORICO
            WHERE
            NUM_APOL_SINISTRO = :SINISHIS-NUM-APOL-SINISTRO
            AND COD_OPERACAO IN (1181, 1182, 1183, 1184)
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT
											SUM (VAL_OPERACAO) AS VAL_TOT_PRE_LIB
											FROM
											SEGUROS.SINISTRO_HISTORICO
											WHERE
											NUM_APOL_SINISTRO = '{this.SINISHIS_NUM_APOL_SINISTRO}'
											AND COD_OPERACAO IN (1181
							, 1182
							, 1183
							, 1184)";

            return query;
        }
        public string SINISHIS_VAL_OPERACAO { get; set; }
        public string SINISHIS_NUM_APOL_SINISTRO { get; set; }

        public static R2300_00_SELECT_SINISHIS_DB_SELECT_1_Query1 Execute(R2300_00_SELECT_SINISHIS_DB_SELECT_1_Query1 r2300_00_SELECT_SINISHIS_DB_SELECT_1_Query1)
        {
            var ths = r2300_00_SELECT_SINISHIS_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R2300_00_SELECT_SINISHIS_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R2300_00_SELECT_SINISHIS_DB_SELECT_1_Query1();
            var i = 0;
            dta.SINISHIS_VAL_OPERACAO = result[i++].Value?.ToString();
            return dta;
        }

    }
}