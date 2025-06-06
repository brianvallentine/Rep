using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0965B
{
    public class R1400_00_SELECT_SINISHIS_DB_SELECT_1_Query1 : QueryBasis<R1400_00_SELECT_SINISHIS_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT
            VAL_OPERACAO AS VAL_AVISADO
            INTO
            :SINISHIS-VAL-OPERACAO
            FROM
            SEGUROS.SINISTRO_HISTORICO
            WHERE
            NUM_APOL_SINISTRO = :SINISHIS-NUM-APOL-SINISTRO
            AND COD_OPERACAO = 101
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT
											VAL_OPERACAO AS VAL_AVISADO
											FROM
											SEGUROS.SINISTRO_HISTORICO
											WHERE
											NUM_APOL_SINISTRO = '{this.SINISHIS_NUM_APOL_SINISTRO}'
											AND COD_OPERACAO = 101";

            return query;
        }
        public string SINISHIS_VAL_OPERACAO { get; set; }
        public string SINISHIS_NUM_APOL_SINISTRO { get; set; }

        public static R1400_00_SELECT_SINISHIS_DB_SELECT_1_Query1 Execute(R1400_00_SELECT_SINISHIS_DB_SELECT_1_Query1 r1400_00_SELECT_SINISHIS_DB_SELECT_1_Query1)
        {
            var ths = r1400_00_SELECT_SINISHIS_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1400_00_SELECT_SINISHIS_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1400_00_SELECT_SINISHIS_DB_SELECT_1_Query1();
            var i = 0;
            dta.SINISHIS_VAL_OPERACAO = result[i++].Value?.ToString();
            return dta;
        }

    }
}